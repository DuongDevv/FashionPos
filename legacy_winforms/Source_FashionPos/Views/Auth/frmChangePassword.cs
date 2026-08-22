using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BUS;

namespace WindowsFormsApp1.Views.Auth
{
    public partial class frmChangePassword : Form
    {
        private StaffBUS bus = new StaffBUS();
        private int _maNhanVien;

        public frmChangePassword(int maNhanVien)
        {
            InitializeComponent();
            _maNhanVien = maNhanVien;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtOldPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmNewPassword.UseSystemPasswordChar = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string matKhauCu = txtOldPassword.Text.Trim();
                string matKhauMoi = txtNewPassword.Text.Trim();
                string xacNhan = txtConfirmNewPassword.Text.Trim();

                bool ok = bus.ChangePassword(
                    _maNhanVien, matKhauCu, matKhauMoi, xacNhan);

                if (ok)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            string matKhau = txtNewPassword.Text;

            if (string.IsNullOrEmpty(matKhau))
            {
                lblStrength.Text = "";
                txtNewPassword.BackColor = SystemColors.Window;
                return;
            }

            int score = TinhDoManh(matKhau);

            switch (score)
            {
                case 1:
                    lblStrength.Text = "Rất yếu";
                    lblStrength.ForeColor = Color.Red;
                    txtNewPassword.BackColor = Color.FromArgb(255, 220, 220); // Đỏ nhạt
                    break;
                case 2:
                    lblStrength.Text = "Yếu";
                    lblStrength.ForeColor = Color.OrangeRed;
                    txtNewPassword.BackColor = Color.FromArgb(255, 235, 205); // Cam nhạt
                    break;
                case 3:
                    lblStrength.Text = "Trung bình";
                    lblStrength.ForeColor = Color.Orange;
                    txtNewPassword.BackColor = Color.FromArgb(255, 255, 200); // Vàng nhạt
                    break;
                case 4:
                    lblStrength.Text = "Mạnh";
                    lblStrength.ForeColor = Color.Green;
                    txtNewPassword.BackColor = Color.FromArgb(200, 255, 200); // Xanh nhạt
                    break;
                case 5:
                    lblStrength.Text = "Rất mạnh 💪";
                    lblStrength.ForeColor = Color.DarkGreen;
                    txtNewPassword.BackColor = Color.FromArgb(180, 255, 180); // Xanh đậm hơn
                    break;
            }
        }
        private int TinhDoManh(string matKhau)
        {
            int score = 0;

            // Tiêu chí 1: Độ dài >= 6
            if (matKhau.Length >= 6) score++;

            // Tiêu chí 2: Độ dài >= 10
            if (matKhau.Length >= 10) score++;

            // Tiêu chí 3: Có chữ hoa
            if (System.Text.RegularExpressions.Regex.IsMatch(matKhau, @"[A-Z]")) score++;

            // Tiêu chí 4: Có số
            if (System.Text.RegularExpressions.Regex.IsMatch(matKhau, @"[0-9]")) score++;

            // Tiêu chí 5: Có ký tự đặc biệt
            if (System.Text.RegularExpressions.Regex.IsMatch(matKhau, @"[!@#$%^&*(),.?""':{}|<>]")) score++;

            return score;
        }




    }
}
