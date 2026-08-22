using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.UserControls
{
    public partial class ucProductItem : UserControl
    {
        public int MaBienThe { get; private set; }
        public string TenSanPham { get; private set; }
        public decimal GiaBan { get; private set; }
        public int SoLuongTon { get; private set; }

        //Event khi click vào cart
        public event System.EventHandler OnProductSelected;

        public ucProductItem(int maBienThe, string tenSanPham,
                             decimal giaBan, int soLuongTon,
                             string hinhAnh)
        {
            InitializeComponent();
            MaBienThe = maBienThe;
            TenSanPham = tenSanPham;
            GiaBan = giaBan;
            SoLuongTon = soLuongTon;

            lblProductName.Text = tenSanPham;
            lblProductPrice.Text = string.Format("{0:N0}đ", giaBan);
            lblProductStock.Text = $"Tồn: {soLuongTon}";

            // Load ảnh
            if (!string.IsNullOrEmpty(hinhAnh))
            {
                string fullPath = System.IO.Path.Combine(
                    Application.StartupPath, hinhAnh);
                if (System.IO.File.Exists(fullPath))
                {
                    picbProductImage.Image = Image.FromFile(fullPath);
                    picbProductImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }

            // Hết hàng → làm mờ card
            if (soLuongTon <= 0)
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                lblProductStock.ForeColor = Color.Red;
                lblProductStock.Text = "Hết hàng";
            }

            // Gắn event click cho toàn bộ card
            this.Click += Item_Click;
            picbProductImage.Click += Item_Click;
            lblProductName.Click += Item_Click;
            lblProductPrice.Click += Item_Click;
            lblProductStock.Click += Item_Click;
        }

        private void Item_Click(object sender, System.EventArgs e)
        {
            if (SoLuongTon <= 0)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Sản phẩm này đã hết hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OnProductSelected?.Invoke(this, e);
        }


    }
}
