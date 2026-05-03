namespace WindowsFormsApp1.UserControls
{
    partial class ucStaff
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvListStaff = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtSearchStaff = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.pnCartHome = new System.Windows.Forms.TableLayoutPanel();
            this.pnNewCustomers = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCustomerOfline = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnProductsLowStock = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStaffOnline = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnNewOrders = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNewStaff = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnRevenueCart = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalStaff = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnEditProduct = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddProduct = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoveProduct = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListStaff)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.pnCartHome.SuspendLayout();
            this.pnNewCustomers.SuspendLayout();
            this.pnProductsLowStock.SuspendLayout();
            this.pnNewOrders.SuspendLayout();
            this.pnRevenueCart.SuspendLayout();
            this.pnHeader.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2GroupBox2);
            this.guna2Panel1.Controls.Add(this.guna2GroupBox1);
            this.guna2Panel1.Controls.Add(this.pnHeader);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(995, 707);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Controls.Add(this.dgvListStaff);
            this.guna2GroupBox2.Controls.Add(this.txtSearchStaff);
            this.guna2GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox2.Location = new System.Drawing.Point(0, 224);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(995, 483);
            this.guna2GroupBox2.TabIndex = 6;
            this.guna2GroupBox2.Text = "Danh sách nhân sự";
            // 
            // dgvListStaff
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvListStaff.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListStaff.ColumnHeadersHeight = 4;
            this.dgvListStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListStaff.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListStaff.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListStaff.Location = new System.Drawing.Point(0, 40);
            this.dgvListStaff.Name = "dgvListStaff";
            this.dgvListStaff.RowHeadersVisible = false;
            this.dgvListStaff.RowHeadersWidth = 51;
            this.dgvListStaff.RowTemplate.Height = 24;
            this.dgvListStaff.Size = new System.Drawing.Size(995, 443);
            this.dgvListStaff.TabIndex = 1;
            this.dgvListStaff.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListStaff.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListStaff.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListStaff.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListStaff.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListStaff.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListStaff.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListStaff.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListStaff.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListStaff.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvListStaff.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListStaff.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListStaff.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvListStaff.ThemeStyle.ReadOnly = false;
            this.dgvListStaff.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListStaff.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListStaff.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvListStaff.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgvListStaff.ThemeStyle.RowsStyle.Height = 24;
            this.dgvListStaff.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListStaff.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListStaff.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListStaff_CellDoubleClick);
            // 
            // txtSearchStaff
            // 
            this.txtSearchStaff.BackColor = System.Drawing.Color.Transparent;
            this.txtSearchStaff.BorderColor = System.Drawing.Color.Transparent;
            this.txtSearchStaff.BorderRadius = 15;
            this.txtSearchStaff.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchStaff.DefaultText = "";
            this.txtSearchStaff.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchStaff.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchStaff.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchStaff.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchStaff.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchStaff.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchStaff.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchStaff.Location = new System.Drawing.Point(732, 0);
            this.txtSearchStaff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchStaff.Name = "txtSearchStaff";
            this.txtSearchStaff.PlaceholderText = "Tìm tên nhân viên...";
            this.txtSearchStaff.SelectedText = "";
            this.txtSearchStaff.Size = new System.Drawing.Size(257, 38);
            this.txtSearchStaff.TabIndex = 0;
            this.txtSearchStaff.TextChanged += new System.EventHandler(this.txtSearchStaff_TextChanged);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderRadius = 20;
            this.guna2GroupBox1.Controls.Add(this.pnCartHome);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 66);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(995, 158);
            this.guna2GroupBox1.TabIndex = 5;
            this.guna2GroupBox1.Text = "Chi tiết nhân sự";
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
            this.pnCartHome.Size = new System.Drawing.Size(995, 176);
            this.pnCartHome.TabIndex = 0;
            // 
            // pnNewCustomers
            // 
            this.pnNewCustomers.BackColor = System.Drawing.Color.Transparent;
            this.pnNewCustomers.BorderRadius = 15;
            this.pnNewCustomers.Controls.Add(this.lblCustomerOfline);
            this.pnNewCustomers.Controls.Add(this.label5);
            this.pnNewCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnNewCustomers.FillColor = System.Drawing.Color.White;
            this.pnNewCustomers.Location = new System.Drawing.Point(747, 3);
            this.pnNewCustomers.Name = "pnNewCustomers";
            this.pnNewCustomers.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.pnNewCustomers.ShadowDecoration.Enabled = true;
            this.pnNewCustomers.Size = new System.Drawing.Size(245, 170);
            this.pnNewCustomers.TabIndex = 3;
            // 
            // lblCustomerOfline
            // 
            this.lblCustomerOfline.AutoSize = true;
            this.lblCustomerOfline.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerOfline.ForeColor = System.Drawing.Color.Red;
            this.lblCustomerOfline.Location = new System.Drawing.Point(22, 68);
            this.lblCustomerOfline.Name = "lblCustomerOfline";
            this.lblCustomerOfline.Size = new System.Drawing.Size(63, 25);
            this.lblCustomerOfline.TabIndex = 3;
            this.lblCustomerOfline.Text = "label9";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Đang nghỉ";
            // 
            // pnProductsLowStock
            // 
            this.pnProductsLowStock.BackColor = System.Drawing.Color.Transparent;
            this.pnProductsLowStock.BorderRadius = 15;
            this.pnProductsLowStock.Controls.Add(this.lblStaffOnline);
            this.pnProductsLowStock.Controls.Add(this.label4);
            this.pnProductsLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnProductsLowStock.FillColor = System.Drawing.Color.White;
            this.pnProductsLowStock.Location = new System.Drawing.Point(499, 3);
            this.pnProductsLowStock.Name = "pnProductsLowStock";
            this.pnProductsLowStock.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.pnProductsLowStock.ShadowDecoration.Enabled = true;
            this.pnProductsLowStock.Size = new System.Drawing.Size(242, 170);
            this.pnProductsLowStock.TabIndex = 2;
            // 
            // lblStaffOnline
            // 
            this.lblStaffOnline.AutoSize = true;
            this.lblStaffOnline.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffOnline.ForeColor = System.Drawing.Color.Blue;
            this.lblStaffOnline.Location = new System.Drawing.Point(17, 68);
            this.lblStaffOnline.Name = "lblStaffOnline";
            this.lblStaffOnline.Size = new System.Drawing.Size(63, 25);
            this.lblStaffOnline.TabIndex = 3;
            this.lblStaffOnline.Text = "label8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Đang làm việc";
            // 
            // pnNewOrders
            // 
            this.pnNewOrders.BackColor = System.Drawing.Color.Transparent;
            this.pnNewOrders.BorderRadius = 15;
            this.pnNewOrders.Controls.Add(this.lblNewStaff);
            this.pnNewOrders.Controls.Add(this.label3);
            this.pnNewOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnNewOrders.FillColor = System.Drawing.Color.White;
            this.pnNewOrders.Location = new System.Drawing.Point(251, 3);
            this.pnNewOrders.Name = "pnNewOrders";
            this.pnNewOrders.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.pnNewOrders.ShadowDecoration.Enabled = true;
            this.pnNewOrders.Size = new System.Drawing.Size(242, 170);
            this.pnNewOrders.TabIndex = 1;
            // 
            // lblNewStaff
            // 
            this.lblNewStaff.AutoSize = true;
            this.lblNewStaff.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewStaff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblNewStaff.Location = new System.Drawing.Point(22, 68);
            this.lblNewStaff.Name = "lblNewStaff";
            this.lblNewStaff.Size = new System.Drawing.Size(63, 25);
            this.lblNewStaff.TabIndex = 3;
            this.lblNewStaff.Text = "label7";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nhân sự mới";
            // 
            // pnRevenueCart
            // 
            this.pnRevenueCart.BackColor = System.Drawing.Color.Transparent;
            this.pnRevenueCart.BorderRadius = 15;
            this.pnRevenueCart.Controls.Add(this.lblTotalStaff);
            this.pnRevenueCart.Controls.Add(this.label6);
            this.pnRevenueCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRevenueCart.FillColor = System.Drawing.Color.White;
            this.pnRevenueCart.Location = new System.Drawing.Point(3, 3);
            this.pnRevenueCart.Name = "pnRevenueCart";
            this.pnRevenueCart.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.pnRevenueCart.ShadowDecoration.Enabled = true;
            this.pnRevenueCart.Size = new System.Drawing.Size(242, 170);
            this.pnRevenueCart.TabIndex = 0;
            // 
            // lblTotalStaff
            // 
            this.lblTotalStaff.AutoSize = true;
            this.lblTotalStaff.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStaff.ForeColor = System.Drawing.Color.Black;
            this.lblTotalStaff.Location = new System.Drawing.Point(20, 68);
            this.lblTotalStaff.Name = "lblTotalStaff";
            this.lblTotalStaff.Size = new System.Drawing.Size(63, 25);
            this.lblTotalStaff.TabIndex = 2;
            this.lblTotalStaff.Text = "label6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tổng nhân sự";
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnHeader.BorderRadius = 5;
            this.pnHeader.Controls.Add(this.guna2Panel3);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(116)))), ((int)(((byte)(240)))));
            this.pnHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.ShadowDecoration.BorderRadius = 5;
            this.pnHeader.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.pnHeader.ShadowDecoration.Enabled = true;
            this.pnHeader.Size = new System.Drawing.Size(995, 66);
            this.pnHeader.TabIndex = 2;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderRadius = 5;
            this.guna2Panel3.Controls.Add(this.btnEditProduct);
            this.guna2Panel3.Controls.Add(this.btnAddProduct);
            this.guna2Panel3.Controls.Add(this.label2);
            this.guna2Panel3.Controls.Add(this.btnRemoveProduct);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(116)))), ((int)(((byte)(240)))));
            this.guna2Panel3.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.BorderRadius = 5;
            this.guna2Panel3.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.guna2Panel3.ShadowDecoration.Enabled = true;
            this.guna2Panel3.Size = new System.Drawing.Size(995, 66);
            this.guna2Panel3.TabIndex = 4;
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEditProduct.BorderRadius = 10;
            this.btnEditProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditProduct.ForeColor = System.Drawing.Color.White;
            this.btnEditProduct.Location = new System.Drawing.Point(820, 9);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(79, 45);
            this.btnEditProduct.TabIndex = 5;
            this.btnEditProduct.Text = "Sửa";
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddProduct.BorderRadius = 10;
            this.btnAddProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btnAddProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Location = new System.Drawing.Point(730, 9);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(84, 45);
            this.btnAddProduct.TabIndex = 3;
            this.btnAddProduct.Text = "Thêm";
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "QUẢN LÝ NHÂN SỰ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRemoveProduct.BorderRadius = 10;
            this.btnRemoveProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemoveProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemoveProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btnRemoveProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveProduct.ForeColor = System.Drawing.Color.White;
            this.btnRemoveProduct.Location = new System.Drawing.Point(905, 9);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(79, 45);
            this.btnRemoveProduct.TabIndex = 6;
            this.btnRemoveProduct.Text = "Xóa";
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // ucStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ucStaff";
            this.Size = new System.Drawing.Size(995, 707);
            this.Load += new System.EventHandler(this.ucStaff_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListStaff)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.pnCartHome.ResumeLayout(false);
            this.pnNewCustomers.ResumeLayout(false);
            this.pnNewCustomers.PerformLayout();
            this.pnProductsLowStock.ResumeLayout(false);
            this.pnProductsLowStock.PerformLayout();
            this.pnNewOrders.ResumeLayout(false);
            this.pnNewOrders.PerformLayout();
            this.pnRevenueCart.ResumeLayout(false);
            this.pnRevenueCart.PerformLayout();
            this.pnHeader.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Button btnEditProduct;
        private Guna.UI2.WinForms.Guna2Button btnAddProduct;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnRemoveProduct;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.TableLayoutPanel pnCartHome;
        private Guna.UI2.WinForms.Guna2Panel pnNewCustomers;
        private System.Windows.Forms.Label lblCustomerOfline;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Panel pnProductsLowStock;
        private System.Windows.Forms.Label lblStaffOnline;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Panel pnNewOrders;
        private System.Windows.Forms.Label lblNewStaff;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel pnRevenueCart;
        private System.Windows.Forms.Label lblTotalStaff;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchStaff;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListStaff;
    }
}
