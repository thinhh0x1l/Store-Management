using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class ChiTietHoaDonDTO
    {
        public int HoaDonBan_id { get; set; }
        public int SanPham_id { get; set; }
        public int soLuong { get; set; }
        public DateTime Sanpham_NgayHetHan { get; set; }

        public ChiTietHoaDonDTO()
        {

        }
        public ChiTietHoaDonDTO(int sanPham_id, int soLuong, DateTime Sanpham_NgayHetHan) { 
            this.SanPham_id = sanPham_id;
            this.soLuong = soLuong; 
            this.Sanpham_NgayHetHan = Sanpham_NgayHetHan;
        }
    }
}
