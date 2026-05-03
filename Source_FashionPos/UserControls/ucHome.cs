using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.BUS;
using WindowsFormsApp1.Utils;

namespace WindowsFormsApp1.UserControls
{
    public partial class ucHome : UserControl
    {

        private OrderBUS hdBUS = new OrderBUS();
        private CustomerBUS khBUS = new CustomerBUS();
        private ProductBUS spBUS = new ProductBUS();
        public ucHome()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                LoadThongTinNhanVien();
                LoadThongKe();
                LoadBieuDoDoanhThu();
                LoadTop5BanChay();
            }
        }

        // ── Thông tin NV đang đăng nhập ──────────────────────
        private void LoadThongTinNhanVien()
        {
            lblStaffName.Text = SessionManager.HoTen;

            // Load ảnh đại diện NV
            try
            {
                var nvBUS = new StaffBUS();
                DataRow nv = nvBUS.GetByID(SessionManager.MaNhanVien);

                if (nv != null && nv["HinhAnh"] != DBNull.Value)
                {
                    string fullPath = Path.Combine(
                        Application.StartupPath, nv["HinhAnh"].ToString());

                    if (File.Exists(fullPath))
                    {
                        SetRoundAvatar(Image.FromFile(fullPath));
                        return;
                    }
                }

                // Không có ảnh → dùng ảnh mặc định chữ cái đầu
                SetDefaultAvatar(SessionManager.HoTen);
            }
            catch { SetDefaultAvatar(SessionManager.HoTen); }
        }

        // Tạo avatar tròn từ ảnh
        private void SetRoundAvatar(Image img)
        {
            int size = Math.Min(picAvatar.Width, picAvatar.Height);
            Bitmap bmp = new Bitmap(size, size);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, size, size);
                    g.SetClip(path);
                    g.DrawImage(img, 0, 0, size, size);
                }
            }

            picAvatar.Image = bmp;
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Tạo avatar mặc định — nền màu + chữ cái đầu tên
        private void SetDefaultAvatar(string hoTen)
        {
            int size = Math.Min(picAvatar.Width, picAvatar.Height);
            Bitmap bmp = new Bitmap(size, size);

            string chu = string.IsNullOrEmpty(hoTen)
                ? "?" : hoTen[0].ToString().ToUpper();

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Nền tròn màu xanh
                using (var path = new GraphicsPath())
                using (var brush = new SolidBrush(Color.FromArgb(33, 97, 217)))
                {
                    path.AddEllipse(0, 0, size, size);
                    g.FillPath(brush, path);
                }

                // Chữ cái đầu
                using (Font font = new Font("Segoe UI", size * 0.35f, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    SizeF textSize = g.MeasureString(chu, font);
                    float x = (size - textSize.Width) / 2;
                    float y = (size - textSize.Height) / 2;
                    g.DrawString(chu, font, brush, x, y);
                }
            }

            picAvatar.Image = bmp;
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
        }
       
        // ── Thống kê 4 card ──────────────────────────────────
        private void LoadThongKe()
        {
            try
            {
                DateTime homNay = DateTime.Today;
                DateTime dauThang = new DateTime(homNay.Year, homNay.Month, 1);
                DateTime nguong7 = homNay.AddDays(-7);

                // 1. Doanh thu hôm nay
                DataTable dtHoaDon = hdBUS.GetByDateRange(homNay, homNay);
                decimal doanhThu = 0;
                int soHoaDon = dtHoaDon.Rows.Count;
                foreach (DataRow row in dtHoaDon.Rows)
                    doanhThu += Convert.ToDecimal(row["KhachCanTra"]);

                lblRevenueToday.Text = string.Format("{0:N0}đ", doanhThu);

                // 2. Đơn hàng mới hôm nay
                lblNewBill.Text = soHoaDon.ToString();

                // 3. Sản phẩm sắp hết (tồn kho < 5)
                DataTable dtTon = spBUS.GetStock();
                int sapHet = 0;
                foreach (DataRow row in dtTon.Rows)
                    if (Convert.ToInt32(row["SoLuongTon"]) < 5) sapHet++;

                lblProductOFStock.Text = sapHet.ToString();
                lblProductOFStock.ForeColor = sapHet > 0
                    ? Color.Red
                    : Color.FromArgb(39, 174, 96);

                // 4. Khách hàng mới trong tháng
                DataTable dtKH = khBUS.GetAll();
                int khachMoi = 0;
                foreach (DataRow row in dtKH.Rows)
                {
                    if (row["NgayTao"] != DBNull.Value &&
                        Convert.ToDateTime(row["NgayTao"]) >= dauThang)
                        khachMoi++;
                }
                lblNewCustomerThisMonth.Text = khachMoi.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message);
            }
        }

        // ── Biểu đồ doanh thu theo tháng ─────────────────────
        private void LoadBieuDoDoanhThu()
        {
            try
            {
                chartRevenue.Series.Clear();
                chartRevenue.ChartAreas.Clear();

                ChartArea area = new ChartArea();
                area.AxisX.Title = "";
                area.AxisY.Title = "Doanh thu (đ)";
                area.AxisY.LabelStyle.Format = "N0";
                area.AxisX.Interval = 1;
                area.AxisX.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
                area.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
                area.BackColor = Color.White;
                chartRevenue.ChartAreas.Add(area);

                Series series = new Series("Doanh thu");
                series.ChartType = SeriesChartType.Column;
                series.Color = Color.FromArgb(33, 97, 217);
                series.BorderColor = Color.FromArgb(20, 70, 180);
                series.BorderWidth = 1;

                // Lấy 12 tháng trong năm hiện tại
                int namHienTai = DateTime.Now.Year;
                for (int thang = 1; thang <= 12; thang++)
                {
                    DateTime tuNgay = new DateTime(namHienTai, thang, 1);
                    DateTime denNgay = tuNgay.AddMonths(1).AddDays(-1);

                    if (tuNgay > DateTime.Today)
                    {
                        DataPoint point = new DataPoint();
                        point.SetValueY(0);
                        point.AxisLabel = $"T{thang}";
                        series.Points.Add(point);
                        continue;
                    }

                    if (denNgay > DateTime.Today)
                        denNgay = DateTime.Today;

                    DataTable dt = hdBUS.GetByDateRange(tuNgay, denNgay);
                    decimal tongDT = 0;
                    foreach (DataRow row in dt.Rows)
                        tongDT += Convert.ToDecimal(row["KhachCanTra"]);

                    DataPoint p = new DataPoint();
                    p.SetValueY(tongDT);
                    p.AxisLabel = $"T{thang}";
                    p.ToolTip = $"Tháng {thang}: {tongDT:N0}đ";

                    // Tháng hiện tại highlight màu khác
                    if (thang == DateTime.Now.Month)
                        p.Color = Color.FromArgb(230, 100, 30);

                    series.Points.Add(p);
                }

                chartRevenue.Series.Add(series);
                chartRevenue.BackColor = Color.White;
                chartRevenue.BorderlineColor = Color.Transparent;

                // Legend
                chartRevenue.Legends.Clear();
                Legend legend = new Legend();
                legend.Enabled = false;
                chartRevenue.Legends.Add(legend);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi biểu đồ: " + ex.Message);
            }
        }

        // ── Top 5 sản phẩm bán chạy ──────────────────────────
        private void LoadTop5BanChay()
        {
            try
            {
                dgvTopPoduct.AutoGenerateColumns = false;
                dgvTopPoduct.Columns.Clear();

                dgvTopPoduct.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "TenSanPham", HeaderText = "Sản phẩm", Width = 160, Name = "TenSanPham" });
                dgvTopPoduct.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "MauSac", HeaderText = "Màu", Width = 70, Name = "MauSac" });
                dgvTopPoduct.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "KichCo", HeaderText = "Size", Width = 55, Name = "KichCo" });
                dgvTopPoduct.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "SoLuongBan", HeaderText = "SL bán", Width = 70, Name = "SoLuongBan" });
                dgvTopPoduct.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "DoanhThu", HeaderText = "Doanh thu", Width = 100, Name = "DoanhThu" });

                dgvTopPoduct.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 97, 217);
                dgvTopPoduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvTopPoduct.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                dgvTopPoduct.EnableHeadersVisualStyles = false;
                dgvTopPoduct.ColumnHeadersHeight = 36;
                dgvTopPoduct.RowsDefaultCellStyle.BackColor = Color.White;
                dgvTopPoduct.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
                dgvTopPoduct.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
                dgvTopPoduct.RowTemplate.Height = 36;
                dgvTopPoduct.BorderStyle = BorderStyle.None;
                dgvTopPoduct.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvTopPoduct.GridColor = Color.FromArgb(220, 225, 235);
                dgvTopPoduct.RowHeadersVisible = false;
                dgvTopPoduct.ReadOnly = true;
                dgvTopPoduct.AllowUserToAddRows = false;
                dgvTopPoduct.DataError += (s, e) => e.Cancel = true;

                // Lấy top 5 trong tháng này
                DateTime dauThang = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DataTable dt = hdBUS.GetBestSellingProducts(dauThang, DateTime.Today);

                // Chỉ lấy 5 dòng đầu
                DataTable top5 = dt.Clone();
                int count = Math.Min(5, dt.Rows.Count);
                for (int i = 0; i < count; i++)
                    top5.ImportRow(dt.Rows[i]);

                dgvTopPoduct.DataSource = top5;

                dgvTopPoduct.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                dgvTopPoduct.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Tô màu top 1, 2, 3
                for (int i = 0; i < dgvTopPoduct.Rows.Count; i++)
                {
                    if (i == 0)
                        dgvTopPoduct.Rows[i].DefaultCellStyle.BackColor
                            = Color.FromArgb(30, 255, 215, 0);
                    else if (i == 1)
                        dgvTopPoduct.Rows[i].DefaultCellStyle.BackColor
                            = Color.FromArgb(30, 192, 192, 192);
                    else if (i == 2)
                        dgvTopPoduct.Rows[i].DefaultCellStyle.BackColor
                            = Color.FromArgb(30, 205, 127, 50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi top 5: " + ex.Message);
            }
        }



    }
}
