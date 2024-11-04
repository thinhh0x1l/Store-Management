namespace WindowsFormsApp1
{
    partial class PhanQuyen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridViewNV = new System.Windows.Forms.DataGridView();
            this.cbbPhanQuyen = new System.Windows.Forms.ComboBox();
            this.btnCapQuyen = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnThuHoi = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNV)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewNV
            // 
            this.gridViewNV.AllowUserToAddRows = false;
            this.gridViewNV.AllowUserToDeleteRows = false;
            this.gridViewNV.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridViewNV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridViewNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewNV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.gridViewNV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewNV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridViewNV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewNV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridViewNV.ColumnHeadersHeight = 40;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewNV.DefaultCellStyle = dataGridViewCellStyle7;
            this.gridViewNV.EnableHeadersVisualStyles = false;
            this.gridViewNV.Location = new System.Drawing.Point(68, 12);
            this.gridViewNV.Name = "gridViewNV";
            this.gridViewNV.ReadOnly = true;
            this.gridViewNV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewNV.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gridViewNV.RowTemplate.Height = 35;
            this.gridViewNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewNV.Size = new System.Drawing.Size(587, 669);
            this.gridViewNV.TabIndex = 0;
            this.gridViewNV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewNV_CellClick);
            // 
            // cbbPhanQuyen
            // 
            this.cbbPhanQuyen.BackColor = System.Drawing.Color.Aqua;
            this.cbbPhanQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPhanQuyen.FormattingEnabled = true;
            this.cbbPhanQuyen.Location = new System.Drawing.Point(705, 25);
            this.cbbPhanQuyen.Name = "cbbPhanQuyen";
            this.cbbPhanQuyen.Size = new System.Drawing.Size(340, 33);
            this.cbbPhanQuyen.TabIndex = 1;
            this.cbbPhanQuyen.SelectedIndexChanged += new System.EventHandler(this.cbbPhanQuyen_SelectedIndexChanged);
            // 
            // btnCapQuyen
            // 
            this.btnCapQuyen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCapQuyen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCapQuyen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCapQuyen.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCapQuyen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCapQuyen.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnCapQuyen.FillColor2 = System.Drawing.Color.CornflowerBlue;
            this.btnCapQuyen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapQuyen.ForeColor = System.Drawing.Color.Black;
            this.btnCapQuyen.Location = new System.Drawing.Point(705, 108);
            this.btnCapQuyen.Name = "btnCapQuyen";
            this.btnCapQuyen.Size = new System.Drawing.Size(340, 131);
            this.btnCapQuyen.TabIndex = 2;
            this.btnCapQuyen.Text = "Cấp Quyền";
            this.btnCapQuyen.Click += new System.EventHandler(this.btnCapQuyen_Click);
            // 
            // btnThuHoi
            // 
            this.btnThuHoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThuHoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThuHoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThuHoi.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThuHoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThuHoi.FillColor = System.Drawing.Color.Crimson;
            this.btnThuHoi.FillColor2 = System.Drawing.Color.Crimson;
            this.btnThuHoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuHoi.ForeColor = System.Drawing.Color.Silver;
            this.btnThuHoi.Location = new System.Drawing.Point(705, 465);
            this.btnThuHoi.Name = "btnThuHoi";
            this.btnThuHoi.Size = new System.Drawing.Size(340, 120);
            this.btnThuHoi.TabIndex = 3;
            this.btnThuHoi.Text = "Thu Hồi Quyền";
            this.btnThuHoi.Click += new System.EventHandler(this.btnThuHoi_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhan.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXacNhan.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnXacNhan.FillColor2 = System.Drawing.Color.CornflowerBlue;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.Black;
            this.btnXacNhan.Location = new System.Drawing.Point(705, 291);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(340, 130);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // PhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnThuHoi);
            this.Controls.Add(this.btnCapQuyen);
            this.Controls.Add(this.cbbPhanQuyen);
            this.Controls.Add(this.gridViewNV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PhanQuyen";
            this.Text = "PhanQuyen";
            this.Load += new System.EventHandler(this.PhanQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewNV;
        private System.Windows.Forms.ComboBox cbbPhanQuyen;
        private Guna.UI2.WinForms.Guna2GradientButton btnCapQuyen;
        private Guna.UI2.WinForms.Guna2GradientButton btnThuHoi;
        private Guna.UI2.WinForms.Guna2GradientButton btnXacNhan;
    }
}