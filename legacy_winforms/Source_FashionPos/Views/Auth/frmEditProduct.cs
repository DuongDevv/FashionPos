using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApp1.BUS;

namespace WindowsFormsApp1.Views.Auth
{
    public partial class frmEditProduct : Form
    {
        private ProductBUS bus = new ProductBUS();
        private int _maSanPham;
        private string _imgPath = null;

        public frmEditProduct(int maSanPham = 0)
        {
            InitializeComponent();
            _maSanPham = maSanPham;
        }

        private void frmEditProduct_Load(object sender, EventArgs e)
        {
            CategoryType();
            dtpProductDate.Enabled = false;

            if (_maSanPham > 0)
                LoadEditProduct();
            else
                LoadAddProduct();
        }
        private void CategoryType()
        {
            DataTable dt = bus.GetAllProductCategory();
            cboProductCategory.Items.Clear();
            foreach (DataRow row in dt.Rows)
                cboProductCategory.Items.Add(row["TenDanhMuc"].ToString());

            if (cboProductCategory.Items.Count > 0)
                cboProductCategory.SelectedIndex = 0;
        }
        private void LoadAddProduct()
        {
            lblTitle.Text = "THÊM SẢN PHẨM";
            txtProductID.Text = bus.GetNextID().ToString();
            txtProductID.Enabled = false;
            dtpProductDate.Value = DateTime.Today;
        }
        private void LoadEditProduct()
        {
            lblTitle.Text = "CHỈNH SỬA SẢN PHẨM";
            txtProductID.Enabled = false;

            try
            {
                DataRow row = bus.GetByID(_maSanPham);
                if (row == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtProductID.Text = row["MaSanPham"].ToString();
                txtProductName.Text = row["TenSanPham"].ToString();
                txtProductSellingPrice.Text = row["GiaCoBan"].ToString();
                txtProductDescription.Text = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : "";

                if (row["NgayTao"] != DBNull.Value)
                    dtpProductDate.Value = Convert.ToDateTime(row["NgayTao"]);

                // Load danh mục
                string tenDM = row["TenDanhMuc"].ToString();
                int idx = cboProductCategory.FindStringExact(tenDM);
                if (idx >= 0) cboProductCategory.SelectedIndex = idx;

                // Load ảnh
                string hinhAnh = row["HinhAnh"] != DBNull.Value
                                 ? row["HinhAnh"].ToString() : "";
                if (!string.IsNullOrEmpty(hinhAnh))
                {
                    string fullPath = Path.Combine(Application.StartupPath, hinhAnh);
                    if (File.Exists(fullPath))
                    {
                        _imgPath = hinhAnh;
                        picProductAvatar.Image = Image.FromFile(fullPath);
                        picProductAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUploadProductAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Chọn ảnh sản phẩm";

                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    string folder = Path.Combine(
                        Application.StartupPath, "img", "products");
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    string ext = Path.GetExtension(ofd.FileName);
                    string newName = $"product_{DateTime.Now:yyyyMMddHHmmss}{ext}";
                    string destPath = Path.Combine(folder, newName);

                    File.Copy(ofd.FileName, destPath, overwrite: true);

                    _imgPath = Path.Combine("img", "products", newName);
                    picProductAvatar.Image = Image.FromFile(destPath);
                    picProductAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtProductSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSanPham = txtProductName.Text.Trim();
                string giaStr = txtProductSellingPrice.Text.Trim();
                string moTa = txtProductDescription.Text.Trim();
                object hinhAnh = string.IsNullOrEmpty(_imgPath)
                                     ? null : (object)_imgPath;

                if (!decimal.TryParse(giaStr, out decimal giaCoBan))
                    throw new Exception("Giá cơ bản không hợp lệ!");

                // Lấy MaDanhMuc
                DataTable dtDM = bus.GetAllProductCategory();
                int maDanhMuc = 0;
                string tenDMChon = cboProductCategory.SelectedItem?.ToString();
                foreach (DataRow row in dtDM.Rows)
                {
                    if (row["TenDanhMuc"].ToString() == tenDMChon)
                    {
                        maDanhMuc = Convert.ToInt32(row["MaDanhMuc"]);
                        break;
                    }
                }

                object objMoTa = string.IsNullOrEmpty(moTa) ? null : (object)moTa;

                if (_maSanPham == 0)
                {
                    bool ok = bus.Insert(tenSanPham, maDanhMuc, objMoTa, hinhAnh, giaCoBan);
                    if (ok)
                    {
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    bool ok = bus.Update(_maSanPham, tenSanPham, maDanhMuc,
                                         objMoTa, hinhAnh, giaCoBan);
                    if (ok)
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thành công",
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

        private void btnCancelProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
