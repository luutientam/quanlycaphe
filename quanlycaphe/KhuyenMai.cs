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
    public partial class KhuyenMai : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True");
        public KhuyenMai()
        {
            InitializeComponent();
            loadKhuyenMai();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
        }
        public bool checkTrungMaKhuyenMai(String maKM)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from KhuyenMai where MaKhuyenMai = '" + maKM + "'";
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
        public void loadKhuyenMai()
        {
            // Load khuyen mai
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "select * from KhuyenMai";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            dgvKhuyenMai.DataSource = tb;
            dgvKhuyenMai.Refresh();

        }
        public void clear()
        {
            txtMaKM.Text = "";
            txtTenKM.Text = "";
            txtMoTa.Text = "";
            dtNgayBatDau.Value = DateTime.Now;
            dtNgayKetThuc.Value = DateTime.Now;
            txtPhanTramGiam.Text = "";
        }
        public void enableTextBox()
        {
            txtMaKM.Enabled = true;
            txtTenKM.Enabled = true;
            txtMoTa.Enabled = true;
            dtNgayBatDau.Enabled = true;
            dtNgayKetThuc.Enabled = true;
            txtPhanTramGiam.Enabled = true;
        }
        public void disableTextBox()
        {
            txtMaKM.Enabled = false;
            txtTenKM.Enabled = false;
            txtMoTa.Enabled = false;
            dtNgayBatDau.Enabled = false;
            dtNgayKetThuc.Enabled = false;
            txtPhanTramGiam.Enabled = false;
        }
        private void KhuyenMai_Load(object sender, EventArgs e)
        {

        }

        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)e.RowIndex;
            if (i >= 0)
            {
                txtMaKM.Text = dgvKhuyenMai.Rows[i].Cells[0].Value.ToString();
                txtTenKM.Text = dgvKhuyenMai.Rows[i].Cells[1].Value.ToString();
                txtMoTa.Text = dgvKhuyenMai.Rows[i].Cells[2].Value.ToString();
                dtNgayBatDau.Value = Convert.ToDateTime(dgvKhuyenMai.Rows[i].Cells[3].Value.ToString());
                dtNgayKetThuc.Value = Convert.ToDateTime(dgvKhuyenMai.Rows[i].Cells[4].Value.ToString());
                txtPhanTramGiam.Text = dgvKhuyenMai.Rows[i].Cells[5].Value.ToString();
            }
            enableTextBox();
            txtMaKM.Enabled = false;
            buttonThemMoi.Enabled = false;
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = true;
            buttonXoa.Enabled = true;
            buttonHuyThaoTac.Enabled = true;
        }

        private void buttonThemMoi_Click(object sender, EventArgs e)
        {
            buttonThemMoi.Enabled = false;
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
            buttonThemMoi.Enabled = true;
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            String maKM = txtMaKM.Text;
            if (maKM == "")
            {
                MessageBox.Show("Vui lòng nhập mã khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(checkTrungMaKhuyenMai(maKM))
            {
                MessageBox.Show("Mã khuyến mãi đã tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            String tenKM = txtTenKM.Text;
            if (tenKM == "")
            {
                MessageBox.Show("Vui lòng nhập tên khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String moTa = txtMoTa.Text;
            if (moTa == "")
            {
                MessageBox.Show("Vui lòng nhập mô tả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String phanTramGiam = txtPhanTramGiam.Text;
            if (phanTramGiam == "")
            {
                MessageBox.Show("Vui lòng nhập phần trăm giảm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime ngayBatDau = dtNgayBatDau.Value;
            String ngayBatDausql = ngayBatDau.ToString("yyyy-MM-dd");
            DateTime ngayKetThuc = dtNgayKetThuc.Value;
            String ngayKetThucsql = ngayBatDau.ToString("yyyy-MM-dd");
            String tb = "Kiểm tra thông tin trước khi lưu: \n Mã khuyến mãi: " + maKM + "\n Tên khuyến mãi: " + tenKM + "\n Mô tả: " + moTa + "\n Ngày bắt đầu khuyến mãi: " + ngayBatDausql + "\n Ngày kết thúc khuyến mãi: " + ngayKetThucsql + "\n Phần trăm giảm: " + phanTramGiam;
            if (MessageBox.Show(tb,"Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No){
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "insert into KhuyenMai values('" + maKM + "', N'" + tenKM + "', N'" + moTa + "', '" + ngayBatDausql + "', '" + ngayKetThucsql + "', '" + phanTramGiam + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            loadKhuyenMai();
            MessageBox.Show("Thêm mới thành công", "Thông báo");
            clear();
            disableTextBox();
            buttonLuu.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            buttonHuyThaoTac.Enabled = false;
            buttonThemMoi.Enabled = true;
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            String maKM = txtMaKM.Text;
            if (maKM == "")
            {
                MessageBox.Show("Vui lòng nhập mã khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String tenKM = txtTenKM.Text;
            if (tenKM == "")
            {
                MessageBox.Show("Vui lòng nhập tên khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String moTa = txtMoTa.Text;
            if (moTa == "")
            {
                MessageBox.Show("Vui lòng nhập mô tả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String phanTramGiam = txtPhanTramGiam.Text;
            if (phanTramGiam == "")
            {
                MessageBox.Show("Vui lòng nhập phần trăm giảm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime ngayBatDau = dtNgayBatDau.Value;
            String ngayBatDausql = ngayBatDau.ToString("yyyy-MM-dd");
            DateTime ngayKetThuc = dtNgayKetThuc.Value;
            String ngayKetThucsql = ngayBatDau.ToString("yyyy-MM-dd");
            if(MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin không ?", "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "update KhuyenMai set TenKhuyenMai = N'" + tenKM + "', MoTa = N'" + moTa + "', NgayBatDau = '" + ngayBatDausql + "', NgayKetThuc = '" + ngayKetThucsql + "', PhanTramGiam = '" + phanTramGiam + "' where MaKhuyenMai = '" + maKM + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            loadKhuyenMai();
            MessageBox.Show("Cập nhật thành công", "Thông báo");
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
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete from KhuyenMai where MaKhuyenMai = '" + txtMaKM.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                loadKhuyenMai();
                MessageBox.Show("Xóa thành công", "Thông báo");
                clear();
                disableTextBox();
                buttonLuu.Enabled = false;
                buttonCapNhat.Enabled = false;
                buttonXoa.Enabled = false;
                buttonHuyThaoTac.Enabled = false;
                buttonThemMoi.Enabled = true;
            }
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String maKM = txtMaKM_TK.Text;
            String tenKM = txtTenKM_TK.Text;
            //DateTime ngayApDung = dtNgayApDung_TK.Value;
            //String ngayApDungsql = ngayApDung.ToString("yyyy-MM-dd");
            String phanTramGiam = txtPhanTramGiam_TK.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "select * from KhuyenMai where MaKhuyenMai like '%"+maKM+"%' and TenKhuyenMai like N'%"+tenKM+"%' and PhanTramGiam like '%"+phanTramGiam+ "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            dgvKhuyenMai.DataSource = tb;
            dgvKhuyenMai.Refresh();

             
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
            head.Value2 = "THỐNG KÊ THÔNG TIN VỀ KHUYẾN MÃI";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            xls.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 6.0;
            xls.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ KHUYỄN MÃI";
            cl2.ColumnWidth = 16.0;


            xls.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "TÊN KHUYẾN MÃI";
            cl3.ColumnWidth = 18.0;
            xls.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "MÔ TẢ";
            cl4.ColumnWidth = 20.0;
            xls.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "NGÀY BẮT ĐẦU";
            cl5.ColumnWidth = 15.0;
            xls.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "NGÀY KẾT THÚC";
            cl6.ColumnWidth = 15.0;
            //xls.Range cl6_1 = oSheet.get_Range("F4", "F1000");
            //cl6_1.Columns.NumberFormat = "dd/mm/yyyy";


            xls.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "PHẦN TRĂM GIẢM";
            cl7.ColumnWidth = 18.0;

            //xls.Range cl8 = oSheet.get_Range("I3", "I3");
            //cl8.Value2 = "TÊN ĐĂNG NHẬP";
            //cl8.ColumnWidth = 20.0;

            //xls.Range cl9 = oSheet.get_Range("J3", "J3");
            //cl9.Value2 = "MẬT KHẨU";
            //cl9.ColumnWidth = 15.0;

            //xls.Range cl10 = oSheet.get_Range("K3", "K3");
            //cl10.Value2 = "EMAIL";
            //cl10.ColumnWidth = 30.0;

            //xls.Range cl11 = oSheet.get_Range("L3", "L3");
            //cl11.Value2 = "NGÀY TẠO";
            //cl11.ColumnWidth = 13.0;

            //xls.Range cl12 = oSheet.get_Range("M3", "M3");
            //cl12.Value2 = "TRẠNG THÁI";
            //cl12.ColumnWidth = 15.0;

            //xls.Range cl8 = oSheet.get_Range("H3", "H3");
            //cl8.Value2 = "GHI CHÚ";
            //cl8.ColumnWidth = 15.0;
            xls.Range rowHead = oSheet.get_Range("A3", "G3");
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
                    if (c == 5 || c == 6) // Cột ngày sinh (E) - chú ý: chỉ số mảng bắt đầu từ 0
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
            xls.Range dateColumn = oSheet.Range[oSheet.Cells[rowStart, 5], oSheet.Cells[rowEnd, 5]];
            dateColumn.NumberFormat = "dd/mm/yyyy";

            // Định dạng lại cột ngày sinh (K)
            xls.Range dateColumn2 = oSheet.Range[oSheet.Cells[rowStart, 6], oSheet.Cells[rowEnd, 6]];
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
            String maKM = txtMaKM_TK.Text;
            String tenKM = txtTenKM_TK.Text;
            //DateTime ngayApDung = dtNgayApDung_TK.Value;
            //String ngayApDungsql = ngayApDung.ToString("yyyy-MM-dd");
            String phanTramGiam = txtPhanTramGiam_TK.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "select * from KhuyenMai where MaKhuyenMai like '%" + maKM + "%' and TenKhuyenMai like N'%" + tenKM + "%' and PhanTramGiam like '%" + phanTramGiam + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            ExportExcel(tb, "KhuyenMai");
        }

        private void txtTenKM_TK_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPhanTramGiam_TK_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dgvKhuyenMai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtMaKM_TK_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaKM_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTenKM_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtPhanTramGiam_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtNgayBatDau_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void ThemKhuyenMai(String maKM, String tenKM, String moTa, DateTime ngayBatDau, DateTime ngayKetThuc, String phanTramGiam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "insert into KhuyenMai values('" + maKM + "', N'" + tenKM + "', N'" + moTa + "', '" + ngayBatDau.ToString("yyyy-MM-dd") + "', '" + ngayKetThuc.ToString("yyyy-MM-dd") + "', '" + phanTramGiam + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadKhuyenMai();
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
                            string maKM = wsheet.Cells[i, 1].Value?.ToString();
                            string tenKhuyenMai = wsheet.Cells[i, 2].Value?.ToString();
                            string moTa = wsheet.Cells[i, 3].Value?.ToString();
                            DateTime ngayBatDau;
                            if (!DateTime.TryParse(wsheet.Cells[i, 4].Value?.ToString(), out ngayBatDau))
                            {
                                ngayBatDau = DateTime.MinValue; // Gán giá trị mặc định nếu lỗi
                            }
                            DateTime ngayKetThuc;
                            if (!DateTime.TryParse(wsheet.Cells[i, 5].Value?.ToString(), out ngayKetThuc))
                            {
                                ngayKetThuc = DateTime.MinValue; // Gán giá trị mặc định nếu lỗi
                            }
                            string phanTramGiam = wsheet.Cells[i, 6].Value?.ToString();
                            if (checkTrungMaKhuyenMai(maKM))
                            {
                                MessageBox.Show("Trùng mã khuyến mãi -> " + maKM + " <- !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                i++;
                                continue;
                            }

                            // Gọi phương thức ThemDocGia với dữ liệu đã được ép kiểu đúng
                            ThemKhuyenMai(maKM, tenKhuyenMai, moTa, ngayBatDau, ngayKetThuc, phanTramGiam);
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
                loadKhuyenMai();
            }
        }
    }
}
