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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace quanlycaphe
{
    public partial class NhaCungCap : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=quanlycafe;Integrated Security=True");
        public NhaCungCap()
        {
            InitializeComponent();
            loadNhaCungCap();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;

        }
        public void loadNhaCungCap()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT * from NhaCungCap";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Dispose();
            con.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }
        public void clear()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSdt.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
        }
        public void enableTextBox()
        {
            txtMaNCC.Enabled = true;
            txtTenNCC.Enabled = true;
            txtSdt.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
        }
        public void disableTextBox()
        {
            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            txtSdt.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maNCC = txtMaNCC.Text.Trim();
            String tenNCC = txtTenNCC.Text.Trim();
            if (maNCC == "" || tenNCC == "")
            {
                MessageBox.Show("Mã nhà cung cấp và tên nhà cung cấp không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String email = txtEmail.Text.Trim();
            String diaChi = txtDiaChi.Text.Trim();
            String sdt = txtSdt.Text.Trim();
            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //b2: kết nối sql
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (checkTrungMaNCC(maNCC))
            {
                MessageBox.Show("Trùng mã nhà cung cấp !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }
            String sql = "insert NhaCungCap values('" + maNCC + "', N'" + tenNCC + "',  '" + sdt + "', N'" + email + "','" + diaChi + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadNhaCungCap();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maNCC = txtMaNCC.Text.Trim();
            String tenNCC = txtTenNCC.Text.Trim();
            if (maNCC == "" || tenNCC == "")
            {
                MessageBox.Show("Mã nhà cung cấp và tên nhà cung cấp không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String email = txtEmail.Text.Trim();
            String diaChi = txtDiaChi.Text.Trim();
            String sdt = txtSdt.Text.Trim();
            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải đủ 10 số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //b2: kết nối sql
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "update NhaCungCap set TenNhaCungCap = N'" + tenNCC + "', Email =  '" + email + "', DiaChi = N'" + diaChi + "', SoDienThoai = '" + sdt + "' where MaNhaCungCap = '" + maNCC + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadNhaCungCap();
            txtMaNCC.Enabled = true;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String maNCC = txtMaNCC.Text.Trim();
                String sql = "delete from NhaCungCap where MaNhaCungCap = '" + maNCC + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                loadNhaCungCap();
            }
        }
        

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String maNCC = txtMaNCC_tk.Text.Trim();
            String tenNCC = txtTenNCC_tk.Text.Trim();
            String sdt = txtSdt_tk.Text.Trim();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select * from NhaCungCap where MaNhaCungCap like '%" + maNCC + "%' and TenNhaCungCap like N'%" + tenNCC + "%' and SoDienThoai like '%" + sdt + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtt = new DataTable();
            da.Fill(dtt);
            cmd.Dispose();
            con.Close();
            dataGridView1.DataSource = dtt;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)e.RowIndex;
            txtMaNCC.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenNCC.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtSdt.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            enableTextBox();
            buttonSua.Enabled = true;
            buttonXoa.Enabled = true;
            buttonHuyThaoTac.Enabled = true;
            buttonLuu.Enabled = false;
            txtMaNCC.Enabled = false;
        }
        public bool checkTrungMaNCC(String maNCC)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from NhaCungCap where MaNhaCungCap = '" + maNCC + "'";
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMaNCC_tk_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTenNCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtSdt_tk_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTenNCC_tk_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            buttonLuu.Enabled = true;
            buttonSua.Enabled = false;
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
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }

        private void txtDiaChi_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
