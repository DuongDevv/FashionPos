-- 1. Bảng DanhMuc
CREATE TABLE DanhMuc (
    MaDanhMuc INT PRIMARY KEY IDENTITY(1,1),
    TenDanhMuc NVARCHAR(100) NOT NULL
);

-- 2. Bảng NhaCungCap
CREATE TABLE NhaCungCap (
    MaNhaCungCap INT PRIMARY KEY IDENTITY(1,1),
    TenNhaCungCap NVARCHAR(200) NOT NULL,
    NguoiLienHe NVARCHAR(100),
    SoDienThoai VARCHAR(20),
    Email VARCHAR(100),
    DiaChi NVARCHAR(MAX),
    TrangThai BIT NOT NULL DEFAULT 1  -- 1: Đang hợp tác, 0: Ngừng
);

-- 3. Bảng NhanVien
CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh date,
    GioiTinh tinyint 
        constraint CHK_NhanVien_GioiTinh check (GioiTinh in (0,1,2)), 
    SoDienThoai VARCHAR(20),
    Email varchar(100),
    HinhAnh nvarchar(max),
    ChucVu NVARCHAR(50),
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(255) NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Đang làm việc'
        CONSTRAINT CHK_NhanVien_TrangThai CHECK (TrangThai IN (N'Đang làm việc', N'Nghỉ việc'))
);
select * from NhanVien
UPDATE NhanVien 
SET TenDangNhap = 'superManager',
    ChucVu      = 'SuperManager',
    TrangThai   = N'Đang làm việc'
WHERE MaNhanVien = 1;


-- 4. Bảng SanPham
CREATE TABLE SanPham (
    MaSanPham INT PRIMARY KEY IDENTITY(1,1),
    TenSanPham NVARCHAR(200) NOT NULL,
    MaDanhMuc INT NOT NULL
        CONSTRAINT FK_SanPham_DanhMuc FOREIGN KEY REFERENCES DanhMuc(MaDanhMuc),
    MoTa NVARCHAR(MAX),
    GiaCoBan DECIMAL(18,2) NOT NULL DEFAULT 0,
    NgayTao DATETIME NOT NULL DEFAULT GETDATE()
);

-- 5. Bảng BienTheSanPham
--    Mỗi sản phẩm có thể có nhiều biến thể (Màu + Size)
CREATE TABLE BienTheSanPham (
    MaBienThe INT PRIMARY KEY IDENTITY(1,1),
    MaSanPham INT NOT NULL
        CONSTRAINT FK_BienThe_SanPham FOREIGN KEY REFERENCES SanPham(MaSanPham),
    KichCo NVARCHAR(20) NOT NULL,
    MauSac NVARCHAR(50) NOT NULL,
    SoLuongTon INT NOT NULL DEFAULT 0
        CONSTRAINT CHK_BienThe_SoLuongTon CHECK (SoLuongTon >= 0),
    GiaBan DECIMAL(18,2) NOT NULL DEFAULT 0,
        CONSTRAINT UQ_BienThe UNIQUE (MaSanPham, KichCo, MauSac)
);

ALTER TABLE SanPham ADD TrangThai BIT NOT NULL DEFAULT 1;
ALTER TABLE SanPham ADD HinhAnh NVARCHAR(500);
ALTER TABLE BienTheSanPham ADD HinhAnh NVARCHAR(max);

-- 6. Bảng KhachHang
CREATE TABLE KhachHang (
    MaKhachHang INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(20)   UNIQUE,
    GioiTinh tinyint
        constraint chk_KhachHang_GioiTinh check (GioiTinh in (0,1,2)),
    Email VARCHAR(100),
    DiaChi NVARCHAR(MAX),
    TongChiTieu   DECIMAL(18,2)  NOT NULL DEFAULT 0,
    DiemTichLuy INT NOT NULL DEFAULT 0
        CONSTRAINT CHK_KhachHang_Diem CHECK (DiemTichLuy >= 0),
    NgayTao DATETIME NOT NULL DEFAULT GETDATE(),
    LoaiThanhVien NVARCHAR(20)   NOT NULL DEFAULT N'Đồng'
        CONSTRAINT CHK_KH_LoaiThanhVien 
            CHECK (LoaiThanhVien IN (N'Đồng', N'Bạc', N'Vàng', N'Đen'))
);

-- 7. Bảng HoaDon
CREATE TABLE HoaDon (
    MaHoaDon INT PRIMARY KEY IDENTITY(1,1),
    SoHoaDon AS ('HD' + RIGHT('00000' + CAST(MaHoaDon AS VARCHAR(10)), 5)) PERSISTED,
    MaKhachHang INT
        CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    MaNhanVien INT NOT NULL
        CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY REFERENCES NhanVien(MaNhanVien),
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    TongTienHang DECIMAL(18,2) NOT NULL DEFAULT 0,
    LoaiGiamGia VARCHAR(3) NOT NULL DEFAULT '%',
    GiamGia DECIMAL(18,2) NOT NULL DEFAULT 0,
    KhachCanTra DECIMAL(18,2) NOT NULL DEFAULT 0,
    KhachDaTra DECIMAL(18,2) NOT NULL DEFAULT 0,
    TienThoi AS (KhachDaTra - KhachCanTra) PERSISTED,
    PhuongThucThanhToan NVARCHAR(30) NOT NULL DEFAULT N'Tiền mặt'
        CONSTRAINT CHK_HoaDon_ThanhToan CHECK (PhuongThucThanhToan IN (N'Tiền mặt', N'Chuyển khoản', N'Thẻ', N'Ví điện tử')),
    DiemTichDuoc INT NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(MAX)
);

-- 8. Bảng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon (
    MaChiTietHD INT PRIMARY KEY IDENTITY(1,1),
    MaHoaDon INT NOT NULL
        CONSTRAINT FK_ChiTietHD_HoaDon FOREIGN KEY REFERENCES HoaDon(MaHoaDon),
    MaBienThe INT NOT NULL
        CONSTRAINT FK_ChiTietHD_BienThe FOREIGN KEY REFERENCES BienTheSanPham(MaBienThe),
    SoLuong INT NOT NULL
        CONSTRAINT CHK_ChiTietHD_SoLuong CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL DEFAULT 0, 
    ThanhTien AS (SoLuong * DonGia) PERSISTED
);

-- 9. Bảng PhieuNhap
CREATE TABLE PhieuNhap (
    MaPhieuNhap INT PRIMARY KEY IDENTITY(1,1),
    SoPhieuNhap AS ('PN' + RIGHT('00000' + CAST(MaPhieuNhap AS VARCHAR(10)), 5)) PERSISTED,
    MaNhaCungCap INT NOT NULL
        CONSTRAINT FK_PhieuNhap_NhaCungCap FOREIGN KEY REFERENCES NhaCungCap(MaNhaCungCap),
    MaNhanVien INT NOT NULL
        CONSTRAINT FK_PhieuNhap_NhanVien FOREIGN KEY REFERENCES NhanVien(MaNhanVien),
    NgayNhap DATETIME NOT NULL DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(MAX)
);

-- 10. Bảng ChiTietPhieuNhap
CREATE TABLE ChiTietPhieuNhap (
    MaChiTietPN INT PRIMARY KEY IDENTITY(1,1),
    MaPhieuNhap INT NOT NULL
        CONSTRAINT FK_ChiTietPN_PhieuNhap FOREIGN KEY REFERENCES PhieuNhap(MaPhieuNhap),
    MaBienThe INT NOT NULL
        CONSTRAINT FK_ChiTietPN_BienThe FOREIGN KEY REFERENCES BienTheSanPham(MaBienThe),
    SoLuong INT NOT NULL
        CONSTRAINT CHK_ChiTietPN_SoLuong CHECK (SoLuong > 0),
    GiaNhap DECIMAL(18,2) NOT NULL DEFAULT 0,
    ThanhTien AS (SoLuong * GiaNhap) PERSISTED
);

-- 11. Bảng CauHinhHeThong (key-value, linh hoạt mở rộng)
CREATE TABLE CauHinhHeThong (
    TenCauHinh VARCHAR(100)  PRIMARY KEY,
    GiaTri NVARCHAR(MAX),
    MoTa NVARCHAR(255) 
);

select * from CauHinhHeThong

INSERT INTO CauHinhHeThong (TenCauHinh, GiaTri, MoTa) VALUES
    ('TenCuaHang',  N'NQD Fashion',             N'Tên cửa hàng'),
    ('SoDienThoai', N'0788687875',               N'Số điện thoại'),
    ('Email',       N'nqdfashion@gmail.com',     N'Email cửa hàng'),
    ('Website',     N'nqdfashion.com',           N'Website'),
    ('DiaChi',      N'123 Thanh Hóa',            N'Địa chỉ'),
    ('Facebook',    N'facebook.com/nqdfashion',  N'Link Facebook'),
    ('Zalo',        N'0788687875',               N'Số Zalo'),
    ('Instagram',   N'instagram.com/nqdfashion', N'Link Instagram'),
    ('Tiktok',      N'tiktok.com/nqdfashion',    N'Link TikTok');

CREATE INDEX IX_SanPham_DanhMuc       ON SanPham(MaDanhMuc);
CREATE INDEX IX_BienThe_SanPham       ON BienTheSanPham(MaSanPham);
CREATE INDEX IX_HoaDon_KhachHang      ON HoaDon(MaKhachHang);
CREATE INDEX IX_HoaDon_NhanVien       ON HoaDon(MaNhanVien);
CREATE INDEX IX_HoaDon_NgayLap        ON HoaDon(NgayLap);
CREATE INDEX IX_ChiTietHD_HoaDon      ON ChiTietHoaDon(MaHoaDon);
CREATE INDEX IX_ChiTietHD_BienThe     ON ChiTietHoaDon(MaBienThe);
CREATE INDEX IX_PhieuNhap_NhaCungCap  ON PhieuNhap(MaNhaCungCap);
CREATE INDEX IX_ChiTietPN_PhieuNhap   ON ChiTietPhieuNhap(MaPhieuNhap);

INSERT INTO DanhMuc (TenDanhMuc) VALUES 
    (N'Áo'),
    (N'Quần'),
    (N'Giày'),
    (N'Phụ kiện'),
    (N'Túi xách'),
    (N'Mũ');