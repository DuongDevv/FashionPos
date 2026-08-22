using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views.Auth
{
    public partial class frmInputQuantity : Form
    {
        public int SoLuong { get; private set; }
        public decimal GiaNhap { get; private set; }
        public frmInputQuantity()
        {
            InitializeComponent();
        }

        private void frmInputQuantity_Load(object sender, EventArgs e)
        {
            txtInputQuantity.Text = "1";
            txtInputPrice.Text = "0";
            txtInputQuantity.Focus();
            txtInputQuantity.SelectAll();
        }

        private void txtInputQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void txtInputPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void txtInputQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtInputPrice.Focus();
                txtInputPrice.SelectAll();
            }
        }

        private void txtInputPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSaveInput_Click(sender, e);
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInputQuantity.Text, out int sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInputQuantity.Focus();
                txtInputQuantity.SelectAll();
                return;
            }

            if (!decimal.TryParse(txtInputPrice.Text, out decimal gia) || gia <= 0)
            {
                MessageBox.Show("Giá nhập phải lớn hơn 0!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInputPrice.Focus();
                txtInputPrice.SelectAll();
                return;
            }

            SoLuong = sl;
            GiaNhap = gia;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelInput_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
