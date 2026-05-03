namespace WindowsFormsApp1.UserControls
{
    partial class ucHome
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnCartHome = new System.Windows.Forms.TableLayoutPanel();
            this.pnNewCustomers = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNewCustomerThisMonth = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnProductsLowStock = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProductOFStock = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnNewOrders = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNewBill = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnRevenueCart = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRevenueToday = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnHeaderHome = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvTopPoduct = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnCartHome.SuspendLayout();
            this.pnNewCustomers.SuspendLayout();
            this.pnProductsLowStock.SuspendLayout();
            this.pnNewOrders.SuspendLayout();
            this.pnRevenueCart.SuspendLayout();
            this.pnHeaderHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopPoduct)).BeginInit();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // pnCartHome
            // 
            this.pnCartHome.BackColor = System.Drawing.Color.Transparent;
            this.pnCartHome.ColumnCount = 4;
            this.pnCartHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnCartHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnCartHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnCartHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnCartHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.pnCartHome.Controls.Add(this.pnNewCustomers, 3, 0);
            this.pnCartHome.Controls.Add(this.pnProductsLowStock, 2, 0);
            this.pnCartHome.Controls.Add(this.pnNewOrders, 1, 0);
            this.pnCartHome.Controls.Add(this.pnRevenueCart, 0, 0);
            this.pnCartHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCartHome.Location = new System.Drawing.Point(0, 40);
            this.pnCartHome.Name = "pnCartHome";
            this.pnCartHome.RowCount = 1;
            this.pnCartHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnCartHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.pnCartHome.Size = new System.Drawing.Size(1098, 176);
            this.pnCartHome.TabIndex = 0;
            // 
            // pnNewCustomers
            // 
            this.pnNewCustomers.BackColor = System.Drawing.Color.Transparent;
            this.pnNewCustomers.BorderRadius = 15;
            this.pnNewCustomers.Controls.Add(this.lblNewCustomerThisMonth);
            this.pnNewCustomers.Controls.Add(this.label5);
            this.pnNewCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnNewCustomers.FillColor = System.Drawing.Color.White;
            this.pnNewCustomers.Location = new System.Drawing.Point(825, 3);
            this.pnNewCustomers.Name = "pnNewCustomers";
            this.pnNewCustomers.ShadowDecoration.Enabled = true;
            this.pnNewCustomers.Size = new System.Drawing.Size(270, 170);
            this.pnNewCustomers.TabIndex = 3;
            // 
            // lblNewCustomerThisMonth
            // 
            this.lblNewCustomerThisMonth.AutoSize = true;
            this.lblNewCustomerThisMonth.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCustomerThisMonth.Location = new System.Drawing.Point(170, 121);
            this.lblNewCustomerThisMonth.Name = "lblNewCustomerThisMonth";
            this.lblNewCustomerThisMonth.Size = new System.Drawing.Size(63, 25);
            this.lblNewCustomerThisMonth.TabIndex = 3;
            this.lblNewCustomerThisMonth.Text = "label9";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Khách hàng mới:";
            // 
            // pnProductsLowStock
            // 
            this.pnProductsLowStock.BackColor = System.Drawing.Color.Transparent;
            this.pnProductsLowStock.BorderRadius = 15;
            this.pnProductsLowStock.Controls.Add(this.lblProductOFStock);
            this.pnProductsLowStock.Controls.Add(this.label4);
            this.pnProductsLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnProductsLowStock.FillColor = System.Drawing.Color.White;
            this.pnProductsLowStock.Location = new System.Drawing.Point(551, 3);
            this.pnProductsLowStock.Name = "pnProductsLowStock";
            this.pnProductsLowStock.ShadowDecoration.Enabled = true;
            this.pnProductsLowStock.Size = new System.Drawing.Size(268, 170);
            this.pnProductsLowStock.TabIndex = 2;
            // 
            // lblProductOFStock
            // 
            this.lblProductOFStock.AutoSize = true;
            this.lblProductOFStock.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductOFStock.ForeColor = System.Drawing.Color.Red;
            this.lblProductOFStock.Location = new System.Drawing.Point(152, 121);
            this.lblProductOFStock.Name = "lblProductOFStock";
            this.lblProductOFStock.Size = new System.Drawing.Size(63, 25);
            this.lblProductOFStock.TabIndex = 3;
            this.lblProductOFStock.Text = "label8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Sản phẩm sắp hết:";
            // 
            // pnNewOrders
            // 
            this.pnNewOrders.BackColor = System.Drawing.Color.Transparent;
            this.pnNewOrders.BorderRadius = 15;
            this.pnNewOrders.Controls.Add(this.lblNewBill);
            this.pnNewOrders.Controls.Add(this.label3);
            this.pnNewOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnNewOrders.FillColor = System.Drawing.Color.White;
            this.pnNewOrders.Location = new System.Drawing.Point(277, 3);
            this.pnNewOrders.Name = "pnNewOrders";
            this.pnNewOrders.ShadowDecoration.Enabled = true;
            this.pnNewOrders.Size = new System.Drawing.Size(268, 170);
            this.pnNewOrders.TabIndex = 1;
            // 
            // lblNewBill
            // 
            this.lblNewBill.AutoSize = true;
            this.lblNewBill.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewBill.Location = new System.Drawing.Point(153, 121);
            this.lblNewBill.Name = "lblNewBill";
            this.lblNewBill.Size = new System.Drawing.Size(63, 25);
            this.lblNewBill.TabIndex = 3;
            this.lblNewBill.Text = "label7";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đơn hàng mới:";
            // 
            // pnRevenueCart
            // 
            this.pnRevenueCart.BackColor = System.Drawing.Color.Transparent;
            this.pnRevenueCart.BorderRadius = 15;
            this.pnRevenueCart.Controls.Add(this.lblRevenueToday);
            this.pnRevenueCart.Controls.Add(this.label2);
            this.pnRevenueCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRevenueCart.FillColor = System.Drawing.Color.White;
            this.pnRevenueCart.Location = new System.Drawing.Point(3, 3);
            this.pnRevenueCart.Name = "pnRevenueCart";
            this.pnRevenueCart.ShadowDecoration.Enabled = true;
            this.pnRevenueCart.Size = new System.Drawing.Size(268, 170);
            this.pnRevenueCart.TabIndex = 0;
            // 
            // lblRevenueToday
            // 
            this.lblRevenueToday.AutoSize = true;
            this.lblRevenueToday.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblRevenueToday.Location = new System.Drawing.Point(168, 121);
            this.lblRevenueToday.Name = "lblRevenueToday";
            this.lblRevenueToday.Size = new System.Drawing.Size(63, 25);
            this.lblRevenueToday.TabIndex = 2;
            this.lblRevenueToday.Text = "label6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Doanh thu hôm nay:";
            // 
            // pnHeaderHome
            // 
            this.pnHeaderHome.BorderRadius = 15;
            this.pnHeaderHome.Controls.Add(this.lblStaffName);
            this.pnHeaderHome.Controls.Add(this.label1);
            this.pnHeaderHome.Controls.Add(this.picAvatar);
            this.pnHeaderHome.Controls.Add(this.guna2HtmlLabel1);
            this.pnHeaderHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeaderHome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(116)))), ((int)(((byte)(240)))));
            this.pnHeaderHome.Location = new System.Drawing.Point(0, 0);
            this.pnHeaderHome.Name = "pnHeaderHome";
            this.pnHeaderHome.Size = new System.Drawing.Size(1098, 85);
            this.pnHeaderHome.TabIndex = 0;
            // 
            // lblStaffName
            // 
            this.lblStaffName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.BackColor = System.Drawing.Color.Transparent;
            this.lblStaffName.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffName.ForeColor = System.Drawing.Color.White;
            this.lblStaffName.Location = new System.Drawing.Point(1013, 33);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(48, 17);
            this.lblStaffName.TabIndex = 5;
            this.lblStaffName.Text = "Admin";
            this.lblStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "TRANG CHỦ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            this.picAvatar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.FillColor = System.Drawing.Color.Black;
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(951, 10);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(56, 56);
            this.picAvatar.TabIndex = 3;
            this.picAvatar.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(54, 33);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(136, 33);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "TRANG CHỦ";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderRadius = 20;
            this.guna2GroupBox1.Controls.Add(this.pnCartHome);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 85);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1098, 217);
            this.guna2GroupBox1.TabIndex = 4;
            this.guna2GroupBox1.Text = "THỐNG KÊ";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2GroupBox3);
            this.guna2Panel1.Controls.Add(this.guna2GroupBox2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 302);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1098, 488);
            this.guna2Panel1.TabIndex = 5;
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.Controls.Add(this.dgvTopPoduct);
            this.guna2GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox3.Location = new System.Drawing.Point(526, 0);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.Size = new System.Drawing.Size(572, 488);
            this.guna2GroupBox3.TabIndex = 1;
            this.guna2GroupBox3.Text = "Top 5 bán chạy";
            // 
            // dgvTopPoduct
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTopPoduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopPoduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTopPoduct.ColumnHeadersHeight = 4;
            this.dgvTopPoduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.Format = "{0:N0}đ";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTopPoduct.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTopPoduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopPoduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTopPoduct.Location = new System.Drawing.Point(0, 40);
            this.dgvTopPoduct.Name = "dgvTopPoduct";
            this.dgvTopPoduct.RowHeadersVisible = false;
            this.dgvTopPoduct.RowHeadersWidth = 51;
            this.dgvTopPoduct.RowTemplate.Height = 24;
            this.dgvTopPoduct.Size = new System.Drawing.Size(572, 448);
            this.dgvTopPoduct.TabIndex = 0;
            this.dgvTopPoduct.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopPoduct.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTopPoduct.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTopPoduct.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTopPoduct.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTopPoduct.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopPoduct.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTopPoduct.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTopPoduct.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTopPoduct.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvTopPoduct.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTopPoduct.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTopPoduct.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvTopPoduct.ThemeStyle.ReadOnly = false;
            this.dgvTopPoduct.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopPoduct.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTopPoduct.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvTopPoduct.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgvTopPoduct.ThemeStyle.RowsStyle.Height = 24;
            this.dgvTopPoduct.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTopPoduct.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Controls.Add(this.chartRevenue);
            this.guna2GroupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox2.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(526, 488);
            this.guna2GroupBox2.TabIndex = 0;
            this.guna2GroupBox2.Text = "Doanh thu theo tháng:";
            // 
            // chartRevenue
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea1);
            this.chartRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend1);
            this.chartRevenue.Location = new System.Drawing.Point(0, 40);
            this.chartRevenue.Name = "chartRevenue";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRevenue.Series.Add(series1);
            this.chartRevenue.Size = new System.Drawing.Size(526, 448);
            this.chartRevenue.TabIndex = 0;
            this.chartRevenue.Text = "chart1";
            // 
            // ucHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.pnHeaderHome);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucHome";
            this.Size = new System.Drawing.Size(1098, 790);
            this.pnCartHome.ResumeLayout(false);
            this.pnNewCustomers.ResumeLayout(false);
            this.pnNewCustomers.PerformLayout();
            this.pnProductsLowStock.ResumeLayout(false);
            this.pnProductsLowStock.PerformLayout();
            this.pnNewOrders.ResumeLayout(false);
            this.pnNewOrders.PerformLayout();
            this.pnRevenueCart.ResumeLayout(false);
            this.pnRevenueCart.PerformLayout();
            this.pnHeaderHome.ResumeLayout(false);
            this.pnHeaderHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopPoduct)).EndInit();
            this.guna2GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnHeaderHome;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.TableLayoutPanel pnCartHome;
        private Guna.UI2.WinForms.Guna2Panel pnRevenueCart;
        private Guna.UI2.WinForms.Guna2Panel pnNewCustomers;
        private Guna.UI2.WinForms.Guna2Panel pnProductsLowStock;
        private Guna.UI2.WinForms.Guna2Panel pnNewOrders;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTopPoduct;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.Label lblNewCustomerThisMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProductOFStock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNewBill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRevenueToday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStaffName;
    }
}
