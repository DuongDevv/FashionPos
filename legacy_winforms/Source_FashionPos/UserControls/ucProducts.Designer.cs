namespace WindowsFormsApp1.UserControls
{
    partial class ucProducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnListProduct = new Guna.UI2.WinForms.Guna2Panel();
            this.grbListProduct = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvListProduct = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnEditProduct = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRemoveProduct = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditProduct = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddProduct = new Guna.UI2.WinForms.Guna2Button();
            this.pnSearchProduct = new Guna.UI2.WinForms.Guna2Panel();
            this.grbSearchProduct = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cboSearchProductSize = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSearchProductColor = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearchProduct = new Guna.UI2.WinForms.Guna2Button();
            this.cboSearchProductType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearchNameProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvListProductVarian = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnListProduct.SuspendLayout();
            this.grbListProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListProduct)).BeginInit();
            this.pnEditProduct.SuspendLayout();
            this.pnSearchProduct.SuspendLayout();
            this.grbSearchProduct.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListProductVarian)).BeginInit();
            this.SuspendLayout();
            // 
            // pnListProduct
            // 
            this.pnListProduct.Controls.Add(this.grbListProduct);
            this.pnListProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnListProduct.Location = new System.Drawing.Point(5, 310);
            this.pnListProduct.Name = "pnListProduct";
            this.pnListProduct.Size = new System.Drawing.Size(1205, 252);
            this.pnListProduct.TabIndex = 3;
            // 
            // grbListProduct
            // 
            this.grbListProduct.BorderRadius = 10;
            this.grbListProduct.Controls.Add(this.dgvListProduct);
            this.grbListProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbListProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbListProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grbListProduct.Location = new System.Drawing.Point(0, 0);
            this.grbListProduct.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.grbListProduct.Name = "grbListProduct";
            this.grbListProduct.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.grbListProduct.Size = new System.Drawing.Size(1205, 252);
            this.grbListProduct.TabIndex = 0;
            this.grbListProduct.Text = "Danh sách sản phẩm";
            // 
            // dgvListProduct
            // 
            this.dgvListProduct.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvListProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListProduct.ColumnHeadersHeight = 4;
            this.dgvListProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListProduct.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListProduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListProduct.Location = new System.Drawing.Point(10, 45);
            this.dgvListProduct.Name = "dgvListProduct";
            this.dgvListProduct.RowHeadersVisible = false;
            this.dgvListProduct.RowHeadersWidth = 51;
            this.dgvListProduct.RowTemplate.Height = 24;
            this.dgvListProduct.Size = new System.Drawing.Size(1185, 202);
            this.dgvListProduct.TabIndex = 0;
            this.dgvListProduct.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListProduct.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListProduct.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListProduct.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListProduct.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListProduct.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListProduct.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListProduct.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListProduct.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListProduct.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvListProduct.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListProduct.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListProduct.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvListProduct.ThemeStyle.ReadOnly = false;
            this.dgvListProduct.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListProduct.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListProduct.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvListProduct.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgvListProduct.ThemeStyle.RowsStyle.Height = 24;
            this.dgvListProduct.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListProduct.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListProduct_CellDoubleClick);
            this.dgvListProduct.SelectionChanged += new System.EventHandler(this.dgvListProduct_SelectionChanged);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.MinimumWidth = 6;
            this.colCheck.Name = "colCheck";
            // 
            // pnEditProduct
            // 
            this.pnEditProduct.BorderRadius = 10;
            this.pnEditProduct.Controls.Add(this.btnRemoveProduct);
            this.pnEditProduct.Controls.Add(this.btnEditProduct);
            this.pnEditProduct.Controls.Add(this.btnAddProduct);
            this.pnEditProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnEditProduct.Location = new System.Drawing.Point(5, 236);
            this.pnEditProduct.Name = "pnEditProduct";
            this.pnEditProduct.Size = new System.Drawing.Size(1205, 74);
            this.pnEditProduct.TabIndex = 2;
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
            this.btnRemoveProduct.Location = new System.Drawing.Point(190, 10);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(79, 45);
            this.btnRemoveProduct.TabIndex = 2;
            this.btnRemoveProduct.Text = "Xóa";
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
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
            this.btnEditProduct.Location = new System.Drawing.Point(105, 10);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(79, 45);
            this.btnEditProduct.TabIndex = 1;
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
            this.btnAddProduct.Location = new System.Drawing.Point(5, 10);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(91, 45);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Thêm";
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // pnSearchProduct
            // 
            this.pnSearchProduct.Controls.Add(this.grbSearchProduct);
            this.pnSearchProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnSearchProduct.Location = new System.Drawing.Point(5, 71);
            this.pnSearchProduct.Name = "pnSearchProduct";
            this.pnSearchProduct.Size = new System.Drawing.Size(1205, 165);
            this.pnSearchProduct.TabIndex = 1;
            // 
            // grbSearchProduct
            // 
            this.grbSearchProduct.BorderRadius = 10;
            this.grbSearchProduct.Controls.Add(this.cboSearchProductSize);
            this.grbSearchProduct.Controls.Add(this.label5);
            this.grbSearchProduct.Controls.Add(this.cboSearchProductColor);
            this.grbSearchProduct.Controls.Add(this.label4);
            this.grbSearchProduct.Controls.Add(this.btnSearchProduct);
            this.grbSearchProduct.Controls.Add(this.cboSearchProductType);
            this.grbSearchProduct.Controls.Add(this.txtSearchNameProduct);
            this.grbSearchProduct.Controls.Add(this.label3);
            this.grbSearchProduct.Controls.Add(this.label2);
            this.grbSearchProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbSearchProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grbSearchProduct.Location = new System.Drawing.Point(0, 0);
            this.grbSearchProduct.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.grbSearchProduct.Name = "grbSearchProduct";
            this.grbSearchProduct.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.grbSearchProduct.Size = new System.Drawing.Size(1205, 165);
            this.grbSearchProduct.TabIndex = 0;
            this.grbSearchProduct.Text = "Tìm kiếm";
            // 
            // cboSearchProductSize
            // 
            this.cboSearchProductSize.BackColor = System.Drawing.Color.Transparent;
            this.cboSearchProductSize.BorderRadius = 19;
            this.cboSearchProductSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSearchProductSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchProductSize.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSearchProductSize.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSearchProductSize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSearchProductSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSearchProductSize.ItemHeight = 30;
            this.cboSearchProductSize.Location = new System.Drawing.Point(676, 89);
            this.cboSearchProductSize.Name = "cboSearchProductSize";
            this.cboSearchProductSize.Size = new System.Drawing.Size(114, 36);
            this.cboSearchProductSize.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(672, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Kích cỡ:";
            // 
            // cboSearchProductColor
            // 
            this.cboSearchProductColor.BackColor = System.Drawing.Color.Transparent;
            this.cboSearchProductColor.BorderRadius = 19;
            this.cboSearchProductColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSearchProductColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchProductColor.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSearchProductColor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSearchProductColor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSearchProductColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSearchProductColor.ItemHeight = 30;
            this.cboSearchProductColor.Location = new System.Drawing.Point(556, 89);
            this.cboSearchProductColor.Name = "cboSearchProductColor";
            this.cboSearchProductColor.Size = new System.Drawing.Size(114, 36);
            this.cboSearchProductColor.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Màu sắc:";
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.BackColor = System.Drawing.Color.White;
            this.btnSearchProduct.BorderColor = System.Drawing.Color.Transparent;
            this.btnSearchProduct.BorderRadius = 20;
            this.btnSearchProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearchProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearchProduct.ForeColor = System.Drawing.Color.White;
            this.btnSearchProduct.Location = new System.Drawing.Point(807, 72);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(72, 53);
            this.btnSearchProduct.TabIndex = 4;
            this.btnSearchProduct.Text = "Lọc";
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // cboSearchProductType
            // 
            this.cboSearchProductType.BackColor = System.Drawing.Color.Transparent;
            this.cboSearchProductType.BorderRadius = 19;
            this.cboSearchProductType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSearchProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchProductType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSearchProductType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSearchProductType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSearchProductType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSearchProductType.ItemHeight = 30;
            this.cboSearchProductType.Location = new System.Drawing.Point(368, 89);
            this.cboSearchProductType.Name = "cboSearchProductType";
            this.cboSearchProductType.Size = new System.Drawing.Size(182, 36);
            this.cboSearchProductType.TabIndex = 3;
            // 
            // txtSearchNameProduct
            // 
            this.txtSearchNameProduct.BackColor = System.Drawing.Color.White;
            this.txtSearchNameProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.txtSearchNameProduct.BorderRadius = 20;
            this.txtSearchNameProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchNameProduct.DefaultText = "";
            this.txtSearchNameProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchNameProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchNameProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchNameProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchNameProduct.FillColor = System.Drawing.SystemColors.Control;
            this.txtSearchNameProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchNameProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchNameProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchNameProduct.Location = new System.Drawing.Point(43, 77);
            this.txtSearchNameProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchNameProduct.Name = "txtSearchNameProduct";
            this.txtSearchNameProduct.PlaceholderText = "Nhập tên hoặc mã.....";
            this.txtSearchNameProduct.SelectedText = "";
            this.txtSearchNameProduct.Size = new System.Drawing.Size(302, 48);
            this.txtSearchNameProduct.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Danh mục:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Từ khóa:";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 5;
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(116)))), ((int)(((byte)(240)))));
            this.guna2Panel1.Location = new System.Drawing.Point(5, 5);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 5;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.Size = new System.Drawing.Size(1205, 66);
            this.guna2Panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ SẢN PHẨM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.guna2GroupBox1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(5, 562);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1205, 266);
            this.guna2Panel2.TabIndex = 1;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.dgvListProductVarian);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1205, 266);
            this.guna2GroupBox1.TabIndex = 0;
            this.guna2GroupBox1.Text = "Danh sách biến thể sản phẩm";
            // 
            // dgvListProductVarian
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvListProductVarian.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListProductVarian.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvListProductVarian.ColumnHeadersHeight = 4;
            this.dgvListProductVarian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListProductVarian.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvListProductVarian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListProductVarian.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListProductVarian.Location = new System.Drawing.Point(0, 40);
            this.dgvListProductVarian.Name = "dgvListProductVarian";
            this.dgvListProductVarian.RowHeadersVisible = false;
            this.dgvListProductVarian.RowHeadersWidth = 51;
            this.dgvListProductVarian.RowTemplate.Height = 24;
            this.dgvListProductVarian.Size = new System.Drawing.Size(1205, 226);
            this.dgvListProductVarian.TabIndex = 0;
            this.dgvListProductVarian.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListProductVarian.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListProductVarian.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListProductVarian.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListProductVarian.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListProductVarian.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListProductVarian.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListProductVarian.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListProductVarian.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListProductVarian.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvListProductVarian.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListProductVarian.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListProductVarian.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvListProductVarian.ThemeStyle.ReadOnly = false;
            this.dgvListProductVarian.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListProductVarian.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListProductVarian.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvListProductVarian.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgvListProductVarian.ThemeStyle.RowsStyle.Height = 24;
            this.dgvListProductVarian.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListProductVarian.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListProductVarian.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListProductVarian_CellDoubleClick);
            // 
            // ucProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.pnListProduct);
            this.Controls.Add(this.pnEditProduct);
            this.Controls.Add(this.pnSearchProduct);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucProducts";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1215, 833);
            this.Load += new System.EventHandler(this.ucProducts_Load);
            this.pnListProduct.ResumeLayout(false);
            this.grbListProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListProduct)).EndInit();
            this.pnEditProduct.ResumeLayout(false);
            this.pnSearchProduct.ResumeLayout(false);
            this.grbSearchProduct.ResumeLayout(false);
            this.grbSearchProduct.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListProductVarian)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel pnSearchProduct;
        private Guna.UI2.WinForms.Guna2Panel pnEditProduct;
        private Guna.UI2.WinForms.Guna2GroupBox grbSearchProduct;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchNameProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnSearchProduct;
        private Guna.UI2.WinForms.Guna2ComboBox cboSearchProductType;
        private Guna.UI2.WinForms.Guna2Button btnRemoveProduct;
        private Guna.UI2.WinForms.Guna2Button btnEditProduct;
        private Guna.UI2.WinForms.Guna2Button btnAddProduct;
        private Guna.UI2.WinForms.Guna2Panel pnListProduct;
        private Guna.UI2.WinForms.Guna2GroupBox grbListProduct;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListProduct;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private Guna.UI2.WinForms.Guna2ComboBox cboSearchProductColor;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cboSearchProductSize;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListProductVarian;
    }
}
