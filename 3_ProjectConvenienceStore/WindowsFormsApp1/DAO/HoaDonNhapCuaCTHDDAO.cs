using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace WindowsFormsApp1.DAO
{
    public class HoaDonNhapCuaCTHDDAO
    {
        public List<HoaDonNhapCuaCTHD> getTTFromCTHDN(List<ChiTietHoaDonNhapDTO> list)
        {
            SanPhamNCCDAO sanPhamNCCDAO = new SanPhamNCCDAO();
            List < HoaDonNhapCuaCTHD > listCTHD=new List<HoaDonNhapCuaCTHD> ();
           
            foreach (var chiTiet in list)
            {
                HoaDonNhapCuaCTHD hdncthd = new HoaDonNhapCuaCTHD();
                hdncthd.MaSP = chiTiet.SanPhamNCC_id;
                 hdncthd.soLuong = chiTiet.soLuong;
                hdncthd.ngayHH = chiTiet.SanPham_NgayHetHan;

                hdncthd.tenSP = sanPhamNCCDAO.getTenById(hdncthd.MaSP);
                hdncthd.donGia = sanPhamNCCDAO.getDonGia(hdncthd.MaSP);
                hdncthd.thanhTien = hdncthd.soLuong * hdncthd.donGia;

                listCTHD.Add(hdncthd);
            }
            return listCTHD;
        }




        public DataTable ChuyenListToDataTable(List<HoaDonNhapCuaCTHD> listChiTiet)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("Mã Sản Phẩm", typeof(int));
            dt.Columns.Add("Tên Sản Phẩm", typeof(string));
            dt.Columns.Add("Số Lượng", typeof(int));
            dt.Columns.Add("Đơn Giá", typeof(int));
            dt.Columns.Add("Thành Tiền", typeof(int));
            dt.Columns.Add("Ngày Hết Hạn", typeof(DateTime));

            foreach (var chiTiet in listChiTiet)
            {
                DataRow row = dt.NewRow();
                row["Mã Sản Phẩm"] = chiTiet.MaSP;
                row["Tên Sản Phẩm"] = chiTiet.tenSP;
                row["Số Lượng"] = chiTiet.soLuong;
                row["Đơn Giá"] = chiTiet.donGia;
                row["Thành Tiền"] = chiTiet.thanhTien;
                row["Ngày Hết Hạn"] = chiTiet.ngayHH;

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
