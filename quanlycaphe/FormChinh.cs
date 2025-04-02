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

        }
        public void loadform(object Form)
        {
            if (this.panel1.Controls.Count > 0)
            {
                this.panel1.Controls.RemoveAt(0);
            }
            Form fh = Form as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fh);
            this.panel1.Tag = fh;
            fh.Show();
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
            loadform(new DonHang());
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
    }
}
