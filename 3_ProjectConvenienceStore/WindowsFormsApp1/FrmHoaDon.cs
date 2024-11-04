using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DTO;
namespace WindowsFormsApp1
{
    public partial class FrmHoaDon : Form
    {
        DateTime selectedDate;
        public HoaDonNhapBLL hdnbll;
        public ChiTietHoaDonNhapBLL cthdnbll;


        public HoaDonBanBLL hdbbll;
        public ChiTietHoaDonBLL cthdbbll;

        public FrmHoaDon()
        {
            InitializeComponent();

        }



        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
           
            
            hdnbll = new HoaDonNhapBLL();
            cthdnbll = new ChiTietHoaDonNhapBLL();


            hdbbll = new HoaDonBanBLL();
            cthdbbll = new ChiTietHoaDonBLL();
        }

   

        //-------------hóa đơn nhập theo ngày----------------------------
        private void dtpNgayThang_ValueChanged(object sender, EventArgs e)
        {
            selectedDate = dtpNgayThang.Value;
            DateTime ngayhd = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);


            DataTable dt = new DataTable();
            dt = hdnbll.getHDNgay(ngayhd);
            dtgHDN.DataSource = dt;
        

        }
        private void dtgHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgHDN.Rows[e.RowIndex] != null)
                {
                    DataGridViewRow row = dtgHDN.Rows[e.RowIndex];
                    if (row.Cells["id"].Value != null)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);
                        DataTable dt = new DataTable();
                        dt = cthdnbll.getChiTietHDN(id);
                        dgvCTHD.DataSource = dt;

                        //cấu hình cột cho bảng chi tiêt hóa đơn
                        if (dgvCTHD.Columns.Contains("id"))
                            dgvCTHD.Columns["id"].HeaderText = "Mã SP";

                        if (dgvCTHD.Columns.Contains("ten"))
                            dgvCTHD.Columns["ten"].HeaderText = "Tên SP";

                        if (dgvCTHD.Columns.Contains("soLuong"))
                            dgvCTHD.Columns["soLuong"].HeaderText = "Số lượng";

                        if (dgvCTHD.Columns.Contains("donGia"))
                            dgvCTHD.Columns["donGia"].HeaderText = "Đơn giá";

                        if (!dgvCTHD.Columns.Contains("SoTienTungSP"))
                        {
                            DataGridViewTextBoxColumn soTienTungSanPham = new DataGridViewTextBoxColumn();
                            soTienTungSanPham.Name = "SoTienTungSP";
                            soTienTungSanPham.HeaderText = "Tổng tiền SP";
                            soTienTungSanPham.ValueType = typeof(int);
                            dgvCTHD.Columns.Add(soTienTungSanPham);
                        }


                        foreach (DataGridViewRow dgvRow in dgvCTHD.Rows)
                        {
                            if (dgvRow.IsNewRow) continue;

                            int spid = Convert.ToInt32(dgvRow.Cells["id"].Value);
                            int sl = Convert.ToInt32(dgvRow.Cells["soLuong"].Value);
                            int soTienTungSP = cthdnbll.tongTienSPTam(id, spid, sl);
                            dgvRow.Cells["SoTienTungSP"].Value = soTienTungSP;
                        }
                        if (dgvCTHD.Columns.Contains("SanPham_NgayHetHan"))
                            dgvCTHD.Columns["SanPham_NgayHetHan"].HeaderText = "Ngày hết hạn";

                        ///////////////////////////////
                        string nvid = Convert.ToString(row.Cells["NhanVien_id"].Value);
                        DateTime ngayNhap = Convert.ToDateTime(row.Cells["ngayNhap"].Value);

                        long tongTien = Convert.ToInt64(row.Cells["tongTien"].Value);
                        txtMaHD.Text = id.ToString();
                        txtMaNV.Text = nvid;
                        lblNgayHD.Visible = true;
                        lblNgayHD.Text = ngayNhap.ToString("yyyy/MM/dd");

                        txtTongTien.Text = tongTien.ToString();
                        TimeSpan gioNhap;
                        if (TimeSpan.TryParse(row.Cells["gioNhap"].Value.ToString(), out gioNhap))
                        {
                            lblGioHD.Visible = true;
                            lblGioHD.Text = gioNhap.ToString(@"hh\:mm\:ss");
                        }




                    }
                }
            }
        }

        //---------------------------hóa đơn nhập theo tháng--------------------------------------------------------
        private void dtpThang_ValueChanged(object sender, EventArgs e)
        {

            selectedDate = dtpThang.Value;

            DateTime thanghd = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            lblThang.Visible = true;
            lblThang.Text = "Tháng " + thanghd.Month + "/" + thanghd.Year;
            DataTable dt = new DataTable();
            dt = hdnbll.getHDThang(thanghd);

            dtgHDN1.DataSource = dt;

          
        }

        private void dtgHDN1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgHDN1.Rows[e.RowIndex] != null)
                {
                    DataGridViewRow row = dtgHDN1.Rows[e.RowIndex];
                    if (row.Cells["id"].Value != null)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);
                        DataTable dt = new DataTable();
                        dt = cthdnbll.getChiTietHDN(id);
                        dgvCTHD1.DataSource = dt;

                        //cấu hình cột cho bảng chi tiêt hóa đơn
                        if (dgvCTHD1.Columns.Contains("id"))
                            dgvCTHD1.Columns["id"].HeaderText = "Mã SP";

                        if (dgvCTHD1.Columns.Contains("ten"))
                            dgvCTHD1.Columns["ten"].HeaderText = "Tên SP";

                        if (dgvCTHD1.Columns.Contains("soLuong"))
                            dgvCTHD1.Columns["soLuong"].HeaderText = "Số lượng";

                        if (dgvCTHD1.Columns.Contains("donGia"))
                            dgvCTHD1.Columns["donGia"].HeaderText = "Đơn giá";

                        if (!dgvCTHD1.Columns.Contains("SoTienTungSP"))
                        {
                            DataGridViewTextBoxColumn soTienTungSanPham = new DataGridViewTextBoxColumn();
                            soTienTungSanPham.Name = "SoTienTungSP";
                            soTienTungSanPham.HeaderText = "Tổng tiền SP";
                            soTienTungSanPham.ValueType = typeof(int);
                            dgvCTHD1.Columns.Add(soTienTungSanPham);
                        }


                        foreach (DataGridViewRow dgvRow in dgvCTHD1.Rows)
                        {
                            if (dgvRow.IsNewRow) continue;

                            int spid = Convert.ToInt32(dgvRow.Cells["id"].Value);
                            int sl = Convert.ToInt32(dgvRow.Cells["soLuong"].Value);
                            int soTienTungSP = cthdnbll.tongTienSPTam(id, spid, sl);
                            dgvRow.Cells["SoTienTungSP"].Value = soTienTungSP;
                        }
                        if (dgvCTHD1.Columns.Contains("SanPham_NgayHetHan"))
                            dgvCTHD1.Columns["SanPham_NgayHetHan"].HeaderText = "Ngày hết hạn";

                       
                        string nvid = Convert.ToString(row.Cells["NhanVien_id"].Value);
                        DateTime ngayNhap = Convert.ToDateTime(row.Cells["ngayNhap"].Value);

                        long tongTien = Convert.ToInt64(row.Cells["tongTien"].Value);
                        txtMaHD1.Text = id.ToString();
                        txtMaNV1.Text = nvid.ToString();
                        lblNgayHD1.Visible = true;
                        lblNgayHD1.Text = ngayNhap.ToString("yyyy/MM/dd");

                        txtTongTien1.Text = tongTien.ToString();
                        TimeSpan gioNhap;
                        if (TimeSpan.TryParse(row.Cells["gioNhap"].Value.ToString(), out gioNhap))
                        {
                            lblGioHD1.Visible = true;
                            lblGioHD1.Text = gioNhap.ToString(@"hh\:mm\:ss");
                        }

                    }
                }
            }
        }



        //--------------------------------hóa đơn nhập theo năm---------------------------------------------------
        private void dtpNam_ValueChanged(object sender, EventArgs e)
        {
            selectedDate = dtpNam.Value;

            DateTime namhd = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);
            lblNam.Visible = true;
            lblNam.Text = "Năm " + namhd.Year;
            DataTable dt = new DataTable();
            dt = hdnbll.getHDNam(namhd);


            dtgHDN2.DataSource = dt;

        
        }

        private void dtgHDN2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgHDN2.Rows[e.RowIndex] != null)
                {
                    DataGridViewRow row = dtgHDN2.Rows[e.RowIndex];
                    if (row.Cells["id"].Value != null)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);
                        DataTable dt = new DataTable();
                        dt = cthdnbll.getChiTietHDN(id);
                        dgvCTHD2.DataSource = dt;

                        //cấu hình cột cho bảng chi tiêt hóa đơn
                        if (dgvCTHD2.Columns.Contains("id"))
                            dgvCTHD2.Columns["id"].HeaderText = "Mã SP";

                        if (dgvCTHD2.Columns.Contains("ten"))
                            dgvCTHD2.Columns["ten"].HeaderText = "Tên SP";

                        if (dgvCTHD2.Columns.Contains("soLuong"))
                            dgvCTHD2.Columns["soLuong"].HeaderText = "Số lượng";

                        if (dgvCTHD2.Columns.Contains("donGia"))
                            dgvCTHD2.Columns["donGia"].HeaderText = "Đơn giá";

                        if (!dgvCTHD2.Columns.Contains("SoTienTungSP"))
                        {
                            DataGridViewTextBoxColumn soTienTungSanPham = new DataGridViewTextBoxColumn();
                            soTienTungSanPham.Name = "SoTienTungSP";
                            soTienTungSanPham.HeaderText = "Tổng tiền SP";
                            soTienTungSanPham.ValueType = typeof(int);
                            dgvCTHD2.Columns.Add(soTienTungSanPham);
                        }


                        foreach (DataGridViewRow dgvRow in dgvCTHD2.Rows)
                        {
                            if (dgvRow.IsNewRow) continue;

                            int spid = Convert.ToInt32(dgvRow.Cells["id"].Value);
                            int sl = Convert.ToInt32(dgvRow.Cells["soLuong"].Value);
                            int soTienTungSP = cthdnbll.tongTienSPTam(id, spid, sl);
                            dgvRow.Cells["SoTienTungSP"].Value = soTienTungSP;
                        }
                        if (dgvCTHD2.Columns.Contains("SanPham_NgayHetHan"))
                            dgvCTHD2.Columns["SanPham_NgayHetHan"].HeaderText = "Ngày hết hạn";

                     
                        string nvid = Convert.ToString(row.Cells["NhanVien_id"].Value);
                        DateTime ngayNhap = Convert.ToDateTime(row.Cells["ngayNhap"].Value);

                        long tongTien = Convert.ToInt64(row.Cells["tongTien"].Value);
                        txtMaHD2.Text = id.ToString();
                        txtMaNV2.Text = nvid.ToString();
                        lblNgayHD2.Visible = true;
                        lblNgayHD2.Text = ngayNhap.ToString("yyyy/MM/dd");

                        txtTongTienn2.Text = tongTien.ToString();
                        TimeSpan gioNhap;
                        if (TimeSpan.TryParse(row.Cells["gioNhap"].Value.ToString(), out gioNhap))
                        {
                            lblGioHD2.Visible = true;
                            lblGioHD2.Text = gioNhap.ToString(@"hh\:mm\:ss");
                        }




                    }
                }
            }
        }

        //-----------------------hoa don nhap theo ma nhan vien va ngay----------------------------------

        private void dtpNV_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNVHDN.Text))
            {
                dtpNV.Value = new DateTime(2024, 1, 1);
                msg.Visible = true;
                msg.Text = "*Vui lòng nhập mã nhân viên";
                msg.ForeColor = Color.Red;
                txtMaNVHDN.Focus();
            }
            else
            {
                string nvid = txtMaNVHDN.Text;
                if (hdnbll.kiemTraNV(nvid))
                {
                    DateTime ngaynv = new DateTime(dtpNV.Value.Year, dtpNV.Value.Month, dtpNV.Value.Day);
                    msg.Visible = false;
                    msg.Text="";
                    DataTable dt = hdnbll.getHDNTheoMaNVVaNgay(nvid, ngaynv);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dtgHDN3.DataSource = dt;
                       
                    }
                    else
                    {
                        dtpNV.Value = new DateTime(2024, 1, 1);
                        msg.Visible = true;
                        msg.Text = "*Không có dữ liệu hóa đơn cho nhân viên vào ngày đã chọn";
                        msg.ForeColor = Color.Red;

                        dtgHDN3.DataSource = null;
                        FrmHoaDon_Load(sender, e);

                    }
                }
                else
                {
                    dtpNV.Value = new DateTime(2024, 1, 1);
                    msg.Visible = true;
                    msg.Text = "*Không tồn tại nhân viên";
                    msg.ForeColor = Color.Red;
                
                    txtMaNVHDN.Focus();
                  
                    dtgHDN3.DataSource=null;
                 
                    FrmHoaDon_Load(sender,e);
                }
            }
        }


        private void dtgHDN3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgHDN3.Rows[e.RowIndex] != null)
                {
                    DataGridViewRow row = dtgHDN3.Rows[e.RowIndex];
                    if (row.Cells["id"].Value != null)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);
                        DataTable dt = new DataTable();
                        dt = cthdnbll.getChiTietHDN(id);
                        dgvCTHD3.DataSource = dt;

                        //cấu hình cột cho bảng chi tiêt hóa đơn
                        if (dgvCTHD3.Columns.Contains("id"))
                            dgvCTHD3.Columns["id"].HeaderText = "Mã SP";

                        if (dgvCTHD3.Columns.Contains("ten"))
                            dgvCTHD3.Columns["ten"].HeaderText = "Tên SP";

                        if (dgvCTHD3.Columns.Contains("soLuong"))
                            dgvCTHD3.Columns["soLuong"].HeaderText = "Số lượng";

                        if (dgvCTHD3.Columns.Contains("donGia"))
                            dgvCTHD3.Columns["donGia"].HeaderText = "Đơn giá";

                        if (!dgvCTHD3.Columns.Contains("SoTienTungSP"))
                        {
                            DataGridViewTextBoxColumn soTienTungSanPham = new DataGridViewTextBoxColumn();
                            soTienTungSanPham.Name = "SoTienTungSP";
                            soTienTungSanPham.HeaderText = "Tổng tiền SP";
                            soTienTungSanPham.ValueType = typeof(int);
                            dgvCTHD3.Columns.Add(soTienTungSanPham);
                        }


                        foreach (DataGridViewRow dgvRow in dgvCTHD3.Rows)
                        {
                            if (dgvRow.IsNewRow) continue;

                            int spid = Convert.ToInt32(dgvRow.Cells["id"].Value);
                            int sl = Convert.ToInt32(dgvRow.Cells["soLuong"].Value);
                            int soTienTungSP = cthdnbll.tongTienSPTam(id, spid, sl);
                            dgvRow.Cells["SoTienTungSP"].Value = soTienTungSP;
                        }
                        if (dgvCTHD3.Columns.Contains("SanPham_NgayHetHan"))
                            dgvCTHD3.Columns["SanPham_NgayHetHan"].HeaderText = "Ngày hết hạn";

                        ///////////////////////////////
                        string nvid = Convert.ToString(row.Cells["NhanVien_id"].Value);
                        DateTime ngayNhap = Convert.ToDateTime(row.Cells["ngayNhap"].Value);

                        long tongTien = Convert.ToInt64(row.Cells["tongTien"].Value);
                        txtMaHD3.Text = id.ToString();
                        txtMaNV3.Text = nvid.ToString();
                        lblNgayHD3.Visible = true;
                        lblNgayHD3.Text = ngayNhap.ToString("yyyy/MM/dd");

                        txtTongTien3.Text = tongTien.ToString();
                        TimeSpan gioNhap;
                        if (TimeSpan.TryParse(row.Cells["gioNhap"].Value.ToString(), out gioNhap))
                        {
                            lblGioHD3.Visible = true;
                            lblGioHD3.Text = gioNhap.ToString(@"hh\:mm\:ss");
                        }




                    }
                }
            }
        }
        //-----------------------------------------------hoa don ban------------------------------------
        //-----------------hoa don ban theo ngay----------------------------------------------------------
        private void ngayHD_ValueChanged(object sender, EventArgs e)
        {

            selectedDate = ngayHD.Value;

            DateTime ngayhd = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);

            DataTable dt = new DataTable();
            dt = hdbbll.GetHoaDonTheoNgay(ngayhd);

            dgvNgayHD.DataSource = dt;
            
        }
     
        private void dgvNgayHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvNgayHD.Rows[e.RowIndex] != null)
                {
                    DataGridViewRow row = dgvNgayHD.Rows[e.RowIndex];

                    if (row.Cells["id"].Value != null)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);

                        DataTable dt = new DataTable();
                        dt = cthdbbll.getChiTietHDBan(id);
                        dgvCTHD4.DataSource = dt;

                        //cấu hình cột cho bảng chi tiêt hóa đơn
                        if (dgvCTHD4.Columns.Contains("id"))
                            dgvCTHD4.Columns["id"].HeaderText = "Mã SP";

                        if (dgvCTHD4.Columns.Contains("ten"))
                            dgvCTHD4.Columns["ten"].HeaderText = "Tên SP";

                        if (dgvCTHD4.Columns.Contains("soLuong"))
                            dgvCTHD4.Columns["soLuong"].HeaderText = "Số lượng";

                        if (dgvCTHD4.Columns.Contains("donGia"))
                            dgvCTHD4.Columns["donGia"].HeaderText = "Đơn giá";

                        if (!dgvCTHD4.Columns.Contains("SoTienTungSP"))
                        {
                            DataGridViewTextBoxColumn soTienTungSanPham = new DataGridViewTextBoxColumn();
                            soTienTungSanPham.Name = "SoTienTungSP";
                            soTienTungSanPham.HeaderText = "Tổng tiền SP";
                            soTienTungSanPham.ValueType = typeof(int);
                            dgvCTHD4.Columns.Add(soTienTungSanPham);
                        }
                    

                        foreach (DataGridViewRow dgvRow in dgvCTHD4.Rows)
                        {
                            if (dgvRow.IsNewRow) continue;

                            int spid = Convert.ToInt32(dgvRow.Cells["id"].Value);
                            int sl = Convert.ToInt32(dgvRow.Cells["soLuong"].Value);
                            int soTienTungSP = cthdbbll.tongTienSPTam(id, spid, sl);
                            dgvRow.Cells["SoTienTungSP"].Value = soTienTungSP;
                        }

                        if (dgvCTHD4.Columns.Contains("Sanpham_NgayHetHan"))
                            dgvCTHD4.Columns["Sanpham_NgayHetHan"].HeaderText = "Ngày hết hạn";

                        ///////////////////////////////
                        string nvid = Convert.ToString(row.Cells["NhanVien_id"].Value);
                        DateTime ngayBan = Convert.ToDateTime(row.Cells["ngayBan"].Value);

                        int makh = Convert.ToInt32(row.Cells["KhachHang_id"].Value);
                        long tongTien = Convert.ToInt64(row.Cells["tongTien"].Value);
                        txtMaHD4.Text = id.ToString();
                        txtMaNV4.Text = nvid.ToString();
                        txtMaKH4.Text = makh.ToString();
                        lblNgayHD4.Visible = true;
                        lblNgayHD4.Text = ngayBan.ToString("yyyy/MM/dd");

                        txtTongTien4.Text = tongTien.ToString();
                        TimeSpan gioBan;
                        if (TimeSpan.TryParse(row.Cells["gioBan"].Value.ToString(), out gioBan))
                        {
                            lblGioHD4.Visible = true;
                            lblGioHD4.Text = gioBan.ToString(@"hh\:mm\:ss");
                        }


                    }
                }
            }
        }
        //------------------------------------hoa don ban theo thang----------------------------------------------
        private void ngayThangHD_ValueChanged(object sender, EventArgs e)
        {
            selectedDate = ngayThangHD.Value;

            DateTime thanghd = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            lblThangHDB.Visible = true;
            lblThangHDB.Text = "Tháng " + thanghd.Month + "/" + thanghd.Year;
            DataTable dt = new DataTable();
            dt = hdbbll.GetHoaDonTheoThang(thanghd);

            dtgHDN5.DataSource = dt;

           
        }
      
        private void dtgHDN5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgHDN5.Rows[e.RowIndex] != null)
                {
                    DataGridViewRow row = dtgHDN5.Rows[e.RowIndex];

                    if (row.Cells["id"].Value != null)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);

                        DataTable dt = new DataTable();
                        dt = cthdbbll.getChiTietHDBan(id);
                        dtgCTHD5.DataSource = dt;

                        //cấu hình cột cho bảng chi tiêt hóa đơn
                        if (dtgCTHD5.Columns.Contains("id"))
                            dtgCTHD5.Columns["id"].HeaderText = "Mã SP";

                        if (dtgCTHD5.Columns.Contains("ten"))
                            dtgCTHD5.Columns["ten"].HeaderText = "Tên SP";

                        if (dtgCTHD5.Columns.Contains("soLuong"))
                            dtgCTHD5.Columns["soLuong"].HeaderText = "Số lượng";

                        if (dtgCTHD5.Columns.Contains("donGia"))
                            dtgCTHD5.Columns["donGia"].HeaderText = "Đơn giá";

                        if (!dtgCTHD5.Columns.Contains("SoTienTungSP"))
                        {
                            DataGridViewTextBoxColumn soTienTungSanPham = new DataGridViewTextBoxColumn();
                            soTienTungSanPham.Name = "SoTienTungSP";
                            soTienTungSanPham.HeaderText = "Tổng tiền SP";
                            soTienTungSanPham.ValueType = typeof(int);
                            dtgCTHD5.Columns.Add(soTienTungSanPham);
                        }


                        foreach (DataGridViewRow dgvRow in dtgCTHD5.Rows)
                        {
                            if (dgvRow.IsNewRow) continue;

                            int spid = Convert.ToInt32(dgvRow.Cells["id"].Value);
                            int sl = Convert.ToInt32(dgvRow.Cells["soLuong"].Value);
                            int soTienTungSP = cthdbbll.tongTienSPTam(id, spid, sl);
                            dgvRow.Cells["SoTienTungSP"].Value = soTienTungSP;
                        }

                        if (dtgCTHD5.Columns.Contains("Sanpham_NgayHetHan"))
                            dtgCTHD5.Columns["Sanpham_NgayHetHan"].HeaderText = "Ngày hết hạn";

                        ///////////////////////////////
                        string nvid = Convert.ToString(row.Cells["NhanVien_id"].Value);
                        DateTime ngayBan = Convert.ToDateTime(row.Cells["ngayBan"].Value);

                        int makh = Convert.ToInt32(row.Cells["KhachHang_id"].Value);
                        long tongTien = Convert.ToInt64(row.Cells["tongTien"].Value);
                        txtMaHD5.Text = id.ToString();
                        txtMaNV5.Text = nvid.ToString();
                        txtMaKH5.Text = makh.ToString();
                        lblNgayHD5.Visible = true;
                        lblNgayHD5.Text = ngayBan.ToString("yyyy/MM/dd");

                        txtTongTien5.Text = tongTien.ToString();
                        TimeSpan gioBan;
                        if (TimeSpan.TryParse(row.Cells["gioBan"].Value.ToString(), out gioBan))
                        {
                            lblGioHD5.Visible = true;
                            lblGioHD5.Text = gioBan.ToString(@"hh\:mm\:ss");
                        }


                    }
                }
            }
        }
        //--------------------------------hoa don ban theo nam----------------------------------------------------------
        private void namHD_ValueChanged(object sender, EventArgs e)
        {
            selectedDate = namHD.Value;

            DateTime namhd = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            lblNamHDB.Visible = true;
            lblNamHDB.Text = "Năm: "+ namhd.Year;
            DataTable dt = new DataTable();
            dt = hdbbll.GetHoaDonTheoNam(namhd);

            dtgHDB6.DataSource = dt;

            
        }
     
     
        private void dtgHDB6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgHDB6.Rows[e.RowIndex] != null)
                {
                    DataGridViewRow row = dtgHDB6.Rows[e.RowIndex];

                    if (row.Cells["id"].Value != null)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);

                        DataTable dt = new DataTable();
                        dt = cthdbbll.getChiTietHDBan(id);
                        dtgCTHD6.DataSource = dt;

                     
                        if (dtgCTHD6.Columns.Contains("id"))
                            dtgCTHD6.Columns["id"].HeaderText = "Mã SP";

                        if (dtgCTHD6.Columns.Contains("ten"))
                            dtgCTHD6.Columns["ten"].HeaderText = "Tên SP";

                        if (dtgCTHD6.Columns.Contains("soLuong"))
                            dtgCTHD6.Columns["soLuong"].HeaderText = "Số lượng";

                        if (dtgCTHD6.Columns.Contains("donGia"))
                            dtgCTHD6.Columns["donGia"].HeaderText = "Đơn giá";

                        if (!dtgCTHD6.Columns.Contains("SoTienTungSP"))
                        {
                            DataGridViewTextBoxColumn soTienTungSanPham = new DataGridViewTextBoxColumn();
                            soTienTungSanPham.Name = "SoTienTungSP";
                            soTienTungSanPham.HeaderText = "Tổng tiền SP";
                            soTienTungSanPham.ValueType = typeof(int);
                            dtgCTHD6.Columns.Add(soTienTungSanPham);
                        }


                        foreach (DataGridViewRow dgvRow in dtgCTHD6.Rows)
                        {
                            if (dgvRow.IsNewRow) continue;

                            int spid = Convert.ToInt32(dgvRow.Cells["id"].Value);
                            int sl = Convert.ToInt32(dgvRow.Cells["soLuong"].Value);
                            int soTienTungSP = cthdbbll.tongTienSPTam(id, spid, sl);
                            dgvRow.Cells["SoTienTungSP"].Value = soTienTungSP;
                        }

                        if (dtgCTHD6.Columns.Contains("Sanpham_NgayHetHan"))
                            dtgCTHD6.Columns["Sanpham_NgayHetHan"].HeaderText = "Ngày hết hạn";

                    
                        string nvid = Convert.ToString(row.Cells["NhanVien_id"].Value);
                        DateTime ngayBan = Convert.ToDateTime(row.Cells["ngayBan"].Value);

                        int makh = Convert.ToInt32(row.Cells["KhachHang_id"].Value);
                        long tongTien = Convert.ToInt64(row.Cells["tongTien"].Value);
                        txtMaHD6.Text = id.ToString();
                        txtMaNV6.Text = nvid.ToString();
                        txtMaKH6.Text = makh.ToString();
                        lblNgayHD6.Visible = true;
                        lblNgayHD6.Text = ngayBan.ToString("yyyy/MM/dd");

                        txtTongTien6.Text = tongTien.ToString();
                        TimeSpan gioNhap;
                        if (TimeSpan.TryParse(row.Cells["gioBan"].Value.ToString(), out gioNhap))
                        {
                            lblGioHD6.Visible = true;
                            lblGioHD6.Text = gioNhap.ToString(@"hh\:mm\:ss");
                        }


                    }
                }
            }
        }

        //---------------------hoa don ban theo ma nhan vien------------------------------------
        private void ngayNVHD_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNVHD2.Text))
            {
                ngayNVHD.Value = new DateTime(2024, 1, 1);
                msg1.Visible = true;
                msg1.Text = "*Vui lòng nhập mã nhân viên";
                msg1.ForeColor = Color.Red;
                txtMaNVHD2.Focus();
            }
            else
            {
                string nvid = txtMaNVHD2.Text;
                if (hdbbll.kiemTraNV(nvid))
                {
                    DateTime ngaynv = new DateTime(ngayNVHD.Value.Year, ngayNVHD.Value.Month, ngayNVHD.Value.Day);
                    msg1.Visible = false;
                    msg1.Text = "";
                    DataTable dt = hdbbll.GetHoaDonTheoMaNVVaNgay(nvid, ngaynv);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dtgHDB8.DataSource = dt;
                       
                    }
                    else
                    {
                        ngayNVHD.Value = new DateTime(2024, 1, 1);
                        msg1.Visible = true;
                        msg1.Text = "*Không có dữ liệu hóa đơn cho nhân viên vào ngày đã chọn";
                        msg1.ForeColor = Color.Red;

                        dtgHDB8.DataSource = null;
                        FrmHoaDon_Load(sender, e);

                    }
                }
                else
                {
                    ngayNVHD.Value = new DateTime(2024, 1, 1);
                    msg1.Visible = true;
                    msg1.Text = "*Không tồn tại nhân viên";
                    msg1.ForeColor = Color.Red;

                    txtMaNVHD2.Focus();

                    dtgHDB8.DataSource = null;

                    FrmHoaDon_Load(sender, e);
                }
            }
        }

        private void dtgHDB8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgHDB8.Rows[e.RowIndex] != null)
                {
                    DataGridViewRow row = dtgHDB8.Rows[e.RowIndex];

                    if (row.Cells["id"].Value != null)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);

                        DataTable dt = new DataTable();
                        dt = cthdbbll.getChiTietHDBan(id);
                        dtgCTHD8.DataSource = dt;

                        if (dtgCTHD8.Columns.Contains("id"))
                            dtgCTHD8.Columns["id"].HeaderText = "Mã SP";

                        if (dtgCTHD8.Columns.Contains("ten"))
                            dtgCTHD8.Columns["ten"].HeaderText = "Tên SP";

                        if (dtgCTHD8.Columns.Contains("soLuong"))
                            dtgCTHD8.Columns["soLuong"].HeaderText = "Số lượng";

                        if (dtgCTHD8.Columns.Contains("donGia"))
                            dtgCTHD8.Columns["donGia"].HeaderText = "Đơn giá";

                        if (!dtgCTHD8.Columns.Contains("SoTienTungSP"))
                        {
                            DataGridViewTextBoxColumn soTienTungSanPham = new DataGridViewTextBoxColumn();
                            soTienTungSanPham.Name = "SoTienTungSP";
                            soTienTungSanPham.HeaderText = "Tổng tiền SP";
                            soTienTungSanPham.ValueType = typeof(int);
                            dtgCTHD8.Columns.Add(soTienTungSanPham);
                        }


                        foreach (DataGridViewRow dgvRow in dtgCTHD8.Rows)
                        {
                            if (dgvRow.IsNewRow) continue;

                            int spid = Convert.ToInt32(dgvRow.Cells["id"].Value);
                            int sl = Convert.ToInt32(dgvRow.Cells["soLuong"].Value);
                            int soTienTungSP = cthdbbll.tongTienSPTam(id, spid, sl);
                            dgvRow.Cells["SoTienTungSP"].Value = soTienTungSP;
                        }

                        if (dtgCTHD8.Columns.Contains("Sanpham_NgayHetHan"))
                            dtgCTHD8.Columns["Sanpham_NgayHetHan"].HeaderText = "Ngày hết hạn";

                    
                        string nvid = Convert.ToString(row.Cells["NhanVien_id"].Value);
                        DateTime ngayBan = Convert.ToDateTime(row.Cells["ngayBan"].Value);

                        int makh = Convert.ToInt32(row.Cells["KhachHang_id"].Value);
                        long tongTien = Convert.ToInt64(row.Cells["tongTien"].Value);
                        txtMaHD8.Text = id.ToString();
                        txtMaNV8.Text = nvid.ToString();
                        txtMaKH8.Text = makh.ToString();
                        lblNgayHD8.Visible = true;
                        lblNgayHD8.Text = ngayBan.ToString("yyyy/MM/dd");

                        txtTongTien8.Text = tongTien.ToString();
                        TimeSpan gioNhap;
                        if (TimeSpan.TryParse(row.Cells["gioBan"].Value.ToString(), out gioNhap))
                        {
                            lblGioHD8.Visible = true;
                            lblGioHD8.Text = gioNhap.ToString(@"hh\:mm\:ss");
                        }


                    }
                }
            }
            }

        //------------------------------hoa don ban theo sdt khach hang ------------------------------
        public bool checkSDT(string sdt)
        {
            
            if (sdt.Length == 10 && long.TryParse(sdt, out long phoneNumber))
            {
               
                return hdbbll.checkHD(sdt);
            }
            else
            {
              
                return false;
            }
        }
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text;
            
            if (checkNumer(sdt) && sdt.Length == 10)
            {
                lblmesssdt.Visible = false;
                DataTable dt = hdbbll.GetHoaDonTheoSDT(sdt);
                dtgHDB7.DataSource = dt;

            }
            else
            {
                dtgHDB7.DataSource = null;
            }

            //if (sdt.Length == 10)
            //{
            //    if (checkSDT(sdt))
            //    {
            //        lblmesssdt.Visible = false; 
            //        DataTable dt = hdbbll.GetHoaDonTheoSDT(sdt); 
            //        dtgHDB7.DataSource = dt; 
            //    }
            //    else
            //    {
            //        lblmesssdt.Visible = true;
            //        lblmesssdt.Text = "Số điện thoại không hợp lệ hoặc không tồn tại khách hàng";
            //        txtSDT.Clear();
            //        txtSDT.Focus();
            //    }
            //}
            //else
            //{
            //    lblmesssdt.Visible =true; // Ẩn thông báo lỗi khi số điện thoại chưa đủ 10 chữ số
            //}
        }
        private bool checkNumer(string s)
        {
            if (s.Length == 0) return false;
            if (txtSDT.Text[0] != '0') return false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            return true;
        }

        private void dtgHDB7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgHDB7.Rows[e.RowIndex] != null)
                {
                    DataGridViewRow row = dtgHDB7.Rows[e.RowIndex];

                    if (row.Cells["id"].Value != null)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);

                        DataTable dt = new DataTable();
                        dt = cthdbbll.getChiTietHDBan(id);
                        dtgCTHD7.DataSource = dt;

                  
                        if (dtgCTHD7.Columns.Contains("id"))
                            dtgCTHD7.Columns["id"].HeaderText = "Mã SP";

                        if (dtgCTHD7.Columns.Contains("ten"))
                            dtgCTHD7.Columns["ten"].HeaderText = "Tên SP";

                        if (dtgCTHD7.Columns.Contains("soLuong"))
                            dtgCTHD7.Columns["soLuong"].HeaderText = "Số lượng";

                        if (dtgCTHD7.Columns.Contains("donGia"))
                            dtgCTHD7.Columns["donGia"].HeaderText = "Đơn giá";

                        if (!dtgCTHD7.Columns.Contains("SoTienTungSP"))
                        {
                            DataGridViewTextBoxColumn soTienTungSanPham = new DataGridViewTextBoxColumn();
                            soTienTungSanPham.Name = "SoTienTungSP";
                            soTienTungSanPham.HeaderText = "Tổng tiền SP";
                            soTienTungSanPham.ValueType = typeof(int);
                            dtgCTHD7.Columns.Add(soTienTungSanPham);
                        }


                        foreach (DataGridViewRow dgvRow in dtgCTHD7.Rows)
                        {
                            if (dgvRow.IsNewRow) continue;

                            int spid = Convert.ToInt32(dgvRow.Cells["id"].Value);
                            int sl = Convert.ToInt32(dgvRow.Cells["soLuong"].Value);
                            int soTienTungSP = cthdbbll.tongTienSPTam(id, spid, sl);
                            dgvRow.Cells["SoTienTungSP"].Value = soTienTungSP;
                        }

                        if (dtgCTHD7.Columns.Contains("Sanpham_NgayHetHan"))
                            dtgCTHD7.Columns["Sanpham_NgayHetHan"].HeaderText = "Ngày hết hạn";

                 
                        string nvid = Convert.ToString(row.Cells["NhanVien_id"].Value);
                        DateTime ngayBan = Convert.ToDateTime(row.Cells["ngayBan"].Value);

                        int makh = Convert.ToInt32(row.Cells["KhachHang_id"].Value);
                        long tongTien = Convert.ToInt64(row.Cells["tongTien"].Value);
                        txtMaHD7.Text = id.ToString();
                        txtMaNV7.Text = nvid.ToString();
                        txtMaKH7.Text = makh.ToString();
                        lblNgayHD7.Visible = true;
                        lblNgayHD7.Text = ngayBan.ToString("yyyy/MM/dd");

                        txtTongTien7.Text = tongTien.ToString();
                        TimeSpan gioNhap;
                        if (TimeSpan.TryParse(row.Cells["gioBan"].Value.ToString(), out gioNhap))
                        {
                            lblGioHD7.Visible = true;
                            lblGioHD7.Text = gioNhap.ToString(@"hh\:mm\:ss");
                        }


                    }
                }
            }
        }
    }
}