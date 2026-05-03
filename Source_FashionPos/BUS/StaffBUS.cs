using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WindowsFormsApp1.DAL;

namespace WindowsFormsApp1.BUS
{
    public class StaffBUS
    {
        private StaffDAL dal = new StaffDAL();

        //Lấy tất cả nhân viên
        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        //Tìm kiếm
        public DataTable Search(string keyword, string chucVu)
        {
            return dal.Search(keyword, chucVu);
        }

        //Lấy 1 nhân viên theo mã
        public DataRow GetByID(int maNhanVien)
        {
            return dal.GetByID(maNhanVien);
        }

        public int GetNextID()
        {
            return dal.GetNextID();
        }

        //Đăng nhập
        public DataRow Login(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                throw new System.Exception("Vui lòng nhập tên đăng nhập!");
            if (string.IsNullOrWhiteSpace(matKhau))
                throw new System.Exception("Vui lòng nhập mật khẩu!");

            return dal.Login(tenDangNhap, matKhau);
        }

        //Thêm nhân viên
        public int Insert(string hoTen, object ngaySinh, object gioiTinh, object soDienThoai, object email, object hinhAnh, object chucVu, string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                throw new System.Exception("Vui lòng nhập họ tên!");
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                throw new System.Exception("Vui lòng nhập tên đăng nhập!");
            if (string.IsNullOrWhiteSpace(matKhau))
                throw new System.Exception("Vui lòng nhập mật khẩu!");
            if (matKhau.Length < 6)
                throw new System.Exception("Mật khẩu phải có ít nhất 6 ký tự!");
            if (dal.IsExistUserName(tenDangNhap))
                throw new System.Exception("Tên đăng nhập đã tồn tại!");
            if (soDienThoai != null && !string.IsNullOrEmpty(soDienThoai.ToString()))
            {
                string sdt = soDienThoai.ToString().Trim();
                if (!Regex.IsMatch(sdt, @"^\d+$"))
                    throw new Exception("Số điện thoại chỉ được chứa số!");
                if (sdt.Length < 10 || sdt.Length > 11)
                    throw new Exception("Số điện thoại phải từ 10-11 số!");
            }

            return dal.Insert(hoTen, ngaySinh, gioiTinh, soDienThoai,
                              email, hinhAnh, chucVu, tenDangNhap, matKhau);
        }

        //Cập nhật nhân viên
        public bool Update(int maNhanVien, string hoTen, object ngaySinh, object gioiTinh, object soDienThoai, object email, object hinhAnh, object chucVu, string trangThai)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                throw new System.Exception("Vui lòng nhập họ tên!");
            if (soDienThoai != null && !string.IsNullOrEmpty(soDienThoai.ToString()))
            {
                string sdt = soDienThoai.ToString().Trim();
                if (!Regex.IsMatch(sdt, @"^\d+$"))
                    throw new Exception("Số điện thoại chỉ được chứa số!");
                if (sdt.Length < 10 || sdt.Length > 11)
                    throw new Exception("Số điện thoại phải từ 10-11 số!");
            }

            return dal.Update(maNhanVien, hoTen, ngaySinh, gioiTinh, soDienThoai, email, hinhAnh, chucVu, trangThai);
        }

        //Đổi mật khẩu
        public bool ChangePassword(int maNhanVien, string matKhauCu, string matKhauMoi, string xacNhanMatKhau)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi))
                throw new System.Exception("Vui lòng nhập mật khẩu mới!");
            if (matKhauMoi.Length < 6)
                throw new System.Exception("Mật khẩu mới phải có ít nhất 6 ký tự!");
            if (matKhauMoi != xacNhanMatKhau)
                throw new System.Exception("Xác nhận mật khẩu không khớp!");

            //Kiểm tra mật khẩu cũ đúng không
            DataRow nv = dal.GetByID(maNhanVien);
            if (nv == null || nv["MatKhau"].ToString() != matKhauCu)
                throw new System.Exception("Mật khẩu cũ không đúng!");

            return dal.ChangePassword(maNhanVien, matKhauMoi);
        }

        //Xóa mềm
        public bool Delete(int maNhanVien)
        {
            return dal.Delete(maNhanVien);
        }

    }
}
