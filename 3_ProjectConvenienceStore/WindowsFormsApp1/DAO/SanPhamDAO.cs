using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace WindowsFormsApp1.DAO
{
    public class SanPhamDAO
    {
        private DataConnect data = new DataConnect();
        private SqlConnection conn = new SqlConnection(new Login().newConnect);
        public SanPhamDAO()
        {
            conn = new SqlConnection(new Login().newConnect);
            data = new DataConnect();
        }
        //lay don gia san pham
        public int getDonGia(int spid)
        {
            string query = " SELECT donGia FROM SanPham WHERE id=@spid";
            SqlParameter[] sqlParameters =
            {
              new SqlParameter("@spid", SqlDbType.Int) { Value = spid }
            };
            try
            {
                object result = data.ExecuteScalar(query, sqlParameters);

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn giá cho sản phẩm với mã: " + spid, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0; // hoặc giá trị mặc định khác nếu cần
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy đơn giá sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0; // hoặc giá trị mặc định khác nếu cần
            }
        }

        //show sản phẩm ra bảng
        public DataTable getSanPham()
        {
            DataTable dt = new DataTable();
            string query = " SELECT * FROM SanPham ORDER BY id ASC";
            try
            {
                dt = data.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        //chèn sản phẩm
        public bool insertSanPham(SanPhamDTO sp)
        {
            string query = "INSERT INTO SanPham(ten, LoaiSanPham_id, donGia, soLuong, urlAnh, ngayHetHan, trangThai) " +
                            "VALUES (@ten, @LoaiSanPham_id, @donGia, @soLuong, @urlAnh, @ngayHetHan, @trangThai)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten", SqlDbType.NVarChar) { Value = sp.ten },
                new SqlParameter("@LoaiSanPham_id", SqlDbType.Int) { Value = sp.LoaiSanPham_id },
                new SqlParameter("@donGia", SqlDbType.Int) { Value = sp.donGia },
                new SqlParameter("@soLuong", SqlDbType.Int) { Value = sp.soLuong },
                new SqlParameter("@urlAnh", SqlDbType.VarBinary) { Value = sp.urlAnh },
                new SqlParameter("@ngayHetHan", SqlDbType.Date) { Value = sp.ngayHetHan },
                new SqlParameter("@trangThai", SqlDbType.Int) { Value = sp.trangThai }
            };
            try
            {
                int rowsAffected = data.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Xóa sản phẩm theo id
        public bool deleteSanPhamById(int id)
        {
            string query = "DELETE FROM SanPham WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };
            try
            {
                int rowAffected = data.ExecuteNonQuery(query, parameters);
                return rowAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //lay san pham theo id
        public SanPhamDTO getSanPhamById(int id)
        {
            SanPhamDTO sp = null;
            string query = "SELECT * FROM SanPham WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };

            try
            {
                DataTable dt = new DataTable();
                dt = data.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    sp = new SanPhamDTO
                    {
                        id = Convert.ToInt32(row["id"]),
                        ten = Convert.ToString(row["ten"]),
                        LoaiSanPham_id = Convert.ToInt32(row["LoaiSanPham_id"]),
                        donGia = Convert.ToInt32(row["donGia"]),
                        soLuong = Convert.ToInt32(row["soLuong"]),
                        urlAnh = row["urlAnh"] != DBNull.Value ? (byte[])row["urlAnh"] : null,
                        ngayHetHan = Convert.ToDateTime(row["ngayHetHan"]),
                        trangThai = Convert.ToInt16(row["trangThai"])
                    };
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm với mã: " + id, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sp;
        }

        // Cập nhật sản phẩm
        public bool updateSanPhamById(SanPhamDTO sp)
        {
            string query = "UPDATE SanPham SET donGia=@donGia, soLuong=@soLuong, trangThai=@trangThai WHERE id=@id AND ngayHetHan=@ngayHetHan";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@donGia", SqlDbType.Int) { Value = sp.donGia },
                new SqlParameter("@soLuong", SqlDbType.Int) { Value = sp.soLuong },
                new SqlParameter("@trangThai", SqlDbType.SmallInt) { Value = sp.trangThai },
                new SqlParameter("@id", SqlDbType.Int) { Value = sp.id },
                new SqlParameter("@ngayHetHan", SqlDbType.Date) { Value = sp.ngayHetHan }
            };
            try
            {
                int rowAffected = data.ExecuteNonQuery(query, parameters);
                return rowAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //kiểm tra sản phẩm cần nhập hay không
        public bool checkTT(int idsp)
        {
            int tt = 0;
            string query = "SELECT COUNT(DISTINCT trangThai) AS SoLuongTrangThai FROM SanPham WHERE id = @id AND trangThai IN (1, 2);";
            SqlParameter[] sqlParameter = new SqlParameter[]
           {
                   new SqlParameter("@id", SqlDbType.Int) { Value =idsp },

           };
            try
            {

                object result = data.ExecuteScalar(query, sqlParameter);


                if (result != null)
                {
                    tt = Convert.ToInt32(result);
                    return tt == 2;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy sản phẩm gần đây thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        // lay so luong san pham hien co
        public int soluongHienTai(int id, DateTime nhh)
        {
            int rs = 0;
            string query = "SELECT soLuong FROM SanPham WHERE id=@id AND ngayHetHan=@nhh";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                   new SqlParameter("@id", SqlDbType.Int) { Value =id },
                    new SqlParameter("@nhh", SqlDbType.DateTime) { Value =nhh }
            };

            try
            {
                object result = data.ExecuteScalar(query, sqlParameter);
                if (result != null)
                {
                    rs = Convert.ToInt32(result);

                }
                return rs;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy sản phẩm gần đây thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }

        public DateTime getNgayHetHan(int sanPhamId)
        {
            DateTime ngay = new DateTime();

            string query = "SELECT ngayHetHan FROM SanPham WHERE id = @sanPhamId AND trangThai=1";
            SqlParameter[] parameters = new SqlParameter[]
          {
                new SqlParameter("@sanPhamId", SqlDbType.Int) { Value = sanPhamId }
          };
            try
            {
                object ngayHetHan = data.ExecuteScalar(query, parameters);
                if (ngayHetHan != null)
                {
                    ngay = Convert.ToDateTime(ngayHetHan);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy ngày sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return ngay;

        }
        public DataTable sanPhamHH()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT sp.id, sp.ten, lsp.ten AS LoaiSanPham, sp.urlAnh, sp.soLuong, sp.ngayHetHan
                     FROM SanPham sp
                     INNER JOIN LoaiSanPham lsp ON sp.LoaiSanPham_id = lsp.id
                     WHERE sp.soLuong<=10 AND sp.trangThai=1
                     ORDER BY sp.soLuong DESC";

            try
            {
                dt = data.ExecuteQuery(query);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách sản phẩm hết hàng: " + ex.Message);
            }
            return dt;
        }
        public bool updateSoLuongSanPham(int id, int soLuong)
        {
            string query = "update SanPham set soLuong = soLuong - @soLuong where id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@soLuong",SqlDbType.Int){Value= soLuong },
                new SqlParameter("@id",SqlDbType.Int){Value=id }
            };

            int rowAffected = data.ExecuteNonQuery(query, parameters);
            return rowAffected > 0;

        }
        public int getTrangThai(int sanPhamId, DateTime nhh)
        {
            int tt = 0;
            string query = "SELECT trangThai FROM SanPham WHERE id = @sanPhamId AND ngayHetHan=@nhh";
            SqlParameter[] parameters = new SqlParameter[]
          {
                new SqlParameter("@sanPhamId", SqlDbType.Int) { Value = sanPhamId },
                 new SqlParameter("@nhh", SqlDbType.DateTime) { Value = nhh }
          };
            try
            {
                //data.OpenConnection();
                tt = data.ExecuteNonQuery(query, parameters);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy ngày sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return tt;
        }
        //lay ten sp theo id
        public string getTenByID(int id)
        {
            string ten = "";
            string query = "SELECT ten FROM SanPham WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]
         {
                new SqlParameter("@id", SqlDbType.Int) { Value = id },

         };
            try
            {
                //data.OpenConnection();
                object sp = data.ExecuteScalar(query, parameters);
                if (sp != null)
                {
                    ten = sp.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy tên sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return ten;



        }

        //lay loai sp theo id sp
        public int getLoaiSPByID(int id)
        {
            int loaispid = 0;
            string query = "SELECT LoaiSanPham_id  FROM SanPham WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]
         {
                new SqlParameter("@id", SqlDbType.Int) { Value = id },

         };
            try
            {
                //data.OpenConnection();
                object sp = data.ExecuteScalar(query, parameters);
                if (sp != null)
                {
                    loaispid = Convert.ToInt32(sp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy loại sản phẩm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return loaispid;
        }




        public List<SanPhamDTO> getListSanPham1()
        {
            var list = new List<SanPhamDTO>();
            string query = "SELECT  [id],[ten],[LoaiSanPham_id],[donGia],[urlAnh],[ngayHetHan],[trangThai],[soLuong] FROM [SanPham] Where trangThai = 1";
            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string ten = reader.GetString(1);
                    int LoaiSanPham_id = reader.GetInt32(2);
                    int donGia = reader.GetInt32(3);
                    long len = reader.GetBytes(4, 0, null, 0, 0);
                    byte[] urlAnh = new byte[System.Convert.ToInt32(len) + 1];
                    reader.GetBytes(4, 0, urlAnh, 0, System.Convert.ToInt32(len));
                    DateTime ngayHetHan = reader.GetDateTime(5);
                    short trangThai = 1;
                    int soLuong = reader.GetInt32(7);
                    list.Add(new SanPhamDTO() { id = id, ten = ten, LoaiSanPham_id = LoaiSanPham_id, donGia = donGia, urlAnh = urlAnh, ngayHetHan = ngayHetHan, trangThai = trangThai, soLuong = soLuong });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không được dữ liệu Sản Phẩm");
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public DataTable getDatatable(string sqlquerry)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlquerry, conn);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return dt;
        }

        
        public bool updateSanPhamBayBan(int id, int donGia)
        {
            string query = "update SanPham set donGia =  @donGia, trangThai = 1 where id = @id AND trangThai = 2";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@donGia",SqlDbType.Int){Value= donGia },
                new SqlParameter("@id",SqlDbType.Int){Value=id }
            };

            int rowAffected = data.ExecuteNonQuery(query, parameters);
            return rowAffected > 0;

        }
        public bool updateSanPhamHa(int id)
        {
            string query = "update SanPham set trangThai = 3 where id = @id AND trangThai = 1";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.Int){Value=id }
            };

            int rowAffected = data.ExecuteNonQuery(query, parameters);
            return rowAffected > 0;

        }
        
        




       
        

    }
}
