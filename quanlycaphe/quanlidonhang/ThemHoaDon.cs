using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml.Wordprocessing;
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
/*            maNhanVien.Text = User.MaNhanVien + " - " + User.TenNhanVien;
            maNhanVien.Enabled = false;*/
            InitializeComponent();
            loadMaKhachHang();
            setNgayLapHoaDon();
            loadSanPham();
            loadMaKhuyenMai();
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
                    model.Rows.Add(sanPham.MaSanPham, sanPham.TenSanPham, soLuongInt, sanPham.Gia * soLuongInt);
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

        private void suaSoLuong_Click(object sender, EventArgs e)
        {
            // Lấy chỉ số hàng được chọn từ DataGridView
            string tenSp = tenSanPhamDuocChon.Text.Trim();
            string sLuong = soLuong.Text;
            int soLuongInt = int.Parse(sLuong);
            int i = kiemTraSoLuong(tenSp, soLuongInt);
            if (i == 1)
            {
                MessageBox.Show("Số lượng nhập vượt quá số lượng trong kho ! \n" + soLuongTrongKho(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int selectedRow = dgvSanPhamDuocThem.CurrentCell.RowIndex; // Lấy chỉ số hàng được chọn
            if (selectedRow >= 0)
            { // Kiểm tra xem có hàng nào được chọn không
                System.Data.DataTable model = (System.Data.DataTable)dgvSanPhamDuocThem.DataSource;

                // Lấy số lượng mới từ TextBox
                int soLuongMoi = int.Parse(this.soLuong.Text);

                // Cập nhật lại số lượng trong bảng
                model.Rows[selectedRow]["soluong"] = soLuongMoi; // Giả sử cột 2 là số lượng

                // Lấy tên sản phẩm từ cột tên
                string tenSanPham = model.Rows[selectedRow]["tensanpham"].ToString();

                // Lấy thông tin sản phẩm dựa trên tên
                SanPham sp = LayThongTinSanPhamDaChon(tenSanPham);

                if (sp != null)
                {
                    // Lấy giá của sản phẩm từ đối tượng SanPham và cập nhật lại giá tổng
                    double giaSanPham = sp.Gia; // Giá của sản phẩm
                    double tongGiaMoi = giaSanPham * soLuongMoi; // Cập nhật tổng giá dựa trên số lượng mới
                    model.Rows[selectedRow]["gia"] = tongGiaMoi; // Cập nhật giá vào cột tổng giá (cột 3)
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            tinhTongTien();
        }

     

        private void xoaSanPham_Click(object sender, EventArgs e)
        {
            int selectedRow = dgvSanPhamDuocThem.CurrentCell.RowIndex; // Lấy chỉ số hàng được chọn
            if (selectedRow >= 0)
            { // Kiểm tra xem có hàng nào được chọn không
                DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                { // Nếu người dùng chọn "Có"
                    System.Data.DataTable model = (System.Data.DataTable)dgvSanPhamDuocThem.DataSource;
                    model.Rows.RemoveAt(selectedRow); // Xóa hàng được chọn
                    // Gọi phương thức tính tổng tiền sau khi xóa sản phẩm
                    tinhTongTien();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void loadMaKhuyenMai()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sql = "SELECT * FROM khuyenmai";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string maKhuyenMai = reader["makhuyenmai"].ToString();
                    string tenKhuyenMai = reader["tenkhuyenmai"].ToString();
                    string phanTramGiam = reader["phantramgiam"].ToString();

                    khuyenMai.Items.Add(maKhuyenMai + " - " + tenKhuyenMai + " - " + phanTramGiam + "%");
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
        private void tinhTongTienKhuyenMai(int phanTram)
        {
            System.Data.DataTable model = (System.Data.DataTable)dgvSanPhamDuocThem.DataSource;
            double tongTienKhuyenMai = 0;
            tongTienKhuyenMai = Convert.ToDouble(this.tongTienHoaDon.Text) * (100 - phanTram) / 100;
            // Cập nhật giá trị tổng tiền vào TextBox
            tongTienHoaDonKhuyenMai.Text = tongTienKhuyenMai.ToString();
        }

        private void dgvSanPhamDuocThem_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy chỉ số hàng được chọn từ DataGridView
            int selectedRow = e.RowIndex; // Lấy chỉ số hàng được chọn
            if (selectedRow >= 0)
            { // Kiểm tra xem có hàng nào được chọn không
                System.Data.DataTable model = (System.Data.DataTable)dgvSanPhamDuocThem.DataSource;

                // Lấy dữ liệu từ bảng theo chỉ số hàng và các cột tương ứng
                string tenSanPham = model.Rows[selectedRow]["tensanpham"].ToString(); // Giả sử cột 1 là tên sản phẩm
                int soLuong = Convert.ToInt32(model.Rows[selectedRow]["soluong"]); // Giả sử cột 2 là số lượng

                // Set lại giá trị vào TextBox để sửa
                tenSanPhamDuocChon.Text = tenSanPham; // Đặt lại tên sản phẩm vào TextBox
                this.soLuong.Text = soLuong.ToString(); // Đặt lại số lượng vào TextBox
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tongTienHoaDonKhuyenMai_TextChanged(object sender, EventArgs e)
        {

        }

        private void khuyenMai_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (khuyenMai.SelectedItem != null)
            {
                string tenKhuyenMaiDuocChon = khuyenMai.SelectedItem.ToString();
                string[] str1 = tenKhuyenMaiDuocChon.Split(new string[] { " - " }, StringSplitOptions.None);
                string maKhuyenMaiDaTach = str1[2];
                string[] str2 = maKhuyenMaiDaTach.Split('%');
                string phanTramDaTach = str2[0];
                tinhTongTienKhuyenMai(int.Parse(phanTramDaTach));
            }
        }

        private void truSoLuongTrongKho(String maSanPham, int soLuong)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // Lấy số lượng trong kho của sản phẩm
                string sqlLaySoLuong = "SELECT soluong FROM sanpham WHERE masanpham = @MaSanPham";
                SqlCommand cmdLaySoLuong = new SqlCommand(sqlLaySoLuong, con);
                cmdLaySoLuong.Parameters.AddWithValue("@MaSanPham", maSanPham);
                SqlDataReader reader = cmdLaySoLuong.ExecuteReader();

                int soLuongTrongKhoInt = 0;
                if (reader.Read())
                {
                    soLuongTrongKhoInt = Convert.ToInt32(reader["soluong"]);
                }
                reader.Close();

                // Kiểm tra và cập nhật số lượng trong kho
                if (soLuongTrongKhoInt >= soLuong)
                {
                    string sqlCapNhatSoLuong = "UPDATE sanpham SET soluong = @SoLuong WHERE masanpham = @MaSanPham";
                    SqlCommand cmdCapNhat = new SqlCommand(sqlCapNhatSoLuong, con);
                    cmdCapNhat.Parameters.AddWithValue("@SoLuong", soLuongTrongKhoInt - soLuong);
                    cmdCapNhat.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    cmdCapNhat.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Số lượng trong kho không đủ để trừ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        private void thanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ giao diện
                /*string maKhachHangGiaoDien = cbxMaKhachHang.SelectedItem.ToString();*/
                string maKhachHangGiaoDien = cbxMaKhachHang.SelectedItem?.ToString();
                if (maKhachHangGiaoDien == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng");
                    return;
                }
                string[] str1 = maKhachHangGiaoDien.Split(new string[] { " - " }, StringSplitOptions.None);
               
                string maKhachHang_1 = str1[0];

                string maNhanVienGiaoDien = maNhanVien.Text;
                string[] str2 = maNhanVienGiaoDien.Split(new string[] { " - " }, StringSplitOptions.None);
                string maNhanVien_1 = str2[0];

                string ngayLapHoaDon_1 = this.ngayLapHoaDon.Text;

                string khuyenMaiGiaoDien = this.khuyenMai.SelectedItem?.ToString();
                if (khuyenMaiGiaoDien == null)
                {
                    MessageBox.Show("Vui lòng chọn mã khuyến mại");
                    return;
                }

                string[] str3 = khuyenMaiGiaoDien.Split(new string[] { " - " }, StringSplitOptions.None);
                string khuyenMai_1 = str3[0];

                string tongTienText = tongTienHoaDonKhuyenMai.Text.Trim();

                // Chuyển đổi sang DateTime để lưu vào cơ sở dữ liệu
                DateTime ngayLapHoaDonDateTime = DateTime.ParseExact(ngayLapHoaDon_1, "yyyy-MM-dd HH:mm:ss", null);

                // Kiểm tra ràng buộc
                if (string.IsNullOrEmpty(maKhachHang_1))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng");
                    return;
                }

                if (dgvSanPhamDuocThem.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm");
                    return;
                }

                if (string.IsNullOrEmpty(khuyenMai_1))
                {
                    MessageBox.Show("Vui lòng chọn mã khuyến mại");
                    return;
                }

                // Chuyển đổi tổng tiền từ chuỗi sang số khi có >= 1 sản phẩm được chọn 
                double tongTienHoaDon_1 = double.Parse(tongTienText);

                // Kết nối với cơ sở dữ liệu
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Thêm hóa đơn vào bảng `hoadon`
                    string sqlInsertHoaDon = "INSERT INTO donhang (makhachhang, manhanvien, ngaydat, tongtien, makhuyenmai) VALUES (@MaKH, @MaNV, @NgayLap, @TongTien, @MaKM)";
                    SqlCommand cmdHoaDon = new SqlCommand(sqlInsertHoaDon, con, transaction);
                    cmdHoaDon.Parameters.AddWithValue("@MaKH", maKhachHang_1);
                    cmdHoaDon.Parameters.AddWithValue("@MaNV", maNhanVien_1);
                    cmdHoaDon.Parameters.AddWithValue("@NgayLap", ngayLapHoaDonDateTime);
                    cmdHoaDon.Parameters.AddWithValue("@TongTien", tongTienHoaDon_1);
                    cmdHoaDon.Parameters.AddWithValue("@MaKM", khuyenMai_1);
                    cmdHoaDon.ExecuteNonQuery();

                    // Lấy mã hóa đơn vừa thêm (auto-increment)
                    cmdHoaDon.CommandText = "SELECT SCOPE_IDENTITY()";
                    int maHoaDon_1 = Convert.ToInt32(cmdHoaDon.ExecuteScalar());

                    // Thêm từng chi tiết hóa đơn vào bảng `chitiethoadon`
                    string sqlInsertChiTietHD = "INSERT INTO chitietdonhang (machitietdonhang, masanpham, soluong, gia) VALUES (@MaHD, @MaSP, @SoLuong, @Gia)";
                    SqlCommand cmdChiTietHD = new SqlCommand(sqlInsertChiTietHD, con, transaction);
                    foreach (DataGridViewRow row in dgvSanPhamDuocThem.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string maSP = row.Cells["masanpham"].Value.ToString();
                        int soLuong = Convert.ToInt32(row.Cells["soluong"].Value);
                        double gia = Convert.ToDouble(row.Cells["gia"].Value);

                        cmdChiTietHD.Parameters.Clear();
                        cmdChiTietHD.Parameters.AddWithValue("@MaHD", maHoaDon_1);
                        cmdChiTietHD.Parameters.AddWithValue("@MaSP", maSP);
                        cmdChiTietHD.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdChiTietHD.Parameters.AddWithValue("@Gia", gia);
                        cmdChiTietHD.ExecuteNonQuery();

                        // Trừ số lượng trong kho khi thêm hóa đơn
                        truSoLuongTrongKho(maSP, soLuong);
                    }

                    // Commit transaction
                    transaction.Commit();

                    MessageBox.Show("Thêm hóa đơn thành công, vui lòng thanh toán!");

                    // Đóng kết nối
                    con.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
            }
        }
    }
}

