using DocumentFormat.OpenXml.Drawing.ChartDrawing;
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
        private Timer timer;

        public FormChinh()
        {
            InitializeComponent();
            if (User.MaNhanVien == null)
            {
                lblHoTen.Text = "" + User.TenNguoiDung + " _ " + User.TenVaiTro;
                //label2.Text = "Quyền: " + User.MaVaiTro;
                //label3.Text = "Mã: " + User.MaNguoiDung;
            }
            else
            {
                lblHoTen.Text = "" + User.TenNhanVien + " _  Nhân viên";
                //label2.Text = "Quyền: Nhân viên";
                //label3.Text = "Mã: " + User.MaNhanVien;
            }
            lblTime.Text = "" + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            //// Tạo và cấu hình Timer để cập nhật thời gian
            timer = new Timer();
            timer.Interval = 1000; // 1 giây
            timer.Tick += timer1_Tick;
            timer.Start();

            loadform(new ht());

        }
        public void defaultColorItem()
        {
            MenuNguoiDung.BackColor = Color.Beige;
            MenuSanPham.BackColor = Color.Beige;
            sảnPhẩmToolStripMenuItem1.BackColor = Color.Beige;
            danhMụcSảnPhẩmToolStripMenuItem.BackColor = Color.Beige;
            MenuDonHang.BackColor = Color.Beige;
            MenuKH.BackColor = Color.Beige;
            MenuBan.BackColor = Color.Beige;
            MenuNCC.BackColor = Color.Beige;
            MenuBC.BackColor = Color.Beige;
            MenuKM.BackColor = Color.Beige;
            nhânViênToolStripMenuItem.BackColor = Color.Beige;
            vaiTròToolStripMenuItem.BackColor = Color.Beige;
            tổngQuanToolStripMenuItem.BackColor = Color.Beige;
            báoCáoDoanhThuToolStripMenuItem.BackColor = Color.Beige;
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
            defaultColorItem();
            MenuNguoiDung.BackColor = Color.PeachPuff;
        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loadform(new SanPham());
            defaultColorItem();
            sảnPhẩmToolStripMenuItem1.BackColor = Color.PeachPuff;
            MenuSanPham.BackColor = Color.PeachPuff;
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new DanhMucSanPham());
            defaultColorItem();
            danhMụcSảnPhẩmToolStripMenuItem.BackColor = Color.PeachPuff;
            MenuSanPham.BackColor = Color.PeachPuff;
        }

        private void MenuDonHang_Click(object sender, EventArgs e)
        {
            loadform(new quanlidonhang.Dasboard()); // Đảm bảo Dasboard kế thừa từ Form
            defaultColorItem();
            MenuDonHang.BackColor = Color.PeachPuff;

        }


        private void MenuKH_Click(object sender, EventArgs e)
        {
            loadform(new KhachHang());
            defaultColorItem();
            MenuKH.BackColor = Color.PeachPuff;
        }

        private void MenuBan_Click(object sender, EventArgs e)
        {
            loadform(new QuanLyBan());
            defaultColorItem();
            MenuBan.BackColor = Color.PeachPuff;
        }

        private void MenuNCC_Click(object sender, EventArgs e)
        {
            loadform(new NhaCungCap());
            defaultColorItem();
            MenuNCC.BackColor = Color.PeachPuff;
        }

        private void MenuBC_Click(object sender, EventArgs e)
        {
            loadform(new BaoCao());
            defaultColorItem();
            MenuBC.BackColor = Color.PeachPuff;
        }

        private void MenuKM_Click(object sender, EventArgs e)
        {
            loadform(new KhuyenMai());
            defaultColorItem();
            MenuKM.BackColor = Color.PeachPuff;
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new QuanLyNhanVien());
            defaultColorItem();
            nhânViênToolStripMenuItem.BackColor = Color.PeachPuff;
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DangNhap dangNhap = new DangNhap();
                dangNhap.Show();
                this.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            loadform(new ht());
            defaultColorItem();
        }

        private void vaiTròToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new VaiTro());
            defaultColorItem();
            vaiTròToolStripMenuItem.BackColor = Color.PeachPuff;
        }

        private void tổngQuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new TongQuan());
            defaultColorItem();
            MenuBC.BackColor = Color.PeachPuff;
            tổngQuanToolStripMenuItem.BackColor = Color.PeachPuff;
        }

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new BaoCao());
            defaultColorItem();
            MenuBC.BackColor = Color.PeachPuff;
            báoCáoDoanhThuToolStripMenuItem.BackColor = Color.PeachPuff;
        }

        private void MenuBC_Click_1(object sender, EventArgs e)
        {

        }
    }
}
