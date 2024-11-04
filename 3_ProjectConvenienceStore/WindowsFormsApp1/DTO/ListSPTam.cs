using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class ListSPTam
    {
        public int hoaDon_id {  get; set; }
        public int id { get; set; }
        public string ten { get; set; }
        public int LoaiSanPham_id { get; set; }
        public int donGia { get; set; }
        public byte[] urlAnh { get; set; }
        public DateTime ngayHetHan { get; set; }
      

        public ListSPTam() { }

        public ListSPTam(int id, int LoaiSanPham_id,int donGia, byte[] urlAnh, DateTime ngayHetHan)
        {
            this.id = id;
            this.ten = ten;
            this.LoaiSanPham_id = LoaiSanPham_id;
            this.urlAnh = urlAnh;
            this.ngayHetHan = ngayHetHan;
            this.donGia= donGia;

        }
    }
}
