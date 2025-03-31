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
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            cbbTenNhaCungCap.DataSource = tb;
            cbbTenNhaCungCap.DisplayMember = "TenNhaCungCap";
            cbbTenNhaCungCap.ValueMember = "MaNhaCungCap";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }

        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            String maSP = txtMaSP.Text;
            String tenSP = txtTenSP.Text;
            String maDanhMuc = cbbTenDanhMuc.SelectedValue.ToString();
            String gia = txtGia.Text;
            String soLuong = txtSoLuong.Text;
            String moTa = txtMoTa.Text;
            String maNhaCungCap = cbbTenNhaCungCap.SelectedValue.ToString();
            if (maSP == null)
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
            if (tenSP == null)
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gia == null)
            {
                MessageBox.Show("Vui lòng nhập giá sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (soLuong == null)
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
            if (moTa == null)
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
            // Đường dẫn lưu ảnh trong project
            string thuMucAnh = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imageSP");
            string tenTepAnh = Guid.NewGuid().ToString() + ".jpg";
            string duongDanTep = Path.Combine(thuMucAnh, tenTepAnh);

            // Lưu ảnh vào thư mục
            pictureBox1.Image.Save(duongDanTep, ImageFormat.Jpeg);
            // Lưu đường dẫn tương đối vào CSDL
            string duongDanTuongDoi = Path.Combine("imageSP", tenTepAnh);
            String ngayTao = dtNgayTao.Value.ToString("yyyy-MM-dd");
            // Mở kết nối CSDL nếu đang đóng
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "INSERT INTO SanPham VALUES('"+maSP+"', '"+tenSP+"', '"+maDanhMuc+"', '"+gia+"', '"+moTa+"', '"+duongDanTuongDoi+"', '"+ngayTao+"', '"+maNhaCungCap+"', '"+so+"')";




        }
    }
}
