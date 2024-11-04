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
    public partial class FrmDanhSachNhanVien : Form
    {
        public FrmDanhSachNhanVien()
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
            pnl_danhsachnv.Controls.Add(childForm);
            pnl_danhsachnv.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_them_nv_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmThemNhanVien());
        }

    }
}
