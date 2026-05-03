using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WindowsFormsApp1.UserControls;
using WindowsFormsApp1.Utils;
using WindowsFormsApp1.Views.Main;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ucHome _ucHome;
        private ucStaff _ucStaff;
        private ucProducts _ucProducts;
        private ucSell _ucSell;
        private ucCustomer _ucCustomer;
        private ucSupplier _ucSupplier;
        private ucStockIn _ucStockIn;
        private ucReport _ucReport;
        private ucSetting _ucSetting;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _ucHome = new ucHome();
            _ucStaff = new ucStaff();
            _ucProducts = new ucProducts();
            _ucSell = new ucSell();
            _ucCustomer = new ucCustomer();
            _ucSupplier = new ucSupplier();
            _ucStockIn = new ucStockIn();
            _ucReport = new ucReport();
            _ucSetting = new ucSetting();

            foreach (UserControl uc in new UserControl[]
            {
            _ucHome, _ucStaff, _ucProducts,
            _ucSell, _ucCustomer, _ucSupplier, _ucStockIn, _ucReport, _ucSetting
            })
            {
                uc.Dock = DockStyle.Fill;
                pnContainer.Controls.Add(uc);
                uc.Hide();
            }

            PhanQuyen(SessionManager.ChucVu);
            ShowUserControl(_ucHome);
        }
        private void PhanQuyen(string chucVu)
        {
            switch (chucVu)
            {
                case "SuperManager":
                    // Có quyền tất cả - không ẩn gì
                    break;

                case "Manager":
                    btnProducts.Visible = false;
                    btnSell.Visible = false;
                    btnCustomers.Visible = false;
                    btnSupplier.Visible = false;
                    btnStockIn.Visible = false;
                    btnReport.Visible = false;
                    break;

                case "Staff":
                    btnStaff.Visible = false;
                    btnSupplier.Visible = false;
                    btnReport.Visible = false;
                    break;
            }
        }

        private void ShowUserControl(UserControl uc)
        {
            foreach (Control c in pnContainer.Controls)
                c.Hide();
            uc.Show();
            uc.BringToFront();
        }

        private void btnHome_Click(object sender, EventArgs e)
            => ShowUserControl(_ucHome);

        private void btnStaffs_Click(object sender, EventArgs e)
            => ShowUserControl(_ucStaff);

        private void btnProducts_Click(object sender, EventArgs e)
            => ShowUserControl(_ucProducts);

        private void btnSell_Click(object sender, EventArgs e)
            => ShowUserControl(_ucSell);

        private void btnCustomers_Click(object sender, EventArgs e)
            => ShowUserControl(_ucCustomer);

        private void btnSupplier_Click(object sender, EventArgs e)
            => ShowUserControl(_ucSupplier);

        private void btnStockIn_Click(object sender, EventArgs e)
            => ShowUserControl(_ucStockIn);

        private void btnReport_Click(object sender, EventArgs e)
            => ShowUserControl(_ucReport);

        private void btnSetting_Click(object sender, EventArgs e)
            => ShowUserControl(_ucSetting);

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmLogin().Show();
        }

    }
}
