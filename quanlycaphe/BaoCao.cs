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
using System.Diagnostics;
//using System.Excel;

namespace quanlycaphe
{
    public partial class BaoCao : Form
    {
        ketnoicuadiem ketnoi = new ketnoicuadiem();
        public BaoCao()
        {
            InitializeComponent();
            Load_trangthai();
            Load_Nguonhang();
            Load_Nhanvien();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void doanhThuTheoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void Load_trangthai()
        {
            //ket noi dtb
            ketnoi.Open();

            //tao doi tuong command de thuc hien truy van
            string sql = "select TrangThai from DonHang";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());

            //tao doi tuong dataadapter de lay du lieu tu cmd
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            //khoi tao doi tuonf datatable de lay du lieu tu da
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Dispose();
            ketnoi.Close();

            //bo sung them 1 dong vao vi tri dau tien cua bang tb
            DataRow dr = dt.NewRow();
            dr["TrangThai"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);

            //do du lieu tu tb vao combobox
            cbtrangthai.DataSource = null;
            cbtrangthai.DataSource = dt;
            cbtrangthai.DisplayMember = "TrangThai";
            cbtrangthai.ValueMember = "TrangThai";
            //  cbtrangthai.SelectedIndex = 0; // Chọn giá trị đầu tiên trong ComboBox
            //  cbtrangthai.Visible = false;

        }
        private void Load_Nguonhang()
        {
            //ket noi dtb
            ketnoi.Open();

            //tao doi tuong command de thuc hien truy van
            string sql = "select TenDanhMuc from DanhMuc";
            SqlCommand sqlcmd = new SqlCommand(sql, ketnoi.GetConnection());

            //tao doi tuong dataadapter de lay du lieu tu cmd
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;

            //khoi tao doi tuonf datatable de lay du lieu tu da
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlcmd.Dispose();
            ketnoi.Close();

            //bo sung them 1 dong vao vi tri dau tien cua bang tb
            DataRow dr = dt.NewRow();
            dr["TenDanhMuc"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);

            //do du lieu tu tb vao combobox
            cbnguonhang.DataSource = null;
            cbnguonhang.DataSource = dt;
            cbnguonhang.DisplayMember = "TenDanhMuc";
            cbnguonhang.ValueMember = "TenDanhMuc";
            //cbnguonhang.SelectedIndex = 0; // Chọn giá trị đầu tiên trong ComboBox

        }
        private void Load_Nhanvien()
        {
            //ket noi dtb
            ketnoi.Open();

            //tao doi tuong command de thuc hien truy van
            string sql = "select MaNhanVien from NhanVien";
            SqlCommand sqlCommand = new SqlCommand(sql, ketnoi.GetConnection());

            //tao doi tuong dataadapter de lay du lieu tu cmd
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCommand;

            //khoi tao doi tuonf datatable de lay du lieu tu da
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlCommand.Dispose();
            ketnoi.Close();

            DataRow dr = dt.NewRow();
            dr["MaNhanVien"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);

            //do du lieu tu tb vao combobox
            cbnhanvien.DataSource = null;
            cbnhanvien.DataSource = dt;
            cbnhanvien.DisplayMember = "MaNhanVien";
            cbnhanvien.ValueMember = "MaNhanVien";
            //cbnhanvien.SelectedIndex = 0; // Chọn giá trị đầu tiên trong ComboBox
        }

        private void btbaocao_Click(object sender, EventArgs e)
        {
            string trangthai = cbtrangthai.SelectedValue.ToString();
            string nguonhang = cbnguonhang.SelectedValue.ToString();
            string nhanvien = cbnhanvien.SelectedValue.ToString();

            ketnoi.Open();

            string sql = @"SELECT dh.MaDonHang, dh.TongTien, dh.NgayDat, dh.MaNhanVien, dh.TrangThai
FROM DonHang dh
JOIN ChiTietDonHang ct ON dh.MaDonHang = ct.MaDonHang
JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham";

            List<string> conditions = new List<string>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ketnoi.GetConnection();

            if (trangthai != "Tất cả")
            {
                conditions.Add("dh.TrangThai = @trangthai");
                cmd.Parameters.AddWithValue("@trangthai", trangthai);
            }
            if (nguonhang != "Tất cả")
            {
                conditions.Add("dm.TenDanhMuc = @nguonhang");
                cmd.Parameters.AddWithValue("@nguonhang", nguonhang);
            }
            if (nhanvien != "Tất cả")
            {
                conditions.Add("dh.MaNhanVien = @nhanvien");
                cmd.Parameters.AddWithValue("@nhanvien", nhanvien);
            }

            if (conditions.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", conditions);
            }

            cmd.CommandText = sql;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmd.Dispose();
            ketnoi.Close();

            dgvbaocao.DataSource = dt;

        }

        private void dgvbaocao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvbaocao.Rows[e.RowIndex];

            // Lấy giá trị của ô đầu tiên trong hàng đã chọn
            string maDonHang = row.Cells["madonhang"].Value.ToString();
            string tongtien = row.Cells["tongtien"].Value.ToString();
            DateTime ngayht;
            if (DateTime.TryParse(row.Cells["NgayDat"].Value.ToString(), out ngayht))
            {
                // Chuyển đổi thành chuỗi theo định dạng mong muốn
                string formattedDate = ngayht.ToString("yyyy-MM-dd");
                //MessageBox.Show($"Mã đơn hàng: {maDonHang}\nTổng Tiền: {tongtien} \nNgày hiện tại: {formattedDate} \nMã nhân viên: {maNhanVien} \nTrạng Thái: {trangthai}");
            }
            else
            {
                MessageBox.Show("Không thể chuyển đổi ngày.");
            }
            string maNhanVien = row.Cells["manhanvien"].Value.ToString();
            string trangthai = row.Cells["trangthai"].Value.ToString();
           
        }

        private void bttrangchu_Click(object sender, EventArgs e)
        {
            FormChinh f = new FormChinh();
            f.ShowDialog();
            this.Hide();
        }

        private void btxuatfile_Click(object sender, EventArgs e)
        {

            if (dgvbaocao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu File Excel",
                FileName = "DanhSachDonHang.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ExportExcelFromGrid(dgvbaocao, "DanhSachDonHang", filePath);
                MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🟢 Mở file Excel ngay sau khi xuất
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
        }
        private void ExportExcelFromGrid(DataGridView gridView, string sheetName, string filePath)
        {
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook oBook = oExcel.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets[1];
            oSheet.Name = sheetName;

            // Tạo tiêu đề cột
            string[] columnNames = { "STT", "MÃ ĐƠN HÀNG", "TỎNGO TIỀN", "NGÀY ĐẶT ", "MÃ NHÂN VIÊN", "TRẠNG THÁi" };
            for (int i = 0; i < columnNames.Length; i++)
            {
                oSheet.Cells[1, i + 1] = columnNames[i];
                oSheet.Cells[1, i + 1].Font.Bold = true;  // Làm đậm tiêu đề
            }

            // Đổ dữ liệu từ DataGridView vào Excel
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                oSheet.Cells[i + 2, 1] = (i + 1).ToString(); // STT
                for (int j = 0; j < gridView.Columns.Count; j++)
                {
                    oSheet.Cells[i + 2, j + 2] = gridView.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // Lưu file và đóng ứng dụng Excel
            oBook.SaveAs(filePath);
            oBook.Close();
            oExcel.Quit();

            // Giải phóng bộ nhớ
            ReleaseObject(oSheet);
            ReleaseObject(oBook);
            ReleaseObject(oExcel);
        }
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}
