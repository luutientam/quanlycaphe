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
using xls = Microsoft.Office.Interop.Excel;

namespace quanlycaphe
{
    public partial class KhachHang : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True");
        public KhachHang()
        {  
            InitializeComponent();
            loadKhachHang();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
            txtDuongDan.Enabled = false;

        }
        public void loadKhachHang()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT * from KhachHang";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Dispose();
            con.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }
        public void clear()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSdt.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
        }
        public void enableTextBox()
        {
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtSdt.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
        }
        public void disableTextBox()
        {
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            txtSdt.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maKH = txtMaKH.Text.Trim();
            String tenKH = txtTenKH.Text.Trim();
            if (maKH == "" || tenKH == "")
            {
                MessageBox.Show("Mã khách hàng và tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String email = txtEmail.Text.Trim();
            String diaChi = txtDiaChi.Text.Trim();
            String sdt = txtSdt.Text.Trim();
            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //b2: kết nối sql
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (checkTrungMaKH(maKH))
            {
                MessageBox.Show("Trùng mã khách hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            String sql = "insert KhachHang values('" + maKH + "', N'" + tenKH + "',  '" + sdt + "', N'" + email + "','" + diaChi + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadKhachHang();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maKH = txtMaKH.Text.Trim();
            String tenKH = txtTenKH.Text.Trim();
            if (maKH == "" || tenKH == "")
            {
                MessageBox.Show("Mã khách hàng và tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String email = txtEmail.Text.Trim();
            String diaChi = txtDiaChi.Text.Trim();
            String sdt = txtSdt.Text.Trim();
            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải đủ 10 số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //b2: kết nối sql
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "update KhachHang set TenKhachHang = N'" + tenKH + "', Email =  '" + email + "', DiaChi = N'" + diaChi + "', SoDienThoai = '" + sdt + "' where MaKhachHang = '" + maKH + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadKhachHang();
            txtMaKH.Enabled = true;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String maKH = txtMaKH.Text.Trim();
                String sql = "delete from KhachHang where MaKhachHang = '" + maKH + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                loadKhachHang();
            }
        }

        

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String maKH = txtMaKH_tk.Text.Trim();
            String tenKH = txtTenKH_tk.Text.Trim();
            String sdt = txtSdtKH_tk.Text.Trim();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select * from KhachHang where MaKhachHang like '%" + maKH + "%' and TenKhachHang like N'%" + tenKH + "%' and SoDienThoai like '%" + sdt + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtt = new DataTable();
            da.Fill(dtt);
            cmd.Dispose();
            con.Close();
            dataGridView1.DataSource = dtt;
            dataGridView1.Refresh();
        }

        public bool checkTrungMaKH(String maKH)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from KhachHang where MaKhachHang = '" + maKH + "'";
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonThem_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)e.RowIndex;
            txtMaKH.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtSdt.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            enableTextBox();
            buttonCapNhat.Enabled = true;
            buttonXoa.Enabled = true;
            buttonHuyThaoTac.Enabled = true;
            buttonLuu.Enabled = false;
            txtMaKH.Enabled = false;
        }
        public void ThemKhachHang(String maKH, String tenKH, String sdt, String email, String diaChi)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "insert KhachHang values('" + maKH + "', N'" + tenKH + "', N'" + sdt + "' , '" + email + "', N'" + diaChi + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
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
                            string maKH = wsheet.Cells[i, 1].Value?.ToString();
                            string tenKH = wsheet.Cells[i, 2].Value?.ToString();
                            string sdt = wsheet.Cells[i, 3].Value?.ToString();
                            string email = wsheet.Cells[i, 4].Value?.ToString();
                            string diaChi = wsheet.Cells[i, 5].Value?.ToString();

                            if (checkTrungMaKH(maKH))
                            {
                                MessageBox.Show("Trùng mã khách hàng -> " + maKH + " <- !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                i++;
                                continue;
                            }
                            

                            // Gọi phương thức ThemKhachHang với dữ liệu đã được ép kiểu đúng
                            ThemKhachHang(maKH, tenKH, sdt, email, diaChi);
                            i++;
                        }
                    }
                    while (true);
                }
            }
        }
        private void groupBox2_Enter(object sender, EventArgs e)
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
            head.Value2 = "THỐNG KÊ THÔNG TIN VỀ KHÁCH HÀNG";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            xls.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã khách hàng";
            cl1.ColumnWidth = 20.0;
            xls.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tên khách hàng";
            cl2.ColumnWidth = 30.0;
            xls.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Số điện thoại";
            cl3.ColumnWidth = 15.0;
            xls.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Email";
            cl4.ColumnWidth = 12.0;
            xls.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Địa chỉ";
            cl5.ColumnWidth = 60.0;
            //xls.Range cl6_1 = oSheet.get_Range("F4", "F1000");
            //cl6_1.Columns.NumberFormat = "dd/mm/yyyy";
            //xls.Range cl8 = oSheet.get_Range("H3", "H3");
            //cl8.Value2 = "GHI CHÚ";
            //cl8.ColumnWidth = 15.0;
            xls.Range rowHead = oSheet.get_Range("A3", "E3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = xls.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // Tạo mảng đối tượng để lưu toàn bộ dữ liệu trong DataTable
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count + 1]; // Thêm 1 cột cho STT

            // Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                //arr[r, 0] = r + 1; // STT ở cột đầu tiên (A)
                DataRow dr = tb.Rows[r];

                for (int c = 0; c < tb.Columns.Count; c++)
                {
                    arr[r, c] = dr[c]; // Dịch cột sang phải một đơn vị
                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count;
            // Ô bắt đầu điền dữ liệu
            xls.Range c1 = (xls.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            xls.Range c2 = (xls.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            xls.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            // Định dạng lại cột ngày sinh (E)
            //xls.Range dateColumn = oSheet.Range[oSheet.Cells[rowStart, 5], oSheet.Cells[rowEnd, 5]];
            //dateColumn.NumberFormat = "dd/mm/yyyy";
            // Kẻ viền
            range.Borders.LineStyle = xls.Constants.xlSolid;
            // Căn giữa cột STT
            xls.Range c3 = (xls.Range)oSheet.Cells[rowEnd, columnStart];
            xls.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = openFileDialog.FileName;
                ReadExcel(openFileDialog.FileName);
                MessageBox.Show("Nhập files thành công", "Thông báo", MessageBoxButtons.OK);
                loadKhachHang();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String maKH = txtMaKH_tk.Text.Trim();
            String tenKH = txtTenKH_tk.Text.Trim();
            String sdt = txtSdtKH_tk.Text.Trim();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select * from KhachHang where MaKhachHang like '%" + maKH + "%' and TenKhachHang like N'%" + tenKH + "%' and SoDienThoai like N'%" + sdt + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtt = new DataTable();
            da.Fill(dtt);
            cmd.Dispose();
            con.Close();
            ExportExcel(dtt, "Danh sách khách hàng");
        }

        private void txtDuongDan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenKH_tk_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
