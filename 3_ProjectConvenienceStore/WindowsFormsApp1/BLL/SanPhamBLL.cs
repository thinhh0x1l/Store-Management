using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{
    public  class SanPhamBLL
    {
        private SqlConnection conn = new SqlConnection(Login.Connect);
        private SanPhamDAO sanPhamDAO = new SanPhamDAO();
        
        public DataTable getSanPham()
        {
            return sanPhamDAO.getSanPham();
        }
       
        public bool InsertSanPham(SanPhamDTO sp)
        {
            // Kiểm tra dữ liệu đầu vào trước khi thêm vào cơ sở dữ liệu
            if (string.IsNullOrEmpty(sp.ten))
            {
                throw new ArgumentException("Tên sản phẩm không được để trống.");
            }

            if (sp.donGia <= 0)
            {
                throw new ArgumentException("Đơn giá phải lớn hơn 0.");
            }

            if (sp.soLuong < 0)
            {
                throw new ArgumentException("Số lượng sản phẩm không được nhỏ hơn 0.");
            }

            if (sp.ngayHetHan < DateTime.Now)
            {
                throw new ArgumentException("Ngày hết hạn không được nhỏ hơn ngày hiện tại.");
            }

            return sanPhamDAO.insertSanPham(sp);
        }

         
        public List<SanPhamDTO>getLoaiSanPham1()
        {
             List<SanPhamDTO> check = sanPhamDAO.getListSanPham1();
            if (check != null)
                return check;

            MessageBox.Show("Không được dữ liệu Sản Phẩm");
            return null;
            
        }
        public DataTable getDTSP( int i )
        {
            string querry = "SELECT * FROM SanPham Where trangThai = '"+i+"'";
            return sanPhamDAO.getDatatable(querry);

        }
        public void sfsad()
        {
            Hashtable ht = new Hashtable();

        }
        public void updateSoLuongSanPham(string id, string soLuong)
        {
            int ID = Convert.ToInt32(id);
            int SoLuong = Convert.ToInt32(soLuong);
            if (sanPhamDAO.updateSoLuongSanPham(ID, SoLuong))
                Console.WriteLine($"200 id = {ID} , so Luong = {SoLuong}");
            else Console.WriteLine($"Loi khong update dc id = {ID} , so Luong = {SoLuong} ");
        }
        private static List<SPThanhToan> list;
        private static  List<SPHoaDon>  listHD;
        public static void setListSPThanhToan(List<SPThanhToan> l)
        {
            list = l;
        }
        public static List<SPThanhToan> GetSPThanhToan()
        {
            return list;
        }
        public static List<SPHoaDon> GetSPHoaDon()
        {
            listHD = new List<SPHoaDon>();
            for (int i = 0; i < list.Count; i++) { 
                SPHoaDon spHoaDon = new SPHoaDon(i + 1, list[i].lbTen.Text, Convert.ToInt32(list[i].txtSoLuong.Text), Convert.ToInt32(list[i].donGia), Convert.ToInt32(list[i].tong));
                listHD.Add(spHoaDon);
            }
            return listHD;
        }
        public void updateSanPhamBayBan(string ID, string DONGIA)
        {
            int id = Convert.ToInt32(ID);
            int donGia = Convert.ToInt32(DONGIA);
            sanPhamDAO.updateSanPhamBayBan(id, donGia);
        }
        public bool updateSanPhamBayBanHa(string id, string sl, string ngayHetHan)
        {
            if(!(sl == "0" || DateTime.Parse(ngayHetHan) <= DateTime.Now))
            {
                MessageBox.Show("Sản Phẩm vẫn còn bán được");
                return false;
            }
            return sanPhamDAO.updateSanPhamHa(Convert.ToInt32(id));
        }
        public DataTable sanPhamHH()
        {
            return sanPhamDAO.sanPhamHH();
        }
        public bool checkTT(int id)
        {
            return sanPhamDAO.checkTT(id);
        }
        // lay ten theo id sp
        public string getTenByID(int id)
        {
            return sanPhamDAO.getTenByID(id);
        }
        
    }
    public class SPHoaDon
    {
        public int STT { get; set; }
        public string tenSP { get; set; }
        public int soLuong { get; set; }
        public int donGia { get; set; }
        public int tongTien { get; set; }


        public SPHoaDon() { }
        public SPHoaDon(int STT, string tenSP, int soLuong, int donGia, int tongTien)
        {
            this.STT = STT;
            this.tenSP = tenSP;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.tongTien = tongTien;
            
        }

    }
}

