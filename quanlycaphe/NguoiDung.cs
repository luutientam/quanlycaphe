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
using xls = Microsoft.Office.Interop.Excel;

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
            DataRow r = tb.NewRow();
            r["MaVaiTro"] = "";
            r["TenVaiTro"] = "--- Chọn vai trò ---";
            tb.Rows.InsertAt(r, 0);

            cbbVaiTro.DataSource = tb;
            cbbVaiTro.DisplayMember = "TenVaiTro";
            cbbVaiTro.ValueMember = "MaVaiTro";

            cbbVaiTro_TK.DataSource = tb;
            cbbVaiTro_TK.DisplayMember = "TenVaiTro";
            cbbVaiTro_TK.ValueMember = "MaVaiTro";
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
            cbbTrangThai.Text = dgvNguoiDung.Rows[i].Cells[11].Value.ToString();
           
            enableTextBox();
            txtTB.Text = "";
            txtTenDangNhap.Enabled = false;
            
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
            if (cbbTrangThai.SelectedIndex == -1)
            {
                trangThai = "Hoạt động";
            }
            if(MessageBox.Show("Bạn có chắc chắn muốn thêm mới người dùng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
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
            //if(checkTrungTenDangNhap(tenDangNhap))
            //{
            //    MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            String trangThai = cbbTrangThai.Text;
            if (cbbTrangThai.SelectedIndex == -1)
            {
                trangThai = "Hoạt động";
            }
            if(MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin người dùng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sqlND = "UPDATE NguoiDung SET TenNguoiDung = N'" + tenNguoiDung + "', MaVaiTro = '" + maVaiTro + "', SoDienThoai = '" + soDienThoai + "', NgaySinh = '" + ngaySinh + "', GioiTinh = N'" + gioiTinh + "', DiaChi = N'" + diaChi + "' WHERE MaNguoiDung = '" + maNguoiDung + "'";
            SqlCommand cmdND = new SqlCommand(sqlND, con);
            cmdND.ExecuteNonQuery();
            cmdND.Dispose();
            string sqlTK = "UPDATE TaiKhoan SET TenDangNhap = '" + tenDangNhap + "', MatKhau = '" + matKhau + "', Email = '" + email + "', TrangThai = N'" + trangThai + "' WHERE MaTaiKhoan = 'MTK" + maNguoiDung + "'";
            SqlCommand cmdTK = new SqlCommand(sqlTK, con);
            cmdTK.ExecuteNonQuery();
            cmdTK.Dispose();
            con.Close();

            loadNguoiDung();
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
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
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String tenNguoiDung = txtTenNguoiDung_TK.Text;
            String vaiTro = cbbVaiTro_TK.SelectedValue.ToString();
            String gioiTinh = cbbGioiTinh_TK.Text;
            String tenDangNhap = txtTenDangNhap_TK.Text;
            String trangThai = cbbTrangThai_TK.Text;
            String diaChi = txtDiaChi_TK.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if(cbbGioiTinh_TK.SelectedIndex == -1 || gioiTinh == "-- Chọn giới tính --")
            {
                gioiTinh = "";
            }
            if(cbbTrangThai_TK.SelectedIndex == -1 || trangThai == "-- Chọn trạng thái --")
            {
                trangThai = "";
            }
            string sql = "select N.MaNguoiDung, N.TenNguoiDung, V.TenVaiTro, N.SoDienThoai, N.NgaySinh, N.GioiTinh, " +
             "N.DiaChi, T.TenDangNhap, T.MatKhau, T.Email, T.NgayTao, T.TrangThai " +
             "from NguoiDung N " +
             "join TaiKhoan T on N.MaTaiKhoan = T.MaTaiKhoan " +
             "join VaiTro V on N.MaVaiTro = V.MaVaiTro " +
             "where N.TenNguoiDung like N'%" + tenNguoiDung + "%' " +
             "and T.tenDangNhap like '%" + tenDangNhap + "%' " +
             "and N.GioiTinh like N'%" + gioiTinh + "%' " +
             "and N.DiaChi like N'%" + diaChi + "%' " +
             "and T.TrangThai like N'%" + trangThai + "%' " +
             "and V.MaVaiTro like '%" + vaiTro + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            dgvNguoiDung.DataSource = tb;
            dgvNguoiDung.Refresh();


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void ExportExcel(DataTable tb, string sheetname)
        {
            //Tạo các đối tượng Excel

            xls.Application oExcel = new xls.Application();
            xls.Workbooks oBooks;
            xls.Sheets oSheets;
            xls.Workbook oBook;
            xls.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (xls.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (xls.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetname;
            // Tạo phần đầu nếu muốn
            xls.Range head = oSheet.get_Range("A1", "G1");
            head.MergeCells = true;
            head.Value2 = "THỐNG KÊ THÔNG TIN VỀ NGƯỜI DÙNG";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            xls.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 6.0;
            xls.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ NGƯỜI DÙNG";
            cl2.ColumnWidth = 16.0;

            xls.Range cl02 = oSheet.get_Range("C3", "C3");
            cl02.Value2 = "Tên NGƯỜI DÙNG";
            cl02.ColumnWidth = 20.0;

            xls.Range cl3 = oSheet.get_Range("D3", "D3");
            cl3.Value2 = "VAI TRÒ";
            cl3.ColumnWidth = 15.0;
            xls.Range cl4 = oSheet.get_Range("E3", "E3");
            cl4.Value2 = "SỐ ĐIỆN THOẠI";
            cl4.ColumnWidth = 15.0;
            xls.Range cl5 = oSheet.get_Range("F3", "F3");
            cl5.Value2 = "NGÀY SINH";
            cl5.ColumnWidth = 12.0;
            xls.Range cl6 = oSheet.get_Range("G3", "G3");
            cl6.Value2 = "GIỚI TÍNH";
            cl6.ColumnWidth = 14.0;
            //xls.Range cl6_1 = oSheet.get_Range("F4", "F1000");
            //cl6_1.Columns.NumberFormat = "dd/mm/yyyy";


            xls.Range cl7 = oSheet.get_Range("H3", "H3");
            cl7.Value2 = "ĐỊA CHỈ";
            cl7.ColumnWidth = 30;

            xls.Range cl8 = oSheet.get_Range("I3", "I3");
            cl8.Value2 = "TÊN ĐĂNG NHẬP";
            cl8.ColumnWidth = 20.0;

            xls.Range cl9 = oSheet.get_Range("J3", "J3");
            cl9.Value2 = "MẬT KHẨU";
            cl9.ColumnWidth = 15.0;

            xls.Range cl10 = oSheet.get_Range("K3", "K3");
            cl10.Value2 = "EMAIL";
            cl10.ColumnWidth = 30.0;

            xls.Range cl11 = oSheet.get_Range("L3", "L3");
            cl11.Value2 = "NGÀY TẠO";
            cl11.ColumnWidth = 13.0;

            xls.Range cl12 = oSheet.get_Range("M3", "M3");
            cl12.Value2 = "TRẠNG THÁI";
            cl12.ColumnWidth = 15.0;

            //xls.Range cl8 = oSheet.get_Range("H3", "H3");
            //cl8.Value2 = "GHI CHÚ";
            //cl8.ColumnWidth = 15.0;
            xls.Range rowHead = oSheet.get_Range("A3", "M3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = xls.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 44;
            rowHead.HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // Tạo mảng đối tượng để lưu toàn bộ dữ liệu trong DataTable
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count + 1]; // Thêm 1 cột cho STT

            // Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                arr[r, 0] = r + 1; // STT ở cột đầu tiên (A)
                DataRow dr = tb.Rows[r];

                for (int c = 0; c < tb.Columns.Count; c++)
                {
                    if (c == 6 || c == 12) // Cột ngày sinh (E) - chú ý: chỉ số mảng bắt đầu từ 0
                    {
                        DateTime tempDate;
                        if (DateTime.TryParse(dr[c].ToString(), out tempDate))
                        {
                            arr[r, c + 1] = tempDate.ToOADate(); // Chuyển thành kiểu số của Excel
                        }
                        else
                        {
                            arr[r, c + 1] = dr[c].ToString(); // Nếu không phải ngày hợp lệ, giữ nguyên
                        }
                    }
                    else if (c == 3) // Cột số điện thoại
                    {
                        arr[r, c + 1] = "'" + dr[c].ToString();
                    }

                    else
                    {
                        arr[r, c + 1] = dr[c]; // Dịch cột sang phải một đơn vị
                    }
                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count + 1;
            // Ô bắt đầu điền dữ liệu
            xls.Range c1 = (xls.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            xls.Range c2 = (xls.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            xls.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            // Định dạng lại cột ngày sinh (E)
            xls.Range dateColumn = oSheet.Range[oSheet.Cells[rowStart, 6], oSheet.Cells[rowEnd, 6]];
            dateColumn.NumberFormat = "dd/mm/yyyy";

            // Định dạng lại cột ngày sinh (K)
            xls.Range dateColumn2 = oSheet.Range[oSheet.Cells[rowStart, 12], oSheet.Cells[rowEnd, 12]];
            dateColumn2.NumberFormat = "dd/mm/yyyy";
            // Kẻ viền
            range.Borders.LineStyle = xls.Constants.xlSolid;
            // Căn giữa cột STT
            xls.Range c3 = (xls.Range)oSheet.Cells[rowEnd, columnStart];
            xls.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String tenNguoiDung = txtTenNguoiDung_TK.Text;
            String vaiTro = cbbVaiTro_TK.SelectedValue.ToString();
            String gioiTinh = cbbGioiTinh_TK.Text;
            String tenDangNhap = txtTenDangNhap_TK.Text;
            String trangThai = cbbTrangThai_TK.Text;
            String diaChi = txtDiaChi_TK.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (cbbGioiTinh_TK.SelectedIndex == -1 || gioiTinh == "-- Chọn giới tính --")
            {
                gioiTinh = "";
            }
            if (cbbTrangThai_TK.SelectedIndex == -1 || trangThai == "-- Chọn trạng thái --")
            {
                trangThai = "";
            }
            string sql = "select N.MaNguoiDung, N.TenNguoiDung, V.TenVaiTro, N.SoDienThoai, N.NgaySinh, N.GioiTinh, " +
             "N.DiaChi, T.TenDangNhap, T.MatKhau, T.Email, T.NgayTao, T.TrangThai " +
             "from NguoiDung N " +
             "join TaiKhoan T on N.MaTaiKhoan = T.MaTaiKhoan " +
             "join VaiTro V on N.MaVaiTro = V.MaVaiTro " +
             "where N.TenNguoiDung like N'%" + tenNguoiDung + "%' " +
             "and T.tenDangNhap like '%" + tenDangNhap + "%' " +
             "and N.GioiTinh like N'%" + gioiTinh + "%' " +
             "and N.DiaChi like N'%" + diaChi + "%' " +
             "and T.TrangThai like N'%" + trangThai + "%' " +
             "and V.MaVaiTro like '%" + vaiTro + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            ExportExcel(tb, "Danh sách người dùng");
        }
    }
}
