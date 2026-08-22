using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DAL;


namespace WindowsFormsApp1.BUS
{
    public class SupplierBUS
    {
        private SupplierDAL dal = new SupplierDAL();

        //Lấy tất cả nhà cung cấp
        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        //Lấy nhà cung cấp đang hợp tác
        public DataTable GetActive()
        {
            return dal.GetActive();
        }

        //Tìm kiếm
        public DataTable Search(string keyword)
        {
            return dal.Search(keyword);
        }

        //Lấy 1 nhà cung cấp theo mã
        public DataRow GetByID(int maNhaCungCap)
        {
            return dal.GetByID(maNhaCungCap);
        }

        //Thêm nhà cung cấp
        public bool Insert(string tenNhaCungCap, object nguoiLienHe, object soDienThoai, object email, object diaChi)
        {
            if (string.IsNullOrWhiteSpace(tenNhaCungCap))
                throw new System.Exception("Vui lòng nhập tên nhà cung cấp!");

            if (soDienThoai != null)
            {
                string sdt = soDienThoai.ToString().Trim();
                if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d+$"))
                    throw new System.Exception("Số điện thoại chỉ được chứa số!");
                if (sdt.Length < 10 || sdt.Length > 11)
                    throw new System.Exception("Số điện thoại phải từ 10-11 số!");
            }

            return dal.Insert(tenNhaCungCap, nguoiLienHe, soDienThoai, email, diaChi);
        }

        //Cập nhật nhà cung cấp
        public bool Update(int maNhaCungCap, string tenNhaCungCap, object nguoiLienHe, object soDienThoai, object email, object diaChi)
        {
            if (string.IsNullOrWhiteSpace(tenNhaCungCap))
                throw new System.Exception("Vui lòng nhập tên nhà cung cấp!");

            if (soDienThoai != null)
            {
                string sdt = soDienThoai.ToString().Trim();
                if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d+$"))
                    throw new System.Exception("Số điện thoại chỉ được chứa số!");
                if (sdt.Length < 10 || sdt.Length > 11)
                    throw new System.Exception("Số điện thoại phải từ 10-11 số!");
            }

            return dal.Update(maNhaCungCap, tenNhaCungCap, nguoiLienHe,
                              soDienThoai, email, diaChi);
        }

        //Ngừng hợp tác
        public bool Delete(int maNhaCungCap)
        {
            return dal.Delete(maNhaCungCap);
        }

        //Khôi phục hợp tác
        public bool Restore(int maNhaCungCap)
        {
            return dal.Restore(maNhaCungCap);
        }
    }
}
