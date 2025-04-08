using DocumentFormat.OpenXml.VariantTypes;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace quanlycaphe
{
    public partial class TongQuan : Form
    {
        ketnoicuadiem ketnoi = new ketnoicuadiem();
        private DateTimePicker dtpNgay = new DateTimePicker();
        public TongQuan()
        {
            InitializeComponent();
            dtpNgay.Location = new Point(10, 10);
            this.Controls.Add(dtpNgay);
            try
            {
                ketnoi.Open();
                ketnoi.Close();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu. Vui lòng kiểm tra lại:" + ex.Message);
            }
        }

        private void trangchu_Click(object sender, EventArgs e)
        {
            FormChinh f = new FormChinh();
            f.ShowDialog();
            this.Hide();
        }
        //khoi tao du lieu ban dau
        private void Tongquan_Load()
        {

        }
        private void btngay_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtngaydau.Value.Date;
            LoadData(selectedDate, selectedDate);
            HienThiBieuDo(selectedDate, selectedDate);
        }
        //Ham lay du lieu tu sql
        private void LoadData(DateTime fromDate, DateTime toDate)
        {
            ketnoi.Open();
            string sql = @"SELECT SUM(dh.TongTien) as TongDoanhSo,COUNT(DISTINCT dh.MaDonHang) as SoLuongDonHang FROM DonHang dh JOIN ChiTietDonHang ct ON dh.MaDonHang = ct.MaDonHang WHERE dh.NgayDat BETWEEN @fromDate AND @toDate";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
            cmd.Parameters.AddWithValue("@fromDate", fromDate);
            cmd.Parameters.AddWithValue("@toDate", toDate);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tbtongdoanhso.Text = reader["TongDoanhSo"] != DBNull.Value ? reader["TongDoanhSo"].ToString() : "0";
              //  tbtongloinhuan.Text = reader["TongLoiNhuan"] != DBNull.Value ? reader["TongLoiNhuan"].ToString() : "0";
                tbtongdonhang.Text = reader["SoLuongDonHang"] != DBNull.Value ? reader["SoLuongDonHang"].ToString() : "0";
               // tbdonhuy.Text = reader["SoLuongDonHang"] != DBNull.Value ? reader["SoLuongDonHang"].ToString() : "0";
            }
            else
            {
                tbtongdoanhso.Text = "0";
              ///  tbtongloinhuan.Text = "0";
                tbtongdonhang.Text = "0";
            }
            reader.Close();
            ketnoi.Close();
        }
        private DataTable LayDuLieuTuSQL(DateTime fromDate, DateTime toDate)
        {
            ketnoi.Open();
            string sql = @"
SELECT 
    SUM(dh.TongTien) AS TongDoanhSo,
    COUNT(DISTINCT dh.MaDonHang) AS SoLuongDonHang
FROM DonHang dh
JOIN ChiTietDonHang ct ON ct.MaDonHang = dh.MaDonHang
WHERE dh.NgayDat BETWEEN @fromDate AND @toDate";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.GetConnection());
            cmd.Parameters.AddWithValue("@fromDate", fromDate);
            cmd.Parameters.AddWithValue("@toDate", toDate);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.Close();
            return dt;
        }
        private void HienThiBieuDo(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = LayDuLieuTuSQL(fromDate, toDate);
            chartdoanhso.Series.Clear();
            chartdoanhso.ChartAreas.Clear();
            chartdoanhso.ChartAreas.Add("MainArea");

            // 3 series cho 3 chỉ số
            var sDoanhSo = new Series("Doanh số") { ChartType = SeriesChartType.Column };
          //  var sLoiNhuan = new Series("Lợi nhuận") { ChartType = SeriesChartType.Column };

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                double doanhSo = row["TongDoanhSo"] != DBNull.Value ? Convert.ToDouble(row["TongDoanhSo"]) : 0;
                //double loiNhuan = row["TongLoiNhuan"] != DBNull.Value ? Convert.ToDouble(row["TongLoiNhuan"]) : 0;
              

                // Thêm 1 điểm duy nhất với label tương ứng
                sDoanhSo.Points.AddXY("Doanh số", doanhSo);
             //   sLoiNhuan.Points.AddXY("Lợi nhuận", loiNhuan);
              
            }

            // Thêm vào chart
            chartdoanhso.Series.Add(sDoanhSo);
           // chartdoanhso.Series.Add(sLoiNhuan);
         

            // Optionally: căn đều khoảng cách, hiển thị giá trị trên cột
            foreach (var s in chartdoanhso.Series)
            {
                s.IsValueShownAsLabel = true;
            }
        }

        private void btweek_Click(object sender, EventArgs e)
        {
            DateTime todate = DateTime.Today;
            DateTime fromdate = todate.AddDays(-7);

            //cap nhat datepicker
            dtngaydau.Value = fromdate;
            dtngaycuoi.Value = todate;

            LoadData(fromdate, todate);
            HienThiBieuDo(fromdate, todate);
        }

        private void btmonth_Click(object sender, EventArgs e)
        {
            DateTime todate = DateTime.Today;
            DateTime fromdate = todate.AddDays(-30);

            //cap nhat datepicker
            dtngaydau.Value = fromdate;
            dtngaycuoi.Value = todate;

            LoadData(fromdate, todate);
            HienThiBieuDo(fromdate, todate);
        }

        private void bt90day_Click(object sender, EventArgs e)
        {
            DateTime todate = DateTime.Today;
            DateTime fromdate = todate.AddDays(-90);

            //cap nhat datepicker
            dtngaydau.Value = fromdate;
            dtngaycuoi.Value = todate;

            LoadData(fromdate, todate);
            HienThiBieuDo(fromdate, todate);
        }
    }
}
    
  
