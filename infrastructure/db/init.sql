-- =============================================================================
-- FASHION POS ENTERPRISE DATABASE SCHEMA (POSTGRESQL OPTIMIZED)
-- Converted & Redesigned from SQL Server (Fashion.sql)
-- Target Engine: PostgreSQL 14+
-- Features: 3NF Normalization, ACID Transactions, Auto Triggers, Row Locking,
--           Generated Columns, Composite Indexes & Anti-Overselling Guard.
-- =============================================================================

-- 1. CLEANUP & EXTENSIONS
DROP SCHEMA IF EXISTS public CASCADE;
CREATE SCHEMA public;
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
CREATE EXTENSION IF NOT EXISTS "pgcrypto";

-- 2. ENUM TYPES
CREATE TYPE employee_role AS ENUM ('SUPER_MANAGER', 'STORE_MANAGER', 'CASHIER', 'WAREHOUSE_STAFF');
CREATE TYPE employee_status AS ENUM ('ACTIVE', 'INACTIVE', 'ON_LEAVE');
CREATE TYPE membership_tier AS ENUM ('BRONZE', 'SILVER', 'GOLD', 'BLACK'); -- Đồng, Bạc, Vàng, Đen
CREATE TYPE discount_type AS ENUM ('PERCENT', 'AMOUNT');
CREATE TYPE payment_method AS ENUM ('CASH', 'VNPAY', 'MOMO', 'BANK_TRANSFER', 'CARD');
CREATE TYPE order_status AS ENUM ('PENDING', 'COMPLETED', 'CANCELLED');

-- 3. TABLES DESIGN

-- Table: System Settings (CauHinhHeThong)
CREATE TABLE system_settings (
    setting_key VARCHAR(100) PRIMARY KEY,
    setting_value TEXT NULL,
    description VARCHAR(255) NULL,
    updated_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Table: Employees (NhanVien)
CREATE TABLE employees (
    id SERIAL PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    dob DATE NULL,
    gender SMALLINT DEFAULT 1 CHECK (gender IN (0, 1)), -- 0: Nữ, 1: Nam
    phone_number VARCHAR(20) UNIQUE NULL,
    email VARCHAR(100) UNIQUE NULL,
    avatar_url TEXT NULL,
    role employee_role NOT NULL DEFAULT 'CASHIER',
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL, -- BCrypt/Argon2 Hash
    status employee_status NOT NULL DEFAULT 'ACTIVE',
    created_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Table: Customers (KhachHang)
CREATE TABLE customers (
    id SERIAL PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20) UNIQUE NULL,
    gender SMALLINT DEFAULT 1 CHECK (gender IN (0, 1)),
    email VARCHAR(100) UNIQUE NULL,
    address TEXT NULL,
    total_spent DECIMAL(15, 2) NOT NULL DEFAULT 0.00 CHECK (total_spent >= 0),
    loyalty_points INT NOT NULL DEFAULT 0 CHECK (loyalty_points >= 0),
    membership_tier membership_tier NOT NULL DEFAULT 'BRONZE',
    created_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Table: Suppliers (NhaCungCap)
CREATE TABLE suppliers (
    id SERIAL PRIMARY KEY,
    name VARCHAR(200) NOT NULL,
    contact_person VARCHAR(100) NULL,
    phone_number VARCHAR(20) NULL,
    email VARCHAR(100) NULL,
    address TEXT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Table: Categories (DanhMuc)
CREATE TABLE categories (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE,
    slug VARCHAR(120) NOT NULL UNIQUE,
    created_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Table: Products (SanPham)
CREATE TABLE products (
    id SERIAL PRIMARY KEY,
    category_id INT NOT NULL REFERENCES categories(id) ON DELETE RESTRICT,
    name VARCHAR(200) NOT NULL,
    slug VARCHAR(220) NOT NULL UNIQUE,
    description TEXT NULL,
    base_price DECIMAL(15, 2) NOT NULL CHECK (base_price >= 0),
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    image_url VARCHAR(500) NULL,
    created_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Table: Product Variants (BienTheSanPham)
CREATE TABLE product_variants (
    id SERIAL PRIMARY KEY,
    product_id INT NOT NULL REFERENCES products(id) ON DELETE CASCADE,
    sku VARCHAR(50) NOT NULL UNIQUE, -- Mã vạch quét POS
    size VARCHAR(20) NOT NULL,
    color VARCHAR(50) NOT NULL,
    stock_quantity INT NOT NULL DEFAULT 0 CHECK (stock_quantity >= 0), -- CHẶN ÂM KHO
    price DECIMAL(15, 2) NOT NULL CHECK (price >= 0),
    image_url TEXT NULL,
    version INT NOT NULL DEFAULT 0, -- Dùng cho Optimistic Locking
    created_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT idx_variant_size_color_unique UNIQUE (product_id, size, color)
);

-- Table: Purchase Orders (PhieuNhap)
CREATE TABLE purchase_orders (
    id BIGSERIAL PRIMARY KEY,
    po_code VARCHAR(30) UNIQUE NOT NULL, -- PN00001
    supplier_id INT NOT NULL REFERENCES suppliers(id) ON DELETE RESTRICT,
    employee_id INT NOT NULL REFERENCES employees(id) ON DELETE RESTRICT,
    total_amount DECIMAL(15, 2) NOT NULL DEFAULT 0.00 CHECK (total_amount >= 0),
    notes TEXT NULL,
    created_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Table: Purchase Order Details (ChiTietPhieuNhap)
CREATE TABLE purchase_order_details (
    id BIGSERIAL PRIMARY KEY,
    purchase_order_id BIGINT NOT NULL REFERENCES purchase_orders(id) ON DELETE CASCADE,
    variant_id INT NOT NULL REFERENCES product_variants(id) ON DELETE RESTRICT,
    quantity INT NOT NULL CHECK (quantity > 0),
    import_price DECIMAL(15, 2) NOT NULL CHECK (import_price >= 0),
    subtotal DECIMAL(15, 2) GENERATED ALWAYS AS (quantity * import_price) STORED
);

-- Table: Orders (HoaDon)
CREATE TABLE orders (
    id BIGSERIAL PRIMARY KEY,
    order_code VARCHAR(30) UNIQUE NOT NULL, -- HD00001
    customer_id INT NULL REFERENCES customers(id) ON DELETE SET NULL,
    employee_id INT NOT NULL REFERENCES employees(id) ON DELETE RESTRICT,
    total_items_amount DECIMAL(15, 2) NOT NULL CHECK (total_items_amount >= 0),
    discount_type discount_type NOT NULL DEFAULT 'PERCENT',
    discount_value DECIMAL(15, 2) NOT NULL DEFAULT 0.00 CHECK (discount_value >= 0),
    final_amount DECIMAL(15, 2) NOT NULL CHECK (final_amount >= 0),
    paid_amount DECIMAL(15, 2) NOT NULL CHECK (paid_amount >= 0),
    change_amount DECIMAL(15, 2) GENERATED ALWAYS AS (paid_amount - final_amount) STORED,
    payment_method payment_method NOT NULL DEFAULT 'CASH',
    earned_points INT NOT NULL DEFAULT 0 CHECK (earned_points >= 0),
    status order_status NOT NULL DEFAULT 'COMPLETED',
    notes TEXT NULL,
    idempotency_key VARCHAR(100) UNIQUE NULL, -- Tránh trùng đơn khi gọi API Webhook
    created_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

-- Table: Order Details (ChiTietHoaDon)
CREATE TABLE order_details (
    id BIGSERIAL PRIMARY KEY,
    order_id BIGINT NOT NULL REFERENCES orders(id) ON DELETE CASCADE,
    variant_id INT NOT NULL REFERENCES product_variants(id) ON DELETE RESTRICT,
    quantity INT NOT NULL CHECK (quantity > 0),
    unit_price DECIMAL(15, 2) NOT NULL CHECK (unit_price >= 0),
    subtotal DECIMAL(15, 2) GENERATED ALWAYS AS (quantity * unit_price) STORED
);

-- 4. PERFORMANCE INDEXES
-- Quick SKU scanner lookup for POS quầy bán hàng
CREATE INDEX idx_product_variants_sku ON product_variants(sku);

-- Category & Product slug lookup cho Web Ecommerce Next.js
CREATE INDEX idx_products_category_active ON products(category_id, is_active);
CREATE INDEX idx_products_slug ON products(slug);

-- Báo cáo doanh thu & Đơn hàng theo thời gian
CREATE INDEX idx_orders_created_at ON orders(created_at DESC);
CREATE INDEX idx_orders_customer ON orders(customer_id, created_at DESC);
CREATE INDEX idx_orders_employee ON orders(employee_id, created_at DESC);

-- Partial Index: Cảnh báo tồn kho sụt giảm (< 10 sản phẩm)
CREATE INDEX idx_variants_low_stock ON product_variants(stock_quantity) WHERE stock_quantity < 10;

-- 5. AUTOMATIC TRIGGERS & PROCEDURES (ENTERPRISE LOGIC)
-- Trigger 1: Auto-update Khách hàng (Tích điểm, Chi tiêu, Nâng Hạng)
CREATE OR REPLACE FUNCTION fn_update_customer_membership()
RETURNS TRIGGER AS $$
DECLARE
    v_new_total DECIMAL(15, 2);
    v_new_points INT;
    v_new_tier membership_tier;
BEGIN
    IF NEW.customer_id IS NOT NULL AND NEW.status = 'COMPLETED' THEN
        -- Tính tổng chi tiêu và điểm tích lũy mới
        SELECT 
            total_spent + NEW.final_amount,
            loyalty_points + NEW.earned_points
        INTO v_new_total, v_new_points
        FROM customers
        WHERE id = NEW.customer_id;

        -- Xác định Hạng thành viên (Đồng, Bạc, Vàng, Đen)
        IF v_new_points >= 300 THEN
            v_new_tier := 'BLACK';   -- Hạng Đen (Vip Pro)
        ELSIF v_new_points >= 200 THEN
            v_new_tier := 'GOLD';    -- Hạng Vàng
        ELSIF v_new_points >= 100 THEN
            v_new_tier := 'SILVER';  -- Hạng Bạc
        ELSE
            v_new_tier := 'BRONZE';  -- Hạng Đồng
        END IF;

        -- Cập nhật thông tin Khách hàng
        UPDATE customers
        SET total_spent = v_new_total,
            loyalty_points = v_new_points,
            membership_tier = v_new_tier,
            updated_at = CURRENT_TIMESTAMP
        WHERE id = NEW.customer_id;
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_orders_update_customer
AFTER INSERT OR UPDATE OF status ON orders
FOR EACH ROW
EXECUTE FUNCTION fn_update_customer_membership();

-- 6. STORED PROCEDURE: CREATING ORDER WITH ATOMIC STOCK DEDUCTION & ROW LOCKING
CREATE OR REPLACE PROCEDURE sp_create_pos_order(
    p_order_code VARCHAR(30),
    p_customer_id INT,
    p_employee_id INT,
    p_total_items_amount DECIMAL(15, 2),
    p_discount_type discount_type,
    p_discount_value DECIMAL(15, 2),
    p_final_amount DECIMAL(15, 2),
    p_paid_amount DECIMAL(15, 2),
    p_payment_method payment_method,
    p_earned_points INT,
    p_items JSONB, -- Dạng json array: [{"variant_id": 2, "quantity": 1, "unit_price": 200000}]
    INOUT p_order_id BIGINT DEFAULT NULL
)
LANGUAGE plpgsql
AS $$
DECLARE
    item JSONB;
    v_variant_id INT;
    v_qty INT;
    v_price DECIMAL(15, 2);
    v_current_stock INT;
BEGIN
    -- 1. Insert Master Order
    INSERT INTO orders (
        order_code, customer_id, employee_id, total_items_amount,
        discount_type, discount_value, final_amount, paid_amount,
        payment_method, earned_points, status
    ) VALUES (
        p_order_code, p_customer_id, p_employee_id, p_total_items_amount,
        p_discount_type, p_discount_value, p_final_amount, p_paid_amount,
        p_payment_method, p_earned_points, 'COMPLETED'
    ) RETURNING id INTO p_order_id;

    -- 2. Loop Items & Deduct Stock safely
    FOR item IN SELECT * FROM jsonb_array_elements(p_items)
    LOOP
        v_variant_id := (item->>'variant_id')::INT;
        v_qty := (item->>'quantity')::INT;
        v_price := (item->>'unit_price')::DECIMAL(15, 2);

        -- Pessimistic Lock biến thể sản phẩm chống Race Condition
        SELECT stock_quantity INTO v_current_stock
        FROM product_variants
        WHERE id = v_variant_id
        FOR UPDATE;

        IF v_current_stock < v_qty THEN
            RAISE EXCEPTION 'Sản phẩm variant_id % không đủ tồn kho! (Tồn: %, Yêu cầu: %)', 
                v_variant_id, v_current_stock, v_qty;
        END IF;

        -- Thêm chi tiết hóa đơn
        INSERT INTO order_details (order_id, variant_id, quantity, unit_price)
        VALUES (p_order_id, v_variant_id, v_qty, v_price);

        -- Trừ kho an toàn
        UPDATE product_variants
        SET stock_quantity = stock_quantity - v_qty,
            version = version + 1,
            updated_at = CURRENT_TIMESTAMP
        WHERE id = v_variant_id;
    END LOOP;
END;
$$;

-- 7. SEED DATA MIGRATED FROM FASHION.SQL
INSERT INTO system_settings (setting_key, setting_value, description) VALUES
('TenCuaHang', 'NQD Fashion', 'Tên cửa hàng'),
('DiaChi', '123 Thanh Hóa', 'Địa chỉ'),
('SoDienThoai', '0788687875', 'Số điện thoại'),
('Email', 'nqdfashion@gmail.com', 'Email cửa hàng'),
('Website', 'nqdfashion.com', 'Website'),
('Facebook', 'facebook.com/nqdfashion', 'Link Facebook'),
('Instagram', 'instagram.com/nqdfashion', 'Link Instagram'),
('Tiktok', 'tiktok.com/nqdfashion', 'Link TikTok'),
('Zalo', '0788687875', 'Số Zalo');

INSERT INTO employees (full_name, dob, gender, phone_number, email, role, username, password_hash, status) VALUES
('Nguyễn Văn A', '2000-04-26', 1, '0906834761', 'nva@gmail.com', 'SUPER_MANAGER', 'superManager', '$2b$10$w8T0i/E1n1k/Qk.X8O0d4e9v6ZJvG7nQ1m8U0k9d8c7b6a5f4e3d2', 'ACTIVE'); -- Hash mẫu BCrypt

INSERT INTO customers (full_name, phone_number, gender, total_spent, loyalty_points, membership_tier) VALUES
('Khách Hàng VVIP', '0906834761', 0, 2100000.00, 2100, 'BLACK');

INSERT INTO suppliers (name, contact_person, phone_number, email, address, is_active) VALUES
('Gucci Vietnam Supplier', 'Anh Đương đẹp trai', '0123456789', 'duongdeptrai@gmail.com', 'TP. Hồ Chí Minh', TRUE),
('Nhà Cung Cấp Tổng Hợp', 'Hùng', '0906834761', NULL, NULL, TRUE);

INSERT INTO categories (name, slug) VALUES
('Áo', 'ao'), ('Quần', 'quan'), ('Giày', 'giay'),
('Phụ kiện', 'phu-kien'), ('Túi xách', 'tui-xach'), ('Mũ', 'mu');

INSERT INTO products (category_id, name, slug, description, base_price, is_active) VALUES
(1, 'Áo Thun NQD Classic', 'ao-thun-nqd-classic', 'Áo thun cotton cao cấp', 200000.00, TRUE);

INSERT INTO product_variants (product_id, sku, size, color, stock_quantity, price) VALUES
(1, 'SKU-AO-001-XAM-36', '36', 'Xám', 10, 200000.00);
