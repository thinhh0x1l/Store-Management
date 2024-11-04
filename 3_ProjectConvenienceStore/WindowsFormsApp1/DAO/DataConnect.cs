using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.DAO
{
    public class DataConnect
    {
        public string connectionString = new Login().newConnect;
        public SqlConnection conn;
        
        public DataConnect()
        {
            
            conn = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }


        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

       
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand(query, conn);
                
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                    
                da.Fill(dataTable);
                    
                }
            
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int result = 0;

            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }

        // Thực hiện một câu lệnh trả về một giá trị đơn
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;

            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    result = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }

        
    }
}

