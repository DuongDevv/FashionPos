namespace WindowsFormsApp1.UserControls
{
    partial class ucSell
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnSellSearchProduct = new Guna.UI2.WinForms.Guna2Panel();
            this.btnResertSearchBar = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSearchSize = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSearchColor = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSearchProductTypeSell = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchNameProductSell = new Guna.UI2.WinForms.Guna2TextBox();
            this.flpProductList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnSell = new Guna.UI2.WinForms.Guna2Panel();
            this.pnPayment = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvListItems = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colProdutNameSell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinusProductSell = new System.Windows.Forms.DataGridViewImageColumn();
            this.colProductQuanlitySell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlusProductSell = new System.Windows.Forms.DataGridViewImageColumn();
            this.colProductPriceSell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemoveProductSell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnTotalPrice = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProductDiscountPay = new System.Windows.Forms.Label();
            this.lblProductPricePay = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.lblTotalPriceProduct = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnCustomerInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPickCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.lblPoint = new System.Windows.Forms.Label();
            this.picCustomerAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnSellSearchProduct.SuspendLayout();
            this.pnSell.SuspendLayout();
            this.pnPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).BeginInit();
            this.pnTotalPrice.SuspendLayout();
            this.pnCustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomerAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnSellSearchProduct
            // 
            this.pnSellSearchProduct.BackColor = System.Drawing.Color.Transparent;
            this.pnSellSearchProduct.BorderRadius = 15;
            this.pnSellSearchProduct.Controls.Add(this.btnResertSearchBar);
            this.pnSellSearchProduct.Controls.Add(this.label5);
            this.pnSellSearchProduct.Controls.Add(this.cboSearchSize);
            this.pnSellSearchProduct.Controls.Add(this.label4);
            this.pnSellSearchProduct.Controls.Add(this.cboSearchColor);
            this.pnSellSearchProduct.Controls.Add(this.label2);
            this.pnSellSearchProduct.Controls.Add(this.cboSearchProductTypeSell);
            this.pnSellSearchProduct.Controls.Add(this.label1);
            this.pnSellSearchProduct.Controls.Add(this.txtSearchNameProductSell);
            this.pnSellSearchProduct.CustomizableEdges.TopLeft = false;
            this.pnSellSearchProduct.CustomizableEdges.TopRight = false;
            this.pnSellSearchProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnSellSearchProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(116)))), ((int)(((byte)(240)))));
            this.pnSellSearchProduct.Location = new System.Drawing.Point(0, 0);
            this.pnSellSearchProduct.Name = "pnSellSearchProduct";
            this.pnSellSearchProduct.Size = new System.Drawing.Size(1124, 100);
            this.pnSellSearchProduct.TabIndex = 0;
            // 
            // btnResertSearchBar
            // 
            this.btnResertSearchBar.BorderRadius = 15;
            this.btnResertSearchBar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResertSearchBar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResertSearchBar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResertSearchBar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResertSearchBar.FillColor = System.Drawing.Color.Yellow;
            this.btnResertSearchBar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResertSearchBar.ForeColor = System.Drawing.Color.Black;
            this.btnResertSearchBar.Location = new System.Drawing.Point(1015, 31);
            this.btnResertSearchBar.Name = "btnResertSearchBar";
            this.btnResertSearchBar.Size = new System.Drawing.Size(78, 45);
            this.btnResertSearchBar.TabIndex = 7;
            this.btnResertSearchBar.Text = "Reset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(924, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "kích cỡ:";
            // 
            // cboSearchSize
            // 
            this.cboSearchSize.BackColor = System.Drawing.Color.Transparent;
            this.cboSearchSize.BorderRadius = 15;
            this.cboSearchSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSearchSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchSize.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSearchSize.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSearchSize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSearchSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSearchSize.ItemHeight = 30;
            this.cboSearchSize.Location = new System.Drawing.Point(927, 40);
            this.cboSearchSize.Name = "cboSearchSize";
            this.cboSearchSize.Size = new System.Drawing.Size(81, 36);
            this.cboSearchSize.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(812, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Màu sắc:";
            // 
            // cboSearchColor
            // 
            this.cboSearchColor.BackColor = System.Drawing.Color.Transparent;
            this.cboSearchColor.BorderRadius = 15;
            this.cboSearchColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSearchColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchColor.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSearchColor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSearchColor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSearchColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSearchColor.ItemHeight = 30;
            this.cboSearchColor.Location = new System.Drawing.Point(815, 40);
            this.cboSearchColor.Name = "cboSearchColor";
            this.cboSearchColor.Size = new System.Drawing.Size(106, 36);
            this.cboSearchColor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(645, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Danh mục:";
            // 
            // cboSearchProductTypeSell
            // 
            this.cboSearchProductTypeSell.BackColor = System.Drawing.Color.Transparent;
            this.cboSearchProductTypeSell.BorderRadius = 15;
            this.cboSearchProductTypeSell.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSearchProductTypeSell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchProductTypeSell.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSearchProductTypeSell.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSearchProductTypeSell.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSearchProductTypeSell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSearchProductTypeSell.ItemHeight = 30;
            this.cboSearchProductTypeSell.Location = new System.Drawing.Point(648, 40);
            this.cboSearchProductTypeSell.Name = "cboSearchProductTypeSell";
            this.cboSearchProductTypeSell.Size = new System.Drawing.Size(161, 36);
            this.cboSearchProductTypeSell.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(95, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên sản phẩm:";
            // 
            // txtSearchNameProductSell
            // 
            this.txtSearchNameProductSell.BackColor = System.Drawing.Color.Transparent;
            this.txtSearchNameProductSell.BorderRadius = 15;
            this.txtSearchNameProductSell.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchNameProductSell.DefaultText = "";
            this.txtSearchNameProductSell.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchNameProductSell.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchNameProductSell.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchNameProductSell.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchNameProductSell.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchNameProductSell.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchNameProductSell.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchNameProductSell.Location = new System.Drawing.Point(82, 28);
            this.txtSearchNameProductSell.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchNameProductSell.Name = "txtSearchNameProductSell";
            this.txtSearchNameProductSell.PlaceholderText = "";
            this.txtSearchNameProductSell.SelectedText = "";
            this.txtSearchNameProductSell.Size = new System.Drawing.Size(542, 48);
            this.txtSearchNameProductSell.TabIndex = 0;
            // 
            // flpProductList
            // 
            this.flpProductList.AutoScroll = true;
            this.flpProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProductList.Location = new System.Drawing.Point(0, 100);
            this.flpProductList.Name = "flpProductList";
            this.flpProductList.Size = new System.Drawing.Size(754, 659);
            this.flpProductList.TabIndex = 1;
            // 
            // pnSell
            // 
            this.pnSell.Controls.Add(this.flpProductList);
            this.pnSell.Controls.Add(this.pnPayment);
            this.pnSell.Controls.Add(this.pnSellSearchProduct);
            this.pnSell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSell.Location = new System.Drawing.Point(0, 0);
            this.pnSell.Name = "pnSell";
            this.pnSell.Size = new System.Drawing.Size(1124, 759);
            this.pnSell.TabIndex = 0;
            // 
            // pnPayment
            // 
            this.pnPayment.Controls.Add(this.dgvListItems);
            this.pnPayment.Controls.Add(this.pnTotalPrice);
            this.pnPayment.Controls.Add(this.pnCustomerInfo);
            this.pnPayment.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnPayment.FillColor = System.Drawing.Color.White;
            this.pnPayment.Location = new System.Drawing.Point(754, 100);
            this.pnPayment.Name = "pnPayment";
            this.pnPayment.Size = new System.Drawing.Size(370, 659);
            this.pnPayment.TabIndex = 0;
            // 
            // dgvListItems
            // 
            this.dgvListItems.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvListItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListItems.ColumnHeadersHeight = 4;
            this.dgvListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListItems.ColumnHeadersVisible = false;
            this.dgvListItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProdutNameSell,
            this.colMinusProductSell,
            this.colProductQuanlitySell,
            this.colPlusProductSell,
            this.colProductPriceSell,
            this.colRemoveProductSell});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListItems.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvListItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListItems.Location = new System.Drawing.Point(0, 100);
            this.dgvListItems.Name = "dgvListItems";
            this.dgvListItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListItems.RowHeadersVisible = false;
            this.dgvListItems.RowHeadersWidth = 51;
            this.dgvListItems.RowTemplate.Height = 70;
            this.dgvListItems.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvListItems.Size = new System.Drawing.Size(370, 391);
            this.dgvListItems.TabIndex = 0;
            this.dgvListItems.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListItems.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListItems.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListItems.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListItems.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListItems.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListItems.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListItems.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListItems.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListItems.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListItems.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListItems.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListItems.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvListItems.ThemeStyle.ReadOnly = false;
            this.dgvListItems.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListItems.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListItems.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListItems.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListItems.ThemeStyle.RowsStyle.Height = 70;
            this.dgvListItems.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListItems.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colProdutNameSell
            // 
            this.colProdutNameSell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProdutNameSell.FillWeight = 64.93465F;
            this.colProdutNameSell.HeaderText = "Tên sp";
            this.colProdutNameSell.MinimumWidth = 6;
            this.colProdutNameSell.Name = "colProdutNameSell";
            // 
            // colMinusProductSell
            // 
            this.colMinusProductSell.HeaderText = "-";
            this.colMinusProductSell.MinimumWidth = 6;
            this.colMinusProductSell.Name = "colMinusProductSell";
            // 
            // colProductQuanlitySell
            // 
            this.colProductQuanlitySell.FillWeight = 74.63754F;
            this.colProductQuanlitySell.HeaderText = "Số lượng";
            this.colProductQuanlitySell.MinimumWidth = 6;
            this.colProductQuanlitySell.Name = "colProductQuanlitySell";
            // 
            // colPlusProductSell
            // 
            this.colPlusProductSell.HeaderText = "+";
            this.colPlusProductSell.MinimumWidth = 6;
            this.colPlusProductSell.Name = "colPlusProductSell";
            // 
            // colProductPriceSell
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProductPriceSell.DefaultCellStyle = dataGridViewCellStyle3;
            this.colProductPriceSell.FillWeight = 160.4278F;
            this.colProductPriceSell.HeaderText = "Tổng tiền";
            this.colProductPriceSell.MinimumWidth = 6;
            this.colProductPriceSell.Name = "colProductPriceSell";
            // 
            // colRemoveProductSell
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            this.colRemoveProductSell.DefaultCellStyle = dataGridViewCellStyle4;
            this.colRemoveProductSell.HeaderText = "Xóa";
            this.colRemoveProductSell.MinimumWidth = 6;
            this.colRemoveProductSell.Name = "colRemoveProductSell";
            // 
            // pnTotalPrice
            // 
            this.pnTotalPrice.BackColor = System.Drawing.Color.Transparent;
            this.pnTotalPrice.BorderRadius = 15;
            this.pnTotalPrice.Controls.Add(this.lblProductDiscountPay);
            this.pnTotalPrice.Controls.Add(this.lblProductPricePay);
            this.pnTotalPrice.Controls.Add(this.label8);
            this.pnTotalPrice.Controls.Add(this.label7);
            this.pnTotalPrice.Controls.Add(this.btnPay);
            this.pnTotalPrice.Controls.Add(this.lblTotalPriceProduct);
            this.pnTotalPrice.Controls.Add(this.label3);
            this.pnTotalPrice.CustomizableEdges.BottomLeft = false;
            this.pnTotalPrice.CustomizableEdges.BottomRight = false;
            this.pnTotalPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnTotalPrice.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.pnTotalPrice.Location = new System.Drawing.Point(0, 491);
            this.pnTotalPrice.Name = "pnTotalPrice";
            this.pnTotalPrice.Size = new System.Drawing.Size(370, 168);
            this.pnTotalPrice.TabIndex = 1;
            // 
            // lblProductDiscountPay
            // 
            this.lblProductDiscountPay.AutoSize = true;
            this.lblProductDiscountPay.BackColor = System.Drawing.Color.Transparent;
            this.lblProductDiscountPay.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductDiscountPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblProductDiscountPay.Location = new System.Drawing.Point(222, 34);
            this.lblProductDiscountPay.Name = "lblProductDiscountPay";
            this.lblProductDiscountPay.Size = new System.Drawing.Size(40, 17);
            this.lblProductDiscountPay.TabIndex = 8;
            this.lblProductDiscountPay.Text = "Giảm";
            // 
            // lblProductPricePay
            // 
            this.lblProductPricePay.AutoSize = true;
            this.lblProductPricePay.BackColor = System.Drawing.Color.Transparent;
            this.lblProductPricePay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPricePay.ForeColor = System.Drawing.Color.White;
            this.lblProductPricePay.Location = new System.Drawing.Point(221, 3);
            this.lblProductPricePay.Name = "lblProductPricePay";
            this.lblProductPricePay.Size = new System.Drawing.Size(32, 20);
            this.lblProductPricePay.TabIndex = 7;
            this.lblProductPricePay.Text = "Giá";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(27, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Giảm giá:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(27, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tiền hàng:";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Transparent;
            this.btnPay.BorderRadius = 15;
            this.btnPay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(50, 109);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(209, 45);
            this.btnPay.TabIndex = 4;
            this.btnPay.Text = "THANH TOÁN";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // lblTotalPriceProduct
            // 
            this.lblTotalPriceProduct.AutoSize = true;
            this.lblTotalPriceProduct.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPriceProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPriceProduct.ForeColor = System.Drawing.Color.White;
            this.lblTotalPriceProduct.Location = new System.Drawing.Point(219, 68);
            this.lblTotalPriceProduct.Name = "lblTotalPriceProduct";
            this.lblTotalPriceProduct.Size = new System.Drawing.Size(43, 28);
            this.lblTotalPriceProduct.TabIndex = 3;
            this.lblTotalPriceProduct.Text = "Giá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(25, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng tiền:";
            // 
            // pnCustomerInfo
            // 
            this.pnCustomerInfo.Controls.Add(this.btnPickCustomer);
            this.pnCustomerInfo.Controls.Add(this.lblCustomerType);
            this.pnCustomerInfo.Controls.Add(this.lblPoint);
            this.pnCustomerInfo.Controls.Add(this.picCustomerAvatar);
            this.pnCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCustomerInfo.FillColor = System.Drawing.Color.White;
            this.pnCustomerInfo.Location = new System.Drawing.Point(0, 0);
            this.pnCustomerInfo.Margin = new System.Windows.Forms.Padding(10);
            this.pnCustomerInfo.Name = "pnCustomerInfo";
            this.pnCustomerInfo.Size = new System.Drawing.Size(370, 100);
            this.pnCustomerInfo.TabIndex = 0;
            // 
            // btnPickCustomer
            // 
            this.btnPickCustomer.BackColor = System.Drawing.Color.White;
            this.btnPickCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPickCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPickCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPickCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPickCustomer.FillColor = System.Drawing.Color.Transparent;
            this.btnPickCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickCustomer.ForeColor = System.Drawing.Color.Blue;
            this.btnPickCustomer.Location = new System.Drawing.Point(188, 6);
            this.btnPickCustomer.Name = "btnPickCustomer";
            this.btnPickCustomer.Size = new System.Drawing.Size(127, 45);
            this.btnPickCustomer.TabIndex = 3;
            this.btnPickCustomer.Text = "+ Chọn khách";
            this.btnPickCustomer.Click += new System.EventHandler(this.btnPickCustomer_Click);
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.BackColor = System.Drawing.Color.White;
            this.lblCustomerType.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerType.Location = new System.Drawing.Point(88, 24);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(71, 17);
            this.lblCustomerType.TabIndex = 2;
            this.lblCustomerType.Text = "KHÁCH LẺ";
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.BackColor = System.Drawing.Color.Transparent;
            this.lblPoint.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoint.Location = new System.Drawing.Point(88, 50);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(89, 15);
            this.lblPoint.TabIndex = 1;
            this.lblPoint.Text = "Điểm tích lũy: 0";
            // 
            // picCustomerAvatar
            // 
            this.picCustomerAvatar.BackColor = System.Drawing.Color.White;
            this.picCustomerAvatar.FillColor = System.Drawing.Color.Black;
            this.picCustomerAvatar.ImageRotate = 0F;
            this.picCustomerAvatar.Location = new System.Drawing.Point(30, 16);
            this.picCustomerAvatar.Name = "picCustomerAvatar";
            this.picCustomerAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picCustomerAvatar.Size = new System.Drawing.Size(48, 50);
            this.picCustomerAvatar.TabIndex = 0;
            this.picCustomerAvatar.TabStop = false;
            // 
            // ucSell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnSell);
            this.Name = "ucSell";
            this.Size = new System.Drawing.Size(1124, 759);
            this.Load += new System.EventHandler(this.ucSell_Load);
            this.pnSellSearchProduct.ResumeLayout(false);
            this.pnSellSearchProduct.PerformLayout();
            this.pnSell.ResumeLayout(false);
            this.pnPayment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).EndInit();
            this.pnTotalPrice.ResumeLayout(false);
            this.pnTotalPrice.PerformLayout();
            this.pnCustomerInfo.ResumeLayout(false);
            this.pnCustomerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomerAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnSellSearchProduct;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchNameProductSell;
        private Guna.UI2.WinForms.Guna2ComboBox cboSearchProductTypeSell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpProductList;
        private Guna.UI2.WinForms.Guna2Panel pnSell;
        private Guna.UI2.WinForms.Guna2Panel pnPayment;
        private Guna.UI2.WinForms.Guna2Panel pnCustomerInfo;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListItems;
        private Guna.UI2.WinForms.Guna2Panel pnTotalPrice;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnPay;
        private System.Windows.Forms.Label lblTotalPriceProduct;
        private Guna.UI2.WinForms.Guna2Button btnPickCustomer;
        private System.Windows.Forms.Label lblCustomerType;
        private System.Windows.Forms.Label lblPoint;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picCustomerAvatar;
        private System.Windows.Forms.Label lblProductDiscountPay;
        private System.Windows.Forms.Label lblProductPricePay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdutNameSell;
        private System.Windows.Forms.DataGridViewImageColumn colMinusProductSell;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductQuanlitySell;
        private System.Windows.Forms.DataGridViewImageColumn colPlusProductSell;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductPriceSell;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemoveProductSell;
        private Guna.UI2.WinForms.Guna2Button btnResertSearchBar;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cboSearchSize;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cboSearchColor;
    }
}
