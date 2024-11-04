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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace WindowsFormsApp1
{
    public partial class frmNhaCungCap : Form
    {
        DataTable table = new DataTable();
        SanPhamNCCBLL sanphamNCCBll = new SanPhamNCCBLL();
        LoaiSanPhamBLL loaiSanPhamBLL = new LoaiSanPhamBLL();
        public frmNhaCungCap()
        {
            InitializeComponent();
            cbbLoaiSanPham.DataSource = loaiSanPhamBLL.getLoaiSanPham();
            if (cbbLoaiSanPham.DataSource != null)
            {
                cbbLoaiSanPham.DisplayMember = "ten";
                cbbLoaiSanPham.ValueMember = "id";
            }
            cbbLSP.DataSource = loaiSanPhamBLL.getAllLoaiSanPham();
            if (cbbLSP.DataSource != null)
            {
                cbbLSP.DisplayMember = "ten";
                cbbLSP.ValueMember = "id";
            }
            //cbbLoaiSanPham.DataSource = loaiSanPhamBLL.getLoaiSanPham();
            //cbbLoaiSanPham.DisplayMember = "ten";
            //cbbLoaiSanPham.ValueMember = "id";
            //cbbLSP.DataSource = loaiSanPhamBLL.getAllLoaiSanPham();
            //cbbLSP.DisplayMember = "ten";
            //cbbLSP.ValueMember = "id";
        }
        private int i = 1;
        private void NewGrid(int i)
        {
            //int i = System.Convert.ToInt32(comboBox1.SelectedItem.ToString());
            gridViewSP.DataBindings.Clear();
            gridViewSP.DataSource = sanphamNCCBll.getDTSPNCC(i);
            reset();

        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            NewGrid(i);
            configgridViewSP();
        }
        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {

        }

        private void cbbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            i = System.Convert.ToInt32(comboBox.SelectedItem.ToString());
            frmNhaCungCap_Load(sender, e);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị của loại sản phẩm đã chọn
                object selectedValue = cbbLoaiSanPham.SelectedValue;
                int selectedCategoryId;

                // Kiểm tra giá trị và chuyển đổi an toàn
                if (selectedValue != null && int.TryParse(selectedValue.ToString(), out selectedCategoryId))
                {
                    // Lấy DataTable từ DataGridView
                    DataTable dtProducts = (DataTable)gridViewSP.DataSource;
                    if (dtProducts != null)
                    {
                        // Tạo DataView và áp dụng bộ lọc
                        DataView dv = dtProducts.DefaultView;
                        if (selectedCategoryId == 0) // Nếu chọn "Tất cả" hoặc không chọn gì
                        {
                            // Hiển thị tất cả các hàng
                            dv.RowFilter = string.Empty;
                        }
                        else
                        {
                            // Áp dụng bộ lọc dựa trên ID loại sản phẩm đã chọn
                            dv.RowFilter = $"LoaiSanPham_id = {selectedCategoryId}";
                        }
                    }
                    //textNone();
                }
                else
                {
                    // Xử lý trường hợp giá trị không hợp lệ hoặc null
                    // Có thể bỏ qua hoặc đưa ra thông báo lỗi
                }
            }
            catch (Exception ex) { }
        }
        public void configgridViewSP()
        {

            gridViewSP.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);


            if (gridViewSP.Columns.Contains("urlAnh"))
            {
                DataGridViewImageColumn imageColumn = gridViewSP.Columns["urlAnh"] as DataGridViewImageColumn;
                if (imageColumn != null)
                {
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    gridViewSP.Columns["urlAnh"].Width = 100;
                }
            }

            gridViewSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void gridViewSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int index = e.RowIndex;
            if (index < 0)
                return;
            //xuLyButton();
            reset();
            readOnly();
            DataGridViewRow row = gridViewSP.Rows[index];
            txtMa.Text = row.Cells[0].Value.ToString();
            txtTen.Text = row.Cells[1].Value.ToString();
            loaiSanPham = Convert.ToInt32(row.Cells[2].Value.ToString());
            foreach (var item in cbbLoaiSanPham.Items)
            {
                // Lấy ra thuộc tính của đối tượng dựa trên ValueMember và DisplayMember
                var valueProperty = item.GetType().GetProperty(cbbLoaiSanPham.ValueMember);
                var displayProperty = item.GetType().GetProperty(cbbLoaiSanPham.DisplayMember);

                // Kiểm tra xem giá trị của ValueMember có khớp không
                if (valueProperty.GetValue(item).ToString() == row.Cells[2].Value.ToString())
                {
                    
                    // Lấy ra giá trị của DisplayMember
                   // cbbLSP.ValueMember = valueProperty.GetValue(item).ToString();
                   cbbLSP.Text = displayProperty.GetValue(item).ToString();
                    
                    // MessageBox.Show(txtLoaiSanPham.Text); // Hiển thị hoặc sử dụng displayText
                    break;
                }
            }
            
            txtDonGia.Text = row.Cells[3].Value.ToString();
            txtNgayHetHan.Text = DateTime.Parse(row.Cells[5].Value.ToString()).ToString("yyyy/MM/dd");

            rd0.Enabled = rd0.Checked = !(rd1.Enabled = rd1.Checked = Convert.ToBoolean(row.Cells[6].Value));
                   
            try
            {
                MemoryStream ms = new MemoryStream(row.Cells[4].Value as byte[]);
                Bitmap bmp = new Bitmap(ms);
                pic.BackgroundImage = bmp;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnChinhSua.Enabled = true;
        }
        private void reset()
        {
            btnThem.FillColor2 = Color.FromArgb(255, 77, 165);
            btnChinhSua.FillColor2 = Color.FromArgb(255, 77, 165);
            urlAnh = "";
            txtMa.Clear();
            txtDonGia.Clear();
            txtNgayHetHan.Clear();
            txtTen.Clear();
            pic.BackgroundImage = null;
            cbbLSP.Text = "";
            loaiSanPham = -1;
            rd1.Checked = rd0.Checked = false;
            rd0.Enabled = rd1.Enabled = true;
            btnXacNhan.Enabled = false;
            btnChinhSua.Enabled = false;
        }
        private void readOnly()
        {
            if (btnThem.FillColor2 == Color.FromArgb(192, 255, 255) || btnChinhSua.FillColor2 == Color.FromArgb(192, 255, 255)) {
                txtDonGia.ReadOnly = false;
                txtNgayHetHan.ReadOnly = false;
                txtTen.ReadOnly = false;
                pic.Enabled = true;
                cbbLSP.Enabled = true;
                btnXacNhan.Enabled = true;
                rd0.Enabled = rd1.Enabled = true;
            }
            else
            {
                txtDonGia.ReadOnly = true;
                txtNgayHetHan.ReadOnly = true;
                txtTen.ReadOnly = true;
                pic.Enabled = false;
                cbbLSP.Enabled = false;
                //rd1.Enabled = rd0.Enabled = false;
                //pnCungCap.Enabled = false; 
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            reset();
            btnThem.FillColor2 = Color.FromArgb(192, 255, 255);
            btnChinhSua.Enabled = false;
            txtMa.Text = sanphamNCCBll.getNextIdSanPhamNCC().ToString();
            readOnly();
            rd1.Checked = true;
            rd0.Enabled = false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (btnThem.FillColor2 == Color.FromArgb(192, 255, 255))
                sanphamNCCBll.themSanPhamNCC(txtTen.Text, loaiSanPham, txtDonGia.Text, urlAnh, txtNgayHetHan.Text);
            else
                sanphamNCCBll.chinhSuaSanPhamNCC(txtMa.Text, txtTen.Text, loaiSanPham, txtDonGia.Text, urlAnh, txtNgayHetHan.Text, rd1.Checked);
            frmNhaCungCap_Load(sender, e);
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            //reset();

            btnChinhSua.FillColor2 = Color.FromArgb(192, 255, 255);
            readOnly();
        }
        private string  urlAnh;
        private void pic_Click(object sender, EventArgs e)
        {
            if (btnThem.FillColor2 == Color.FromArgb(192, 255, 255) || btnChinhSua.FillColor2 == Color.FromArgb(192, 255, 255))
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png;)|*.jpg; *.jpeg; *.gif; *.bmp; *.png;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    urlAnh = open.FileName;
                    pic.BackgroundImage = new Bitmap(open.FileName);
                    pic.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }
        private int loaiSanPham;
        private void cbbLSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                object selectedValue = cbbLSP.SelectedValue;
                int selectedCategoryId;
                if (selectedValue != null && int.TryParse(selectedValue.ToString(), out selectedCategoryId))
                {
                    if (selectedCategoryId != 0)
                    {
                        loaiSanPham = selectedCategoryId;
                    }
                }
            }
            catch (Exception ex) { }
  
        }

        private void cbbLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị của loại sản phẩm đã chọn
                object selectedValue = cbbLoaiSanPham.SelectedValue;
                int selectedCategoryId;

                // Kiểm tra giá trị và chuyển đổi an toàn
                if (selectedValue != null && int.TryParse(selectedValue.ToString(), out selectedCategoryId))
                {
                    // Lấy DataTable từ DataGridView
                    DataTable dtProducts = (DataTable)gridViewSP.DataSource;
                    if (dtProducts != null)
                    {
                        // Tạo DataView và áp dụng bộ lọc
                        DataView dv = dtProducts.DefaultView;
                        if (selectedCategoryId == 0) // Nếu chọn "Tất cả" hoặc không chọn gì
                        {
                            // Hiển thị tất cả các hàng
                            dv.RowFilter = string.Empty;
                        }
                        else
                        {
                            // Áp dụng bộ lọc dựa trên ID loại sản phẩm đã chọn
                            dv.RowFilter = $"LoaiSanPham_id = {selectedCategoryId}";
                        }
                    }
                    reset();
                    readOnly();
                }
                else
                {
                    // Xử lý trường hợp giá trị không hợp lệ hoặc null
                    // Có thể bỏ qua hoặc đưa ra thông báo lỗi
                }
            }
            catch (Exception ex) { }
        }
        private bool checkNumer(string s)
        {
            if (s.Length == 0) return false;
            //if (txtSDT.Text[0] != '0') return false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            return true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.ToLower();

            // Lặp qua tất cả các hàng của DataGridView
            foreach (DataGridViewRow row in gridViewSP.Rows)
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
                    gridViewSP.ClearSelection();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
