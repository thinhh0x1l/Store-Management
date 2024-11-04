using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class NhanVienDTO
    {
        public string id { get; set; }
        public string ten { get; set; }
        public string ho { get; set; }
        public string SDT { get; set; }
        public byte[] urlAnh { get; set; }
        public string diaChi { get; set; }
        public bool gioiTinh { get; set; }
        public string CCCD { get; set; }
        public DateTime ngaySinh { get; set; }
        public bool trangThai { get; set; }
        public short Quyen_ID { get; set; }

    }
}
