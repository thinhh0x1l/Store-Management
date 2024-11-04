using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;
namespace WindowsFormsApp1
{
    public partial class FrmHoaDonNhap : Form
    {

        List<ChiTietHoaDonNhapDTO> list = new List<ChiTietHoaDonNhapDTO>();
        string  manvhdn;
        int hdid = 0;
        DateTime ngay;
        TimeSpan gio;
        long tongtienhd;
        public SanPhamBLL spbll = new SanPhamBLL();
        HoaDonNhapBLL hdn = new HoaDonNhapBLL();
        public SanPhamNCCBLL spncc = new SanPhamNCCBLL();
        public ChiTietHoaDonNhapBLL cthd = new ChiTietHoaDonNhapBLL();
        public List<HoaDonNhapCuaCTHD> getTTFromCTHDN = new List<HoaDonNhapCuaCTHD>();
        public HDNCuaCTHDBLL hdncthd=new HDNCuaCTHDBLL();
        public FrmHoaDonNhap()
        {
            InitializeComponent();
            
        }

        public void LoadData(List<ChiTietHoaDonNhapDTO> dt, int hoaDonId, string manv, string ngaylap, string giolap, int mahd, long tongtien, int sl)
        {
            hdid = hoaDonId;
            list.AddRange(dt);
            // dgvChiTietHoaDon.DataSource = dt;
            getTTFromCTHDN = hdncthd.getTTFromCTHDN(dt);
            DataTable datatable=new DataTable();

            datatable = hdncthd.ChuyenListToDataTable(getTTFromCTHDN);

            dgvChiTietHoaDon.DataSource= datatable;

            manvhdn = manv;
            lblMaNV.Text = manvhdn;
            lblNgayHoaDon.Text = ngaylap;
            ngay = DateTime.ParseExact(ngaylap, "yyyy/MM/dd", null);

            lblGioHoaDon.Text = giolap;

            DateTime dateTime = DateTime.Parse(giolap);
            gio = dateTime.TimeOfDay;

            lblMaHD.Text = Convert.ToString(mahd);
            lblTongTien.Text = Convert.ToString(tongtien);
            tongtienhd = Convert.ToInt64(tongtien);

            lblSoLuong.Text = sl.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNhapHoaDon_Click(object sender, EventArgs e)
        {
            HoaDonNhapDTO hd = new HoaDonNhapDTO(manvhdn, ngay, gio, tongtienhd);
            dgvChiTietHoaDon.Refresh();
            if (hdn.AddHoaDonNhap(hd))
            {
                cthd.LuuDanhSachChiTietHoaDon(hdid, list);
            }
            this.Close();
        }

    }
}
