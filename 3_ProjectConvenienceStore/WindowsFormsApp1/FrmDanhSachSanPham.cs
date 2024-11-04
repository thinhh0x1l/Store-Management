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
    public partial class FrmDanhSachSanPham : Form
    {
        public FrmDanhSachSanPham()
        {
            InitializeComponent();
        }
        public Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnl_dssp_main.Controls.Add(childForm);
            pnl_dssp_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
      

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_sua_sp_Click(object sender, EventArgs e)
        {
            FrmSuaSanPham frm_sua_sp= new FrmSuaSanPham();
            frm_sua_sp.Show();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmThemSanPham());
        }
    }
}
