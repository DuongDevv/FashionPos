# 🛒 FASHIONPOS ENTERPRISE PLATFORM

> **Legacy System Migration**: Tái cấu trúc và nâng cấp toàn bộ hệ thống bán hàng quầy FashionPOS cũ (từ C# WinForms / SQL Server 2-tier) lên **Nền tảng Web POS Enterprise 3-tier (C# .NET 8 Web API + PostgreSQL 16 + Redis 7 + Next.js 16 App Router)**.

---

## 🌟 TÍNH NĂNG NỔI BẬT (KEY FEATURES)

### 1. 🛒 Bán Hàng Tại Quầy (POS Terminal)
- **Quét Mã Vạch SKU Tốc Độ Cao**: Tra cứu sản phẩm theo mã vạch SKU trong DB PostgreSQL với độ trễ `< 5ms`.
- **Giỏ Hàng Thực Thời**: Tự động tính tiền, áp mã giảm giá, kiểm tra giới hạn tồn kho DB không cho bán vượt quá số lượng trong kho.
- **Tính Tiền Khách Đưa & Tiền Thối**: Hỗ trợ nhiều phương thức (Tiền mặt, VNPAY, Momo, Chuyển khoản), tính tiền thối tự động.
- **In Hóa Đơn (Receipt Modal)**: Hiển thị hóa đơn mã `HD...`, chi tiết đơn hàng, tiền thối và điểm thưởng được cộng.

### 2. 📱 TRA CỨU SĐT KHÁCH HÀNG & TÍCH ĐIỂM TỰ ĐỘNG
- **Tra Cứu Khách Hàng Bằng SĐT**: Nhập số điện thoại khách hàng trực tiếp trên màn hình POS để hiển thị Tên, Điểm hiện có, Tổng chi tiêu và Hạng thẻ (Đồng, Bạc, Vàng, Đen VVIP).
- **Đăng Ký Thành Viên Mới Nhanh Tại Quầy**: Nếu SĐT chưa đăng ký, hệ thống nổ Modal đăng ký mới 1-click và tự động gán ngay khách hàng mới vào đơn hàng hiện tại!
- **Tự Động Nâng Hạng Thành Viên**: PostgreSQL Trigger tự động cộng điểm (`10.000đ = 1 điểm`) và tự động nâng hạng thẻ ngay khi thanh toán đơn hàng.

### 3. 🛡️ BẢO MẬT & PHÂN QUYỀN NHÂN VIÊN (SECURITY & AUTH)
- **Mã Hóa Mật Khẩu BCrypt**: Bảo mật thông tin tài khoản nhân viên.
- **Xác Thực JWT Token**: Sinh JWT Access Token chứa Claims (`employeeId`, `fullName`, `role`).
- **Phân Quyền Vai Trò (RBAC)**: `SUPER_MANAGER`, `STORE_MANAGER`, `CASHIER`, `WAREHOUSE_STAFF`.

### 4. 📦 QUẢN LÝ SẢN PHẨM & KHO HÀNG (INVENTORY ENGINE)
- **Anti-Overselling Guard**: Chặn tồn kho âm ở cả tầng DB constraint (`CHECK stock_quantity >= 0`) và EF Core DbTransaction.
- **Thêm Sản Phẩm Mới & SKU**: Modal form thêm sản phẩm, mã vạch SKU, Size, Màu sắc và Tồn kho ban đầu.

### 5. 📊 DASHBOARD & BÁO CÁO DOANH THU
- Thống kê doanh thu hôm nay, tổng đơn hàng POS, số lượng khách VVIP và cảnh báo biến thể sản phẩm sụt giảm tồn kho (`< 10`).

---

## 🛠️ TECH STACK BLUEPRINT

| Thành phần | Công nghệ lựa chọn | Ghi chú kỹ thuật |
| :--- | :--- | :--- |
| **Backend API** | **C# .NET 8 Web API** | Entity Framework Core 8, Npgsql DataSource Enum Translator, Swagger OpenAPI, BCrypt, JWT |
| **Primary Database** | **PostgreSQL 16** | ACID Transactions, Stored Procedures, Triggers tự động tích điểm, Composite Indexes |
| **In-Memory Cache** | **Redis 7** | In-memory Distributed Lock & Cache Layer |
| **Frontend Web** | **Next.js 16 (App Router)** | React 19, TypeScript, Tailwind CSS (Tông màu Royal Blue `#2161D9`), Lucide Icons |
| **Container & DevOps** | **Docker & Nginx** | Multi-stage Dockerfile (~120MB), Docker Compose, Next.js Server Proxy Rewrites |

---

## 🏗️ CẤU TRÚC DỰ ÁN (MONOREPO ARCHITECTURE)

```
FashionPos/
├── apps/
│   ├── api/                 # Backend REST API Server (C# .NET 8 Web API)
│   │   └── FashionPos.Api/
│   │       ├── Controllers/ # Auth, Orders, Products, Variants, Customers, Employees
│   │       ├── Data/        # EF Core DbContext & PostgreSQL Enum Mappings
│   │       ├── DTOs/        # Data Transfer Objects
│   │       └── Services/    # Order Creation ACID Transaction Service
│   └── web/                 # Frontend POS Web Application (Next.js 16)
│       ├── src/app/         # App Router: /pos, /dashboard, /products, /customers, /staff, /settings, /login
│       └── src/components/  # Navigation Sidebar & Enterprise UI Components (Button, Badge, Input, Card)
├── infrastructure/          # Cấu hình Docker PostgreSQL, Redis, Nginx & SQL Scripts
│   ├── db/                  # init.sql (PostgreSQL Enterprise Schema & Seed Data)
│   └── nginx/               # nginx.conf (Reverse Proxy & Security Headers)
├── legacy_winforms/         # Code WinForms C# cũ (Lưu kỷ niệm & đối chiếu nghiệp vụ)
├── docs/                    # Tài liệu ERD & Đồ án gốc
├── start.sh                 # Script 1-click kích hoạt toàn bộ hệ thống
├── stop.sh                  # Script 1-click tắt an toàn hệ thống
└── status.sh                # Script kiểm tra sức khỏe 4 tầng ứng dụng
```

---

## 🚀 HƯỚNG DẪN CÀI ĐẶT & CHẠY ỨNG DỤNG WEB POS ENTERPRISE

### 📋 Yêu Cầu Môi Trường:
- **Node.js**: v18+ (Đã test mượt trên Node.js v26)
- **.NET SDK**: .NET 8 SDK
- **Docker & Docker Compose**: Để chạy PostgreSQL 16 & Redis 7

### 1️⃣ Bước 1: Clone Repository Về Máy
```bash
git clone https://github.com/DuongDevv/FashionPos.git
cd FashionPos
```

### 2️⃣ Bước 2: Kích Hoạt 1-Click Startup Script (Bản Web Enterprise)
Chạy duy nhất 1 lệnh duy nhất để tự động bật Docker Database, Backend .NET 8 API và Frontend Next.js Web:

```bash
chmod +x start.sh stop.sh status.sh
./start.sh
```

*(Script sẽ tự động dựng Docker PostgreSQL 16 (Port 5434), Redis 7 (Port 6381), Server .NET 8 (Port 5000) và Web POS (Port 3001)!)*

### 3️⃣ Bước 3: Truy Cập Ứng Dụng Trên Trình Duyệt
- 🛒 **Web POS Bán Hàng**: [`http://localhost:3001/pos`](http://localhost:3001/pos)
- 🔑 **Trang Đăng Nhập**: [`http://localhost:3001/login`](http://localhost:3001/login)
- 📊 **Dashboard Doanh Thu**: [`http://localhost:3001/dashboard`](http://localhost:3001/dashboard)
- 🌐 **Swagger API Documentation**: [`http://localhost:5000/swagger`](http://localhost:5000/swagger)

---

## 💻 HƯỚNG DẪN CHẠY BẢN LEGACY C# WINFORMS CŨ (NẾU CẦN ĐỐI CHIẾU)

Nếu bạn muốn mở và chạy thử bản desktop **C# WinForms cũ** trong thư mục `legacy_winforms/`:

### 📋 Yêu Cầu Môi Trường WinForms:
- Hệ điều hành Windows
- **Visual Studio 2019 / 2022** (Đã cài workload `.NET Desktop Development`)
- **SQL Server** (SQL Server Express / Enterprise) & SSMS (SQL Server Management Studio)

### 🛠️ Các Bước Thực Hiện:
1. **Phục hồi Cơ sở dữ liệu SQL Server**:
   - Mở SSMS, tạo mới Database tên `FashionPOS`.
   - Mở file SQL `infrastructure/db/Fashion.sql` và bấm **Execute** để tạo bảng và dữ liệu mẫu.
2. **Cấu hình Chuỗi Kết Nối (Connection String)**:
   - Mở file `legacy_winforms/Source_FashionPos/DAL/DataHelper.cs` (hoặc `App.config`).
   - Cập nhật chuỗi kết nối SQL Server của máy bạn: `Server=.\SQLEXPRESS;Database=FashionPOS;Trusted_Connection=True;`.
3. **Mở Solution và Chạy Ứng Dụng**:
   - Mở file `legacy_winforms/Source_FashionPos/WindowsFormsApp1.sln` bằng Visual Studio.
   - Nhấn **F5** để Build và chạy phần mềm WinForms Desktop.

---

## 🔑 TÀI KHOẢN & DỮ LIỆU THỬ NGHIỆM (DEMO CREDENTIALS)

- **Tài khoản Quản Trị**: `superManager` / Mật khẩu: `123456`
- **Số Điện Thoại Tích Điểm Demo**: `0906834761` (Khách Hàng VVIP - Hạng Đen)
- **Mã Vạch SKU Test Quét POS**: `SKU-AO-001-XAM-36` (Áo Thun NQD Classic)

---

## 🛠️ CÁC LỆNH ĐIỀU KHIỂN HỆ THỐNG (OPERATIONAL SCRIPTS)

- **Kiểm tra trạng thái hệ thống**: `./status.sh`
- **Tắt toàn bộ dịch vụ an toàn**: `./stop.sh`
- **Bật lại hệ thống**: `./start.sh`

---

## 📜 LICENSE & CREDITS
© 2026 Developed by **Nguyễn Quốc Đương (DuongDevv)** - Sinh viên CNTT Cao đẳng Kỹ thuật Cao Thắng.
