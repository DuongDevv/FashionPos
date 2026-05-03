using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BUS;
using WindowsFormsApp1.Utils;
using WindowsFormsApp1.Views.Auth;

namespace WindowsFormsApp1.UserControls
{
    public partial class ucSetting : UserControl
    {
        private SystemInformationBUS chBUS = new SystemInformationBUS();
        private StaffBUS nvBUS = new StaffBUS();

        private int _maNhanVien => SessionManager.MaNhanVien;
        public ucSetting()
        {
            InitializeComponent();

        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                LoadShopInfo();
                LoadAccountInfo();
                PhanQuyenSetting();
            }
        }

        private void ucSetting_Load(object sender, EventArgs e)
        {

        }
        private void PhanQuyenSetting()
        {
            string chucVu = SessionManager.ChucVu;

            if (chucVu == "Staff")
            {
                // Disable toàn bộ ô thông tin cửa hàng
                txtShopName.Enabled = false;
                txtShopEmail.Enabled = false;
                txtShopPhone.Enabled = false;
                txtShopWebsite.Enabled = false;
                txtShopAddress.Enabled = false;
                txtShopFacebook.Enabled = false;
                txtShopInstagram.Enabled = false;
                txtShopZalo.Enabled = false;
                txtShopTiktok.Enabled = false;

                // Ẩn nút Lưu và Hủy của tab thông tin cửa hàng
                btnSaveShopInformation.Visible = false;
                btnCancelShopInformation.Visible = false;
            }
            else
            {
                // SuperManager và Manager được sửa bình thường
                txtShopName.Enabled = true;
                txtShopEmail.Enabled = true;
                txtShopPhone.Enabled = true;
                txtShopWebsite.Enabled = true;
                txtShopAddress.Enabled = true;
                txtShopFacebook.Enabled = true;
                txtShopInstagram.Enabled = true;
                txtShopZalo.Enabled = true;
                txtShopTiktok.Enabled = true;

                btnSaveShopInformation.Visible = true;
                btnCancelShopInformation.Visible = true;
            }
        }

        // ── Tab 1: Thông tin cửa hàng ────────────────────────
        private void LoadShopInfo()
        {
            try
            {
                txtShopName.Text = chBUS.GetGiaTri("TenCuaHang");
                txtShopEmail.Text = chBUS.GetGiaTri("Email");
                txtShopPhone.Text = chBUS.GetGiaTri("SoDienThoai");
                txtShopWebsite.Text = chBUS.GetGiaTri("Website");
                txtShopAddress.Text = chBUS.GetGiaTri("DiaChi");
                txtShopFacebook.Text = chBUS.GetGiaTri("Facebook");
                txtShopInstagram.Text = chBUS.GetGiaTri("Instagram");
                txtShopZalo.Text = chBUS.GetGiaTri("Zalo");
                txtShopTiktok.Text = chBUS.GetGiaTri("Tiktok");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin cửa hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Tab 2: Thông tin tài khoản ───────────────────────
        private void LoadAccountInfo()
        {
            try
            {
                DataRow nv = nvBUS.GetByID(_maNhanVien);
                if (nv == null) return;

                txtStaffIDSetting.Text = nv["MaNhanVien"].ToString();
                txtStaffNameSetting.Text = nv["HoTen"].ToString();
                txtStaffPhoneSetting.Text = nv["SoDienThoai"].ToString();
                txtStaffEmailSetting.Text = nv["Email"].ToString();
                txtStaffPositionSetting.Text = nv["ChucVu"].ToString();
                txtStaffAccountSetting.Text = nv["TenDangNhap"].ToString();
                txtStaffPasswordSetting.Text = nv["MatKhau"].ToString();
                txtStaffPasswordSetting.UseSystemPasswordChar = true; // Ẩn mặc định
                txtStaffPasswordSetting.Enabled = false;

                // Ngày sinh
                if (nv["NgaySinh"] != DBNull.Value)
                    txtDateStaffSetting.Text = Convert.ToDateTime(nv["NgaySinh"])
                                               .ToString("dd/MM/yyyy");

                // Giới tính
                if (nv["GioiTinh"] != DBNull.Value)
                {
                    int gt = Convert.ToInt32(nv["GioiTinh"]);
                    txtStaffSexSetting.Text = gt == 1 ? "Nam" : gt == 2 ? "Nữ" : "Không xác định";
                }

                // Load ảnh
                string hinhAnh = nv["HinhAnh"] != DBNull.Value
                                 ? nv["HinhAnh"].ToString() : "";
                if (!string.IsNullOrEmpty(hinhAnh))
                {
                    string fullPath = Path.Combine(Application.StartupPath, hinhAnh);
                    if (File.Exists(fullPath))
                    {
                        picStaffAvatarSetting.Image = Image.FromFile(fullPath);
                        picStaffAvatarSetting.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }

                // Các ô chỉ đọc
                txtStaffIDSetting.Enabled = false;
                txtStaffAccountSetting.Enabled = false;
                txtStaffPasswordSetting.Enabled = false;
                txtStaffSexSetting.Enabled = false;
                txtStaffPositionSetting.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin tài khoản: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveShopInformation_Click(object sender, EventArgs e)
        {
            try
            {
                bool ok = chBUS.UpdateAll(
                    txtShopName.Text.Trim(),
                    txtShopPhone.Text.Trim(),
                    txtShopEmail.Text.Trim(),
                    txtShopWebsite.Text.Trim(),
                    txtShopAddress.Text.Trim(),
                    txtShopFacebook.Text.Trim(),
                    txtShopZalo.Text.Trim(),
                    txtShopInstagram.Text.Trim(),
                    txtShopTiktok.Text.Trim()
                );

                if (ok)
                    MessageBox.Show("Lưu thông tin cửa hàng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelShopInformation_Click(object sender, EventArgs e)
        {
            LoadShopInfo();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(_maNhanVien);
            frm.ShowDialog();
            LoadAccountInfo();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtStaffPasswordSetting.UseSystemPasswordChar = !chkShowPass.Checked;
        }
    }
}
