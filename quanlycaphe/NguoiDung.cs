using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlycaphe
{
    public partial class NguoiDung : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=quanlycafe;Integrated Security=True");

        public NguoiDung()
        {
            InitializeComponent();
            loadNguoiDung();
            loadVaiTro();
            disableTextBox();
            dtNgayTao.Enabled = false;
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }
        public void clear()
        {
            txtMaND.Text = "";
            txtTenND.Text = "";
            cbbVaiTro.SelectedIndex = 0;
            txtSDT.Text = "";
            dtNgaySinh.Value = DateTime.Now;
            cbbGioiTinh.SelectedIndex = -1;
            txtDiaChi.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtEmail.Text = "";
            dtNgayTao.Value = DateTime.Now;
            cbbTrangThai.SelectedIndex = -1;
        }
        public void disableTextBox()
        {
            txtMaND.Enabled = false;
            txtTenND.Enabled = false;
            cbbVaiTro.Enabled = false;
            txtSDT.Enabled = false;
            dtNgaySinh.Enabled = false;
            cbbGioiTinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;
            txtEmail.Enabled = false;
            dtNgayTao.Enabled = false;
            cbbTrangThai.Enabled = false;
        }
        public void enableTextBox()
        {
            txtMaND.Enabled = true;
            txtTenND.Enabled = true;
            cbbVaiTro.Enabled = true;
            txtSDT.Enabled = true;
            dtNgaySinh.Enabled = true;
            cbbGioiTinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtTenDangNhap.Enabled = true;
            txtMatKhau.Enabled = true;
            txtEmail.Enabled = true;
            cbbTrangThai.Enabled = true;
        }
        public void loadVaiTro()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT * FROM VaiTro";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            cbbVaiTro.DataSource = tb;
            cbbVaiTro.DisplayMember = "TenVaiTro";
            cbbVaiTro.ValueMember = "MaVaiTro";
        }
        public void loadNguoiDung()
        {
            // Load khuyen mai
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT N.MaNguoiDung,  N.TenNguoiDung, V.TenVaiTro, N.SoDienThoai, N.NgaySinh, N.GioiTinh, N.DiaChi,T.TenDangNhap, T.MatKhau, T.Email, T.NgayTao, T.TrangThai FROM NguoiDung N JOIN TaiKhoan T ON N.MaTaiKhoan = T.MaTaiKhoan JOIN VaiTro V ON N.MaVaiTro = V.MaVaiTro";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            dgvNguoiDung.DataSource = tb;
            dgvNguoiDung.Refresh();
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)e.RowIndex;
            txtMaND.Text = dgvNguoiDung.Rows[i].Cells[0].Value.ToString();
            txtTenND.Text = dgvNguoiDung.Rows[i].Cells[1].Value.ToString();
            cbbVaiTro.Text = dgvNguoiDung.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text = dgvNguoiDung.Rows[i].Cells[3].Value.ToString();
            dtNgaySinh.Value = Convert.ToDateTime(dgvNguoiDung.Rows[i].Cells[4].Value.ToString());
            cbbGioiTinh.Text = dgvNguoiDung.Rows[i].Cells[5].Value.ToString();
            txtDiaChi.Text = dgvNguoiDung.Rows[i].Cells[6].Value.ToString();
            txtTenDangNhap.Text = dgvNguoiDung.Rows[i].Cells[7].Value.ToString();
            txtMatKhau.Text = dgvNguoiDung.Rows[i].Cells[8].Value.ToString();
            txtEmail.Text = dgvNguoiDung.Rows[i].Cells[9].Value.ToString();
            dtNgayTao.Value = Convert.ToDateTime(dgvNguoiDung.Rows[i].Cells[10].Value.ToString());
            string trangThai = dgvNguoiDung.Rows[i].Cells[11].Value.ToString();
            if (Convert.ToInt32(trangThai) == 1)
            {
                cbbTrangThai.Text = "Hoạt động";
            }
            else if (Convert.ToInt32(trangThai) == 0)
            {
                cbbTrangThai.Text = "Khóa";
            }
            else
            {
                cbbTrangThai.Text = "Chưa xác minh";
            }
            enableTextBox();
            buttonCapNhat.Enabled = true;
            buttonXoa.Enabled = true;
            buttonHuyThaoTac.Enabled = true;
            buttonLuu.Enabled = false;
            txtMaND.Enabled = false;
        }

        private void buttonThemMoi_Click(object sender, EventArgs e)
        {
            buttonLuu.Enabled = true;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = true;
            enableTextBox();
            clear();
        }

        private void buttonHuyThaoTac_Click(object sender, EventArgs e)
        {
            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }
        public bool checkTrungMaNguoiDung(String maNguoiDung)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from NguoiDung where MaNguoiDung = '" + maNguoiDung + "'";
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
            String maNguoiDung = txtMaND.Text;
            String tenNguoiDung = txtTenND.Text;
            String maVaiTro = cbbVaiTro.SelectedValue.ToString();
            String soDienThoai = txtSDT.Text;
            String ngaySinh = dtNgaySinh.Value.ToString("yyyy-MM-dd");
            String diaChi = txtDiaChi.Text;
            String tenDangNhap = txtTenDangNhap.Text;
            String matKhau = txtMatKhau.Text;
            String email = txtEmail.Text;
            String ngayTao = dtNgayTao.Value.ToString("yyyy-MM-dd");
           
            if (maNguoiDung == "")
            {
                MessageBox.Show("Mã người dùng không được để trống","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if(checkTrungMaNguoiDung(maNguoiDung))
            {
                MessageBox.Show("Mã người dùng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tenNguoiDung == "")
            {
                MessageBox.Show("Tên người dùng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String gioiTinh = cbbGioiTinh.Text;
            if (tenDangNhap == "")
            {
                MessageBox.Show("Tên đăng nhập không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (matKhau == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (email == "")
            {
                MessageBox.Show("Email không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Regex regexSDT = new Regex(@"^0\d{9,10}$"); // Chỉ nhận số, dài 10-11 số
            Regex regexEmail = new Regex(@"^[\w.-]+@[\w.-]+\.[a-zA-Z]{2,6}$"); // Định dạng email
            Regex regexNoSpace = new Regex(@"^\S+$"); // Không chứa khoảng trắng
            if (!regexSDT.IsMatch(soDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!regexEmail.IsMatch(email))
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!regexNoSpace.IsMatch(maNguoiDung))
            {
                MessageBox.Show("Mã người dùng không được chứa khoảng trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!regexNoSpace.IsMatch(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập không được chứa khoảng trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String trangThai = cbbTrangThai.Text;
            if (trangThai == "Hoạt động" || cbbTrangThai.SelectedIndex == -1)
            {
                trangThai = "1";
            }
            else if (trangThai == "Khóa")
            {
                trangThai = "0";
            }
            else
            {
                trangThai = "2";
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String maTaiKhoan = "MTK" + maNguoiDung;
            String sqlTK = "INSERT INTO TaiKhoan VALUES('" + maTaiKhoan + "', '" + tenDangNhap + "', '" + matKhau + "', '" + email + "', '" + ngayTao + "', '" + trangThai + "')";
            SqlCommand cmdTK = new SqlCommand(sqlTK, con);
            cmdTK.ExecuteNonQuery();
            cmdTK.Dispose();
            String sqlND = "INSERT INTO NguoiDung VALUES('" + maNguoiDung + "', '" + maVaiTro + "', '" + maTaiKhoan + "', '" + soDienThoai + "', N'" + tenNguoiDung + "', '" + ngaySinh + "', N'" + gioiTinh + "', N'" + diaChi + "')";
            SqlCommand cmdND = new SqlCommand(sqlND, con);
            cmdND.ExecuteNonQuery();
            cmdND.Dispose();
            con.Close();
            MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadNguoiDung();
            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            String maNguoiDung = txtMaND.Text;
            String tenNguoiDung = txtTenND.Text;
            String maVaiTro = cbbVaiTro.SelectedValue.ToString();
            String soDienThoai = txtSDT.Text;
            String ngaySinh = dtNgaySinh.Value.ToString("yyyy-MM-dd");
            String diaChi = txtDiaChi.Text;
            String tenDangNhap = txtTenDangNhap.Text;
            String matKhau = txtMatKhau.Text;
            String email = txtEmail.Text;
            String ngayTao = dtNgayTao.Value.ToString("yyyy-MM-dd");
            if (tenNguoiDung == "")
            {
                MessageBox.Show("Tên người dùng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String gioiTinh = cbbGioiTinh.Text;
            if (tenDangNhap == "")
            {
                MessageBox.Show("Tên đăng nhập không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (matKhau == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (email == "")
            {
                MessageBox.Show("Email không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Regex regexSDT = new Regex(@"^0\d{9,10}$"); // Chỉ nhận số, dài 10-11 số
            Regex regexEmail = new Regex(@"^[\w.-]+@[\w.-]+\.[a-zA-Z]{2,6}$"); // Định dạng email
            Regex regexNoSpace = new Regex(@"^\S+$"); // Không chứa khoảng trắng
            if (!regexSDT.IsMatch(soDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!regexEmail.IsMatch(email))
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!regexNoSpace.IsMatch(maNguoiDung))
            {
                MessageBox.Show("Mã người dùng không được chứa khoảng trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!regexNoSpace.IsMatch(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập không được chứa khoảng trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(checkTrungTenDangNhap(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String trangThai = cbbTrangThai.Text;
            if (trangThai == "Hoạt động" || cbbTrangThai.SelectedIndex == -1)
            {
                trangThai = "1";
            }
            else if (trangThai == "Khóa")
            {
                trangThai = "0";
            }
            else
            {
                trangThai = "2";
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sqlND = "UPDATE NguoiDung SET TenNguoiDung = N'" + tenNguoiDung + "', MaVaiTro = '" + maVaiTro + "', SoDienThoai = '" + soDienThoai + "', TenNguoiDung = '" + tenDangNhap + "', NgaySinh = '" + ngaySinh + "', GioiTinh = N'" + gioiTinh + "', DiaChi = N'" + diaChi + "' WHERE MaNguoiDung = '" + maNguoiDung + "'";
            SqlCommand cmdND = new SqlCommand(sqlND, con);
            cmdND.ExecuteNonQuery();
            cmdND.Dispose();
            string sqlTK = "UPDATE TaiKhoan SET TenDangNhap = '" + tenDangNhap + "', MatKhau = '" + matKhau + "', Email = '" + email + "', TrangThai = '" + trangThai + "' WHERE MaTaiKhoan = 'MTK" + maNguoiDung + "'";
            SqlCommand cmdTK = new SqlCommand(sqlTK, con);
            cmdTK.ExecuteNonQuery();
            cmdTK.Dispose();
            con.Close();

            loadNguoiDung();

            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            String maNguoiDung = txtMaND.Text;
            String maTaiKhoan = "MTK" + maNguoiDung;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sqlND = "DELETE FROM NguoiDung WHERE MaNguoiDung = '" + maNguoiDung + "'";
            SqlCommand cmdND = new SqlCommand(sqlND, con);
            cmdND.ExecuteNonQuery();
            cmdND.Dispose();
            String sqlTK = "DELETE FROM TaiKhoan WHERE MaTaiKhoan = '" + maTaiKhoan + "'";
            SqlCommand cmdTK = new SqlCommand(sqlTK, con);
            cmdTK.ExecuteNonQuery();
            cmdTK.Dispose();
            con.Close();
            loadNguoiDung();

            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }
        public bool checkTrungTenDangNhap(String tenDangNhap)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from TaiKhoan where TenDangNhap = '" + tenDangNhap + "'";
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
        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            if(txtTenDangNhap.Text == "")
            {
                txtTB.Text = "";
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String tenDangNhap = txtTenDangNhap.Text;
            String sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap = '" + tenDangNhap + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtTB.Text = "❌ Tên đăng nhập đã tồn tại";
                txtTB.ForeColor = Color.Red;
            }
            else
            {
                txtTB.Text = "💚 Tên đăng nhập hợp lệ";
                txtTB.ForeColor = Color.Green;
            }
            dr.Close();
        }
    }
}
