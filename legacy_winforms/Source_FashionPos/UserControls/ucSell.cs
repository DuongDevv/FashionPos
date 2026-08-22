using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BUS;
using System.Windows.Forms;
using WindowsFormsApp1.Views.Auth;

namespace WindowsFormsApp1.UserControls
{
    public partial class ucSell : UserControl
    {
        private ProductBUS spBUS = new ProductBUS();
        private CustomerBUS khBUS = new CustomerBUS();
        private OrderBUS hdBUS = new OrderBUS();

        private DataTable _gioHang;
        private int? _maKhachHang = null;
        private bool _daLoad = false;
        public ucSell()
        {
            InitializeComponent();
            SetupShoppingCart();
            SetupDGVGioHang();
        }

        private void ucSell_Load(object sender, EventArgs e)
        {

        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible && !_daLoad)
            {
                LoadComboBox();
                LoadSanPham();
                _daLoad = true;
            }
        }

        // ── Giỏ hàng ─────────────────────────────────────────
        private void SetupShoppingCart()
        {
            _gioHang = hdBUS.CreateCard();
        }

        private void SetupDGVGioHang()
        {
            dgvListItems.AutoGenerateColumns = false;
            dgvListItems.Columns.Clear();

            dgvListItems.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "MaBienThe", Name = "MaBienThe", Visible = false });
            dgvListItems.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "TenSanPham", HeaderText = "Sản phẩm", Width = 140, Name = "TenSanPham" });
            dgvListItems.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "SoLuong", HeaderText = "SL", Width = 45, Name = "SoLuong" });
            dgvListItems.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "DonGia", HeaderText = "Đơn giá", Width = 90, Name = "DonGia" });
            dgvListItems.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "ThanhTien", HeaderText = "T.Tiền", Width = 90, Name = "ThanhTien" });

            // Nút xóa
            dgvListItems.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "✕",
                UseColumnTextForButtonValue = true,
                Width = 35,
                Name = "btnXoa"
            });

            dgvListItems.RowHeadersVisible = false;
            dgvListItems.AllowUserToAddRows = false;
            dgvListItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListItems.DataError += (s, e) => e.Cancel = true;

            // Xóa dòng khi click ✕
            dgvListItems.CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                if (dgvListItems.Columns[e.ColumnIndex].Name != "btnXoa") return;

                int maBienThe = Convert.ToInt32(
                    dgvListItems.Rows[e.RowIndex].Cells["MaBienThe"].Value);

                hdBUS.RemoveCartItem(_gioHang, maBienThe);
                RefreshGioHang();
            };
        }


        

        // ── Load ComboBox ────────────────────────────────────
        private void LoadComboBox()
        {
            // Danh mục
            DataTable dtDM = spBUS.GetAllProductCategory();
            cboSearchProductTypeSell.Items.Clear();
            cboSearchProductTypeSell.Items.Add("Tất cả");
            foreach (DataRow row in dtDM.Rows)
                cboSearchProductTypeSell.Items.Add(row["TenDanhMuc"].ToString());
            cboSearchProductTypeSell.SelectedIndex = 0;

            // Màu sắc
            DataTable dtMau = spBUS.GetAllColor();
            cboSearchColor.Items.Clear();
            cboSearchColor.Items.Add("Tất cả");
            foreach (DataRow row in dtMau.Rows)
                cboSearchColor.Items.Add(row["MauSac"].ToString());
            cboSearchColor.SelectedIndex = 0;

            // Kích cỡ
            DataTable dtSize = spBUS.GetAllSize();
            cboSearchSize.Items.Clear();
            cboSearchSize.Items.Add("Tất cả");
            foreach (DataRow row in dtSize.Rows)
                cboSearchSize.Items.Add(row["KichCo"].ToString());
            cboSearchSize.SelectedIndex = 0;
        }
        private void RefreshGioHang()
        {
            dgvListItems.DataSource = null;
            dgvListItems.DataSource = _gioHang;
            CapNhatGioHang();
        }

        // ── Load sản phẩm vào FlowLayoutPanel ───────────────
        private void LoadSanPham()
        {
            try
            {
                string keyword = txtSearchNameProductSell.Text.Trim();
                string danhMuc = cboSearchProductTypeSell.SelectedItem?.ToString() ?? "Tất cả";
                string mauSac = cboSearchColor.SelectedItem?.ToString() ?? "Tất cả";
                string kichCo = cboSearchSize.SelectedItem?.ToString() ?? "Tất cả";

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

                flpProductList.Controls.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int maBienThe = Convert.ToInt32(row["MaBienThe"]);
                    string tenSP = row["TenSanPham"].ToString()
                                        + $"\n{row["MauSac"]} - {row["KichCo"]}";
                    decimal giaBan = Convert.ToDecimal(row["GiaBan"]);
                    int soLuongTon = Convert.ToInt32(row["SoLuongTon"]);
                    string hinhAnh = row.Table.Columns.Contains("HinhAnh") &&
                                        row["HinhAnh"] != DBNull.Value
                                        ? row["HinhAnh"].ToString() : "";

                    ucProductItem item = new ucProductItem(
                        maBienThe, tenSP, giaBan, soLuongTon, hinhAnh);

                    item.OnProductSelected += ProductItem_OnProductSelected;
                    flpProductList.Controls.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Click vào SP → thêm vào giỏ ─────────────────────
        private void ProductItem_OnProductSelected(object sender, EventArgs e)
        {
            try
            {
                ucProductItem item = sender as ucProductItem;
                if (item == null) return;

                hdBUS.AddToCart(_gioHang,
                    item.MaBienThe, item.TenSanPham,
                    "", "", 1, item.GiaBan);

                RefreshGioHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Cập nhật hiển thị giỏ hàng ──────────────────────
        private void CapNhatGioHang()
        {
            // Tính tổng
            decimal tongTienHang = hdBUS.CalculateSubtotal(_gioHang);

            // Tính giảm giá theo hạng khách
            decimal phanTramGiam = 0;
            if (_maKhachHang.HasValue)
            {
                DataRow kh = khBUS.GetByID(_maKhachHang.Value);
                if (kh != null)
                    phanTramGiam = khBUS.TinhPhanTramGiam(kh["LoaiThanhVien"].ToString());
            }

            decimal tienGiam = tongTienHang * phanTramGiam / 100;
            decimal tongCanTra = tongTienHang - tienGiam;

            lblProductPricePay.Text = string.Format("{0:N0}đ", tongTienHang);
            lblProductDiscountPay.Text = phanTramGiam > 0
                ? $"-{phanTramGiam}% ({string.Format("{0:N0}đ", tienGiam)})"
                : "0đ";
            lblTotalPriceProduct.Text = string.Format("{0:N0}đ", tongCanTra);
        }

        // ── Nút Chọn khách ───────────────────────────────────

        // ── Nút Reset tìm kiếm ───────────────────────────────
        private void btnResertSearchBar_Click(object sender, EventArgs e)
        {
            txtSearchNameProductSell.Text = "";
            cboSearchProductTypeSell.SelectedIndex = 0;
            cboSearchColor.SelectedIndex = 0;
            cboSearchSize.SelectedIndex = 0;
            LoadSanPham();
        }

        // ── Tìm kiếm realtime ────────────────────────────────
        private void txtSearchNameProductSell_TextChanged(object sender, EventArgs e)
        {
            LoadSanPham();
        }

        private void cboSearchProductTypeSell_SelectedIndexChanged(object sender, EventArgs e)
            => LoadSanPham();

        private void cboSearchColor_SelectedIndexChanged(object sender, EventArgs e)
            => LoadSanPham();

        private void cboSearchSize_SelectedIndexChanged(object sender, EventArgs e)
            => LoadSanPham();

        // ── Nút Thanh toán ───────────────────────────────────
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (_gioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tongTienHang = hdBUS.CalculateSubtotal(_gioHang);
            decimal phanTramGiam = 0;

            if (_maKhachHang.HasValue)
            {
                DataRow kh = khBUS.GetByID(_maKhachHang.Value);
                if (kh != null)
                    phanTramGiam = khBUS.TinhPhanTramGiam(kh["LoaiThanhVien"].ToString());
            }

            decimal khachCanTra = hdBUS.TotalPayable(tongTienHang, "%", phanTramGiam);

            // Mở form thanh toán
            frmPayment frm = new frmPayment(
                _maKhachHang, tongTienHang, phanTramGiam, khachCanTra, _gioHang);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Reset sau khi thanh toán
                _gioHang = hdBUS.CreateCard();
                _maKhachHang = null;
                lblCustomerType.Text = "KHÁCH LẺ";
                lblPoint.Text = "Điểm tích lũy: 0";
                RefreshGioHang();
                CapNhatGioHang();
                LoadSanPham(); // Reload tồn kho mới
            }
        }

        private void btnPickCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                frmPickCustomer frm = new frmPickCustomer();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _maKhachHang = frm.MaKhachHang;

                    if (_maKhachHang.HasValue)
                    {
                        DataRow kh = khBUS.GetByID(_maKhachHang.Value);
                        if (kh != null)
                        {
                            lblCustomerType.Text = kh["HoTen"].ToString();
                            lblPoint.Text = $"Điểm tích lũy: {kh["DiemTichLuy"]}";
                        }
                    }
                    else
                    {
                        lblCustomerType.Text = "KHÁCH LẺ";
                        lblPoint.Text = "Điểm tích lũy: 0";
                    }

                    CapNhatGioHang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
