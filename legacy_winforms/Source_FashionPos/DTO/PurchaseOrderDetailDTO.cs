using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class PurchaseOrderDetailDTO
    {
        public int MaChiTietPN { get; set; }
        public int MaPhieuNhap { get; set; }
        public int MaBienThe { get; set; }
        public string TenSanPham { get; set; }  // Join
        public string KichCo { get; set; }       // Join
        public string MauSac { get; set; }       // Join
        public int SoLuong { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
