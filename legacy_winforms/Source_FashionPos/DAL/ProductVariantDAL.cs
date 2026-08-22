using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAL
{
    public class ProductVariantDAL
    {
        //Lấy biến thể sản phẩm
        public DataTable GetAll()
        {
            string query = @"select bt.MaBienThe, sp.TenSanPham, 
                                    bt.KichCo, bt.MauSac,
                                    bt.SoLuongTon, bt.GiaBan
                             from BienTheSanPham bt
                             join SanPham sp on bt.MaSanPham = sp.MaSanPham";
            return DataHelper.GetDataTable(query);
        }

        //Lấy tất cả biến thể theo mã sản phẩm
        public DataTable GetBySanPham(int maSanPham)
        {
            string query = @"select * from BienTheSanPham 
                             where MaSanPham = @MaSanPham";
            SqlParameter[] parameters = {
                new SqlParameter("@MaSanPham", maSanPham)
            };
            return DataHelper.GetDataTable(query, parameters);
        }

        //Lấy 1 biến thể theo mã
        public DataRow GetByID(int maBienThe)
        {
            string query = @"select bt.*, sp.TenSanPham 
                             from BienTheSanPham bt
                             join SanPham sp on bt.MaSanPham = sp.MaSanPham
                             where bt.MaBienThe = @MaBienThe";
            SqlParameter[] parameters = {
                new SqlParameter("@MaBienThe", maBienThe)
            };
            DataTable dt = DataHelper.GetDataTable(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        //Thêm biến thể
        public bool Insert(int maSanPham, string kichCo, string mauSac, int soLuongTon, decimal giaBan, object hinhAnh)
        {
            string query = @"insert into BienTheSanPham (MaSanPham, KichCo, MauSac, SoLuongTon, GiaBan, HinhAnh) values
                                (@MaSanPham, @KichCo, @MauSac, @SoLuongTon, @GiaBan, @HinhAnh)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaSanPham", maSanPham),
                new SqlParameter("@KichCo", kichCo),
                new SqlParameter("@MauSac", mauSac),
                new SqlParameter("@SoLuongTon", soLuongTon),
                new SqlParameter("@GiaBan", giaBan),
                new SqlParameter("@HinhAnh", hinhAnh ?? DBNull.Value)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Cập nhật biến thể
        public bool Update(int maBienThe, string kichCo, string mauSac, int soLuongTon, decimal giaBan, object hinhAnh)
        {
            string query = @"update BienTheSanPham set
                                KichCo = @KichCo,
                                MauSac = @MauSac,
                                SoLuongTon = @SoLuongTon,
                                GiaBan = @GiaBan,
                                HinhAnh = @HinhAnh
                             where MaBienThe = @MaBienThe";
            SqlParameter[] parameters = {
                new SqlParameter("@MaBienThe", maBienThe),
                new SqlParameter("@KichCo", kichCo),
                new SqlParameter("@MauSac", mauSac),
                new SqlParameter("@SoLuongTon", soLuongTon),
                new SqlParameter("@GiaBan", giaBan),
                new SqlParameter("@HinhAnh", hinhAnh ?? DBNull.Value)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Cập nhật số lượng tồn sau khi bán hoặc nhập hàng
        public bool UpdateSoLuong(int maBienThe, int soLuongThayDoi)
        {
            string query = @"update BienTheSanPham 
                             set SoLuongTon = SoLuongTon + @SoLuongThayDoi
                             where MaBienThe = @MaBienThe";
            SqlParameter[] parameters = {
                new SqlParameter("@MaBienThe",      maBienThe),
                new SqlParameter("@SoLuongThayDoi", soLuongThayDoi)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Xóa biến thể
        public bool Delete(int maBienThe)
        {
            string query = @"delete from BienTheSanPham 
                             where MaBienThe = @MaBienThe";
            SqlParameter[] parameters = {
                new SqlParameter("@MaBienThe", maBienThe)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Kiểm tra biến thể đã tồn tại chưa (tránh duplicate Size + Màu)
        public bool IsExist(int maSanPham, string kichCo, string mauSac)
        {
            string query = @"select count(1) from BienTheSanPham 
                             where MaSanPham = @MaSanPham 
                             and KichCo = @KichCo 
                             and MauSac = @MauSac";
            SqlParameter[] parameters = {
                new SqlParameter("@MaSanPham", maSanPham),
                new SqlParameter("@KichCo",    kichCo),
                new SqlParameter("@MauSac",    mauSac)
            };
            return (int)DataHelper.ExecuteScalar(query, parameters) > 0;
        }
    }
}
