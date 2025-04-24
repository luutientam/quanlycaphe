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
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True");

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

                string query = "SELECT t.MaTaiKhoan, n.MaNguoiDung, n.MaVaiTro, vt.TenVaiTro, n.TenNguoiDung, n.SoDienThoai, n.NgaySinh, n.GioiTinh, n.DiaChi, " +
  "nv.MaNhanVien, nv.TenNhanVien, nv.SoDienThoai AS SoDienThoaiNV, nv.DiaChi AS DiaChiNV, t.TrangThai " +
  "FROM TaiKhoan t " +
  "LEFT JOIN NguoiDung n ON t.MaTaiKhoan = n.MaTaiKhoan " +
  "LEFT JOIN NhanVien nv ON t.MaTaiKhoan = nv.MaTaiKhoan " +
  "LEFT JOIN VaiTro vt ON vt.MaVaiTro = n.MaVaiTro " +
  "WHERE t.TenDangNhap = @TenDangNhap AND t.MatKhau = @MatKhau";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TenDangNhap", txtTaiKhoan.Text.Trim());
                cmd.Parameters.AddWithValue("@MatKhau", textBoxMatKhau.Text.Trim());

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    var row = dt.Rows[0];
                    String trangThai = row["TrangThai"].ToString();
                    if (trangThai == "Khóa")
                    {
                        MessageBox.Show("Tài khoản đã bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (trangThai == "Chờ xác nhận" || trangThai == "Chờ xác minh")
                    {
                        MessageBox.Show("Tài khoản đang chờ xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!Convert.IsDBNull(row["MaNguoiDung"]))
                    {
                        User.MaNguoiDung = row["MaNguoiDung"].ToString();
                        User.MaVaiTro = row["MaVaiTro"].ToString();
                        User.TenVaiTro = row["TenVaiTro"].ToString();
                        User.TenNguoiDung = row["TenNguoiDung"].ToString();
                        User.SoDienThoai = row["SoDienThoai"].ToString();
                        User.NgaySinh = row["NgaySinh"].ToString();
                        User.GioiTinh = row["GioiTinh"].ToString();
                        User.DiaChi = row["DiaChi"].ToString();
                        User.MaTaiKhoan = row["MaTaiKhoan"].ToString();

                        User.MaNhanVien = null;
                        User.TenNhanVien = null;
                    }
                    else if (!Convert.IsDBNull(row["MaNhanVien"]))
                    {
                        User.MaNhanVien = row["MaNhanVien"].ToString();
                        User.TenNhanVien = row["TenNhanVien"].ToString();
                        User.SoDienThoai = row["SoDienThoaiNV"].ToString();
                        User.DiaChi = row["DiaChi"].ToString();
                        User.NgaySinh = row["NgaySinh"].ToString();
                        User.GioiTinh = row["GioiTinh"].ToString();
                        User.MaTaiKhoan = row["MaTaiKhoan"].ToString();

                        User.MaNguoiDung = null;
                        User.MaVaiTro = null;
                        User.TenVaiTro = null;
                        User.TenNguoiDung = null;
                    }

                    FormChinh f = new FormChinh();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
