using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class ProductVariantDTO
    {
        public int MaBienThe { get; set; }
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }  // Join từ bảng SanPham
        public string KichCo { get; set; }
        public string MauSac { get; set; }
        public string MaBarcode { get; set; }
        public int SoLuongTon { get; set; }
        public decimal GiaBan { get; set; }
    }
}
