using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SanPham : UserControl
    {
        
        public SanPham(string tag, byte[] url, string ten, int soLuong, int donGia, EventHandler onclick)
        {
            InitializeComponent();
            newSanPham(tag, url, ten, soLuong, donGia, onclick);
        }
        public void newSanPham(string tag , byte[] url,string ten, int soLuong, int donGia, EventHandler onclick)
        {
            this.Tag = tag;
            MemoryStream ms = new MemoryStream(url);
            Bitmap bmp = new Bitmap(ms);
            this.setInfo(bmp, ten, soLuong, donGia);
            this.Click += new EventHandler(onclick);
        }
        public void setInfo(Bitmap pic, string ten, int soLuong, int gia)
        {
            this.pnHinhAnh.BackgroundImage = pic;
            this.lbGia.Text = gia.ToString()+"đ";
            this.lbSoLuong.Text = soLuong.ToString();
            this.lbTenSP.Text = ten;
        }
        public string getName()
        {
            return lbTenSP.Text;
        }

        private void SanPham_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Blue;


        }

        private void SanPham_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Linen;
        }

        private void SanPham_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void SanPham_MouseMove(object sender, MouseEventArgs e)
        {
           
       
        }

        private void SanPham_MouseEnter_1(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(217, 229, 242);
        }

        private void pnHinhAnh_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbSoLuong_Click(object sender, EventArgs e)
        {

        }
    }
}
