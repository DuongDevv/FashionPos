using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DAL;


namespace WindowsFormsApp1.BUS
{
    public class CustomerBUS
    {
        private CustomerDAL dal = new CustomerDAL();

        //Lấy tất cả khách hàng
        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        //Tìm kiếm theo tên hoặc SĐT
        public DataTable Search(string keyword)
        {
            return dal.Search(keyword);
        }

        //Lấy 1 khách hàng theo mã
        public DataRow GetByID(int maKhachHang)
        {
            return dal.GetByID(maKhachHang);
        }

        public int GetNextID()
        {
            return dal.GetNextID();
        }

        //Tìm khách theo SĐT (dùng ở POS)
        public DataRow GetBySDT(string soDienThoai)
        {
            if (string.IsNullOrWhiteSpace(soDienThoai))
                throw new System.Exception("Vui lòng nhập số điện thoại!");

            return dal.GetByPhone(soDienThoai);
        }

        //Thêm khách hàng
        public bool Insert(string hoTen, object soDienThoai, object gioiTinh, object email, object diaChi)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                throw new Exception("Vui lòng nhập họ tên!");

            if (soDienThoai != null && !string.IsNullOrEmpty(soDienThoai.ToString()))
            {
                string sdt = soDienThoai.ToString().Trim();

                if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d+$"))
                    throw new Exception("Số điện thoại chỉ được chứa số!");

                if (sdt.Length < 10 || sdt.Length > 11)
                    throw new Exception("Số điện thoại phải từ 10-11 số!");

                // Kiểm tra SĐT đã tồn tại chưa → hiện thông báo thân thiện
                if (dal.IsExistPhone(sdt))
                    throw new Exception($"Số điện thoại {sdt} đã được đăng ký!");
            }

            return dal.Insert(hoTen, soDienThoai, gioiTinh, email, diaChi);
        }

        //Cập nhật khách hàng
        public bool Update(int maKhachHang, string hoTen, object soDienThoai, object gioiTinh, object email, object diaChi)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                throw new Exception("Vui lòng nhập họ tên!");

            if (soDienThoai != null && !string.IsNullOrEmpty(soDienThoai.ToString()))
            {
                string sdt = soDienThoai.ToString().Trim();

                if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d+$"))
                    throw new Exception("Số điện thoại chỉ được chứa số!");

                if (sdt.Length < 10 || sdt.Length > 11)
                    throw new Exception("Số điện thoại phải từ 10-11 số!");

                // Kiểm tra SĐT trùng nhưng bỏ qua chính KH đang sửa
                DataRow kh = dal.GetByPhone(sdt);
                if (kh != null && Convert.ToInt32(kh["MaKhachHang"]) != maKhachHang)
                    throw new Exception($"Số điện thoại {sdt} đã được đăng ký!");
            }

            return dal.Update(maKhachHang, hoTen, soDienThoai, gioiTinh, email, diaChi);
        }

        //Cập nhật điểm sau khi thanh toán
        public bool UpdateDiem(int maKhachHang, int diemCong, decimal soTienChi)
        {
            return dal.UpdateScore(maKhachHang, diemCong, soTienChi);
        }

        //Xóa khách hàng
        public bool Delete(int maKhachHang)
        {
            return dal.Delete(maKhachHang);
        }

        //Tính điểm tích lũy từ số tiền (1000đ = 1 điểm)
        public int TinhDiem(decimal soTien)
        {
            return (int)(soTien / 1000);
        }

        //Tính % giảm giá theo hạng thành viên
        public decimal TinhPhanTramGiam(string loaiThanhVien)
        {
            switch (loaiThanhVien)
            {
                case "Vàng": return 5;
                case "Đen": return 10;
                default: return 0;  // Đồng, Bạc không giảm
            }
        }
    }
}
