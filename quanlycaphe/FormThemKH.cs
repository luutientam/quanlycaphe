using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using System.Linq;

using System.Windows.Forms;

using quanlycaphe.quanlidonhang;

namespace quanlycaphe
{
    public partial class FormThemKH : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True");

        ThemHoaDon themHoaDon;

        public FormThemKH(ThemHoaDon parentForm)
        {
            InitializeComponent();
            this.themHoaDon = parentForm;
        }

        private void FormThemKH_Load(object sender, EventArgs e)
        {
        }
        public bool checkTrungMaKH(String maKH)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from KhachHang where MaKhachHang = '" + maKH + "'";
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

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            String maKH = txtMaKH.Text.Trim();
            String tenKH = txtTenKH.Text.Trim();
            if (maKH == "" || tenKH == "")
            {
                MessageBox.Show("Mã khách hàng và tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (checkTrungMaKH(maKH))
            {
                MessageBox.Show("Trùng mã khách hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }

            String sql = "insert KhachHang values('" + maKH + "', N'" + tenKH + "',  '" + sdt + "', N'" + email + "','" + diaChi + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            themHoaDon.loadMaKhachHang(); // Gọi hàm load lại mã khách hàng
            this.Close(); // Đóng form thêm khách hàng
            con.Close();

        }


    }
}
