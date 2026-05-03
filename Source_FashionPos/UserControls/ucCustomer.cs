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
    public partial class ucCustomer : UserControl
    {
        private CustomerBUS bus = new CustomerBUS();
        public ucCustomer()
        {
            InitializeComponent();
            SetupDGV();
        }

        private void ucCustomer_Load(object sender, EventArgs e)
        {
            SetupDGV();
            LoadData();
        }
        private void SetupDGV()
        {
            dgvListCustomer.AutoGenerateColumns = false;
            dgvListCustomer.Columns.Clear();

            var cols = new[]
            {
                new { Name = "MaKhachHang",   Header = "Mã KH",          Width = 65  },
                new { Name = "HoTen",         Header = "Họ và tên",       Width = 170 },
                new { Name = "SoDienThoai",   Header = "Số điện thoại",   Width = 120 },
                new { Name = "Email",         Header = "Email",           Width = 170 },
                new { Name = "DiaChi",        Header = "Địa chỉ",         Width = 170 },
                new { Name = "DiemTichLuy",   Header = "Điểm tích lũy",   Width = 100 },
                new { Name = "TongChiTieu",   Header = "Tổng chi tiêu",   Width = 120 },
                new { Name = "LoaiThanhVien", Header = "Hạng",            Width = 90  },
                new { Name = "NgayTao",    Header = "Ngày đăng ký",    Width = 110 },
            };

            foreach (var c in cols)
                dgvListCustomer.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = c.Name,
                    HeaderText = c.Header,
                    Width = c.Width,
                    Name = c.Name
                });

            dgvListCustomer.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 97, 217);
            dgvListCustomer.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListCustomer.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvListCustomer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListCustomer.EnableHeadersVisualStyles = false;
            dgvListCustomer.ColumnHeadersHeight = 40;

            dgvListCustomer.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListCustomer.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            dgvListCustomer.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 97, 217);
            dgvListCustomer.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvListCustomer.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvListCustomer.RowTemplate.Height = 38;

            dgvListCustomer.BorderStyle = BorderStyle.None;
            dgvListCustomer.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvListCustomer.GridColor = Color.FromArgb(220, 225, 235);
            dgvListCustomer.RowHeadersVisible = false;
            dgvListCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListCustomer.ReadOnly = true;
            dgvListCustomer.AllowUserToAddRows = false;
            dgvListCustomer.MultiSelect = false;
        }

        private void LoadData(string keyword = "")
        {
            try
            {
                // Lấy tất cả nếu không có keyword, search nếu có
                DataTable dt = string.IsNullOrEmpty(keyword)
                    ? bus.GetAll()
                    : bus.Search(keyword);

                dgvListCustomer.DataSource = dt;
                UpdateStatistics(dt);
                ColorHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorHang()
        {   
            foreach (DataGridViewRow row in dgvListCustomer.Rows)
            {
                var cell = row.Cells["LoaiThanhVien"];
                if (cell.Value == null) continue;

                switch (cell.Value.ToString())
                {
                    case "Đồng":
                        cell.Style.ForeColor = Color.FromArgb(180, 120, 60);
                        break;
                    case "Bạc":
                        cell.Style.ForeColor = Color.FromArgb(140, 140, 140);
                        break;
                    case "Vàng":
                        cell.Style.ForeColor = Color.FromArgb(218, 165, 32);
                        break;
                    case "Đen":
                        cell.Style.ForeColor = Color.FromArgb(30, 30, 30);
                        break;
                }
                cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }
        }

        private void UpdateStatistics(DataTable dt)
        {
            int tongKH = 0;
            int khachMoi = 0;
            int quayLai = 0;

            DateTime nguong = DateTime.Now.AddDays(-7);

            foreach (DataRow row in dt.Rows)
            {
                tongKH++;

                // Khách mới: đăng ký trong 7 ngày gần nhất
                if (row["NgayTao"] != DBNull.Value &&
                    Convert.ToDateTime(row["NgayTao"]) >= nguong)
                    khachMoi++;

                // Khách quay lại: số hóa đơn >= 2
                // Cần thêm cột SoLanMua vào query GetAll/Search
                // hoặc đếm từ bảng HoaDon
                if (row.Table.Columns.Contains("SoLanMua") &&
                    row["SoLanMua"] != DBNull.Value &&
                    Convert.ToInt32(row["SoLanMua"]) >= 2)
                    quayLai++;
            }

            lblTotalCustomer.Text = tongKH.ToString();
            lblNewCustomer.Text = khachMoi.ToString();
            lblReturnCustomer.Text = quayLai.ToString();
        }

        // Nút Lọc — tìm kiếm theo tên hoặc SĐT
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            LoadData(txtSearchNameCustomer.Text.Trim());

        }

        // Tìm kiếm khi nhấn Enter
        private void btnSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData(txtSearchNameCustomer.Text.Trim());
        }

        // Nút Sửa
        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dgvListCustomer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maKH = Convert.ToInt32(
                dgvListCustomer.SelectedRows[0].Cells["MaKhachHang"].Value);

            frmEditCustomer frm = new frmEditCustomer(maKH);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadData(txtSearchNameCustomer.Text.Trim());
        }

        // Nút Xóa
        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            if (dgvListCustomer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenKH = dgvListCustomer.SelectedRows[0].Cells["HoTen"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa khách hàng \"{tenKH}\" không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                int maKH = Convert.ToInt32(
                    dgvListCustomer.SelectedRows[0].Cells["MaKhachHang"].Value);

                if (bus.Delete(maKH))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(txtSearchNameCustomer.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Double click mở form sửa

        private void dgvListCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnEditCustomer_Click(sender, e);
        }


    }
}
