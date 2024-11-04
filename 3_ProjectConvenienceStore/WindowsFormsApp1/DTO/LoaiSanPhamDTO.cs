using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class LoaiSanPhamDTO
    {
        public int id {  get; set; }
        public string ten {  get; set; }

        public LoaiSanPhamDTO()
        {

        }
        public LoaiSanPhamDTO(string ten)
        {
            this.ten = ten;
        }
    }
}
