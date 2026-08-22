namespace WindowsFormsApp1.Views.Auth
{
    partial class frmInputQuantity
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
            this.txtInputQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtInputPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelInput = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveInput = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // txtInputQuantity
            // 
            this.txtInputQuantity.BorderColor = System.Drawing.Color.DimGray;
            this.txtInputQuantity.BorderRadius = 20;
            this.txtInputQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInputQuantity.DefaultText = "";
            this.txtInputQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtInputQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtInputQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInputQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInputQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInputQuantity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInputQuantity.Location = new System.Drawing.Point(30, 65);
            this.txtInputQuantity.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtInputQuantity.Name = "txtInputQuantity";
            this.txtInputQuantity.PlaceholderText = "Nhập số lượng...";
            this.txtInputQuantity.SelectedText = "";
            this.txtInputQuantity.Size = new System.Drawing.Size(286, 69);
            this.txtInputQuantity.TabIndex = 0;
            this.txtInputQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputQuantity_KeyDown);
            this.txtInputQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputQuantity_KeyPress);
            // 
            // txtInputPrice
            // 
            this.txtInputPrice.BorderColor = System.Drawing.Color.DimGray;
            this.txtInputPrice.BorderRadius = 20;
            this.txtInputPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInputPrice.DefaultText = "";
            this.txtInputPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtInputPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtInputPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInputPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInputPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInputPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInputPrice.Location = new System.Drawing.Point(30, 168);
            this.txtInputPrice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtInputPrice.Name = "txtInputPrice";
            this.txtInputPrice.PlaceholderText = "Nhập số lượng...";
            this.txtInputPrice.SelectedText = "";
            this.txtInputPrice.Size = new System.Drawing.Size(286, 69);
            this.txtInputPrice.TabIndex = 1;
            this.txtInputPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputPrice_KeyDown);
            this.txtInputPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputPrice_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "SỐ LƯỢNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "ĐƠN GIÁ";
            // 
            // btnCancelInput
            // 
            this.btnCancelInput.BorderRadius = 25;
            this.btnCancelInput.BorderThickness = 1;
            this.btnCancelInput.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelInput.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelInput.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelInput.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelInput.FillColor = System.Drawing.Color.White;
            this.btnCancelInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelInput.ForeColor = System.Drawing.Color.DarkGray;
            this.btnCancelInput.Location = new System.Drawing.Point(36, 276);
            this.btnCancelInput.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelInput.Name = "btnCancelInput";
            this.btnCancelInput.Size = new System.Drawing.Size(114, 65);
            this.btnCancelInput.TabIndex = 4;
            this.btnCancelInput.Text = "HỦY";
            this.btnCancelInput.Click += new System.EventHandler(this.btnCancelInput_Click);
            // 
            // btnSaveInput
            // 
            this.btnSaveInput.BorderRadius = 25;
            this.btnSaveInput.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveInput.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveInput.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveInput.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveInput.FillColor = System.Drawing.Color.Black;
            this.btnSaveInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveInput.ForeColor = System.Drawing.Color.White;
            this.btnSaveInput.Location = new System.Drawing.Point(174, 276);
            this.btnSaveInput.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveInput.Name = "btnSaveInput";
            this.btnSaveInput.Size = new System.Drawing.Size(114, 65);
            this.btnSaveInput.TabIndex = 5;
            this.btnSaveInput.Text = "LƯU";
            this.btnSaveInput.Click += new System.EventHandler(this.btnSaveInput_Click);
            // 
            // frmInputQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(342, 384);
            this.Controls.Add(this.btnSaveInput);
            this.Controls.Add(this.btnCancelInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInputPrice);
            this.Controls.Add(this.txtInputQuantity);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInputQuantity";
            this.Text = "frmInputQuantity";
            this.Load += new System.EventHandler(this.frmInputQuantity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtInputQuantity;
        private Guna.UI2.WinForms.Guna2TextBox txtInputPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnCancelInput;
        private Guna.UI2.WinForms.Guna2Button btnSaveInput;
    }
}