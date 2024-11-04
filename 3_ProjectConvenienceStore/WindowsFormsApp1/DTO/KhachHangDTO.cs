using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class KhachHangDTO
    {

        public int id { get; set; }
        public string ten { get; set; }
        public string ho { get; set; }
        public string SDT { get; set; }
        public int tichDiem { get; set; }


        public KhachHangDTO() { }
        public KhachHangDTO(string ten, string ho, string SDT, int Diem)
        {
           
            this.ten = ten;
            this.ho = ho;
            this.SDT = SDT;
            this.tichDiem =Diem;
        }

        public KhachHangDTO(string ten, string ho, string SDT)
        {

            this.ten = ten;
            this.ho = ho;
            this.SDT = SDT;
          
        }
    }
}
