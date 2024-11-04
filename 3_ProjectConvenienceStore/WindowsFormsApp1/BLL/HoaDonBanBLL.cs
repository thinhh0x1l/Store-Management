using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{
    public class HoaDonBanBLL
    {
        private HoaDonBanDAO hoaDonBanDAO = new HoaDonBanDAO();



        // Lấy tất cả hóa đơn
        public DataTable GetAllHoaDonBan()
        {
            try
            {
                return hoaDonBanDAO.GetHoaDonBan();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tất cả hóa đơn bán: " + ex.Message);
            }
        }

        // Thêm hóa đơn bán
        public void AddHoaDonBan(HoaDonBanDTO hdb)
        {
            try
            {
                hoaDonBanDAO.AddHoaDonBan(hdb);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm hóa đơn bán: " + ex.Message);
            }
        }

        // Thêm sản phẩm vào giỏ
        public void AddSanPhamVaoGio(int hoaDonId, int sanPhamId, int soLuong)
        {
            //try
            //{
            //    hoaDonBanDAO.AddSanPhamVaoGio(hoaDonId, sanPhamId, soLuong);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Lỗi khi thêm sản phẩm vào giỏ: " + ex.Message);
            //}
        }

        // Lấy hóa đơn theo ngày
        public DataTable GetHoaDonTheoNgay(DateTime ngayban)
        {
            try
            {
                return hoaDonBanDAO.GetHoaDonTheoNgay(ngayban);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy hóa đơn theo ngày: " + ex.Message);
            }
        }

        // Lấy hóa đơn theo tháng
        public DataTable GetHoaDonTheoThang(DateTime thang)
        {
            try
            {
                return hoaDonBanDAO.GetHoaDonTheoThang(thang);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy hóa đơn theo tháng: " + ex.Message);
            }
        }

        // Lấy hóa đơn theo năm
        public DataTable GetHoaDonTheoNam(DateTime nam)
        {
            try
            {
                return hoaDonBanDAO.GetHoaDonTheoNam(nam);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy hóa đơn theo năm: " + ex.Message);
            }
        }
        //manv va ngay
        public DataTable GetHoaDonTheoMaNVVaNgay(string id, DateTime ngay)
        {
            try
            {
                return hoaDonBanDAO.GetHoaDonTheoMaNVVaNgay(id, ngay);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy hóa đơn theo mã nhân viên: " + ex.Message);
            }
        }
        //sdt
        public DataTable GetHoaDonTheoSDT(string sdt)
        {
            try
            {
                return hoaDonBanDAO.GetHoaDonTheoSDT(sdt);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy hóa đơn theo số điện thoại: " + ex.Message);
            }
        }
        //check sdt
        public bool checkHD(string sdt)
        {
            return hoaDonBanDAO.checkHD(sdt);
        }
        //tong thu hoa don theo ngay 
        public long tongThuTheoNgay(DateTime ngayBan)
        {
            return hoaDonBanDAO.tongThuTheoNgay(ngayBan);
        }
        //tong thu hoa don theo thang

        public DataTable ThongKeDoanhThuTheoThang(DateTime thang)
        {
            return hoaDonBanDAO.ThongKeDoanhThuTheoThang(thang);
        }
        public DataTable ThongKeDoanhThuTheoNam(DateTime nam)
        {
            return hoaDonBanDAO.ThongKeDoanhThuTheoNam(nam);
        }
        //san pham ban chay theo ngay
        public DataTable sanPhamBanChayTrongNgay(DateTime ngay)
        {
            return hoaDonBanDAO.sanPhamBanChayTrongNgay(ngay);
        }
        //san pham ban chay theo tháng
        public DataTable sanPhamBanChay(DateTime thang)
        {
            return hoaDonBanDAO.sanPhamBanChay(thang);
        }
        //public long tongThuTheoThang(DateTime thang)
        //{
        //    return hoaDonBanDAO.tongThuTheoThang(thang);
        //}
        public List<HoaDonBanDTO> listHDBTheoNgay(DataTable hdb)
        {
            return hoaDonBanDAO.listHDBTheoNgay(hdb);
        }
        //tinh chi phi nhap theo san pham theo hoa don
        public long tongPhiNhapSP(List<HoaDonBanDTO> list)
        {
            return hoaDonBanDAO.tongPhiNhapSP(list);
        }
        //tinh tong chi phi nhap theo ngay
        public long TongChiPhiNhapTheoNgay(DateTime date)
        {
            return hoaDonBanDAO.TongChiPhiNhapTheoNgay(date);
        }
        public long TongChiPhiNhapTheoThang(int thang, int nam)
        {
            return hoaDonBanDAO.TongChiPhiNhapTheoThang(thang, nam);
        }
        //kiem tranhan vien co hoa don ban ch
        public bool kiemTraNV(string nv)
        {
            return hoaDonBanDAO.kiemTraNV(nv);
        }
        // Sinh Ra mã hóa đơn kế tiếp;
        public int getNextOrderId()
        {
            int id;
            try
            {
                id = hoaDonBanDAO.getNextOrder() + 1;
                return id;
            }
            catch (Exception e) { MessageBox.Show("Không thể lấy mã hóa dơn");
                return -1;
            }
        }
        public bool insertHoaDonBan(string NhanVien_id, int KhachHang_id, int tongTien)
        {
            bool s = hoaDonBanDAO.insertHoaDonBan(NhanVien_id, KhachHang_id, tongTien);
            if (s)
                return true;
            MessageBox.Show("Tạo hóa đơn không thành công");
            return false;

        }
        public static HoaDonBan hd;
        public static void setHoaDonBan(HoaDonBan hoaDonBan)
        {
            hd = hoaDonBan;
        }
        public static HoaDonBan GetHoaDonBan()
        {
            return hd;
        }



        // Lấy tất cả hóa đơn
        

    }
    public class HoaDonBan
    {
        public string maHoaDon;
        public string maNhanVien;
        public string tenKhachHang;
        public string thanhTien;
        public string tienKhach;
        public string tienThua;
        public string diemHoaDon;
        public DateTime thoiGianBan;
        public HoaDonBan(string maHoaDon, string maNhanVien, string tenKhachHang, string thanhTien, string tienKhach, string tienThua, string diemHoaDon, DateTime thoiGianBan)
        {
            this.maHoaDon = maHoaDon;
            this.maNhanVien = maNhanVien;
            this.tenKhachHang = tenKhachHang;
            this.thanhTien = thanhTien;
            this.tienKhach = tienKhach;
            this.tienThua = tienThua;
            this.diemHoaDon = diemHoaDon;
            this.thoiGianBan = thoiGianBan;
        }
    }
}
