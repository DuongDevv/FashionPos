using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DAL;


namespace WindowsFormsApp1.BUS
{
    public class OrderBUS
    {
        private OrderDAL hdDAL = new OrderDAL();
        private CustomerDAL khDAL = new CustomerDAL();
        private ProductVariantDAL btDAL = new ProductVariantDAL();

        //Lấy tất cả hóa đơn
        public DataTable GetAll()
        {
            return hdDAL.GetAll();
        }

        //Lấy hóa đơn theo khoảng ngày
        public DataTable GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
                throw new Exception("Ngày bắt đầu không được lớn hơn ngày kết thúc!");

            return hdDAL.GetByDateRange(fromDate, toDate);
        }

        //Lấy chi tiết hóa đơn
        public DataTable GetOrderDetai(int maHoaDon)
        {
            return hdDAL.GetOrderDetail(maHoaDon);
        }

        //Lấy doanh thu theo ngày (dashboard)
        public DataTable GetDailyRevenue(DateTime tuNgay, DateTime denNgay)
        {
            return hdDAL.GetDailyRevenue(tuNgay, denNgay);
        }

        //Tính tổng tiền hàng từ giỏ hàng
        public decimal CalculateSubtotal(DataTable gioHang)
        {
            decimal tong = 0;
            foreach (DataRow row in gioHang.Rows)
                tong += Convert.ToDecimal(row["ThanhTien"]);
            return tong;
        }

        //Tính tiền khách cần trả sau giảm giá
        public decimal TotalPayable(decimal tongTienHang, string loaiGiamGia, decimal giamGia)
        {
            if (loaiGiamGia == "%")
            {
                if (giamGia < 0 || giamGia > 100)
                    throw new Exception("Phần trăm giảm giá phải từ 0 đến 100!");

                decimal tienGiam = tongTienHang * giamGia / 100;
                return tongTienHang - tienGiam;
            }
            else
            {
                if (giamGia < 0)
                    throw new Exception("Số tiền giảm không được âm!");
                if (giamGia > tongTienHang)
                    throw new Exception("Số tiền giảm không được lớn hơn tổng tiền hàng!");

                return tongTienHang - giamGia;
            }
        }

        //Tạo hóa đơn
        public bool CreateOrder(
            int? maKhachHang, int maNhanVien,
            decimal tongTienHang, string loaiGiamGia, decimal giamGia,
            decimal khachCanTra, decimal khachDaTra,
            string phuongThucThanhToan, string ghiChu,
            DataTable gioHang)
        {
            if (gioHang == null || gioHang.Rows.Count == 0)
                throw new Exception("Giỏ hàng trống, vui lòng thêm sản phẩm!");
            if (khachDaTra < khachCanTra)
                throw new Exception("Tiền khách đưa không đủ!");
            if (string.IsNullOrWhiteSpace(phuongThucThanhToan))
                throw new Exception("Vui lòng chọn phương thức thanh toán!");

            //Kiểm tra tồn kho từng sản phẩm
            foreach (DataRow row in gioHang.Rows)
            {
                int maBienThe = Convert.ToInt32(row["MaBienThe"]);
                int soLuong = Convert.ToInt32(row["SoLuong"]);

                DataRow bienThe = btDAL.GetByID(maBienThe);
                if (bienThe == null)
                    throw new Exception("Sản phẩm không tồn tại!");

                int tonKho = Convert.ToInt32(bienThe["SoLuongTon"]);
                if (soLuong > tonKho)
                    throw new Exception($"{bienThe["TenSanPham"]} - {bienThe["KichCo"]} - {bienThe["MauSac"]} chỉ còn {tonKho} sản phẩm!");
            }

            //Tính điểm tích lũy (1000đ = 1 điểm)
            int diemTichDuoc = maKhachHang.HasValue ? (int)(khachCanTra / 1000) : 0;

            return hdDAL.CreateOrder(
                maKhachHang, maNhanVien,
                tongTienHang, loaiGiamGia, giamGia,
                khachCanTra, khachDaTra,
                phuongThucThanhToan, diemTichDuoc,
                ghiChu, gioHang);
        }

        //Tạo DataTable giỏ hàng (dùng ở ucSell)
        public DataTable CreateCard()
        {
            DataTable gioHang = new DataTable();
            gioHang.Columns.Add("MaBienThe", typeof(int));
            gioHang.Columns.Add("TenSanPham", typeof(string));
            gioHang.Columns.Add("KichCo", typeof(string));
            gioHang.Columns.Add("MauSac", typeof(string));
            gioHang.Columns.Add("SoLuong", typeof(int));
            gioHang.Columns.Add("DonGia", typeof(decimal));
            gioHang.Columns.Add("ThanhTien", typeof(decimal));
            return gioHang;
        }

        //Thêm sản phẩm vào giỏ hàng
        public void AddToCart(DataTable gioHang, int maBienThe, string tenSanPham, string kichCo, string mauSac, int soLuong, decimal donGia)
        {
            //Nếu sản phẩm đã có trong giỏ thì cộng thêm số lượng
            foreach (DataRow row in gioHang.Rows)
            {
                if (Convert.ToInt32(row["MaBienThe"]) == maBienThe)
                {
                    row["SoLuong"] = Convert.ToInt32(row["SoLuong"]) + soLuong;
                    row["ThanhTien"] = Convert.ToDecimal(row["DonGia"]) * Convert.ToInt32(row["SoLuong"]);
                    return;
                }
            }

            //Chưa có thì thêm mới
            gioHang.Rows.Add(maBienThe, tenSanPham, kichCo, mauSac, soLuong, donGia, soLuong * donGia);
        }

        //Xóa sản phẩm khỏi giỏ hàng
        public void RemoveCartItem(DataTable gioHang, int maBienThe)
        {
            foreach (DataRow row in gioHang.Rows)
            {
                if (Convert.ToInt32(row["MaBienThe"]) == maBienThe)
                {
                    row.Delete();
                    break;
                }
            }
            gioHang.AcceptChanges();
        }

        //Lấy sản phẩm bán chạy
        public DataTable GetBestSellingProducts(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay > denNgay)
                throw new Exception("Ngày bắt đầu không được lớn hơn ngày kết thúc!");
            return hdDAL.GetBestSellingProducts(tuNgay, denNgay);
        }
    }
}
