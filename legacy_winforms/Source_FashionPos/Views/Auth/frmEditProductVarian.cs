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
    public partial class frmEditProductVarian : Form
    {
        private ProductBUS bus = new ProductBUS();
        private int _maBienThe;  // 0 = thêm mới, >0 = sửa
        private int _maSanPham;  // sản phẩm cha
        private string _hinhAnhPath = null;
        public frmEditProductVarian(int maSanPham)
        {
            InitializeComponent();
            _maBienThe = 0;
            _maSanPham = maSanPham;
        }
        public frmEditProductVarian(int maBienThe, bool isSua)
        {
            InitializeComponent();
            _maBienThe = maBienThe;
            _maSanPham = 0;
        }

        private void frmEditProductVarian_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            dtpProductVarianDate.Enabled = false;

            if (_maBienThe > 0)
                LoadEditProductVarian();
            else
                LoadAddProductVarian();
        }

        private void LoadComboBox()
        {
            // Load màu sắc
            cboProductColor.Items.Clear();
            cboProductColor.Items.AddRange(new object[]
            {
                "Đỏ", "Xanh dương", "Xanh lá", "Đen", "Trắng",
                "Vàng", "Hồng", "Tím", "Cam", "Xám", "Nâu"
            });

            // Load kích cỡ
            cboProductSize.Items.Clear();
            cboProductSize.Items.AddRange(new object[]
            {
                "XS", "S", "M", "L", "XL", "XXL",
                "36", "37", "38", "39", "40", "41", "42"
            });
            // Load danh mục (chỉ đọc)
            DataTable dt = bus.GetAllProductCategory();
            cboProductCategory.Items.Clear();
            foreach (DataRow row in dt.Rows)
                cboProductCategory.Items.Add(row["TenDanhMuc"].ToString());
            cboProductCategory.Enabled = false;
        }

        private void LoadAddProductVarian()
        {
            lblTitle.Text = "THÊM BIẾN THỂ SẢN PHẨM";
            dtpProductVarianDate.Value = DateTime.Today;

            // Load thông tin SP cha
            DataRow sp = bus.GetByID(_maSanPham);
            if (sp != null)
            {
                txtProductID.Text = _maSanPham.ToString();
                txtProductName.Text = sp["TenSanPham"].ToString();

                string tenDM = sp["TenDanhMuc"].ToString();
                int idx = cboProductCategory.FindStringExact(tenDM);
                if (idx >= 0) cboProductCategory.SelectedIndex = idx;
            }
            txtProductID.Enabled = false;
            txtProductName.Enabled = false;
        }

        private void LoadEditProductVarian()
        {
            lblTitle.Text = "CHỈNH SỬA BIẾN THỂ";
            txtProductID.Enabled = false;
            txtProductName.Enabled = false;
            txtProductInStock.Enabled = false; // Chỉ đọc

            try
            {
                DataRow row = bus.GetVarianByID(_maBienThe);
                if (row == null)
                {
                    txtProductInStock.Text = row["SoLuongTon"].ToString();
                    MessageBox.Show("Không tìm thấy biến thể!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                _maSanPham = Convert.ToInt32(row["MaSanPham"]);
                txtProductID.Text = row["MaBienThe"].ToString();
                txtProductName.Text = row["TenSanPham"].ToString();
                txtProductSellingPrice.Text = row["GiaBan"].ToString();
                txtProductInStock.Text = row["SoLuongTon"].ToString();
                // Load màu sắc
                int idxColor = cboProductColor.FindStringExact(row["MauSac"].ToString());
                cboProductColor.SelectedIndex = idxColor >= 0 ? idxColor : -1;
                if (idxColor < 0) cboProductColor.Text = row["MauSac"].ToString();

                // Load kích cỡ
                int idxSize = cboProductSize.FindStringExact(row["KichCo"].ToString());
                cboProductSize.SelectedIndex = idxSize >= 0 ? idxSize : -1;
                if (idxSize < 0) cboProductSize.Text = row["KichCo"].ToString();

                // Load danh mục
                DataRow sp = bus.GetByID(_maSanPham);
                if (sp != null)
                {
                    string tenDM = sp["TenDanhMuc"].ToString();
                    int idx = cboProductCategory.FindStringExact(tenDM);
                    if (idx >= 0) cboProductCategory.SelectedIndex = idx;
                }

                // Load ảnh
                string hinhAnh = row["HinhAnh"] != DBNull.Value
                                 ? row["HinhAnh"].ToString() : "";
                if (!string.IsNullOrEmpty(hinhAnh))
                {
                    string fullPath = Path.Combine(Application.StartupPath, hinhAnh);
                    if (File.Exists(fullPath))
                    {
                        _hinhAnhPath = hinhAnh;
                        picProductAvatarVarian.Image = Image.FromFile(fullPath);
                        picProductAvatarVarian.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnUploadAvatarProductVarian_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Chọn ảnh biến thể";

                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    string folder = Path.Combine(
                        Application.StartupPath, "img", "variants");
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    string ext = Path.GetExtension(ofd.FileName);
                    string newName = $"variant_{DateTime.Now:yyyyMMddHHmmss}{ext}";
                    string destPath = Path.Combine(folder, newName);

                    File.Copy(ofd.FileName, destPath, overwrite: true);

                    _hinhAnhPath = Path.Combine("img", "variants", newName);
                    picProductAvatarVarian.Image = Image.FromFile(destPath);
                    picProductAvatarVarian.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void txtProductInStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void btnSaveProductVarian_Click(object sender, EventArgs e)
        {
            try
            {
                string mauSac = cboProductColor.Text.Trim();
                string kichCo = cboProductSize.Text.Trim();
                string giaStr = txtProductSellingPrice.Text.Trim();
                string tonStr = txtProductInStock.Text.Trim();
                object hinhAnh = string.IsNullOrEmpty(_hinhAnhPath)
                                  ? null : (object)_hinhAnhPath;

                if (!decimal.TryParse(giaStr, out decimal giaBan))
                    throw new Exception("Giá bán không hợp lệ!");
                if (!int.TryParse(tonStr, out int tonKho))
                    throw new Exception("Tồn kho không hợp lệ!");

                if (_maBienThe == 0)
                {
                    // THÊM MỚI
                    bool ok = bus.InsertVarian(
                        _maSanPham, kichCo, mauSac,
                        null, 0, giaBan, hinhAnh);

                    if (ok)
                    {
                        MessageBox.Show("Thêm biến thể thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // SỬA
                    bool ok = bus.UpdateVarian(
                        _maBienThe, kichCo, mauSac,
                        null, tonKho, giaBan, hinhAnh);

                    if (ok)
                    {
                        MessageBox.Show("Cập nhật biến thể thành công!", "Thành công",
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

        private void btnCancelProductVarian_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
