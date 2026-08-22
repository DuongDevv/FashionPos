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
    public partial class ucStaff : UserControl
    {
        private StaffBUS bus = new StaffBUS();

        public ucStaff()
        {
            InitializeComponent();
            SetupDGV();
        }

        private void ucStaff_Load(object sender, EventArgs e)
        {
            SetupDGV();
            LoadData();
        }
 
        private void SetupDGV()
        {
            dgvListStaff.AutoGenerateColumns = false;
            dgvListStaff.Columns.Clear();

            var cols = new[]
            {
                new { Name = "MaNhanVien",  Header = "Mã NV",          Width = 65  },
                new { Name = "HoTen",       Header = "Họ và tên",       Width = 180 },
                new { Name = "ChucVu",      Header = "Chức vụ",         Width = 130 },
                new { Name = "SoDienThoai", Header = "Số điện thoại",   Width = 120 },
                new { Name = "Email",       Header = "Email",           Width = 190 },
                new { Name = "TenDangNhap", Header = "Tên đăng nhập",   Width = 130 },
                new { Name = "TrangThai",   Header = "Trạng thái",      Width = 120 },
            };

            foreach (var c in cols)
            {
                dgvListStaff.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = c.Name,
                    HeaderText = c.Header,
                    Width = c.Width,
                    Name = c.Name
                });
            }

            dgvListStaff.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 97, 217);
            dgvListStaff.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListStaff.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvListStaff.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListStaff.EnableHeadersVisualStyles = false;
            dgvListStaff.ColumnHeadersHeight = 40;

            dgvListStaff.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListStaff.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 92, 88);
            dgvListStaff.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvListStaff.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvListStaff.RowTemplate.Height = 38;

            dgvListStaff.BorderStyle = BorderStyle.None;
            dgvListStaff.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvListStaff.GridColor = Color.FromArgb(220, 225, 235);
            dgvListStaff.RowHeadersVisible = false;
            dgvListStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListStaff.ReadOnly = true;
            dgvListStaff.AllowUserToAddRows = false;
            dgvListStaff.MultiSelect = false;
        }

        private void LoadData(string keyword = "")
        {
            try
            {
                DataTable dt = string.IsNullOrEmpty(keyword)
                    ? bus.GetAll()
                    : bus.Search(keyword, "Tất cả");

                dgvListStaff.DataSource = dt;
                UpdateStatistics(dt);
                ColorState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorState()
        {
            foreach (DataGridViewRow row in dgvListStaff.Rows)
            {
                var cell = row.Cells["TrangThai"];
                if (cell.Value == null) continue;

                if (cell.Value.ToString() == "Đang làm việc")
                {
                    cell.Style.ForeColor = Color.FromArgb(39, 174, 96);
                    cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
                else
                {
                    cell.Style.ForeColor = Color.FromArgb(231, 76, 60);
                    cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
            }
        }

        private void UpdateStatistics(DataTable dt)
        {
            int tongNV = 0;
            int nsMoi = 0;
            int dangLam = 0;
            int dangNghi = 0;

            DateTime nguong = DateTime.Now.AddDays(-7);

            foreach (DataRow row in dt.Rows)
            {
                tongNV++;

                string tt = row["TrangThai"].ToString();
                if (tt == "Đang làm việc") dangLam++;
                else dangNghi++;

                if (row["NgayTao"] != DBNull.Value &&
                    Convert.ToDateTime(row["NgayTao"]) >= nguong)
                    nsMoi++;
            }

            lblTotalStaff.Text = tongNV.ToString();
            lblNewStaff.Text = nsMoi.ToString();
            lblStaffOnline.Text = dangLam.ToString();
            lblCustomerOfline.Text = dangNghi.ToString();
        }

        private void txtSearchStaff_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearchStaff.Text.Trim());
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmEditStaff frm = new frmEditStaff();
            if (frm.ShowDialog() == DialogResult.OK)
                LoadData(txtSearchStaff.Text.Trim());
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvListStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = Convert.ToInt32(
                dgvListStaff.SelectedRows[0].Cells["MaNhanVien"].Value);

            frmEditStaff frm = new frmEditStaff(maNV);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadData(txtSearchStaff.Text.Trim());
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvListStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenNV = dgvListStaff.SelectedRows[0].Cells["HoTen"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn cho nhân viên \"{tenNV}\" nghỉ việc không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                int maNV = Convert.ToInt32(
                    dgvListStaff.SelectedRows[0].Cells["MaNhanVien"].Value);

                if (bus.Delete(maNV))
                {
                    MessageBox.Show("Chuyển trạng thái sang Nghỉ việc thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(txtSearchStaff.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnEditProduct_Click(sender, e);
        }


    }
}
