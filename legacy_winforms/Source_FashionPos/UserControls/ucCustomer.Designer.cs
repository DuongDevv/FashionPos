namespace WindowsFormsApp1.UserControls
{
    partial class ucCustomer
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
            this.pnCustomer = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvListCustomer = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel8 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblReturnCustomer = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2Panel7 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNewCustomer = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalCustomer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnSearchCustomer = new Guna.UI2.WinForms.Guna2Panel();
            this.grbSearchProduct = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnEditCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.btnRemoveCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearchCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearchNameCustomer = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnHeaderCustomer = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnCustomer.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCustomer)).BeginInit();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel8.SuspendLayout();
            this.guna2Panel7.SuspendLayout();
            this.guna2Panel6.SuspendLayout();
            this.pnSearchCustomer.SuspendLayout();
            this.grbSearchProduct.SuspendLayout();
            this.pnHeaderCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnCustomer
            // 
            this.pnCustomer.Controls.Add(this.guna2Panel5);
            this.pnCustomer.Controls.Add(this.guna2Panel3);
            this.pnCustomer.Controls.Add(this.pnSearchCustomer);
            this.pnCustomer.Controls.Add(this.pnHeaderCustomer);
            this.pnCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCustomer.Location = new System.Drawing.Point(5, 5);
            this.pnCustomer.Name = "pnCustomer";
            this.pnCustomer.Size = new System.Drawing.Size(925, 715);
            this.pnCustomer.TabIndex = 0;
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.BackColor = System.Drawing.Color.Gray;
            this.guna2Panel5.BorderRadius = 10;
            this.guna2Panel5.BorderThickness = 1;
            this.guna2Panel5.Controls.Add(this.guna2GroupBox1);
            this.guna2Panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel5.FillColor = System.Drawing.Color.White;
            this.guna2Panel5.Location = new System.Drawing.Point(0, 339);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(925, 376);
            this.guna2Panel5.TabIndex = 2;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.dgvListCustomer);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(925, 376);
            this.guna2GroupBox1.TabIndex = 0;
            this.guna2GroupBox1.Text = "Danh sách khách hàng:";
            // 
            // dgvListCustomer
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvListCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListCustomer.ColumnHeadersHeight = 4;
            this.dgvListCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListCustomer.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListCustomer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListCustomer.Location = new System.Drawing.Point(0, 40);
            this.dgvListCustomer.Name = "dgvListCustomer";
            this.dgvListCustomer.RowHeadersVisible = false;
            this.dgvListCustomer.RowHeadersWidth = 51;
            this.dgvListCustomer.RowTemplate.Height = 24;
            this.dgvListCustomer.Size = new System.Drawing.Size(925, 336);
            this.dgvListCustomer.TabIndex = 0;
            this.dgvListCustomer.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListCustomer.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListCustomer.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListCustomer.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListCustomer.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListCustomer.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListCustomer.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListCustomer.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListCustomer.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListCustomer.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvListCustomer.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListCustomer.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListCustomer.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvListCustomer.ThemeStyle.ReadOnly = false;
            this.dgvListCustomer.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListCustomer.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListCustomer.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvListCustomer.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgvListCustomer.ThemeStyle.RowsStyle.Height = 24;
            this.dgvListCustomer.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListCustomer.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListCustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListCustomer_CellDoubleClick);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.guna2Panel8);
            this.guna2Panel3.Controls.Add(this.guna2Panel7);
            this.guna2Panel3.Controls.Add(this.guna2Panel6);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 210);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(925, 129);
            this.guna2Panel3.TabIndex = 1;
            // 
            // guna2Panel8
            // 
            this.guna2Panel8.BackColor = System.Drawing.Color.Gray;
            this.guna2Panel8.BorderRadius = 10;
            this.guna2Panel8.BorderThickness = 1;
            this.guna2Panel8.Controls.Add(this.lblReturnCustomer);
            this.guna2Panel8.Controls.Add(this.label8);
            this.guna2Panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel8.FillColor = System.Drawing.Color.White;
            this.guna2Panel8.Location = new System.Drawing.Point(616, 0);
            this.guna2Panel8.Name = "guna2Panel8";
            this.guna2Panel8.Size = new System.Drawing.Size(308, 129);
            this.guna2Panel8.TabIndex = 2;
            // 
            // lblReturnCustomer
            // 
            this.lblReturnCustomer.AutoSize = true;
            this.lblReturnCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblReturnCustomer.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnCustomer.ForeColor = System.Drawing.Color.Blue;
            this.lblReturnCustomer.Location = new System.Drawing.Point(237, 62);
            this.lblReturnCustomer.Name = "lblReturnCustomer";
            this.lblReturnCustomer.Size = new System.Drawing.Size(43, 50);
            this.lblReturnCustomer.TabIndex = 5;
            this.lblReturnCustomer.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "KHÁCH HÀNG QUAY LẠI:";
            // 
            // guna2Panel7
            // 
            this.guna2Panel7.BackColor = System.Drawing.Color.Gray;
            this.guna2Panel7.BorderRadius = 10;
            this.guna2Panel7.BorderThickness = 1;
            this.guna2Panel7.Controls.Add(this.lblNewCustomer);
            this.guna2Panel7.Controls.Add(this.label6);
            this.guna2Panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel7.FillColor = System.Drawing.Color.White;
            this.guna2Panel7.Location = new System.Drawing.Point(308, 0);
            this.guna2Panel7.Name = "guna2Panel7";
            this.guna2Panel7.Size = new System.Drawing.Size(308, 129);
            this.guna2Panel7.TabIndex = 1;
            // 
            // lblNewCustomer
            // 
            this.lblNewCustomer.AutoSize = true;
            this.lblNewCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblNewCustomer.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCustomer.ForeColor = System.Drawing.Color.Lime;
            this.lblNewCustomer.Location = new System.Drawing.Point(237, 62);
            this.lblNewCustomer.Name = "lblNewCustomer";
            this.lblNewCustomer.Size = new System.Drawing.Size(43, 50);
            this.lblNewCustomer.TabIndex = 3;
            this.lblNewCustomer.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "KHÁCH HÀNG MỚI:";
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.BackColor = System.Drawing.Color.Gray;
            this.guna2Panel6.BorderRadius = 10;
            this.guna2Panel6.BorderThickness = 1;
            this.guna2Panel6.Controls.Add(this.lblTotalCustomer);
            this.guna2Panel6.Controls.Add(this.label3);
            this.guna2Panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel6.FillColor = System.Drawing.Color.White;
            this.guna2Panel6.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.Size = new System.Drawing.Size(308, 129);
            this.guna2Panel6.TabIndex = 0;
            // 
            // lblTotalCustomer
            // 
            this.lblTotalCustomer.AutoSize = true;
            this.lblTotalCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCustomer.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCustomer.Location = new System.Drawing.Point(226, 64);
            this.lblTotalCustomer.Name = "lblTotalCustomer";
            this.lblTotalCustomer.Size = new System.Drawing.Size(43, 50);
            this.lblTotalCustomer.TabIndex = 1;
            this.lblTotalCustomer.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "TỔNG KHÁCH HÀNG:";
            // 
            // pnSearchCustomer
            // 
            this.pnSearchCustomer.Controls.Add(this.grbSearchProduct);
            this.pnSearchCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnSearchCustomer.Location = new System.Drawing.Point(0, 64);
            this.pnSearchCustomer.Name = "pnSearchCustomer";
            this.pnSearchCustomer.Size = new System.Drawing.Size(925, 146);
            this.pnSearchCustomer.TabIndex = 1;
            // 
            // grbSearchProduct
            // 
            this.grbSearchProduct.BorderRadius = 10;
            this.grbSearchProduct.Controls.Add(this.btnEditCustomer);
            this.grbSearchProduct.Controls.Add(this.btnRemoveCustomer);
            this.grbSearchProduct.Controls.Add(this.btnSearchCustomer);
            this.grbSearchProduct.Controls.Add(this.txtSearchNameCustomer);
            this.grbSearchProduct.Controls.Add(this.label2);
            this.grbSearchProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbSearchProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grbSearchProduct.Location = new System.Drawing.Point(0, 0);
            this.grbSearchProduct.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.grbSearchProduct.Name = "grbSearchProduct";
            this.grbSearchProduct.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.grbSearchProduct.Size = new System.Drawing.Size(925, 146);
            this.grbSearchProduct.TabIndex = 1;
            this.grbSearchProduct.Text = "Tìm kiếm";
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.BackColor = System.Drawing.Color.White;
            this.btnEditCustomer.BorderColor = System.Drawing.Color.Transparent;
            this.btnEditCustomer.BorderRadius = 20;
            this.btnEditCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btnEditCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditCustomer.ForeColor = System.Drawing.Color.White;
            this.btnEditCustomer.Location = new System.Drawing.Point(724, 72);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(72, 53);
            this.btnEditCustomer.TabIndex = 6;
            this.btnEditCustomer.Text = "Sửa";
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // btnRemoveCustomer
            // 
            this.btnRemoveCustomer.BackColor = System.Drawing.Color.White;
            this.btnRemoveCustomer.BorderColor = System.Drawing.Color.Transparent;
            this.btnRemoveCustomer.BorderRadius = 20;
            this.btnRemoveCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemoveCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemoveCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btnRemoveCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveCustomer.ForeColor = System.Drawing.Color.White;
            this.btnRemoveCustomer.Location = new System.Drawing.Point(802, 72);
            this.btnRemoveCustomer.Name = "btnRemoveCustomer";
            this.btnRemoveCustomer.Size = new System.Drawing.Size(72, 53);
            this.btnRemoveCustomer.TabIndex = 5;
            this.btnRemoveCustomer.Text = "Xóa";
            this.btnRemoveCustomer.Click += new System.EventHandler(this.btnRemoveCustomer_Click);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.BackColor = System.Drawing.Color.White;
            this.btnSearchCustomer.BorderColor = System.Drawing.Color.Transparent;
            this.btnSearchCustomer.BorderRadius = 20;
            this.btnSearchCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearchCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearchCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearchCustomer.ForeColor = System.Drawing.Color.White;
            this.btnSearchCustomer.Location = new System.Drawing.Point(648, 72);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(72, 53);
            this.btnSearchCustomer.TabIndex = 4;
            this.btnSearchCustomer.Text = "Lọc";
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            this.btnSearchCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSearchCustomer_KeyDown);
            // 
            // txtSearchNameCustomer
            // 
            this.txtSearchNameCustomer.BackColor = System.Drawing.Color.White;
            this.txtSearchNameCustomer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.txtSearchNameCustomer.BorderRadius = 20;
            this.txtSearchNameCustomer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchNameCustomer.DefaultText = "";
            this.txtSearchNameCustomer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchNameCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchNameCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchNameCustomer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchNameCustomer.FillColor = System.Drawing.SystemColors.Control;
            this.txtSearchNameCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchNameCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchNameCustomer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchNameCustomer.Location = new System.Drawing.Point(43, 77);
            this.txtSearchNameCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchNameCustomer.Name = "txtSearchNameCustomer";
            this.txtSearchNameCustomer.PlaceholderText = "Nhập tên hoặc mã.....";
            this.txtSearchNameCustomer.SelectedText = "";
            this.txtSearchNameCustomer.Size = new System.Drawing.Size(598, 48);
            this.txtSearchNameCustomer.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(49, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Từ khóa:";
            // 
            // pnHeaderCustomer
            // 
            this.pnHeaderCustomer.BorderRadius = 20;
            this.pnHeaderCustomer.Controls.Add(this.label1);
            this.pnHeaderCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeaderCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(116)))), ((int)(((byte)(240)))));
            this.pnHeaderCustomer.Location = new System.Drawing.Point(0, 0);
            this.pnHeaderCustomer.Name = "pnHeaderCustomer";
            this.pnHeaderCustomer.Size = new System.Drawing.Size(925, 64);
            this.pnHeaderCustomer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ KHÁCH HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnCustomer);
            this.Name = "ucCustomer";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(935, 725);
            this.Load += new System.EventHandler(this.ucCustomer_Load);
            this.pnCustomer.ResumeLayout(false);
            this.guna2Panel5.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCustomer)).EndInit();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel8.ResumeLayout(false);
            this.guna2Panel8.PerformLayout();
            this.guna2Panel7.ResumeLayout(false);
            this.guna2Panel7.PerformLayout();
            this.guna2Panel6.ResumeLayout(false);
            this.guna2Panel6.PerformLayout();
            this.pnSearchCustomer.ResumeLayout(false);
            this.grbSearchProduct.ResumeLayout(false);
            this.grbSearchProduct.PerformLayout();
            this.pnHeaderCustomer.ResumeLayout(false);
            this.pnHeaderCustomer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnCustomer;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel pnSearchCustomer;
        private Guna.UI2.WinForms.Guna2Panel pnHeaderCustomer;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox grbSearchProduct;
        private Guna.UI2.WinForms.Guna2Button btnSearchCustomer;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchNameCustomer;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel8;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel7;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel6;
        private System.Windows.Forms.Label lblTotalCustomer;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label lblReturnCustomer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNewCustomer;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListCustomer;
        private Guna.UI2.WinForms.Guna2Button btnEditCustomer;
        private Guna.UI2.WinForms.Guna2Button btnRemoveCustomer;
    }
}
