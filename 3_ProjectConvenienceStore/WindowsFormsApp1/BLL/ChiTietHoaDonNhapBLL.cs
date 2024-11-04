using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{
   public class ChiTietHoaDonNhapBLL
    {
        public ChiTietHoaDonNhapDAO chiTietHoaDonNhapDAO = new ChiTietHoaDonNhapDAO();
        public ChiTietHoaDonNhapDAO chiTietHoaDonDAO;

        public ChiTietHoaDonNhapBLL()
        {
            chiTietHoaDonDAO = new ChiTietHoaDonNhapDAO();
        }
        // lay danh sach chi tiet hoa don
        public List<ChiTietHoaDonNhapDTO> GetListChiTietHD(int hoaDonId)
        {
            try
            {
                return chiTietHoaDonDAO.getListChiTietHD(hoaDonId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chi tiết hóa đơn: " + ex.Message);
            }
        }
        // lay danh sach chi tiet hoa don ra dtgr
        public DataTable getChiTietHDN(int hoaDonId)
        {
            try
            {
                return chiTietHoaDonDAO.getChiTietHD(hoaDonId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chi tiết hóa đơn: " + ex.Message);
            }
        }
        // Thêm chi tiết hóa đơn
        public void AddChiTietHoaDon(int hoaDonId, ChiTietHoaDonNhapDTO chiTiet)
        {
            try
            {
                chiTietHoaDonDAO.addChiTietHoaDon(hoaDonId, chiTiet);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public bool deleteCTHDByHDId(int hoaDonId)
        {
            try
            {
                if (chiTietHoaDonDAO.deleteCTHDByHDId(hoaDonId)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa chi tiết hóa đơn:: " + ex.Message);
            }
        }

        //public int soLuongSPCTHD(int hoaDonId,int sPID)
        //{
        //    return chiTietHoaDonDAO.soLuongTungLoaiSP(hoaDonId, sPID);
        //}

        //remove san pham
        public void removeSP(int id)
        {
            chiTietHoaDonDAO.removeSP(id);
        }
        //tong tien san pham tam thoi
        public int tongTienSPTam(int hdid, int spid, int sl)
        {
            return chiTietHoaDonDAO.tongTienSPTam(hdid, spid, sl);
        }

        ////cap nhat so luong sp
        public bool capNhatsLSP(int hdid, int spid, int sl, DateTime ngay)
        {
            return chiTietHoaDonDAO.capNhatSoLuongSP(hdid, spid, sl, ngay);
        }

        public bool LuuDanhSachChiTietHoaDon(int hdid, List<ChiTietHoaDonNhapDTO> chiTietList)
        {
            return chiTietHoaDonDAO.LuuDanhSachChiTietHoaDon(hdid, chiTietList);
        }

        public long tinhTongTienCTHD(List<ChiTietHoaDonNhapDTO> lst)
        {
            return chiTietHoaDonDAO.tinhTongTienAllCTHD(lst);
        }
        //cap nhat sl san pham trong cthd
        public void capNhatSoLuongCTHD(int hdid, int spid, int slm)
        {
            chiTietHoaDonDAO.capNhatSoLuongCTHD(hdid, spid, slm);
        }
        //tong sl trong hoa don 
        public int tongSLCTHD(List<ChiTietHoaDonNhapDTO> lst)
        {
            return chiTietHoaDonDAO.tongSLCTHD(lst);
        }
        //
        public List<ChiTietHoaDonNhapDTO> addChiTietHDList(int hdid, SanPhamNCCDTO sp)
        {
            return chiTietHoaDonDAO.addChiTietHoaDonVaoList(hdid, sp);
        }
        public DataTable ChuyenListToDataTable(List<ChiTietHoaDonNhapDTO> listChiTiet)
        {
            return chiTietHoaDonDAO.ChuyenListToDataTable(listChiTiet);
        }
        

    }
}
