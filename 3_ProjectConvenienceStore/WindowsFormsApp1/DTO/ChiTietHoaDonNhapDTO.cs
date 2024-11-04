using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class ChiTietHoaDonNhapDTO
    {
        public int HoaDonNhap_id { get; set; }
        public int SanPhamNCC_id { get; set; }
        public int soLuong { get; set; }
        public DateTime SanPham_NgayHetHan { get; set; }

        public ChiTietHoaDonNhapDTO()
        {

        }
        public ChiTietHoaDonNhapDTO(int HoaDonBan_id, int sanPham_id, int soLuong, DateTime Sanpham_NgayHetHan)
        {
            this.HoaDonNhap_id = HoaDonBan_id;
            this.SanPhamNCC_id = sanPham_id;
            this.soLuong = soLuong;
            this.SanPham_NgayHetHan = Sanpham_NgayHetHan;
        }
    }
}