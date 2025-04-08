using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlycaphe
{
    public partial class FormChinh : Form
    {
        public FormChinh()
        {
            InitializeComponent();
            //if(User.MaNguoiDung != null)
            //{
            //    label1.Text = "Xin chào: " + User.TenNguoiDung;
            //    label2.Text = "Quyền: " + User.MaVaiTro;
            //    label3.Text = "Mã: " + User.MaNguoiDung;
            //}
            //else
            //{
            //    label1.Text = "Xin chào: " + User.TenNhanVien;
            //    label2.Text = "Quyền: Nhân viên";
            //    label3.Text = "Mã: " + User.MaNhanVien;
            //}
            //label3.Text = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");

        }
        public void loadform(Form form)
        {
            if (form == null) return; // Tránh lỗi khi truyền vào null

            if (this.panel1.Controls.Count > 0)
            {
                this.panel1.Controls.RemoveAt(0);
            }

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form);
            this.panel1.Tag = form;
            form.Show();
        }


        private void FormChinh_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void MenuNguoiDung_Click(object sender, EventArgs e)
        {
            loadform(new NguoiDung());
        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loadform(new SanPham());
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new DanhMucSanPham());
        }

        private void MenuDonHang_Click(object sender, EventArgs e)
        {
            loadform(new quanlidonhang.Dasboard()); // Đảm bảo Dasboard kế thừa từ Form
        }


        private void MenuKH_Click(object sender, EventArgs e)
        {
            loadform(new KhachHang());
        }

        private void MenuBan_Click(object sender, EventArgs e)
        {
            loadform(new QuanLyBan());
        }

        private void MenuNCC_Click(object sender, EventArgs e)
        {
            loadform(new NhaCungCap());
        }

        private void MenuBC_Click(object sender, EventArgs e)
        {
            loadform(new BaoCao());
        }

        private void MenuKM_Click(object sender, EventArgs e)
        {
            loadform(new KhuyenMai());
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new QuanLyNhanVien());
        }

        private void tổngQuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new TongQuan());
        }

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new BaoCao());
        }
    }
}
