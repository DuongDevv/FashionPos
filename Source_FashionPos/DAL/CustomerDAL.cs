using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Web;

namespace WindowsFormsApp1.DAL
{
    public class CustomerDAL
    {
        public DataTable GetAll()
        {
            string query = @"SELECT kh.*,
                     (SELECT COUNT(*) FROM HoaDon 
                      WHERE MaKhachHang = kh.MaKhachHang) AS SoLanMua
                     FROM KhachHang kh
                     ORDER BY kh.NgayTao DESC";
            return DataHelper.GetDataTable(query);
        }

        public DataTable Search(string keyword)
        {
            string query = @"SELECT kh.*,
                     (SELECT COUNT(*) FROM HoaDon 
                      WHERE MaKhachHang = kh.MaKhachHang) AS SoLanMua
                     FROM KhachHang kh
                     WHERE kh.HoTen       LIKE @Keyword
                     OR    kh.SoDienThoai LIKE @Keyword
                     ORDER BY kh.NgayDangKy DESC";
            SqlParameter[] parameters = {
        new SqlParameter("@Keyword", "%" + keyword + "%")
    };
            return DataHelper.GetDataTable(query, parameters);
        }

        public DataRow GetByID(int id)
        {
            string query = "select * from KhachHang where MaKhachHang = @MaKhachHang";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaKhachHang", id)
            };
            DataTable dt = DataHelper.GetDataTable(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public int GetNextID()
        {
            string query = "SELECT ISNULL(MAX(MaKhachHang), 0) + 1 FROM KhachHang";
            object result = DataHelper.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 1;
        }

        public DataRow GetByPhone(string phone)
        {
            string query = "select * from KhachHang where SoDienThoai = @SDT";
            SqlParameter[] parameters =
            {
                new SqlParameter("@SDT", phone)
            };
            DataTable dt = DataHelper.GetDataTable(query, parameters);
            return dt.Rows.Count>0?dt.Rows[0] : null;
        }

        public bool Insert(string hoTen, object soDienThoai, object gioiTinh, object email, object diaChi)
        {
            string query = @"insert into KhachHang 
                            (HoTen, SoDienThoai, GioiTinh, Email, DiaChi) values
                            (@HoTen, @SoDienThoai, @GioiTinh, @Email, @DiaChi)";
            SqlParameter[] parameters = {
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@SoDienThoai", soDienThoai ?? DBNull.Value),
                new SqlParameter("@GioiTinh", gioiTinh ?? DBNull.Value),
                new SqlParameter("@Email", email ?? DBNull.Value),
                new SqlParameter("@DiaChi", diaChi ?? DBNull.Value)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(int maKhachHang, string hoTen, object soDienThoai, object gioiTinh, object email, object diaChi)
        {
            string query = @"update KhachHang set HoTen = @HoTen, SoDienThoai = @SoDienThoai, GioiTin = @GioiTinh, Email = @Email, DiaChi = @DiaChi
                             where MaKhachHang = @MaKhachHang";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaKhachHang", maKhachHang),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@SoDienThoai", soDienThoai ?? DBNull.Value),
                new SqlParameter("@GioiTinh", gioiTinh?? DBNull.Value),
                new SqlParameter("@Email", email?? DBNull.Value),
                new SqlParameter("@DiaChi", diaChi ?? DBNull.Value)
            };
            return DataHelper.ExecuteNonQuery(query,parameters) > 0;
        }

        public bool UpdateScore(int id, int point, decimal price)
        {
            string query = @"update KhachHang set
                                DiemTichLuy = DiemTichLuy + @DiemCong,
                                TongChiTieu = TongChiTieu + @SoTienChi,
                                LoaiThanhVien = case
                                    when DiemTichLuy = @DiemCong >= 300 then N'Đen'
                                    when DiemTichLuy = @DiemCong >= 200 then N'Vàng'
                                    when DiemTichLuy = @DiemCong >= 100 then N'Bạc'
                                    else N'Đồng'
                                end
                             where MaKhachHang = @MaKhachHang";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaKhachHang", id),
                new SqlParameter("@DiemCong", point),
                new SqlParameter("@SoTienChi", price)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int id)
        {
            string query = "delete from KhachHang where MaKhachHang = @MaKhachHang";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaKhachHang",id)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool IsExistPhone(string phone)
        {
            string query = "select count(1) from KhachHang where SoDienThoai = @SDT";
            SqlParameter[] parameters =
            {
                new SqlParameter("@SDT", phone)
            };
            return (int)DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
