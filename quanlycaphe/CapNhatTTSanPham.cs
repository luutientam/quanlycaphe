﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;


namespace quanlycaphe
{

    public partial class CapNhatTTSanPham : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True");
        SanPham formsp;
        public CapNhatTTSanPham(SanPham sp)
        {
            InitializeComponent();
            loadcbbKhuyenMai();
            loadcbbNhaCungCap();
            loadcbbDanhMuc();
            formsp = sp;
        }
        public void loadcbbDanhMuc()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT * FROM DanhMuc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable tb = new System.Data.DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            DataRow r = tb.NewRow();
            r["MaDanhMuc"] = "";
            r["TenDanhMuc"] = "--- Chọn danh mục sp ---";
            tb.Rows.InsertAt(r, 0);

            cbbTenDanhMuc.DataSource = tb;
            cbbTenDanhMuc.DisplayMember = "TenDanhMuc";
            cbbTenDanhMuc.ValueMember = "MaDanhMuc";
        }
        public void loadcbbNhaCungCap()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT * FROM NhaCungCap";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable tb = new System.Data.DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            DataRow r = tb.NewRow();
            r["MaNhaCungCap"] = "";
            r["TenNhaCungCap"] = "--- Chọn nhà cung cấp ---";
            tb.Rows.InsertAt(r, 0);

            cbbTenNhaCungCap.DataSource = tb;
            cbbTenNhaCungCap.DisplayMember = "TenNhaCungCap";
            cbbTenNhaCungCap.ValueMember = "MaNhaCungCap";
        }
        public void loadcbbKhuyenMai()
        {
            if (con.State == ConnectionState.Closed) con.Open();

            string sql = "SELECT MaKhuyenMai, TenKhuyenMai, PhanTramGiam FROM KhuyenMai";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            System.Data.DataTable tb = new System.Data.DataTable();
            da.Fill(tb);
            con.Close();

            // Thêm dòng mặc định
            DataRow r = tb.NewRow();
            r["MaKhuyenMai"] = "";
            r["TenKhuyenMai"] = "--- Chọn khuyến mãi (nếu có) ---";
            r["PhanTramGiam"] = 0;
            tb.Rows.InsertAt(r, 0);

            // Tạo cột hiển thị kết hợp
            tb.Columns.Add("DisplayText", typeof(string));
            foreach (DataRow row in tb.Rows)
            {
                var ma = row["MaKhuyenMai"]?.ToString();
                var ten = row["TenKhuyenMai"]?.ToString();
                var pct = Convert.ToDecimal(row["PhanTramGiam"]);
                row["DisplayText"] =  $"{ma} - {ten} ({pct:N0}%)";
            }

            cbbKhuyenMai.DataSource = tb;
            cbbKhuyenMai.DisplayMember = "DisplayText";
            cbbKhuyenMai.ValueMember = "MaKhuyenMai";
        }

        public void them()
        {
            buttonCapNhat.Visible = false;
            buttonXoa.Visible = false;
        }
        public void capNhatThongTin(String maSP, String tenSP, String tenDanhMuc, String gia, String moTa, String duongDanAnh, String duongDanDayDu, String tenNhaCungCap, DateTime ngayTao, DateTime hanSuDung, String soLuong, String giaNhap, String maKhuyenMai)
        {
            labelsp.Text = "Cập nhật thông tin sản phẩm";
            txtMaSP.Enabled = false;
            buttonLuu.Visible = false;
            txtMaSP.Text = maSP;
            txtTenSP.Text = tenSP;
            cbbTenDanhMuc.Text = tenDanhMuc;
            txtGia.Text = gia;
            txtMoTa.Text = moTa;
            if (File.Exists(duongDanDayDu))
            {
                pictureBox1.Image = Image.FromFile(duongDanDayDu);
                txtDuongDanCU.Text = duongDanAnh;
            }
            cbbTenNhaCungCap.Text = tenNhaCungCap;
            dtNgayTao.Value = ngayTao;
            txtSoLuong.Text = soLuong;
            dtPHanSuDung.Value =  hanSuDung;
            txtGiaNhap.Text =  giaNhap;
            cbbKhuyenMai.SelectedValue = maKhuyenMai;
            formsp.loadSanPham();


        }
        public bool checkTrungMaSanPham(String maSP)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from SanPham where MaSanPham = '" + maSP + "'";
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
            String maSP = txtMaSP.Text;
            String tenSP = txtTenSP.Text;

            String gia = txtGia.Text;
            String soLuong = txtSoLuong.Text;
            String moTa = txtMoTa.Text;

            if (maSP == "")
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra mã sản phẩm không chứa khoảng trắng
            Regex regexMaSP = new Regex(@"^\S+$");
            if (!regexMaSP.IsMatch(maSP))
            {
                MessageBox.Show("Mã sản phẩm không được chứa khoảng trắng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (checkTrungMaSanPham(maSP))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tenSP == "")
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String maDanhMuc = cbbTenDanhMuc.SelectedValue.ToString();
            if (maDanhMuc == "")
            {
                MessageBox.Show("Vui lòng chọn danh mục sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gia == "")
            {
                MessageBox.Show("Vui lòng nhập giá sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (soLuong == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra giá chỉ chứa số
            Regex regexGia = new Regex(@"^\d+([.]\d+)?$");
            if (!regexGia.IsMatch(gia))
            {
                MessageBox.Show("Giá sản phẩm chỉ được nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String giaNhap = txtGiaNhap.Text;
            // Kiểm tra giá chỉ chứa số
            if (!regexGia.IsMatch(giaNhap))
            {
                MessageBox.Show("Giá sản phẩm chỉ được nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Regex regexSoLuong = new Regex(@"^\d+$");
            if (!regexSoLuong.IsMatch(soLuong))
            {
                MessageBox.Show("Số lượng sản phẩm chỉ được nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (moTa == "")
            {
                MessageBox.Show("Vui lòng nhập mô tả sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra nếu ảnh chưa được chọn
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh cho sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String maNhaCungCap = cbbTenNhaCungCap.SelectedValue.ToString();
            if (maNhaCungCap == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đường dẫn lưu ảnh trong project
            string thuMucAnh = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imageSP");
            if (!Directory.Exists(thuMucAnh))
            {
                Directory.CreateDirectory(thuMucAnh);
            }
            string tenTepAnh = Guid.NewGuid().ToString() + ".jpg";
            string duongDanTep = Path.Combine(thuMucAnh, tenTepAnh);

            // Lưu ảnh vào thư mục
            pictureBox1.Image.Save(duongDanTep, ImageFormat.Jpeg);
            // Lưu đường dẫn tương đối vào CSDL
            string duongDanTuongDoi = Path.Combine("imageSP", tenTepAnh);
            String ngayTao = dtNgayTao.Value.ToString("yyyy-MM-dd");
            String hanSuDung = dtPHanSuDung.Value.ToString("yyyy-MM-dd");
            String maKhuyenMai = cbbKhuyenMai.SelectedValue.ToString();

            if (MessageBox.Show("Bạn có chắc chắn muốn thêm sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            // Mở kết nối CSDL nếu đang đóng
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "INSERT INTO SanPham VALUES('" + maSP + "', N'" + tenSP + "', '" + maDanhMuc + "', '" + gia + "', N'" + moTa + "', '" + duongDanTuongDoi + "', '" + ngayTao + "', '" + maNhaCungCap + "', '" + soLuong + "','" + hanSuDung + "','" + giaNhap + "'";
            if (maKhuyenMai != "")
            {
                sql += ", '" + maKhuyenMai + "'";
            }
            else {
            sql += ", NULL";
            }
            sql += ")";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);
            formsp.loadSanPham();
            Close();
            
        }

        private void buttonHuyThaoTac_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn hủy thao tác không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }


        }
        private bool KiemTraSanPhamTonTaiTrongChiTietDonHang(string maSP)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string sql = "SELECT COUNT(*) FROM ChiTietDonHang WHERE MaSanPham = @MaSP";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaSP", maSP);

            int count = (int)cmd.ExecuteScalar();

            cmd.Dispose();
            con.Close();

            return count > 0;
        }


        private void buttonXoa_Click(object sender, EventArgs e)
        {
            String maSP = txtMaSP.Text;
            if (KiemTraSanPhamTonTaiTrongChiTietDonHang(maSP))
            {
                MessageBox.Show("Không thể xóa sản phẩm này vì nó đã tồn tại trong chi tiết đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "DELETE FROM SanPham WHERE MaSanPham = '" + maSP + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);
            formsp.loadSanPham();
            Close();

        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            String maSP = txtMaSP.Text;
            String tenSP = txtTenSP.Text;
            String maDanhMuc = cbbTenDanhMuc.SelectedValue.ToString();
            String gia = txtGia.Text;
            String soLuong = txtSoLuong.Text;
            String moTa = txtMoTa.Text;
            String maNhaCungCap = cbbTenNhaCungCap.SelectedValue.ToString();
            if (tenSP == "")
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (maDanhMuc == "")
            {
                MessageBox.Show("Vui lòng chọn danh mục sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gia == "")
            {
                MessageBox.Show("Vui lòng nhập giá sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (soLuong == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra giá chỉ chứa số (hỗ trợ số thực với dấu . hoặc ,)
            Regex regexGia = new Regex(@"^\d+([.]\d+)?$");
            if (!regexGia.IsMatch(gia))
            {
                MessageBox.Show("Giá sản phẩm nhập chưa hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String giaNhap = txtGiaNhap.Text;
            // Kiểm tra giá chỉ chứa số
            if (!regexGia.IsMatch(giaNhap))
            {
                MessageBox.Show("Giá sản phẩm chỉ được nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Regex regexSoLuong = new Regex(@"^\d+$");
            if (!regexSoLuong.IsMatch(soLuong))
            {
                MessageBox.Show("Số lượng sản phẩm chỉ được nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (moTa == "")
            {
                MessageBox.Show("Vui lòng nhập mô tả sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra nếu ảnh chưa được chọn
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh cho sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (maNhaCungCap == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string duongDanTuongDoi = null;
            if (txtDuongDanMOI.Text != "")
            {
                // Đường dẫn lưu ảnh trong project
                string thuMucAnh = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imageSP");
                if (!Directory.Exists(thuMucAnh))
                {
                    Directory.CreateDirectory(thuMucAnh);
                }
                string tenTepAnh = Guid.NewGuid().ToString() + ".jpg";
                string duongDanTep = Path.Combine(thuMucAnh, tenTepAnh);

                // Lưu ảnh vào thư mục
                pictureBox1.Image.Save(duongDanTep, ImageFormat.Jpeg);
                // Lưu đường dẫn tương đối vào CSDL
                duongDanTuongDoi = Path.Combine("imageSP", tenTepAnh);
            }
            else
            {
                duongDanTuongDoi = txtDuongDanCU.Text;
            }
            String ngayTao = dtNgayTao.Value.ToString("yyyy-MM-dd");
            String hanSuDung = dtPHanSuDung.Value.ToString("yyyy-MM-dd");
            String maKhuyenMai = cbbKhuyenMai.SelectedValue.ToString();
            if (maKhuyenMai == "")
            {
                maKhuyenMai = null;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // Mở kết nối CSDL nếu đang đóng
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            // Câu lệnh SQL với tham số hóa
            String sql = "UPDATE SanPham SET TenSanPham = @TenSanPham, MaDanhMuc = @MaDanhMuc, Gia = @Gia, MoTa = @MoTa, HinhAnh = @HinhAnh, NgayTao = @NgayTao, MaNhaCungCap = @MaNhaCungCap, SoLuong = @SoLuong, HanSuDung = @HanSuDung, GiaNhap = @GiaNhap, MaKhuyenMai = @MaKhuyenMai WHERE MaSanPham = @MaSanPham";

            SqlCommand cmd = new SqlCommand(sql, con);

            // Thêm các tham số
            cmd.Parameters.AddWithValue("@TenSanPham", tenSP);
            cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);
            cmd.Parameters.AddWithValue("@Gia", gia);
            cmd.Parameters.AddWithValue("@MoTa", moTa);
            cmd.Parameters.AddWithValue("@HinhAnh", duongDanTuongDoi);
            cmd.Parameters.AddWithValue("@NgayTao", ngayTao);
            cmd.Parameters.AddWithValue("@MaNhaCungCap", maNhaCungCap);
            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
            cmd.Parameters.AddWithValue("@HanSuDung", hanSuDung);
            cmd.Parameters.AddWithValue("@GiaNhap", giaNhap);
            cmd.Parameters.AddWithValue("@MaKhuyenMai", (object)maKhuyenMai ?? DBNull.Value); // Nếu maKhuyenMai là null, thì thay thế bằng DBNull.Value
            cmd.Parameters.AddWithValue("@MaSanPham", maSP);

            // Thực thi câu lệnh
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            // Thông báo cập nhật thành công
            MessageBox.Show("Cập nhật sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);

            // Load lại dữ liệu sau khi cập nhật
            formsp.loadSanPham();
            Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.png;*.bmp;*.jfif;*.jpeg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                txtDuongDanMOI.Text = openFileDialog.FileName;
            }
        }
    }
}
