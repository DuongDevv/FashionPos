using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class PurchaseOrderDTO
    {
        public int MaPhieuNhap { get; set; }
        public string SoPhieuNhap { get; set; }
        public int MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }  // Join
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }    // Join
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public string GhiChu { get; set; }
    }
}
