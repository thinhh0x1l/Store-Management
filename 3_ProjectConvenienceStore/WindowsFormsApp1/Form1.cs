using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(

     int nLeftRect,
     int nTopRect,
     int nRightRect,
     int nButtomRect,
     int nWidthEllipse,
     int nHeightEllipse

 );
        private void resetColorButton()
        {
            btn_main.FillColor = Color.Transparent;
            btn_banhang.FillColor = Color.Transparent;
            btn_sanpham.FillColor = Color.Transparent;
            btn_nhaphang.FillColor = Color.Transparent;
            btnNNC.FillColor = Color.Transparent;
            btn_phanQuyen.FillColor = Color.Transparent;
            btn_hoadon.FillColor = Color.Transparent;
            btn_thongke.FillColor = Color.Transparent;
            btn_khachhang.FillColor = Color.Transparent;
            btn_nhanvien_sidebar.FillColor = Color.Transparent;
        }
        DataConnect data;
        public Form1()
        {

            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.StartPosition = FormStartPosition.CenterScreen;
            data = new DataConnect();
            OpenChildForm(new FrmHome());

        }
        public Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnl_main.Controls.Add(childForm);
            pnl_main.Tag = childForm;

            childForm.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
 

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            resetColorButton();
            btn_nhanvien_sidebar.FillColor = Color.Black;
            OpenChildForm(new frmNhanVien());
        }
        bool sideBarExpand = true; // Biến để kiểm soát trạng thái mở rộng hoặc thu gọn của sidebar

    

        private void btn_danhmuc_add_Click(object sender, EventArgs e)
        {
           // OpenChildForm(new FrmThemDanhMuc());
        }

       

      
        private void btn_main_Click(object sender, EventArgs e)
        {
            resetColorButton();
            btn_main.FillColor = Color.Black;
            OpenChildForm(new FrmHome());
        }

        private void pnl_sanpham_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_sanpham_add_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new FrmThemSanPham());
        }

    

      

        private void btn_sanpham_list_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLySanPham());
        }
        
        private void btn_nv_list_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new FrmDanhSachNhanVien());
        }

        private void btn_nv_add_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new FrmThemNhanVien());
        }

     

        private void pnl_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {

        }

        private void btn_banhang_Click(object sender, EventArgs e)
        {
            resetColorButton();
            btn_banhang.FillColor = Color.Black;
            OpenChildForm(new frmBanHang());
        }

        private void btn_sanpham_Click(object sender, EventArgs e)
        {
            resetColorButton();
            btn_sanpham.FillColor = Color.Black;
            OpenChildForm(new frmQuanLySanPham());
        }

        private void btn_thoat_Click_1(object sender, EventArgs e)
        {
            //string querySession = $"SELECT session_id FROM sys.dm_exec_sessions " +
            //    $"WHERE login_name = '{Login.tenNV}' AND " +
            //    $"program_name != 'SQL Server Management Studio' ";
            //object v = (data.ExecuteScalar(querySession, new SqlParameter[] { }));
            //int sesssionId = Convert.ToInt32(v);
            //string query = "USE MASTER " +
            //     $"KILL {sesssionId}"; 
            //     //"USE ConvenienceStore";
            //data.ExecuteNonQuery(query, new SqlParameter[] { });
            this.Close();
        }

        private void btn_nhaphang_Click(object sender, EventArgs e)
        {
            resetColorButton();
            btn_nhaphang.FillColor = Color.Black;
            OpenChildForm(new FrmNhapHang());
        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            resetColorButton();
            btn_thongke.FillColor = Color.Black;
            OpenChildForm(new FrmThongKe());
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            resetColorButton();
            btn_hoadon.FillColor = Color.Black;
            OpenChildForm(new FrmHoaDon());
        }

        private void btn_khachhang_Click(object sender, EventArgs e)
        {
            resetColorButton();
            btn_khachhang.FillColor = Color.Black;
            OpenChildForm(new FrmKhachHang());
        }

        private void btnNNC_Click(object sender, EventArgs e)
        {
            resetColorButton();
            btnNNC.FillColor = Color.Black;
            OpenChildForm(new frmNhaCungCap());
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            resetColorButton();
            btn_phanQuyen.FillColor = Color.Black;
            OpenChildForm(new PhanQuyen());
        }
    }
}