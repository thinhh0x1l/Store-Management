using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace WindowsFormsApp1.DAO
{
    public class NhanVienDAO
    {
        private DataTable dt;
        private DataConnect data = new DataConnect();
        //lay don gia san pham
        private SqlConnection conn = new SqlConnection(new Login().newConnect);
        public NhanVienDAO() { data = new DataConnect(); conn = new SqlConnection(new Login().newConnect); }

        public DataTable getTableNhanVien(int i  )
        {

            string query = $"SELECT  [id],[ho],[ten] ,[ngaySinh],[SDT],[diaChi],[urlAnh],[CCCD],[gioiTinh],[trangThai]  FROM [NhanVien] WHERE [trangThai]= {i} AND  id != 'nv0'";
            return data.ExecuteQuery(query) ;
        }
        public int getNextNV()
        {
            string query = "select count(id) from NhanVien";
            return Convert.ToInt32(data.ExecuteScalar(query, new SqlParameter[] { }));
        }
       
        public bool insertNhanVien(string maNV, string ho, string ten ,DateTime ngaySinh,
                                    string SDT,string diaChi, string urlAnh, string CCCD, bool gioiTinh )
        {
            string query = $"INSERT INTO NhanVien VALUES(@maNV,@ho,@ten,@ngaySinh," +
                "@SDT,@diaChi," +
                $"(SELECT * FROM OPENROWSET(BULK '{urlAnh}', SINGLE_BLOB) AS Anh)" +
                ",@CCCD,@gioiTinh,1,0)";
            DateTime date;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maNV", SqlDbType.VarChar) { Value = maNV },
                new SqlParameter("@ho", SqlDbType.NVarChar) { Value = ho },
                new SqlParameter("@ten", SqlDbType.NVarChar) { Value = ten },
                new SqlParameter("@ngaySinh",SqlDbType.Date) {Value = ngaySinh.ToString("yyyy-MM-dd") },
                new SqlParameter("@SDT", SqlDbType.Char) { Value = SDT },
                new SqlParameter("@diaChi", SqlDbType.NVarChar) { Value = diaChi },
                //new SqlParameter("@urlAnh", urlAnh) ,
                new SqlParameter("@CCCD", SqlDbType.Char) { Value = CCCD },
                new SqlParameter("@gioiTinh", SqlDbType.Bit) { Value = gioiTinh }
            };

            try
            {
                //data.OpenConnection();
                int rowsAffected = data.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm Nhan Vien: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public int createLoginServer(string login, string password)
        {
            string query = "USE MASTER " +
                           $"CREATE LOGIN {login} WITH PASSWORD = '{password}'" +
                           "USE ConvenienceStore " +
                           $"CREATE USER {login} FOR LOGIN {login}";

            return data.ExecuteNonQuery(query, new SqlParameter[] { });
        }
        public bool updateNhanVien(string maNV, string ho, string ten, DateTime ngaySinh,
                                    string SDT, string diaChi, string urlAnh, string CCCD, bool gioiTinh, bool trangThai)
        {
            string query;
            SqlParameter[] parameters;
            if (urlAnh == "") {
                query = $"UPDATE NhanVien SET ho = @ho, ten = @ten, ngaySinh = @ngaySinh," +
                    "SDT = @SDT, diaChi = @diaChi" +
                    ", CCCD = @CCCD, gioiTinh = @gioiTinh, trangThai = @trangThai WHERE id = @maNV";
                parameters = new SqlParameter[]
                {
                new SqlParameter("@maNV", SqlDbType.VarChar) { Value = maNV },
                new SqlParameter("@ho", SqlDbType.NVarChar) { Value = ho },
                new SqlParameter("@ten", SqlDbType.NVarChar) { Value = ten },
                new SqlParameter("@ngaySinh",SqlDbType.Date) {Value = ngaySinh.ToString("yyyy-MM-dd") },
                new SqlParameter("@SDT", SqlDbType.Char) { Value = SDT },
                new SqlParameter("@diaChi", SqlDbType.NVarChar) { Value = diaChi },
                //new SqlParameter("@urlAnh", urlAnh) ,
                new SqlParameter("@CCCD", SqlDbType.Char) { Value = CCCD },
                new SqlParameter("@gioiTinh", SqlDbType.Bit) { Value = gioiTinh },
                new SqlParameter("@trangThai", SqlDbType.Bit) { Value = trangThai}
                };
            }
            else
            {
                query = $"UPDATE NhanVien SET ho = @ho, ten = @ten, ngaySinh = @ngaySinh," +
                "SDT = @SDT, diaChi = @diaChi," +
                $"urlAnh = (SELECT * FROM OPENROWSET(BULK '{urlAnh}', SINGLE_BLOB) AS Anh)" +
                ",CCCD = @CCCD, gioiTinh = @gioiTinh, trangThai = @trangThai WHERE id = @maNV";
                parameters = new SqlParameter[]
                {
                new SqlParameter("@maNV", SqlDbType.VarChar) { Value = maNV },
                new SqlParameter("@ho", SqlDbType.NVarChar) { Value = ho },
                new SqlParameter("@ten", SqlDbType.NVarChar) { Value = ten },
                new SqlParameter("@ngaySinh",SqlDbType.Date) {Value = ngaySinh.ToString("yyyy-MM-dd") },
                new SqlParameter("@SDT", SqlDbType.Char) { Value = SDT },
                new SqlParameter("@diaChi", SqlDbType.NVarChar) { Value = diaChi },
                //new SqlParameter("@urlAnh", urlAnh) ,
                new SqlParameter("@CCCD", SqlDbType.Char) { Value = CCCD },
                new SqlParameter("@gioiTinh", SqlDbType.Bit) { Value = gioiTinh },
                new SqlParameter("@trangThai", SqlDbType.Bit) { Value = trangThai}
                };
            }

            try
            {
                //data.OpenConnection();
                int rowsAffected = data.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi update Nhan Vien: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public int resetPassword(string maNV, string password)
        {
            string query = "USE MASTER " +
                    $"ALTER LOGIN {maNV} WITH PASSWORD = '{password}' " + 
                    "USE ConvenienceStore";
            return data.ExecuteNonQuery(query, new SqlParameter[] { });

        }
        public int enableLogin(string maNV)
        {
            string query = "USE MASTER " +
                $"ALTER LOGIN {maNV} ENABLE " +
                 "USE ConvenienceStore";
            return data.ExecuteNonQuery(query, new SqlParameter[] { });
        }
        public int disableLogin(string maNV)
        {
            string querySession = $"SELECT session_id FROM sys.dm_exec_sessions WHERE login_name = '{maNV}'";
            object v = (data.ExecuteScalar(querySession, new SqlParameter[] { }));
            int sesssionId = Convert.ToInt32(v);
            string s = "";
            if(sesssionId != 0)
            {
                s = $"KILL {sesssionId}";
            }
            string query = "USE MASTER " +
                $"ALTER LOGIN {maNV} DISABLE " +
                 $"{s} " +
                 "USE ConvenienceStore";
            return data.ExecuteNonQuery(query, new SqlParameter[] { });
        }
        public DataTable getNhanVienQuyen()
        {
            string query = "SELECT nv.id, nv.ho as[Last Name], nv.ten as [First Name] " +
                ",q.id as [Mã Quyền], q.ten as [Tên Quyền] FROM Quyen q " +
                "JOIN NhanVien nv ON q.id = nv.Quyen_ID WHERE nv.trangThai = 1 AND nv.id != 'nv0'";
            return data.ExecuteQuery(query, new SqlParameter[] { });
        }
        public int updateQuyenNhanVien(string maNV, string maQuyen)
        {
            string query = $"UPDATE NhanVien SET Quyen_ID = {maQuyen} WHERE id = '{maNV}'";
            return data.ExecuteNonQuery(query, new SqlParameter[] { });
        }
        public void doiMatKhau(string nameLogin, string newPassword, string oldPassword)
        {
            string query = $"ALTER LOGIN {nameLogin} WITH PASSWORD = '{newPassword}' OLD_PASSWORD = '{oldPassword}'";
            data.ExecuteNonQuery(query, new SqlParameter[] { });
        }
    }
}
