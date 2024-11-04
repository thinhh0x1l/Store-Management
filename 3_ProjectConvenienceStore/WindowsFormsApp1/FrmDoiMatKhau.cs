using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1
{
    public partial class FrmDoiMatKhau : Form
    {
        NhanVienDAO nhanVienDAO = new NhanVienDAO();
        public FrmDoiMatKhau()
        {
            InitializeComponent();
            txtMKmoi1.UseSystemPasswordChar = txtMKmoi2.UseSystemPasswordChar = txtMKcu.UseSystemPasswordChar = true;
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMKmoi1.Clear();
            txtMKmoi2.Clear();
            txtMKcu.Clear();
            reset();
        }
        private void reset()
        {
           ;
            lbMK2.Text = lbMKcu.Text = lbMKmoi1.Text = "";
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            reset();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            reset();
        }

        private void txtMKcu_TextChanged(object sender, EventArgs e)
        {
            reset();
        }
        
        private void btn_sua_nv_Click(object sender, EventArgs e)
        {
            if(txtMKcu.Text == "")
            {
                lbMKcu.Text = "*Không được để trống";
                return;
            }
            else if(txtMKmoi1.Text == "") {
                lbMKmoi1.Text = "*Không được để trống";
                return;
            }
            else if (txtMKmoi2.Text == "") {
                lbMK2.Text = "*Không được để trống";
                return;

            }
            else if (txtMKcu.Text != Login.matKhau)
            {
                lbMKcu.Text = "*Mật khẩu cũ không chính xác";
                return;
            }
            else if (txtMKmoi1.Text != txtMKmoi2.Text) {
                lbMK2.Text = "*Mật khẩu không khớp";
                return;
            }
            else
            {
                nhanVienDAO.doiMatKhau(Login.tenNV, txtMKmoi1.Text,txtMKcu.Text);
                MessageBox.Show("Đổi mật khẩu thành công");
            }
            FrmDoiMatKhau_Load(sender, e);
        }

        private void txtMKcu_IconLeftClick(object sender, EventArgs e)
        {
            if(txtMKcu.UseSystemPasswordChar == false)
            {

                txtMKcu.UseSystemPasswordChar = true;

            }
            else
            {

                txtMKcu.UseSystemPasswordChar = false;

            }
        }

        private void txtMKmoi1_IconLeftClick(object sender, EventArgs e)
        {
            if (txtMKmoi1.UseSystemPasswordChar == false)
            {

                txtMKmoi1.UseSystemPasswordChar = true;

            }
            else
            {

                txtMKmoi1.UseSystemPasswordChar = false;

            }
        }

        private void txtMKmoi2_IconLeftClick(object sender, EventArgs e)
        {
            if (txtMKmoi2.UseSystemPasswordChar == false)
            {

                txtMKmoi2.UseSystemPasswordChar = true;

            }
            else
            {

                txtMKmoi2.UseSystemPasswordChar = false;

            }
        }
    }
}
