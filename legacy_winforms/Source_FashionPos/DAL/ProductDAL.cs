using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAL
{
    public class ProductDAL
    {
        //Lấy danh sách sản phẩm
        public DataTable GetAll()
        {
            string query = @"select sp.MaSanPham, sp.TenSanPham, 
                                    dm.TenDanhMuc, sp.MoTa, 
                                    sp.HinhAnh, sp.GiaCoBan, 
                                    sp.NgayTao, sp.TrangThai
                             from SanPham sp
                             join DanhMuc dm on sp.MaDanhMuc = dm.MaDanhMuc";
            return DataHelper.GetDataTable(query);
        }

        //Lấy sản phẩm đang bán (Trạng thái =1)
        public DataTable GetActive()
        {
            string query = @"select sp.MaSanPham, sp.TenSanPham, 
                                    dm.TenDanhMuc, sp.MoTa, 
                                    sp.HinhAnh, sp.GiaCoBan, 
                                    sp.NgayTao, sp.TrangThai
                             from SanPham sp
                             join DanhMuc dm on sp.MaDanhMuc = dm.MaDanhMuc
                             where sp.TrangThai = 1";
            return DataHelper.GetDataTable(query);
        }

        public DataTable GetAllColor()
        {
            string query = "SELECT DISTINCT MauSac FROM BienTheSanPham ORDER BY MauSac";
            return DataHelper.GetDataTable(query);
        }

        public int GetNextID()
        {
            string query = "SELECT ISNULL(MAX(MaSanPham), 0) + 1 FROM SanPham";
            object result = DataHelper.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 1;
        }

        public DataTable GetAllSize()
        {
            string query = "SELECT DISTINCT KichCo FROM BienTheSanPham ORDER BY KichCo";
            return DataHelper.GetDataTable(query);
        }
        public DataTable SearchByVarian(string keyword, int maDanhMuc,
                                  string mauSac, string kichCo)
        {
            string query = @"SELECT DISTINCT sp.MaSanPham, sp.TenSanPham,
                            dm.TenDanhMuc, sp.GiaCoBan,
                            sp.NgayTao, sp.TrangThai
                     FROM SanPham sp
                     JOIN DanhMuc dm         ON sp.MaDanhMuc  = dm.MaDanhMuc
                     JOIN BienTheSanPham bt  ON bt.MaSanPham  = sp.MaSanPham
                     WHERE sp.TenSanPham LIKE @Keyword";

            if (maDanhMuc > 0) query += " AND sp.MaDanhMuc = @MaDanhMuc";
            if (mauSac != "Tất cả") query += " AND bt.MauSac = @MauSac";
            if (kichCo != "Tất cả") query += " AND bt.KichCo = @KichCo";

            SqlParameter[] parameters = {
        new SqlParameter("@Keyword",   "%" + keyword + "%"),
        new SqlParameter("@MaDanhMuc", maDanhMuc),
        new SqlParameter("@MauSac",    mauSac),
        new SqlParameter("@KichCo",    kichCo)
    };
            return DataHelper.GetDataTable(query, parameters);
        }

        //Tìm kiếm sản phẩm theo danh mục (loại sản phẩm)
        public DataTable Search(string keyword, int maDanhMuc)
        {
            string query = @"select sp.MaSanPham, sp.TenSanPham, 
                                    dm.TenDanhMuc, sp.MoTa, 
                                    sp.HinhAnh, sp.GiaCoBan, 
                                    sp.NgayTao, sp.TrangThai
                             from SanPham sp
                             join DanhMuc dm on sp.MaDanhMuc = dm.MaDanhMuc
                             where sp.TenSanPham LIKE @Keyword";
            if (maDanhMuc > 0)
                query += " and sp.MaDanhMuc = @MaDanhMuc";

            SqlParameter[] parameters = {
                new SqlParameter("@Keyword",   "%" + keyword + "%"),
                new SqlParameter("@MaDanhMuc", maDanhMuc)
            };
            return DataHelper.GetDataTable(query, parameters);
        }

        public DataTable GetVarianAll(string keyword, int maDanhMuc,
                                string mauSac, string kichCo)
        {
            string query = @"SELECT bt.MaBienThe, sp.TenSanPham,
                            bt.MauSac, bt.KichCo,
                            bt.SoLuongTon, bt.GiaBan
                     FROM BienTheSanPham bt
                     JOIN SanPham sp ON bt.MaSanPham = sp.MaSanPham
                     JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                     WHERE sp.TrangThai = 1
                     AND sp.TenSanPham LIKE @Keyword";

            if (maDanhMuc > 0) query += " AND sp.MaDanhMuc = @MaDanhMuc";
            if (mauSac != "Tất cả") query += " AND bt.MauSac = @MauSac";
            if (kichCo != "Tất cả") query += " AND bt.KichCo = @KichCo";

            query += " ORDER BY sp.TenSanPham";

            SqlParameter[] parameters = {
        new SqlParameter("@Keyword",   "%" + keyword + "%"),
        new SqlParameter("@MaDanhMuc", maDanhMuc),
        new SqlParameter("@MauSac",    mauSac),
        new SqlParameter("@KichCo",    kichCo)
    };
            return DataHelper.GetDataTable(query, parameters);
        }

        //Lấy tồn kho
        public DataTable GetStock()
        {
            string query = @"SELECT sp.TenSanPham, bt.MauSac, bt.KichCo,
                            bt.SoLuongTon, bt.GiaBan, dm.TenDanhMuc
                     FROM BienTheSanPham bt
                     JOIN SanPham sp ON bt.MaSanPham = sp.MaSanPham
                     JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                     WHERE sp.TrangThai = 1
                     ORDER BY bt.SoLuongTon ASC";
            return DataHelper.GetDataTable(query);
        }

        //Lấy sản phẩm theo mã sản phẩm
        public DataRow GetByID(int id)
        {
            string query = @"select sp.*, dm.TenDanhMuc 
                             from SanPham sp
                             join DanhMuc dm on sp.MaDanhMuc = dm.MaDanhMuc
                             where sp.MaSanPham = @MaSanPham";
            SqlParameter[] parameters = {
                new SqlParameter("@MaSanPham", id)
            };
            DataTable dt = DataHelper.GetDataTable(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        //Thêm sản phẩm
        public bool Insert(string tenSanPham, int maDanhMuc, object moTa, object hinhAnh, decimal giaCoBan)
        {
            string query = @"insert into SanPham (TenSanPham, MaDanhMuc, MoTa, HinhAnh, GiaCoBan) values
                            (@TenSanPham, @MaDanhMuc, @MoTa, @HinhAnh, @GiaCoBan)";
            SqlParameter[] parameters = {
                new SqlParameter("@TenSanPham", tenSanPham),
                new SqlParameter("@MaDanhMuc",  maDanhMuc),
                new SqlParameter("@MoTa",       moTa    ?? DBNull.Value),
                new SqlParameter("@HinhAnh",    hinhAnh ?? DBNull.Value),
                new SqlParameter("@GiaCoBan",   giaCoBan)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Lấy id sản phẩm vừa thêm (dùng khi cần thêm biến thể ngay sau)
        public int InsertAndGetID(string tenSanPham, int maDanhMuc, object moTa,
                                   object hinhAnh, decimal giaCoBan)
        {
            string query = @"insert into SanPham (TenSanPham, MaDanhMuc, MoTa, HinhAnh, GiaCoBan) values
                            (@TenSanPham, @MaDanhMuc, @MoTa, @HinhAnh, @GiaCoBan);
                            select scope_identity();";
            SqlParameter[] parameters = {
                new SqlParameter("@TenSanPham", tenSanPham),
                new SqlParameter("@MaDanhMuc",  maDanhMuc),
                new SqlParameter("@MoTa",       moTa    ?? DBNull.Value),
                new SqlParameter("@HinhAnh",    hinhAnh ?? DBNull.Value),
                new SqlParameter("@GiaCoBan",   giaCoBan)
            };
            object result = DataHelper.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        //Cập nhật sản phẩm
        public bool Update(int maSanPham, string tenSanPham, int maDanhMuc, object moTa, object hinhAnh, decimal giaCoBan)
        {
            string query = @"update SanPham set
                                TenSanPham = @TenSanPham,
                                MaDanhMuc  = @MaDanhMuc,
                                MoTa       = @MoTa,
                                HinhAnh    = @HinhAnh,
                                GiaCoBan   = @GiaCoBan
                             where MaSanPham = @MaSanPham";
            SqlParameter[] parameters = {
                new SqlParameter("@MaSanPham", maSanPham),
                new SqlParameter("@TenSanPham", tenSanPham),
                new SqlParameter("@MaDanhMuc", maDanhMuc),
                new SqlParameter("@MoTa", moTa ?? DBNull.Value),
                new SqlParameter("@HinhAnh", hinhAnh ?? DBNull.Value),
                new SqlParameter("@GiaCoBan", giaCoBan)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Xóa mềm (Phòng trường hợp khóa ngoại)
        public bool Delete(int maSanPham)
        {
            string query = @"update SanPham 
                             set TrangThai = 0 
                             where MaSanPham = @MaSanPham";
            SqlParameter[] parameters = {
                new SqlParameter("@MaSanPham", maSanPham)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        //Hiện lại sản phẩm đã xóa mềm  
        public bool Restore(int maSanPham)
        {
            string query = @"update SanPham 
                             set TrangThai = 1 
                             where MaSanPham = @MaSanPham";
            SqlParameter[] parameters = {
                new SqlParameter("@MaSanPham", maSanPham)
            };
            return DataHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
