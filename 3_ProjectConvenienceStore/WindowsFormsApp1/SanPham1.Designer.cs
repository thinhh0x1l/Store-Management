namespace WindowsFormsApp1
{
    partial class SanPham1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SanPham1));
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblGia = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTenSP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ptbHinhAnh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblSL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Snow;
            this.guna2GradientPanel1.Controls.Add(this.lblSL);
            this.guna2GradientPanel1.Controls.Add(this.lblGia);
            this.guna2GradientPanel1.Controls.Add(this.lblTenSP);
            this.guna2GradientPanel1.Controls.Add(this.ptbHinhAnh);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(104, 166);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // lblGia
            // 
            this.lblGia.BackColor = System.Drawing.Color.Transparent;
            this.lblGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.ForeColor = System.Drawing.Color.Red;
            this.lblGia.Location = new System.Drawing.Point(29, 121);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(38, 18);
            this.lblGia.TabIndex = 2;
            this.lblGia.Text = "12000";
            // 
            // lblTenSP
            // 
            this.lblTenSP.BackColor = System.Drawing.Color.Transparent;
            this.lblTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.Location = new System.Drawing.Point(3, 97);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(97, 18);
            this.lblTenSP.TabIndex = 1;
            this.lblTenSP.Text = "Khoai tây Swing";
            this.lblTenSP.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbHinhAnh
            // 
            this.ptbHinhAnh.Image = ((System.Drawing.Image)(resources.GetObject("ptbHinhAnh.Image")));
            this.ptbHinhAnh.ImageRotate = 0F;
            this.ptbHinhAnh.Location = new System.Drawing.Point(3, 3);
            this.ptbHinhAnh.Name = "ptbHinhAnh";
            this.ptbHinhAnh.Size = new System.Drawing.Size(98, 98);
            this.ptbHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbHinhAnh.TabIndex = 0;
            this.ptbHinhAnh.TabStop = false;
            // 
            // lblSL
            // 
            this.lblSL.BackColor = System.Drawing.Color.Transparent;
            this.lblSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSL.ForeColor = System.Drawing.Color.Gray;
            this.lblSL.Location = new System.Drawing.Point(14, 145);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(21, 17);
            this.lblSL.TabIndex = 3;
            this.lblSL.Text = "SL:";
            // 
            // SanPham1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "SanPham1";
            this.Size = new System.Drawing.Size(104, 166);
            this.Load += new System.EventHandler(this.SanPham1_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHinhAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenSP;
        private Guna.UI2.WinForms.Guna2PictureBox ptbHinhAnh;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGia;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSL;
    }
}
