using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class ChiTietHoaDonDAO
    {
        public DataConnect da = new DataConnect();
      
        //lay chi tiet hoa don
        public DataTable getChiTietHD(int hoaDonId)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM ChiTietHoaDonBan WHERE HoaDonBan_id = @hoaDonId";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@hoaDonId", SqlDbType.Int) { Value = hoaDonId }
            };

            try
            {
                da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
            }
           
            return dt;
        }



        // Lấy chi tiết hóa đơn theo mã hóa đơn
        public List<ChiTietHoaDonDTO> getListChiTietHD(int hoaDonId)
        {
            try
            {
                DataTable dt = getChiTietHD(hoaDonId);
                List<ChiTietHoaDonDTO> chiTietList = new List<ChiTietHoaDonDTO>();
                if (dt.Rows.Count == 0)
                    return chiTietList;
                foreach (DataRow row in dt.Rows)
                {
                    ChiTietHoaDonDTO chiTiet = new ChiTietHoaDonDTO
                    {
                        HoaDonBan_id = Convert.ToInt32(row["HoaDonBan_id"]),
                        SanPham_id = Convert.ToInt32(row["SanPham_id"]),
                        soLuong = Convert.ToInt32(row["SoLuong"]),
                        Sanpham_NgayHetHan = Convert.ToDateTime(row["Sanpham_NgayHetHan"])
                    };

                    chiTietList.Add(chiTiet);
                }

                return chiTietList;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        // Thêm chi tiết hóa đơn
        public void addChiTietHoaDon(int hoaDonId, ChiTietHoaDonDTO chiTiet)
        {
            string query = "INSERT INTO ChiTietHoaDonBan (HoaDonBan_id, SanPham_id, soLuong, Sanpham_NgayHetHan) VALUES (@hoaDonId, @sanPhamId, @soLuong, @ngayhethan)";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@hoaDonId", SqlDbType.Int) { Value = hoaDonId },
                new SqlParameter("@sanPhamId", SqlDbType.Int) { Value = chiTiet.SanPham_id },
                new SqlParameter("@soLuong", SqlDbType.Int) { Value = chiTiet.soLuong },
                new SqlParameter("@ngayhethan", SqlDbType.DateTime) { Value = chiTiet.Sanpham_NgayHetHan }
            };

            try
            {
                da.OpenConnection();
                da.ExecuteNonQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi tiết hóa đơn bán: " + ex.Message);
            }
           
        }

        // Kiểm tra sự tồn tại của sản phẩm trong chi tiết hóa đơn
        public bool kiemTraSanPham(int hoaDonId, int sanPhamId)
        {
            string query = "SELECT COUNT(*) FROM ChiTietHoaDonBan WHERE HoaDonBan_id = @hoaDonId AND SanPham_id = @sanPhamId";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@hoaDonId", SqlDbType.Int) { Value = hoaDonId },
                new SqlParameter("@sanPhamId", SqlDbType.Int) { Value = sanPhamId }
            };

            try
            {
                da.OpenConnection();
                int count = (int)da.ExecuteScalar(query, sqlParameters);
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra sản phẩm trong chi tiết hóa đơn bán: " + ex.Message);
            }
         
        }

        // Cập nhật số lượng sản phẩm
        public void capNhatSoLuong(int hoaDonId, int sanPhamId, int soLuong)
        {
            string query = "UPDATE ChiTietHoaDonBan SET soLuong = @soLuong WHERE HoaDonBan_id = @hoaDonId AND SanPham_id = @sanPhamId";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@hoaDonId", SqlDbType.Int) { Value = hoaDonId },
                new SqlParameter("@sanPhamId", SqlDbType.Int) { Value = sanPhamId },
                new SqlParameter("@soLuong", SqlDbType.Int) { Value = soLuong }
            };

            try
            {
                da.OpenConnection();
                da.ExecuteNonQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật số lượng sản phẩm trong chi tiết hóa đơn bán: " + ex.Message);
            }
          
        }
        public bool insertChiTietHoaDonBan(int HoaDonBan_id, int SanPham_id, int soLuong, DateTime SanPham_NgayHetHan)
        {
            string query = "INSERT INTO ChiTietHoaDonBan " +
                           "VALUES (@HoaDonBan_id, @SanPham_id, @soLuong, @SanPham_NgayHetHan)";
            SqlParameter[] parameters = new SqlParameter[]
               {
                new SqlParameter("@HoaDonBan_id", SqlDbType.Int) { Value = HoaDonBan_id },
                new SqlParameter("@SanPham_id", SqlDbType.Int) { Value = SanPham_id },
                new SqlParameter("@soLuong", SqlDbType.Int) { Value = soLuong },
                new SqlParameter("@SanPham_NgayHetHan", SqlDbType.Date) { Value = SanPham_NgayHetHan }  
               };
            try
            {
                int rowsAffected = da.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Tạo Chi Tiết Hóa Đơn Bán Thất Bại: " + ex.Message);
            }
        }
    }
}
