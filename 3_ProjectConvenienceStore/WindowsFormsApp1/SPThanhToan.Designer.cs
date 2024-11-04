namespace WindowsFormsApp1
{
    partial class SPThanhToan
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
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.pnAnh = new System.Windows.Forms.Panel();
            this.lbTen = new System.Windows.Forms.Label();
            this.lbDonGia = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(322, 33);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(60, 31);
            this.txtSoLuong.TabIndex = 5;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtSoLuong.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtSoLuong.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            this.txtSoLuong.MouseEnter += new System.EventHandler(this.textBox1_MouseEnter);
            // 
            // pnAnh
            // 
            this.pnAnh.BackColor = System.Drawing.Color.White;
            this.pnAnh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnAnh.Enabled = false;
            this.pnAnh.Location = new System.Drawing.Point(47, 3);
            this.pnAnh.Name = "pnAnh";
            this.pnAnh.Size = new System.Drawing.Size(85, 95);
            this.pnAnh.TabIndex = 1;
            // 
            // lbTen
            // 
            this.lbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTen.Location = new System.Drawing.Point(150, 21);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(69, 69);
            this.lbTen.TabIndex = 2;
            this.lbTen.Text = "Phô Mai con Bò cười";
            // 
            // lbDonGia
            // 
            this.lbDonGia.AutoSize = true;
            this.lbDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDonGia.Location = new System.Drawing.Point(236, 40);
            this.lbDonGia.Name = "lbDonGia";
            this.lbDonGia.Size = new System.Drawing.Size(70, 18);
            this.lbDonGia.TabIndex = 3;
            this.lbDonGia.Text = "Đơn Giá";
            this.lbDonGia.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.Location = new System.Drawing.Point(388, 38);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(49, 20);
            this.lbTongTien.TabIndex = 4;
            this.lbTongTien.Text = "Tổng";
            this.lbTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTongTien.Click += new System.EventHandler(this.lbTongTien_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(150, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 5;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.Location = new System.Drawing.Point(13, 40);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(17, 18);
            this.lbID.TabIndex = 6;
            this.lbID.Text = "0";
            // 
            // SPThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.lbDonGia);
            this.Controls.Add(this.lbTen);
            this.Controls.Add(this.pnAnh);
            this.Controls.Add(this.txtSoLuong);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "SPThanhToan";
            this.Size = new System.Drawing.Size(495, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnAnh;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtSoLuong;
        public System.Windows.Forms.Label lbID;
        public System.Windows.Forms.Label lbTen;
        public System.Windows.Forms.Label lbDonGia;
        public System.Windows.Forms.Label lbTongTien;
    }
}
