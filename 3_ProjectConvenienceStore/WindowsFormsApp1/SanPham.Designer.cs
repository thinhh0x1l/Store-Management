namespace WindowsFormsApp1
{
    partial class SanPham
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
            this.lbGia = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.lbTenSP = new System.Windows.Forms.Label();
            this.pnHinhAnh = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lbGia
            // 
            this.lbGia.AutoSize = true;
            this.lbGia.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGia.ForeColor = System.Drawing.Color.Red;
            this.lbGia.Location = new System.Drawing.Point(76, 65);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(43, 16);
            this.lbGia.TabIndex = 15;
            this.lbGia.Text = "$10000";
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbSoLuong.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuong.ForeColor = System.Drawing.Color.MediumBlue;
            this.lbSoLuong.Location = new System.Drawing.Point(76, 44);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(22, 17);
            this.lbSoLuong.TabIndex = 14;
            this.lbSoLuong.Text = "40";
            this.lbSoLuong.Click += new System.EventHandler(this.lbSoLuong_Click);
            // 
            // lbTenSP
            // 
            this.lbTenSP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbTenSP.Location = new System.Drawing.Point(76, 4);
            this.lbTenSP.Name = "lbTenSP";
            this.lbTenSP.Size = new System.Drawing.Size(55, 29);
            this.lbTenSP.TabIndex = 13;
            this.lbTenSP.Text = "label1dfffffffdasdfasdfsadf";
            // 
            // pnHinhAnh
            // 
            this.pnHinhAnh.BackColor = System.Drawing.Color.White;
            this.pnHinhAnh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnHinhAnh.Enabled = false;
            this.pnHinhAnh.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.pnHinhAnh.Location = new System.Drawing.Point(3, 3);
            this.pnHinhAnh.Name = "pnHinhAnh";
            this.pnHinhAnh.Size = new System.Drawing.Size(68, 78);
            this.pnHinhAnh.TabIndex = 12;
            this.pnHinhAnh.Paint += new System.Windows.Forms.PaintEventHandler(this.pnHinhAnh_Paint);
            // 
            // SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbGia);
            this.Controls.Add(this.lbSoLuong);
            this.Controls.Add(this.lbTenSP);
            this.Controls.Add(this.pnHinhAnh);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "SanPham";
            this.Size = new System.Drawing.Size(137, 85);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SanPham_MouseClick);
            this.MouseEnter += new System.EventHandler(this.SanPham_MouseEnter_1);
            this.MouseLeave += new System.EventHandler(this.SanPham_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SanPham_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbGia;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.Label lbTenSP;
        public System.Windows.Forms.Panel pnHinhAnh;
    }
}
