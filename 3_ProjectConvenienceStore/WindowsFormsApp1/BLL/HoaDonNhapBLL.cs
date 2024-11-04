using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{
    public class HoaDonNhapBLL
    {
        public HoaDonNhapDAO hoaDonNhapDAO = new HoaDonNhapDAO();
        public ChiTietHoaDonNhapDAO chiTietHoaDonDAO = new ChiTietHoaDonNhapDAO();
        //lay id
        public int getId()
        {
            return hoaDonNhapDAO.getID();
        }


        // Thêm hóa đơn nhâp
        public bool AddHoaDonNhap(HoaDonNhapDTO hdb)
        {
            if (hoaDonNhapDAO.AddHoaDonNhap(hdb))
            {
                return true;
            }
            return false;
           
        }

        // Thêm sản phẩm vào giỏ
        public void AddSanPhamVaoGio(int hdid, SanPhamNCCDTO sp, int sl)
        {
            hoaDonNhapDAO.AddSanPhamVaoGio(hdid, sp, sl);

        }


        // lấy số lượng sản phẩm trong hóa đơn
        public int getAllSoLuongSP(int hdid)
        {
            return hoaDonNhapDAO.SoLuong(hdid);
        }
        //lay hoa don theo ngay
        public DataTable getHDNgay(DateTime ngay)
        {
            return hoaDonNhapDAO.GetHoaDonTheoNgay(ngay);
        }

        public DataTable getHDThang(DateTime thang)
        {
            return hoaDonNhapDAO.GetHoaDonTheoThang(thang);
        }

        public DataTable getHDNam(DateTime nam)
        {
            return hoaDonNhapDAO.GetHoaDonTheoNam(nam);
        }
        public DataTable getHDNTheoMaNVVaNgay(string id, DateTime ngay)
        {
            return hoaDonNhapDAO.GetHoaDonTheoMaNVVaNgay(id, ngay);
        }
        public DataTable GetSPNhapNhieuTheoThang(DateTime thang)
        {
            return hoaDonNhapDAO.GetSPNhapNhieuTheoThang(thang);
        }
        public bool kiemTraNV(string nv)
        {
            return hoaDonNhapDAO.kiemTraNV(nv);
        }

        // Lấy tất cả hóa đơn
        public DataTable GetAllHoaDonNhap()
        {
            try
            {
                return hoaDonNhapDAO.GetHoaDonNhap();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tất cả hóa đơn bán: " + ex.Message);
            }
        }

        // Thêm hóa đơn bán
       

        // Thêm sản phẩm vào giỏ
        

    }
}
