using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{
    public class SanPhamNCCBLL
    {
        private SanPhamNCCDAO spnccDAO;
        private SanPhamDAO sanPhamDAO;
        public SanPhamNCCBLL()
        {
            spnccDAO = new SanPhamNCCDAO();
            sanPhamDAO = new SanPhamDAO();
        }


        public DataTable GetAllSanPhamNCC()
        {
            return spnccDAO.GetAllSanPhamNCC();
        }

        public bool InsertSanPham(SanPhamNCCDTO sp)
        {

            return spnccDAO.insertSanPham(sp);
        }

        public bool DeleteSanPham(int id)
        {

            return spnccDAO.deleteSanPham(id);
        }

        public bool UpdateSanPham(SanPhamNCCDTO sp)
        {

            return spnccDAO.updateSanPham(sp);
        }

        public DataTable GetSanPhamNCCByLoaiSanPham(int loaiSanPhamId)
        {

            return spnccDAO.GetSanPhamNCCByLoaiSanPham(loaiSanPhamId);
        }
        public DataTable GetSanPhamNCCByName(string tenSanPham)
        {

            if (string.IsNullOrEmpty(tenSanPham))
            {
                throw new ArgumentException("Tên sản phẩm không được để trống.");
            }
            return spnccDAO.GetSanPhamNCCByName(tenSanPham);
        }

        public DataTable getDTSPNCC(int i)
        {
            return spnccDAO.getDatatable(i);

        }
        // lay ten theo id sp
        public string getTenByID(int id)
        {
            return spnccDAO.getTenById(id);
        }
        //lay don gia theo id san pham
        public int getDonGia(int id)
        {
            return spnccDAO.getDonGia(id);
        }
        public int getNextIdSanPhamNCC()
        {
            return spnccDAO.getNextIdSanPhamNCC() + 1;
        }
        public void themSanPhamNCC(string ten, int loaiSanPham, string donGia, string urlAnh, string ngayHetHan)
        {
            if(spnccDAO.themSanPhamNCC(ten, loaiSanPham, donGia, urlAnh, ngayHetHan) > 0)
                MessageBox.Show("Thêm Sản Phẩm Thành Công");
            else
                MessageBox.Show("Thêm Sản Phẩm Thất bại");
        }
        public void chinhSuaSanPhamNCC(string id, string ten, int loaiSanPham_id,
                                    string donGia, string urlAnh, string ngayHetHan, bool trangThai)
        {
            if( spnccDAO.updateSanPhamNCC(id, ten, loaiSanPham_id, donGia, urlAnh, ngayHetHan, trangThai))
                MessageBox.Show("Cập Nhật Phẩm Thành Công");
            else
                MessageBox.Show("Cập Nhật Phẩm Thất bại");
        }
    }
}
