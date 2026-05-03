using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAL
{
    public class ProductCategoryDAL
    {
        //Lấy tất cả danh mục
        public DataTable GetAll()
        {
            string query = "select * from DanhMuc";
            return DataHelper.GetDataTable(query);
        }

        //Lấy 1 danh mục theo mã
        public DataRow GetByID(int maDanhMuc)
        {
            string query = "select * from DanhMuc where MaDanhMuc = @MaDanhMuc";
            SqlParameter[] parameters = {
                new SqlParameter("@MaDanhMuc", maDanhMuc)
            };
            DataTable dt = DataHelper.GetDataTable(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        //Thêm danh mục
        public bool Insert(string tenDanhMuc)
        {
            string query = "insert into DanhMuc (TenDanhMuc) values (@TenDanhMuc)";
            SqlParameter[] parameters = {
                new SqlParameter("@TenDanhMuc", tenDanhMuc)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Cập nhật danh mục
        public bool Update(int maDanhMuc, string tenDanhMuc)
        {
            string query = @"update DanhMuc 
                             set TenDanhMuc = @TenDanhMuc 
                             where MaDanhMuc = @MaDanhMuc";
            SqlParameter[] parameters = {
                new SqlParameter("@MaDanhMuc",  maDanhMuc),
                new SqlParameter("@TenDanhMuc", tenDanhMuc)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Xóa danh mục
        public bool Delete(int maDanhMuc)
        {
            string query = "delete from DanhMuc where MaDanhMuc = @MaDanhMuc";
            SqlParameter[] parameters = {
                new SqlParameter("@MaDanhMuc", maDanhMuc)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Kiểm tra tên danh mục đã tồn tại chưa
        public bool IsExist(string tenDanhMuc)
        {
            string query = "select count(1) from DanhMuc where TenDanhMuc = @TenDanhMuc";
            SqlParameter[] parameters = {
                new SqlParameter("@TenDanhMuc", tenDanhMuc)
            };
            return (int)DataHelper.ExecuteScalar(query, parameters) > 0;
        }

        //Kiểm tra danh mục có sản phẩm không (trước khi xóa)
        public bool HasSanPham(int maDanhMuc)
        {
            string query = "select count(1) from SanPham where MaDanhMuc = @MaDanhMuc";
            SqlParameter[] parameters = {
                new SqlParameter("@MaDanhMuc", maDanhMuc)
            };
            return (int)DataHelper.ExecuteScalar(query, parameters) > 0;
        }
    }
}
