using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SPThanhToan : UserControl
    {
        public event EventHandler MouseClick;

        public event EventHandler TextChanged;

        NumberFormatInfo numberFormat = new NumberFormatInfo
        {
            NumberGroupSeparator = "."    // Ký tự phân cách hàng nghìn
        };
        public SPThanhToan(DateTime ngyHetHan,string tag, byte[] url, int id, string ten, int soLuong, int donGia, EventHandler onclick, EventHandler textChanged,EventHandler y)
        {
            InitializeComponent();
            this.ngayHetHan = ngyHetHan;
            newSanPham(tag, url, id, ten, soLuong, donGia, onclick, textChanged,y);
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            txtSoLuong.MouseClick += txtSoLuong_MouseClick;
        }
        public void newSanPham(string tag, byte[] url, int id ,string ten, int soLuong, int donGia,EventHandler onclick, EventHandler textChanged, EventHandler y)
        {
            this.Tag = tag;
            MemoryStream ms = new MemoryStream(url);
            Bitmap bmp = new Bitmap(ms);
            this.setInfo(bmp, id, ten,  donGia,soLuong,tag);
            this.Click += new EventHandler(onclick);
            this.TextChanged += new EventHandler(textChanged);
            this.MouseClick += new EventHandler(y);
        }
        public long donGia = 1;
        int sl;
        public long tong;
        private DateTime ngayHetHan;
        private void txtSoLuong_MouseClick(object sender, EventArgs e)
        {
            // Gọi sự kiện TextChanged khi TextBox thay đổi
            MouseClick?.Invoke(this, e);
        }
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            // Gọi sự kiện TextChanged khi TextBox thay đổi
            TextChanged?.Invoke(this, e);
        }
        public void setInfo(Bitmap pic,int id, string ten,  int gia,int sl,string tag)
        {
            this.pnAnh.BackgroundImage = pic;
            donGia = gia;
            tong = gia;
           
            this.lbID.Text = id.ToString();
            this.lbDonGia.Text = donGia.ToString("N0", numberFormat) + "đ";
            this.txtSoLuong.Text = "1";
            this.lbTen.Text = ten;
            this.lbTongTien.Text = tong.ToString("N0", numberFormat) + "đ";
            this.tag = tag;
            this.sl = sl;
            //GioHangSP.Bans.Add(this);
        }
        string pass = "1";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Equals(""))
            {
                tong = 0;
                lbTongTien.Text = tong.ToString() + "đ";
            }
            else if (checkChar(txtSoLuong.Text) && System.Convert.ToInt32(txtSoLuong.Text) <= sl && System.Convert.ToInt32(txtSoLuong.Text) > 0)
            {
                   tong = donGia * System.Convert.ToInt32(txtSoLuong.Text);
                lbTongTien.Text = tong.ToString("N0", numberFormat) + "đ";
             }
            else
                txtSoLuong.Text = pass;
            pass = txtSoLuong.Text;
        }
        public string getText()
        {
            return txtSoLuong.Text;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }
        public DateTime ngayHetHanSP()
        {
            return ngayHetHan;
        }
        
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            //int i = txtSoLuong.Text.Count();
            //string s = txtSoLuong.Text;
            //try
            //{

            //    if (i > 0 && s[i - 1] >= '0' && (s[i - 1] <= '9' && s[0] > '0' && s[0] <= '9') && System.Convert.ToInt32(txtSoLuong.Text) <= this.sl)
            //    {
            //        i++;
            //        this.lbTongTien.Text = "";
            //        try
            //        {

            //            this.tong = donGia * System.Convert.ToInt64(txtSoLuong.Text);
            //            this.lbTongTien.Text = tong.ToString() + "đ";

            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Loi" + ex.Message);
            //        }
            //    }

            //    else
            //        txtSoLuong.Text = label4.Text;
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    txtSoLuong.Text = "1";
            //}
            
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            
        }
       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i = txtSoLuong.Text.Count();
            string s = txtSoLuong.Text;
           if (i > 0 && s[i - 1] >= '0' && s[i - 1] <= '9' && s[0] > '0' && s[0] <= '9' )
                try
                {
                    label4.Text = txtSoLuong.Text;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("LOI "+ ex.Message);
                }
        }
        string tag; 
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public string getTag()
        {
            return this.tag;    
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbTongTien_Click(object sender, EventArgs e)
        {

        }
        private bool checkChar(string s)
        {
            
            for (int i = 0; i < s.Length; i++) {
                if(s[i] <'0' || s[i] > '9')
                    return false;
            }
            return true;
        }
    }
}
