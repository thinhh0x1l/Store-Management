using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class HoaDonNhapDAO
    {
        public DataConnect da = new DataConnect();
        public ChiTietHoaDonNhapDAO chiTietHoaDonDAO = new ChiTietHoaDonNhapDAO();
        public SanPhamNCCDAO sanPhamNCCDAO = new SanPhamNCCDAO();


        public HoaDonNhapDAO()
        {
            da = new DataConnect();
        }

        // Lay ma don
        public int getID()
        {
            object id = null;
            int hdid = 0;
            string query = "SELECT COUNT (*) FROM HoaDonNHap";
            try
            {
                //da.OpenConnection();
                id = da.ExecuteScalar(query);
                if (id != null)
                {
                    hdid = Convert.ToInt32(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy id hóa đơn : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hdid;

        }


        // Thêm hóa đơn nhập
        public bool AddHoaDonNhap(HoaDonNhapDTO hdn)
        {
            string query = "INSERT INTO HoaDonNhap (NhanVien_id, ngayNhap, gioNhap, tongTien) VALUES (@nvid, @ngayNhap, @gioNhap, @tongTien)";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@nvid", SqlDbType.VarChar) { Value = hdn.NhanVien_id },
                new SqlParameter("@ngayNhap", SqlDbType.Date) { Value = hdn.ngayNhap },
                new SqlParameter("@gioNhap", SqlDbType.Time) { Value = hdn.gioNhap },
                new SqlParameter("@tongTien", SqlDbType.BigInt) { Value = hdn.tongTien }
            };

          
                return da.ExecuteNonQuery(query, sqlParameters) > 0;
              //  MessageBox.Show("Thêm hóa đơn nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        // Thêm sản phẩm vào hóa đơn nhập
        public void AddSanPhamVaoGio(int hoaDonId, SanPhamNCCDTO sp, int sl)
        {
            try
            {
                ChiTietHoaDonNhapDTO chiTiet = new ChiTietHoaDonNhapDTO
                {
                    SanPhamNCC_id = sp.id,
                    soLuong = sl,
                    SanPham_NgayHetHan = sp.ngayHetHan
                };
                chiTietHoaDonDAO.addChiTietHoaDon(hoaDonId, chiTiet);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm vào hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tính tổng tiền


        // Tổng số lượng sản phẩm trong hóa đơn
        public int SoLuong(int hoaDonId)
        {
            int tongSoLuong = 0;
            try
            {
                List<ChiTietHoaDonNhapDTO> lst = chiTietHoaDonDAO.getListChiTietHD(hoaDonId);
                foreach (var chiTiet in lst)
                {
                    if (chiTiet.soLuong != null)
                    {
                        int soLuong = chiTiet.soLuong;
                        tongSoLuong += soLuong;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng số lượng sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tongSoLuong;
        }





        // Lấy hóa đơn theo ngày
        public DataTable GetHoaDonTheoNgay(DateTime ngayNhap)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM HoaDonNhap WHERE CAST(ngayNhap AS DATE) = @ngayNhap";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@ngayNhap", SqlDbType.Date) { Value = ngayNhap }
            };

            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy hóa đơn theo ngày: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // Lấy hóa đơn theo tháng
        public DataTable GetHoaDonTheoThang(DateTime thang)
        {
            DataTable dt = new DataTable();
            DateTime startDate = new DateTime(thang.Year, thang.Month, 1);
            DateTime startDateNextMonth = startDate.AddMonths(1);

            string query = "SELECT * FROM HoaDonNhap WHERE ngayNhap >= @startDate AND ngayNhap < @startDateNextMonth ORDER BY id DESC";

            SqlParameter[] sqlParameters =
            {
        new SqlParameter("@startDate", SqlDbType.Date) { Value = startDate },
        new SqlParameter("@startDateNextMonth", SqlDbType.Date) { Value = startDateNextMonth }
    };

            try
            {
               // da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy hóa đơn theo tháng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // Lấy hóa đơn theo năm
        public DataTable GetHoaDonTheoNam(DateTime nam)
        {
            DataTable dt = new DataTable();
            int year = nam.Year;

            string query = "SELECT * FROM HoaDonNhap WHERE YEAR(ngayNhap) = @nam ORDER BY id DESC";

            SqlParameter[] sqlParameters =
            {
        new SqlParameter("@nam", SqlDbType.Int) { Value = year }
    };

            try
            {
               // da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy hóa đơn theo năm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // Lấy hóa đơn theo mã nhân viên và ngày
        public DataTable GetHoaDonTheoMaNVVaNgay(string nhanVienId, DateTime ngayNhap)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM HoaDonNhap WHERE NhanVien_id = @nhanVienId ";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@nhanVienId", SqlDbType.VarChar) { Value = nhanVienId }
            };

            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy hóa đơn theo mã nhân viên và ngày: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        //san pham duoc nhap nhieu nhat theo thang

        public DataTable GetSPNhapNhieuTheoThang(DateTime thang)
        {
            DataTable dt = new DataTable();
            DateTime startDate = new DateTime(thang.Year, thang.Month, 1);
            DateTime startDateNextMonth = startDate.AddMonths(1);

            string query = "SELECT TOP 20 spncc.id, spncc.ten, spncc.urlAnh, lsp.ten AS LoaiSanPham, spncc.ngayHetHan, SUM(cthdn.soLuong) AS SoLuongNhap" +
                " FROM ChiTietHoaDonNhap cthdn" +
                " INNER JOIN SanPhamNCC spncc ON cthdn.SanPhamNCC_id = spncc.id " +
                "INNER JOIN LoaiSanPham lsp ON lsp.id = spncc.LoaiSanPham_id " +
                "INNER JOIN HoaDonNhap hdn ON cthdn.HoaDonNhap_id = hdn.id" +
                " WHERE hdn.ngayNhap >= @startDate AND hdn.ngayNhap < @startDateNextMonth" +
                " GROUP BY spncc.id, spncc.ten, spncc.urlAnh, spncc.ngayHetHan, lsp.ten ORDER BY SoLuongNhap DESC ";


            SqlParameter[] sqlParameters =
            {
        new SqlParameter("@startDate", SqlDbType.Date) { Value = startDate },
        new SqlParameter("@startDateNextMonth", SqlDbType.Date) { Value = startDateNextMonth }
    };

            try
            {
               // da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy hóa đơn theo tháng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        //kiemtra nhan vien co hoa don chua
        public bool kiemTraNV(string nv)
        {
            string query = @"SELECT COUNT(*) 
                     FROM HoaDonNhap 
                     WHERE NhanVien_id = @id;";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.VarChar) { Value = nv }
            };
            try
            {
                //da.OpenConnection();
                object rowsAffected = da.ExecuteScalar(query, parameters);

                return Convert.ToInt32(rowsAffected) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        // Lấy tất cả hóa đơn
        public DataTable GetHoaDonNhap()
        {
            string query = "SELECT * FROM HoaDonNhap";
            DataTable dt = new DataTable();
            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lấy hóa đơn thất bại: " + ex.Message);
            }

            return dt;
        }

        
        // lay hoa don theo ma nhan vien va ngay hoa don
        public DataTable GetHoaDonTheoMaNVVaNgay(int nhanVienId, DateTime ngayban)
        {
            string query = "SELECT * FROM HoaDonBan WHERE NhanVien_id = @nhanVienId AND ngayBan = @ngayban";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
        new SqlParameter("@nhanVienId", SqlDbType.Int) { Value = nhanVienId },
        new SqlParameter("@ngayban", SqlDbType.Date) { Value = ngayban }
            };

            DataTable dt = new DataTable();
            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy hóa đơn theo mã nhân viên và ngày: " + ex.Message);
            }

            return dt;
        }

    }
}
