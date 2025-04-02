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
using System.IO;
using System.Diagnostics;
//excel
using xls = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;

using els = Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Office.Interop.Excel;

namespace quanlycaphe
{
    public partial class DanhMucSanPham : Form
    {

        private ketnoicuadiem ketnoi = new ketnoicuadiem();
        public DanhMucSanPham()
        {
            InitializeComponent();
            loadTrangThai();
            load_DanhMuc();
            LoadComboBoxTrangThaiTimKiem();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadTrangThai()
        {
            cbttdm.Items.Clear();
            cbttdm.Items.Add("Tất cả");
            cbttdm.Items.Add("Hoạt động");
            cbttdm.Items.Add("Tạm ngừng");
            cbttdm.SelectedIndex = 0; // Chọn giá trị mặc định là "Tat ca"
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            try
            {
                string madanhmuc = txtmadm.Text.Trim();
                string tendanhmuc = txttendm.Text.Trim();
              //  string trangthai = cbttdm.SelectedItem.ToString();
                string mota = txtmotadm.Text.Trim();
                
                ketnoi.Open();
                string sql = "insert into DanhMuc (MaDanhMuc, TenDanhMuc, TrangThai, MoTa)" +
                    "Values (@madanhmuc, @tendanhmuc, @trangthai, @mota)";
                SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
                cmd.Parameters.AddWithValue("@madanhmuc", txtmadm.Text);
                cmd.Parameters.AddWithValue("@tendanhmuc", txttendm.Text);

                // Kiểm tra trạng thái trước khi lưu
                string trangThai = cbttdm.SelectedItem.ToString();
                cmd.Parameters.AddWithValue("@trangthai", trangThai);

                cmd.Parameters.AddWithValue("@mota", txtmotadm.Text);

              
                cmd.ExecuteNonQuery();
                ketnoi.Close();
                load_DanhMuc();
                MessageBox.Show("Them thong tin thanh cong!", "Thong bao");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Loi:" + ex.Message, "Loi");
            }
        }


        private void btchonanh_Click(object sender, EventArgs e)
        {
            
                
        }

        private void dtdanhmucsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dtdanhmucsanpham.Rows.Count) return;
            DataGridViewRow row = dtdanhmucsanpham.Rows[e.RowIndex];

            txtmadm.Text = row.Cells[0].Value.ToString();
            txttendm.Text = row.Cells[1].Value.ToString();
            cbttdm.Text = row.Cells[2].Value.ToString();
            txtmotadm.Text = row.Cells[3].Value.ToString();
            
        }

        private void load_DanhMuc()
        {
            try
            {
                ketnoi.Open();
                string sql = @"select dm.MaDanhMuc, dm.TenDanhMuc, ISNULL(TrangThai, 'Không xác định') AS TrangThai, dm.MoTa from DanhMuc dm";
                SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);      

                dtdanhmucsanpham.DataSource = dt;
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi tai danh muc :" + ex.Message, "loi");
            }
            finally
            {
                ketnoi.Close();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if(dtdanhmucsanpham.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon thong tin can sua!", "Thong bao"); return;
            }

            //lay thong tin tu cac o nhap du lieu
            string madanhmuc = txtmadm.Text.Trim();
            string tendanhmuc = txttendm.Text.Trim();
            string trangthai = cbttdm.SelectedItem.ToString();
            string mota = txtmotadm.Text.Trim();

            if (string.IsNullOrEmpty(madanhmuc)|| string.IsNullOrEmpty(tendanhmuc)|| string.IsNullOrEmpty(trangthai)|| string.IsNullOrEmpty(mota)){
                MessageBox.Show("Vui long dien day du thong tin!", "Thong bao");
                return;
            }

            ketnoi.Open();
            string sql = "update DanhMuc set TenDanhMuc = @tendanhmuc, TrangThai = @trangthai, MoTa = @mota where MaDanhMuc = @madanhmuc";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
            cmd.Parameters.Add("@madanhmuc", SqlDbType.VarChar, 10).Value = madanhmuc;
            cmd.Parameters.Add("@tendanhmuc", SqlDbType.NVarChar,100).Value = tendanhmuc;
            cmd.Parameters.Add("@trangthai", SqlDbType.NVarChar,50).Value = trangthai;
            cmd.Parameters.Add("@mota", SqlDbType.NVarChar,255).Value = mota; 

            int rowaff = cmd.ExecuteNonQuery();
            ketnoi.Close();
            if (rowaff > 0)
            {
                MessageBox.Show("Cap nhat thong tin thanh cong!", "Thong bao");
                load_DanhMuc();
            }
            else
            {
                MessageBox.Show("Khong cap nhat duoc thong tin!", "Loi");
            }
        }

        private void dtdanhmucsanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btload_Click(object sender, EventArgs e)
        {
            load_DanhMuc();
            xoatrang();
        }

        private void xoatrang()
        {
            txtmadm.Clear();
            txttendm.Clear();
            txtmotadm.Clear();
            cbttdm.SelectedItem = 0;

            tkmadm.Clear();
            tktendm.Clear();
            tkcbttdm.SelectedItem = 0;
        }
        private void btxoa_Click(object sender, EventArgs e)
        {
            if(dtdanhmucsanpham.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon thong tin can xoa!", "Thong Bao");
                return;
            }
            DialogResult kq = MessageBox.Show("Ban co chac muon xoa khong","Thong bao", MessageBoxButtons.OKCancel);

            if (kq == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                string madanhmuc = dtdanhmucsanpham.CurrentRow.Cells[0].Value.ToString();
                ketnoi.Open();
                string sql = "delete from DanhMuc where MaDanhMuc = @madanhmuc";
                SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
                cmd.Parameters.Add("@madanhmuc", SqlDbType.VarChar, 10).Value = madanhmuc;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoa thong tin thanh cong!", "Thong Bao");
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi xoa du lieu: " + ex.Message, "Loi");
            }
            finally
            {
                ketnoi.Close();
                xoatrang();
            }
            try
            {
                load_DanhMuc();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi khi tai du lieu :" + ex.Message, "Loi");
            }
        }

        private void LoadComboBoxTrangThaiTimKiem()
        {
            tkcbttdm.Items.Clear();
            tkcbttdm.Items.Add("Tất cả");
            tkcbttdm.Items.Add("Hoạt động");
            tkcbttdm.Items.Add("Tạm ngừng");
            tkcbttdm.SelectedIndex = 0; // Chọn giá trị mặc định "Tất cả"
        }

        private void bttk_Click(object sender, EventArgs e)
        {
            try
            {
                string madanhmuc = tkmadm.Text.Trim();
                string tendanhmuc = tktendm.Text.Trim();
                string trangthai;
                if(tkcbttdm.SelectedItem == null)
                {
                    trangthai = "";
                }
                else
                {
                    trangthai= tkcbttdm.SelectedItem.ToString();
                }
               
                string condition = "";
                // Nếu giá trị tìm kiếm không phải "Tất cả", thêm điều kiện lọc theo trang thái
                if (!string.IsNullOrEmpty(trangthai) && trangthai != "Tất cả")
                {
                    condition = " and TrangThai like N'%" + trangthai + "%'";
                }
                ketnoi.Open();
                string sql = "select * from DanhMuc where MaDanhMuc like '%" + madanhmuc + "%' and " +
                             "TenDanhMuc like N'%" + tendanhmuc + "%'" + condition;
                SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                System.Data.DataTable tb = new System.Data.DataTable();
                da.Fill(tb);
                cmd.Dispose();
                dtdanhmucsanpham.DataSource = tb;
                dtdanhmucsanpham.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không tải được dữ liệu: " + ex.Message, "Lỗi");
            }
            finally
            {
                ketnoi.Close();
                // Không xoá dữ liệu tìm kiếm nếu bạn muốn giữ lại điều kiện
                 xoatrang();
            }
        }

        private void btxuatfile_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ DataGridView (chỉ xuất những dữ liệu đang hiển thị)
                System.Data.DataTable dt = dtdanhmucsanpham.DataSource as System.Data.DataTable;
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

        private void btchonfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Chọn File Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtduongdanfile.Text = openFileDialog.FileName; // Hiển thị đường dẫn file trong textbox
            }
        }

        private void btnhapfile_Click(object sender, EventArgs e)
        {
            string filePath = txtduongdanfile.Text;

            if (string.IsNullOrWhiteSpace(filePath) || !System.IO.File.Exists(filePath))
            {
                MessageBox.Show("Vui lòng chọn file hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ImportExcelToGrid(filePath);  // Đọc dữ liệu vào DataGridView
            SaveImportedDataToDatabase(); // Lưu vào database
        }
        private void SaveImportedDataToDatabase()
        {
            if (dtdanhmucsanpham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để lưu vào database!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kết nối đến database
            ketnoi.Open();

            foreach (DataGridViewRow row in dtdanhmucsanpham.Rows)
            {
                if (row.IsNewRow) continue;  // Bỏ qua dòng trống cuối cùng của DataGridView

                string madanhmuc = row.Cells[0].Value.ToString();
                string tendanhmuc = row.Cells[1].Value.ToString();
                string trangthai = row.Cells[2].Value.ToString();
                string mota = row.Cells[3].Value.ToString();

                // Kiểm tra dữ liệu hợp lệ
                if (string.IsNullOrEmpty(madanhmuc) || string.IsNullOrEmpty(tendanhmuc) || string.IsNullOrEmpty(trangthai))
                {
                    MessageBox.Show("Dữ liệu không hợp lệ trong một số dòng, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }


                // Kiểm tra xem danh muc đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM DanhMuc WHERE MaDanhMuc = @madanhmuc";
                SqlCommand checkCmd = new SqlCommand(checkQuery, ketnoi.GetConnection());
                checkCmd.Parameters.AddWithValue("@madanhmuc", madanhmuc);
                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0) // Chưa có -> Thêm mới
                {
                    string insertQuery = "INSERT INTO DanhMuc (MaDanhMuc, TenDanhMuc, TrangThai, MoTa) VALUES (@madanhmuc, @tendanhmuc, @trangthai, @mota)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, ketnoi.GetConnection());
                    insertCmd.Parameters.AddWithValue("@madanhmuc", madanhmuc);
                    insertCmd.Parameters.AddWithValue("@tendanhmuc", tendanhmuc);
                    insertCmd.Parameters.AddWithValue("@trangthai", trangthai);
                    insertCmd.Parameters.AddWithValue("@mota", mota);

                    insertCmd.ExecuteNonQuery();
                }
                else // Đã tồn tại -> Cập nhật
                {
                    string updateQuery = "UPDATE DanhMuc SET TenDanhMuc=@tendanhmuc, TrangThai=@trangthai, MoTa=@mota, HinhAnh=@hinhanh WHERE MaDanhMuc=@madanhmuc";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, ketnoi.GetConnection());
                    updateCmd.Parameters.AddWithValue("@madanhmuc", madanhmuc);
                    updateCmd.Parameters.AddWithValue("@tendanhmuc", tendanhmuc);
                    updateCmd.Parameters.AddWithValue("@trangthai", trangthai);
                    updateCmd.Parameters.AddWithValue("@mota", mota);

                    updateCmd.ExecuteNonQuery();
                }
            }

            ketnoi.Close();
            MessageBox.Show("Lưu dữ liệu vào database thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            load_DanhMuc(); // Cập nhật lại danh sách danh muc sau khi nhập
        }

        // 📌 Hàm nhập dữ liệu từ file Excel vào DataGridView
        private void ImportExcelToGrid(string filePath)
        {
            // Mở file Excel ở chế độ chỉ đọc để tránh bị khóa
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var workbook = new XLWorkbook(stream))
            {
                var worksheet = workbook.Worksheet(1); // Chọn Sheet đầu tiên
                var range = worksheet.RangeUsed();
                var table = new System.Data.DataTable();

                // Đọc tiêu đề cột từ dòng đầu tiên
                var headerRow = range.FirstRowUsed();
                foreach (var cell in headerRow.Cells())
                {
                    table.Columns.Add(cell.GetString());
                }

                // Đọc dữ liệu từ các dòng còn lại (bắt đầu từ dòng thứ 2)
                foreach (var row in range.RowsUsed().Skip(1))
                {
                    // Tạo mảng giá trị có số lượng phần tử bằng số cột
                    object[] values = new object[table.Columns.Count];
                    for (int i = 1; i <= table.Columns.Count; i++)
                    {
                        values[i - 1] = row.Cell(i).GetString();
                    }
                    table.Rows.Add(values);
                }

                // Hiển thị DataTable lên DataGridView
                dtdanhmucsanpham.DataSource = table;
            }
        }
    }
    }
