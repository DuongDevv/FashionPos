using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Windows.Forms;
using WindowsFormsApp1.BUS;
using WindowsFormsApp1.Utils;

namespace WindowsFormsApp1.Views.Auth
{
    public partial class frmPayment : Form
    {
        private OrderBUS hdBUS = new OrderBUS();
        private CustomerBUS khBUS = new CustomerBUS();

        private int? _maKhachHang;
        private decimal _tongTienHang;
        private decimal _phanTramGiam;
        private decimal _khachCanTra;
        private DataTable _gioHang;
        public frmPayment(int? maKhachHang, decimal tongTienHang,
                          decimal phanTramGiam, decimal khachCanTra,
                          DataTable gioHang)
        {
            InitializeComponent();
            _maKhachHang = maKhachHang;
            _tongTienHang = tongTienHang;
            _phanTramGiam = phanTramGiam;
            _khachCanTra = khachCanTra;
            _gioHang = gioHang;
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            lblTotalPrice.Text = string.Format("{0:N0}đ", _khachCanTra);
            lblChange.Text = "0đ";
            txtAmountTendered.Focus();
        }

        private void txtAmountTendered_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void txtAmountTendered_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmountTendered.Text, out decimal khachDaTra))
            {
                lblChange.Text = "0đ";
                return;
            }

            decimal tienThoi = khachDaTra - _khachCanTra;

            if (tienThoi < 0)
            {
                lblChange.Text = string.Format("-{0:N0}đ", Math.Abs(tienThoi));
                lblChange.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblChange.Text = string.Format("{0:N0}đ", tienThoi);
                lblChange.ForeColor = System.Drawing.Color.FromArgb(230, 100, 30);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtAmountTendered.Text, out decimal khachDaTra))
                    throw new Exception("Vui lòng nhập tiền khách đưa!");

                if (khachDaTra < _khachCanTra)
                    throw new Exception("Tiền khách đưa không đủ!");

                // Lấy mã nhân viên đang đăng nhập
                // TODO: thay bằng session sau khi làm màn hình login
                int maNhanVien = SessionManager.MaNhanVien;

                bool ok = hdBUS.CreateOrder(_maKhachHang, maNhanVien, _tongTienHang, "%", _phanTramGiam, _khachCanTra, khachDaTra, "Tiền mặt", null, _gioHang);

                if (ok)
                {
                    MessageBox.Show("Thanh toán thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
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
    }
}
