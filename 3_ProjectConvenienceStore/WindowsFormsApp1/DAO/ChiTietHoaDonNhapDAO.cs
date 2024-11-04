using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;
using System.Windows.Forms;

namespace WindowsFormsApp1.DAO
{
    public class ChiTietHoaDonNhapDAO
    {
        public DataConnect da = new DataConnect();
        public SanPhamDAO sp = new SanPhamDAO();
        public SanPhamNCCDAO spncc = new SanPhamNCCDAO();
        // Lấy chi tiết hóa đơn
        public ChiTietHoaDonNhapDAO() { da = new DataConnect(); }
        public DataTable getChiTietHD(int hoaDonId)
        {
            DataTable dt = new DataTable();
            string query = @"
                          SELECT 
                            sp.ten,
                            sp.id,
                            ct.soLuong,
                            sp.donGia,
                            ct.Sanpham_NgayHetHan
                          FROM 
                            ChiTietHoaDonNhap ct
                          INNER JOIN 
                           SanPhamNCC sp ON ct.SanPhamNCC_id = sp.id
                         WHERE 
                            ct.HoaDonNhap_id = @hoaDonId";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@hoaDonId", SqlDbType.Int) { Value = hoaDonId }
            };

            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, sqlParameters);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Lấy chi tiết hóa đơn theo mã hóa đơn
        public List<ChiTietHoaDonNhapDTO> getListChiTietHD(int hoaDonId)
        {
            try
            {
                DataTable dt = getChiTietHD(hoaDonId);
                List<ChiTietHoaDonNhapDTO> chiTietList = new List<ChiTietHoaDonNhapDTO>();
                if (dt == null || dt.Rows.Count == 0)
                    return chiTietList;

                foreach (DataRow row in dt.Rows)
                {
                    ChiTietHoaDonNhapDTO chiTiet = new ChiTietHoaDonNhapDTO
                    {
                        HoaDonNhap_id = hoaDonId,
                        SanPhamNCC_id = Convert.ToInt32(row["id"]),
                        soLuong = Convert.ToInt32(row["soLuong"]),
                        SanPham_NgayHetHan = Convert.ToDateTime(row["Sanpham_NgayHetHan"])
                    };

                    chiTietList.Add(chiTiet);
                }

                return chiTietList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chi tiết hóa đơn: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ChiTietHoaDonNhapDTO>();
            }
        }

        //
        public void removeSP(int id)
        {
            List<ChiTietHoaDonNhapDTO> lst = new List<ChiTietHoaDonNhapDTO>();
            foreach (var chitiet in danhSachChiTietHoaDon)
            {
                if (chitiet.SanPhamNCC_id == id) lst.Add(chitiet);
            }
            foreach (var chitiet in lst)
            {
                danhSachChiTietHoaDon.Remove(chitiet);
            }
        }
        public List<ChiTietHoaDonNhapDTO> danhSachChiTietHoaDon = new List<ChiTietHoaDonNhapDTO>();

        public List<ChiTietHoaDonNhapDTO> addChiTietHoaDonVaoList(int hoaDonId, SanPhamNCCDTO sp)
        {
            ChiTietHoaDonNhapDTO chiTiet = new ChiTietHoaDonNhapDTO(hoaDonId, sp.id, 1, sp.ngayHetHan);
            danhSachChiTietHoaDon.Add(chiTiet);
            return danhSachChiTietHoaDon;


        }
        public long tinhTongTienAllCTHD(List<ChiTietHoaDonNhapDTO> lst)
        {
            long tongTien = 0;
            foreach (var chiTiet in lst)
            {
                long donGia = Convert.ToInt64(spncc.getDonGia(chiTiet.SanPhamNCC_id));


                tongTien += chiTiet.soLuong * donGia;
            }
            return tongTien;
        }
        public int tongSLCTHD(List<ChiTietHoaDonNhapDTO> lst)
        {
            int sl = 0;
            foreach (var chiTiet in lst)
            {
                int sp = chiTiet.soLuong;


                sl += sp;
            }
            return sl;
        }

        public DataTable ChuyenListToDataTable(List<ChiTietHoaDonNhapDTO> listChiTiet)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("Mã Sản Phẩm", typeof(int));
            dt.Columns.Add("Số Lượng", typeof(int));
            dt.Columns.Add("Ngày Hết Hạn", typeof(DateTime));

            foreach (var chiTiet in listChiTiet)
            {
                DataRow row = dt.NewRow();
                row["Mã Sản Phẩm"] = chiTiet.SanPhamNCC_id;
                row["Số Lượng"] = chiTiet.soLuong;
                row["Ngày Hết Hạn"] = chiTiet.SanPham_NgayHetHan;

                dt.Rows.Add(row);
            }

            return dt;
        }

        public void capNhatSoLuongCTHD(int hdid, int spid, int sl)
        {

            foreach (var chiTiet in danhSachChiTietHoaDon)
            {
                if (chiTiet.SanPhamNCC_id == spid && chiTiet.HoaDonNhap_id == hdid)
                {
                    chiTiet.soLuong = sl;
                    break;
                }
            }


        }
        public bool LuuDanhSachChiTietHoaDon(int hdid, List<ChiTietHoaDonNhapDTO> chiTietList)
        {
            foreach (var chiTiet in chiTietList)
            {
                bool isSaved = addChiTietHoaDon(hdid, chiTiet);
                if (!isSaved)
                {
                    return false;
                }
            }
            return true;
        }

        public bool addChiTietHoaDon(int hoaDonId, ChiTietHoaDonNhapDTO chiTiet)
        {
            string query = "INSERT INTO ChiTietHoaDonNhap (HoaDonNhap_id, SanPhamNCC_id, soLuong, SanPham_NgayHetHan) VALUES (@hoaDonId, @sanPhamId, @soLuong, @ngayhethan)";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@hoaDonId", SqlDbType.Int) { Value = hoaDonId },
                new SqlParameter("@sanPhamId", SqlDbType.Int) { Value = chiTiet.SanPhamNCC_id },
                new SqlParameter("@soLuong", SqlDbType.Int) { Value = chiTiet.soLuong },
                new SqlParameter("@ngayhethan", SqlDbType.Date) { Value = chiTiet.SanPham_NgayHetHan}
            };

            try
            {
                //da.OpenConnection();
                int rs = da.ExecuteNonQuery(query, sqlParameters);

                if (rs > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        // Xóa chi tiết hóa đơn theo ID
        public bool deleteCTHDByHDId(int hoaDonId)
        {
            string query = "DELETE FROM ChiTietHoaDonNhap WHERE HoaDonNhap_id=@hoaDonId";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@hoaDonId", SqlDbType.Int) { Value = hoaDonId }
            };
            try
            {
                //da.OpenConnection();
                int rowAffected = da.ExecuteNonQuery(query, sqlParameters);
                if (rowAffected > 0)
                {
                    MessageBox.Show("Xóa chi tiết hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chi tiết hóa đơn để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết hóa đơn: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }


        public int tongTienSPTam(int hdid, int spid, int sl)
        {

            int soLuongMoi = sl;
            int soTienSP = spncc.getDonGia(spid);
            int capNhatTien = soLuongMoi * soTienSP;
            return capNhatTien;
        }


        //them so luong vao san pham
        public bool capNhatSoLuongSP(int hdid, int spid, int sl, DateTime ngayHetHan)
        {
            // Lấy ngày hết hạn của sản phẩm trong kho
            DateTime ngayHetHanSP = sp.getNgayHetHan(spid);
            int soLuongSPHienCo = 0;
            int donGia = 0;
            string ten = "";
            int loaispid = 0;
            byte[] anh = null;
            SqlParameter[] parameters;
            string query = "";

            // Kiểm tra sản phẩm đã có trong kho chưa
            if (!spncc.kiemTraSPTrongKho(spid)) // chưa có
            {
                donGia = spncc.getDonGia(spid);
                ten = spncc.getTenById(spid);
                loaispid = spncc.getLoaiSPById(spid);
                anh = spncc.getAnhSPById(spid); 

                query = "SET IDENTITY_INSERT SanPham ON;" +
                       " INSERT INTO SanPham(id, ten, LoaiSanPHam_id, donGia, urlAnh, ngayHetHan, trangThai, soLuong) " +
                        "VALUES(@id,@ten, @loaisp, @dongia, @anh, @ngayHetHan, 2, @sl)" +
                        "";

                parameters = new SqlParameter[]
                {
                   new SqlParameter("@id", SqlDbType.Int) { Value = spid },
                   new SqlParameter("@ten", SqlDbType.NVarChar) { Value = ten },
                   new SqlParameter("@donGia", SqlDbType.Int) { Value = donGia },
                   new SqlParameter("@loaisp", SqlDbType.Int) { Value = loaispid },
                   new SqlParameter("@sl", SqlDbType.Int) { Value = sl },
                   new SqlParameter("@ngayHetHan", SqlDbType.Date) { Value = ngayHetHan },
                   new SqlParameter("@anh", SqlDbType.VarBinary) { Value = anh }
                };
            }
            else if (ngayHetHanSP.Date == ngayHetHan.Date)
            {
                soLuongSPHienCo = sp.soluongHienTai(spid, ngayHetHanSP);
                query = "UPDATE SanPham SET soLuong=@sl WHERE id=@id";

                parameters = new SqlParameter[]
                {
            new SqlParameter("@sl", SqlDbType.Int) { Value = sl + soLuongSPHienCo },
            new SqlParameter("@id", SqlDbType.Int) { Value = spid }
                };
            }
            else
            {
                soLuongSPHienCo = sl;
                ten = spncc.getTenById(spid);
                loaispid = sp.getLoaiSPByID(spid);
                donGia = sp.getDonGia(spid);
                anh = spncc.getAnhSPById(spid);
                query = "SET IDENTITY_INSERT SanPham ON; " +
                        "INSERT INTO SanPham(id, ten, LoaiSanPHam_id, donGia, urlAnh, ngayHetHan, trangThai, soLuong) " +
                        "VALUES(@id, @ten, @loaisp, @dongia, @anh, @ngayHetHan, 2, @sl); " +
                        "";

                parameters = new SqlParameter[]
                {
            new SqlParameter("@id", SqlDbType.Int) { Value = spid },
            new SqlParameter("@ten", SqlDbType.NVarChar) { Value = ten },
            new SqlParameter("@donGia", SqlDbType.Int) { Value = donGia },
            new SqlParameter("@loaisp", SqlDbType.Int) { Value = loaispid },
            new SqlParameter("@sl", SqlDbType.Int) { Value = sl },
            new SqlParameter("@ngayHetHan", SqlDbType.Date) { Value = ngayHetHan },
            new SqlParameter("@anh", SqlDbType.VarBinary) { Value = anh }
                };
            }

            try
            {
                //da.OpenConnection();
                int rs = da.ExecuteNonQuery(query, parameters);
                return rs > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật số lượng sản phẩm: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                //da.OpenConnection();
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
                //da.OpenConnection();
                da.ExecuteNonQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật số lượng sản phẩm trong chi tiết hóa đơn bán: " + ex.Message);
            }

        }
    }
}
