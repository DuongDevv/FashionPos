using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAL
{
    public class PurchaseOrderDAL
    {
        //Lấy tất cả phiếu nhập
        public DataTable GetAll()
        {
            string query = @"select pn.MaPhieuNhap, pn.SoPhieuNhap,
                                    ncc.TenNhaCungCap,
                                    nv.HoTen as TenNhanVien,
                                    pn.NgayNhap, pn.TongTien, pn.GhiChu
                             from PhieuNhap pn
                             join NhaCungCap ncc on pn.MaNhaCungCap = ncc.MaNhaCungCap
                             join NhanVien nv on pn.MaNhanVien= nv.MaNhanVien
                             order by pn.NgayNhap desc";
            return DataHelper.GetDataTable(query);
        }

        //Lấy phiếu nhập theo khoảng ngày
        public DataTable GetByDateRange(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"select pn.MaPhieuNhap, pn.SoPhieuNhap,
                                    ncc.TenNhaCungCap,
                                    nv.HoTen as TenNhanVien,
                                    pn.NgayNhap, pn.TongTien, pn.GhiChu
                             from PhieuNhap pn
                             join NhaCungCap ncc on pn.MaNhaCungCap = ncc.MaNhaCungCap
                             join NhanVien nv on pn.MaNhanVien = nv.MaNhanVien
                             where cast(pn.NgayNhap as date) between @TuNgay and @DenNgay
                             order by pn.NgayNhap desc";
            SqlParameter[] parameters = {
                new SqlParameter("@TuNgay",  tuNgay.Date),
                new SqlParameter("@DenNgay", denNgay.Date)
            };
            return DataHelper.GetDataTable(query, parameters);
        }

        //Lấy chi tiết 1 phiếu nhập
        public DataTable GetChiTiet(int maPhieuNhap)
        {
            string query = @"select ct.MaChiTietPN,
                                    sp.TenSanPham,
                                    bt.KichCo, bt.MauSac,
                                    ct.SoLuong, ct.GiaNhap, ct.ThanhTien
                             from ChiTietPhieuNhap ct
                             join BienTheSanPham bt on ct.MaBienThe = bt.MaBienThe
                             join SanPham sp on bt.MaSanPham = sp.MaSanPham
                             where ct.MaPhieuNhap = @MaPhieuNhap";
            SqlParameter[] parameters = {
                new SqlParameter("@MaPhieuNhap", maPhieuNhap)
            };
            return DataHelper.GetDataTable(query, parameters);
        }

        //Tạo phiếu nhập + chi tiết + cập nhật tồn kho
        //Dùng Transaction để đảm bảo toàn vẹn dữ liệu
        public bool CreatePhieuNhap(
            int maNhaCungCap, int maNhanVien,
            decimal tongTien, string ghiChu,
            DataTable danhSachNhap)
        // danhSachNhap gồm các cột: MaBienThe, SoLuong, GiaNhap
        {
            string connStr = DataHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    //1. Thêm phiếu nhập
                    string queryPN = @"insert into PhieuNhap (MaNhaCungCap, MaNhanVien, TongTien, GhiChu)
                                      values
                                            (@MaNhaCungCap, @MaNhanVien, @TongTien, @GhiChu);
                                      select scope_identity();";

                    SqlCommand cmdPN = new SqlCommand(queryPN, conn, transaction);
                    cmdPN.Parameters.AddWithValue("@MaNhaCungCap", maNhaCungCap);
                    cmdPN.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmdPN.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdPN.Parameters.AddWithValue("@GhiChu", (object)ghiChu ?? DBNull.Value);

                    int maPhieuNhap = Convert.ToInt32(cmdPN.ExecuteScalar());

                    //2. Thêm chi tiết + cập nhật tồn kho
                    foreach (DataRow row in danhSachNhap.Rows)
                    {
                        int maBienThe = Convert.ToInt32(row["MaBienThe"]);
                        int soLuong = Convert.ToInt32(row["SoLuong"]);
                        decimal giaNhap = Convert.ToDecimal(row["GiaNhap"]);

                        //Thêm chi tiết phiếu nhập
                        string queryCT = @"insert into ChiTietPhieuNhap (MaPhieuNhap, MaBienThe, SoLuong, GiaNhap)
                                          values
                                                (@MaPhieuNhap, @MaBienThe, @SoLuong, @GiaNhap)";
                        SqlCommand cmdCT = new SqlCommand(queryCT, conn, transaction);
                        cmdCT.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                        cmdCT.Parameters.AddWithValue("@MaBienThe", maBienThe);
                        cmdCT.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdCT.Parameters.AddWithValue("@GiaNhap", giaNhap);
                        cmdCT.ExecuteNonQuery();

                        //Cộng tồn kho
                        string queryTon = @"update BienTheSanPham
                                            set SoLuongTon = SoLuongTon + @SoLuong
                                            where MaBienThe = @MaBienThe";
                        SqlCommand cmdTon = new SqlCommand(queryTon, conn, transaction);
                        cmdTon.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdTon.Parameters.AddWithValue("@MaBienThe", maBienThe);
                        cmdTon.ExecuteNonQuery();
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
