using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BUS;

namespace WindowsFormsApp1.Views.Auth
{
    public partial class frmEditStaff : Form
    {
        private StaffBUS bus = new StaffBUS();
        private int _staffID;
        private string _imgPath = null;

        public frmEditStaff(int maNhanVien = 0)
        {
            InitializeComponent();
            _staffID = maNhanVien;
        }

        private void frmEditStaff_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            dtpStaffDate.Value = DateTime.Today;

            if (_staffID > 0)
                LoadEditStaff();
            else
                LoadAddStaff();
        }

        private void LoadComboBox()
        {
            cboStaffPosition.Items.Clear();
            cboStaffPosition.Items.AddRange(new object[]
            {
                "Manager", "Staff"
            });

            cboStaffSex.Items.Clear();
            cboStaffSex.Items.AddRange(new object[]
            {
                "Nam", "Nữ", "Khác"
            });
            cboStaffSex.SelectedIndex = 0;
        }

        private void LoadAddStaff()
        {
            lblTitle.Text = "THÊM NHÂN SỰ";
            txtStaffID.Text = bus.GetNextID().ToString();
            txtStaffID.Enabled = false;
        }

        private void LoadEditStaff()
        {
            lblTitle.Text = "ĐIỀU CHỈNH NHÂN SỰ";
            txtStaffID.Text = _staffID.ToString();
            txtStaffID.Enabled = false;

            try
            {
                DataRow row = bus.GetByID(_staffID);
                if (row == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtStaffFullName.Text = row["HoTen"].ToString();
                txtStaffPhone.Text = row["SoDienThoai"].ToString();
                txtStaffEmail.Text = row["Email"].ToString();
                txtUserName.Text = row["TenDangNhap"].ToString();
                txtPassword.Text = row["MatKhau"].ToString();
                txtUserName.Enabled = false;

                if (row["NgaySinh"] != DBNull.Value)
                    dtpStaffDate.Value = Convert.ToDateTime(row["NgaySinh"]);

                if (row["GioiTinh"] != DBNull.Value)
                    cboStaffSex.SelectedIndex = Convert.ToInt32(row["GioiTinh"]);

                string chucVu = row["ChucVu"].ToString();
                cboStaffPosition.SelectedIndex = cboStaffPosition.FindStringExact(chucVu);
                if (cboStaffPosition.SelectedIndex == -1)
                    cboStaffPosition.Text = chucVu;

                string hinhAnh = row["HinhAnh"].ToString();
                if (!string.IsNullOrEmpty(hinhAnh) && File.Exists(hinhAnh))
                {
                    string fullPath = Path.Combine(Application.StartupPath, hinhAnh);
                    if (File.Exists(fullPath))
                    {
                        _imgPath = hinhAnh; 
                        SetRoundImage(Image.FromFile(fullPath));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetRoundImage(Image img)
        {
            int size = Math.Min(picStaffAvatar.Width, picStaffAvatar.Height);
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

            picStaffAvatar.Image = bmp;
            picStaffAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string hoTen = txtStaffFullName.Text.Trim();
                string soDienThoai = txtStaffPhone.Text.Trim();
                string email = txtStaffEmail.Text.Trim();
                string chucVu = cboStaffPosition.Text.Trim();
                string tenDangNhap = txtUserName.Text.Trim();
                int gioiTinh = cboStaffSex.SelectedIndex;
                object ngaySinh = dtpStaffDate.Value.Date;
                object hinhAnh = string.IsNullOrEmpty(_imgPath)
                                     ? null : (object)_imgPath;

                object objSDT = string.IsNullOrEmpty(soDienThoai) ? null : (object)soDienThoai;
                object objEmail = string.IsNullOrEmpty(email) ? null : (object)email;
                object objCV = string.IsNullOrEmpty(chucVu) ? null : (object)chucVu;

                if (_staffID == 0)
                {
                    string matKhau = txtPassword.Text.Trim();
                    int maMoi = bus.Insert(hoTen, ngaySinh, gioiTinh, objSDT, objEmail, hinhAnh, objCV, tenDangNhap, matKhau);
                    if (maMoi > 0)
                    {
                        txtStaffID.Text = maMoi.ToString();
                        MessageBox.Show($"Thêm nhân viên thành công! Mã NV: {maMoi}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    bool ok = bus.Update(_staffID, hoTen, ngaySinh, gioiTinh, objSDT, objEmail, hinhAnh,objCV, "Đang làm việc");
                    if (ok)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thành công",
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

        private void btnUpLoadImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Chọn ảnh đại diện";

                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    // Tạo thư mục img\staff nếu chưa có
                    string folder = Path.Combine(
                        Application.StartupPath, "img", "staff");
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    // Đặt tên file mới = timestamp tránh trùng
                    string ext = Path.GetExtension(ofd.FileName);
                    string newName = $"staff_{DateTime.Now:yyyyMMddHHmmss}{ext}";
                    string destPath = Path.Combine(folder, newName);

                    // Copy ảnh vào thư mục
                    File.Copy(ofd.FileName, destPath, overwrite: true);

                    // Lưu đường dẫn tương đối vào biến
                    _imgPath = Path.Combine("img", "staff", newName);

                    // Hiển thị ảnh tròn
                    SetRoundImage(Image.FromFile(destPath));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn chắc chắn muốn thoát chương trình chứ?", "Thông báo",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtStaffPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}
