using DocumentFormat.OpenXml.VariantTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace quanlycaphe
{
    public partial class TongQuan : Form
    {
        ketnoicuadiem ketnoi = new ketnoicuadiem();
        private DateTimePicker dtpNgay = new DateTimePicker();
        
        public TongQuan()
        {
            InitializeComponent();
            dtpNgay.Location = new Point(10, 10);
            this.Controls.Add(dtpNgay);
            try
            {
                ketnoi.Open();
                ketnoi.Close();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu. Vui lòng kiểm tra lại:" + ex.Message);
            }
            Load_tk();
            TongQuan_Load();
        }

        private void trangchu_Click(object sender, EventArgs e)
        {
            FormChinh f = new FormChinh();
            f.ShowDialog();
            this.Hide();
        }
        //khoi tao du lieu ban dau
        private void TongQuan_Load()
        {
            DateTime today = DateTime.Today;
            dtngaydau.Value = today;
            dtngaycuoi.Value = today;
            LoadData(today, today.AddHours(23).AddMinutes(59).AddSeconds(59));
            LoadDataTatCa();
        }
        private void btngay_Click(object sender, EventArgs e)
        {
            //DateTime selectedDate = dtngaydau.Value.Date;
            DateTime fromDate = dtngaydau.Value.Date;
            DateTime toDate = dtngaydau.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            if (fromDate > toDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //LoadData(selectedDate, selectedDate);
           LoadData(fromDate, toDate);
            
        }
        //Ham lay du lieu tu sql
        private void LoadData(DateTime fromDate, DateTime toDate)
        {
            fromDate = fromDate.Date; // 00:00:00
            toDate = toDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59); // 23:59:59

            ketnoi.Open();
            string sql = @"SELECT SUM(dh.TongTien) as TongDoanhSo,
            COUNT(DISTINCT dh.MaDonHang) as SoLuongDonHang,
            SUM(CASE WHEN dh.TrangThai != N'Đã hủy' THEN ct.SoLuong * (sp.Gia - ISNULL(sp.GiaNhap, 0)) ELSE 0 END) AS TongLoiNhuan,
            count (Distinct case when dh.TrangThai = N'Đã hủy' then dh.MaDonHang end) as SoDonHangHuy,
            sum (case when sp.MaKhuyenMai is not null and dh.TrangThai != N'Đã hủy' then ct.SoLuong * ct.Gia * km.PhanTramGiam / 100 else 0 end) as TongKhuyenMai,
            AVG (case when dh.TrangThai != N'Đã hủy' then dh.TongTien end) as GiaTriTrungBinh 
            FROM DonHang dh JOIN ChiTietDonHang ct ON dh.MaDonHang = ct.MaDonHang
            JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
            LEFT JOIN KhuyenMai km on sp.MaKhuyenMai = km.MaKhuyenMai
            WHERE dh.NgayDat BETWEEN @fromDate AND @toDate";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
            cmd.Parameters.AddWithValue("@fromDate", fromDate);
            cmd.Parameters.AddWithValue("@toDate", toDate);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tbtongdoanhso.Text = reader["TongDoanhSo"].ToString();
                tbtongloinhuan.Text = reader["TongLoiNhuan"].ToString();
                tbtongdonhang.Text = reader["SoLuongDonHang"].ToString();
                tbdonhuy.Text = reader["SoDonHangHuy"].ToString();
                tbkhuyenmai.Text = reader["TongKhuyenMai"].ToString();
                tbgiatritb.Text = reader["GiaTriTrungBinh"].ToString();

            }
            else
            {
                tbtongdoanhso.Text = "0";
                tbtongloinhuan.Text = "0";
                tbtongdonhang.Text = "0";
                tbdonhuy.Text = "0";
                tbkhuyenmai.Text = "0";
                tbgiatritb.Text = "0";

            }
            reader.Close();
            ketnoi.Close();
        }
        private DataTable LayDuLieuTuSQL(DateTime fromDate, DateTime toDate)
        {
            ketnoi.Open();
            string sql = @"SELECT SUM(dh.TongTien) as TongDoanhSo,
            COUNT(DISTINCT dh.MaDonHang) as SoLuongDonHang,
            SUM(CASE WHEN dh.TrangThai != N'Ðã hủy' THEN ct.SoLuong * (sp.Gia - ISNULL(sp.GiaNhap, 0)) ELSE 0 END) AS TongLoiNhuan,
            COUNT (Distinct case when dh.TrangThai = N'Ðã hủy' then dh.MaDonHang end) as SoDonHangHuy,
            SUM (case when sp.MaKhuyenMai is not null and dh.TrangThai != N'Ðã hủy' then ct.SoLuong * ct.Gia * km.PhanTramGiam / 100 else 0 end) as TongKhuyenMai,
            AVG (case when dh.TrangThai != N'Ðã hủy' then dh.TongTien end) as GiaTriTrungBinh 
            FROM DonHang dh JOIN ChiTietDonHang ct ON dh.MaDonHang = ct.MaDonHang
            JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
            LEFT JOIN KhuyenMai km on sp.MaKhuyenMai = km.MaKhuyenMai
            WHERE dh.NgayDat BETWEEN @fromDate AND @toDate";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
            cmd.Parameters.AddWithValue("@fromDate", fromDate);
            cmd.Parameters.AddWithValue("@toDate", toDate);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.Close();
            return dt;
        }
        

        private void btweek_Click(object sender, EventArgs e)
        {
            DateTime todate = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
            DateTime fromdate = todate.AddDays(-7);

            //cap nhat datepicker
            dtngaydau.Value = fromdate;
            dtngaycuoi.Value = todate;

            LoadData(fromdate, todate);
           
        }

        private void btmonth_Click(object sender, EventArgs e)
        {
            DateTime todate = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
            DateTime fromdate = todate.AddDays(-30);

            //cap nhat datepicker
            dtngaydau.Value = fromdate;
            dtngaycuoi.Value = todate;

            LoadData(fromdate, todate);
          
        }

        private void bt90day_Click(object sender, EventArgs e)
        {
            DateTime todate = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
            DateTime fromdate = todate.AddDays(-90);

            //cap nhat datepicker
            dtngaydau.Value = fromdate;
            dtngaycuoi.Value = todate;

            LoadData(fromdate, todate);
          
        }
        private void Load_tk()
        {
            cbtk.Items.Clear();
            cbtk.Items.Add("Tất cả");
            cbtk.Items.Add("Sản Phẩm Hết");
            cbtk.Items.Add("Sản Phẩm Còn");
            cbtk.Items.Add("Sản Phẩm Bán Chạy");
            cbtk.Items.Add("Sản Phẩm Sắp Hết Hạn");
            cbtk.SelectedIndex = 0; // Chọn giá trị mặc định là "Tat ca"
        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            string timkiemthongtin = cbtk.SelectedItem.ToString();

            if (string.IsNullOrEmpty(timkiemthongtin))
            {
                MessageBox.Show("Vui lòng chọn loại tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (timkiemthongtin)
            {
                case "Tất cả":
                    LoadDataTatCa();
                    break;
                case "Sản Phẩm Hết":
                    LoadDataSanPhamHet();
                    break;
                case "Sản Phẩm Còn":
                    LoadDataSanPhamCon();
                    break;
                case "Sản Phẩm Bán Chạy":
                    LoadDataSanPhamBanChay();
                    break;
                case "Sản Phẩm Sắp Hết Hạn":
                    LoadDataSanPhamSapHetHan();
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn loại tìm kiếm.");
                    break;
            }

        }
        private void LoadDataTatCa()
        {
            string sql = "SELECT MaSanPham, TenSanPham, SoLuong, HanSuDung FROM SanPham ";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvthongtinkho.DataSource = dt;
        }
        private void LoadDataSanPhamHet()
        {
            string sql = "SELECT MaSanPham, TenSanPham, SoLuong, HanSuDung FROM SanPham WHERE SoLuong = 0";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvthongtinkho.DataSource = dt;
        }
        private void LoadDataSanPhamCon()
        {
            string sql = "SELECT MaSanPham, TenSanPham, SoLuong, HanSuDung FROM SanPham WHERE SoLuong > 0";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvthongtinkho.DataSource = dt;
        }
        private void LoadDataSanPhamBanChay()
        {
            string sql = "SELECT TOP 10 sp.MaSanPham, sp.TenSanPham, SUM(ct.SoLuong) as SoLuong, sp.HanSuDung FROM SanPham sp " +
                " JOIN ChiTietDonHang ct on sp.MaSanPham = ct.MaSanPham " +
                " JOIN DonHang dh on ct.MaDonHang = dh.MaDonHang " +
                " WHERE dh.TrangThai != N'Đã hủy'" +
                " GROUP BY sp.MaSanPham , sp.TenSanPham, sp.HanSuDung" +
                " ORDER BY SoLuong DESC";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvthongtinkho.DataSource = dt;
        }
        private void LoadDataSanPhamSapHetHan()
        {
            string sql = "SELECT MaSanPham, TenSanPham, SoLuong, HanSuDung FROM SanPham  WHERE HanSuDung IS NOT NULL AND HanSuDung <= DATEADD(day, 30, GETDATE()) AND SoLuong > 0";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
            cmd.Parameters.AddWithValue("@today", DateTime.Today);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvthongtinkho.DataSource = dt;
        }
        private void dgvthongtinkho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvthongtinkho.Rows[e.RowIndex];

            // Lấy giá trị của ô đầu tiên trong hàng đã chọn
            string masanpham = row.Cells["MaSanPham"].Value.ToString();
            string tensanpham = row.Cells["TenSanPham"].Value.ToString();
            string soluong = row.Cells["SoLuong"].Value.ToString();
            string hansudung = row.Cells["HanSuDung"].Value.ToString();
        }

        private void trogiup_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btxuatfile_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ DataGridView (chỉ xuất những dữ liệu đang hiển thị)
                System.Data.DataTable dt = dgvthongtinkho.DataSource as System.Data.DataTable;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                    return;
                }

                // Lấy tên file từ TextBox và thêm phần mở rộng .xlsx
                string fileName = txttenfile.Text.Trim();
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Vui lòng nhập tên file!", "Thông báo");
                    return;
                }
                // Đường dẫn thư mục cố định (điều chỉnh theo ý bạn)
                string folderPath = @"D:\excelcafe\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string filePath = Path.Combine(folderPath, fileName + ".xlsx");

                if (File.Exists(filePath))
                {
                    MessageBox.Show("File đã tồn tại. Vui lòng chọn tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Gọi hàm xuất file Excel với DataTable, tên sheet và filePath
                ExportExcel(dt, "DanhMuc", filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi");
            }
            finally
            {
                ketnoi.Close();
            }
        }
        // Hàm xuất Excel sử dụng ClosedXML
        public void ExportExcel(System.Data.DataTable tb, string sheetName, string filePath)
        {
            try
            {
                if (tb == null || tb.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo");
                    return;
                }

                // Sử dụng ClosedXML để tạo file Excel
                using (var workbook = new ClosedXML.Excel.XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(tb, sheetName);
                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(filePath);
                }

                // Mở file Excel sau khi lưu
                Process.Start(filePath);
                MessageBox.Show("Xuất file thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi");
            }
        }
    }
}
    
  
