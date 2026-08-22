using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAL
{
    public class OrderDAL
    {
        //Lấy tất cả hóa đơn
        public DataTable GetAll()
        {
            string query = @"select hd.MaHoaDon, hd.SoHoaDon, 
                                    kh.HoTen AS TenKhachHang,
                                    nv.HoTen AS TenNhanVien,
                                    hd.NgayLap, hd.TongTienHang,
                                    hd.LoaiGiamGia, hd.GiamGia,
                                    hd.KhachCanTra, hd.KhachDaTra,
                                    hd.TienThoi, hd.PhuongThucThanhToan,
                                    hd.DiemTichDuoc, hd.GhiChu
                             from HoaDon hd
                             left join KhachHang kh on hd.MaKhachHang = kh.MaKhachHang
                             join NhanVien nv on hd.MaNhanVien = nv.MaNhanVien
                             order by hd.NgayLap desc";
            return DataHelper.GetDataTable(query);
        }

        //Lấy hóa đơn theo khoảng ngày (dùng cho báo cáo)
        public DataTable GetByDateRange(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"select hd.MaHoaDon, hd.SoHoaDon,
                                    kh.HoTen AS TenKhachHang,
                                    nv.HoTen AS TenNhanVien,
                                    hd.NgayLap, hd.TongTienHang,
                                    hd.LoaiGiamGia, hd.GiamGia,
                                    hd.KhachCanTra, hd.KhachDaTra,
                                    hd.TienThoi, hd.PhuongThucThanhToan,
                                    hd.DiemTichDuoc
                             from HoaDon hd
                             left join KhachHang kh on hd.MaKhachHang = kh.MaKhachHang
                             join NhanVien  nv ON hd.MaNhanVien  = nv.MaNhanVien
                             where cast(hd.NgayLap as date) between @TuNgay and @DenNgay
                             order by hd.NgayLap DESC";
            SqlParameter[] parameters = {
                new SqlParameter("@TuNgay",  tuNgay.Date),
                new SqlParameter("@DenNgay", denNgay.Date)
            };
            return DataHelper.GetDataTable(query, parameters);
        }

        //Lấy chi tiết 1 hóa đơn
        public DataTable GetOrderDetail(int maHoaDon)
        {
            string query = @"select ct.MaChiTietHD,
                                    sp.TenSanPham,
                                    bt.KichCo, bt.MauSac,
                                    ct.SoLuong, ct.DonGia, ct.ThanhTien
                             from ChiTietHoaDon ct
                             join BienTheSanPham bt on ct.MaBienThe = bt.MaBienThe
                             join SanPham sp on bt.MaSanPham = sp.MaSanPham
                             where ct.MaHoaDon = @MaHoaDon";
            SqlParameter[] parameters = {
                new SqlParameter("@MaHoaDon", maHoaDon)
            };
            return DataHelper.GetDataTable(query, parameters);
        }

        public DataTable GetBestSellingProducts(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"SELECT sp.TenSanPham, bt.MauSac, bt.KichCo,
                            SUM(ct.SoLuong)   AS SoLuongBan,
                            SUM(ct.ThanhTien) AS DoanhThu
                     FROM ChiTietHoaDon ct
                     JOIN BienTheSanPham bt ON ct.MaBienThe = bt.MaBienThe
                     JOIN SanPham        sp ON bt.MaSanPham = sp.MaSanPham
                     JOIN HoaDon         hd ON ct.MaHoaDon  = hd.MaHoaDon
                     WHERE CAST(hd.NgayLap AS DATE) BETWEEN @TuNgay AND @DenNgay
                     GROUP BY sp.TenSanPham, bt.MauSac, bt.KichCo
                     ORDER BY SoLuongBan DESC";
            SqlParameter[] parameters = {
        new SqlParameter("@TuNgay",  tuNgay),
        new SqlParameter("@DenNgay", denNgay)
    };
            return DataHelper.GetDataTable(query, parameters);
        }

        //Doanh thu theo ngày (dùng cho dashboard)
        public DataTable GetDailyRevenue(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"select cast(NgayLap as date) as Ngay,
                                    count(*) as SoHoaDon,
                                    sum(KhachCanTra) as DoanhThu
                             from HoaDon
                             where cast(NgayLap as date) between @TuNgay and @DenNgay
                             group by cast(NgayLap as date)
                             order by Ngay";
            SqlParameter[] parameters = {
                new SqlParameter("@TuNgay",  tuNgay.Date),
                new SqlParameter("@DenNgay", denNgay.Date)
            };
            return DataHelper.GetDataTable(query, parameters);
        }

        //Tạo hóa đơn + chi tiết + cập nhật tồn kho + cập nhật điểm
        //Dùng Transaction để đảm bảo toàn vẹn dữ liệu
        public bool CreateOrder(
            int? maKhachHang, int maNhanVien,
            decimal tongTienHang, string loaiGiamGia, decimal giamGia,
            decimal khachCanTra, decimal khachDaTra,
            string phuongThucThanhToan, int diemTichDuoc,
            string ghiChu, DataTable gioHang)
        //gioHang gồm các cột: MaBienThe, SoLuong, DonGia
        {
            string connStr = DataHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    //1. Thêm hóa đơn
                    string queryHD = @"insert into HoaDon (MaKhachHang, MaNhanVien, TongTienHang, LoaiGiamGia,
                                                                GiamGia, KhachCanTra, KhachDaTra, PhuongThucThanhToan, DiemTichDuoc, GhiChu)
                                      values (@MaKhachHang, @MaNhanVien, @TongTienHang, @LoaiGiamGia,
                                                    @GiamGia, @KhachCanTra, @KhachDaTra, @PhuongThucThanhToan, @DiemTichDuoc, @GhiChu);
                                      select scope_identity();";

                    SqlCommand cmdHD = new SqlCommand(queryHD, conn, transaction);
                    cmdHD.Parameters.AddWithValue("@MaKhachHang", (object)maKhachHang ?? DBNull.Value);
                    cmdHD.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmdHD.Parameters.AddWithValue("@TongTienHang", tongTienHang);
                    cmdHD.Parameters.AddWithValue("@LoaiGiamGia", loaiGiamGia);
                    cmdHD.Parameters.AddWithValue("@GiamGia", giamGia);
                    cmdHD.Parameters.AddWithValue("@KhachCanTra", khachCanTra);
                    cmdHD.Parameters.AddWithValue("@KhachDaTra", khachDaTra);
                    cmdHD.Parameters.AddWithValue("@PhuongThucThanhToan", phuongThucThanhToan);
                    cmdHD.Parameters.AddWithValue("@DiemTichDuoc", diemTichDuoc);
                    cmdHD.Parameters.AddWithValue("@GhiChu", (object)ghiChu ?? DBNull.Value);

                    int maHoaDon = Convert.ToInt32(cmdHD.ExecuteScalar());

                    //2.Thêm chi tiết hóa đơn + cập nhật tồn kho
                    foreach (DataRow row in gioHang.Rows)
                    {
                        int maBienThe = Convert.ToInt32(row["MaBienThe"]);
                        int soLuong = Convert.ToInt32(row["SoLuong"]);
                        decimal donGia = Convert.ToDecimal(row["DonGia"]);

                        //Thêm chi tiết
                        string queryCT = @"insert into ChiTietHoaDon (MaHoaDon, MaBienThe, SoLuong, DonGia)
                                          values
                                                (@MaHoaDon, @MaBienThe, @SoLuong, @DonGia)";
                        SqlCommand cmdCT = new SqlCommand(queryCT, conn, transaction);
                        cmdCT.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        cmdCT.Parameters.AddWithValue("@MaBienThe", maBienThe);
                        cmdCT.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdCT.Parameters.AddWithValue("@DonGia", donGia);
                        cmdCT.ExecuteNonQuery();

                        //Trừ tồn kho
                        string queryTon = @"update BienTheSanPham 
                                            set SoLuongTon = SoLuongTon - @SoLuong
                                            where MaBienThe = @MaBienThe";
                        SqlCommand cmdTon = new SqlCommand(queryTon, conn, transaction);
                        cmdTon.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdTon.Parameters.AddWithValue("@MaBienThe", maBienThe);
                        cmdTon.ExecuteNonQuery();
                    }

                    //3. Cập nhật điểm + hạng khách hàng (nếu có)
                    if (maKhachHang.HasValue && diemTichDuoc > 0)
                    {
                        string queryDiem = @"update KhachHang set
                                                DiemTichLuy  = DiemTichLuy + @Diem,
                                                TongChiTieu  = TongChiTieu + @TienChi,
                                                LoaiThanhVien = CASE
                                                    when DiemTichLuy + @Diem >= 300 then N'Đen'
                                                    when DiemTichLuy + @Diem >= 200 then N'Vàng'
                                                    when DiemTichLuy + @Diem >= 100 then N'Bạc'
                                                    else N'Đồng'
                                                end
                                             where MaKhachHang = @MaKhachHang";
                        SqlCommand cmdDiem = new SqlCommand(queryDiem, conn, transaction);
                        cmdDiem.Parameters.AddWithValue("@Diem", diemTichDuoc);
                        cmdDiem.Parameters.AddWithValue("@TienChi", khachCanTra);
                        cmdDiem.Parameters.AddWithValue("@MaKhachHang", maKhachHang.Value);
                        cmdDiem.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
