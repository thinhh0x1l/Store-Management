using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DTO;
namespace WindowsFormsApp1
{
    public partial class SanPham1 : UserControl
    {

        public SanPhamBLL spbll=new SanPhamBLL();
        public SanPhamDTO spdto=new SanPhamDTO();

        public SanPham1()
        {
            InitializeComponent();
        }
        public void LoadSanPham( string tenSanPham, int giaSanPham, byte[] hinhAnh,int soluong)
        {
            lblTenSP.Text = tenSanPham;
            lblGia.Text = giaSanPham.ToString()+" VND";
            lblSL.Text ="Số lượng: "+ soluong;
            using (MemoryStream ms = new MemoryStream(hinhAnh))
            {
                Image img = Image.FromStream(ms);
                ptbHinhAnh.Image = img;
            }
        }

        private void SanPham1_Load(object sender, EventArgs e)
        {
         
        }
    }
}
