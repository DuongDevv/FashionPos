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
using WindowsFormsApp1.Views.Auth;
    
namespace WindowsFormsApp1.UserControls
{
    public partial class ucStockIn : UserControl
    {
        private ProductBUS spBUS = new ProductBUS();
        private SupplierBUS nccBUS = new SupplierBUS();
        private PurchaseOrderBUS pnBUS = new PurchaseOrderBUS();

        private DataTable _danhSachNhap; // Giỏ hàng nhập
        private bool _daLoad = false;
        public ucStockIn()
        {
            InitializeComponent();
            SetupDGVSearch();
            SetupDGVInput();
        }

        private void ucStockIn_Load(object sender, EventArgs e)
        {

        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible && !_daLoad)
            {
                LoadComboBox();
                LoadProduct();
                _danhSachNhap = pnBUS.CreateListInput();
                dgvListProductStockin.DataSource = _danhSachNhap;
                UpdateSubtotal();
                _daLoad = true;
            }
        }

        private void SetupDGVSearch()
        {
            dgvSearchProductStockin.AutoGenerateColumns = false;
            dgvSearchProductStockin.Columns.Clear();

            dgvSearchProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "MaBienThe", Name = "MaBienThe", Visible = false });
            dgvSearchProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "TenSanPham", HeaderText = "Tên sản phẩm", Width = 180, Name = "TenSanPham" });
            dgvSearchProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "MauSac", HeaderText = "Màu", Width = 80, Name = "MauSac" });
            dgvSearchProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "KichCo", HeaderText = "Size", Width = 60, Name = "KichCo" });
            dgvSearchProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "SoLuongTon", HeaderText = "Tồn kho", Width = 80, Name = "SoLuongTon" });
            dgvSearchProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "GiaBan", HeaderText = "Giá bán", Width = 90, Name = "GiaBan" });

            StyleDGV(dgvSearchProductStockin);
            dgvSearchProductStockin.DataError += (s, e) => e.Cancel = true;
        }

        // ── Setup DGV danh sách nhập ─────────────────────────
        private void SetupDGVInput()
        {
            dgvListProductStockin.AutoGenerateColumns = false;
            dgvListProductStockin.Columns.Clear();

            dgvListProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "MaBienThe", Name = "MaBienThe", Visible = false });
            dgvListProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "TenSanPham", HeaderText = "Sản phẩm", Width = 150, Name = "TenSanPham" });
            dgvListProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "MauSac", HeaderText = "Màu", Width = 70, Name = "MauSac" });
            dgvListProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "KichCo", HeaderText = "Size", Width = 55, Name = "KichCo" });
            dgvListProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "SoLuong", HeaderText = "SL", Width = 50, Name = "SoLuong" });
            dgvListProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "GiaNhap", HeaderText = "Giá nhập", Width = 90, Name = "GiaNhap" });
            dgvListProductStockin.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "ThanhTien", HeaderText = "Thành tiền", Width = 100, Name = "ThanhTien" });

            // Thêm nút xóa
            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "✕",
                UseColumnTextForButtonValue = true,
                Width = 35,
                Name = "btnXoa"
            };
            dgvListProductStockin.Columns.Add(btnXoa);

            StyleDGV(dgvListProductStockin);
            dgvListProductStockin.DataError += (s, e) => e.Cancel = true;
            dgvListProductStockin.CellClick += dgvListProductStockin_CellClick;

            dgvListProductStockin.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvListProductStockin.Columns)
            {
                col.ReadOnly = true; // Mặc định tất cả readonly
            }
            dgvListProductStockin.Columns["SoLuong"].ReadOnly = false; // Cho sửa số lượng
            dgvListProductStockin.Columns["GiaNhap"].ReadOnly = false; // Cho sửa giá nhập

            // Bắt event khi sửa xong 1 ô
            dgvListProductStockin.CellEndEdit += dgvListProductStockin_CellEndEdit;
        }

        private void StyleDGV(DataGridView dgv)
        {
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 97, 217);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 36;
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 97, 217);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgv.RowTemplate.Height = 36;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(220, 225, 235);
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.MultiSelect = false;
        }

        private void LoadComboBox()
        {
            // Danh mục
            DataTable dtDM = spBUS.GetAllProductCategory();
            cboSearchProductTypeStockin.Items.Clear();
            cboSearchProductTypeStockin.Items.Add("Tất cả");
            foreach (DataRow row in dtDM.Rows)
                cboSearchProductTypeStockin.Items.Add(row["TenDanhMuc"].ToString());
            cboSearchProductTypeStockin.SelectedIndex = 0;

            // Màu sắc
            DataTable dtMau = spBUS.GetAllColor();
            cboSearchProductColorStockin.Items.Clear();
            cboSearchProductColorStockin.Items.Add("Tất cả");
            foreach (DataRow row in dtMau.Rows)
                cboSearchProductColorStockin.Items.Add(row["MauSac"].ToString());
            cboSearchProductColorStockin.SelectedIndex = 0;

            // Kích cỡ
            DataTable dtSize = spBUS.GetAllSize();
            cboSearchProductSizeStockin.Items.Clear();
            cboSearchProductSizeStockin.Items.Add("Tất cả");
            foreach (DataRow row in dtSize.Rows)
                cboSearchProductSizeStockin.Items.Add(row["KichCo"].ToString());
            cboSearchProductSizeStockin.SelectedIndex = 0;

            // Nhà cung cấp
            DataTable dtNCC = nccBUS.GetActive();

            cboPickSupplier.DataSource = null;
            cboPickSupplier.Items.Clear();

            cboPickSupplier.DisplayMember = "TenNhaCungCap";
            cboPickSupplier.ValueMember = "MaNhaCungCap";
            cboPickSupplier.DataSource = dtNCC;

            if (dtNCC.Rows.Count > 0)
                cboPickSupplier.SelectedIndex = 0;  
        }
        private void LoadProduct()
        {
            try
            {
                string keyword = txtSearchNameProductStockin.Text.Trim();
                string danhMuc = cboSearchProductTypeStockin.SelectedItem?.ToString() ?? "Tất cả";
                string mauSac = cboSearchProductColorStockin.SelectedItem?.ToString() ?? "Tất cả";
                string kichCo = cboSearchProductSizeStockin.SelectedItem?.ToString() ?? "Tất cả";

                int maDanhMuc = 0;
                if (danhMuc != "Tất cả")
                {
                    DataTable dtDM = spBUS.GetAllProductCategory();
                    foreach (DataRow row in dtDM.Rows)
                        if (row["TenDanhMuc"].ToString() == danhMuc)
                        {
                            maDanhMuc = Convert.ToInt32(row["MaDanhMuc"]);
                            break;
                        }
                }

                DataTable dt = spBUS.GetVarianAll(keyword, maDanhMuc, mauSac, kichCo);
                dgvSearchProductStockin.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPickSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPickSupplier.SelectedItem == null) return;

            DataRowView row = cboPickSupplier.SelectedItem as DataRowView;
            if (row == null) return;

            lblContactPerson.Text = "👤 Người liên hệ: " +
                                         row["NguoiLienHe"].ToString();
            lblContactPersonPhone.Text = "📞 SĐT: " +
                                         row["SoDienThoai"].ToString();
        }

        private void btnSearchProductStockin_Click(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void dgvSearchProductStockin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int maBienThe = Convert.ToInt32(dgvSearchProductStockin.Rows[e.RowIndex].Cells["MaBienThe"].Value);
            string tenSanPham = dgvSearchProductStockin.Rows[e.RowIndex].Cells["TenSanPham"].Value.ToString();
            string mauSac = dgvSearchProductStockin.Rows[e.RowIndex].Cells["MauSac"].Value.ToString();
            string kichCo = dgvSearchProductStockin.Rows[e.RowIndex].Cells["KichCo"].Value.ToString();

            using (frmInputQuantity frm = new frmInputQuantity())
            {
                if (frm.ShowDialog() != DialogResult.OK) return;

                try
                {
                    pnBUS.AddToList(_danhSachNhap, maBienThe,
                        tenSanPham, kichCo, mauSac, frm.SoLuong, frm.GiaNhap);

                    dgvListProductStockin.DataSource = null;
                    dgvListProductStockin.DataSource = _danhSachNhap;
                    UpdateSubtotal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvListProductStockin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvListProductStockin.Columns[e.ColumnIndex].Name != "btnXoa") return;

            int maBienThe = Convert.ToInt32(
                dgvListProductStockin.Rows[e.RowIndex].Cells["MaBienThe"].Value);

            pnBUS.XoaKhoiDanhSach(_danhSachNhap, maBienThe);

            dgvListProductStockin.DataSource = null;
            dgvListProductStockin.DataSource = _danhSachNhap;
            UpdateSubtotal();
        }

        private void UpdateSubtotal()
        {
            decimal tongTien = pnBUS.CalculateSubtotal(_danhSachNhap);
            lblTotalPriceProductsStockin.Text = string.Format("{0:N0}đ", tongTien);
        }

        private void btnPaymentStockin_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboPickSupplier.SelectedItem == null)
                    throw new Exception("Vui lòng chọn nhà cung cấp!");

                if (_danhSachNhap.Rows.Count == 0)
                    throw new Exception("Danh sách nhập hàng trống!");

                DataRowView ncc = cboPickSupplier.SelectedItem as DataRowView;
                int maNhaCungCap = Convert.ToInt32(ncc["MaNhaCungCap"]);

                // Lấy mã nhân viên đang đăng nhập
                // Tạm thời hardcode = 1, sau này lấy từ session đăng nhập
                int maNhanVien = SessionManager.MaNhanVien;

                bool ok = pnBUS.CreatePhieuNhap(
                    maNhaCungCap, maNhanVien, null, _danhSachNhap);

                if (ok)
                {
                    MessageBox.Show("Nhập kho thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form
                    _danhSachNhap = pnBUS.CreateListInput();
                    dgvListProductStockin.DataSource = _danhSachNhap;
                    UpdateSubtotal();
                    LoadProduct(); // Reload tồn kho mới
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvListProductStockin_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvListProductStockin.Columns[e.ColumnIndex].Name;
            if (colName != "SoLuong" && colName != "GiaNhap") return;

            try
            {
                var row = _danhSachNhap.Rows[e.RowIndex];
                string val = dgvListProductStockin.Rows[e.RowIndex]
                                .Cells[e.ColumnIndex].Value?.ToString();

                if (colName == "SoLuong")
                {
                    if (!int.TryParse(val, out int sl) || sl <= 0)
                    {
                        MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row["SoLuong"] = 1;
                    }
                    else
                    {
                        row["SoLuong"] = sl;
                        row["ThanhTien"] = sl * Convert.ToDecimal(row["GiaNhap"]);
                    }
                }
                else if (colName == "GiaNhap")
                {
                    if (!decimal.TryParse(val, out decimal gia) || gia <= 0)
                    {
                        MessageBox.Show("Giá nhập phải lớn hơn 0!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row["GiaNhap"] = 0;
                    }
                    else
                    {
                        row["GiaNhap"] = gia;
                        row["ThanhTien"] = gia * Convert.ToInt32(row["SoLuong"]);
                    }
                }

                UpdateSubtotal();
            }
            catch { }
        }
    }
}
