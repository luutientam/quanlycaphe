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
    public partial class QuanLyBan : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True");
        public QuanLyBan()
        {
            InitializeComponent();
            loadBan();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }
        public void loadBan()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT * from Ban";
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
            txtMaBan.Text = "";
            txtTenBan.Text = "";
            cbxTrangThai.Text = "";
        }

        public void enableTextBox()
        {
            txtMaBan.Enabled = true;
            txtTenBan.Enabled = true;
            cbxTrangThai.Enabled = true;   
        }
        public void disableTextBox()
        {
            txtMaBan.Enabled = false;
            txtTenBan.Enabled = false;
            cbxTrangThai.Enabled = false;
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

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maBan = txtMaBan.Text.Trim();
            String tenBan = txtTenBan.Text.Trim();
            if (maBan == "" || tenBan == "")
            {
                MessageBox.Show("Mã khách hàng và tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String trangThai = cbxTrangThai.SelectedItem.ToString();
            //b2: kết nối sql
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (checkTrungMaBan(maBan))
            {
                MessageBox.Show("Trùng mã khách hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaBan.Focus();
                return;
            }
            String sql = "insert Ban values('" + maBan + "', N'" + tenBan + "',  '" + trangThai + "' )";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadBan();
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maBan = txtMaBan.Text.Trim();
            String tenBan = txtTenBan.Text.Trim();
            if (maBan == "" || tenBan == "")
            {
                MessageBox.Show("Mã khách hàng và tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn trạng thái bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String trangThai = cbxTrangThai.SelectedItem.ToString();
            //b2: kết nối sql
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "update Ban set TenBan = N'" + tenBan + "', TrangThai =  '" + trangThai + "' where MaBan = '" + maBan + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadBan();
            txtMaBan.Enabled = true;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String maBan = txtMaBan.Text.Trim();
                String sql = "delete from Ban where MaBan = '" + maBan + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                loadBan();
            }
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

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String maBan = txtMaBan_TK.Text.Trim();
            String tenBan = txtTenBan_TK.Text.Trim();
            String trangThai = cbxTrangThai_TK.SelectedItem.ToString();
            if(cbxTrangThai_TK.SelectedIndex == -1 || trangThai == "--Chọn trạng thái--")
            {
                trangThai = "";
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select * from Ban where MaBan like '%" + maBan + "%' and TenBan like N'%" + tenBan + "%' and TrangThai like N'%" + trangThai + "%'";
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
            txtMaBan.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenBan.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbxTrangThai.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            enableTextBox();
            buttonCapNhat.Enabled = true;
            buttonXoa.Enabled = true;
            buttonHuyThaoTac.Enabled = true;
            buttonLuu.Enabled = false;
            txtMaBan.Enabled = false;
        }
        public bool checkTrungMaBan(String maBan)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from Ban where MaBan = '" + maBan + "'";
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
        public void ThemBan(String maBan, String tenBan, String trangThai)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "insert Ban values('" + maBan + "', N'" + tenBan + "', N'" + trangThai + "')";
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
                            string maBan = wsheet.Cells[i, 1].Value?.ToString();
                            string tenBan = wsheet.Cells[i, 2].Value?.ToString();
                            string trangThai = wsheet.Cells[i, 3].Value?.ToString();
                            if (checkTrungMaBan(maBan))
                            {
                                MessageBox.Show("Trùng mã bàn -> " + maBan + " <- !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                i++;
                                continue;
                            }



                            // Gọi phương thức ThemKhachHang với dữ liệu đã được ép kiểu đúng
                            ThemBan(maBan, tenBan, trangThai);
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
            head.Value2 = "THỐNG KÊ THÔNG TIN VỀ BÀN";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            xls.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã bàn";
            cl1.ColumnWidth = 20.0;
            xls.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tên bàn";
            cl2.ColumnWidth = 30.0;
            xls.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Trạng thái";
            cl3.ColumnWidth = 15.0;
            //xls.Range cl6_1 = oSheet.get_Range("F4", "F1000");
            //cl6_1.Columns.NumberFormat = "dd/mm/yyyy";
            //xls.Range cl8 = oSheet.get_Range("H3", "H3");
            //cl8.Value2 = "GHI CHÚ";
            //cl8.ColumnWidth = 15.0;
            xls.Range rowHead = oSheet.get_Range("A3", "C3");
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
                loadBan();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String maBan = txtMaBan_TK.Text.Trim();
            String tenBan = txtTenBan_TK.Text.Trim();
            String trangThai = cbxTrangThai_TK.SelectedItem.ToString();
            if (cbxTrangThai_TK.SelectedIndex == -1 || trangThai == "--Chọn trạng thái--")
            {
                trangThai = "";
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select * from Ban where MaBan like '%" + maBan + "%' and TenBan like N'%" + tenBan + "%' and TrangThai like N'%" + trangThai + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtt = new DataTable();
            da.Fill(dtt);
            cmd.Dispose();
            con.Close();
            ExportExcel(dtt, "Danh sách bàn");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
