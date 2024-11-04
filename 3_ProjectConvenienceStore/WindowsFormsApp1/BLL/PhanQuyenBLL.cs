using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;

namespace WindowsFormsApp1.BLL
{
    public class PhanQuyenBLL
    {
        PhanQuyenDAO phanQuyenDAO;
        public PhanQuyenBLL() { 
            phanQuyenDAO = new PhanQuyenDAO();
        }
        public DataTable getPhanQuyen()
        {
            return phanQuyenDAO.getQuyen();
        }
        public void capQuyen(string maNV, string role)
        {
            if(role == "QuanLy")
            {
                phanQuyenDAO.capQuyenServer(maNV, role);
            }
            if (!phanQuyenDAO.capQuyen(maNV, role))
                MessageBox.Show("Cấp Quyền Thành Công");
        }
        public void thuHoiQuyen(string maNV, string role)
        {
            if (role == "QuanLy")
            {
                phanQuyenDAO.thuHoiQuyenServer(maNV, role);
            }
            if (!phanQuyenDAO.thuHoiQuyen(maNV, role))
                MessageBox.Show("Thu Hồi Quyền Thành Công");
        }
    }
}
