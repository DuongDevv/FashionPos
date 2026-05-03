using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class OrderDTO
    {
        public int MaHoaDon { get; set; }
        public string SoHoaDon { get; set; }
        public int? MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }  // Join từ KhachHang
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }   // Join từ NhanVien
        public DateTime NgayLap { get; set; }
        public decimal TongTienHang { get; set; }
        public string LoaiGiamGia { get; set; }   // 'VND' hoặc '%'
        public decimal GiamGia { get; set; }
        public decimal KhachCanTra { get; set; }
        public decimal KhachDaTra { get; set; }
        public decimal TienThoi { get; set; }     // Computed
        public string PhuongThucThanhToan { get; set; }
        public int DiemTichDuoc { get; set; }
        public string GhiChu { get; set; }
    }
}
