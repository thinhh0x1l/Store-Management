using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DTO;
namespace WindowsFormsApp1
{
    public partial class FrmKhachHang : Form
    {
        public KhachHangBLL khbll;
      


        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            khbll = new KhachHangBLL();
            btn_them_kh.Enabled = false;
            loadKH();
        }
        public void loadKH()
        {
            DataTable dt = new DataTable();
            dt = khbll.getAllKhachHang();
            dtgKH.DataSource = dt;
            dtgKH.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
        }


        

        private void btn_them_kh_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text;
            string ho = txtHo.Text;
            string sdt=txtSDT.Text;
            KhachHangDTO kh = new KhachHangDTO(ten,ho,sdt);
            if (khbll.insertKhachHang(kh))
            {
                MessageBox.Show("Thêm khách hàng thành công!","Thông báo",MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
            dtgKH.DataBindings.Clear();
            loadKH();


        }
        public void clearTextBox()
        {
            txtHo.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            txtMaKH.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtDiem.DataBindings.Clear();
            dtgKH.DataBindings.Clear();
            btnDeleteKH.Enabled = btn_sua_kh.Enabled = txtMaKH.Enabled = true;
            btn_them_kh.Enabled = false;
            btnThem.FillColor = Color.CornflowerBlue;
            txtHo.Text = "";
            txtTen.Text = "";
            txtMaKH.Text = "";
            txtSDT.Text = "";
            txtDiem.Text = "";

        }
        private void btn_sua_kh_Click(object sender, EventArgs e)
        {
            if (dtgKH.CurrentRow != null)
            {

                int id = Convert.ToInt32(txtMaKH.Text);
                string sdt=txtSDT.Text;
                bool result = khbll.updateKhachHang(id ,txtHo.Text, txtTen.Text, sdt);

                if (result)
                {
                    clearTextBox();
                    loadKH();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK);
                }
            }

        }
        private void btnDeleteKH_Click(object sender, EventArgs e)
        {
            if (dtgKH.CurrentRow!=null)
            {
                DataGridViewRow currentRow = dtgKH.CurrentRow;
                int id = Convert.ToInt32(currentRow.Cells[0].Value.ToString());
                if (!khbll.kiemTraKH(id)) {
                   bool result = khbll.deleteKhachHang(id);
                    if (result)
                    {
                        clearTextBox();
                        loadKH();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xóa khách hàng đã có hóa đơn!", "Thông báo", MessageBoxButtons.OK);
                }
            }
              
              
            }

        

        private void dtgKH_Click(object sender, EventArgs e)
        {
            clearTextBox() ;
            
            if (dtgKH.CurrentRow != null)
            {
                DataGridViewRow currentRow = dtgKH.CurrentRow;
                int id = Convert.ToInt32(currentRow.Cells[0].Value.ToString());
                string ho = currentRow.Cells[1].Value.ToString();
                string ten = currentRow.Cells[2].Value.ToString();
                string sdt = currentRow.Cells[3].Value.ToString();
                float diem = float.Parse(currentRow.Cells[4].Value.ToString());

                txtHo.Text = ho;
                txtTen.Text = ten;
                txtMaKH.Text = id+"";
                txtSDT.Text = sdt;
                txtDiem.Text = diem + "";

            }
        }

        private void dtgKH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgKH.Rows[e.RowIndex].IsNewRow) return;

            int id = Convert.ToInt32(dtgKH.Rows[e.RowIndex].Cells["id"].Value);
            if (!khbll.kiemTraKH(id))
            {
                dtgKH.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
            }
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            clearTextBox();
            btnThem.FillColor = Color.MidnightBlue;
            txtDiem.Text = "0";
            btnDeleteKH.Enabled = btn_sua_kh.Enabled = txtMaKH.Enabled = false;
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (checkNumber(txtSDT.Text) && txtSDT.Text.Length == 10 && btnThem.FillColor == Color.MidnightBlue) {
                txtSDT.FillColor = Color.Cyan;
                btn_them_kh.Enabled = true;
            }
            else
            {
                txtSDT.FillColor = Color.White;
                btn_them_kh.Enabled = false;
            }
            if (checkNumber(txtSDT.Text) && txtSDT.Text.Length == 10 && btnThem.FillColor != Color.MidnightBlue)
            {
                btn_sua_kh.Enabled = true;
                txtSDT.FillColor = Color.Cyan;
            }
            else
            {
                btn_sua_kh.Enabled = false;
                txtSDT.FillColor = Color.White;
            }
        }
        private bool checkNumber(string s)
        {
            if (s.Length == 0) return false;
            if (s[0] != '0') return false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            return true;
        }
    }
}
