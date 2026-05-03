namespace WindowsFormsApp1.UserControls
{
    partial class ucSupplier
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
            this.pnSupplier = new Guna.UI2.WinForms.Guna2Panel();
            this.pnSupplierDetail = new Guna.UI2.WinForms.Guna2Panel();
            this.pnListSupplier = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvListSupplier = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnEditSupplier = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRemoveSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.pnHeaderSupplier = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnSupplier.SuspendLayout();
            this.pnSupplierDetail.SuspendLayout();
            this.pnListSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListSupplier)).BeginInit();
            this.pnEditSupplier.SuspendLayout();
            this.pnHeaderSupplier.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSupplier
            // 
            this.pnSupplier.Controls.Add(this.pnSupplierDetail);
            this.pnSupplier.Controls.Add(this.pnHeaderSupplier);
            this.pnSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSupplier.Location = new System.Drawing.Point(0, 0);
            this.pnSupplier.Name = "pnSupplier";
            this.pnSupplier.Size = new System.Drawing.Size(1045, 680);
            this.pnSupplier.TabIndex = 3;
            // 
            // pnSupplierDetail
            // 
            this.pnSupplierDetail.Controls.Add(this.pnListSupplier);
            this.pnSupplierDetail.Controls.Add(this.pnEditSupplier);
            this.pnSupplierDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSupplierDetail.Location = new System.Drawing.Point(0, 64);
            this.pnSupplierDetail.Margin = new System.Windows.Forms.Padding(10);
            this.pnSupplierDetail.Name = "pnSupplierDetail";
            this.pnSupplierDetail.Padding = new System.Windows.Forms.Padding(10);
            this.pnSupplierDetail.Size = new System.Drawing.Size(1045, 616);
            this.pnSupplierDetail.TabIndex = 4;
            // 
            // pnListSupplier
            // 
            this.pnListSupplier.Controls.Add(this.dgvListSupplier);
            this.pnListSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnListSupplier.FillColor = System.Drawing.Color.White;
            this.pnListSupplier.Location = new System.Drawing.Point(10, 82);
            this.pnListSupplier.Name = "pnListSupplier";
            this.pnListSupplier.Size = new System.Drawing.Size(1025, 524);
            this.pnListSupplier.TabIndex = 1;
            // 
            // dgvListSupplier
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvListSupplier.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListSupplier.ColumnHeadersHeight = 4;
            this.dgvListSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListSupplier.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListSupplier.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListSupplier.Location = new System.Drawing.Point(0, 0);
            this.dgvListSupplier.Name = "dgvListSupplier";
            this.dgvListSupplier.RowHeadersVisible = false;
            this.dgvListSupplier.RowHeadersWidth = 51;
            this.dgvListSupplier.RowTemplate.Height = 24;
            this.dgvListSupplier.Size = new System.Drawing.Size(1025, 524);
            this.dgvListSupplier.TabIndex = 0;
            this.dgvListSupplier.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListSupplier.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListSupplier.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListSupplier.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListSupplier.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListSupplier.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListSupplier.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListSupplier.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListSupplier.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListSupplier.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListSupplier.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListSupplier.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListSupplier.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvListSupplier.ThemeStyle.ReadOnly = false;
            this.dgvListSupplier.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListSupplier.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListSupplier.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListSupplier.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListSupplier.ThemeStyle.RowsStyle.Height = 24;
            this.dgvListSupplier.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListSupplier.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListSupplier_CellDoubleClick);
            // 
            // pnEditSupplier
            // 
            this.pnEditSupplier.BackColor = System.Drawing.Color.Transparent;
            this.pnEditSupplier.Controls.Add(this.btnRemoveSupplier);
            this.pnEditSupplier.Controls.Add(this.btnEditSupplier);
            this.pnEditSupplier.Controls.Add(this.btnAddSupplier);
            this.pnEditSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnEditSupplier.FillColor = System.Drawing.Color.White;
            this.pnEditSupplier.Location = new System.Drawing.Point(10, 10);
            this.pnEditSupplier.Name = "pnEditSupplier";
            this.pnEditSupplier.Size = new System.Drawing.Size(1025, 72);
            this.pnEditSupplier.TabIndex = 0;
            // 
            // btnRemoveSupplier
            // 
            this.btnRemoveSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRemoveSupplier.BorderRadius = 10;
            this.btnRemoveSupplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveSupplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemoveSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemoveSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btnRemoveSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveSupplier.ForeColor = System.Drawing.Color.White;
            this.btnRemoveSupplier.Location = new System.Drawing.Point(208, 14);
            this.btnRemoveSupplier.Name = "btnRemoveSupplier";
            this.btnRemoveSupplier.Size = new System.Drawing.Size(79, 45);
            this.btnRemoveSupplier.TabIndex = 5;
            this.btnRemoveSupplier.Text = "Xóa";
            this.btnRemoveSupplier.Click += new System.EventHandler(this.btnRemoveSupplier_Click);
            // 
            // btnEditSupplier
            // 
            this.btnEditSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEditSupplier.BorderRadius = 10;
            this.btnEditSupplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditSupplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditSupplier.ForeColor = System.Drawing.Color.White;
            this.btnEditSupplier.Location = new System.Drawing.Point(123, 14);
            this.btnEditSupplier.Name = "btnEditSupplier";
            this.btnEditSupplier.Size = new System.Drawing.Size(79, 45);
            this.btnEditSupplier.TabIndex = 4;
            this.btnEditSupplier.Text = "Sửa";
            this.btnEditSupplier.Click += new System.EventHandler(this.btnEditSupplier_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddSupplier.BorderRadius = 10;
            this.btnAddSupplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddSupplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btnAddSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddSupplier.ForeColor = System.Drawing.Color.White;
            this.btnAddSupplier.Location = new System.Drawing.Point(23, 14);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(91, 45);
            this.btnAddSupplier.TabIndex = 3;
            this.btnAddSupplier.Text = "Thêm";
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // pnHeaderSupplier
            // 
            this.pnHeaderSupplier.Controls.Add(this.label1);
            this.pnHeaderSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeaderSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(116)))), ((int)(((byte)(240)))));
            this.pnHeaderSupplier.Location = new System.Drawing.Point(0, 0);
            this.pnHeaderSupplier.Margin = new System.Windows.Forms.Padding(10);
            this.pnHeaderSupplier.Name = "pnHeaderSupplier";
            this.pnHeaderSupplier.Padding = new System.Windows.Forms.Padding(10);
            this.pnHeaderSupplier.Size = new System.Drawing.Size(1045, 64);
            this.pnHeaderSupplier.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnSupplier);
            this.Name = "ucSupplier";
            this.Size = new System.Drawing.Size(1045, 680);
            this.Load += new System.EventHandler(this.ucSupplier_Load);
            this.pnSupplier.ResumeLayout(false);
            this.pnSupplierDetail.ResumeLayout(false);
            this.pnListSupplier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListSupplier)).EndInit();
            this.pnEditSupplier.ResumeLayout(false);
            this.pnHeaderSupplier.ResumeLayout(false);
            this.pnHeaderSupplier.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnSupplier;
        private Guna.UI2.WinForms.Guna2Panel pnHeaderSupplier;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel pnSupplierDetail;
        private Guna.UI2.WinForms.Guna2Panel pnListSupplier;
        private Guna.UI2.WinForms.Guna2Panel pnEditSupplier;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListSupplier;
        private Guna.UI2.WinForms.Guna2Button btnRemoveSupplier;
        private Guna.UI2.WinForms.Guna2Button btnEditSupplier;
        private Guna.UI2.WinForms.Guna2Button btnAddSupplier;
    }
}
