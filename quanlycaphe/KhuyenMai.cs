using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlycaphe
{
    public partial class KhuyenMai : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=quanlycafe;Integrated Security=True");
        public KhuyenMai()
        {
            InitializeComponent();
            loadKhuyenMai();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }
        public bool checkTrungMaKhuyenMai(String maKM)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from KhuyenMai where MaKhuyenMai = '" + maKM + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar();
            if (kq > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();
        }
        public void loadKhuyenMai()
        {
            // Load khuyen mai
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "select * from KhuyenMai";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            dgvKhuyenMai.DataSource = tb;
            dgvKhuyenMai.Refresh();

        }
        public void clear()
        {
            txtMaKM.Text = "";
            txtTenKM.Text = "";
            txtMoTa.Text = "";
            dtNgayBatDau.Value = DateTime.Now;
            dtNgayKetThuc.Value = DateTime.Now;
            txtPhanTramGiam.Text = "";
        }
        public void enableTextBox()
        {
            txtMaKM.Enabled = true;
            txtTenKM.Enabled = true;
            txtMoTa.Enabled = true;
            dtNgayBatDau.Enabled = true;
            dtNgayKetThuc.Enabled = true;
            txtPhanTramGiam.Enabled = true;
        }
        public void disableTextBox()
        {
            txtMaKM.Enabled = false;
            txtTenKM.Enabled = false;
            txtMoTa.Enabled = false;
            dtNgayBatDau.Enabled = false;
            dtNgayKetThuc.Enabled = false;
            txtPhanTramGiam.Enabled = false;
        }
        private void KhuyenMai_Load(object sender, EventArgs e)
        {

        }

        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)e.RowIndex;
            if (i >= 0)
            {
                txtMaKM.Text = dgvKhuyenMai.Rows[i].Cells[0].Value.ToString();
                txtTenKM.Text = dgvKhuyenMai.Rows[i].Cells[1].Value.ToString();
                txtMoTa.Text = dgvKhuyenMai.Rows[i].Cells[2].Value.ToString();
                dtNgayBatDau.Value = Convert.ToDateTime(dgvKhuyenMai.Rows[i].Cells[3].Value.ToString());
                dtNgayKetThuc.Value = Convert.ToDateTime(dgvKhuyenMai.Rows[i].Cells[4].Value.ToString());
                txtPhanTramGiam.Text = dgvKhuyenMai.Rows[i].Cells[5].Value.ToString();
            }
        }

        private void buttonThemMoi_Click(object sender, EventArgs e)
        {
            buttonLuu.Enabled = true;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = true;
            enableTextBox();
            clear();
        }

        private void buttonHuyThaoTac_Click(object sender, EventArgs e)
        {
            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            String maKM = txtMaKM.Text;
            if (maKM == "")
            {
                MessageBox.Show("Vui lòng nhập mã khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(checkTrungMaKhuyenMai(maKM))
            {
                MessageBox.Show("Mã khuyến mãi đã tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            String tenKM = txtTenKM.Text;
            if (tenKM == "")
            {
                MessageBox.Show("Vui lòng nhập tên khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String moTa = txtMoTa.Text;
            if (moTa == "")
            {
                MessageBox.Show("Vui lòng nhập mô tả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String phanTramGiam = txtPhanTramGiam.Text;
            if (phanTramGiam == "")
            {
                MessageBox.Show("Vui lòng nhập phần trăm giảm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime ngayBatDau = dtNgayBatDau.Value;
            String ngayBatDausql = ngayBatDau.ToString("yyyy-MM-dd");
            DateTime ngayKetThuc = dtNgayKetThuc.Value;
            String ngayKetThucsql = ngayBatDau.ToString("yyyy-MM-dd");
            String tb = "Kiểm tra thông tin trước khi lưu: \n Mã khuyến mãi: " + maKM + "\n Tên khuyến mãi: " + tenKM + "\n Mô tả: " + moTa + "\n Ngày bắt đầu khuyến mãi: " + ngayBatDausql + "\n Ngày kết thúc khuyến mãi: " + ngayKetThucsql + "\n Phần trăm giảm: " + phanTramGiam;
            if (MessageBox.Show(tb,"Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No){
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "insert into KhuyenMai values('" + maKM + "', N'" + tenKM + "', N'" + moTa + "', '" + ngayBatDausql + "', '" + ngayKetThucsql + "', '" + phanTramGiam + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            loadKhuyenMai();
            MessageBox.Show("Thêm mới thành công", "Thông báo");
            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            String maKM = txtMaKM.Text;
            if (maKM == "")
            {
                MessageBox.Show("Vui lòng nhập mã khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String tenKM = txtTenKM.Text;
            if (tenKM == "")
            {
                MessageBox.Show("Vui lòng nhập tên khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String moTa = txtMoTa.Text;
            if (moTa == "")
            {
                MessageBox.Show("Vui lòng nhập mô tả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String phanTramGiam = txtPhanTramGiam.Text;
            if (phanTramGiam == "")
            {
                MessageBox.Show("Vui lòng nhập phần trăm giảm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime ngayBatDau = dtNgayBatDau.Value;
            String ngayBatDausql = ngayBatDau.ToString("yyyy-MM-dd");
            DateTime ngayKetThuc = dtNgayKetThuc.Value;
            String ngayKetThucsql = ngayBatDau.ToString("yyyy-MM-dd");
            if(MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin không ?", "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "update KhuyenMai set TenKhuyenMai = N'" + tenKM + "', MoTa = N'" + moTa + "', NgayBatDau = '" + ngayBatDausql + "', NgayKetThuc = '" + ngayKetThucsql + "', PhanTramGiam = '" + phanTramGiam + "' where MaKhuyenMai = '" + maKM + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            loadKhuyenMai();
            MessageBox.Show("Cập nhật thành công", "Thông báo");
            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete from KhuyenMai where MaKhuyenMai = '" + txtMaKM.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                loadKhuyenMai();
                MessageBox.Show("Xóa thành công", "Thông báo");
                clear();
                disableTextBox();
                buttonLuu.Enabled = false;
                buttonCapNhat.Enabled = false;
                buttonXoa.Enabled = false;
                buttonHuyThaoTac.Enabled = false;
            }
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String maKM = txtMaKM_TK.Text;
            String tenKM = txtTenKM_TK.Text;
            //DateTime ngayApDung = dtNgayApDung_TK.Value;
            //String ngayApDungsql = ngayApDung.ToString("yyyy-MM-dd");
            String phanTramGiam = txtPhanTramGiam_TK.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "select * from KhuyenMai where MaKhuyenMai like '%"+maKM+"%' and TenKhuyenMai like N'%"+tenKM+"%' and PhanTramGiam like '%"+phanTramGiam+ "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            dgvKhuyenMai.DataSource = tb;
            dgvKhuyenMai.Refresh();

             
        }
    }
}
