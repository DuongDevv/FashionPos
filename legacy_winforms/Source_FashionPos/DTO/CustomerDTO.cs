using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class CustomerDTO
    {
        public int MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public byte? GioiTinh { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public decimal TongChiTieu { get; set; }
        public int DiemTichLuy { get; set; }
        public DateTime NgayTao { get; set; }
        public string LoaiThanhVien { get; set; }
    }
}
