namespace WindowsFormsApp1.Views.Auth
{
    partial class frmPickCustomer
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearchByPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddNewCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.pnlResult = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.picCustomerAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomerAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(265, 38);
            this.lblTitle.TabIndex = 25;
            this.lblTitle.Text = "TÌM KHÁCH HÀNG";
            // 
            // txtSearchByPhone
            // 
            this.txtSearchByPhone.BorderRadius = 15;
            this.txtSearchByPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchByPhone.DefaultText = "";
            this.txtSearchByPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchByPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchByPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchByPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchByPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchByPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchByPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchByPhone.Location = new System.Drawing.Point(19, 81);
            this.txtSearchByPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchByPhone.Name = "txtSearchByPhone";
            this.txtSearchByPhone.PlaceholderText = "";
            this.txtSearchByPhone.SelectedText = "";
            this.txtSearchByPhone.Size = new System.Drawing.Size(523, 68);
            this.txtSearchByPhone.TabIndex = 26;
            this.txtSearchByPhone.TextChanged += new System.EventHandler(this.txtSearchByPhone_TextChanged);
            this.txtSearchByPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchByPhone_KeyPress);
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddNewCustomer.BorderRadius = 10;
            this.btnAddNewCustomer.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnAddNewCustomer.BorderThickness = 2;
            this.btnAddNewCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewCustomer.FillColor = System.Drawing.Color.White;
            this.btnAddNewCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(116)))), ((int)(((byte)(240)))));
            this.btnAddNewCustomer.Location = new System.Drawing.Point(19, 331);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(523, 45);
            this.btnAddNewCustomer.TabIndex = 27;
            this.btnAddNewCustomer.Text = "+ THÊM MỚI KHÁCH NHANH";
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // pnlResult
            // 
            this.pnlResult.BackColor = System.Drawing.Color.Transparent;
            this.pnlResult.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.pnlResult.BorderRadius = 20;
            this.pnlResult.BorderThickness = 1;
            this.pnlResult.Controls.Add(this.lblCustomerPhone);
            this.pnlResult.Controls.Add(this.lblCustomerName);
            this.pnlResult.Controls.Add(this.picCustomerAvatar);
            this.pnlResult.Location = new System.Drawing.Point(19, 183);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.pnlResult.Size = new System.Drawing.Size(523, 103);
            this.pnlResult.TabIndex = 28;
            this.pnlResult.Click += new System.EventHandler(this.pnlResult_Click);
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerPhone.ForeColor = System.Drawing.Color.Silver;
            this.lblCustomerPhone.Location = new System.Drawing.Point(104, 55);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(111, 17);
            this.lblCustomerPhone.TabIndex = 2;
            this.lblCustomerPhone.Text = "SĐT: 0912345678";
            this.lblCustomerPhone.Click += new System.EventHandler(this.lblCustomerPhone_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(102, 30);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(63, 25);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "label1";
            this.lblCustomerName.Click += new System.EventHandler(this.lblCustomerName_Click);
            // 
            // picCustomerAvatar
            // 
            this.picCustomerAvatar.FillColor = System.Drawing.SystemColors.WindowFrame;
            this.picCustomerAvatar.ImageRotate = 0F;
            this.picCustomerAvatar.Location = new System.Drawing.Point(27, 18);
            this.picCustomerAvatar.Name = "picCustomerAvatar";
            this.picCustomerAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picCustomerAvatar.Size = new System.Drawing.Size(64, 64);
            this.picCustomerAvatar.TabIndex = 0;
            this.picCustomerAvatar.TabStop = false;
            // 
            // frmPickCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(575, 403);
            this.Controls.Add(this.pnlResult);
            this.Controls.Add(this.btnAddNewCustomer);
            this.Controls.Add(this.txtSearchByPhone);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPickCustomer";
            this.Text = "frmPickCustomer";
            this.Load += new System.EventHandler(this.frmPickCustomer_Load);
            this.pnlResult.ResumeLayout(false);
            this.pnlResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomerAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchByPhone;
        private Guna.UI2.WinForms.Guna2Button btnAddNewCustomer;
        private Guna.UI2.WinForms.Guna2Panel pnlResult;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label lblCustomerName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picCustomerAvatar;
    }
}