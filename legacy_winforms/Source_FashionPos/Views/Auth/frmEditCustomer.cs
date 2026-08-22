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
    public partial class frmEditCustomer : Form
    {
        private CustomerBUS bus = new CustomerBUS();
        private int _maKhachHang;
        public frmEditCustomer(int maKH = 0)
        {
            InitializeComponent();
            _maKhachHang = maKH;
        }

        private void frmEditCustomer_Load(object sender, EventArgs e)
        {
            // Load ComboBox giới tính
            cboCustomerSex.Items.Clear();
            cboCustomerSex.Items.AddRange(new object[]
            {
                "Không xác định", "Nam", "Nữ"
            });
            cboCustomerSex.SelectedIndex = 0;

            // Các trường chỉ đọc
            txtCustomerID.Enabled = false;
            dtpCustomerDate.Enabled = false;
            txtCustomerRank.Enabled = false;
            txtCustomerTotalSpending.Enabled = false;
            txtCustomerRewardPoints.Enabled = false;

            if (_maKhachHang > 0)
                LoadEditCustomer();
            else
                LoadAddCustomer();
        }
        private void LoadAddCustomer()
        {
            lblTitle.Text = "THÊM KHÁCH HÀNG";
            txtCustomerID.Text = bus.GetNextID().ToString();
            dtpCustomerDate.Value = DateTime.Today;
            txtCustomerRank.Text = "Đồng";
            txtCustomerTotalSpending.Text = "0";
            txtCustomerRewardPoints.Text = "0";
        }

        private void LoadEditCustomer()
        {
            lblTitle.Text = "CHỈNH SỬA KHÁCH HÀNG";

            try
            {
                DataRow row = bus.GetByID(_maKhachHang);
                if (row == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtCustomerID.Text = row["MaKhachHang"].ToString();
                txtCustomerFullName.Text = row["HoTen"].ToString();
                txtCustomerPhone.Text = row["SoDienThoai"].ToString();
                txtCustomerEmail.Text = row["Email"].ToString();
                txtCustomerRank.Text = row["LoaiThanhVien"].ToString();
                txtCustomerTotalSpending.Text = string.Format("{0:N0}", row["TongChiTieu"]);
                txtCustomerRewardPoints.Text = row["DiemTichLuy"].ToString();

                if (row["NgayTao"] != DBNull.Value)
                    dtpCustomerDate.Value = Convert.ToDateTime(row["NgayTao"]);

                if (row["GioiTinh"] != DBNull.Value)
                    cboCustomerSex.SelectedIndex = Convert.ToInt32(row["GioiTinh"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chỉ cho nhập số vào SĐT
        private void txtCustomerPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        public void PreFillPhone(string sdt)
        {
            txtCustomerPhone.Text = sdt;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string hoTen = txtCustomerFullName.Text.Trim();
                string soDienThoai = txtCustomerPhone.Text.Trim();
                string email = txtCustomerEmail.Text.Trim();
                int gioiTinh = cboCustomerSex.SelectedIndex;

                object objSDT = string.IsNullOrEmpty(soDienThoai) ? null : (object)soDienThoai;
                object objEmail = string.IsNullOrEmpty(email) ? null : (object)email;

                if (_maKhachHang == 0)
                {
                    // THÊM MỚI
                    bool ok = bus.Insert(hoTen, objSDT, gioiTinh, objEmail, null);
                    if (ok)
                    {
                        MessageBox.Show("Thêm khách hàng thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // SỬA
                    bool ok = bus.Update(_maKhachHang, hoTen, objSDT, gioiTinh, objEmail, null);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
