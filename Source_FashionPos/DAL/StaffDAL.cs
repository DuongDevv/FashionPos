                                    using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAL
{
    public class StaffDAL
    {
        public DataTable GetAll()
        {
            string query = "SELECT * FROM NhanVien";
            return DataHelper.GetDataTable(query);
        }

        public DataTable Search(string keyword, string chucVu)
        {
            string query = "SELECT * FROM NhanVien WHERE HoTen LIKE @Keyword";
            if (!string.IsNullOrEmpty(chucVu) && chucVu != "Tất cả")
                query += " AND ChucVu = @ChucVu";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Keyword", "%" + keyword + "%"),
                new SqlParameter("@ChucVu",  chucVu ?? "")
            };
            return DataHelper.GetDataTable(query, parameters);
        }

        public DataRow GetByID(int maNhanVien)
        {
            string query = "SELECT * FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNhanVien", maNhanVien)
            };
            DataTable dt = DataHelper.GetDataTable(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public DataRow Login(string username, string password)
        {
            string query = @"SELECT * FROM NhanVien
                             WHERE TenDangNhap = @TenDangNhap
                             AND   MatKhau     = @MatKhau
                             AND   TrangThai   = N'Đang làm việc'";
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenDangNhap", username), // khớp với query
                new SqlParameter("@MatKhau",     password)  // khớp với query
            };
            DataTable dt = DataHelper.GetDataTable(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public int Insert(string hoTen, object ngaySinh, object gioiTinh,
                           object soDienThoai, object email, object hinhAnh,
                           object chucVu, string tenDangNhap, string matKhau)
        {
            string query = @"INSERT INTO NhanVien 
                            (HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, HinhAnh, ChucVu, TenDangNhap, MatKhau)
                            VALUES
                            (@HoTen, @NgaySinh, @GioiTinh, @SoDienThoai, @Email, @HinhAnh, @ChucVu, @TenDangNhap, @MatKhau);
                            SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters =
            {
                new SqlParameter("@HoTen",       hoTen),
                new SqlParameter("@NgaySinh",    ngaySinh    ?? DBNull.Value),
                new SqlParameter("@GioiTinh",    gioiTinh    ?? DBNull.Value),
                new SqlParameter("@SoDienThoai", soDienThoai ?? DBNull.Value),
                new SqlParameter("@Email",       email       ?? DBNull.Value),
                new SqlParameter("@HinhAnh",     hinhAnh     ?? DBNull.Value),
                new SqlParameter("@ChucVu",      chucVu      ?? DBNull.Value),
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@MatKhau",     matKhau)
            };
            object result = DataHelper.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public bool Update(int maNhanVien, string hoTen, object ngaySinh,
                            object gioiTinh, object soDienThoai, object email,
                            object hinhAnh, object chucVu, string trangThai)
        {
            string query = @"UPDATE NhanVien SET
                                HoTen       = @HoTen,
                                NgaySinh    = @NgaySinh,
                                GioiTinh    = @GioiTinh,
                                SoDienThoai = @SoDienThoai,
                                Email       = @Email,
                                HinhAnh     = @HinhAnh,
                                ChucVu      = @ChucVu,
                                TrangThai   = @TrangThai
                             WHERE MaNhanVien = @MaNhanVien";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNhanVien",  maNhanVien),
                new SqlParameter("@HoTen",       hoTen),
                new SqlParameter("@NgaySinh",    ngaySinh    ?? DBNull.Value),
                new SqlParameter("@GioiTinh",    gioiTinh    ?? DBNull.Value),
                new SqlParameter("@SoDienThoai", soDienThoai ?? DBNull.Value),
                new SqlParameter("@Email",       email       ?? DBNull.Value),
                new SqlParameter("@HinhAnh",     hinhAnh     ?? DBNull.Value),
                new SqlParameter("@ChucVu",      chucVu      ?? DBNull.Value),
                new SqlParameter("@TrangThai",   trangThai)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool ChangePassword(int id, string newPassword)
        {
            string query = @"UPDATE NhanVien
                             SET MatKhau = @MatKhau
                             WHERE MaNhanVien = @MaNhanVien";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNhanVien", id),
                new SqlParameter("@MatKhau",    newPassword)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int id)
        {
            string query = @"UPDATE NhanVien
                             SET TrangThai = N'Nghỉ việc'
                             WHERE MaNhanVien = @MaNhanVien";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNhanVien", id)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool IsExistUserName(string username)
        {
            string query = "SELECT COUNT(1) FROM NhanVien WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenDangNhap", username)
            };
            return (int)DataHelper.ExecuteScalar(query, parameters) > 0; // sửa thành ExecuteScalar
        }

        public int GetNextID()
        {
            string query = "SELECT ISNULL(MAX(MaNhanVien), 0) + 1 FROM NhanVien";
            object result = DataHelper.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 1;
        }
    }
}
