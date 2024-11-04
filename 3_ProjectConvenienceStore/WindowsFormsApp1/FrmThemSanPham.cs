using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmThemSanPham : Form
    {
        public FrmThemSanPham()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btn_quaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn file ảnh được chọn
                string imagePath = ofd.FileName;

                // Hiển thị ảnh trong PictureBox
                pictureBox1.Image = Image.FromFile(imagePath);

                // Tùy chỉnh kích thước PictureBox cho phù hợp với ảnh
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
