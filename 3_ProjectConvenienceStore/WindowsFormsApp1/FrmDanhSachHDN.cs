using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DTO;
using WindowsFormsApp1.BLL;
namespace WindowsFormsApp1
{
    public partial class FrmDanhSachHDN : Form
    {
        HoaDonNhapBLL hdn=new HoaDonNhapBLL();
        public FrmDanhSachHDN()
        {
            InitializeComponent();
        }

        private void FrmDanhSachHDN_Load(object sender, EventArgs e)
        {
            loadHDN();

        }

        public void loadHDN()
        {
            DataTable dt=new DataTable();
            dt= hdn.GetAllHoaDonNhap();
            dtgHDN.DataSource = dt;
            if (dtgHDN.Columns.Contains("id"))
                dtgHDN.Columns["id"].HeaderText = "Mã hóa đơn nhập";
            if (dtgHDN.Columns.Contains("NhanVien_id"))
                dtgHDN.Columns["NhanVien_id"].HeaderText = "Mã NV nhập";
            if (dtgHDN.Columns.Contains("ngayNhap"))
                dtgHDN.Columns["ngayNhap"].HeaderText = "Ngày nhập";
            if (dtgHDN.Columns.Contains("gioNhap"))
                dtgHDN.Columns["gioNhap"].HeaderText = "Giờ nhập";
            if (dtgHDN.Columns.Contains("tongTien"))
                dtgHDN.Columns["tongTien"].HeaderText = "Tổng tiền";
        }

   

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
