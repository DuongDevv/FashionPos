using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DAL;

namespace WindowsFormsApp1.BUS
{
    public class PurchaseOrderBUS
    {
        private PurchaseOrderDAL pnDAL = new PurchaseOrderDAL();
        private ProductVariantDAL btDAL = new ProductVariantDAL();

        //Lấy tất cả phiếu nhập
        public DataTable GetAll()
        {
            return pnDAL.GetAll();
        }

        //Lấy phiếu nhập theo khoảng ngày
        public DataTable GetByDateRange(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay > denNgay)
                throw new Exception("Ngày bắt đầu không được lớn hơn ngày kết thúc!");

            return pnDAL.GetByDateRange(tuNgay, denNgay);
        }

        //Lấy chi tiết phiếu nhập
        public DataTable GetChiTiet(int maPhieuNhap)
        {
            return pnDAL.GetChiTiet(maPhieuNhap);
        }

        //Tính tổng tiền từ danh sách nhập
        public decimal CalculateSubtotal(DataTable danhSachNhap)
        {
            decimal tong = 0;
            foreach (DataRow row in danhSachNhap.Rows)
                tong += Convert.ToDecimal(row["ThanhTien"]);
            return tong;
        }

        //Tạo phiếu nhập
        public bool CreatePhieuNhap(int maNhaCungCap, int maNhanVien, string ghiChu, DataTable danhSachNhap)
        {
            if (maNhaCungCap <= 0)
                throw new Exception("Vui lòng chọn nhà cung cấp!");
            if (danhSachNhap == null || danhSachNhap.Rows.Count == 0)
                throw new Exception("Danh sách nhập hàng trống!");

            //Kiểm tra số lượng từng dòng
            foreach (DataRow row in danhSachNhap.Rows)
            {
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal giaNhap = Convert.ToDecimal(row["GiaNhap"]);

                if (soLuong <= 0)
                    throw new Exception("Số lượng nhập phải lớn hơn 0!");
                if (giaNhap <= 0)
                    throw new Exception("Giá nhập phải lớn hơn 0!");
            }

            decimal tongTien = CalculateSubtotal(danhSachNhap);

            return pnDAL.CreatePhieuNhap(maNhaCungCap, maNhanVien, tongTien, ghiChu, danhSachNhap);
        }

        //Tạo DataTable danh sách nhập (dùng ở ucStok_in)
        public DataTable CreateListInput()
        {
            DataTable ds = new DataTable();
            ds.Columns.Add("MaBienThe", typeof(int));
            ds.Columns.Add("TenSanPham", typeof(string));
            ds.Columns.Add("KichCo", typeof(string));
            ds.Columns.Add("MauSac", typeof(string));
            ds.Columns.Add("SoLuong", typeof(int));
            ds.Columns.Add("GiaNhap", typeof(decimal));
            ds.Columns.Add("ThanhTien", typeof(decimal));
            return ds;
        }

        //Thêm sản phẩm vào danh sách nhập
        public void AddToList(DataTable danhSach, int maBienThe, string tenSanPham, string kichCo, string mauSac, int soLuong, decimal giaNhap)
        {
            if (soLuong <= 0)
                throw new Exception("Số lượng nhập phải lớn hơn 0!");
            if (giaNhap <= 0)
                throw new Exception("Giá nhập phải lớn hơn 0!");

            foreach (DataRow row in danhSach.Rows)
            {
                if (Convert.ToInt32(row["MaBienThe"]) == maBienThe)
                {
                    row["SoLuong"] = Convert.ToInt32(row["SoLuong"]) + soLuong;
                    row["ThanhTien"] = Convert.ToDecimal(row["GiaNhap"])
                                       * Convert.ToInt32(row["SoLuong"]);
                    return;
                }
            }

            //Chưa có thì thêm mới
            danhSach.Rows.Add(maBienThe, tenSanPham, kichCo, mauSac, soLuong, giaNhap, soLuong * giaNhap);
        }

        //Xóa sản phẩm khỏi danh sách nhập
        public void XoaKhoiDanhSach(DataTable danhSach, int maBienThe)
        {
            foreach (DataRow row in danhSach.Rows)
            {
                if (Convert.ToInt32(row["MaBienThe"]) == maBienThe)
                {
                    row.Delete();
                    break;
                }
            }
            danhSach.AcceptChanges();
        }
    }
}

