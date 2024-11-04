using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DTO;
using static System.ComponentModel.Design.ObjectSelectorEditor;
namespace WindowsFormsApp1.DAO
{
    public class LoaiSanPhamDAO
    {
        
        DataTable dt = new DataTable();
        private DataConnect da = new DataConnect();
        public LoaiSanPhamDAO()
        {
            conn = new SqlConnection(new Login().newConnect);
            da = new DataConnect();
        }
        // Lấy sản phẩm theo loại sản phẩm
        public DataTable getSanPhamByLoaiSanPhamNCC(int id)
        {
            DataTable dt = new DataTable();
            string query = "SELECT sp.id, sp.ten AS TenSanPham, sp.donGia, sp.ngayHetHan, sp.urlAnh, sp.trangThai " +
                           "FROM SanphamNCC sp " +
                           "JOIN LoaiSanPham lsp ON sp.LoaiSanPham_id = lsp.id " +
                           "WHERE sp.LoaiSanPham_id = @loaispid";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@loaispid", SqlDbType.Int) { Value = id }
            };

            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy sản phẩm theo loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }


        public DataTable getAllSP()
        {
            DataTable dt = new DataTable();
            string query = "SELECT sp.id, sp.ten AS TenSanPham, lsp.ten, sp.donGia, sp.ngayHetHan, sp.urlAnh " +
                           "FROM SanphamNCC sp " +
                           "JOIN LoaiSanPham lsp ON sp.LoaiSanPham_id = lsp.id ";


            try
            {
                //da.OpenConnection();
                dt = da.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy sản phẩm theo loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        // Lấy tất cả loại sản phẩm
        public List<LoaiSanPhamDTO> getAllLoaiSanPham()
        {
            //DataTable dt = new DataTable();
            //string query = "SELECT * FROM LoaiSanPham";
            //try
            //{
            //    //da.OpenConnection();
            //    dt = da.ExecuteQuery(query);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi lấy tất cả loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //return dt;
            var list = new List<LoaiSanPhamDTO>();
            
            try
            {
                conn.Open();
                string query = "Select id, ten from LoaiSanPham";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new LoaiSanPhamDTO()
                    {
                        id = reader.GetInt32(0),
                        ten = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

    
        public List<LoaiSanPhamDTO> getLSP()
        {
            var list = new List<LoaiSanPhamDTO>()
            {
                new LoaiSanPhamDTO(){id = 0 , ten = "Tất Cả"}
            };
            try
            {
                conn.Open();
                string query = "Select id, ten from LoaiSanPham";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new LoaiSanPhamDTO()
                    {
                        id = reader.GetInt32(0),
                        ten = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        public DataTable getTableLSP()
        {
            string query = "Select * from LoaiSanPham";
            return da.ExecuteQuery(query);
        }

        // Lấy sản phẩm theo loại sản phẩm


























        SqlConnection conn;
        
        
        


    }
}
