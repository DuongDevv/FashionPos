using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BUS;

namespace WindowsFormsApp1.UserControls
{
    public partial class ucReport : UserControl
    {
        private OrderBUS hdBUS = new OrderBUS();
        private PurchaseOrderBUS pnBUS = new PurchaseOrderBUS();
        private ProductBUS spBUS = new ProductBUS();

        public ucReport()
        {
            InitializeComponent();
        }

        private void ucReport_Load(object sender, EventArgs e)
        {
            // Load loại báo cáo
            cboReportType.Items.Clear();
            cboReportType.Items.AddRange(new object[]
            {
                "Doanh thu theo ngày",
                "Sản phẩm bán chạy",
                "Tồn kho",
                "Lịch sử hóa đơn",
                "Nhập hàng"
            });
            cboReportType.SelectedIndex = 0;

            // Mặc định từ đầu tháng đến hôm nay
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = DateTime.Now;

            SetupDGV();
        }

        private void SetupDGV()
        {
            dgvReportDetail.AutoGenerateColumns = true;
            dgvReportDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 97, 217);
            dgvReportDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReportDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvReportDetail.EnableHeadersVisualStyles = false;
            dgvReportDetail.ColumnHeadersHeight = 40;
            dgvReportDetail.RowsDefaultCellStyle.BackColor = Color.White;
            dgvReportDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            dgvReportDetail.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 97, 217);
            dgvReportDetail.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvReportDetail.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvReportDetail.RowTemplate.Height = 38;
            dgvReportDetail.BorderStyle = BorderStyle.None;
            dgvReportDetail.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReportDetail.GridColor = Color.FromArgb(220, 225, 235);
            dgvReportDetail.RowHeadersVisible = false;
            dgvReportDetail.ReadOnly = true;
            dgvReportDetail.AllowUserToAddRows = false;
            dgvReportDetail.DataError += (s, e) => e.Cancel = true;
        }

        // ── Nút Xem ──────────────────────────────────────────
        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime tuNgay = dtpFromDate.Value.Date;
                DateTime denNgay = dtpToDate.Value.Date;
                string loai = cboReportType.SelectedItem?.ToString();

                DataTable dt = null;

                switch (loai)
                {
                    case "Doanh thu theo ngày":
                        dt = GetDoanhThu(tuNgay, denNgay);
                        break;
                    case "Sản phẩm bán chạy":
                        dt = GetBestSellingProducts(tuNgay, denNgay);
                        break;
                    case "Tồn kho":
                        dt = GetStock();
                        break;
                    case "Lịch sử hóa đơn":
                        dt = GetLichSuHoaDon(tuNgay, denNgay);
                        break;
                    case "Nhập hàng":
                        dt = GetNhapHang(tuNgay, denNgay);
                        break;
                }

                dgvReportDetail.DataSource = dt;
                AutoFormatColumns(loai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── 1. Doanh thu theo ngày ───────────────────────────
        private DataTable GetDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = hdBUS.GetDailyRevenue(tuNgay, denNgay);
            dt.Columns["Ngay"].ColumnName = "Ngày";
            dt.Columns["SoHoaDon"].ColumnName = "Số HĐ";
            dt.Columns["DoanhThu"].ColumnName = "Doanh thu";
            return dt;
        }

        // ── 2. Sản phẩm bán chạy ────────────────────────────
        private DataTable GetBestSellingProducts(DateTime tuNgay, DateTime denNgay)
        {
            return hdBUS.GetBestSellingProducts(tuNgay, denNgay);
        }

        // ── 3. Tồn kho ───────────────────────────────────────
        private DataTable GetStock()
        {
            return spBUS.GetStock();
        }

        // ── 4. Lịch sử hóa đơn ──────────────────────────────
        private DataTable GetLichSuHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            return hdBUS.GetByDateRange(tuNgay, denNgay);
        }

        // ── 5. Nhập hàng ─────────────────────────────────────
        private DataTable GetNhapHang(DateTime tuNgay, DateTime denNgay)
        {
            return pnBUS.GetByDateRange(tuNgay, denNgay);
        }

        // ── Format cột theo loại báo cáo ─────────────────────
        private void AutoFormatColumns(string loai)
        {
            foreach (DataGridViewColumn col in dgvReportDetail.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Format cột tiền
                string name = col.HeaderText.ToLower();
                if (name.Contains("tiền") || name.Contains("thu") ||
                    name.Contains("giá") || name.Contains("tổng"))
                {
                    col.DefaultCellStyle.Format = "N0";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Format cột số lượng
                if (name.Contains("sl") || name.Contains("số lượng") ||
                    name.Contains("tồn") || name.Contains("hđ"))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReportDetail.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "CSV Files|*.csv",
                    FileName = $"BaoCao_{cboReportType.SelectedItem}_{DateTime.Now:yyyyMMdd}.csv"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                {
                    // Header
                    string[] headers = new string[dgvReportDetail.Columns.Count];
                    for (int i = 0; i < dgvReportDetail.Columns.Count; i++)
                        headers[i] = dgvReportDetail.Columns[i].HeaderText;
                    sw.WriteLine(string.Join(",", headers));

                    // Data
                    foreach (DataGridViewRow row in dgvReportDetail.Rows)
                    {
                        string[] cells = new string[dgvReportDetail.Columns.Count];
                        for (int i = 0; i < dgvReportDetail.Columns.Count; i++)
                            cells[i] = row.Cells[i].Value?.ToString() ?? "";
                        sw.WriteLine(string.Join(",", cells));
                    }
                }

                MessageBox.Show("Xuất file thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

