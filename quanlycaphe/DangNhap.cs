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
    public partial class DangNhap : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6VHQAFG;Initial Catalog=quanlycafe;Integrated Security=True");

        public DangNhap()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Đảo trạng thái ẩn/hiện mật khẩu
            textBoxMatKhau.UseSystemPasswordChar = !textBoxMatKhau.UseSystemPasswordChar;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string query = "SELECT * FROM NguoiDung WHERE TenDangNhap = '" + txtTaiKhoan.Text + "' AND MatKhau = '" + textBoxMatKhau.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                User.UserId = dt.Rows[0]["MaNguoiDung"].ToString();
                User.Username = dt.Rows[0]["TenDangNhap"].ToString();
                User.Role = dt.Rows[0]["MaVaiTro"].ToString();
                
            }
            else
            {
                FormChinh f = new FormChinh();
                f.Show();
                this.Hide();
                //MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
