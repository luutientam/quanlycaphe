using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.VariantTypes;
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
        private SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True");
        private SanPham sanPham; // Khai báo biến SanPham

        public ThemHoaDon()
        {
            InitializeComponent();
            loadMaKhachHang();
            setNgayLapHoaDon();
            loadSanPham();
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
                string sql = "SELECT * FROM khachhang";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string maKhach = reader["makhachhang"].ToString();
                    string tenKhachHang = reader["tenkhachhang"].ToString();
                    cbxMaKhachHang.Items.Add(maKhach + " - " + tenKhachHang);
                }
                reader.Close();

                this.tenSanPhamDuocChon.Enabled = false;
                this.tongTienHoaDonKhuyenMai.Enabled = false;
                this.tongTienHoaDon.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadSanPham()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sql = "SELECT * FROM sanpham";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string tensanpham = reader["tensanpham"].ToString();
                    chonSanPham.Items.Add(tensanpham);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        // Load dữ liệu
        private void cbxMaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        // lấy thông tin sản phẩm đã chọn
        private SanPham LayThongTinSanPhamDaChon(string tenSanPham)
        {
            SanPham sanPham = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string sql = "SELECT masanpham, gia FROM sanpham WHERE tensanpham = @TenSanPham";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@TenSanPham", tenSanPham);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string maSanPham = reader["masanpham"].ToString(); // Ghi đúng tên cột như trong DB
                    double giaSanPham = Convert.ToDouble(reader["gia"]);
                    sanPham = new SanPham(maSanPham, tenSanPham, giaSanPham);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sanPham;
        }

        private void maNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        // set ma nhan vien va ten nhan vien  
/*        public void setMaNhanVien(User user)
        {
            maNhanVien.Text = user.MaNhanVien + " - " + user.TenNhanVien;
            maNhanVien.Enabled = false;
        }
*/
        // set ma nhan vien va ten nhan vien  
        public void setNgayLapHoaDon()
        {
            try
            {
                // Lấy thời gian hiện tại cho ngày lập hóa đơn
                DateTime now = DateTime.Now;
                string formattedDateTime = now.ToString("yyyy-MM-dd HH:mm:ss");
                ngayLapHoaDon.Text = formattedDateTime;
                ngayLapHoaDon.Enabled = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi thêm hóa đơn: " + e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chonSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            soLuong.Text = "";

            if (chonSanPham.SelectedItem != null)
            {
                string tenSanPhamDuocChonChuaTach = chonSanPham.SelectedItem.ToString();
                string[] str = tenSanPhamDuocChonChuaTach.Split('-');
                string tenSanPhamDuocChon = str[0].Trim();
                this.tenSanPhamDuocChon.Text = tenSanPhamDuocChon;
                string soLuongSanPham = soLuong.Text; // Lấy số lượng từ giao diện
                sanPham = LayThongTinSanPhamDaChon(tenSanPhamDuocChon); // Lấy thông tin sản phẩm
            }
        }

        private void huyHoaDon_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tenSanPhamDuocChon_TextChanged(object sender, EventArgs e)
        {

        }

        private void soLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void themSanPham_Click(object sender, EventArgs e)
        {
            if (sanPham != null)
            {
                var model = (System.Data.DataTable)dgvSanPhamDuocThem.DataSource;
                if (model == null)
                {
                    // Initialize the DataTable if it is null
                    model = new System.Data.DataTable();
                    model.Columns.Add("masanpham", typeof(string));
                    model.Columns.Add("tensanpham", typeof(string));
                    model.Columns.Add("soluong", typeof(int));
                    model.Columns.Add("gia", typeof(double));
                    dgvSanPhamDuocThem.DataSource = model;
                }

                bool sanPhamDaTonTai = false;
                // Duyệt qua tất cả các dòng trong bảng để kiểm tra xem sản phẩm đã tồn tại hay chưa
                foreach (DataRow row in model.Rows)
                {
                    string maSanPhamTrongBang = row["masanpham"].ToString(); // Lấy mã sản phẩm từ cột đầu tiên
                    if (maSanPhamTrongBang != null && maSanPhamTrongBang.Equals(sanPham.MaSanPham))
                    {
                        // Nếu sản phẩm đã tồn tại, tăng số lượng lên
                        int soLuongHienTai = row["soluong"] == DBNull.Value ? 0 : Convert.ToInt32(row["soluong"]);

                        soLuongHienTai += Convert.ToInt32(soLuong.Text); // Tăng số lượng lên
                        row["soluong"] = soLuongHienTai; // Cập nhật số lượng

                        // Cập nhật giá theo số lượng mới
                        double giaSanPham = sanPham.Gia;
                        row["gia"] = giaSanPham * soLuongHienTai; // Cập nhật giá

                        sanPhamDaTonTai = true;
                        break;
                    }
                }

                // Nếu sản phẩm chưa tồn tại trong bảng thì thêm dòng mới
                if (!sanPhamDaTonTai)
                {
                    string tenSanPham = tenSanPhamDuocChon.Text.Trim();
                    int soLuongInt = Convert.ToInt32(soLuong.Text);
                    int i = kiemTraSoLuong(tenSanPham, soLuongInt);
                    if (i == 1)
                    {
                        MessageBox.Show("Số lượng nhập vượt quá số lượng trong kho ! \n" + soLuongTrongKho());
                        return;
                    }
                    if (soLuongInt > 10)
                    {
                        MessageBox.Show("Số lượng quá 10 \n" + soLuongTrongKho());
                        return;
                    }
                    model.Rows.Add(sanPham.MaSanPham, sanPham.TenSanPham, soLuongInt, sanPham.Gia);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Gọi phương thức tính tổng tiền sau khi thêm sản phẩm
            tinhTongTien();
        }


        private void tinhTongTien()
        {
            System.Data.DataTable model = (System.Data.DataTable)dgvSanPhamDuocThem.DataSource;
            double tongTien = 0;

            foreach (DataRow row in model.Rows)
            {
                double gia = Convert.ToDouble(row["gia"]); // Lấy giá từ cột "gia"
                tongTien += gia; // Tính tổng tiền
            }
            // Cập nhật giá trị tổng tiền vào TextBox
            tongTienHoaDon.Text = tongTien.ToString();
        }

        private int kiemTraSoLuong(String tenSanPhamDuocChon, int soLuongNhap)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sql = "SELECT soluong FROM sanpham WHERE tensanpham = @TenSanPham";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@TenSanPham", tenSanPhamDuocChon);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int soLuongTrongKho = Convert.ToInt32(reader["soluong"]);
                    if (soLuongNhap > soLuongTrongKho)
                    {
                        return 1;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return 0;
        }
        private String soLuongTrongKho()
        {
            String danhSachSoluong = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String sql = "SELECT tensanpham, soluong FROM sanpham";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                danhSachSoluong = "Số lượng trong kho: \n";
                while (reader.Read())
                {
                    String tenSp = reader["tensanpham"].ToString();
                    String soLuong = reader["soluong"].ToString();
                    danhSachSoluong += tenSp + ": " + soLuong + "\n";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return danhSachSoluong;
        }
    }
}

