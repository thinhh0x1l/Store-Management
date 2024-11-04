using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DAO;

namespace WindowsFormsApp1
{
    public partial class FrmPhieuThanhDon : Form
    {
        SanPhamBLL sanPhamBLL = new SanPhamBLL();
        List<SPThanhToan> listSPThanhToan;
        List<SPHoaDon> listSPHoaDon;
        HoaDonBan hoaDonBan;
        HoaDonBanBLL HoaDonBanBLL = new HoaDonBanBLL();
        NumberFormatInfo numberFormat = new NumberFormatInfo
        {
            NumberGroupSeparator = "."    // Ký tự phân cách hàng nghìn
        };
        public FrmPhieuThanhDon()
        {
            InitializeComponent();
            //listSPHoaDon = sanPhamBLL.GetSPHoaDon();
            //listSPThanhToan = sanPhamBLL.GetSPThanhToan();
            hoaDonBan = HoaDonBanBLL.GetHoaDonBan();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPhieuThanhDon_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SanPhamBLL.GetSPHoaDon();
            lbTienThua.Text = Convert.ToInt32(hoaDonBan.tienThua).ToString("N0", numberFormat);
            lbTenKH.Text = hoaDonBan.tenKhachHang;
            lbMaHoaDon.Text = hoaDonBan.maHoaDon;
            lbDiem.Text = hoaDonBan.diemHoaDon;
            lbNgayBan.Text = hoaDonBan.thoiGianBan.ToString();
            lbThanhTien.Text = Convert.ToInt32(hoaDonBan.thanhTien).ToString("N0", numberFormat); 
             lbMaNV.Text = hoaDonBan.maNhanVien;
            lbTienKH.Text = Convert.ToInt32(hoaDonBan.tienKhach).ToString("N0", numberFormat); 
        }
    }
}
