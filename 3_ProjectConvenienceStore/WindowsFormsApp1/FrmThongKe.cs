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
using WindowsFormsApp1.DTO;
namespace WindowsFormsApp1
{
    public partial class FrmThongKe : Form
    {
        HoaDonBanBLL hdbbll;
        HoaDonNhapBLL hdnbll;
        List<HoaDonBanDTO> listhdbTHeoNgay;
        List<DoanhThu> doanhthulst;
        SanPhamBLL spbll;
        public FrmThongKe()
        {
            InitializeComponent();
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            hdbbll = new HoaDonBanBLL();
            hdnbll = new HoaDonNhapBLL();
            listhdbTHeoNgay =new List<HoaDonBanDTO>();
            doanhthulst=new List<DoanhThu>();
            spbll=new SanPhamBLL();
           
        }

        public DataTable doanhThu(List<DoanhThu> dt)
        {
            DataTable dtable = new DataTable();
            dtable.Columns.Add("Tổng thu", typeof(long));
            dtable.Columns.Add("Vốn", typeof(long));
            dtable.Columns.Add("Lãi", typeof(long));
            foreach (DoanhThu doanhthu in dt)
            {
                DataRow row =dtable.NewRow();
                row["Tổng thu"]=doanhthu.tongThu;
                row["Vốn"] = doanhthu.von;
                row["Lãi"] = doanhthu.lai;

                dtable.Rows.Add(row);
            }
            return dtable;
        }
        private void DTNgay_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate= new DateTime();
            selectedDate = DTNgay.Value;
            DateTime ngayhd = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);
         
            lblNgay.Text= "Ngày "+ngayhd.Year+"/"+ngayhd.Month+"/"+ngayhd.Day;
            lblNgay.Visible = true;
            //tinh doanh thu trong ngay
            long tongThu = hdbbll.tongThuTheoNgay(ngayhd);
            if (tongThu == 0)
            {
                listhdbTHeoNgay.Clear();
                dtgDTNgay.DataSource = null;
                lblmess.Text = "* Ngày được chọn không có dữ liệu";
                lblmess.Visible = true;
                return;
             
            }

            //lay cac hoa don trong ngay
            DataTable hdb=new DataTable();
            hdb = hdbbll.GetHoaDonTheoNgay(ngayhd);
            if (hdb != null)
            {
                lblmess.Visible = false;
                listhdbTHeoNgay = hdbbll.listHDBTheoNgay(hdb);
                dtgDTNgay.DataSource = null;

                //tinh chi phi nhap dua tren gia nhap cua san pham trong chi tiet hoa don
                long von = hdbbll.tongPhiNhapSP(listhdbTHeoNgay);
                long lai = tongThu - von;
                DoanhThu doanhthu = new DoanhThu(tongThu, von, lai);
                doanhthulst.Add(doanhthu);
                DataTable dataTable = new DataTable();
                dataTable = doanhThu(doanhthulst);
                dtgDTNgay.DataSource = dataTable;
                doanhthulst.Clear();
            }
            else
            {
               
                dtgDTNgay.DataSource = null;
                lblmess.Text = "* Ngày được chọn không có dữ liệu";
                lblmess.Visible = true;
                return;

            }
        }

        private void DTThang_ValueChanged(object sender, EventArgs e)
        {
            
          
            DateTime thanghd = new DateTime(DTThang.Value.Year, DTThang.Value.Month, DTThang.Value.Day);
           
            long tongthu = 0;
            long tongvon = 0;
            long tonglai = 0;
            
            //lay datatable ngay hoa don, tong thu theo ngay

            DataTable dt=new DataTable();
            dt = hdbbll.ThongKeDoanhThuTheoThang(thanghd);//lay duoc cac ngay hoa don va tong thu
            dtgDTThang.DataSource = dt;

            if (!dtgDTThang.Columns.Contains("Vốn"))
            {
                DataGridViewTextBoxColumn von = new DataGridViewTextBoxColumn();
                von.Name = "Vốn";
                von.HeaderText = "Vốn";
                von.ValueType = typeof(long);
                dtgDTThang.Columns.Add(von);
            }
            if (!dtgDTThang.Columns.Contains("Lãi"))
            {
                DataGridViewTextBoxColumn lai = new DataGridViewTextBoxColumn();
                lai.Name = "Lãi";
                lai.HeaderText = "Lãi";
                lai.ValueType = typeof(long);
                dtgDTThang.Columns.Add(lai);
            }

            foreach (DataGridViewRow row in dtgDTThang.Rows)
            {
                if (row.IsNewRow) continue;

                long von = hdbbll.TongChiPhiNhapTheoNgay(Convert.ToDateTime(row.Cells["Ngay"].Value));
                tongvon += von;
                long lai = Convert.ToInt64(row.Cells["DoanhThu"].Value) - von;
                tonglai += lai;
                tongthu += Convert.ToInt64(row.Cells["DoanhThu"].Value);
                row.Cells["Vốn"].Value = von;
                row.Cells["Lãi"].Value = lai;
            }
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lblThang.Visible = true;
            txtTTThang.Visible = true;
            txtTVThang.Visible = true;
            txtTLThang.Visible = true;
            lblThang.Text = "Tháng " + thanghd.Month + "/" + thanghd.Year;
            txtTTThang.Text = tongthu.ToString();
            txtTVThang.Text = tongvon.ToString();
            txtTLThang.Text = tonglai.ToString();


        }

        private void DTNam_ValueChanged(object sender, EventArgs e)
        {
           
           
            DateTime namhd = new DateTime(DTNam.Value.Year, DTNam.Value.Month, DTNam.Value.Day);
            int nam = namhd.Year;
            long tongthu = 0;
            long tongvon = 0;
            long tonglai = 0;
        

            DataTable dt = new DataTable();
            dt = hdbbll.ThongKeDoanhThuTheoNam(namhd);//lay duoc cac ngay hoa don va tong thu
            dtgDTNam.DataSource = dt;

            if (!dtgDTNam.Columns.Contains("Vốn"))
            {
                DataGridViewTextBoxColumn von = new DataGridViewTextBoxColumn();
                von.Name = "Vốn";
                von.HeaderText = "Vốn";
                von.ValueType = typeof(long);
                dtgDTNam.Columns.Add(von);
            }
            if (!dtgDTNam.Columns.Contains("Lãi"))
            {
                DataGridViewTextBoxColumn lai = new DataGridViewTextBoxColumn();
                lai.Name = "Lãi";
                lai.HeaderText = "Lãi";
                lai.ValueType = typeof(long);
                dtgDTNam.Columns.Add(lai);
            }

            foreach (DataGridViewRow row in dtgDTNam.Rows)
            {
                if (row.IsNewRow) continue;

                long von = hdbbll.TongChiPhiNhapTheoThang(Convert.ToInt32(row.Cells["Thang"].Value),nam);
                tongvon += von;
                long lai = Convert.ToInt64(row.Cells["DoanhThu"].Value) - von;
                tonglai += lai;
                tongthu += Convert.ToInt64(row.Cells["DoanhThu"].Value);
                row.Cells["Vốn"].Value = von;
                row.Cells["Lãi"].Value = lai;
            }
            lbl4.Visible = true;
            lbl5.Visible = true;
            lbl6.Visible = true;
            lblNam.Visible = true;
            txtTTNam.Visible = true;
            txtTVNam.Visible = true;
            txtTLNam.Visible = true;
            lblNam.Text = "Năm " + namhd.Year;
            txtTTNam.Text = tongthu.ToString();
            txtTVNam.Text = tongvon.ToString();
            txtTLNam.Text = tonglai.ToString();
        }

     
        private void TKThang_ValueChanged(object sender, EventArgs e)
        {
            DateTime thanghd = new DateTime(TKThang.Value.Year, TKThang.Value.Month, TKThang.Value.Day);
            DataTable dt = new DataTable();
            dt = hdbbll.sanPhamBanChay(thanghd);//lay duoc cac ngay hoa don va tong thu
            dtgSPBanChay.DataSource = dt;
            lblThangTK.Text = "Tháng " + thanghd.Month + "/" + thanghd.Year;
            lblThangTK.Visible = true;
            loadSanPham();
        }
        public void loadSanPham()
        {

            if (dtgSPBanChay.Columns.Contains("urlAnh"))
            {
                DataGridViewImageColumn imageColumn = dtgSPBanChay.Columns["urlAnh"] as DataGridViewImageColumn;
                if (imageColumn != null)
                {
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dtgSPBanChay.Columns["urlAnh"].Width = 100;
                }
            }

            dtgSPBanChay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
     
        private void tabControl3_Selected(object sender, TabControlEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = spbll.sanPhamHH();
            dtgHetHang.DataSource = dt;

            loadSanPham1();
            

        }
        public void loadSanPham1()
        {

            if (dtgHetHang.Columns.Contains("urlAnh"))
            {
                DataGridViewImageColumn imageColumn = dtgHetHang.Columns["urlAnh"] as DataGridViewImageColumn;
                if (imageColumn != null)
                {
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dtgHetHang.Columns["urlAnh"].Width = 100;
                }
            }

            dtgHetHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
       

        private void SPNThang_ValueChanged(object sender, EventArgs e)
        {
            DateTime thang = new DateTime(SPNThang.Value.Year, SPNThang.Value.Month, SPNThang.Value.Day);
            lblSPNThang.Visible = true;
            lblSPNThang.Text = "Tháng nhập: " + thang.Month + "/" + thang.Year;
            DataTable dt=new DataTable();
            dt = hdnbll.GetSPNhapNhieuTheoThang(thang);
            dtgSPN.DataSource = dt;
            loadSanPham2();
           

        }
        public void loadSanPham2()
        {

            if (dtgSPN.Columns.Contains("urlAnh"))
            {
                DataGridViewImageColumn imageColumn = dtgSPN.Columns["urlAnh"] as DataGridViewImageColumn;
                if (imageColumn != null)
                {
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dtgSPN.Columns["urlAnh"].Width = 100;
                }
            }

            dtgSPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dtgDTNgay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgDTNam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
