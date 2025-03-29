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
        SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=quanlycafe;Integrated Security=True");

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
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string query = "SELECT n.MaNguoiDung, n.MaVaiTro, n.TenNguoiDung, n.SoDienThoai, n.NgaySinh, n.GioiTinh, n.DiaChi, " +
                               "nv.MaNhanVien, nv.TenNhanVien, nv.SoDienThoai AS SoDienThoai, nv.DiaChi AS DiaChi " +
                               "FROM NguoiDung n " +
                               "LEFT JOIN TaiKhoan t ON n.MaTaiKhoan = t.MaTaiKhoan " +
                               "LEFT JOIN NhanVien nv ON n.MaTaiKhoan = nv.MaTaiKhoan " +
                               "WHERE t.TenDangNhap = '" + txtTaiKhoan.Text + "' AND t.MatKhau = '" + textBoxMatKhau.Text + "'";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    User.MaNguoiDung = dt.Rows[0]["MaNguoiDung"].ToString();
                    User.MaVaiTro = dt.Rows[0]["MaVaiTro"].ToString();
                    User.TenNguoiDung = dt.Rows[0]["TenNguoiDung"].ToString();
                    User.SoDienThoai = dt.Rows[0]["SoDienThoai"].ToString();
                    User.NgaySinh = dt.Rows[0]["NgaySinh"].ToString();
                    User.GioiTinh = dt.Rows[0]["GioiTinh"].ToString();
                    User.DiaChi = dt.Rows[0]["DiaChi"].ToString();
                    User.MaTaiKhoan = dt.Rows[0]["MaTaiKhoan"].ToString();
                    
                    User.MaNhanVien = null;
                    User.TenNhanVien = null;

                    // Nếu là nhân viên, lấy thêm thông tin nhân viên
                    if (dt.Rows[0]["MaNhanVien"] != null)
                    {
                        User.MaNguoiDung = null;
                        User.MaVaiTro = null;
                        User.TenNguoiDung = null;

                        User.MaNhanVien = dt.Rows[0]["MaNhanVien"].ToString();
                        User.TenNhanVien = dt.Rows[0]["TenNhanVien"].ToString();
                        User.SoDienThoai = dt.Rows[0]["SoDienThoai"].ToString();
                        User.DiaChi = dt.Rows[0]["DiaChi"].ToString();
                        User.NgaySinh = dt.Rows[0]["NgaySinh"].ToString();
                        User.GioiTinh = dt.Rows[0]["GioiTinh"].ToString();
                        User.MaTaiKhoan = dt.Rows[0]["MaTaiKhoan"].ToString();
                    }
                }

                else
                {
                        FormChinh f = new FormChinh();
                        f.Show();
                        this.Hide();
                        //MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
            catch (Exception ex)
            {
                FormChinh f = new FormChinh();
                f.Show();
                this.Hide();
            }
            
        }
    }
}
