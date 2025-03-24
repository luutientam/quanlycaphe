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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBoxMatKhau.UseSystemPasswordChar)
            {
                textBoxMatKhau.UseSystemPasswordChar = false;
                pictureBox1.Image = Image.FromFile(@"icon\eye_open.jpg");//1q Thay bằng icon mắt mở
            }
            else
            {
                textBoxMatKhau.UseSystemPasswordChar = true;
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\icon\eye_closed.png");// Thay bằng icon mắt đóng
            }
        }
    }
}
