USE [FashionPOS]
GO
/****** Object:  Table [dbo].[BienTheSanPham]    Script Date: 5/4/2026 12:20:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BienTheSanPham](
	[MaBienThe] [int] IDENTITY(1,1) NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[KichCo] [nvarchar](20) NOT NULL,
	[MauSac] [nvarchar](50) NOT NULL,
	[SoLuongTon] [int] NOT NULL,
	[GiaBan] [decimal](18, 2) NOT NULL,
	[HinhAnh] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBienThe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauHinhHeThong]    Script Date: 5/4/2026 12:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHinhHeThong](
	[TenCauHinh] [varchar](100) NOT NULL,
	[GiaTri] [nvarchar](max) NULL,
	[MoTa] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[TenCauHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 5/4/2026 12:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaChiTietHD] [int] IDENTITY(1,1) NOT NULL,
	[MaHoaDon] [int] NOT NULL,
	[MaBienThe] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [decimal](18, 2) NOT NULL,
	[ThanhTien]  AS ([SoLuong]*[DonGia]) PERSISTED,
PRIMARY KEY CLUSTERED 
(
	[MaChiTietHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 5/4/2026 12:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaChiTietPN] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuNhap] [int] NOT NULL,
	[MaBienThe] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiaNhap] [decimal](18, 2) NOT NULL,
	[ThanhTien]  AS ([SoLuong]*[GiaNhap]) PERSISTED,
PRIMARY KEY CLUSTERED 
(
	[MaChiTietPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 5/4/2026 12:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[MaDanhMuc] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 5/4/2026 12:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[SoHoaDon]  AS ('HD'+right('00000'+CONVERT([varchar](10),[MaHoaDon]),(5))) PERSISTED,
	[MaKhachHang] [int] NULL,
	[MaNhanVien] [int] NOT NULL,
	[NgayLap] [datetime] NOT NULL,
	[TongTienHang] [decimal](18, 2) NOT NULL,
	[LoaiGiamGia] [varchar](3) NOT NULL,
	[GiamGia] [decimal](18, 2) NOT NULL,
	[KhachCanTra] [decimal](18, 2) NOT NULL,
	[KhachDaTra] [decimal](18, 2) NOT NULL,
	[TienThoi]  AS ([KhachDaTra]-[KhachCanTra]) PERSISTED,
	[PhuongThucThanhToan] [nvarchar](30) NOT NULL,
	[DiemTichDuoc] [int] NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 5/4/2026 12:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[SoDienThoai] [varchar](20) NULL,
	[GioiTinh] [tinyint] NULL,
	[Email] [varchar](100) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[TongChiTieu] [decimal](18, 2) NOT NULL,
	[DiemTichLuy] [int] NOT NULL,
	[NgayTao] [datetime] NOT NULL,
	[LoaiThanhVien] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 5/4/2026 12:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNhaCungCap] [int] IDENTITY(1,1) NOT NULL,
	[TenNhaCungCap] [nvarchar](200) NOT NULL,
	[NguoiLienHe] [nvarchar](100) NULL,
	[SoDienThoai] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[TrangThai] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/4/2026 12:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [tinyint] NULL,
	[SoDienThoai] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[TenDangNhap] [varchar](50) NOT NULL,
	[MatKhau] [varchar](255) NOT NULL,
	[TrangThai] [nvarchar](20) NOT NULL,
	[NgayTao] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 5/4/2026 12:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieuNhap] [int] IDENTITY(1,1) NOT NULL,
	[SoPhieuNhap]  AS ('PN'+right('00000'+CONVERT([varchar](10),[MaPhieuNhap]),(5))) PERSISTED,
	[MaNhaCungCap] [int] NOT NULL,
	[MaNhanVien] [int] NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[TongTien] [decimal](18, 2) NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 5/4/2026 12:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](200) NOT NULL,
	[MaDanhMuc] [int] NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[GiaCoBan] [decimal](18, 2) NOT NULL,
	[NgayTao] [datetime] NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[HinhAnh] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BienTheSanPham] ON 
GO
INSERT [dbo].[BienTheSanPham] ([MaBienThe], [MaSanPham], [KichCo], [MauSac], [SoLuongTon], [GiaBan], [HinhAnh]) VALUES (2, 1, N'36', N'Xám', 10, CAST(200000.00 AS Decimal(18, 2)), NULL)
GO
SET IDENTITY_INSERT [dbo].[BienTheSanPham] OFF
GO
INSERT [dbo].[CauHinhHeThong] ([TenCauHinh], [GiaTri], [MoTa]) VALUES (N'DiaChi', N'123 Thanh Hóa', N'Địa chỉ')
GO
INSERT [dbo].[CauHinhHeThong] ([TenCauHinh], [GiaTri], [MoTa]) VALUES (N'Email', N'nqdfashion@gmail.com', N'Email cửa hàng')
GO
INSERT [dbo].[CauHinhHeThong] ([TenCauHinh], [GiaTri], [MoTa]) VALUES (N'Facebook', N'facebook.com/nqdfashion', N'Link Facebook')
GO
INSERT [dbo].[CauHinhHeThong] ([TenCauHinh], [GiaTri], [MoTa]) VALUES (N'Instagram', N'instagram.com/nqdfashion', N'Link Instagram')
GO
INSERT [dbo].[CauHinhHeThong] ([TenCauHinh], [GiaTri], [MoTa]) VALUES (N'SoDienThoai', N'0788687875', N'Số điện thoại')
GO
INSERT [dbo].[CauHinhHeThong] ([TenCauHinh], [GiaTri], [MoTa]) VALUES (N'TenCuaHang', N'NQD Fashion', N'Tên cửa hàng')
GO
INSERT [dbo].[CauHinhHeThong] ([TenCauHinh], [GiaTri], [MoTa]) VALUES (N'Tiktok', N'tiktok.com/nqdfashion', N'Link TikTok')
GO
INSERT [dbo].[CauHinhHeThong] ([TenCauHinh], [GiaTri], [MoTa]) VALUES (N'Website', N'nqdfashion.com', N'Website')
GO
INSERT [dbo].[CauHinhHeThong] ([TenCauHinh], [GiaTri], [MoTa]) VALUES (N'Zalo', N'0788687875', N'Số Zalo')
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] ON 
GO
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHD], [MaHoaDon], [MaBienThe], [SoLuong], [DonGia]) VALUES (1, 7, 2, 1, CAST(200000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHD], [MaHoaDon], [MaBienThe], [SoLuong], [DonGia]) VALUES (2, 8, 2, 10, CAST(200000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhap] ON 
GO
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPN], [MaPhieuNhap], [MaBienThe], [SoLuong], [GiaNhap]) VALUES (1, 1, 2, 1, CAST(1000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPN], [MaPhieuNhap], [MaBienThe], [SoLuong], [GiaNhap]) VALUES (2, 2, 2, 20, CAST(200000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[DanhMuc] ON 
GO
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (1, N'Áo')
GO
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (2, N'Quần')
GO
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (3, N'Giày')
GO
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (4, N'Phụ kiện')
GO
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (5, N'Túi xách')
GO
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (6, N'Mũ')
GO
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 
GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayLap], [TongTienHang], [LoaiGiamGia], [GiamGia], [KhachCanTra], [KhachDaTra], [PhuongThucThanhToan], [DiemTichDuoc], [GhiChu]) VALUES (7, 1, 1, CAST(N'2026-04-30T02:10:32.103' AS DateTime), CAST(200000.00 AS Decimal(18, 2)), N'%', CAST(0.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), N'Tiền mặt', 200, NULL)
GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayLap], [TongTienHang], [LoaiGiamGia], [GiamGia], [KhachCanTra], [KhachDaTra], [PhuongThucThanhToan], [DiemTichDuoc], [GhiChu]) VALUES (8, 1, 1, CAST(N'2026-05-01T09:56:01.507' AS DateTime), CAST(2000000.00 AS Decimal(18, 2)), N'%', CAST(5.00 AS Decimal(18, 2)), CAST(1900000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), N'Tiền mặt', 1900, NULL)
GO
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [SoDienThoai], [GioiTinh], [Email], [DiaChi], [TongChiTieu], [DiemTichLuy], [NgayTao], [LoaiThanhVien]) VALUES (1, N'asdasdasda', N'0906834761', 0, NULL, NULL, CAST(2100000.00 AS Decimal(18, 2)), 2100, CAST(N'2026-04-30T01:59:51.543' AS DateTime), N'Đen')
GO
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [NguoiLienHe], [SoDienThoai], [Email], [DiaChi], [TrangThai]) VALUES (1, N'Gucci', N'Anh Đương đẹp trai', N'0123456789', N'duongdeptrai@gmail.com', N'sdasdsadasdasd', 1)
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [NguoiLienHe], [SoDienThoai], [Email], [DiaChi], [TrangThai]) VALUES (2, N'SADSADSA', N'Hùng', N'0906834761', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [HinhAnh], [ChucVu], [TenDangNhap], [MatKhau], [TrangThai], [NgayTao]) VALUES (1, N'Nguyễn Văn A', CAST(N'2026-04-26' AS Date), 0, N'0906834761', N'nva@gmail.com', NULL, N'SuperManager', N'superManager', N'123456', N'Đang làm việc', CAST(N'2026-04-26T18:56:07.977' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuNhap] ON 
GO
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhaCungCap], [MaNhanVien], [NgayNhap], [TongTien], [GhiChu]) VALUES (1, 1, 1, CAST(N'2026-04-30T01:31:30.690' AS DateTime), CAST(1000.00 AS Decimal(18, 2)), NULL)
GO
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhaCungCap], [MaNhanVien], [NgayNhap], [TongTien], [GhiChu]) VALUES (2, 1, 1, CAST(N'2026-05-01T09:55:32.867' AS DateTime), CAST(4000000.00 AS Decimal(18, 2)), NULL)
GO
SET IDENTITY_INSERT [dbo].[PhieuNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaDanhMuc], [MoTa], [GiaCoBan], [NgayTao], [TrangThai], [HinhAnh]) VALUES (1, N'Áo thun', 1, N'Ngon bổ rẻ', CAST(200000.00 AS Decimal(18, 2)), CAST(N'2026-04-29T06:37:53.087' AS DateTime), 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_BienThe]    Script Date: 5/4/2026 12:20:02 PM ******/
ALTER TABLE [dbo].[BienTheSanPham] ADD  CONSTRAINT [UQ_BienThe] UNIQUE NONCLUSTERED 
(
	[MaSanPham] ASC,
	[KichCo] ASC,
	[MauSac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KhachHan__0389B7BD525C600E]    Script Date: 5/4/2026 12:20:02 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD UNIQUE NONCLUSTERED 
(
	[SoDienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__55F68FC01F4823B5]    Script Date: 5/4/2026 12:20:02 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BienTheSanPham] ADD  DEFAULT ((0)) FOR [SoLuongTon]
GO
ALTER TABLE [dbo].[BienTheSanPham] ADD  DEFAULT ((0)) FOR [GiaBan]
GO
ALTER TABLE [dbo].[ChiTietHoaDon] ADD  DEFAULT ((0)) FOR [DonGia]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] ADD  DEFAULT ((0)) FOR [GiaNhap]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT (getdate()) FOR [NgayLap]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [TongTienHang]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ('%') FOR [LoaiGiamGia]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [GiamGia]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [KhachCanTra]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [KhachDaTra]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT (N'Tiền mặt') FOR [PhuongThucThanhToan]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [DiemTichDuoc]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT ((0)) FOR [TongChiTieu]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT ((0)) FOR [DiemTichLuy]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT (N'Đồng') FOR [LoaiThanhVien]
GO
ALTER TABLE [dbo].[NhaCungCap] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT (N'Đang làm việc') FOR [TrangThai]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[PhieuNhap] ADD  DEFAULT (getdate()) FOR [NgayNhap]
GO
ALTER TABLE [dbo].[PhieuNhap] ADD  DEFAULT ((0)) FOR [TongTien]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT ((0)) FOR [GiaCoBan]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[BienTheSanPham]  WITH CHECK ADD  CONSTRAINT [FK_BienThe_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[BienTheSanPham] CHECK CONSTRAINT [FK_BienThe_SanPham]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHD_BienThe] FOREIGN KEY([MaBienThe])
REFERENCES [dbo].[BienTheSanPham] ([MaBienThe])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHD_BienThe]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHD_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHD_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPN_BienThe] FOREIGN KEY([MaBienThe])
REFERENCES [dbo].[BienTheSanPham] ([MaBienThe])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPN_BienThe]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPN_PhieuNhap] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPN_PhieuNhap]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCungCap] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_DanhMuc] FOREIGN KEY([MaDanhMuc])
REFERENCES [dbo].[DanhMuc] ([MaDanhMuc])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_DanhMuc]
GO
ALTER TABLE [dbo].[BienTheSanPham]  WITH CHECK ADD  CONSTRAINT [CHK_BienThe_SoLuongTon] CHECK  (([SoLuongTon]>=(0)))
GO
ALTER TABLE [dbo].[BienTheSanPham] CHECK CONSTRAINT [CHK_BienThe_SoLuongTon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [CHK_ChiTietHD_SoLuong] CHECK  (([SoLuong]>(0)))
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [CHK_ChiTietHD_SoLuong]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [CHK_ChiTietPN_SoLuong] CHECK  (([SoLuong]>(0)))
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [CHK_ChiTietPN_SoLuong]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [CHK_HoaDon_ThanhToan] CHECK  (([PhuongThucThanhToan]=N'Ví điện tử' OR [PhuongThucThanhToan]=N'Thẻ' OR [PhuongThucThanhToan]=N'Chuyển khoản' OR [PhuongThucThanhToan]=N'Tiền mặt'))
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [CHK_HoaDon_ThanhToan]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [CHK_KH_LoaiThanhVien] CHECK  (([LoaiThanhVien]=N'Đen' OR [LoaiThanhVien]=N'Vàng' OR [LoaiThanhVien]=N'Bạc' OR [LoaiThanhVien]=N'Đồng'))
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [CHK_KH_LoaiThanhVien]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [CHK_KhachHang_Diem] CHECK  (([DiemTichLuy]>=(0)))
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [CHK_KhachHang_Diem]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [chk_KhachHang_GioiTinh] CHECK  (([GioiTinh]=(2) OR [GioiTinh]=(1) OR [GioiTinh]=(0)))
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [chk_KhachHang_GioiTinh]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [CHK_NhanVien_GioiTinh] CHECK  (([GioiTinh]=(2) OR [GioiTinh]=(1) OR [GioiTinh]=(0)))
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [CHK_NhanVien_GioiTinh]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [CHK_NhanVien_TrangThai] CHECK  (([TrangThai]=N'Nghỉ việc' OR [TrangThai]=N'Đang làm việc'))
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [CHK_NhanVien_TrangThai]
GO
