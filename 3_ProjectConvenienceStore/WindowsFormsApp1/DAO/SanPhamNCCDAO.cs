using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DTO;
namespace WindowsFormsApp1.DAO
{
    public class SanPhamNCCDAO
    {
        SanPhamNCCDTO spncc = new SanPhamNCCDTO();
        DataConnect da = new DataConnect();
        public SanPhamNCCDAO()
        {
            spncc = new SanPhamNCCDTO();
        }
        //get all san pham nha cung cap
        public DataTable GetAllSanPhamNCC()
        {
            DataTable dt = new DataTable();
            string query = "SELECT id,ten,LoaiSanPham_id,donGia,urlAnh,ngayHetHan FROM SanPhamNCC where trangThai = 1";

            try
            {
                da.OpenConnection();
                dt = da.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                da.CloseConnection();
            }
            return dt;
        }

        // them sp nha cung cap
        public bool insertSanPham(SanPhamNCCDTO sp)
        {
            string query = "INSERT INTO SanPhamNCC (ten, LoaiSanPham_id, donGia, urlAnh, ngayHetHan, trangThai) " +
                           "VALUES (@ten,@LoaiSanPham_id, @donGia, @urlAnh, @ngayHetHan, @trangThai)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten", SqlDbType.NVarChar) { Value = sp.ten },
                new SqlParameter("@LoaiSanPham_id", SqlDbType.Int) { Value = sp.LoaiSanPham_id },
                new SqlParameter("@donGia", SqlDbType.Int) { Value = sp.donGia },
                new SqlParameter("@urlAnh", SqlDbType.VarBinary) { Value = sp.urlAnh },
                new SqlParameter("@ngayHetHan", SqlDbType.Date) { Value = sp.ngayHetHan },
                new SqlParameter("@trangThai", SqlDbType.Bit) { Value = sp.trangThai }
            };
            try
            {
                da.OpenConnection();
                int rowsAffected = da.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                da.CloseConnection();
            }
        }

        // xoa san pham nha cung cap
        public bool deleteSanPham(int id)
        {
            string query = "DELETE FROM SanPhamNCC WHERE id=@id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };
            try
            {
                da.OpenConnection();
                int rowsAffected = da.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                da.CloseConnection();
            }
        }

        // cap nhat san pham gia, ngay het han, trang thai
        public bool updateSanPham(SanPhamNCCDTO spncc)
        {
            string query = "UPDATE SanPhamNCC SET donGia=@gia, ngayHetHan=@ngay, trangThai=@trangthai WHERE id = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@gia", SqlDbType.Int) { Value = spncc.donGia },
                new SqlParameter("@ngay", SqlDbType.Date) { Value = spncc.ngayHetHan },
                new SqlParameter("@trangthai", SqlDbType.Bit) { Value = spncc.trangThai },
                new SqlParameter("@id", SqlDbType.Int) { Value = spncc.id }
            };
            try
            {
                da.OpenConnection();
                int rowsAffected = da.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                da.CloseConnection();
            }
        }

        // lay san pham nha cung cap theo danh muc san pham
        public DataTable GetSanPhamNCCByLoaiSanPham(int loaiSanPhamId)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM SanPhamNCC WHERE LoaiSanPham_id = @LoaiSanPham_id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LoaiSanPham_id", SqlDbType.Int) { Value = loaiSanPhamId }
            };

            try
            {
                da.OpenConnection();
                dt = da.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy sản phẩm theo danh mục thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                da.CloseConnection();
            }

            return dt;
        }

        // lay san pham nha cung cap theo ten 
        public DataTable GetSanPhamNCCByName(string tenSanPham)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM SanPhamNCC WHERE ten LIKE @tenSanPham";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenSanPham", SqlDbType.NVarChar) { Value = "%" + tenSanPham + "%" }
            };

            try
            {
                da.OpenConnection();
                dt = da.ExecuteQuery(query, parameters);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tìm kiếm sản phẩm theo tên thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // get DonGia by sanPhamId
        public int getDonGia(int sanPhamId)
        {
            string query = "SELECT donGia FROM SanPhamNCC WHERE id = @sanPhamId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@sanPhamId", SqlDbType.Int) { Value = sanPhamId }
            };
            try
            {
                object result = da.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn giá cho sản phẩm với mã: " + sanPhamId, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy đơn giá sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public string getTenById(int sanPhamId)
        {
            string query = "SELECT ten FROM SanPhamNCC WHERE id = @sanPhamId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@sanPhamId", SqlDbType.Int) { Value = sanPhamId }
            };
            try
            {
                object result = da.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn giá cho sản phẩm với mã: " + sanPhamId, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy đơn giá sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

        }



        public DataTable getDatatable(int i)
        {
            DataTable dt = new DataTable();
            string querry = "SELECT * FROM SanPhamNCC Where trangThai = '" + i + "'";
            dt = da.ExecuteQuery(querry);
            return dt;
        }
        public int getNextIdSanPhamNCC()
        {
            string query = "select count(id) from SanPhamNCC";
            return Convert.ToInt32(da.ExecuteScalar(query, new SqlParameter[] { }));
        }

        public int themSanPhamNCC(string ten, int loaiSanPham, string donGia, string urlAnh, string ngayHetHan)
        {
            string query = "INSERT INTO SanPhamNCC (ten,LoaiSanPham_id,donGia,urlAnh,ngayHetHan,trangThai) " +
                $"VALUES (N'{ten}',{loaiSanPham},{donGia}, " +
                $"(SELECT * FROM OPENROWSET(BULK N'{urlAnh}', SINGLE_BLOB) AS Anh),'{ngayHetHan}',1)";
            return da.ExecuteNonQuery(query, new SqlParameter[] { });
        }
        public bool updateSanPhamNCC(string id, string ten, int loaiSanPham_id,
                                    string donGia, string urlAnh, string ngayHetHan, bool trangThai)
        {
            string query;
            SqlParameter[] parameters;

            if (urlAnh == "")
            {
                query = $"UPDATE SanPhamNCC SET ten = N'{ten}',LoaiSanPham_id ={loaiSanPham_id}," +
                $"donGia = {donGia}," +
                $"ngayHetHan = '{ngayHetHan}' , trangThai = @trangThai WHERE id = {id}";
                parameters = new SqlParameter[] { new SqlParameter("@trangthai", SqlDbType.Bit) { Value = trangThai } };
            }
            else
            {
                query = $"UPDATE SanPhamNCC SET ten = N'{ten}',LoaiSanPham_id ={loaiSanPham_id}," +
                $"donGia = {donGia}," +
                $"urlAnh = (SELECT * FROM OPENROWSET(BULK N'{urlAnh}', SINGLE_BLOB) AS Anh)" +
                $",ngayHetHan = '{ngayHetHan}' , trangThai = @trangThai WHERE id = {id}";
                parameters = new SqlParameter[] { new SqlParameter("@trangthai", SqlDbType.Bit) { Value = trangThai } };
            }

            try
            {
                int rowsAffected = da.ExecuteNonQuery(query, parameters);
                //MessageBox.Show(rowsAffected.ToString());
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi update SanPham: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //kiem tra san pham da co trong kho chua

        public bool kiemTraSPTrongKho(int id)
        {
            string query = "SELECT COUNT(id) FROM SanPham WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };
            try
            {
            
                int count = (int)da.ExecuteScalar(query, parameters);
                return count > 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public int getLoaiSPById(int id)
        {
            string query = "SELECT LoaiSanPham_id FROM SanPhamNCC WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };
            try
            {
                object rowsAffected = da.ExecuteScalar(query, parameters);
                return Convert.ToInt32(rowsAffected);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

            public byte[] getAnhSPById(int id)
            {
                string query = "SELECT urlAnh FROM SanPhamNCC WHERE id=@id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@id", SqlDbType.Int) { Value = id }
                };
                try
                {
                    object rowsAffected = da.ExecuteScalar(query, parameters);
                return (byte[])(rowsAffected);
            }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
    }
}