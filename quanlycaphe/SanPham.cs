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

namespace quanlycaphe
{
    public partial class SanPham : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=quanlycafe;Integrated Security=True");

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
        }
        public void clear()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGia.Text = "";
            txtMoTa.Text = "";
            txtSoLuong.Text = "";
            pictureBox1.Image = null;
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
            openFileDialog.Filter = "Image Files|*.jpg;*.png;*.bmp";
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
            string sql = "INSERT INTO SanPham VALUES('"+maSP+"', '"+tenSP+"', '"+maDanhMuc+"', '"+gia+"', '"+moTa+"', '"+duongDanTuongDoi+"', '"+ngayTao+"', '"+maNhaCungCap+"', '"+soLuong+"')";
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
            String sql = "UPDATE SanPham SET TenSanPham = '" + tenSP + "', MaDanhMuc = '" + maDanhMuc + "', Gia = '" + gia + "', MoTa = N'" + moTa + "', HinhAnh = '" + duongDanTuongDoi + "', NgayTao = '" + ngayTao + "', MaNhaCungCap = '" + maNhaCungCap + "', SoLuong = '" + soLuong + "' WHERE MaSanPham = '" + maSP + "'";
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
    }
}
