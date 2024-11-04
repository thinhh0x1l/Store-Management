using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class SanPhamNCCDTO
    {
        public int id { get; set; }
        public string ten { get; set; }
        public int LoaiSanPham_id { get; set; }
        public int donGia { get; set; }
        public byte[] urlAnh { get; set; }
        public DateTime ngayHetHan { get; set; }
        public bool trangThai { get; set; }
        public SanPhamNCCDTO()
        {

        }
        public SanPhamNCCDTO(string ten, int LoaiSanPham_id, int donGia, byte[] urlAnh, DateTime ngayHetHan, bool trangThai)
        {
            this.id = id;
            this.ten = ten;
            this.LoaiSanPham_id = LoaiSanPham_id;
            this.donGia = donGia;
            this.urlAnh = urlAnh;
            this.ngayHetHan = ngayHetHan;
            this.trangThai = trangThai;
        }

        public SanPhamNCCDTO(int id, string ten, DateTime ngayHetHan)
        {
            this.id = id;
            this.ten = ten;
        
            this.ngayHetHan = ngayHetHan;


        }
    }
}