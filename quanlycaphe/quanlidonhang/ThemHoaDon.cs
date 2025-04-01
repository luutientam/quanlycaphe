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
    public partial class ThemHoaDon : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=VUATAM\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        private SanPham sanPham; // Khai báo biến SanPham

        public ThemHoaDon()
        {
            InitializeComponent();
            loadMaKhachHang();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dgvSanPhamDuocThem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void loadMaKhachHang()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                {
                    string sql = "SELECT * FROM khachhang";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string maKhach = reader["makh"].ToString();
                        string tenKhachHang = reader["tenkhachhang"].ToString();
                        cbxMaKhachHang.Items.Add(maKhach + " - " + tenKhachHang);
                    }
                    reader.Close();
                }
                this.tenSanPhamDuocChon.Enabled = false;
                this.tongTienHoaDonKhuyenMai.Enabled = false;
                this.tongTienHoaDon.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Load dữ liệu
        private void cbxMaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            soLuong.Text = "";

            string tenSanPhamDuocChonChuaTach = chonSanPham.SelectedItem.ToString();
            string[] str = tenSanPhamDuocChonChuaTach.Split('-');
            string tenSanPhamDuocChon = str[0];
            this.tenSanPhamDuocChon.Text = tenSanPhamDuocChon;

            string soLuongSanPham = soLuong.Text; // Lấy số lượng từ giao diện
            sanPham = LayThongTinSanPhamDaChon(tenSanPhamDuocChon); // Lấy thông tin sản phẩm
        }
        // lấy thông tin sản phẩm đã chọn
        private SanPham LayThongTinSanPhamDaChon(string tenSanPham)
        {
            SanPham sanPham = null;
            string connectionString = "YourConnectionStringHere"; // Thay bằng chuỗi kết nối

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sql = "SELECT masanpham, gia FROM sanpham WHERE tensanpham = @TenSanPham";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@TenSanPham", tenSanPham);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string maSanPham = reader["MaSanPham"].ToString();
                        double giaSanPham = Convert.ToDouble(reader["gia"]);
                        sanPham = new SanPham(maSanPham, tenSanPham, giaSanPham);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sanPham;
        }
    }
}

