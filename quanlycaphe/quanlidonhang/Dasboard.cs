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

namespace quanlycaphe.quanlidonhang
{
    public partial class Dasboard : Form
    {
private SqlConnection con = new SqlConnection(@"Data Source=VUATAM\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");


        public Dasboard()
        {
            InitializeComponent();
            loadDonHang();
      
            nhapExcel.Enabled = false;
            xuatExcel.Enabled = false;
        }

        public void loadDonHang()
        {
            // load don hang len datagridview
            

            try
            {
                if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            }catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=quanlycafe;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
             if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
           
            string sql = "select dh.MaDonHang , kh.TenKhachHang , nv.TenNhanVien , dh.NgayDat, dh.TongTien , dh.MaKhuyenMai from DonHang dh join KhachHang kh on dh.MaKhachHang = kh.MaKhachHang " +
                "join NhanVien nv on nv.MaNhanVien = dh.MaNhanVien";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            dgvDanhSachHoaDon.DataSource = tb;
            dgvDanhSachHoaDon.Refresh();
        }


        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKhuyenMai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonThemMoi_Click(object sender, EventArgs e)
        {
            ThemHoaDon themHoaDon = new ThemHoaDon();
            themHoaDon.ShowDialog();
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
           
        }

        private void timKiem_Click(object sender, EventArgs e)
        {
            string txtTimKiemTmp = txtTimKiem.Text.Trim();

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // Xây dựng câu truy vấn SQL với điều kiện tìm kiếm (nếu cần)
                string sql = "SELECT dh.MaDonHang, kh.tenkhachhang, nv.tennhanvien, dh.NgayDat, dh.tongtien, dh.MaKhuyenMai " +
                             "FROM donhang dh " +
                             "JOIN nhanvien nv ON dh.MaNhanVien = nv.MaNhanVien " +
                             "JOIN khachhang kh ON dh.MaKhachHang = kh.MaKhachHang " +
                             "WHERE dh.MaDonHang LIKE '%" + txtTimKiemTmp + "%' " +
                             "OR kh.tenkhachhang LIKE N'%" + txtTimKiemTmp + "%' " +
                             "OR nv.tennhanvien LIKE N'%" + txtTimKiemTmp + "%' " +
                             "OR dh.NgayDat LIKE '%" + txtTimKiemTmp + "%' " +
                             "OR dh.tongtien LIKE '%" + txtTimKiemTmp + "%' " +
                             "OR dh.MaKhuyenMai LIKE '%" + txtTimKiemTmp + "%'";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable tb = new DataTable();
                    da.Fill(tb);

                    dgvDanhSachHoaDon.DataSource = tb;
                    dgvDanhSachHoaDon.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
