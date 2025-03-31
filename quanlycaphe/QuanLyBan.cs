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
    public partial class QuanLyBan : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=quanlycafe;Integrated Security=True");
        public QuanLyBan()
        {
            InitializeComponent();
            loadBan();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }
        public void loadBan()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT * from Ban";
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
            txtMaBan.Text = "";
            txtTenBan.Text = "";
            cbxTrangThai.Text = "";
        }

        public void enableTextBox()
        {
            txtMaBan.Enabled = true;
            txtTenBan.Enabled = true;
            cbxTrangThai.Enabled = true;   
        }
        public void disableTextBox()
        {
            txtMaBan.Enabled = false;
            txtTenBan.Enabled = false;
            cbxTrangThai.Enabled = false;
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            buttonLuu.Enabled = true;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = true;
            enableTextBox();
            clear();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maBan = txtMaBan.Text.Trim();
            String tenBan = txtTenBan.Text.Trim();
            if (maBan == "" || tenBan == "")
            {
                MessageBox.Show("Mã khách hàng và tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String trangThai = cbxTrangThai.SelectedItem.ToString();
            //b2: kết nối sql
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (checkTrungMaBan(maBan))
            {
                MessageBox.Show("Trùng mã khách hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaBan.Focus();
                return;
            }
            String sql = "insert Ban values('" + maBan + "', N'" + tenBan + "',  '" + trangThai + "' )";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadBan();
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maBan = txtMaBan.Text.Trim();
            String tenBan = txtTenBan.Text.Trim();
            if (maBan == "" || tenBan == "")
            {
                MessageBox.Show("Mã khách hàng và tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn trạng thái bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String trangThai = cbxTrangThai.SelectedItem.ToString();
            //b2: kết nối sql
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "update Ban set TenBan = N'" + tenBan + "', TrangThai =  '" + trangThai + "' where MaBan = '" + maBan + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadBan();
            txtMaBan.Enabled = true;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String maBan = txtMaBan.Text.Trim();
                String sql = "delete from Ban where MaBan = '" + maBan + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                loadBan();
            }
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

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String maBan = txtMaBan_TK.Text.Trim();
            String tenBan = txtTenBan_TK.Text.Trim();
            String trangThai = cbxTrangThai_TK.SelectedItem.ToString();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select * from Ban where MaBan like '%" + maBan + "%' and TenBan like N'%" + tenBan + "%' and TrangThai like N'%" + trangThai + "%'";
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
            txtMaBan.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenBan.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbxTrangThai.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            enableTextBox();
            buttonCapNhat.Enabled = true;
            buttonXoa.Enabled = true;
            buttonHuyThaoTac.Enabled = true;
            buttonLuu.Enabled = false;
            txtMaBan.Enabled = false;
        }
        public bool checkTrungMaBan(String maBan)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from Ban where MaBan = '" + maBan + "'";
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
    }
}
