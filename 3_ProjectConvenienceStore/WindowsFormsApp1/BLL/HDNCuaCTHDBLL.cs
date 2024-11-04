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
   public class HDNCuaCTHDBLL
    {
        HoaDonNhapCuaCTHDDAO hoaDonNhapCuaCTHD = new HoaDonNhapCuaCTHDDAO();
        public List<HoaDonNhapCuaCTHD> getTTFromCTHDN(List<ChiTietHoaDonNhapDTO> list)
        {
            return hoaDonNhapCuaCTHD.getTTFromCTHDN(list);
        }
        public DataTable ChuyenListToDataTable(List<HoaDonNhapCuaCTHD> listChiTiet)
        {
            return hoaDonNhapCuaCTHD.ChuyenListToDataTable(listChiTiet);
        }
    }
}
