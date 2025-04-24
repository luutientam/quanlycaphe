using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using xls = Microsoft.Office.Interop.Excel;


namespace quanlycaphe
{
    public partial class SanPham : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True");
        private Image originalImage;
        public SanPham()
        {
            InitializeComponent();
            loadcbbDanhMuc();
            loadcbbNhaCungCap();
            loadSanPham();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonLuu.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
            buttonThemMoi.Enabled = true;
            dtNgayTao.Enabled = false;
            originalImage = pictureBox1.Image;

        }
        public void clear()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGia.Text = "";
            txtMoTa.Text = "";
            txtSoLuong.Text = "";
            pictureBox1.Image = originalImage;
            txtDuongDanCU.Text = null;
            txtDuongDanMOI.Text = null;
            cbbTenDanhMuc.SelectedIndex = 0;
            cbbTenNhaCungCap.SelectedIndex = 0;
            dtNgayTao.Value = DateTime.Now;
        }
        public void disableTextBox()
        {
            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtGia.Enabled = false;
            txtMoTa.Enabled = false;
            txtSoLuong.Enabled = false;
            pictureBox1.Enabled = false;
            cbbTenDanhMuc.Enabled = false;
            cbbTenNhaCungCap.Enabled = false;
            dtNgayTao.Enabled = false;
        }
        public void enableTextBox()
        {
            txtMaSP.Enabled = true;
            txtTenSP.Enabled = true;
            txtGia.Enabled = true;
            txtMoTa.Enabled = true;
            txtSoLuong.Enabled = true;
            pictureBox1.Enabled = true;
            cbbTenDanhMuc.Enabled = true;
            cbbTenNhaCungCap.Enabled = true;
            dtNgayTao.Enabled = true;
        }
        public void loadSanPham()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string sql = "SELECT sp.MaSanPham, sp.TenSanPham, m.TenDanhMuc, sp.Gia, sp.MoTa, sp.HinhAnh, sp.NgayTao, ncc.TenNhaCungCap, sp.SoLuong FROM SanPham sp join DanhMuc m on sp.MaDanhMuc = m.MaDanhMuc join NhaCungCap ncc on ncc.MaNhaCungCap = sp.MaNhaCungCap";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();

            // Thêm cột ảnh vào DataTable nếu chưa có
            if (!tb.Columns.Contains("AnhSanPham"))
            {
                tb.Columns.Add("AnhSanPham", typeof(byte[])); // Cột chứa ảnh dạng byte[]
            }

            // Duyệt từng dòng để chuyển đường dẫn ảnh thành ảnh thực tế
            foreach (DataRow row in tb.Rows)
            {
                string duongDanAnh = row["HinhAnh"].ToString(); // Lấy đường dẫn ảnh từ CSDL
                string duongDanDayDu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, duongDanAnh);

                if (File.Exists(duongDanDayDu))
                {
                    Image anh = Image.FromFile(duongDanDayDu);
                    row["AnhSanPham"] = ImageToByteArray(anh); // Chuyển ảnh thành mảng byte[]
                }
            }

            dgvSanPham.DataSource = tb;
            dgvSanPham.Refresh();

            // Chỉnh sửa DataGridView để hiển thị ảnh
            if (!dgvSanPham.Columns.Contains("AnhSanPham"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "AnhSanPham";
                imgColumn.HeaderText = "Ảnh Sản Phẩm";
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvSanPham.Columns.Add(imgColumn);
            }
        }

        // Hàm chuyển Image thành byte[]
        public byte[] ImageToByteArray(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
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
            DataTable tb = new DataTable();
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

            cbbDanhMuc_TK.DataSource = tb;
            cbbDanhMuc_TK.DisplayMember = "TenDanhMuc";
            cbbDanhMuc_TK.ValueMember = "MaDanhMuc";
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
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            DataRow r =tb.NewRow();
            r["MaNhaCungCap"] = "";
            r["TenNhaCungCap"] = "--- Chọn nhà cung cấp ---";
            tb.Rows.InsertAt(r, 0);

            cbbTenNhaCungCap.DataSource = tb;
            cbbTenNhaCungCap.DisplayMember = "TenNhaCungCap";
            cbbTenNhaCungCap.ValueMember = "MaNhaCungCap";

            cbbNhaCungCap_TK.DataSource = tb;
            cbbNhaCungCap_TK.DisplayMember = "TenNhaCungCap";
            cbbNhaCungCap_TK.ValueMember = "MaNhaCungCap";
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
            if(checkTrungMaSanPham(maSP))
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
            Regex regexGia = new Regex(@"^\d+$");
            if (!regexGia.IsMatch(gia))
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
            if (MessageBox.Show("Bạn có chắc chắn muốn thêm sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            // Mở kết nối CSDL nếu đang đóng
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "INSERT INTO SanPham VALUES('"+maSP+"', N'"+tenSP+"', '"+maDanhMuc+"', '"+gia+"', N'"+moTa+"', '"+duongDanTuongDoi+"', '"+ngayTao+"', '"+maNhaCungCap+"', '"+soLuong+"')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            loadSanPham();
            MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);
            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
            buttonThemMoi.Enabled = true;
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String maSP = txtMaSP_TK.Text;
            String tenSP = txtTenSP_TK.Text;
            String maDanhMuc = cbbDanhMuc_TK.SelectedValue.ToString();
            String txtgia1 = txtGia1_TK.Text;
            String txtgia2 = txtGia2_TK.Text;
            decimal gia1=0;
            if (txtgia1 != "")
            {
                gia1 = Convert.ToDecimal(txtgia1);
            }
            decimal gia2=0;
            if (txtgia2 != "")
            {
                gia2 = Convert.ToDecimal(txtgia2);
            }
            //String soLuong = txtSoLuong_TK.Text;
            String Ncc = cbbNhaCungCap_TK.SelectedValue.ToString();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT sp.MaSanPham, sp.TenSanPham, m.TenDanhMuc, sp.Gia, sp.MoTa, sp.HinhAnh, sp.NgayTao, ncc.TenNhaCungCap, sp.SoLuong FROM SanPham sp join DanhMuc m on sp.MaDanhMuc = m.MaDanhMuc join NhaCungCap ncc on ncc.MaNhaCungCap = sp.MaNhaCungCap WHERE sp.MaSanPham like '%" + maSP + "%' and sp.TenSanPham like N'%" + tenSP + "%' and m.MaDanhMuc like '%" + maDanhMuc + "%' and ncc.MaNhaCungCap like '%" + Ncc + "%'";
            if (gia1 == 0 && gia2 == 0)
            {
                sql += "";
            }
            else if (gia1 != 0 && gia2 == 0)
            {
                sql += " and sp.Gia >= " + gia1;
            }
            else if (gia1 == 0 && gia2 != 0)
            {
                sql += " and sp.Gia <= "+ gia2;
            }
            else
            {
                sql += " and sp.Gia BETWEEN '" + gia1 + "' and '" + gia2 + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            // Thêm cột ảnh vào DataTable nếu chưa có
            if (!tb.Columns.Contains("AnhSanPham"))
            {
                tb.Columns.Add("AnhSanPham", typeof(byte[])); // Cột chứa ảnh dạng byte[]
            }

            // Duyệt từng dòng để chuyển đường dẫn ảnh thành ảnh thực tế
            foreach (DataRow row in tb.Rows)
            {
                string duongDanAnh = row["HinhAnh"].ToString(); // Lấy đường dẫn ảnh từ CSDL
                string duongDanDayDu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, duongDanAnh);

                if (File.Exists(duongDanDayDu))
                {
                    Image anh = Image.FromFile(duongDanDayDu);
                    row["AnhSanPham"] = ImageToByteArray(anh); // Chuyển ảnh thành mảng byte[]
                }
            }

            dgvSanPham.DataSource = tb;
            dgvSanPham.Refresh();

            // Chỉnh sửa DataGridView để hiển thị ảnh
            if (!dgvSanPham.Columns.Contains("AnhSanPham"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "AnhSanPham";
                imgColumn.HeaderText = "Ảnh Sản Phẩm";
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvSanPham.Columns.Add(imgColumn);
            }


        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)e.RowIndex;
            if (i >= 0)
            {
                txtMaSP.Text = dgvSanPham.Rows[i].Cells[0].Value.ToString();
                txtTenSP.Text = dgvSanPham.Rows[i].Cells[1].Value.ToString();
                cbbTenDanhMuc.Text = dgvSanPham.Rows[i].Cells[2].Value.ToString();
                txtGia.Text = dgvSanPham.Rows[i].Cells[3].Value.ToString();
                txtMoTa.Text = dgvSanPham.Rows[i].Cells[4].Value.ToString();
                
                string duongDanAnh = dgvSanPham.Rows[i].Cells[5].Value.ToString();
                string duongDanDayDu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, duongDanAnh);
                if (File.Exists(duongDanDayDu))
                {
                    pictureBox1.Image = Image.FromFile(duongDanDayDu);
                    txtDuongDanCU.Text = duongDanAnh;
                }
                cbbTenNhaCungCap.Text = dgvSanPham.Rows[i].Cells[7].Value.ToString();
                dtNgayTao.Value = Convert.ToDateTime(dgvSanPham.Rows[i].Cells[6].Value.ToString());
                txtSoLuong.Text = dgvSanPham.Rows[i].Cells[8].Value.ToString();
            }
            
            enableTextBox();
            txtMaSP.Enabled = false;
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = true;
            buttonXoa.Enabled = true;
            buttonHuyThaoTac.Enabled = true;
            buttonThemMoi.Enabled = false;
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
            if(MessageBox.Show("Bạn có chắc chắn muốn cập nhật sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            // Mở kết nối CSDL nếu đang đóng
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "UPDATE SanPham SET TenSanPham = N'" + tenSP + "', MaDanhMuc = '" + maDanhMuc + "', Gia = '" + gia + "', MoTa = N'" + moTa + "', HinhAnh = '" + duongDanTuongDoi + "', NgayTao = '" + ngayTao + "', MaNhaCungCap = '" + maNhaCungCap + "', SoLuong = '" + soLuong + "' WHERE MaSanPham = '" + maSP + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            loadSanPham();
            MessageBox.Show("Cập nhật sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);
            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
            buttonThemMoi.Enabled = true;

        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            String maSP = txtMaSP.Text;
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
            loadSanPham();
            MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);
            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
            buttonThemMoi.Enabled = true;
        }

        private void buttonHuyThaoTac_Click(object sender, EventArgs e)
        {
            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
            buttonThemMoi.Enabled = true;
        }

        private void buttonThemMoi_Click(object sender, EventArgs e)
        {
            enableTextBox();
            clear();
            buttonLuu.Enabled = true;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = true;
            buttonThemMoi.Enabled = false;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtGialon_TextChanged(object sender, EventArgs e)
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
            head.Value2 = "THỐNG KÊ THÔNG TIN VỀ SẢN PHẨM";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            xls.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 6.0;
            xls.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ SẢN PHẨM";
            cl2.ColumnWidth = 16.0;


            xls.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "TÊN SẢN PHẨM";
            cl3.ColumnWidth = 18.0;
            xls.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "TÊN DANH MỤC";
            cl4.ColumnWidth = 20.0;
            xls.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "GIÁ";
            cl5.ColumnWidth = 15.0;
            xls.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "MÔ TẢ";
            cl6.ColumnWidth = 15.0;
            //xls.Range cl6_1 = oSheet.get_Range("F4", "F1000");
            //cl6_1.Columns.NumberFormat = "dd/mm/yyyy";


            xls.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "HÌNH ẢNH";
            cl7.ColumnWidth = 18.0;

            xls.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "NGÀY TẠO";
            cl8.ColumnWidth = 20.0;

            xls.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "TÊN NHÀ CUNG CẤP";
            cl9.ColumnWidth = 35.0;

            xls.Range cl10 = oSheet.get_Range("J3", "J3");
            cl10.Value2 = "SỐ LƯỢNG";
            cl10.ColumnWidth = 20.0;

            //xls.Range cl11 = oSheet.get_Range("L3", "L3");
            //cl11.Value2 = "NGÀY TẠO";
            //cl11.ColumnWidth = 13.0;

            //xls.Range cl12 = oSheet.get_Range("M3", "M3");
            //cl12.Value2 = "TRẠNG THÁI";
            //cl12.ColumnWidth = 15.0;

            //xls.Range cl8 = oSheet.get_Range("H3", "H3");
            //cl8.Value2 = "GHI CHÚ";
            //cl8.ColumnWidth = 15.0;
            xls.Range rowHead = oSheet.get_Range("A3", "J3");
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
                    if (c == 8) // Cột ngày sinh (E) - chú ý: chỉ số mảng bắt đầu từ 0
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
            xls.Range dateColumn = oSheet.Range[oSheet.Cells[rowStart, 8], oSheet.Cells[rowEnd, 8]];
            dateColumn.NumberFormat = "dd/mm/yyyy";

            // Kẻ viền
            range.Borders.LineStyle = xls.Constants.xlSolid;
            // Căn giữa cột STT
            xls.Range c3 = (xls.Range)oSheet.Cells[rowEnd, columnStart];
            xls.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String maSP = txtMaSP_TK.Text;
            String tenSP = txtTenSP_TK.Text;
            String maDanhMuc = cbbDanhMuc_TK.SelectedValue.ToString();
            String txtgia1 = txtGia1_TK.Text;
            String txtgia2 = txtGia2_TK.Text;
            decimal gia1 = 0;
            if (txtgia1 != "")
            {
                gia1 = Convert.ToDecimal(txtgia1);
            }
            decimal gia2 = 0;
            if (txtgia2 != "")
            {
                gia2 = Convert.ToDecimal(txtgia2);
            }
            //String soLuong = txtSoLuong_TK.Text;
            String Ncc = cbbNhaCungCap_TK.SelectedValue.ToString();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT sp.MaSanPham, sp.TenSanPham, m.TenDanhMuc, sp.Gia, sp.MoTa, sp.HinhAnh, sp.NgayTao, ncc.TenNhaCungCap, sp.SoLuong FROM SanPham sp join DanhMuc m on sp.MaDanhMuc = m.MaDanhMuc join NhaCungCap ncc on ncc.MaNhaCungCap = sp.MaNhaCungCap WHERE sp.MaSanPham like '%" + maSP + "%' and sp.TenSanPham like N'%" + tenSP + "%' and m.MaDanhMuc like '%" + maDanhMuc + "%' and ncc.MaNhaCungCap like '%" + Ncc + "%'";
            if (gia1 == 0 && gia2 == 0)
            {
                sql += "";
            }
            else if (gia1 != 0 && gia2 == 0)
            {
                sql += " and sp.Gia >= " + gia1;
            }
            else if (gia1 == 0 && gia2 != 0)
            {
                sql += " and sp.Gia <= " + gia2;
            }
            else
            {
                sql += " and sp.Gia BETWEEN '" + gia1 + "' and '" + gia2 + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            ExportExcel(tb, "Danh sách sản phẩm");
        }
        public void ThemSanPham(String maSP, String tenSP, String maDanhMuc, decimal gia, String moTa, String maNhaCungCap, int soLuong)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string hinhanh = "chưa có";
            string ngayTao = DateTime.Now.ToString("yyyy-MM-dd");
            //String ngaySinhSql = ngaySinh.ToString("yyyy-MM-dd");
            String sql = "insert SanPham values('" + maSP + "', N'" + tenSP + "', '" + maDanhMuc + "', '" + gia + "', N'" + moTa + "', N'"+hinhanh+"', '"+ngayTao+"', '"+maNhaCungCap+"', '"+soLuong+"')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void ReadExcel(String filename)
        {
            //kiểm tra xem filename đã có dữ liệu chưa
            if (filename == null)
            {
                MessageBox.Show("Chưa chọn file");
            }
            else
            {
                xls.Application Excel = new xls.Application();// tạp một app làm việc mới
                                                              // mở dữ liệu từ file
                Excel.Workbooks.Open(filename);
                //đọc dữ liệu từng sheet của excel
                foreach (xls.Worksheet wsheet in Excel.Worksheets)
                {
                    int i = 2;  //để đọc từng dòng của sheet bắt đầu từ dòng số 2
                    do
                    {
                        if (wsheet.Cells[i, 1].Value == null && wsheet.Cells[i, 2].Value == null && wsheet.Cells[i, 3].Value == null)
                        {
                            break;
                        }
                        else
                        {
                            /// Đọc dữ liệu từ Excel
                            string maSP = wsheet.Cells[i, 1].Value?.ToString();
                            string tenSP = wsheet.Cells[i, 2].Value?.ToString();
                            string maDanhMuc = wsheet.Cells[i, 3].Value?.ToString();
                            string giaxc = wsheet.Cells[i, 4].Value?.ToString();
                            string moTa = wsheet.Cells[i, 5].Value?.ToString();
                            string maNhaCungCap = wsheet.Cells[i, 6].Value?.ToString();
                            string soLuongxc = wsheet.Cells[i, 7].Value?.ToString();

                            decimal gia = Convert.ToDecimal(giaxc);
                            int soLuong = Convert.ToInt32(soLuongxc);
                            if (checkTrungMaSanPham(maSP))
                            {
                                MessageBox.Show("Trùng mã sản phẩm -> " + maSP + " <- !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                i++;
                                continue;
                            }
                            //// Xử lý ngày sinh
                            //DateTime ngaySinh;
                            //if (!DateTime.TryParse(wsheet.Cells[i, 4].Value?.ToString(), out ngaySinh))
                            //{
                            //    ngaySinh = DateTime.MinValue; // Gán giá trị mặc định nếu lỗi
                            //}

                            // Gọi phương thức ThemDocGia với dữ liệu đã được ép kiểu đúng
                            ThemSanPham(maSP, tenSP, maDanhMuc, gia, moTa, maNhaCungCap, soLuong);
                            i++;
                        }
                    }
                    while (true);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //txtDuongDan.Text = openFileDialog.FileName;
                ReadExcel(openFileDialog.FileName);
                loadSanPham();
            }
        }

        private void SanPham_Load(object sender, EventArgs e)
        {

        }
    }
}
