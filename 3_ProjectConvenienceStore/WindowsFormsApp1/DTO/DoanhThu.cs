using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class DoanhThu
    {
        public long tongThu {  get; set; }
        public long von {  get; set; }
        public long lai {  get; set; }
        public DoanhThu()
        {

        }
        public DoanhThu(long tongThu,long von,long lai)
        {
            this.tongThu = tongThu;
            this.von = von;
            this.lai = lai;
        }
        
    }
}
