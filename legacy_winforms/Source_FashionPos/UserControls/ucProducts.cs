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
using WindowsFormsApp1.Views.Auth;

namespace WindowsFormsApp1.UserControls
{
    public partial class ucProducts : UserControl
    {
        private ProductBUS bus = new ProductBUS();
        private bool _daLoad = false;
        private int _maSanPhamDangChon = 0;

        public ucProducts()
        {
            InitializeComponent();
            SetupDGVProduct();
            SetupDGVVarian();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible && !_daLoad)
            {
                LoadComboBox();
                LoadProduct();
                _daLoad = true;
            }
        }

        private void ucProducts_Load(object sender, EventArgs e){}

        private void SetupDGVProduct()
        {
            dgvListProduct.AutoGenerateColumns = false;
            dgvListProduct.Columns.Clear();

            var cols = new[]
            {
                new { Name = "MaSanPham", Header = "Mã SP", Width = 65  },
                new { Name = "TenSanPham", Header = "Tên sản phẩm", Width = 220 },
                new { Name = "TenDanhMuc", Header = "Danh mục", Width = 120 },
                new { Name = "GiaCoBan", Header = "Giá cơ bản", Width = 110 },
                new { Name = "NgayTao", Header = "Ngày tạo", Width = 100 },
                new { Name = "TrangThai", Header = "Trạng thái", Width = 100 },
            };

            foreach (var c in cols)
                dgvListProduct.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = c.Name,
                    HeaderText = c.Header,
                    Width = c.Width,
                    Name = c.Name
                });

            StyleDGV(dgvListProduct);
            dgvListProduct.DataError += (s, e) => e.Cancel = true;
        }
        private void SetupDGVVarian()
        {
            dgvListProductVarian.AutoGenerateColumns = false;
            dgvListProductVarian.Columns.Clear();

            var cols = new[]
            {
                new { Name = "MaBienThe", Header = "Mã BT", Width = 65  },
                new { Name = "MauSac", Header = "Màu sắc", Width = 100 },
                new { Name = "KichCo", Header = "Kích cỡ", Width = 80  },
                new { Name = "SoLuongTon", Header = "Tồn kho", Width = 90  },
                new { Name = "GiaBan", Header = "Giá bán", Width = 110 },
            };

            foreach (var c in cols)
                dgvListProductVarian.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = c.Name,
                    HeaderText = c.Header,
                    Width = c.Width,
                    Name = c.Name
                });

            StyleDGV(dgvListProductVarian);
            dgvListProductVarian.DataError += (s, e) => e.Cancel = true;
        }
        private void StyleDGV(DataGridView dgv)
        {
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 97, 217);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 40;

            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 97, 217);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgv.RowTemplate.Height = 38;

            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(220, 225, 235);
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.MultiSelect = false;
        }

        private void LoadComboBox()
        {
            // Load danh mục
            DataTable dtDM = bus.GetAllProductCategory();
            cboSearchProductType.Items.Clear();
            cboSearchProductType.Items.Add("Tất cả");
            foreach (DataRow row in dtDM.Rows) cboSearchProductType.Items.Add(row["TenDanhMuc"].ToString());
            cboSearchProductType.SelectedIndex = 0;

            // Load màu sắc từ biến thể đã có trong DB
            cboSearchProductColor.Items.Clear();
            cboSearchProductColor.Items.Add("Tất cả");
            DataTable dtMau = bus.GetAllColor(); // cần thêm method này
            foreach (DataRow row in dtMau.Rows) cboSearchProductColor.Items.Add(row["MauSac"].ToString());
            cboSearchProductColor.SelectedIndex = 0;

            // Load kích cỡ
            cboSearchProductSize.Items.Clear();
            cboSearchProductSize.Items.Add("Tất cả");
            DataTable dtSize = bus.GetAllSize(); // cần thêm method này
            foreach (DataRow row in dtSize.Rows) cboSearchProductSize.Items.Add(row["KichCo"].ToString());
            cboSearchProductSize.SelectedIndex = 0;
        }



        private void LoadProduct()
        {
            try
            {
                string keyword = txtSearchNameProduct.Text.Trim();
                string danhMuc = cboSearchProductType.SelectedItem?.ToString() ?? "Tất cả";
                string mauSac = cboSearchProductColor.SelectedItem?.ToString() ?? "Tất cả";
                string kichCo = cboSearchProductSize.SelectedItem?.ToString() ?? "Tất cả";

                int maDanhMuc = 0;
                if (danhMuc != "Tất cả")
                {
                    DataTable dtDM = bus.GetAllProductCategory();
                    foreach (DataRow row in dtDM.Rows)
                    {
                        if (row["TenDanhMuc"].ToString() == danhMuc)
                        {
                            maDanhMuc = Convert.ToInt32(row["MaDanhMuc"]);
                            break;
                        }
                    }
                }

                DataTable dt;

                // Lọc màu sắc và kích cỡ nếu có chọn
                if (mauSac != "Tất cả" || kichCo != "Tất cả")
                    dt = bus.SearchByVarian(keyword, maDanhMuc, mauSac, kichCo);
                else
                    dt = bus.Search(keyword, maDanhMuc);

                dgvListProductVarian.DataSource = null;
                _maSanPhamDangChon = 0;
                dgvListProduct.DataSource = dt;
                ColorTrangThai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductVarian(int maSanPham)
        {
            try
            {
                DataTable dt = bus.GetVarianByProduct(maSanPham);
                dgvListProductVarian.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorTrangThai()
        {
            foreach (DataGridViewRow row in dgvListProduct.Rows)
            {
                var cell = row.Cells["TrangThai"];
                if (cell.Value == null) continue;

                string giaTriGoc = cell.Value.ToString();
                bool dangBan = giaTriGoc == "1" || giaTriGoc == "True" || giaTriGoc == "Đang bán";
                cell.Value = dangBan ? "Đang bán" : "Ngừng bán";
                cell.Style.ForeColor = dangBan
                    ? Color.FromArgb(39, 174, 96)
                    : Color.FromArgb(231, 76, 60);
                cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }
        }
        private void dgvListProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListProduct.SelectedRows.Count == 0)
            {
                dgvListProductVarian.DataSource = null;
                _maSanPhamDangChon = 0;
                return;
            }

            _maSanPhamDangChon = Convert.ToInt32(dgvListProduct.SelectedRows[0].Cells["MaSanPham"].Value);

            LoadProductVarian(_maSanPhamDangChon);
        }

        // Nút Lọc
        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            LoadProduct();
        }

        // Nút Thêm
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem itemThemSP = new ToolStripMenuItem("➕ Thêm sản phẩm mới");
            ToolStripMenuItem itemThemBT = new ToolStripMenuItem("➕ Thêm biến thể cho SP đang chọn");

            itemThemSP.Click += (s, ev) =>
            {
                frmEditProduct frm = new frmEditProduct(0);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadProduct();
            };

            itemThemBT.Click += (s, ev) =>
            {
                if (_maSanPhamDangChon == 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm trước!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmEditProductVarian frm = new frmEditProductVarian(_maSanPhamDangChon);
                if (frm.ShowDialog() == DialogResult.OK) LoadProductVarian(_maSanPhamDangChon);
            };

            menu.Items.Add(itemThemSP);
            menu.Items.Add(itemThemBT);
            menu.Show(btnAddProduct, new Point(0, btnAddProduct.Height));
        }


        // Nút Sửa
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem itemSuaSP = new ToolStripMenuItem("✏️ Sửa sản phẩm đang chọn");
            ToolStripMenuItem itemSuaBT = new ToolStripMenuItem("✏️ Sửa biến thể đang chọn");

            itemSuaSP.Click += (s, ev) =>
            {
                if (_maSanPhamDangChon == 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmEditProduct frm = new frmEditProduct(_maSanPhamDangChon);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadProduct();
            };

            itemSuaBT.Click += (s, ev) =>
            {
                if (dgvListProductVarian.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn biến thể cần sửa!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maBT = Convert.ToInt32(dgvListProductVarian.SelectedRows[0].Cells["MaBienThe"].Value);

                frmEditProductVarian frm = new frmEditProductVarian(maBT, true);
                if (frm.ShowDialog() == DialogResult.OK) LoadProductVarian(_maSanPhamDangChon);
            };

            menu.Items.Add(itemSuaSP);
            menu.Items.Add(itemSuaBT);
            menu.Show(btnEditProduct, new Point(0, btnEditProduct.Height));
        }


        // Nút Xóa (ẩn sản phẩm)
        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem itemXoaSP = new ToolStripMenuItem("🗑️ Ẩn sản phẩm đang chọn");
            ToolStripMenuItem itemXoaBT = new ToolStripMenuItem("🗑️ Xóa biến thể đang chọn");

            itemXoaSP.Click += (s, ev) =>
            {
                if (_maSanPhamDangChon == 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần ẩn!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tenSP = dgvListProduct.SelectedRows[0].Cells["TenSanPham"].Value.ToString();
                var confirm = MessageBox.Show(
                    $"Ẩn sản phẩm \"{tenSP}\"?\nBiến thể vẫn được giữ lại.",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                if (bus.Delete(_maSanPhamDangChon))
                {
                    MessageBox.Show("Ẩn sản phẩm thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProduct();
                }
            };

            itemXoaBT.Click += (s, ev) =>
            {
                if (dgvListProductVarian.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn biến thể cần xóa!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    "Bạn có chắc muốn xóa biến thể này không?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                int maBT = Convert.ToInt32(
                    dgvListProductVarian.SelectedRows[0].Cells["MaBienThe"].Value);

                if (bus.DeleteVarian(maBT))
                {
                    MessageBox.Show("Xóa biến thể thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductVarian(_maSanPhamDangChon);
                }
            };

            menu.Items.Add(itemXoaSP);
            menu.Items.Add(itemXoaBT);
            menu.Show(btnRemoveProduct, new Point(0, btnRemoveProduct.Height));
        }

        // Double click mở form sửa
        private void dgvListProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _maSanPhamDangChon == 0) return;
            frmEditProduct frm = new frmEditProduct(_maSanPhamDangChon);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadProduct();
        }

        private void dgvListProductVarian_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maBT = Convert.ToInt32(
                dgvListProductVarian.SelectedRows[0].Cells["MaBienThe"].Value);

            frmEditProductVarian frm = new frmEditProductVarian(maBT, true);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadProductVarian(_maSanPhamDangChon);
        }
    }
}
