using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class HoaDonNhapDTO
    {
        public int id { get; set; }

        public string NhanVien_id { get; set; }
        public DateTime ngayNhap { get; set; }
        public TimeSpan gioNhap { get; set; }
        public long tongTien { get; set; }

        public HoaDonNhapDTO()
        {

        }
        public HoaDonNhapDTO(string nhanVien_id, DateTime ngayNhap, TimeSpan gioNhap)
        {

            NhanVien_id = nhanVien_id;
            this.ngayNhap = ngayNhap;
            this.gioNhap = gioNhap;

        }
        public HoaDonNhapDTO(string nhanVien_id, DateTime ngayNhap, TimeSpan gioNhap, long tongTien)
        {

            NhanVien_id = nhanVien_id;
            this.ngayNhap = ngayNhap;
            this.gioNhap = gioNhap;
            this.tongTien = tongTien;
        }
    }
}
