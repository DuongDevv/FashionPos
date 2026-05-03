using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.DTO;


namespace WindowsFormsApp1.BUS
{
    public class ProductBUS
    {
        private ProductDAL spDAL = new ProductDAL();
        private ProductVariantDAL btDAL = new ProductVariantDAL();
        private ProductCategoryDAL dmDAL = new ProductCategoryDAL();

        //Danh mục
        public DataTable GetAllProductCategory()
        {
            return dmDAL.GetAll();
        }

        public bool InsertProductCategory(string tenDanhMuc)
        {
            if (string.IsNullOrWhiteSpace(tenDanhMuc))
                throw new System.Exception("Vui lòng nhập tên danh mục!");
            if (dmDAL.IsExist(tenDanhMuc))
                throw new System.Exception("Danh mục đã tồn tại!");

            return dmDAL.Insert(tenDanhMuc);
        }

        public bool UpdateProductCategory(int maDanhMuc, string tenDanhMuc)
        {
            if (string.IsNullOrWhiteSpace(tenDanhMuc))
                throw new System.Exception("Vui lòng nhập tên danh mục!");
            if (dmDAL.IsExist(tenDanhMuc))
                throw new System.Exception("Danh mục đã tồn tại!");

            return dmDAL.Update(maDanhMuc, tenDanhMuc);
        }

        public bool DeleteProductCategory(int maDanhMuc)
        {
            if (dmDAL.HasSanPham(maDanhMuc))
                throw new System.Exception("Danh mục đang có sản phẩm, không thể xóa!");

            return dmDAL.Delete(maDanhMuc);
        }

        //Sản phẩm
        public DataTable GetAll()
        {
            return spDAL.GetAll();
        }

        public DataTable GetActive()
        {
            return spDAL.GetActive();
        }

        public DataRow GetVarianByID(int maBienThe)
        {
            return btDAL.GetByID(maBienThe);
        }

        public DataTable Search(string keyword, int maDanhMuc)
        {
            return spDAL.Search(keyword, maDanhMuc);
        }

        public DataRow GetByID(int maSanPham)
        {
            return spDAL.GetByID(maSanPham);
        }
        public int GetNextID()
        {
            return spDAL.GetNextID();
        }

        public DataTable GetStock()
        {
            return spDAL.GetStock();
        }

        public bool Insert(string tenSanPham, int maDanhMuc, object moTa, object hinhAnh, decimal giaCoBan)
        {
            if (string.IsNullOrWhiteSpace(tenSanPham))
                throw new System.Exception("Vui lòng nhập tên sản phẩm!");
            if (maDanhMuc <= 0)
                throw new System.Exception("Vui lòng chọn danh mục!");
            if (giaCoBan < 0)
                throw new System.Exception("Giá cơ bản không được âm!");

            return spDAL.Insert(tenSanPham, maDanhMuc, moTa, hinhAnh, giaCoBan);
        }

        public int InsertAndGetID(string tenSanPham, int maDanhMuc, object moTa, object hinhAnh, decimal giaCoBan)
        {
            if (string.IsNullOrWhiteSpace(tenSanPham))
                throw new System.Exception("Vui lòng nhập tên sản phẩm!");
            if (maDanhMuc <= 0)
                throw new System.Exception("Vui lòng chọn danh mục!");
            if (giaCoBan < 0)
                throw new System.Exception("Giá cơ bản không được âm!");

            return spDAL.InsertAndGetID(tenSanPham, maDanhMuc, moTa, hinhAnh, giaCoBan);
        }

        public bool Update(int maSanPham, string tenSanPham, int maDanhMuc, object moTa, object hinhAnh, decimal giaCoBan)
        {
            if (string.IsNullOrWhiteSpace(tenSanPham))
                throw new System.Exception("Vui lòng nhập tên sản phẩm!");
            if (maDanhMuc <= 0)
                throw new System.Exception("Vui lòng chọn danh mục!");
            if (giaCoBan < 0)
                throw new System.Exception("Giá cơ bản không được âm!");

            return spDAL.Update(maSanPham, tenSanPham, maDanhMuc, moTa, hinhAnh, giaCoBan);
        }

        public bool Delete(int maSanPham)
        {
            return spDAL.Delete(maSanPham);
        }

        public bool Restore(int maSanPham)
        {
            return spDAL.Restore(maSanPham);
        }

        //Biến thể
        public DataTable GetVarianByProduct(int maSanPham)
        {
            return btDAL.GetBySanPham(maSanPham);
        }

        public DataTable GetVarianAll(string keyword, int maDanhMuc,
                                string mauSac, string kichCo)
    => spDAL.GetVarianAll(keyword, maDanhMuc, mauSac, kichCo);

        public DataTable GetAllColor() => spDAL.GetAllColor();
        public DataTable GetAllSize() => spDAL.GetAllSize();
        public DataTable SearchByVarian(string keyword, int maDanhMuc,
                                          string mauSac, string kichCo)
            => spDAL.SearchByVarian(keyword, maDanhMuc, mauSac, kichCo);


        public bool InsertVarian(int maSanPham, string kichCo, string mauSac, object maBarcode, int soLuongTon, decimal giaBan, object hinhAnh)
        {
            if (string.IsNullOrWhiteSpace(kichCo))
                throw new System.Exception("Vui lòng nhập kích cỡ!");
            if (string.IsNullOrWhiteSpace(mauSac))
                throw new System.Exception("Vui lòng nhập màu sắc!");
            if (giaBan < 0)
                throw new System.Exception("Giá bán không được âm!");
            if (soLuongTon < 0)
                throw new System.Exception("Số lượng tồn không được âm!");
            if (btDAL.IsExist(maSanPham, kichCo, mauSac))
                throw new System.Exception("Biến thể Size + Màu này đã tồn tại!");

            return btDAL.Insert(maSanPham, kichCo, mauSac, soLuongTon, giaBan, hinhAnh);
        }

        public bool UpdateVarian(int maBienThe, string kichCo, string mauSac, object maBarcode, int soLuongTon, decimal giaBan, object hinhAnh)
        {
            if (string.IsNullOrWhiteSpace(kichCo))
                throw new System.Exception("Vui lòng nhập kích cỡ!");
            if (string.IsNullOrWhiteSpace(mauSac))
                throw new System.Exception("Vui lòng nhập màu sắc!");
            if (giaBan < 0)
                throw new System.Exception("Giá bán không được âm!");
            if (soLuongTon < 0)
                throw new System.Exception("Số lượng tồn không được âm!");

            return btDAL.Update(maBienThe, kichCo, mauSac, soLuongTon, giaBan, hinhAnh);
        }

        public bool DeleteVarian(int maBienThe)
        {
            return btDAL.Delete(maBienThe);
        }
    }
}
