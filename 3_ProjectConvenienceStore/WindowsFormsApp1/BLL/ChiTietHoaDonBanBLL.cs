using System;
using System.Collections.Generic;
using System.Data;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{
    public class ChiTietHoaDonBLL
    {
        private ChiTietHoaDonBanDAO chiTietHoaDonDAO;
        private ChiTietHoaDonBanDAO chiTietHoaDonBanDAO;

        public ChiTietHoaDonBLL()
        {
            chiTietHoaDonBanDAO = new ChiTietHoaDonBanDAO();
        }

        // Thêm chi tiết hóa đơn
        public void AddChiTietHoaDon(int hoaDonId, ChiTietHoaDonBanDTO chiTiet)
        {
            try
            {
                chiTietHoaDonBanDAO.addChiTietHoaDon(hoaDonId, chiTiet);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        // Cập nhật số lượng sản phẩm trong chi tiết hóa đơn
        public void updateSoLuong(int hoaDonId, int sanPhamId, int soLuong)
        {
            try
            {
                chiTietHoaDonBanDAO.capNhatSoLuong(hoaDonId, sanPhamId, soLuong);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        // Kiểm tra sự tồn tại của sản phẩm trong chi tiết hóa đơn
        public bool checkSanPham(int hoaDonId, int sanPhamId)
        {
            try
            {
                return chiTietHoaDonBanDAO.kiemTraSanPham(hoaDonId, sanPhamId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        //lay chi tiet hoa don 
        public DataTable getChiTietHDBan(int hoaDonId)
        {
            return chiTietHoaDonBanDAO.getChiTietHD(hoaDonId);
        }

        //tinh thanh tien
        public int tongTienSPTam(int hdid, int spid, int sl)
        {
            return chiTietHoaDonBanDAO.tongTienSPTam(hdid, spid, sl);
        }
        // Lấy chi tiết hóa đơn theo mã hóa đơn
        public List<ChiTietHoaDonBanDTO> getChiTietHD(int hoaDonId)
        {
            try
            {
                DataTable dt = chiTietHoaDonBanDAO.getChiTietHD(hoaDonId);
                List<ChiTietHoaDonBanDTO> chiTietList = new List<ChiTietHoaDonBanDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    ChiTietHoaDonBanDTO chiTiet = new ChiTietHoaDonBanDTO
                    {
                        HoaDonBan_id = Convert.ToInt32(row["HoaDonBan_id"]),
                        SanPham_id = Convert.ToInt32(row["SanPham_id"]),
                        soLuong = Convert.ToInt32(row["SoLuong"]),
                        Sanpham_NgayHetHan = Convert.ToDateTime(row["Sanpham_NgayHetHan"])
                    };

                    chiTietList.Add(chiTiet);
                }

                return chiTietList;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        //tong chi phi nhap theo ngay
        //tong chi phi nhap theo hoa don ngay

        public bool insertChiTietHoaDonBan(int HoaDonBan_id, int SanPham_id, int soLuong, DateTime SanPham_NgayHetHan)
        {
            return chiTietHoaDonBanDAO.insertChiTietHoaDonBan(HoaDonBan_id, SanPham_id, soLuong, SanPham_NgayHetHan);
        }
    }
}

