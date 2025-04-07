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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using xls = Microsoft.Office.Interop.Excel;

namespace quanlycaphe
{
    public partial class NhaCungCap : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True");
        public NhaCungCap()
        {
            InitializeComponent();
            loadNhaCungCap();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
            txtDuongDan.Enabled = false;

        }
        public void loadNhaCungCap()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT * from NhaCungCap";
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
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSdt.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
        }
        public void enableTextBox()
        {
            txtMaNCC.Enabled = true;
            txtTenNCC.Enabled = true;
            txtSdt.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
        }
        public void disableTextBox()
        {
            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            txtSdt.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maNCC = txtMaNCC.Text.Trim();
            String tenNCC = txtTenNCC.Text.Trim();
            if (maNCC == "" || tenNCC == "")
            {
                MessageBox.Show("Mã nhà cung cấp và tên nhà cung cấp không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (checkTrungMaNCC(maNCC))
            {
                MessageBox.Show("Trùng mã nhà cung cấp !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }
            String sql = "insert NhaCungCap values('" + maNCC + "', N'" + tenNCC + "',  '" + sdt + "', N'" + email + "','" + diaChi + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadNhaCungCap();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maNCC = txtMaNCC.Text.Trim();
            String tenNCC = txtTenNCC.Text.Trim();
            if (maNCC == "" || tenNCC == "")
            {
                MessageBox.Show("Mã nhà cung cấp và tên nhà cung cấp không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            String sql = "update NhaCungCap set TenNhaCungCap = N'" + tenNCC + "', Email =  '" + email + "', DiaChi = N'" + diaChi + "', SoDienThoai = '" + sdt + "' where MaNhaCungCap = '" + maNCC + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadNhaCungCap();
            txtMaNCC.Enabled = true;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String maNCC = txtMaNCC.Text.Trim();
                String sql = "delete from NhaCungCap where MaNhaCungCap = '" + maNCC + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                loadNhaCungCap();
            }
        }
        

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String maNCC = txtMaNCC_tk.Text.Trim();
            String tenNCC = txtTenNCC_tk.Text.Trim();
            String sdt = txtSdt_tk.Text.Trim();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select * from NhaCungCap where MaNhaCungCap like '%" + maNCC + "%' and TenNhaCungCap like N'%" + tenNCC + "%' and SoDienThoai like '%" + sdt + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtt = new DataTable();
            da.Fill(dtt);
            cmd.Dispose();
            con.Close();
            dataGridView1.DataSource = dtt;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)e.RowIndex;
            txtMaNCC.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenNCC.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtSdt.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            enableTextBox();
            buttonSua.Enabled = true;
            buttonXoa.Enabled = true;
            buttonHuyThaoTac.Enabled = true;
            buttonLuu.Enabled = false;
            txtMaNCC.Enabled = false;
        }
        public bool checkTrungMaNCC(String maNCC)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from NhaCungCap where MaNhaCungCap = '" + maNCC + "'";
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMaNCC_tk_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTenNCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtSdt_tk_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTenNCC_tk_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            buttonLuu.Enabled = true;
            buttonSua.Enabled = false;
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
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }

        private void txtDiaChi_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void ThemNhaCungCap(String maNCC, String tenNCC, String sdt, String email, String diaChi)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "insert NhaCungCap values('" + maNCC + "', N'" + tenNCC + "', N'" + sdt + "' , '" + email + "', N'" + diaChi + "')";
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
                            string maNCC = wsheet.Cells[i, 1].Value?.ToString();
                            string tenNCC = wsheet.Cells[i, 2].Value?.ToString();
                            string sdt = wsheet.Cells[i, 4].Value?.ToString();
                            string email = wsheet.Cells[i, 3].Value?.ToString();
                            string diaChi = wsheet.Cells[i, 5].Value?.ToString();

                            if (checkTrungMaNCC(maNCC))
                            {
                                MessageBox.Show("Trùng mã nhà cung cấp -> " + maNCC + " <- !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                i++;
                                continue;
                            }
                          
                            

                            // Gọi phương thức ThemNhaCungCap với dữ liệu đã được ép kiểu đúng
                            ThemNhaCungCap(maNCC, tenNCC, sdt, email, diaChi);
                            i++;
                        }
                    }
                    while (true);
                }
            }
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
            head.Value2 = "THỐNG KÊ THÔNG TIN VỀ NHÀ CUNG CẤP";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            xls.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã nhà cung cấp";
            cl1.ColumnWidth = 20.0;
            xls.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tên nhà cung cấp";
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
              //  arr[r, 0] = r + 1; // STT ở cột đầu tiên (A)
                DataRow dr = tb.Rows[r];

                for (int c = 0; c < tb.Columns.Count; c++)
                {
                    if (c == 2)
                    {
                        arr[r, c ] = "'" + dr[c].ToString();
                    }
                    else
                    {
                        arr[r, c ] = dr[c];
                    }
                    
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
                loadNhaCungCap();
            }
        }

        private void txtDuongDan_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String maNCC = txtMaNCC_tk.Text.Trim();
            String tenNCC = txtTenNCC_tk.Text.Trim();
            String sdt = txtSdt_tk.Text.Trim();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select * from NhaCungCap where MaNhaCungCap like '%" + maNCC + "%' and TenNhaCungCap like N'%" + tenNCC + "%' and SoDienThoai like N'%" + sdt + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtt = new DataTable();
            da.Fill(dtt);
            cmd.Dispose();
            con.Close();
            ExportExcel(dtt, "Danh sách nhà cung cấp");
        }
    }
}
