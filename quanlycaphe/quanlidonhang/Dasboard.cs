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

namespace quanlycaphe.quanlidonhang
{
    public partial class Dasboard : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=VUATAM\SQLEXPRESS;Initial Catalog=quanlycafe;Integrated Security=True;Encrypt=True");

        public Dasboard()
        {
            InitializeComponent();
            loadDonHang();
            disableTextBox();
            nhapExcel.Enabled = false;
            buttonCapNhat.Enabled = false;
            buttonXoa.Enabled = false;
            xuatExcel.Enabled = false;
        }

        public void loadDonHang()
        {
            // load don hang len datagridview
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "select * from DonHang";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            dgvDanhSachHoaDon.DataSource = tb;
            dgvDanhSachHoaDon.Refresh();
        }


        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKhuyenMai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonThemMoi_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {

        }
    }
}
