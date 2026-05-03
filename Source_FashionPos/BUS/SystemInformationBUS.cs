using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DAL;

namespace WindowsFormsApp1.BUS
{
    public class SystemInformationBUS
    {
        private SystemInformationDAL dal = new SystemInformationDAL();

        public string GetGiaTri(string tenCauHinh)
            => dal.GetGiaTri(tenCauHinh);

        public bool UpdateAll(string tenCuaHang, string soDienThoai, string email,
                              string website, string diaChi, string facebook,
                              string zalo, string instagram, string tiktok)
            => dal.UpdateAll(tenCuaHang, soDienThoai, email, website,
                             diaChi, facebook, zalo, instagram, tiktok);
    }
}
