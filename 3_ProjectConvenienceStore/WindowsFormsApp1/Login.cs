using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }
        public static string tenNV;
        public static string matKhau;
        public string newConnect= Connect;
        public static string Connect;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            newConnect = Connect = @"Data Source= MSI; Initial Catalog=ConvenienceStore;User ID=" + txtUsername.Text + "; Password=" + txtPassword.Text;
            tenNV = txtUsername.Text;
            matKhau = txtPassword.Text.Trim();
            //MessageBox.Show(newConnect);
            conn = new SqlConnection(newConnect);
            try
            {
                this.OpenConnection(conn);
                this.CloseConnection(conn);
                //conn.Close();
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                this.Show();
                Login_Load(sender,e);
                txtUsername.Text = "";
                txtUsername.Focus();
                txtPassword.Text = "";

            }
            catch (Exception ex)
            {
                if (txtUsername.Text.Equals("") && txtPassword.Text.Equals(""))
                {
                    guna2HtmlLabel2.Text = "*Username không được để trống";
                    guna2HtmlLabel3.Text = "*Password không được để trống";
                }
                else if (txtUsername.Text.Equals(""))
                    guna2HtmlLabel2.Text = "*Username không được để trống";
                else if (txtPassword.Text.Equals(""))
                    guna2HtmlLabel3.Text = "*Password không được để trống";
                else
                {
                    MessageBox.Show("Tài khoản không chính xác");
                    txtUsername.Text = "";
                    txtUsername.Focus();
                    txtPassword.Text = "";
                }
            }
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername != null || !txtUsername.Equals(""))
            {
                guna2HtmlLabel2.Text = "";
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername != null || !txtUsername.Equals(""))
            {
                guna2HtmlLabel3.Text = "";
            }
        }

        private void guna2TextBox2_IconLeftClick(object sender, EventArgs e)
        {
         
            
            if (txtPassword.UseSystemPasswordChar == false)
            {
               
                txtPassword.UseSystemPasswordChar = true;
          
            }
            else
            {
                
                txtPassword.UseSystemPasswordChar = false;
               
            }
            
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
            newConnect = Connect = "";
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        public void OpenConnection(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }


        public void CloseConnection(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
