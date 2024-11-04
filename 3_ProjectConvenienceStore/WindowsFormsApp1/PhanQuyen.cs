using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;

namespace WindowsFormsApp1
{
    public partial class PhanQuyen : Form
    {
        NhanVienBLL nhanVienBLL ;
        PhanQuyenBLL phanQuyenBLL ;
        public PhanQuyen()
        {
            InitializeComponent();
            nhanVienBLL = new NhanVienBLL();
            phanQuyenBLL = new PhanQuyenBLL();
            try
            {
                cbbPhanQuyen.DataSource = phanQuyenBLL.getPhanQuyen();
                if (cbbPhanQuyen.DataSource != null)
                {
                    cbbPhanQuyen.DisplayMember = "ten";
                    cbbPhanQuyen.ValueMember = "id";
                }
                

            }
            catch (Exception ex) { }
        }

        private void btnCapQuyen_Click(object sender, EventArgs e)
        {
            cbbPhanQuyen.Enabled = true;
            btnCapQuyen.Enabled = false;
        }

        private void PhanQuyen_Load(object sender, EventArgs e)
        {
            btnCapQuyen.Enabled = btnThuHoi.Enabled = btnXacNhan.Enabled = false;
            gridViewNV.DataBindings.Clear();
            gridViewNV.DataSource = nhanVienBLL.getNhanVienQuyen();
            cbbPhanQuyen.Text = "";
            reset();
        }
        private string tenQuyen = " ádf";
        private int idQuyen = 10;
        private void cbbPhanQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedValue = cbbPhanQuyen.SelectedValue;
            object selectedItem = cbbPhanQuyen.SelectedItem;
            int selectedCategoryId;
            if (selectedValue != null && int.TryParse(selectedValue.ToString(), out selectedCategoryId))
            {
                idQuyen = selectedCategoryId;
                tenQuyen = cbbPhanQuyen.GetItemText(selectedItem);
                
            }
            if(idQuyen != 0 && btnThuHoi.Enabled == false)
                btnXacNhan.Enabled = true;
            else if(idQuyen == 0)
                btnXacNhan.Enabled = false;
        }
        private void reset()
        {
            cbbPhanQuyen.Enabled = false;
            btnXacNhan.Enabled = false;
            btnCapQuyen.Enabled = false;
            btnThuHoi.Enabled = false;
        }
        private void gridViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
                return;
            //xuLyButton();
            DataGridViewRow row = gridViewNV.Rows[index];
            cbbPhanQuyen.Text = row.Cells[4].Value.ToString();
            if (row.Cells[3].Value.ToString() == "0")
            {
                btnCapQuyen.Enabled = true;
                btnThuHoi.Enabled = false;
            }
            else
            {
                btnCapQuyen.Enabled = false;
                btnThuHoi.Enabled = true;
            }
            maNV = row.Cells[0].Value.ToString();
            btnXacNhan.Enabled = false;
            cbbPhanQuyen.Enabled = false ; 

        }
        private string maNV;
        private void btnThuHoi_Click(object sender, EventArgs e)
        {
            nhanVienBLL.updateMaQuyenNhanVien(maNV, 0);
            phanQuyenBLL.thuHoiQuyen(maNV, tenQuyen);
            PhanQuyen_Load(sender, e);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            nhanVienBLL.updateMaQuyenNhanVien(maNV, idQuyen);
            phanQuyenBLL.capQuyen(maNV, tenQuyen);
            PhanQuyen_Load(sender, e);
        }
    }
}
