using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAL
{
    public class SupplierDAL
    {
        //Lấy tất cả nhà cung cấp
        public DataTable GetAll()
        {
            string query = "select * from NhaCungCap";
            return DataHelper.GetDataTable(query);
        }

        //Lấy nhà cung cấp đang hợp tác (TrangThai = 1)
        public DataTable GetActive()
        {
            string query = "select * from NhaCungCap where TrangThai = 1";
            return DataHelper.GetDataTable(query);
        }

        //Tìm kiếm theo tên hoặc số điện thoại
        public DataTable Search(string keyword)
        {
            string query = @"select * from NhaCungCap 
                             where TenNhaCungCap like @Keyword
                             or SoDienThoai like @Keyword";
            SqlParameter[] parameters = {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };
            return DataHelper.GetDataTable(query, parameters);
        }

        //Lấy 1 nhà cung cấp theo mã
        public DataRow GetByID(int maNhaCungCap)
        {
            string query = "select * from NhaCungCap where MaNhaCungCap = @MaNhaCungCap";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNhaCungCap", maNhaCungCap)
            };
            DataTable dt = DataHelper.GetDataTable(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        //Thêm nhà cung cấp
        public bool Insert(string tenNhaCungCap, object nguoiLienHe, object soDienThoai, object email, object diaChi)
        {
            string query = @"insert into NhaCungCap (TenNhaCungCap, NguoiLienHe, SoDienThoai, Email, DiaChi) values
                            (@TenNhaCungCap, @NguoiLienHe, @SoDienThoai, @Email, @DiaChi)";
            SqlParameter[] parameters = {
                new SqlParameter("@TenNhaCungCap", tenNhaCungCap),
                new SqlParameter("@NguoiLienHe", nguoiLienHe ?? DBNull.Value),
                new SqlParameter("@SoDienThoai", soDienThoai ?? DBNull.Value),
                new SqlParameter("@Email", email ?? DBNull.Value),
                new SqlParameter("@DiaChi", diaChi ?? DBNull.Value)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Cập nhật nhà cung cấp
        public bool Update(int maNhaCungCap, string tenNhaCungCap, object nguoiLienHe, object soDienThoai, object email, object diaChi)
        {
            string query = @"update NhaCungCap set
                                TenNhaCungCap = @TenNhaCungCap,
                                NguoiLienHe = @NguoiLienHe,
                                SoDienThoai = @SoDienThoai,
                                Email = @Email,
                                DiaChi = @DiaChi
                             where MaNhaCungCap = @MaNhaCungCap";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNhaCungCap", maNhaCungCap),
                new SqlParameter("@TenNhaCungCap", tenNhaCungCap),
                new SqlParameter("@NguoiLienHe", nguoiLienHe ?? DBNull.Value),
                new SqlParameter("@SoDienThoai", soDienThoai ?? DBNull.Value),
                new SqlParameter("@Email", email ?? DBNull.Value),
                new SqlParameter("@DiaChi", diaChi ?? DBNull.Value)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Xóa mềm - ngừng hợp tác
        public bool Delete(int maNhaCungCap)
        {
            string query = @"update NhaCungCap 
                             set TrangThai = 0 
                             where MaNhaCungCap = @MaNhaCungCap";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNhaCungCap", maNhaCungCap)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Khôi phục hợp tác
        public bool Restore(int maNhaCungCap)
        {
            string query = @"update NhaCungCap 
                             set TrangThai = 1 
                             where MaNhaCungCap = @MaNhaCungCap";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNhaCungCap", maNhaCungCap)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
