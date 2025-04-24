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
            demSoLuong();
        }
        public void loadSanPham()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string sql = "SELECT sp.MaSanPham, sp.TenSanPham, m.TenDanhMuc, sp.Gia, sp.MoTa, sp.HinhAnh, sp.NgayTao, ncc.TenNhaCungCap, sp.SoLuong, sp.HanSuDung, sp.GiaNhap, km.MaKhuyenMai FROM SanPham sp join DanhMuc m on sp.MaDanhMuc = m.MaDanhMuc join NhaCungCap ncc on ncc.MaNhaCungCap = sp.MaNhaCungCap left join KhuyenMai km on km.MaKhuyenMai = sp.MaKhuyenMai";
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

        public void timKiemSP()
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
            if (cbbNhaCungCap_TK.SelectedValue == null)
            {
                return;
            }
            String Ncc = cbbNhaCungCap_TK.SelectedValue.ToString();
            String hanSuDung = txtHanSD.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT sp.MaSanPham, sp.TenSanPham, m.TenDanhMuc, sp.Gia, sp.MoTa, sp.HinhAnh, sp.NgayTao, ncc.TenNhaCungCap, sp.SoLuong, sp.HanSuDung, sp.GiaNhap, sp.MaKhuyenMai FROM SanPham sp join DanhMuc m on sp.MaDanhMuc = m.MaDanhMuc join NhaCungCap ncc on ncc.MaNhaCungCap = sp.MaNhaCungCap WHERE sp.MaSanPham like '%" + maSP + "%' and sp.TenSanPham like N'%" + tenSP + "%' and m.MaDanhMuc like '%" + maDanhMuc + "%' and ncc.MaNhaCungCap like '%" + Ncc + "%'";
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
            if (hanSuDung != "")
            {
                sql += " and DATEDIFF(day, GETDATE(), HanSuDung) <= '" + hanSuDung + "' and DATEDIFF(day, GETDATE(), HanSuDung) >= 0";
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
            demSoLuong();
        }
        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            


        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)e.RowIndex;
            if (i >= 0)
            {
                //txtMaSP.Text = dgvSanPham.Rows[i].Cells[0].Value.ToString();
                //txtTenSP.Text = dgvSanPham.Rows[i].Cells[1].Value.ToString();
                //cbbTenDanhMuc.Text = dgvSanPham.Rows[i].Cells[2].Value.ToString();
                //txtGia.Text = dgvSanPham.Rows[i].Cells[3].Value.ToString();
                //txtMoTa.Text = dgvSanPham.Rows[i].Cells[4].Value.ToString();
                
                //string duongDanAnh = dgvSanPham.Rows[i].Cells[5].Value.ToString();
                //string duongDanDayDu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, duongDanAnh);
                //if (File.Exists(duongDanDayDu))
                //{
                //    pictureBox1.Image = Image.FromFile(duongDanDayDu);
                //    txtDuongDanCU.Text = duongDanAnh;
                //}
                //cbbTenNhaCungCap.Text = dgvSanPham.Rows[i].Cells[7].Value.ToString();
                //dtNgayTao.Value = Convert.ToDateTime(dgvSanPham.Rows[i].Cells[6].Value.ToString());
                //txtSoLuong.Text = dgvSanPham.Rows[i].Cells[8].Value.ToString();

                String maSP = dgvSanPham.Rows[i].Cells[0].Value.ToString();
                String tenSP = dgvSanPham.Rows[i].Cells[1].Value.ToString();
                String tenDanhMuc = dgvSanPham.Rows[i].Cells[2].Value.ToString();
                String gia = dgvSanPham.Rows[i].Cells[3].Value.ToString();
                String moTa = dgvSanPham.Rows[i].Cells[4].Value.ToString();

                string duongDanAnh = dgvSanPham.Rows[i].Cells[5].Value.ToString();
                string duongDanDayDu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, duongDanAnh);
                //if (File.Exists(duongDanDayDu))
                //{
                //    pictureBox1.Image = Image.FromFile(duongDanDayDu);
                //    txtDuongDanCU.Text = duongDanAnh;
                //}
                String tenNhaCungCap = dgvSanPham.Rows[i].Cells[7].Value.ToString();
                DateTime ngayTao = Convert.ToDateTime(dgvSanPham.Rows[i].Cells[6].Value.ToString());
                String soLuong = dgvSanPham.Rows[i].Cells[8].Value.ToString();
                DateTime hanSuDung = Convert.ToDateTime(dgvSanPham.Rows[i].Cells[9].Value.ToString());
                String giaNhap = dgvSanPham.Rows[i].Cells[10].Value.ToString();
                String maKhuyenMai = dgvSanPham.Rows[i].Cells[11].Value.ToString();
                CapNhatTTSanPham f = new CapNhatTTSanPham(this);
                f.capNhatThongTin(maSP,tenSP,tenDanhMuc,gia,moTa,duongDanAnh,duongDanDayDu,tenNhaCungCap,ngayTao,hanSuDung,soLuong,giaNhap,maKhuyenMai);
                f.ShowDialog();
                f.Dispose();
                
            }

        }

       

        private void buttonThemMoi_Click(object sender, EventArgs e)
        {
            CapNhatTTSanPham f = new CapNhatTTSanPham(this);
            f.them();
            f.ShowDialog();
           // buttonThemMoi.Enabled = false;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtGialon_TextChanged(object sender, EventArgs e)
        {
            Regex regexGia = new Regex(@"^\d+([.]\d+)?$");
            String gia2 = txtGia1_TK.Text;
            // Kiểm tra giá chỉ chứa số
            if (txtGia2_TK.Text == "")
            {
                lbTB.Text = "";
                return;
            }
            else if (!regexGia.IsMatch(gia2))
            {
                lbTB.Text = "Giá sản phẩm chỉ được nhập số!";
                lbTB.ForeColor = Color.Red;
                return;
            }
            else
            {
                lbTB.Text = "✅";
                lbTB.ForeColor = Color.Green;
            }

            timKiemSP();
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
            xls.Range head = oSheet.get_Range("A1", "M1");
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
            cl6.ColumnWidth = 30.0;
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

            xls.Range cl11 = oSheet.get_Range("K3", "K3");
            cl11.Value2 = "HẠN SỬ DỤNG";
            cl11.ColumnWidth = 20.0;

            xls.Range cl12 = oSheet.get_Range("L3", "L3");
            cl12.Value2 = "GIÁ NHẬP";
            cl12.ColumnWidth = 20.0;

            xls.Range cl13 = oSheet.get_Range("M3", "M3");
            cl13.Value2 = "KHUYẾN MÃI";
            cl13.ColumnWidth = 15.0;

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
                    if (c == 8 || c == 11) 
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
            // Định dạng lại cột ngày sinh (E)
            xls.Range dateColumn2 = oSheet.Range[oSheet.Cells[rowStart, 11], oSheet.Cells[rowEnd, 11]];
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
            if(cbbNhaCungCap_TK.SelectedValue == null)
            {
                return;
            }
            String Ncc = cbbNhaCungCap_TK.SelectedValue.ToString();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT sp.MaSanPham, sp.TenSanPham, m.TenDanhMuc, sp.Gia, sp.MoTa, sp.HinhAnh, sp.NgayTao, ncc.TenNhaCungCap, sp.SoLuong , sp.HanSuDung, sp.GiaNhap, sp.MaKhuyenMai FROM SanPham sp join DanhMuc m on sp.MaDanhMuc = m.MaDanhMuc join NhaCungCap ncc on ncc.MaNhaCungCap = sp.MaNhaCungCap WHERE sp.MaSanPham like '%" + maSP + "%' and sp.TenSanPham like N'%" + tenSP + "%' and m.MaDanhMuc like '%" + maDanhMuc + "%' and ncc.MaNhaCungCap like '%" + Ncc + "%'";
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
        public void ThemSanPham(String maSP, String tenSP, String maDanhMuc, decimal gia, String moTa, String maNhaCungCap, int soLuong,DateTime hsd, decimal giaNhap, string maKM)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string hinhanh = "chưa có";
            string ngayTao = DateTime.Now.ToString("yyyy-MM-dd");
            //String ngaySinhSql = ngaySinh.ToString("yyyy-MM-dd");
            string sql = "INSERT INTO SanPham VALUES('" + maSP + "', N'" + tenSP + "', '" + maDanhMuc + "', '" + gia + "', N'" + moTa + "', N'" + hinhanh + "', '" + ngayTao + "', '" + maNhaCungCap + "', '" + soLuong + "','" + hsd + "','" + giaNhap + "'";
            if (maKM != null)
            {
                sql += ", '" + maKM + "'";
            }
            else
            {
                sql += ", NULL";
            }
            sql += ")";
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
                            string giaNhapxc = wsheet.Cells[i, 9].Value?.ToString();
                            decimal gia = Convert.ToDecimal(giaxc);
                            decimal giaNhap = Convert.ToDecimal(giaNhapxc);
                            int soLuong = Convert.ToInt32(soLuongxc);
                            DateTime hanSuDung;
                            if (!DateTime.TryParse(wsheet.Cells[i, 8].Value?.ToString(), out hanSuDung))
                            {
                                hanSuDung = DateTime.MinValue; // Gán giá trị mặc định nếu lỗi
                            }
                            string maKhuyenMai = wsheet.Cells[i, 10].Value?.ToString();
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
                            ThemSanPham(maSP, tenSP, maDanhMuc, gia, moTa, maNhaCungCap, soLuong, hanSuDung, giaNhap, maKhuyenMai);
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

        private void txtMaSP_TK_TextChanged(object sender, EventArgs e)
        {
            timKiemSP();
        }

        private void txtTenSP_TK_TextChanged(object sender, EventArgs e)
        {
            timKiemSP();
        }

        private void cbbNhaCungCap_TK_SelectedIndexChanged(object sender, EventArgs e)
        {
            timKiemSP();
        }

        private void cbbDanhMuc_TK_SelectedIndexChanged(object sender, EventArgs e)
        {
            timKiemSP();
        }
        public void demSoLuong()
        {
            int dem = 0;
            for (int i = 0; i < dgvSanPham.Rows.Count; i++)
            {
                if (dgvSanPham.Rows[i].Cells[0].Value != null)
                {
                    dem++;
                }
            }
            txtSoLuong.Text = dem.ToString() + " sản phẩm.";
        }
        private void txtGia1_TK_TextChanged(object sender, EventArgs e)
        {
            Regex regexGia = new Regex(@"^\d+([.]\d+)?$");
            String gia1 = txtGia1_TK.Text;
            // Kiểm tra giá chỉ chứa số
            if (txtGia1_TK.Text == "")
            {
                lbTB.Text = "";
                return;
            }
            else if (!regexGia.IsMatch(gia1))
            {
                lbTB.Text = "Giá sản phẩm chỉ được nhập số!";
                lbTB.ForeColor = Color.Red;
                return;
            }
            else
            {
                lbTB.Text = "✅";
                lbTB.ForeColor = Color.Green;
            }

            timKiemSP();
        }

        private void txtHanSD_TextChanged(object sender, EventArgs e)
        {
            Regex so = new Regex(@"^\d+$");
            String soLuong = txtHanSD.Text;
            if(txtHanSD.Text == "")
            {
                lbTbHsd.Text = "";
                timKiemSP();
                return;
            }
            else if (!so.IsMatch(soLuong))
            {
                lbTbHsd.Text = "Hạn sử dụng chỉ được nhập số!";
                lbTbHsd.ForeColor = Color.Red;
                return;
            }
            else
            {
                lbTbHsd.Text = "✅";
                lbTbHsd.ForeColor = Color.Green;
            }
            timKiemSP();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
