using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class HoaDonNhapCuaCTHD
    {
        public int MaSP { get; set; }
        public string tenSP { get; set; }
        public int soLuong { get; set; }
        public int donGia { get; set; }
        public DateTime ngayHH { get; set; }
        public int thanhTien { get; set; }




        public HoaDonNhapCuaCTHD()
        {

        }

        public HoaDonNhapCuaCTHD(int MaSP, string tenSP, int soLuong, int donGia, DateTime ngayHH, int thanhTien)
        {
            this.MaSP = MaSP;
            this.tenSP = tenSP;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.ngayHH = ngayHH;
            this.thanhTien = thanhTien;

        }
    }
}
