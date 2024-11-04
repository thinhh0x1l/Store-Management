using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DTO;
namespace WindowsFormsApp1
{
    public partial class frmBanHang : Form
    {
        KhachHangBLL khachHangBLL;
        ChiTietHoaDonBLL chiTietHoaDonBLL;
        HoaDonBanBLL HoaDonBanBLL;
        LoaiSanPhamBLL lspbll = new LoaiSanPhamBLL();
        SanPhamBLL spbll ;

        SanPham sp;
        SPThanhToan SPThanhToan;
        Hashtable hashtb;
        Hashtable htGioHang;
        int createHoaDonBan_id;
        NumberFormatInfo numberFormat = new NumberFormatInfo
        {
            NumberGroupSeparator = "."    // Ký tự phân cách hàng nghìn
        };
        public frmBanHang()
        {
            InitializeComponent();
            timer1.Start();
            txtNV.Text = getNameNhanVien();
        }
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            
            khachHangBLL = new KhachHangBLL();
            chiTietHoaDonBLL = new ChiTietHoaDonBLL();
            HoaDonBanBLL = new HoaDonBanBLL();
            spbll = new SanPhamBLL();;
            hashtb = new Hashtable();
            htGioHang = new Hashtable();
            GioHang = new List<SPThanhToan>();
            SPban = new List<SanPham>();
            lbTongTien.Text = "0";
            txtHoaDon.Text = HoaDonBanBLL.getNextOrderId().ToString();
            createHoaDonBan_id = HoaDonBanBLL.getNextOrderId();
            GetData();
            if (txtSDT.Text.Length == 10 && checkNumer(txtSDT.Text))
            { 
                txtDiem.Text = khachHangBLL.getTypeOfName(txtSDT.Text, "tichDiem");
                diem = Convert.ToInt32(txtDiem.Text);
                diemConLai = diem;
                giamTien();
                txtTienKH.FillColor = Color.LemonChiffon;
            }
            lbGiam.Text = "0";
            lbTienThua.Text = "0";
            txtTienKH.Text = "";
            arr = new int[1000];

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtGioLap.Text = DateTime.Now.ToLongTimeString();
            txtNgayLap.Text = DateTime.Now.ToLongDateString();
           
        }
       
        private void GetData()
        {
            txtTimKiem.Text = "";
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            List<SanPhamDTO> list = spbll.getLoaiSanPham1();
            for (int i = 0; i < list.Count; i++)
                if (list[i].soLuong > 0 && list[i].ngayHetHan > DateTime.Now)
                {
                    sp = new SanPham(list[i].id.ToString(), list[i].urlAnh, list[i].ten, list[i].soLuong, list[i].donGia, OnClick); 
                    flowLayoutPanel1.Controls.Add(sp);
                    
                    SPban.Add(sp);
                    hashtb.Add(list[i].id.ToString(), list[i]);
                }    
        }
        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {            
            flowLayoutPanel1.Controls.Clear();       
            for (int i = 0; i < SPban.Count; i++)
            {
               if (SPban[i].getName().ToLower().Contains(txtTimKiem.Text.ToLower()))
                    flowLayoutPanel1.Controls.Add(SPban[i]);
            }
        }
        int[] arr;
        public void OnClick(object sender, EventArgs e)
        {
            if (sender is SPThanhToan)
            {
                string tag = ((SPThanhToan)sender).Tag.ToString();
               
                try
                {
                    SPThanhToan ban = htGioHang[tag] as SPThanhToan;
                    flowLayoutPanel2.Controls.Remove(ban);
                    GioHang.Remove(ban);
                    htGioHang.Remove(tag);
                    lbTongTien.Text = (Convert.ToInt64(lbTongTien.Text) - ban.tong).ToString();
                    
                    arr[System.Convert.ToInt32(tag)] = 0;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                string tag = ((SanPham)sender).Tag.ToString();
                if (arr[System.Convert.ToInt32(tag)] != 0)
                    return;
                else
                {
                    List<SanPhamDTO> list = spbll.getLoaiSanPham1();
                    SanPhamDTO sanPham = hashtb[tag] as SanPhamDTO;
                    lbTongTien.Text = (long.Parse(lbTongTien.Text) + sanPham.donGia).ToString();
                    SPThanhToan = new SPThanhToan(sanPham.ngayHetHan,tag, sanPham.urlAnh, sanPham.id, sanPham.ten, sanPham.soLuong, sanPham.donGia, OnClick, ban_TextChanged, MyUserControl_TextBoxMouseClick);
                    flowLayoutPanel2.Controls.Add(SPThanhToan);
                    GioHang.Add(SPThanhToan);
                    htGioHang.Add(tag,SPThanhToan);
                    arr[System.Convert.ToInt32(tag)] = 1;          
                }
                
            }

        }
        long tongBan;
        private void MyUserControl_TextBoxMouseClick(object sender, EventArgs e)
        {
            SPThanhToan ban = sender as SPThanhToan;
            tongBan = ban.tong;

        }
        private void ban_TextChanged(object sender, EventArgs e)
        {
            SPThanhToan ban = (SPThanhToan)sender;
            try
            {
                lbTongTien.Text = (long.Parse(lbTongTien.Text, numberFormat) - tongBan).ToString();
                lbTongTien.Text = (long.Parse(lbTongTien.Text, numberFormat) + ban.tong).ToString();
                tongBan = ban.tong;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private long TongThanhTien()
        {
            long tong = 0;
            
            for (int i = 0; i < GioHang.Count; i++)
                tong += GioHang[i].tong;
            return tong;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!kiemTraGioHang())
                return;
            if (!HoaDonBanBLL.insertHoaDonBan(getNameNhanVien(), khachHang_id, Convert.ToInt32(lbTongTien.Text)))
                return;
            for (int i  = 0; i < GioHang.Count; i++)
            {
                spbll.updateSoLuongSanPham(GioHang[i].lbID.Text, GioHang[i].txtSoLuong.Text);
            }
            insertChiTietHoaDonBan();
            try
            {
                SanPhamBLL.setListSPThanhToan(GioHang);
                khachHangBLL.updateDiemKhachHang(khachHang_id, (Convert.ToInt32(lbThanhTien.Text) / 1000 ) + diemConLai);
                HoaDonBan hd = new HoaDonBan(txtHoaDon.Text, getNameNhanVien(),txtLastName.Text +" "+ txtFirstName.Text, lbThanhTien.Text, txtTienKH.Text,lbTienThua.Text, (Convert.ToInt32(lbThanhTien.Text) / 1000).ToString(), DateTime.Now);
                HoaDonBanBLL.setHoaDonBan(hd);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
            new FrmPhieuThanhDon().ShowDialog();
            
            frmBanHang_Load(sender, e);
        }
        private string getNameNhanVien()
        {
            if(Login.tenNV.ToLower() == "admin")
                return "nv0";
            return Login.tenNV;
        }

        private bool checkNumer(string s)
        {
            if(s.Length == 0) return false;
            if (txtSDT.Text[0] != '0' ) return false;
                for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            return true;
        }
        private void insertChiTietHoaDonBan()
        {
            for(int i = 0; i < GioHang.Count; i++)
            {
                chiTietHoaDonBLL.insertChiTietHoaDonBan(
                    createHoaDonBan_id,
                    Convert.ToInt32(GioHang[i].lbID.Text),
                    Convert.ToInt32(GioHang[i].txtSoLuong.Text),
                    GioHang[i].ngayHetHanSP()
                    );
            }
        }
        List<SPThanhToan> GioHang ;
        List<SanPham> SPban ;
        int khachHang_id = 0;
        int diem;
        int diemConLai;
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if(txtSDT.Text.Length == 10 && checkNumer(txtSDT.Text))
            {
                    txtSDT.FillColor = Color.FromArgb(192, 255, 255);
                    txtFirstName.Text = khachHangBLL.getTypeOfName(txtSDT.Text, "ten");
                    txtLastName.Text = khachHangBLL.getTypeOfName(txtSDT.Text, "ho");
                    txtDiem.Text = khachHangBLL.getTypeOfName(txtSDT.Text, "tichDiem");
                    khachHang_id = Convert.ToInt32(khachHangBLL.getTypeOfName(txtSDT.Text, "id").ToString());
                    
                    if (txtFirstName.Text == "")
                        btnTaoKHMoi.Enabled = true;
                    else
                   {
                        txtFirstName.ReadOnly = true;
                        txtLastName.ReadOnly = true;
                        btnTaoKHMoi.Enabled = false;
                        diem = Convert.ToInt32(txtDiem.Text);
                        diemConLai = diem;
                        txtTienKH.ReadOnly = false;
                        txtTienKH.FillColor = Color.LemonChiffon;
                    }
                    giamTien();
               
            }
            else
            {
                resetKH();
                lbGiam.Text = "0";
            }
        }

        private void resetKH()
        {
            if (btnTaoKHMoi.BackColor == Color.BlanchedAlmond)
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtDiem.Text = "";
                diem = diemConLai = 0;
                khachHang_id = 0;
                txtFirstName.FillColor = Color.White;
                txtLastName.FillColor = Color.White;
            }
            lbThanhTien.Text = lbTongTien.Text;
            if (txtSDT.Text.Length != 10)
            {
                btnTaoKHMoi.Enabled = false;
                txtSDT.FillColor = Color.White;
            }
            btnXacNhan.Enabled = false;
            txtSDT.ReadOnly = false;
            txtTienKH.ReadOnly = true;
            txtTienKH.FillColor = Color.White;
        }


        private void btnTaoKHMoi_Click(object sender, EventArgs e)
        {
            if(btnTaoKHMoi.BackColor == Color.BlanchedAlmond)
            {
                txtSDT.ReadOnly = true;
                txtFirstName.FillColor = Color.FromArgb(160, 255, 255);
                txtLastName.FillColor = Color.FromArgb(160, 255, 255);
                txtFirstName.ReadOnly = false;
                txtLastName.ReadOnly = false;
                btnTaoKHMoi.BackColor = Color.Violet;
                
            }
            else
            {
                btnTaoKHMoi.BackColor = Color.BlanchedAlmond;
                txtSDT.ReadOnly = false;
                txtFirstName.ReadOnly = true;
                txtLastName.ReadOnly = true;
                resetKH();
            }
        }

        private void lbThanhTien_TextChanged(object sender, EventArgs e)
        {
            giamTien();
            if (!(checkNumer(txtTienKH.Text) 
                && Convert.ToInt32(txtTienKH.Text) >= Convert.ToInt32(lbThanhTien.Text)
                && Convert.ToInt32(txtTienKH.Text) % 1000 == 0))
            {
                btnThanhToan.Enabled = false;
                lbTienThua.Text = "0";
                
            }
            else if(lbTongTien.Text == "0")
            {
                lbTienThua.Text = "0";
                txtTienKH.Text = "";
                
            }
            else
            {
                btnThanhToan.Enabled = true;
                lbTienThua.Text = (Convert.ToInt32(txtTienKH.Text) - Convert.ToInt32(lbThanhTien.Text)).ToString();
                txtTienKH.FillColor = Color.White;
            }
            
        }
        private void giamTien()
        {
            if (txtFirstName.Text == "")
            {
                lbThanhTien.Text = lbTongTien.Text ;
                return;
            }
            else
            {
                if (diem >= 500 && Convert.ToInt32(lbTongTien.Text) >= 10000)
                {
                    int tienGiamToiDa = diem / 500 * 500 * 20;
                    diemConLai = diem - (diem / 500 * 500);
                    if (tienGiamToiDa >= Convert.ToInt32(lbTongTien.Text))
                    {
                        int tienGiam = Convert.ToInt32(lbTongTien.Text) / 10000 * 10000;
                        lbGiam.Text = "-" + tienGiam.ToString() ;
                        diemConLai += (tienGiamToiDa - tienGiam) / 1000;
                        lbThanhTien.Text = (Convert.ToInt32(lbTongTien.Text) - tienGiam).ToString();
                        Console.WriteLine("Điểm còn lại " + diemConLai);
                    }
                    else
                    {
                        lbGiam.Text = "-" + tienGiamToiDa.ToString() ;
                        lbThanhTien.Text = (Convert.ToInt32(lbTongTien.Text) - tienGiamToiDa).ToString() ; ;
                    }

                }
                else
                {
                    lbThanhTien.Text = lbTongTien.Text ;
                    lbGiam.Text = "0";
                }
            }
        }
        private void lbTongTien_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && btnTaoKHMoi.BackColor != Color.BlanchedAlmond)     
                btnXacNhan.Enabled = true;
            else
                btnXacNhan.Enabled = false;
        }       

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            khachHangBLL.insertKhachHangInBanHang(txtLastName.Text, txtFirstName.Text,txtSDT.Text);
            khachHang_id = Convert.ToInt32(khachHangBLL.getTypeOfName(txtSDT.Text, "id").ToString());
            MessageBox.Show("Tạo mới Khách Hang Thành Công id = " + khachHang_id.ToString());
            resetKH();
            btnTaoKHMoi.BackColor = Color.BlanchedAlmond;
            btnTaoKHMoi.Enabled = false;
            txtDiem.Text = khachHangBLL.getTypeOfName(txtSDT.Text, "tichDiem");
            txtTienKH.ReadOnly = false;
            txtTienKH.FillColor = Color.LemonChiffon;
          
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && btnTaoKHMoi.BackColor != Color.BlanchedAlmond)
                btnXacNhan.Enabled = true;
            else
                btnXacNhan.Enabled = false;
        }

        private void txtTienKH_TextChanged(object sender, EventArgs e)
        {
            if(checkNumer(txtTienKH.Text) && Convert.ToInt32(txtTienKH.Text) >= Convert.ToInt32(lbThanhTien.Text) && Convert.ToInt32(txtTienKH.Text)%1000 == 0 && GioHang.Count > 0)
            {
                lbTienThua.Text = (Convert.ToInt32(txtTienKH.Text) - Convert.ToInt32(lbThanhTien.Text)).ToString();    
                btnThanhToan.Enabled = true;
            }
            else if (lbTongTien.Text == "0")
            {
                lbTienThua.Text = "0";
                txtTienKH.Text = "";
                    btnThanhToan.Enabled = false;
            }
            else
            {
                lbTienThua.Text = "0";
                btnThanhToan.Enabled = false;
            }
        }
        private bool kiemTraGioHang()
        {
            for (int i = 0; i < GioHang.Count; i++)
            {
                if (GioHang[i].txtSoLuong.Text.Equals(""))
                {
                    MessageBox.Show($"Hãy Nhập Số lượng cho mã số {GioHang[i].lbID.Text} !");
                    txtTienKH.Text = "";
                    lbTienThua.Text = "";
                    return false;
                }
            }
            return true;
        }

        private void resetSDT_Click(object sender, EventArgs e)
        {
            txtSDT.Clear();
        }
    }
}
