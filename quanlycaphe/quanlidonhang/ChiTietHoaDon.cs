using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlycaphe.quanlidonhang
{
    public partial class ChiTietHoaDon : Form
    {
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void quayLai_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        internal void setData(string maHoaDon_1, string tenKhachHang_1, string tenNhanVien_1, string ngayLap_1, string tongTien_1)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True"))
                {
                    connection.Open();

                    string sql = @"
                        SELECT sp.tensanpham AS [Tên sản phẩm], 
                               ctdh.soluong AS [Số lượng], 
                               ctdh.gia AS [Giá]
                        FROM donhang dh
                        JOIN chitietdonhang ctdh ON dh.madonhang = ctdh.madonhang
                        JOIN sanpham sp ON ctdh.masanpham = sp.masanpham
                        WHERE dh.madonhang = @mahd";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@mahd", maHoaDon_1);

                        SqlDataReader reader = cmd.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Columns.Add("stt");
                        dt.Columns.Add("TenSanPham");
                        dt.Columns.Add("SoLuong");
                        dt.Columns.Add("Gia");

                        int i = 0;
                        while (reader.Read())
                        {
                            i++;
                            dt.Rows.Add(i,
                                        reader["Tên sản phẩm"].ToString(),
                                        reader["Số lượng"].ToString(),
                                        reader["Giá"].ToString());
                        }

                        dgvLoadThongTinSanPham.DataSource = dt;
                        dgvLoadThongTinSanPham.Enabled = false;

                        reader.Close();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn: " + ex.Message);
            }

            // Gán dữ liệu vào các TextBox
            maHoaDon.Text = maHoaDon_1;
            maHoaDon.Enabled = false;
            khachHang.Text = tenKhachHang_1;
            khachHang.Enabled = false;
            nhanVienLapHoaDon.Text = tenNhanVien_1;
            nhanVienLapHoaDon.Enabled = false;
            ngayLapHoaDon.Text = ngayLap_1;
            ngayLapHoaDon.Enabled = false;
            tongTien.Text = tongTien_1;
            tongTien.Enabled = false;
            maKhuyenMai.Enabled = false;
        }
    }
}
