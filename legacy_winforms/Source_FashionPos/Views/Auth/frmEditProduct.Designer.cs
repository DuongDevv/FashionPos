namespace WindowsFormsApp1.Views.Auth
{
    partial class frmEditProduct
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtProductDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picProductAvatar = new Guna.UI2.WinForms.Guna2PictureBox();
            this.cboProductCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpProductDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtProductSellingPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtProductName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtProductID = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSaveProduct = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelProduct = new Guna.UI2.WinForms.Guna2Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnUploadProductAvatar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.picProductAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.BorderColor = System.Drawing.Color.DarkGray;
            this.txtProductDescription.BorderRadius = 20;
            this.txtProductDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductDescription.DefaultText = "";
            this.txtProductDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProductDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductDescription.Location = new System.Drawing.Point(416, 523);
            this.txtProductDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.PlaceholderText = "";
            this.txtProductDescription.SelectedText = "";
            this.txtProductDescription.Size = new System.Drawing.Size(497, 61);
            this.txtProductDescription.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(412, 496);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 23);
            this.label5.TabIndex = 94;
            this.label5.Text = "MÔ TẢ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(15, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 23);
            this.label1.TabIndex = 93;
            this.label1.Text = "ẢNH MINH HỌA";
            // 
            // picProductAvatar
            // 
            this.picProductAvatar.BackColor = System.Drawing.Color.Silver;
            this.picProductAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProductAvatar.FillColor = System.Drawing.Color.DimGray;
            this.picProductAvatar.ImageRotate = 0F;
            this.picProductAvatar.Location = new System.Drawing.Point(19, 131);
            this.picProductAvatar.Name = "picProductAvatar";
            this.picProductAvatar.Size = new System.Drawing.Size(376, 412);
            this.picProductAvatar.TabIndex = 92;
            this.picProductAvatar.TabStop = false;
            // 
            // cboProductCategory
            // 
            this.cboProductCategory.BackColor = System.Drawing.Color.Transparent;
            this.cboProductCategory.BorderColor = System.Drawing.Color.DarkGray;
            this.cboProductCategory.BorderRadius = 10;
            this.cboProductCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboProductCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboProductCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboProductCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboProductCategory.ItemHeight = 30;
            this.cboProductCategory.Location = new System.Drawing.Point(654, 131);
            this.cboProductCategory.Name = "cboProductCategory";
            this.cboProductCategory.Size = new System.Drawing.Size(217, 36);
            this.cboProductCategory.TabIndex = 91;
            // 
            // dtpProductDate
            // 
            this.dtpProductDate.BorderColor = System.Drawing.Color.DarkGray;
            this.dtpProductDate.BorderRadius = 20;
            this.dtpProductDate.BorderThickness = 1;
            this.dtpProductDate.Checked = true;
            this.dtpProductDate.FillColor = System.Drawing.Color.White;
            this.dtpProductDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpProductDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpProductDate.Location = new System.Drawing.Point(419, 427);
            this.dtpProductDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpProductDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpProductDate.Name = "dtpProductDate";
            this.dtpProductDate.Size = new System.Drawing.Size(347, 63);
            this.dtpProductDate.TabIndex = 90;
            this.dtpProductDate.Value = new System.DateTime(2026, 4, 25, 22, 27, 26, 595);
            // 
            // txtProductSellingPrice
            // 
            this.txtProductSellingPrice.BorderColor = System.Drawing.Color.DarkGray;
            this.txtProductSellingPrice.BorderRadius = 20;
            this.txtProductSellingPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductSellingPrice.DefaultText = "";
            this.txtProductSellingPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductSellingPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductSellingPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductSellingPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductSellingPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductSellingPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProductSellingPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductSellingPrice.Location = new System.Drawing.Point(419, 327);
            this.txtProductSellingPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductSellingPrice.Name = "txtProductSellingPrice";
            this.txtProductSellingPrice.PlaceholderText = "";
            this.txtProductSellingPrice.SelectedText = "";
            this.txtProductSellingPrice.Size = new System.Drawing.Size(281, 61);
            this.txtProductSellingPrice.TabIndex = 88;
            this.txtProductSellingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductSellingPrice_KeyPress);
            // 
            // txtProductName
            // 
            this.txtProductName.BorderColor = System.Drawing.Color.DarkGray;
            this.txtProductName.BorderRadius = 20;
            this.txtProductName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductName.DefaultText = "";
            this.txtProductName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProductName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductName.Location = new System.Drawing.Point(419, 230);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.PlaceholderText = "";
            this.txtProductName.SelectedText = "";
            this.txtProductName.Size = new System.Drawing.Size(446, 61);
            this.txtProductName.TabIndex = 87;
            // 
            // txtProductID
            // 
            this.txtProductID.BorderColor = System.Drawing.Color.DarkGray;
            this.txtProductID.BorderRadius = 20;
            this.txtProductID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductID.DefaultText = "";
            this.txtProductID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProductID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductID.Location = new System.Drawing.Point(416, 131);
            this.txtProductID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.PlaceholderText = "";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.SelectedText = "";
            this.txtProductID.Size = new System.Drawing.Size(229, 61);
            this.txtProductID.TabIndex = 86;
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.BorderRadius = 20;
            this.btnSaveProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveProduct.FillColor = System.Drawing.Color.Black;
            this.btnSaveProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProduct.ForeColor = System.Drawing.Color.White;
            this.btnSaveProduct.Location = new System.Drawing.Point(782, 611);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(122, 66);
            this.btnSaveProduct.TabIndex = 85;
            this.btnSaveProduct.Text = "LƯU";
            this.btnSaveProduct.Click += new System.EventHandler(this.btnSaveProduct_Click);
            // 
            // btnCancelProduct
            // 
            this.btnCancelProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelProduct.FillColor = System.Drawing.Color.White;
            this.btnCancelProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelProduct.ForeColor = System.Drawing.Color.Gray;
            this.btnCancelProduct.Location = new System.Drawing.Point(654, 611);
            this.btnCancelProduct.Name = "btnCancelProduct";
            this.btnCancelProduct.Size = new System.Drawing.Size(122, 66);
            this.btnCancelProduct.TabIndex = 84;
            this.btnCancelProduct.Text = "HỦY BỎ";
            this.btnCancelProduct.Click += new System.EventHandler(this.btnCancelProduct_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.DimGray;
            this.lblUserName.Location = new System.Drawing.Point(415, 300);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(80, 23);
            this.lblUserName.TabIndex = 82;
            this.lblUserName.Text = "GIÁ BÁN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(650, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 23);
            this.label7.TabIndex = 81;
            this.label7.Text = "DANH MỤC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(409, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 23);
            this.label6.TabIndex = 80;
            this.label6.Text = " NGÀY TẠO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(415, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 23);
            this.label4.TabIndex = 79;
            this.label4.Text = "TÊN SẢN PHẨM*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(415, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 23);
            this.label3.TabIndex = 78;
            this.label3.Text = "MÃ SP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(348, 25);
            this.label2.TabIndex = 77;
            this.label2.Text = "Vui lòng điền đầy đủ thông tin bên dưới";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(15, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(331, 38);
            this.lblTitle.TabIndex = 76;
            this.lblTitle.Text = "THÔNG TIN SẢN PHẨM";
            // 
            // btnUploadProductAvatar
            // 
            this.btnUploadProductAvatar.BorderRadius = 20;
            this.btnUploadProductAvatar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUploadProductAvatar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUploadProductAvatar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUploadProductAvatar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUploadProductAvatar.FillColor = System.Drawing.Color.Black;
            this.btnUploadProductAvatar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadProductAvatar.ForeColor = System.Drawing.Color.White;
            this.btnUploadProductAvatar.Location = new System.Drawing.Point(156, 549);
            this.btnUploadProductAvatar.Name = "btnUploadProductAvatar";
            this.btnUploadProductAvatar.Size = new System.Drawing.Size(97, 35);
            this.btnUploadProductAvatar.TabIndex = 100;
            this.btnUploadProductAvatar.Text = "TẢI ẢNH";
            this.btnUploadProductAvatar.Click += new System.EventHandler(this.btnUploadProductAvatar_Click);
            // 
            // frmEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(930, 683);
            this.Controls.Add(this.btnUploadProductAvatar);
            this.Controls.Add(this.txtProductDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picProductAvatar);
            this.Controls.Add(this.cboProductCategory);
            this.Controls.Add(this.dtpProductDate);
            this.Controls.Add(this.txtProductSellingPrice);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.btnSaveProduct);
            this.Controls.Add(this.btnCancelProduct);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditProduct";
            this.Text = "frmEditProduct";
            this.Load += new System.EventHandler(this.frmEditProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picProductAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtProductDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox picProductAvatar;
        private Guna.UI2.WinForms.Guna2ComboBox cboProductCategory;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpProductDate;
        private Guna.UI2.WinForms.Guna2TextBox txtProductSellingPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtProductName;
        private Guna.UI2.WinForms.Guna2TextBox txtProductID;
        private Guna.UI2.WinForms.Guna2Button btnSaveProduct;
        private Guna.UI2.WinForms.Guna2Button btnCancelProduct;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnUploadProductAvatar;
    }
}