using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAO
{
    public class PhanQuyenDAO
    {
        DataConnect data;
        public PhanQuyenDAO()
        {

            data = new DataConnect();
        }
        public DataTable getQuyen()
        {
            string query = "SELECT * FROM Quyen";
            return data.ExecuteQuery(query, new SqlParameter[] { });
        }
        public bool thuHoiQuyen(string maNV, string nameRole) 
        {
            string query = $"ALTER ROLE {nameRole} DROP MEMBER {maNV} ";     
            return data.ExecuteNonQuery(query, new SqlParameter[] { }) > 0;
        }
        public bool thuHoiQuyenServer(string maNV, string nameRole)
        {
            string query = $"USE MASTER " +
                $"ALTER SERVER ROLE {nameRole} DROP MEMBER {maNV} " +
                "USE ConvenienceStore ";
            return data.ExecuteNonQuery(query, new SqlParameter[] { }) > 0;
        }

        public bool capQuyen(string maNV, string nameRole)
        {
            string query = $"ALTER ROLE {nameRole} ADD MEMBER {maNV}";
            return data.ExecuteNonQuery(query, new SqlParameter[] { }) > 0;
        }
        public bool capQuyenServer(string maNV, string nameRole)
        {
            string query = $"USE MASTER " +
                $"ALTER SERVER ROLE {nameRole} ADD MEMBER {maNV} " +
                "USE ConvenienceStore";
            return data.ExecuteNonQuery(query, new SqlParameter[] { }) > 0;
        }
    }
}
