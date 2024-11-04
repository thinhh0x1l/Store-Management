using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;

namespace WindowsFormsApp1
{
    public partial class frmQuanLySanPham : Form
    {
        DataTable table = new DataTable();
        SanPhamBLL sanphamBll = new SanPhamBLL();
        LoaiSanPhamBLL loaiSanPhamBLL = new LoaiSanPhamBLL();   
        public frmQuanLySanPham()
        {
            InitializeComponent();
            cbbLoaiSanPham.DataSource = loaiSanPhamBLL.getLoaiSanPham();
            if (cbbLoaiSanPham.DataSource != null)
            {
                cbbLoaiSanPham.DisplayMember = "ten";
                cbbLoaiSanPham.ValueMember = "id";
            }
        }
        private int i = 1;
        private void NewGrid(int i)
        {
            //int i = System.Convert.ToInt32(comboBox1.SelectedItem.ToString());
            gridViewSP.DataBindings.Clear();
            gridViewSP.DataSource = sanphamBll.getDTSP(i);
           
        }
        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            NewGrid(i);
            reset();
            xuLyButton();
            configgridViewSP();
        }
        private void reset()
        {
            cbbLoaiSanPham.SelectedValue = 0;
            readOnlyTrue();
            textNone();
            //pic.BackgroundImage = 
        }
        private void textNone()
        {
            txtSearch.Text = "";
            txtMa.Text = "";
            txtLoaiSanPham.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtNgayHetHan.Text = "";
            lbTen.Text = "";
            pic.BackgroundImage = null;
        }
        private void readOnlyTrue()
        {
            txtDonGia.ReadOnly = true;
            txtSoLuong.ReadOnly = true;
            txtLoaiSanPham.ReadOnly = true;
            txtNgayHetHan.ReadOnly = true;
            txtMa.ReadOnly = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            i = System.Convert.ToInt32(comboBox.SelectedItem.ToString()); 
            frmQuanLySanPham_Load(sender,e); 
        }

        public void xuLyButton()
        {
            
            btnBayBan.Enabled = btnHa.Enabled = btnXacNhan.Enabled = false;
            btnBayBan.FillColor = Color.DarkGray;
            txtDonGia.FillColor = Color.White;
            if (i == 2)
            {
                btnBayBan.Enabled = true;
            }else if (i == 1)
            {
                btnHa.Enabled = true;
            }
            
        }

        private void gridViewSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
                return;
            xuLyButton();
            DataGridViewRow row = gridViewSP.Rows[index];
            txtMa.Text = row.Cells[0].Value.ToString();
            lbTen.Text = row.Cells[1].Value.ToString();
            foreach (var item in cbbLoaiSanPham.Items)
            {
                // Lấy ra thuộc tính của đối tượng dựa trên ValueMember và DisplayMember
                var valueProperty = item.GetType().GetProperty(cbbLoaiSanPham.ValueMember);
                var displayProperty = item.GetType().GetProperty(cbbLoaiSanPham.DisplayMember);

                // Kiểm tra xem giá trị của ValueMember có khớp không
                if (valueProperty.GetValue(item).ToString() == row.Cells[2].Value.ToString())
                {
                    // Lấy ra giá trị của DisplayMember
                    txtLoaiSanPham.Text = displayProperty.GetValue(item).ToString();
                   // MessageBox.Show(txtLoaiSanPham.Text); // Hiển thị hoặc sử dụng displayText
                    break;
                }
            }
            //txtLoaiSanPham.Text = row.Cells[2].Value.ToString();
            txtDonGia.Text = row.Cells[3].Value.ToString();
            txtSoLuong.Text = row.Cells[7].Value.ToString();
            txtNgayHetHan.Text = DateTime.Parse(row.Cells[5].Value.ToString()).ToString("yyyy/MM/dd");
            donGia = Convert.ToInt32(txtDonGia.Text);
            try
            {
                MemoryStream ms = new MemoryStream(row.Cells[4].Value as byte[]);
                Bitmap bmp = new Bitmap(ms);
                pic.BackgroundImage = bmp;  
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            //btnBayBan.FillColor = Color.DarkGray;
            


        }

        private void gridViewSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridViewSP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra chỉ số hàng có hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị của ô trong cột "Status"
                var soluong = gridViewSP.Rows[e.RowIndex].Cells["soLuong"];
                var check = gridViewSP.Rows[e.RowIndex].Cells["ngayHetHan"];
                short status = Convert.ToInt16(gridViewSP.Rows[e.RowIndex].Cells["trangThai"].Value.ToString());
                if (soluong.Value != null && check !=null && status == 1)
                {
                    int statusValue = Convert.ToInt32(soluong.Value.ToString());
                    DateTime checkNHH = Convert.ToDateTime(check.Value.ToString());
                    // Kiểm tra điều kiện và thay đổi màu nền của ô
                    if(checkNHH <= DateTime.Now)
                    {
                        e.CellStyle.BackColor = Color.OrangeRed;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else if (statusValue == 0)
                    {
                        e.CellStyle.BackColor = Color.LightYellow;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        //e.CellStyle.BackColor = Color.White;  // Màu nền mặc định
                        //e.CellStyle.ForeColor = Color.Black;  // Màu chữ mặc định
                    }
                }
            }

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
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Lấy từ khóa tìm kiếm từ TextBox
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
                catch (Exception ex) {
                    
                }
            }
        }

        private void btnCapNhapGia_Click(object sender, EventArgs e)
        {
            
            txtDonGia.ReadOnly = false;
            btnBayBan.FillColor = Color.Black;
            txtDonGia.FillColor = Color.LemonChiffon;
            btnXacNhan.Enabled = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int donGiaChanged = Convert.ToInt32(txtDonGia.Text);
            if(donGiaChanged <= donGia)
            {
                MessageBox.Show("Cửa Hàng Sễ Sớm Phá Sản");
                txtDonGia.Text = donGia.ToString();
                return;
            }else if (donGiaChanged % 1000 != 0)
            {
                MessageBox.Show("Số tiền phải chia hết cho 1000");
                txtDonGia.Text = donGia.ToString();
                return;
            }
            DataTable table = sanphamBll.getDTSP(1);
            // Giá trị mà bạn muốn tìm kiếm
            string valueToFind = txtMa.Text;

            // Tên của cột mà bạn muốn tìm kiếm giá trị
            string columnName = "id";

            // Sử dụng phương thức Select để tìm các hàng thỏa mãn điều kiện
            DataRow[] foundRows = table.Select($"{columnName} = {valueToFind}");

            // Kiểm tra và xử lý các hàng tìm được
            if (foundRows.Length == 0)
            {
                
                    sanphamBll.updateSanPhamBayBan(txtMa.Text, txtDonGia.Text);
                    ///MessageBox.Show($"Bày Bán Thành Công: {row[columnName]}");
                
            }
            else
            {
                MessageBox.Show("Sản Phẩm này hiện vẫn còn bày bán");
            }
            btnXacNhan.Enabled = false;
            txtDonGia.ReadOnly = true;
            btnBayBan.FillColor = Color.DarkGray;
            txtDonGia.FillColor = Color.White;
            frmQuanLySanPham_Load(sender, e);
        }
        private bool checkNumber(string s)
        {
            if (s.Length == 0)
                return false;
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] < '0' || s[i] > '9')
                    return false;
            }
            return true;
        }
        int donGia;
        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (checkNumber(txtDonGia.Text) && btnBayBan.Enabled == true && txtDonGia.ReadOnly == false && Convert.ToInt32(txtDonGia.Text) != donGia && btnBayBan.FillColor == Color.Black)
            {
                btnXacNhan.Enabled = true;
            }
            else
            {
                btnXacNhan.Enabled = false;
            }
        }


        private void cbbLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void gridViewSP_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHa_Click(object sender, EventArgs e)
        {
            
            if (!(sanphamBll.updateSanPhamBayBanHa(txtMa.Text, txtSoLuong.Text, txtNgayHetHan.Text)))
                return;
            frmQuanLySanPham_Load(sender, e);
        }

        private void cbbLoaiSanPham_SelectedIndexChanged_1(object sender, EventArgs e)
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
                    textNone();
                }
                else
                {
                    // Xử lý trường hợp giá trị không hợp lệ hoặc null
                    // Có thể bỏ qua hoặc đưa ra thông báo lỗi
                }
            }
            catch (Exception ex) { }
        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
