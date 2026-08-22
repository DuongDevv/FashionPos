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
    public partial class frmEditSupplier : Form
    {
        private SupplierBUS bus = new SupplierBUS();
        private int _maNhaCungCap;

        public frmEditSupplier(int maNhaCungCap = 0)
        {
            InitializeComponent();
            _maNhaCungCap = maNhaCungCap;

        }

        private void frmEditSupplier_Load(object sender, EventArgs e)
        {
            if (_maNhaCungCap > 0)
                LoadEditSupplier();
            else
                LoadAddSupplier();
        }

        private void LoadAddSupplier()
        {
            lblTitle.Text = "THÊM NHÀ CUNG CẤP";
        }

        private void LoadEditSupplier()
        {
            lblTitle.Text = "CHỈNH SỬA NHÀ CUNG CẤP";

            try
            {
                DataRow row = bus.GetByID(_maNhaCungCap);
                if (row == null)
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtsSupplierFullName.Text = row["TenNhaCungCap"].ToString();
                txtContactPerson.Text = row["NguoiLienHe"].ToString();
                txtContactPersonPhone.Text = row["SoDienThoai"].ToString();
                txtSupplierEmail.Text = row["Email"].ToString();
                txtSupplierAddress.Text = row["DiaChi"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtContactPersonPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                string tenNCC = txtsSupplierFullName.Text.Trim();
                string nguoiLH = txtContactPerson.Text.Trim();
                string sdt = txtContactPersonPhone.Text.Trim();
                string email = txtSupplierEmail.Text.Trim();
                string diaChi = txtSupplierAddress.Text.Trim();

                object objNguoiLH = string.IsNullOrEmpty(nguoiLH) ? null : (object)nguoiLH;
                object objSDT = string.IsNullOrEmpty(sdt) ? null : (object)sdt;
                object objEmail = string.IsNullOrEmpty(email) ? null : (object)email;
                object objDiaChi = string.IsNullOrEmpty(diaChi) ? null : (object)diaChi;

                if (_maNhaCungCap == 0)
                {
                    bool ok = bus.Insert(tenNCC, objNguoiLH, objSDT, objEmail, objDiaChi);
                    if (ok)
                    {
                        MessageBox.Show("Thêm nhà cung cấp thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    bool ok = bus.Update(_maNhaCungCap, tenNCC, objNguoiLH, objSDT, objEmail, objDiaChi);
                    if (ok)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelSupplier_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
