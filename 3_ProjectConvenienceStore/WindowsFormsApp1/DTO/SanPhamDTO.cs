using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class SanPhamDTO
    {
        public int id { get; set; }
        public string ten { get; set; }
        public int LoaiSanPham_id { get; set; }
        public int donGia { get; set; }
        public byte[] urlAnh { get; set; }
        public DateTime ngayHetHan { get; set; }
        public short trangThai { get; set; }
        public int soLuong { get; set; }

        public SanPhamDTO()
        {

        }
       
        
    }
}
