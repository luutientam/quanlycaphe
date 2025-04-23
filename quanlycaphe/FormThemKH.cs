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
using DocumentFormat.OpenXml.Office2010.Drawing;
using Microsoft.Office.Interop.Excel;

namespace quanlycaphe
{
    public partial class FormThemKH : Form
    {
        public FormThemKH()
        {
            InitializeComponent();
        }

        private void FormThemKH_Load(object sender, EventArgs e)
        {
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
            //b2: kết nối sql
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
            con.Close();
            loadKhachHang();
        }
    }
}
