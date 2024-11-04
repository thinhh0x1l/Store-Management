using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class HoaDonBanDAO
    {
        public DataConnect da = new DataConnect();
        public ChiTietHoaDonNhapDAO chiTietHoaDonDAO = new ChiTietHoaDonNhapDAO();
        public SanPhamDAO sanPhamDAO = new SanPhamDAO();
        public HoaDonBanDAO() { da = new DataConnect(); }
        // Lấy tất cả hóa đơn
        public DataTable GetHoaDonBan()
        {
            string query = "SELECT * FROM HoaDonBan";
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

        // Thêm hóa đơn bán
        public void AddHoaDonBan(HoaDonBanDTO hdb)
        {
            string query = "INSERT INTO HoaDonBan (KhachHang_id, NhanVien_id, ngayBan, gioBan, tongTien) VALUES (@khid, @nvid, @ngayban, @gioban, @tongtien)";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@khid", SqlDbType.Int) { Value = hdb.KhachHang_id },
                new SqlParameter("@nvid", SqlDbType.Int) { Value = hdb.NhanVien_id },
                new SqlParameter("@ngayban", SqlDbType.Date) { Value = hdb.ngayBan },
                new SqlParameter("@gioban", SqlDbType.Time) { Value = hdb.gioBan },
                new SqlParameter("@tongtien", SqlDbType.BigInt) { Value = hdb.tongTien }
            };

            try
            {
                //da.OpenConnection();
                da.ExecuteNonQuery(query, sqlParameters);
                MessageBox.Show("Thêm hóa đơn bán thành công");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm hóa đơn bán: " + ex.Message);
            }

        }


        // Lấy hóa đơn theo ngày
        public DataTable GetHoaDonTheoNgay(DateTime ngayBan)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM HoaDonBan WHERE CAST(ngayBan AS DATE) = @ngayBan";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@ngayBan", SqlDbType.Date) { Value = ngayBan }
            };

            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy hóa đơn theo ngày: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }

        //list hoa don theo ngay
        public List<HoaDonBanDTO> listHDBTheoNgay(DataTable hdb)
        {
            List<HoaDonBanDTO> list = new List<HoaDonBanDTO>();
            foreach (DataRow row in hdb.Rows)
            {
                HoaDonBanDTO hoadon = new HoaDonBanDTO();
                hoadon.id = Convert.ToInt32(row["id"]);
                hoadon.NhanVien_id = row["NhanVien_id"].ToString();
                hoadon.KhachHang_id = Convert.ToInt32(row["KhachHang_id"]);
                hoadon.ngayBan = Convert.ToDateTime(row["ngayBan"]);
                hoadon.gioBan = (TimeSpan)row["gioBan"];
                hoadon.tongTien = Convert.ToInt32(row["tongTien"]);
                list.Add(hoadon);
            }
            return list;
        }
        ChiTietHoaDonBanDAO cthdb = new ChiTietHoaDonBanDAO();


        //tinh tong phi nhap theo san pham bang hoa don id
        public long tongPhiNhapSP(List<HoaDonBanDTO> list)
        {
            long sum = 0;
            foreach (HoaDonBanDTO hd in list)
            {
                sum += TinhTongChiPhiNhap(hd.id);
            }
            return sum;
        }

        //lay hoa don theo thang
        public DataTable GetHoaDonTheoThang(DateTime thang)
        {
            DataTable dt = new DataTable();
            DateTime startDate = new DateTime(thang.Year, thang.Month, 1);
            DateTime startDateNextMonth = startDate.AddMonths(1);

            string query = "SELECT * FROM HoaDonBan WHERE ngayBan >= @startDate AND ngayBan < @startDateNextMonth ORDER BY id DESC";

            SqlParameter[] sqlParameters =
            {
        new SqlParameter("@startDate", SqlDbType.Date) { Value = startDate },
        new SqlParameter("@startDateNextMonth", SqlDbType.Date) { Value = startDateNextMonth }
    };

            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy hóa đơn theo tháng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public DataTable GetHoaDonTheoNam(DateTime nam)
        {
            DataTable dt = new DataTable();
            int year = nam.Year;

            string query = "SELECT * FROM HoaDonBan WHERE YEAR(ngayBan) = @nam ORDER BY id DESC";

            SqlParameter[] sqlParameters =
            {
              new SqlParameter("@nam", SqlDbType.Int) { Value = year }
    };

            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy hóa đơn theo năm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // lay hoa don theo ma nhan vien va ngay hoa don
        public DataTable GetHoaDonTheoMaNVVaNgay(string nhanVienId, DateTime ngayban)
        {
            string query = "SELECT * FROM HoaDonBan WHERE NhanVien_id = @nhanVienId  ORDER BY id DESC";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
        new SqlParameter("@nhanVienId", SqlDbType.VarChar) { Value = nhanVienId }
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
        //lay hoa don theo sdt khach hang
        public DataTable GetHoaDonTheoSDT(string sdt)
        {
            string query = "SELECT hdb.id, hdb.KhachHang_id, hdb.NhanVien_id, hdb.ngayBan, hdb.gioBan, hdb.tongTien " +

                    "FROM HoaDonBan hdb " +
                    "INNER JOIN KhachHang kh ON hdb.KhachHang_id = kh.id " +
                    "WHERE kh.SDT = @sdt";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
             new SqlParameter("@sdt", SqlDbType.VarChar) { Value = sdt },

            };

            DataTable dt = new DataTable();
            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy hóa đơn theo số điện thoại : " + ex.Message);
            }

            return dt;
        }
        //kiem tra kh co hoa don khong bang sdt
        public bool checkHD(string sdt)
        {
            string query = "SELECT KhachHang_id FROM HoaDonBan INNER JOIN KhachHang kh ON KhachHang_id=kh.id WHERE kh.SDT=@sdt";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
             new SqlParameter("@sdt", SqlDbType.VarChar) { Value = sdt },

            };


            try
            {
                //da.OpenConnection();
                object result = da.ExecuteScalar(query, sqlParameters);
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result) > 0;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                return false;
            }


        }
        //tính tổng thu hóa đơn theo ngày
        public long tongThuTheoNgay(DateTime ngayBan)
        {
            long tongThu = 0;
            string query = "SELECT SUM(tongTien) FROM HoaDonBan WHERE CAST(ngayBan AS DATE) = @ngayBan";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@ngayBan", SqlDbType.Date) { Value = ngayBan }
            };

            try
            {
                //da.OpenConnection();
                object rs = da.ExecuteScalar(query, sqlParameters);
                if (rs != null)
                {
                    tongThu = Convert.ToInt64(Convert.ToDecimal(rs));
                }
                else return 0;

            }
            catch (Exception ex)
            {
                return 0;
            }
            return tongThu;
        }


        public DataTable ThongKeDoanhThuTheoThang(DateTime thang)
        {
            DataTable dt = new DataTable();


            DateTime startDate = new DateTime(thang.Year, thang.Month, 1);
            DateTime endDate = startDate.AddMonths(1);

            string query = "SELECT CAST(ngayBan AS DATE) AS Ngay, SUM(tongTien) AS DoanhThu " +
                           "FROM HoaDonBan " +
                           "WHERE ngayBan >= @startDate AND ngayBan < @endDate " +
                           "GROUP BY CAST(ngayBan AS DATE) " +
                           "ORDER BY Ngay";

            SqlParameter[] sqlParameters =
            {
        new SqlParameter("@startDate", SqlDbType.Date) { Value = startDate },
        new SqlParameter("@endDate", SqlDbType.Date) { Value = endDate }
    };

            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public DataTable ThongKeDoanhThuTheoNam(DateTime nam)
        {
            DataTable dt = new DataTable();


            DateTime startDate = new DateTime(nam.Year, 1, 1);
            DateTime endDate = startDate.AddYears(1);

            string query = "SELECT MONTH(ngayBan) AS Thang, SUM(tongTien) AS DoanhThu " +
                    "FROM HoaDonBan " +
                    "WHERE ngayBan >= @startDate AND ngayBan < @endDate " +
                    "GROUP BY MONTH(ngayBan) " +
                    "ORDER BY Thang";


            SqlParameter[] sqlParameters =
            {
            new SqlParameter("@startDate", SqlDbType.Date) { Value = startDate },
           new SqlParameter("@endDate", SqlDbType.Date) { Value = endDate }
           };

            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return dt;
        }


        //tong chi phi nhap theo hoa don ngay de lay doanh thu theo ngay
        public long TinhTongChiPhiNhap(int hoaDonId)
        {
            long tongChiPhiNhap = 0;
            string query = @"SELECT SUM(spncc.donGia * ct.soLuong)
                     FROM ChiTietHoaDonBan ct
                     INNER JOIN SanPham sp ON ct.SanPham_id = sp.id
                     INNER JOIN SanPhamNCC spncc ON sp.id = spncc.id
                     WHERE ct.HoaDonBan_id = @hoaDonId AND ct.Sanpham_NgayHetHan=sp.ngayHetHan";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
        new SqlParameter("@hoaDonId", SqlDbType.VarChar) { Value = hoaDonId }
            };

            try
            {
                //da.OpenConnection();
                object result = da.ExecuteScalar(query, sqlParameters);
                if (result != null)
                {
                    tongChiPhiNhap = Convert.ToInt64(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng chi phí nhập: " + ex.Message);
            }


            return tongChiPhiNhap;
        }
        //tinh chi phi nhap theo ngay de lay doanh thu theo thang
        public long TongChiPhiNhapTheoNgay(DateTime date)
        {
            long sum = 0;
            string query = @"SELECT SUM(spncc.donGia*cthd.soLuong) " +
                          "FROM ChiTietHoaDonBan cthd " +
                          "INNER JOIN SanPham sp ON cthd.SanPham_id = sp.id " +
                          "INNER JOIN SanPhamNCC spncc ON sp.id = spncc.id " +
                          "INNER JOIN HoaDonBan hdb ON cthd.HoaDonBan_id = hdb.id " +
                          "WHERE hdb.ngayBan=@date AND cthd.Sanpham_NgayHetHan=sp.ngayHetHan";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@date", SqlDbType.Date) { Value = date } };

            try
            {
                //da.OpenConnection();
                object result = da.ExecuteScalar(query, sqlParameters);
                if (result != null)
                {
                    sum = Convert.ToInt64(result);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng chi phí nhập theo ngày: " + ex.Message);
            }

            return sum;

        }
        public long TongChiPhiNhapTheoThang(int thang, int nam)
        {
            long sum = 0;

            string query = @"SELECT SUM(spncc.donGia * cthd.soLuong) " +
                  "FROM ChiTietHoaDonBan cthd " +
                  "INNER JOIN SanPham sp ON cthd.SanPham_id = sp.id " +
                  "INNER JOIN SanPhamNCC spncc ON sp.id = spncc.id " +
                  "INNER JOIN HoaDonBan hdb ON cthd.HoaDonBan_id = hdb.id " +
                  "WHERE MONTH(hdb.ngayBan) = @thang AND YEAR(hdb.ngayBan) = @nam AND cthd.Sanpham_NgayHetHan=sp.ngayHetHan";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
        new SqlParameter("@thang", SqlDbType.Int) { Value = thang },
        new SqlParameter("@nam", SqlDbType.Int) { Value = nam }
            };
            try
            {
                //da.OpenConnection();
                object result = da.ExecuteScalar(query, sqlParameters);
                if (result != null)
                {
                    sum = Convert.ToInt64(result);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng chi phí nhập theo ngày: " + ex.Message);
            }

            return sum;

        }

        //san pham ban chay theo tháng
        public DataTable sanPhamBanChay(DateTime thang)
        {
            DataTable dt = new DataTable();

            DateTime startDate = new DateTime(thang.Year, thang.Month, 1);
            DateTime endDate = startDate.AddMonths(1);
            string query = @"SELECT sp.id, sp.ten, lsp.ten AS LoaiSanPham, sp.urlAnh, sp.ngayHetHan, SUM(cthd.soLuong) AS SoLuongBan
                     FROM ChiTietHoaDonBan cthd
                     INNER JOIN SanPham sp ON cthd.SanPham_id = sp.id
                     INNER JOIN LoaiSanPham lsp ON sp.LoaiSanPham_id = lsp.id
                     INNER JOIN HoaDonBan hdb ON cthd.HoaDonBan_id = hdb.id
                     WHERE hdb.ngayBan BETWEEN @startDate AND @endDate AND sp.trangThai=1
                     GROUP BY sp.id, sp.ten, lsp.ten, sp.urlAnh, sp.ngayHetHan
                     ORDER BY SoLuongBan DESC";
            SqlParameter[] sqlParameters =
             {
             new SqlParameter("@startDate", SqlDbType.Date) { Value = startDate },
             new SqlParameter("@endDate", SqlDbType.Date) { Value = endDate }
             };

            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách sản phẩm bán chạy: " + ex.Message);
            }
            return dt;
        }

        //lay san pham ban chay trong ngay

        public DataTable sanPhamBanChayTrongNgay(DateTime ngay)
        {
            DataTable dt = new DataTable();


            string query = @"SELECT TOP 10 sp.ten, sp.donGia, sp.urlAnh, SUM(cthd.soLuong) AS SoLuongBan
                     FROM ChiTietHoaDonBan cthd
                     INNER JOIN SanPham sp ON cthd.SanPham_id = sp.id
                     INNER JOIN HoaDonBan hdb ON cthd.HoaDonBan_id = hdb.id
                      WHERE CONVERT(DATE, hdb.ngayBan) = @ngayBan
                     GROUP BY sp.ten, sp.urlAnh, sp.donGia
                     ORDER BY SoLuongBan DESC";
            SqlParameter[] sqlParameters =
             {
             new SqlParameter("@ngayBan", SqlDbType.Date) { Value = ngay },

             };

            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách sản phẩm bán chạy: " + ex.Message);
            }
            return dt;
        }
        //kiem tra nhan vien da co hoa don ban chua
        public bool kiemTraNV(string nv)
        {
            string query = @"SELECT COUNT(*) 
                     FROM HoaDonBan 
                     WHERE NhanVien_id = @id;";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.VarChar) { Value = nv }
            };
            try
            {
               // da.OpenConnection();
                object rowsAffected = da.ExecuteScalar(query, parameters);

                return Convert.ToInt32(rowsAffected) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        //Lấy sinh hóa đơn kế tiếp 
        public int getNextOrder()
        {
            string query = "select count(id) from HoaDonban";
            return Convert.ToInt32(da.ExecuteScalar(query, new SqlParameter[] { }));
        }

        public bool insertHoaDonBan(string NhanVien_id, int KhachHang_id, int tongTien)
        {
            string query = "INSERT INTO HoaDonBan " +
                           "VALUES ( @KhachHang_id, @NhanVien_id, @ngayLap, @gioLap, @tongTien)";
            SqlParameter[] parameters = new SqlParameter[]
               {
                new SqlParameter("@KhachHang_id", SqlDbType.Int) { Value = KhachHang_id },
                new SqlParameter("@NhanVien_id", SqlDbType.VarChar) { Value = NhanVien_id },
                new SqlParameter("@ngayLap", SqlDbType.Date) { Value = DateTime.Now.ToString("yyyy-MM-dd") },
                new SqlParameter("@gioLap", SqlDbType.Time) { Value = DateTime.Now.ToString("HH:mm:ss") },
                new SqlParameter("@tongTien", SqlDbType.Int) { Value = tongTien }
               };
            try
            {
                int rowsAffected = da.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Lấy tất cả hóa đơn
        

        // Thêm sản phẩm vào giỏ // san pham * soluong = tong tien 
        //public void AddSanPhamVaoGio(int hoaDonId, int sanPhamId, int soLuong, DateTime ngayHH)
        //{
        //    try
        //    {
        //        if (chiTietHoaDonDAO.kiemTraSanPham(hoaDonId, sanPhamId))
        //        {
        //            // Nếu sản phẩm đã có trong chi tiết hóa đơn, cập nhật số lượng
        //            chiTietHoaDonDAO.capNhatSoLuong(hoaDonId, sanPhamId, soLuong);
        //        }
        //        else
        //        {
        //            // Nếu sản phẩm chưa có trong chi tiết hóa đơn, thêm mới
        //            ChiTietHoaDonBanDTO chiTiet = new ChiTietHoaDonBanDTO
        //            {
        //                SanPham_id = sanPhamId,
        //                soLuong = soLuong,
        //                Sanpham_NgayHetHan = ngayHH

        //            };
        //            chiTietHoaDonDAO.addChiTietHoaDon(hoaDonId, chiTiet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi thêm sản phẩm vào giỏ: " + ex.Message);
        //    }
        //}
        // tinh tong tien 
        //public int TinhTongTien(int hoaDonId)
        //{
        //    try
        //    {
        //        List<ChiTietHoaDonBanDTO> chiTietList = chiTietHoaDonDAO.getListChiTietHD(hoaDonId);
        //        int  tongTien = 0;

        //        foreach (var chiTiet in chiTietList)
        //        {
        //            int  donGia = sanPhamDAO.getDonGia(chiTiet.SanPham_id);
        //            tongTien += chiTiet.soLuong * donGia;
        //        }

        //        return tongTien;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi tính tổng tiền hóa đơn: " + ex.Message);
        //    }
        //}

        

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
