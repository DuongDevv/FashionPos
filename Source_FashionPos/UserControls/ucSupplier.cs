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
    public partial class ucSupplier : UserControl
    {
        private SupplierBUS bus = new SupplierBUS();
        private bool _daLoad = false;

        public ucSupplier()
        {
            InitializeComponent();
            SetupDGV();
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible && !_daLoad)
            {
                LoadData();
                _daLoad = true;
            }
        }

        private void ucSupplier_Load(object sender, EventArgs e){}

        private void SetupDGV()
        {
            dgvListSupplier.AutoGenerateColumns = false;
            dgvListSupplier.Columns.Clear();

            var cols = new[]
            {
                new { Name = "MaNhaCungCap",  Header = "Mã NCC",          Width = 70  },
                new { Name = "TenNhaCungCap", Header = "Tên nhà cung cấp", Width = 200 },
                new { Name = "NguoiLienHe",   Header = "Người liên hệ",   Width = 140 },
                new { Name = "SoDienThoai",   Header = "Số điện thoại",   Width = 120 },
                new { Name = "Email",         Header = "Email",           Width = 170 },
                new { Name = "DiaChi",        Header = "Địa chỉ",         Width = 200 },
                new { Name = "TrangThai",     Header = "Trạng thái",      Width = 100 },
            };

            foreach (var c in cols)
                dgvListSupplier.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = c.Name,
                    HeaderText = c.Header,
                    Width = c.Width,
                    Name = c.Name
                });

            dgvListSupplier.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 97, 217);
            dgvListSupplier.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListSupplier.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvListSupplier.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListSupplier.EnableHeadersVisualStyles = false;
            dgvListSupplier.ColumnHeadersHeight = 40;

            dgvListSupplier.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListSupplier.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            dgvListSupplier.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 97, 217);
            dgvListSupplier.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvListSupplier.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvListSupplier.RowTemplate.Height = 38;

            dgvListSupplier.BorderStyle = BorderStyle.None;
            dgvListSupplier.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvListSupplier.GridColor = Color.FromArgb(220, 225, 235);
            dgvListSupplier.RowHeadersVisible = false;
            dgvListSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListSupplier.ReadOnly = true;
            dgvListSupplier.AllowUserToAddRows = false;
            dgvListSupplier.MultiSelect = false;

            dgvListSupplier.DataError += (s, e) => e.Cancel = true;
        }

        private void LoadData()
        {
            try
            {
                DataTable dt = bus.GetAll();
                dgvListSupplier.DataSource = dt;
                ColorTrangThai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorTrangThai()
        {
            foreach (DataGridViewRow row in dgvListSupplier.Rows)
            {
                var cell = row.Cells["TrangThai"];
                if (cell.Value == null) continue;

                string val = cell.Value.ToString();
                bool hopTac = val == "1" || val == "True" || val == "Đang hợp tác";

                cell.Value = hopTac ? "Đang hợp tác" : "Ngừng hợp tác";
                cell.Style.ForeColor = hopTac
                    ? Color.FromArgb(39, 174, 96)
                    : Color.FromArgb(231, 76, 60);
                cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {

            frmEditSupplier frm = new frmEditSupplier(0);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            if (dgvListSupplier.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNCC = Convert.ToInt32(
                dgvListSupplier.SelectedRows[0].Cells["MaNhaCungCap"].Value);

            frmEditSupplier frm = new frmEditSupplier(maNCC);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        



        private void btnRemoveSupplier_Click(object sender, EventArgs e)
        {
            if (dgvListSupplier.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNCC = Convert.ToInt32(
                dgvListSupplier.SelectedRows[0].Cells["MaNhaCungCap"].Value);
            string tenNCC = dgvListSupplier.SelectedRows[0].Cells["TenNhaCungCap"].Value.ToString();
            string trangThai = dgvListSupplier.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            bool dangHopTac = trangThai == "Đang hợp tác" || trangThai == "True" || trangThai == "1";
            string hanhDong = dangHopTac ? "ngừng hợp tác" : "khôi phục hợp tác";

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn {hanhDong} với \"{tenNCC}\" không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = dangHopTac ? bus.Delete(maNCC) : bus.Restore(maNCC);

                if (ok)
                {
                    MessageBox.Show($"Đã {hanhDong} thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnEditSupplier_Click(sender, e);
        }
    }
}
