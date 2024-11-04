using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class KhachHangDAO
    {
        private DataConnect da = new DataConnect();
        public KhachHangDAO()
        {
            da = new DataConnect();

        }
        // Lấy danh sách khách hàng
        public DataTable getAllKhachHang()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM KhachHang";
            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu khách hàng nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        // Thêm khách hàng
        public bool insertKhachHang(KhachHangDTO kh)
        {
            string query = "INSERT INTO KhachHang(ho, ten, SDT) VALUES(@ho, @ten, @SDT)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ho", SqlDbType.NVarChar) { Value = kh.ho },
                new SqlParameter("@ten", SqlDbType.NVarChar) { Value = kh.ten },
                new SqlParameter("@SDT", SqlDbType.Char) { Value = kh.SDT }
            };

            try
            {
                //da.OpenConnection();
                int rowsAffected = da.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Cập nhật thông tin số điện thoại
        public bool updateKhachHang(int id, string ho , string ten, string sdt)
        {
            string query = $"UPDATE KhachHang SET SDT=@sdt, ho = N'{ho}', ten = N'{ten}' WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SDT", SqlDbType.VarChar) { Value = sdt },
                new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };

            try
            {
                //da.OpenConnection();
                int rowsAffected = da.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //khach hang chua co hoa đon 

        public bool kiemTraKH(int kh)
        {
            string query = @"SELECT COUNT(*) 
                     FROM KhachHang kh
                     INNER JOIN HoaDonBan hdb 
                     ON hdb.KhachHang_id = kh.id
                     WHERE kh.id = @id;";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.Int) { Value = kh }
            };

            try
            {
                //da.OpenConnection();
                object result = da.ExecuteScalar(query, parameters);

                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable xepHangDiem()
        {
            DataTable dt = new DataTable();
            string query = "SELECT TOP 10 * FROM KhachHang ORDER BY tichDiem DESC";
            try
            {
               // da.OpenConnection();
                dt = da.ExecuteQuery(query);
                if (dt == null)
                {
                    MessageBox.Show("Lỗi khi lấy xếp hạng khách hàng: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               // else
                    //MessageBox.Show(dt.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy xếp hạng khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // Xóa khách hàng
        public bool deleteKhachHang(int id)
        {
            string query = "DELETE FROM KhachHang WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };

            try
            {
                //da.OpenConnection();
                int rowsAffected = da.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public string getName(string sdt, string typeOfName)
        {
            string query = $"Select {typeOfName} from KhachHang Where SDT = {sdt}";
            if (da.ExecuteScalar(query, new SqlParameter[] { }) == null)
            {
                if (typeOfName == "id")
                    return "0";
                return "";
            }
            return da.ExecuteScalar(query, new SqlParameter[] { }).ToString();
        }
        public bool insertKhachHangInBanHan(string ho, string ten, string SDT)
        {
            string query = "INSERT INTO KhachHang(ho, ten, SDT) VALUES(@ho, @ten, @SDT)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ho", SqlDbType.NVarChar) { Value = ho },
                new SqlParameter("@ten", SqlDbType.NVarChar) { Value = ten },
                new SqlParameter("@SDT", SqlDbType.Char) { Value = SDT }
            };

            try
            {
                //da.OpenConnection();
                int rowsAffected = da.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool updateDiemKhachHang(int id, int tichDiem)
        {
            string query = "UPDATE KhachHang SET tichDiem=@tichDiem WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tichDiem", SqlDbType.Int) { Value = tichDiem },
                new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };

            try
            {
                //da.OpenConnection();
                int rowsAffected = da.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
       

        // Lấy danh sách khách hàng
        
    }
}
