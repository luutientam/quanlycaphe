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
using DocumentFormat.OpenXml.Presentation;

namespace quanlycaphe
{
    public partial class VaiTro : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True");

        public VaiTro()
        {
            InitializeComponent();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonLuu.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
            buttonThemMoi.Enabled = true;
            loadVaiTro();
            loadcbBVaiTro();
        }
        public void loadcbBVaiTro()
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
            r["TenVaiTro"] = "-- Chọn vai trò --";
            tb.Rows.InsertAt(r, 0);

            cbbVaiTro_TK.DataSource = tb;
            cbbVaiTro_TK.DisplayMember = "TenVaiTro";
            cbbVaiTro_TK.ValueMember = "MaVaiTro";
        }
        public void loadVaiTro()
        {
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "SELECT * FROM Vaitro";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            dgvVaiTro.DataSource = tb;
            dgvVaiTro.Refresh();
        }
        public void clear()
        {
            txtMaVaiTro.Text = "";
            txtTenVaiTro.Text = "";
        }
        public void disableTextBox()
        {
            txtMaVaiTro.Enabled = false;
            txtTenVaiTro.Enabled = false;
        }
        public void enableTextBox()
        {
            txtMaVaiTro.Enabled = true;
            txtTenVaiTro.Enabled = true;
        }
        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String maVaiTro = txtMaVaiTro_TK.Text;
            String tenVaiTro = cbbVaiTro_TK.SelectedValue.ToString();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "SELECT * FROM Vaitro WHERE MaVaiTro LIKE '%" + maVaiTro + "%' AND MaVaiTro LIKE N'%" + tenVaiTro + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            dgvVaiTro.DataSource = tb;
            dgvVaiTro.Refresh();

        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            String maVaiTro = txtMaVaiTro.Text;
            String tenVaiTro = txtTenVaiTro.Text;
            if (maVaiTro == "" || tenVaiTro == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if(MessageBox.Show("Bạn có muốn thêm vai trò này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "INSERT INTO Vaitro VALUES('"+maVaiTro+"', N'"+tenVaiTro+"')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Thêm mới vai trò thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadVaiTro();
            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
            buttonThemMoi.Enabled = true;
        }

        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            enableTextBox();
            txtMaVaiTro.Enabled = false;
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = true;
            buttonXoa.Enabled = true;
            buttonHuyThaoTac.Enabled = true;
            buttonThemMoi.Enabled = false;
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            String maVaiTro = txtMaVaiTro.Text;
            String tenVaiTro = txtTenVaiTro.Text;
            if (maVaiTro == "" || tenVaiTro == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (MessageBox.Show("Bạn có muốn cập nhật vai trò này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "UPDATE Vaitro SET TenVaiTro = N'" + tenVaiTro + "' WHERE MaVaiTro = '" + maVaiTro + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Cập nhật vai trò thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadVaiTro();

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
            String maVaiTro = txtMaVaiTro.Text;
            if (maVaiTro == "")
            {
                MessageBox.Show("Vui lòng chọn vai trò để xóa");
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa vai trò này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "DELETE FROM Vaitro WHERE MaVaiTro = '" + maVaiTro + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Xóa vai trò thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadVaiTro();
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
            head.Value2 = "THỐNG KÊ THÔNG TIN VỀ VAI TRÒ";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            xls.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 6.0;
            xls.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ VAI TRÒ";
            cl2.ColumnWidth = 16.0;


            xls.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "TÊN VAI TRÒ";
            cl3.ColumnWidth = 18.0;
            
            xls.Range rowHead = oSheet.get_Range("A3", "C3");
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
                    
                     arr[r, c+1] = dr[c]; // Dịch cột sang phải một đơn vị

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
            //// Định dạng lại cột ngày sinh (E)
            //xls.Range dateColumn = oSheet.Range[oSheet.Cells[rowStart, 8], oSheet.Cells[rowEnd, 8]];
            //dateColumn.NumberFormat = "dd/mm/yyyy";

            // Kẻ viền
            range.Borders.LineStyle = xls.Constants.xlSolid;
            // Căn giữa cột STT
            xls.Range c3 = (xls.Range)oSheet.Cells[rowEnd, columnStart];
            xls.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String maVaiTro = txtMaVaiTro_TK.Text;
            String tenVaiTro = cbbVaiTro_TK.SelectedValue.ToString();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "SELECT * FROM Vaitro WHERE MaVaiTro LIKE '%" + maVaiTro + "%' AND MaVaiTro LIKE N'%" + tenVaiTro + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            ExportExcel(tb, "THỐNG KÊ THÔNG TIN VỀ VAI TRÒ");
        }
    }
}
