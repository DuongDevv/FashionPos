using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAL
{
    public class SystemInformationDAL
    {
        //Lấy tất cả cấu hình
        public DataTable GetAll()
        {
            string query = "select * from CauHinhHeThong";
            return DataHelper.GetDataTable(query);
        }

        //Lấy giá trị 1 cấu hình theo tên key
        public string GetGiaTri(string tenCauHinh)
        {
            string query = @"select GiaTri from CauHinhHeThong 
                             where TenCauHinh = @TenCauHinh";
            SqlParameter[] parameters = {
                new SqlParameter("@TenCauHinh", tenCauHinh)
            };
            object result = DataHelper.ExecuteScalar(query, parameters);
            return result == null || result == System.DBNull.Value ? "" : result.ToString();
        }

        //Cập nhật 1 cấu hình
        public bool Update(string tenCauHinh, string giaTri)
        {
            string query = @"update CauHinhHeThong 
                             set GiaTri = @GiaTri 
                             where TenCauHinh = @TenCauHinh";
            SqlParameter[] parameters = {
                new SqlParameter("@TenCauHinh", tenCauHinh),
                new SqlParameter("@GiaTri", giaTri ?? "")
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Cập nhật nhiều cấu hình cùng lúc (dùng cho trang Setting)
        public bool UpdateAll(string tenCuaHang, string soDienThoai, string email, string website, string diaChi, string facebook, string zalo, string instagram, string tiktok)
        {
            string connStr = DataHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string query = @"update CauHinhHeThong 
                                     set GiaTri = @GiaTri 
                                     where TenCauHinh = @TenCauHinh";

                    //Danh sách key-value cần update
                    var configs = new (string Key, string Value)[]
                    {
                        ("TenCuaHang",  tenCuaHang),
                        ("SoDienThoai", soDienThoai),
                        ("Email",       email),
                        ("Website",     website),
                        ("DiaChi",      diaChi),
                        ("Facebook",    facebook),
                        ("Zalo",        zalo),
                        ("Instagram",   instagram),
                        ("Tiktok",      tiktok)
                    };

                    foreach (var config in configs)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@TenCauHinh", config.Key);
                        cmd.Parameters.AddWithValue("@GiaTri", config.Value ?? "");
                        cmd.ExecuteNonQuery();
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
