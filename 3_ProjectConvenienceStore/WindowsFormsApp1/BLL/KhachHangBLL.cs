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
    public class KhachHangBLL
    {
        public KhachHangDAO kh = new KhachHangDAO();

        //get all khach hang
        public DataTable getAllKhachHang()
        {
            return kh.getAllKhachHang();
        }

        //insert khach hang moi
        public bool insertKhachHang(KhachHangDTO k)
        {
            return kh.insertKhachHang(k);
        }

        //update khach hang
        public bool updateKhachHang(int id, string ho , string ten ,string sdt)
        {
            return kh.updateKhachHang(id, ho , ten ,sdt);
        }
        //xep hang diem
        public DataTable xepHangDiem()
        {
            return kh.xepHangDiem();
        }
        //delete khach hang
        public bool deleteKhachHang(int id)
        {
            return kh.deleteKhachHang(id);
        }
        //kiem tra khach hang cha co hoa don 
        public bool kiemTraKH(int id)
        {
            return kh.kiemTraKH(id);
        }
        public string getTypeOfName(string sdt, string typeOfName)
        {
            return kh.getName(sdt, typeOfName);
        }
        //
        public bool insertKhachHangInBanHang(string ho, string ten, string SDT)
        {
            return kh.insertKhachHangInBanHan(ho, ten, SDT);
        }
        //
        public void updateDiemKhachHang(int id, int tichDiem)
        {
            kh.updateDiemKhachHang(id, tichDiem);
        }

        //get all khach hang
        
    }
}
