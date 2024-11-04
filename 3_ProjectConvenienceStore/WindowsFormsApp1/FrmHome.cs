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
    public partial class FrmHome : Form
    {

        public SanPhamBLL spbll;
        public HoaDonBanBLL hdbbll;
        public DateTime ngay;
        public KhachHangBLL khbll;

        public FrmHome()
        {

            InitializeComponent();
        }
        private void FrmHome_Load(object sender, EventArgs e)
        {
            spbll = new SanPhamBLL();
            hdbbll = new HoaDonBanBLL();
            khbll = new KhachHangBLL();
            lblMaNV.Text = Login.tenNV;
            LoadSanPhamList();
            LoadKH();
            lblThoiGian.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }



        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            FrmDoiMatKhau doimk = new FrmDoiMatKhau();
            doimk.Show();
        }

        public void LoadSanPhamList()
        {
            ngay = DateTime.Now.Date;

            DataTable dt = hdbbll.sanPhamBanChayTrongNgay(ngay);

            flowpnlSanPham.Controls.Clear();
            foreach (DataRow row in dt.Rows)
            {

                string tenSanPham = row["ten"].ToString();
                int giaSanPham = Convert.ToInt32(row["donGia"]);
                byte[] hinhAnh = row["urlAnh"] as byte[];
                int sl = Convert.ToInt32(row["SoLuongBan"]);

                SanPham1 spControl = new SanPham1();
                spControl.LoadSanPham(tenSanPham, giaSanPham, hinhAnh, sl);
                flowpnlSanPham.Controls.Add(spControl);
            }
        }
        public void LoadKH()
        {
            DataTable dtKH = new DataTable();
            try
            {
                dtKH = khbll.xepHangDiem();
                dtgDiem.DataSource = dtKH;

                if (dtgDiem.Columns.Contains("id"))
                    if (dtgDiem.Columns["id"].HeaderText == null)
                    {
                        dtgDiem.Columns["id"].HeaderText = "Mã KH";
                        dtgDiem.Columns["ho"].HeaderText = "Họ";
                        dtgDiem.Columns["ten"].HeaderText = "Tên";
                        dtgDiem.Columns["SDT"].HeaderText = "SDT";
                        dtgDiem.Columns["tichDiem"].HeaderText = "Tích điểm";
                    }

            }
            catch (Exception ex) { }


        }

        private void btnDoiMatKhau_Click_1(object sender, EventArgs e)
        {
            new FrmDoiMatKhau().Show();
        }

        private void lblMaNV_Click(object sender, EventArgs e)
        {

        }
    }
}
