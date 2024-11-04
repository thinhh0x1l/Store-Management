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
using WindowsFormsApp1.DAO;
using System.Data.SqlTypes;
using System.Web.UI.WebControls;
namespace WindowsFormsApp1
{
    public partial class FrmNhapHang : Form
    {   
        public int hoaDonId = -1;
        public SanPhamBLL spbll;
        int[] sum = new int[1000];
        int index = 0;
        int soLuong = 0;
        string ngayLap = "";
        string gioLap = "";
        long tongTien = 0;
       string  manv;
     //   List<SanPhamNCCDTO> lstspncc;
        public FrmNhapHang()
        {
            InitializeComponent();
            manv = getNameNhanVien();
            txtMaNV.Text = getNameNhanVien();
            timer1.Start();
        }
        private string getNameNhanVien()
        {
            if (Login.tenNV.ToLower() == "admin")
                return "nv0";
            return Login.tenNV;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            txtGioLap.Text = DateTime.Now.ToLongTimeString();
            txtNgayLap.Text = DateTime.Now.ToString("yyyy/MM/dd");
            gioLap = txtGioLap.Text;
            ngayLap = txtNgayLap.Text;
        }

        public SanPhamNCCBLL spncc;
        public LoaiSanPhamBLL loaisp;
        public SanPhamNCCDTO spdto;
        public HoaDonNhapBLL hdn;
        public ChiTietHoaDonNhapBLL cthd;
        public DataConnect da=new DataConnect();
        public List<ChiTietHoaDonNhapDTO> danhSachChiTietHoaDon;
        public List<ListSPTam> listSPTam;



        public void loadSanPham()
        {
            dtgSpNCC.DataSource = spncc.GetAllSanPhamNCC();
          
         
            if (dtgSpNCC.Columns.Contains("urlAnh"))
            {
                DataGridViewImageColumn imageColumn = dtgSpNCC.Columns["urlAnh"] as DataGridViewImageColumn;
                if (imageColumn != null)
                {
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dtgSpNCC.Columns["urlAnh"].Width = 100;
                }
            }

            dtgSpNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgSpNCC.ClearSelection();
        }
        public void loadLoaiSP()
        {
            cbbLoaiSP.DataSource = loaisp.getLoaiSanPham();
            cbbLoaiSP.DisplayMember = "ten";
            cbbLoaiSP.ValueMember = "id";
          
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
          //  lstspncc = new List<SanPhamNCCDTO>();
            spncc = new SanPhamNCCBLL();
            loaisp = new LoaiSanPhamBLL();
            spdto = new SanPhamNCCDTO();
            hdn = new HoaDonNhapBLL();
            cthd = new ChiTietHoaDonNhapBLL();
            da = new DataConnect();
            danhSachChiTietHoaDon = new List<ChiTietHoaDonNhapDTO>();
            listSPTam = new List<ListSPTam>();
            spbll = new SanPhamBLL();
            sum = new int[1000];

            setOne();
            loadSanPham();
            loadLoaiSP();

            dtgSpNCC.ClearSelection();
            dtgSpNCC.CurrentCell = null;

            dtgHDN.DataBindings.Clear();
            dtgSpNCC.ClearSelection();
            dtgSpNCC.CurrentCell = null;
        }


        private void cbbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                object selectedValue = cbbLoaiSP.SelectedValue;
                int selectedCategoryId;
                dtgSpNCC.ClearSelection();

               
                if (selectedValue != null && int.TryParse(selectedValue.ToString(), out selectedCategoryId))
                {
                    DataTable dtProducts = (DataTable)dtgSpNCC.DataSource;
                    if (dtProducts != null)
                    {
                        DataView dv = dtProducts.DefaultView;
                        if (selectedCategoryId == 0) 
                        {
                           
                            dv.RowFilter = string.Empty;
                        }
                        else
                        {
                            dv.RowFilter = $"LoaiSanPham_id = {selectedCategoryId}";
                        }
                    }

                }
              
            }
            catch (Exception ex) { }

        }

        public int id;
        private void dtgSpNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dtgSpNCC.SelectedRows.Count == 0)
                return;

            if (hoaDonId == -1)
            {
                hoaDonId = hdn.getId() + 1;
                txtMaHD.Text = hoaDonId.ToString();
                id = hoaDonId;
            }

            if (e.RowIndex >= 0)
            {
                if (dtgSpNCC.Rows[e.RowIndex] != null)
                {
                    DataGridViewRow row = dtgSpNCC.Rows[e.RowIndex];
                    if (row.Cells["id"].Value != null && row.Cells["ten"].Value != null && row.Cells["ngayHetHan"].Value != null)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);
                        string ten = row.Cells["ten"].Value.ToString();
                        DateTime ngayHetHan = Convert.ToDateTime(row.Cells["ngayHetHan"].Value);
                        int lsp= Convert.ToInt32(row.Cells["LoaiSanPham_id"].Value);
                        byte[] anh = (byte[])(row.Cells["urlAnh"].Value);
                        // Kiểm tra sản phẩm đã có trong danh sách chi tiết hóa đơn hay chưa
                        bool sanPhamDaChon = danhSachChiTietHoaDon.Any(sp => sp.SanPhamNCC_id == id);
                       
                        if (sanPhamDaChon)
                        {
                            MessageBox.Show("Sản phẩm này đã được thêm vào hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return; // Dừng lại nếu sản phẩm đã có
                        }
                        //Kiểm tra sản phẩm có cần nhập thêm hay không nếu vừa tồn tại trạng thái 1 và 2
                        bool trangThaiSP = spbll.checkTT(id);
                        if (trangThaiSP)
                        {
                            MessageBox.Show("Sản phẩm này đã nhập đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        

                        // Nếu sp chưa có trong chi tiết hóa đơn và chưa có tt2
                        spdto = new SanPhamNCCDTO(id, ten, ngayHetHan);
                        
                       danhSachChiTietHoaDon = cthd.addChiTietHDList(hoaDonId, spdto);

                        // Hiển thị chi tiết hóa đơn ra DataGridView
                        DataTable dt = cthd.ChuyenListToDataTable(danhSachChiTietHoaDon);
                        dtgHDN.DataSource = dt;
                        // them cho hoa don nhap
                        configDtgHDN();



                        txtTongTien.Text = tongTienHoaDon().ToString();

                    }
                }
            }
        }

        public void setOne()
        {
            for(int i = 0; i < sum.Length; i++)
            {
                sum[i] = 1;
            }
        }

        int i = 0;
        public void configDtgHDN()
        {


            // Thêm cột ten sp nếu chưa có
            if (!dtgHDN.Columns.Contains("Tên Sản Phẩm"))
            {
                DataGridViewTextBoxColumn tenSanPham = new DataGridViewTextBoxColumn();
                tenSanPham.Name = "Tên Sản Phẩm";
                tenSanPham.HeaderText = "Tên Sản Phẩm";
                tenSanPham.ValueType = typeof(string);
                dtgHDN.Columns.Add(tenSanPham);
            }


            foreach (DataGridViewRow dgvRow in dtgHDN.Rows)
            {
                if (dgvRow.IsNewRow) continue;

                int spid = Convert.ToInt32(dgvRow.Cells["Mã Sản Phẩm"].Value);
                string ten = spncc.getTenByID(spid);
                dgvRow.Cells["Tên Sản Phẩm"].Value = ten;
            }
            //them cot don gia neu chua co
            if (!dtgHDN.Columns.Contains("Đơn giá"))
            {
                DataGridViewTextBoxColumn donGia = new DataGridViewTextBoxColumn();
                donGia.Name = "Đơn Giá";
                donGia.HeaderText = "Đơn Giá";
                donGia.ValueType = typeof(int);
                dtgHDN.Columns.Add(donGia);
            }


            foreach (DataGridViewRow dgvRow in dtgHDN.Rows)
            {
                if (dgvRow.IsNewRow) continue;

                int spid = Convert.ToInt32(dgvRow.Cells["Mã Sản Phẩm"].Value);
                int dongia = spncc.getDonGia(spid);
                dgvRow.Cells["Đơn Giá"].Value = dongia;
            }

            // Thêm cột SoTienTungSP nếu chưa có
            if (!dtgHDN.Columns.Contains("SoTienTungSP"))
            {
                DataGridViewTextBoxColumn soTienTungSanPham = new DataGridViewTextBoxColumn();
                soTienTungSanPham.Name = "SoTienTungSP";
                soTienTungSanPham.HeaderText = "Tổng tiền SP";
                soTienTungSanPham.ValueType = typeof(int);
                dtgHDN.Columns.Add(soTienTungSanPham);
                //  dtgHDN.Columns["SoTienTungSP"].HeaderCell.Style.ForeColor = Color.Red;
            }

            // Cập nhật giá trị cột SoTienTungSP
            foreach (DataGridViewRow dgvRow in dtgHDN.Rows)
            {
                //if (dgvRow.IsNewRow) continue;

                int spid = Convert.ToInt32(dgvRow.Cells["Mã Sản Phẩm"].Value);
                int soTienTungSP = cthd.tongTienSPTam(hoaDonId, spid, sum[dgvRow.Index]);
                dgvRow.Cells["SoTienTungSP"].Value = soTienTungSP;

                dgvRow.Cells["SoTienTungSP"].Style.ForeColor = Color.Red;

            }

        }
       

        

        public void configDeleteDtgHDN()
        {

            if (dtgHDN.Columns.Contains("Tên Sản Phẩm"))
            {
                dtgHDN.Columns.Remove("Tên Sản Phẩm");
            }
            if (dtgHDN.Columns.Contains("Đơn Giá"))
            {
                dtgHDN.Columns.Remove("Đơn Giá");
            }
            if (dtgHDN.Columns.Contains("SoTienTungSP"))
            {
                dtgHDN.Columns.Remove("SoTienTungSP");
            }
        }
            private void dtgHDN_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.ColumnIndex == dtgHDN.Columns["Số Lượng"].Index && e.RowIndex >= 0)
            {

                DataGridViewRow row = dtgHDN.Rows[e.RowIndex];
                int soLuongMoi = Convert.ToInt32(row.Cells["Số Lượng"].Value);
                int spId = Convert.ToInt32(row.Cells["Mã Sản Phẩm"].Value);
                sum[e.RowIndex]= soLuongMoi;
                cthd.capNhatSoLuongCTHD(hoaDonId, spId, soLuongMoi);

            int spid = Convert.ToInt32(dtgHDN.Rows[e.RowIndex].Cells["Mã Sản Phẩm"].Value);
            int soTienTungSP = cthd.tongTienSPTam(hoaDonId, spid, soLuongMoi);
            dtgHDN.Rows[e.RowIndex].Cells["SoTienTungSP"].Value = soTienTungSP;


            txtTongTien.Text = tongTienHoaDon().ToString();

            }
        }

        public long  tongTienHoaDon()
        {
          
            tongTien = cthd.tinhTongTienCTHD(danhSachChiTietHoaDon);
            txtTongTien.Text = tongTien.ToString();
            return tongTien;
        }

        public int tongSLSPCTHD()
        {
            return cthd.tongSLCTHD(danhSachChiTietHoaDon);
        }

        private bool UpdateSoLuongSP()
        {
            if (dtgHDN.DataSource == null) return false;//

            bool result = false;
            foreach (DataGridViewRow dgvRow in dtgHDN.Rows)
            {
                if (dgvRow.IsNewRow) continue;
                int spId = Convert.ToInt32(dgvRow.Cells["Mã Sản Phẩm"].Value);
                DateTime ngayHetHan = Convert.ToDateTime(dgvRow.Cells["Ngày Hết Hạn"].Value);
                int soLuongMoi = Convert.ToInt32(dgvRow.Cells["Số Lượng"].Value);
                bool success = cthd.capNhatsLSP(hoaDonId, spId, soLuongMoi,ngayHetHan);
                if (!success)
                {
                    MessageBox.Show($"Cập nhật số lượng cho sản phẩm {spId} không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                result = success;
            }
            return result;

        }
        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {

            txtTongTien.Text = "";
            danhSachChiTietHoaDon.Clear();
            danhSachChiTietHoaDon = new List<ChiTietHoaDonNhapDTO>();

            dtgHDN.DataBindings.Clear();

            setOne();

            dtgHDN.DataSource = null;
            configDeleteDtgHDN();


        }
        private void btn_xacnhan_hdnhap_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
         //   dt=(DataTable)dtgHDN.DataSource;
            soLuong = tongSLSPCTHD();
            tongTien = tongTienHoaDon();
            FrmHoaDonNhap frmHoaDonNhap = new FrmHoaDonNhap();
            frmHoaDonNhap.LoadData(danhSachChiTietHoaDon, hoaDonId,manv, ngayLap, gioLap, hoaDonId, tongTien, soLuong);
            
            //cap nhat so luong san pham
            if(UpdateSoLuongSP())
                frmHoaDonNhap.ShowDialog();
            else
            {
                MessageBox.Show("Tạo hóa đơn không thành công");
            }
           
            dtgHDN.DataSource = null;
            configDeleteDtgHDN();
            danhSachChiTietHoaDon.Clear();
            hoaDonId = -1;
            txtTongTien.Text = "";

         

        }

    }

}


    






    


    //


