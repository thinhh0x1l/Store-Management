using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{
    public class LoaiSanPhamBLL
    {
        public LoaiSanPhamDAO loaiSanPhamDAO;

        public LoaiSanPhamBLL()
        {
            loaiSanPhamDAO = new LoaiSanPhamDAO(); // Khởi tạo DAO
        }

        //lay san pham khi có id của loại sản phẩm

        public DataTable getAllSPByLoaiSP(int id)

        {
            if (id == 0)
            {
                loaiSanPhamDAO.getAllSP();
            }
            return loaiSanPhamDAO.getSanPhamByLoaiSanPhamNCC(id);
        }


        // Phương thức lấy danh sách sản phẩm theo loại sản phẩm
        public List<SanPhamDTO> GetSanPhamByLoaiSanPham(int loaiSanPhamId)
        {
            DataTable dt = loaiSanPhamDAO.getSanPhamByLoaiSanPhamNCC(loaiSanPhamId);
            List<SanPhamDTO> sanPhamList = new List<SanPhamDTO>();

            foreach (DataRow row in dt.Rows)
            {
                SanPhamDTO sanPham = new SanPhamDTO
                {
                    id = Convert.ToInt32(row["id"]),
                    ten = row["ten"].ToString(),
                    donGia = Convert.ToInt32(row["donGia"]),
                    soLuong = Convert.ToInt32(row["soLuong"]),
                    ngayHetHan = Convert.ToDateTime(row["ngayHetHan"]),
                    trangThai = Convert.ToInt16(row["trangThai"]),
                    LoaiSanPham_id = Convert.ToInt32(row["LoaiSanPham_id"])
                };

                sanPhamList.Add(sanPham);
            }

            return sanPhamList;
        }

        //lay tat ca loai san pham
        public List<LoaiSanPhamDTO> getAllLoaiSanPham()
        {
            return loaiSanPhamDAO.getAllLoaiSanPham();
        }
        public List<LoaiSanPhamDTO> getLoaiSanPham()
        {
            return loaiSanPhamDAO.getLSP();
        }
        
    }
}
