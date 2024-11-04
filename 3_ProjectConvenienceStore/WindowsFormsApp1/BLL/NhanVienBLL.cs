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
    public class NhanVienBLL
    {
        NhanVienDAO nhanVienDAO = new NhanVienDAO();
        public DataTable getTableTrangThai(int trangThai)
        {
            return nhanVienDAO.getTableNhanVien(trangThai);
        }
        public int getNextIdNV() { 
            return nhanVienDAO.getNextNV();
        }
        public void themNhanVien(string maNV, string ho, string ten, DateTime ngaySinh,
                                    string SDT, string diaChi, string urlAnh, string CCCD, bool gioiTinh) { 

            // xu ly

            bool check = nhanVienDAO.insertNhanVien(maNV, ho, ten, ngaySinh, SDT, diaChi, urlAnh, CCCD, gioiTinh);
            if (check)
                MessageBox.Show("Thêm Nhân Viên Thành Công");
            else
                MessageBox.Show("Thêm Nhân Viên Thất Bại");
        }
        public void createLogin(string username, string password) { 
            nhanVienDAO.createLoginServer(username, password);
        }
        public void updateNhanVien(string maNV, string ho, string ten, DateTime ngaySinh,
                                    string SDT, string diaChi, string urlAnh, string CCCD, bool gioiTinh, bool trangThai)
        {
            bool check = nhanVienDAO.updateNhanVien(maNV, ho, ten, ngaySinh, SDT, diaChi, urlAnh, CCCD, gioiTinh, trangThai);
            if (check)
                MessageBox.Show("Chỉnh Sửa Nhân Viên Thành Công");
            else
                MessageBox.Show("Chỉnh Sửa Nhân Viên Thất Bại");
        }
        public void resetPassword(string maNV, string password) { 
            nhanVienDAO.resetPassword(maNV, password);
        }

        public void convertStatus(string maNV, bool status)
        {     
            if (status)
                nhanVienDAO.enableLogin(maNV);
            else
                nhanVienDAO.disableLogin(maNV);
        }
        public DataTable getNhanVienQuyen()
        {
            return nhanVienDAO.getNhanVienQuyen();
        }
        public void updateMaQuyenNhanVien(string maNV, int maQuyen)
        {
            string maQuyens = maQuyen.ToString();
            nhanVienDAO.updateQuyenNhanVien(maNV, maQuyens);
        }
    }
}
