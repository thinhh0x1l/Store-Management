using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;

namespace WindowsFormsApp1
{
    public partial class frmNhanVien : Form
    {
        private NhanVienBLL nhanVienBLL;
        public frmNhanVien()
        {
            InitializeComponent();

        }
        private int i = 1;
        private void NewGrid(int i)
        {
           
            nhanVienBLL = new NhanVienBLL();
            gridViewNV.DataBindings.Clear();
            gridViewNV.DataSource = nhanVienBLL.getTableTrangThai(i);

        }
       
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            NewGrid(i);
            reset();
            configgridViewNV();
        }

        private void cbbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            i = System.Convert.ToInt32(comboBox.SelectedItem.ToString());
            frmNhanVien_Load(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.ToLower();

            // Lặp qua tất cả các hàng của DataGridView
            foreach (DataGridViewRow row in gridViewNV.Rows)
            {
                // Bỏ qua hàng tiêu đề (nếu có)
                if (row.IsNewRow) continue;

                try
                {
                    // Kiểm tra nếu giá trị trong cột "Name" hoặc "ID" có chứa từ khóa tìm kiếm
                    bool nameContains = row.Cells["ten"].Value != null && row.Cells["ten"].Value.ToString().ToLower().Contains(searchValue);
                    bool idContains = row.Cells["id"].Value != null && row.Cells["id"].Value.ToString().ToLower().Contains(searchValue);

                    // Hiển thị hoặc ẩn hàng tùy thuộc vào kết quả tìm kiếm
                    row.Visible = nameContains || idContains;
                    gridViewNV.ClearSelection();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void gridViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
                return;
            //xuLyButton();
            reset();
            DataGridViewRow row = gridViewNV.Rows[index];
            txtMaNV.Text = row.Cells[0].Value.ToString();
            txtLastNaame.Text = row.Cells[1].Value.ToString();
            txtFirstName.Text = row.Cells[2].Value.ToString();
            dtpNamSinh.Value = DateTime.Parse(row.Cells[3].Value.ToString());
            txtSDT.Text = row.Cells[4].Value.ToString();
            txtDiaChi.Text = row.Cells[5].Value.ToString();
            txtCCCD.Text = row.Cells[7].Value.ToString();

            rdNu.Enabled = rdNu.Checked = !(rdNam.Enabled = rdNam.Checked = Convert.ToBoolean(row.Cells[8].Value));
            rd0.Enabled = rd0.Checked  = !(rd1.Enabled = rd1.Checked = Convert.ToBoolean(row.Cells[9].Value));
   
            try
            {
                MemoryStream ms = new MemoryStream(row.Cells[6].Value as byte[]);
                Bitmap bmp = new Bitmap(ms);
                picUrlAnh.BackgroundImage = bmp;
                picUrlAnh.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnChinhSua.Enabled = true;
            btnXacNhan.Enabled = false;
            //if(i == 0)
                //btnXoa.Enabled = true;
            //btnCapNhapGia.FillColor = Color.DarkGray;
            //txtDonGia.ReadOnly = true;
        }
        private void reset()
        {
            txtMaNV.Clear();
            txtCCCD.Clear();
            txtDiaChi.Clear();
            txtFirstName.Clear();
            txtLastNaame.Clear();

            txtSDT.Clear();
            urlAnh = "";
            picUrlAnh.BackgroundImage = null;
            rd0.Checked = false;
            rd1.Checked = false;
            rdNam.Checked = false;
            rdNu.Checked = false;
            rdNam.Enabled = true;
            rdNu.Enabled = true;
            rd1.Enabled = true;
            rd0.Enabled = true;
            btnXacNhan.Enabled = false;
            txtMK1.Clear();
           
            gbMK.Enabled = false;
            btnThem.FillColor2 = Color.FromArgb(255, 77, 165);
            btnChinhSua.Enabled = false;
            btnChinhSua.FillColor2 = Color.FromArgb(255, 77, 165);
            txtRead();
        }
        private void txtRead()
        {
            if(btnThem.FillColor2 != Color.FromArgb(192, 255, 255) && btnChinhSua.FillColor2 != Color.FromArgb(192, 255, 255))
            {
                
                txtCCCD.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtFirstName.ReadOnly = true;
                txtLastNaame.ReadOnly = true;  
                txtSDT.ReadOnly = true;
               
            }
            else
            {
               
                txtCCCD.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtFirstName.ReadOnly = false;
                txtLastNaame.ReadOnly = false;
                txtSDT.ReadOnly = false;
               
            }
        }
        public void configgridViewNV()
        {

            gridViewNV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);


            if (gridViewNV.Columns.Contains("urlAnh"))
            {
                DataGridViewImageColumn imageColumn = gridViewNV.Columns["urlAnh"] as DataGridViewImageColumn;
                if (imageColumn != null)
                {
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    gridViewNV.Columns["urlAnh"].Width = 100;
                }
            }

            gridViewNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
        // 94, 148, 255 255, 192, 255
        private void btnThem_Click(object sender, EventArgs e)
        {
                reset();
            btnThem.FillColor2 = Color.FromArgb(192, 255, 255);
            txtRead();
            txtMaNV.Text = "nv" + nhanVienBLL.getNextIdNV();
            rdNam.Checked = true;
            rd1.Checked = true;
            rd0.Enabled = false;
            //btnXacNhan.Enabled = true;
            gbMK.Enabled = true;
        }
        //private bool btnThemClicked = false;
        private string urlAnh;
        private void picUrlAnh_Click(object sender, EventArgs e)
        {
            if (btnThem.FillColor2 == Color.FromArgb(192, 255, 255) || btnChinhSua.FillColor2 == Color.FromArgb(192, 255, 255))
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png;)|*.jpg; *.jpeg; *.gif; *.bmp; *.png;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    urlAnh = open.FileName;
                    picUrlAnh.BackgroundImage = new Bitmap(open.FileName);
                    picUrlAnh.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }
        // 255, 77, 165 192, 255, 255
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(btnThem.FillColor2 == Color.FromArgb(192, 255, 255))
            {
                nhanVienBLL.themNhanVien(txtMaNV.Text, txtLastNaame.Text, 
                        txtFirstName.Text, dtpNamSinh.Value,
                        txtSDT.Text, txtDiaChi.Text, urlAnh,txtCCCD.Text , rdNam.Checked);
                nhanVienBLL.createLogin(txtMaNV.Text, txtMK1.Text);
            }
            else
            {
                if (txtMaNV.Text == Login.tenNV && rd0.Checked)
                {
                    MessageBox.Show("Bạn không đủ quyền hạn");
                    return;
                }
                //maNV, ho, ten, ngaySinh, SDT, diaChi, urlAnh, CCCD, gioiTinh, trangThai
                nhanVienBLL.updateNhanVien(txtMaNV.Text, txtLastNaame.Text, 
                        txtFirstName.Text, dtpNamSinh.Value, 
                        txtSDT.Text,txtDiaChi.Text,urlAnh,txtCCCD.Text,rdNam.Checked,rd1.Checked);
                nhanVienBLL.convertStatus(txtMaNV.Text, rd1.Checked);
                if(txtMK1.Text != "")
                {
                    nhanVienBLL.resetPassword(txtMaNV.Text, txtMK1.Text);
                }
            }
            frmNhanVien_Load(sender, e);

        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            btnChinhSua.FillColor2 = Color.FromArgb(192, 255, 255);
            txtRead();
            rd0.Enabled = true;
            rd1.Enabled = true;
            rdNam.Enabled = true;
            rdNu.Enabled = true;
            //btnXacNhan.Enabled = true;
            gbMK.Enabled = true;  
        }
        private void checkXacNhan()
        {
            if(!(txtFirstName.Text == "" || txtLastNaame.Text == "" || txtSDT.FillColor != Color.FromArgb(160, 255, 255) ||
                txtSDT.FillColor != Color.FromArgb(160, 255, 255) || txtDiaChi.Text == "" || picUrlAnh.BackgroundImage == null )
                && (btnThem.FillColor2 == Color.FromArgb(192, 255, 255) || btnChinhSua.FillColor2 == Color.FromArgb(192, 255, 255)))
            {
                btnXacNhan.Enabled=true;
            }
            else
            {
                btnXacNhan.Enabled=false;
            }
                
        }

        private void guna2GradientPanel1_Enter(object sender, EventArgs e)
        {
            
        }

        private void guna2GradientPanel1_MouseEnter(object sender, EventArgs e)
        {
            checkXacNhan();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (checkNumer(txtSDT.Text) && txtSDT.Text.Length == 10)
            {
                txtSDT.FillColor = Color.FromArgb(160, 255, 255);
            }
            else
            {
                txtSDT.FillColor = Color.White;
            }
        }
        private bool checkNumer(string s)
        {
            if (s.Length == 0) return false;
            if (txtSDT.Text[0] != '0') return false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            return true;
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            if (checkNumer(txtCCCD.Text) && txtCCCD.Text.Length == 12)
            {
                txtCCCD.FillColor = Color.FromArgb(160, 255, 255);
            }
            else
            {
                txtCCCD.FillColor = Color.White;
            }
        }

        private void dtpNamSinh_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void gridViewNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
