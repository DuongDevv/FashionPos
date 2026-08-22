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
    public partial class frmPickCustomer : Form
    {
        private CustomerBUS bus = new CustomerBUS();
        public int? MaKhachHang { get; private set; } = null;
        public frmPickCustomer()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchByPhone_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSearchByPhone.Text.Trim();

            // Phải đủ 10 số mới tìm
            if (sdt.Length < 10)
            {
                pnlResult.Visible = false;
                return;
            }

            try
            {
                DataRow kh = bus.GetBySDT(sdt);

                if (kh != null)
                {
                    lblCustomerName.Text = kh["HoTen"].ToString();
                    lblCustomerPhone.Text = $"SĐT: {kh["SoDienThoai"]}";
                    pnlResult.Visible = true;
                    pnlResult.Tag = kh["MaKhachHang"];
                }
                else
                {
                    pnlResult.Visible = false;
                }
            }
            catch { }
        }

        private void txtSearchByPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void pnlResult_Click(object sender, EventArgs e)
        {
            if (pnlResult.Tag == null) return;

            MaKhachHang = Convert.ToInt32(pnlResult.Tag);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lblCustomerName_Click(object sender, EventArgs e)
            => pnlResult_Click(sender, e);

        private void lblCustomerPhone_Click(object sender, EventArgs e)
            => pnlResult_Click(sender, e);

        private void frmPickCustomer_Load(object sender, EventArgs e)
        {
            pnlResult.Visible = false;
            txtSearchByPhone.Focus();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmEditCustomer frm = new frmEditCustomer(0);

            // Tự động điền SĐT nếu đã nhập
            string sdt = txtSearchByPhone.Text.Trim();
            if (!string.IsNullOrEmpty(sdt))
                frm.PreFillPhone(sdt);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Tìm lại khách vừa thêm
                if (!string.IsNullOrEmpty(sdt))
                {
                    DataRow kh = bus.GetBySDT(sdt);
                    if (kh != null)
                    {
                        MaKhachHang = Convert.ToInt32(kh["MaKhachHang"]);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // Không có SĐT thì đóng form tìm kiếm thôi
                    this.Close();
                }
            }
        }
    }
}
