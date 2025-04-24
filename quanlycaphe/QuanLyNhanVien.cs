using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Office.Interop.Excel;
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
using els = Microsoft.Office.Interop.Excel;

namespace quanlycaphe
{
    public partial class QuanLyNhanVien: Form
    {
        //ket noi sql
        ketnoicuadiem ketnoi = new ketnoicuadiem();

        public QuanLyNhanVien()
        {
            InitializeComponent();
            // Đảm bảo panel ẩn ngay khi khởi tạo form
            pnthemnhanvien.Visible = false;
            pnsuathongtin.Visible = false;
            load_nhanvien();
            load_gioitinh();
            load_mataikhoan();
            load_taikhoan();
            load_trangthai();
            load_gioitinhtk();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            // Nếu chưa đặt trong constructor, có thể đảm bảo lại tại đây
            pnthemnhanvien.Visible = false;
            pnsuathongtin.Visible = false;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tsvaitro_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            // Hiển thị panel
            pnthemnhanvien.Visible = true;
            pnthemnhanvien.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Vui long lien he voi 19001858 de tro giup!");

        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            FormChinh formchinh = new FormChinh();
            formchinh.Show();

            //an form hien tai, neu ban muon dong toanbo thi dung close
            this.Hide();
            //this.Close();
        }


        private void button8_Click_1(object sender, EventArgs e)
        {
            // Ẩn panel
            pnthemnhanvien.Visible = false;
        
        }

        private void load_gioitinh()
        {
            cbgioitinh.Items.Clear();
            cbgioitinh.Items.Add("Chọn giới tính");
            cbgioitinh.Items.Add("Nam");
            cbgioitinh.Items.Add("Nữ");
            cbgioitinh.SelectedIndex = 0;

        }

        private void load_trangthai()
        {
            cbtrangthai.Items.Clear();
            cbtrangthai.Items.Add("Chọn trạng thái");
            cbtrangthai.Items.Add("Hoạt động");
            cbtrangthai.Items.Add("Khóa");
            cbtrangthai.SelectedIndex = 0;//dua ve trang thia mac dinh = 0
        }
        private void load_mataikhoan()
        {    
        }
        private void load_gioitinhtk()
        {
            tkcbgt.Items.Clear();
            tkcbgt.Items.Add("Chọn giới tính");
            tkcbgt.Items.Add("Nam");
            tkcbgt.Items.Add("Nữ");
            tkcbgt.SelectedIndex = 0;
        }
     
        private void btxacnhan_Click(object sender, EventArgs e)
        {
            try
            {
                string manhanvien = txtmanhanvien.Text.Trim();
                string tennhanvien = txttennhanvien.Text.Trim();
                string sdt = txtsdt.Text.Trim();
                DateTime ngaysinh = dtdate.Value;
                string diachi = txtdiachi.Text.Trim();
                string gioitinh = cbgioitinh.SelectedItem.ToString();
                string mataikhoan = txtmataikhoan.Text.Trim();
                string tendangnhap = txttendangnhap.Text.Trim();
                string matkhau = txtmatkhau.Text.Trim();
                string email = txtemail.Text.Trim();
                DateTime ngaytao = dtngaytao.Value;
                string trangthai = cbtrangthai.SelectedItem.ToString();
                if (cbtrangthai.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui long chon trang thai!", "loi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (sdt.Length != 10 || !sdt.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại phải đủ 10 số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Đảm bảo đóng kết nối trong mọi trường hợp
                if (ketnoi.GetConnection().State != ConnectionState.Open)
                    ketnoi.Open();

                //bat đau transaction de dam bao toan ven du lieu
                SqlTransaction transaction = ketnoi.GetConnection().BeginTransaction();


                try
                {
                    //luu vao bang tai khoan truoc (bang cha)
                    string sqlTaiKhoan = "insert into TaiKhoan (MaTaiKhoan, TenDangNhap, MatKhau, Email, NgayTao, TrangThai)" +
                        "values (@mataikhoan, @tendangnhap, @matkhau, @email,@ngaytao, @trangthai) ";
                    SqlCommand cmd1 = new SqlCommand(sqlTaiKhoan, ketnoi.GetConnection(), transaction);
                    cmd1.Parameters.Add("@mataikhoan", SqlDbType.VarChar, 50).Value = mataikhoan;
                    cmd1.Parameters.Add("@tendangnhap", SqlDbType.NVarChar, 50).Value = tendangnhap;
                    cmd1.Parameters.Add("@matkhau", SqlDbType.NVarChar, 50).Value = matkhau;
                    cmd1.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email;
                    cmd1.Parameters.Add("@ngaytao", SqlDbType.Date).Value = ngaytao;
                    cmd1.Parameters.Add("@trangthai", SqlDbType.NVarChar, 50).Value = trangthai;
                    cmd1.ExecuteNonQuery();

                    //luu vao bang nhanvien sau (bang con co khoa ngoai mataikhoan)
                    string sql = "insert into NhanVien (MaNhanVien, TenNhanVien, SoDienThoai, DiaChi, MaTaiKhoan, NgaySinh, GioiTinh) " +
                    "Values (@manhanvien, @tennhanvien, @sdt, @diachi, @mataikhoan, @ngaysinh, @gioitinh)";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection(), transaction);
                    cmd.Parameters.Add("@manhanvien", SqlDbType.VarChar, 50).Value = manhanvien;
                    cmd.Parameters.Add("@tennhanvien", SqlDbType.NVarChar, 100).Value = tennhanvien;
                    cmd.Parameters.Add("@sdt", SqlDbType.NVarChar, 50).Value = sdt;
                    cmd.Parameters.Add("@diachi", SqlDbType.NVarChar, 100).Value = diachi;
                    cmd.Parameters.Add("@mataikhoan", SqlDbType.NVarChar, 50).Value = mataikhoan;
                    cmd.Parameters.Add("@ngaysinh", SqlDbType.Date).Value = ngaysinh;
                    cmd.Parameters.Add("@gioitinh", SqlDbType.NVarChar, 10).Value = gioitinh;
                    cmd.ExecuteNonQuery();

                    //commit transaction neu ca 2 lenh thanh cong
                    transaction.Commit();
                    MessageBox.Show("Them nhan vien va tai khoan thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    //rollback neu co loi
                    transaction.Rollback();
                    MessageBox.Show("Loi:" + ex.Message, "loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Đảm bảo đóng kết nối trong mọi trường hợp
        if (ketnoi.GetConnection().State == ConnectionState.Open)
                        ketnoi.Close();
                    load_nhanvien(); //load lai danh sach nhan vien
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi" + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_taikhoan()
        {
            try
            {
                // Đảm bảo đóng kết nối trong mọi trường hợp
                if (ketnoi.GetConnection().State != ConnectionState.Open)
                    ketnoi.Open();
                string sql = @"select tk.MaTaiKhoan, tk.TenDangNhap, tk.MatKhau, tk.Email,tk.NgayTao, tk.TrangThai from TaiKhoan tk";
                SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
               // dtnhanvien.DataSource = dt;
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi:" + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                // Đảm bảo đóng kết nối trong mọi trường hợp
                if (ketnoi.GetConnection().State == ConnectionState.Open)
                    ketnoi.Close();
            }
        }
        private void load_nhanvien()
        {
            try
            {
                // Đảm bảo đóng kết nối trong mọi trường hợp
                if (ketnoi.GetConnection().State != ConnectionState.Open)
                    ketnoi.Open();
                string sql = @"SELECT nv.MaNhanVien, nv.TenNhanVien, nv.SoDienThoai, nv.DiaChi, nv.MaTaiKhoan, nv.NgaySinh, nv.GioiTinh FROM NhanVien nv";
                SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                //dua du lieu vao datagridview
                dtnhanvien.DataSource = dt;
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            finally 
            {
                // Đảm bảo đóng kết nối trong mọi trường hợp
                if (ketnoi.GetConnection().State == ConnectionState.Open)
                    ketnoi.Close();
            }

        }

        private void dtnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Bỏ qua click vào header hoặc các vùng không phải row dữ liệu
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dtnhanvien.Rows[e.RowIndex];

            // Chỉ điền dữ liệu khi panel sửa đang hiển thị
            if (pnsuathongtin.Visible)
            {
                txtsuamanv.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtsuatennv.Text = row.Cells["TenNhanVien"].Value.ToString();
                txtsuasdt.Text = row.Cells["SoDienThoai"].Value.ToString();

                if (DateTime.TryParse(row.Cells["NgaySinh"].Value.ToString(), out DateTime ngaysinh))
                {
                    dtsuadate.Value = ngaysinh;
                }

                txtsuadiachi.Text = row.Cells["DiaChi"].Value.ToString();
                txtsuamatk.Text = row.Cells["MaTaiKhoan"].Value.ToString();
                cbsuagt.SelectedItem = row.Cells["GioiTinh"].Value.ToString();
            }

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //kiem tra co dong nao duoc chon khong
                if (dtnhanvien.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui long chon nhan vien can sua!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                pnthemnhanvien.Visible = false;
                // Hiển thị panel
                pnsuathongtin.Visible = true;
                pnsuathongtin.BringToFront();

                // Khởi tạo danh sách cho ComboBox trong panel chỉnh sửa
                load_sua_gioitinh();
                load_sua_trangthai();

                //lay du lieu tu datagridview tu dong duoc chon
                DataGridViewRow row = dtnhanvien.SelectedRows[0];

                //dien thong tin vao ca controls tren panel sua
                txtsuamanv.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtsuatennv.Text = row.Cells["TenNhanVien"].Value.ToString();
                txtsuasdt.Text = row.Cells["SoDienThoai"].Value.ToString();
                if (DateTime.TryParse(row.Cells["NgaySinh"].Value.ToString(), out DateTime ngaysinh))
                {
                    dtsuadate.Value = ngaysinh;
                }
                else
                {
                    dtsuadate.Value = DateTime.Now;
                }
                txtsuadiachi.Text = row.Cells["DiaChi"].Value.ToString();
                txtsuamatk.Text = row.Cells["MaTaiKhoan"].Value.ToString();
                txtsuamatk.Enabled = false;
                cbsuagt.SelectedItem = row.Cells["GioiTinh"].Value.ToString();
                

                string mataikhoan = row.Cells["MaTaiKhoan"].Value.ToString();
                if (!string.IsNullOrEmpty(mataikhoan))
                {
                    load_laythongtintaikhoan(mataikhoan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo form:" + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_laythongtintaikhoan(string matk)
        {
            //lay thong tin tai khoan tu database
            try
            {
                if (ketnoi.GetConnection().State != ConnectionState.Open)
                    ketnoi.Open();
                string sqltaikhoan1 = "select TenDangNhap, MatKhau, Email, NgayTao, TrangThai from TaiKhoan where MaTaiKhoan = @matk";
                SqlCommand cmd1 = new SqlCommand(sqltaikhoan1, ketnoi.GetConnection());
                cmd1.Parameters.Add("@matk", SqlDbType.VarChar, 50).Value = matk;

                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //dien thong tin tai khoan
                        txtsuatendn.Text = reader["TenDangNhap"].ToString();
                        txtsuamk.Text = reader["MatKhau"].ToString();
                        txtsuaemail.Text = reader["Email"].ToString();
                        if (DateTime.TryParse(reader["NgayTao"].ToString(), out DateTime ngaytao))
                        {
                            dtsuangaytao.Value = ngaytao;
                        }
                        cbsuatrangthai.SelectedItem = reader["TrangThai"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi khi tai thong tin tai khoan :" + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (ketnoi.GetConnection().State == ConnectionState.Open)
                    ketnoi.Close();
            }
        }

        private void load_sua_gioitinh()
        {
            cbsuagt.Items.Clear();
            cbsuagt.Items.Add("Nam");
            cbsuagt.Items.Add("Nữ");
            // Không cần "Chọn giới tính" vì đây là chỉnh sửa, không phải thêm mới
        }

        private void load_sua_trangthai()
        {
            cbsuatrangthai.Items.Clear();
            cbsuatrangthai.Items.Add("Hoạt động");
            cbsuatrangthai.Items.Add("Khóa");
            // Không cần "Chọn trạng thái" vì đây là chỉnh sửa
        }
        private void btsuatt_Click(object sender, EventArgs e)
        {
            try
            {
                //lay du lieu tu form
                string manhanvien = txtsuamanv.Text.Trim();
                string tennhanvien = txtsuatennv.Text.Trim();
                string sodienthoai = txtsuasdt.Text.Trim();
                string diachi = txtsuadiachi.Text.Trim();
                DateTime ngaysinh = dtsuadate.Value;
                string gioitinh = cbsuagt.SelectedItem.ToString();
                string mataikhoan = txtsuamatk.Text.Trim();
                string tendangnhap = txtsuatendn.Text.Trim();
                string matkhau = txtsuamk.Text.Trim();
                string email = txtsuaemail.Text.Trim();
                DateTime ngaytao = dtsuangaytao.Value;
                string trangthai = cbsuatrangthai.SelectedItem.ToString();

                if (string.IsNullOrEmpty(mataikhoan))
                {
                    MessageBox.Show("Mã tài khoản không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem giới tính và trạng thái có được chọn không
                if (string.IsNullOrEmpty(gioitinh) || string.IsNullOrEmpty(trangthai))
                {
                    MessageBox.Show("Vui lòng chọn giới tính và trạng thái!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //ket noi sql
                if (ketnoi.GetConnection().State != ConnectionState.Open)
                    ketnoi.Open();
                SqlTransaction transaction = ketnoi.GetConnection().BeginTransaction();

                try
                {
                    //cap nhat thong tin nhan vien 
                    string sqlnv = @"update NhanVien set TenNhanVien = @tennhanvien, SoDienThoai = @sodienthoai, DiaChi = @diachi, NgaySinh = @ngaysinh, GioiTinh = @gioitinh  where MaNhanVien = @manhanvien";
                    SqlCommand cmdnv = new SqlCommand(sqlnv, ketnoi.GetConnection(), transaction);
                    cmdnv.Parameters.AddWithValue("@tennhanvien", tennhanvien);
                    cmdnv.Parameters.AddWithValue("@sodienthoai", sodienthoai);
                    cmdnv.Parameters.AddWithValue("@diachi", diachi);
                    cmdnv.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                    cmdnv.Parameters.AddWithValue("@gioitinh",gioitinh);
                    cmdnv.Parameters.AddWithValue("@manhanvien", manhanvien);
                    cmdnv.ExecuteNonQuery();

                    //cap nhat thong tin tai khoan
                    string sqltk = @"update TaiKhoan set TenDangNhap = @tendangnhap, MatKhau = @matkhau, Email = @email, NgayTao = @ngaytao, TrangThai = @trangthai  where MaTaiKhoan = @mataikhoan ";
                    SqlCommand cmdtk = new SqlCommand(sqltk, ketnoi.GetConnection(), transaction);
                    cmdtk.Parameters.AddWithValue("@tendangnhap", tendangnhap);
                    cmdtk.Parameters.AddWithValue("@matkhau",matkhau);
                    cmdtk.Parameters.AddWithValue("@email", email);
                    cmdtk.Parameters.AddWithValue("@ngaytao",ngaytao);
                    cmdtk.Parameters.AddWithValue("@trangthai", trangthai);
                    cmdtk.Parameters.AddWithValue("@mataikhoan", mataikhoan);
                    cmdtk.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Cap nhat thong tin thanh cong!");
                    load_nhanvien();
                    load_taikhoan();
                    pnsuathongtin.Visible = false;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: "+ex.Message);
            }
            finally
            {
                if (ketnoi.GetConnection().State == ConnectionState.Open)
                    ketnoi.Close();
            }
            
        }

        private void bthuytt_Click(object sender, EventArgs e)
        {
            // Ẩn panel
            pnsuathongtin.Visible = false;
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Ban co chac chan muon xoa khong?", "Thong Bao", MessageBoxButtons.OKCancel);
            if (kq == DialogResult.Cancel)
            {
                return;
            }

            string manhanvien = dtnhanvien.CurrentRow.Cells[0].Value.ToString();
            if(ketnoi.GetConnection().State != ConnectionState.Open)
            {
                ketnoi.Open();
            }
            string sql = "delete from NhanVien where MaNhanVien = @manhanvien";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
            cmd.Parameters.Add("@manhanvien", SqlDbType.VarChar,10).Value = manhanvien;
            cmd.ExecuteNonQuery();
            load_nhanvien();
            load_taikhoan();
            cmd.Dispose();
            if(ketnoi.GetConnection().State == ConnectionState.Open)
            {
                ketnoi.Close();
            }
        }

        private void btxuat_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy DataTable từ DataGridView
                System.Data.DataTable dataTable = (System.Data.DataTable)dtnhanvien.DataSource;

                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi phương thức xuất Excel
                ExportExcel(dataTable, "Danh sách nhân viên");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportExcel(System.Data.DataTable dataTable, string sheetname)
        {
            try
            {
                // Tạo các đối tượng Excel
                els.Application oExcel = new els.Application();
                els.Workbook oBook = oExcel.Workbooks.Add(Type.Missing);
                els.Worksheet oSheet = (els.Worksheet)oBook.Worksheets[1];
                oSheet.Name = sheetname;

                // Tạo phần tiêu đề
                els.Range head = oSheet.get_Range("A1", "G1");
                head.MergeCells = true;
                head.Value2 = "THỐNG KÊ NHÂN VIÊN";
                head.Font.Bold = true;
                head.Font.Name = "Tahoma";
                head.Font.Size = 18;
                head.HorizontalAlignment = els.XlHAlign.xlHAlignCenter;

                // Tạo tiêu đề cột
                string[] headers = new string[] {
            "MÃ NHÂN VIÊN", "HỌ VÀ TÊN", "SỐ ĐIỆN THOẠI",
            "NGÀY SINH", "ĐỊA CHỈ", "MÃ TÀI KHOẢN", "GIỚI TÍNH"
        };

                for (int i = 0; i < headers.Length; i++)
                {
                    oSheet.Cells[3, i + 1] = headers[i];
                    ((els.Range)oSheet.Cells[3, i + 1]).ColumnWidth = 20;
                }

                // Định dạng tiêu đề cột
                els.Range rowHead = oSheet.get_Range("A3", "G3");
                rowHead.Font.Bold = true;
                rowHead.Borders.LineStyle = els.XlLineStyle.xlContinuous;
                rowHead.Interior.ColorIndex = 15;
                rowHead.HorizontalAlignment = els.XlHAlign.xlHAlignCenter;

                // Đổ dữ liệu từ DataTable vào Excel
                for (int r = 0; r < dataTable.Rows.Count; r++)
                {
                    for (int c = 0; c < dataTable.Columns.Count; c++)
                    {
                        object value = dataTable.Rows[r][c];

                        // Xử lý kiểu DateTime (Ngày sinh)
                        if (value is DateTime)
                        {
                            oSheet.Cells[r + 4, c + 1] = ((DateTime)value).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            oSheet.Cells[r + 4, c + 1] = value?.ToString() ?? "";
                        }
                    }
                }

                // Định dạng toàn bộ vùng dữ liệu
                els.Range dataRange = oSheet.get_Range("A4", $"G{dataTable.Rows.Count + 3}");
                dataRange.Borders.LineStyle = els.XlLineStyle.xlContinuous;

                // Hiển thị Excel
                oExcel.Visible = true;
                oExcel.UserControl = true;

                // Release các đối tượng COM
                System.Runtime.InteropServices.Marshal.ReleaseComObject(dataRange);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(rowHead);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(head);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportExcel(System.Data.DataTable tb, string sheetname, els.Workbook oSheet)
        {
           
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btntk_Click(object sender, EventArgs e)
        {
            ////lay thong tin tim kiem
            //string manhanvien = tkmanv.Text.Trim();
            //string tennhanvien = tktennv.Text.Trim();
            //string gioitinh;
            //if(tkcbgt.SelectedItem == null)
            //{
            //    gioitinh = "";
            //}
            //else
            //{
            //    gioitinh= tkcbgt.SelectedItem.ToString();
            //}


            ////ket noi sql
            //if (ketnoi.GetConnection().State != ConnectionState.Open)
            //{
            //    ketnoi.Open();
            //}
            //string sql = "select * from NhanVien where MaNhanVien like '%" + manhanvien + "%' and TenNhanVien like '%" + tennhanvien + "%' and GioiTinh like '%" + gioitinh + "%'";
            //SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
            //cmd.Parameters.AddWithValue("@manv", "%" + manhanvien + "%");
            //cmd.Parameters.AddWithValue("@tennv", "%" + tennhanvien + "%");
            //cmd.Parameters.AddWithValue("@gt", "%" + gioitinh + "%");
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //adapter.SelectCommand = cmd;
            //System.Data.DataTable dt = new System.Data.DataTable();
            //adapter.Fill(dt);

            //if(ketnoi.GetConnection().State == ConnectionState.Open)
            //{
            //    ketnoi.Close();
            //}
            //dtnhanvien.DataSource =dt;
            //dtnhanvien.Refresh();
            try
            {
                // Lấy thông tin tìm kiếm
                string manhanvien = tkmanv.Text.Trim();
                string tennhanvien = tktennv.Text.Trim();
                string gioitinh = tkcbgt.SelectedItem?.ToString() ?? "";
                if (gioitinh == "Chọn giới tính") gioitinh = "";

                // Kết nối SQL
                if (ketnoi.GetConnection().State != ConnectionState.Open)
                    ketnoi.Open();

                // Xây dựng câu lệnh SQL
                string sql = "SELECT * FROM NhanVien WHERE 1=1"; // Sử dụng 1=1 để dễ thêm điều kiện
                if (!string.IsNullOrEmpty(manhanvien))
                    sql += " AND MaNhanVien LIKE @manv";
                if (!string.IsNullOrEmpty(tennhanvien))
                    sql += " AND TenNhanVien LIKE @tennv";
                if (!string.IsNullOrEmpty(gioitinh))
                    sql += " AND GioiTinh = @gt";

                SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
                if (!string.IsNullOrEmpty(manhanvien))
                    cmd.Parameters.AddWithValue("@manv", "%" + manhanvien + "%");
                if (!string.IsNullOrEmpty(tennhanvien))
                    cmd.Parameters.AddWithValue("@tennv", "%" + tennhanvien + "%");
                if (!string.IsNullOrEmpty(gioitinh))
                    cmd.Parameters.AddWithValue("@gt", gioitinh);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);

                // Gán dữ liệu vào DataGridView
                dtnhanvien.DataSource = dt;
                dtnhanvien.Refresh();

                // Thông báo nếu không tìm thấy
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (ketnoi.GetConnection().State == ConnectionState.Open)
                    ketnoi.Close();
            }
        }

        private void txtsuasdt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
