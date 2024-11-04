using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class HoaDonBanDTO
    {
        public int id { get; set; }
        public int KhachHang_id { get; set; }
        public string NhanVien_id { get; set; }
        public DateTime ngayBan { get; set; }
        public TimeSpan gioBan { get; set; }
        public int tongTien { get; set; }

        public HoaDonBanDTO()
        {

        }
        public HoaDonBanDTO( int khachHang_id, string nhanVien_id, DateTime ngayBan, TimeSpan gioBan, int tongTien)
        {
            
            KhachHang_id = khachHang_id;
            NhanVien_id = nhanVien_id;
            this.ngayBan = ngayBan;
            this.gioBan = gioBan;
            this.tongTien = tongTien;
        }
    }
}
