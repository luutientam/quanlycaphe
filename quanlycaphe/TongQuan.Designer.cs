namespace quanlycaphe
{
    partial class TongQuan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtngaycuoi = new System.Windows.Forms.DateTimePicker();
            this.dtngaydau = new System.Windows.Forms.DateTimePicker();
            this.btweek = new System.Windows.Forms.Button();
            this.btmonth = new System.Windows.Forms.Button();
            this.bt90day = new System.Windows.Forms.Button();
            this.btngay = new System.Windows.Forms.Button();
            this.lbthoigian = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trogiup = new System.Windows.Forms.Button();
            this.trangchu = new System.Windows.Forms.Button();
            this.tcnhanvien = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Tcthongkedoanhso = new System.Windows.Forms.TabPage();
            this.chartdoanhso = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbtongdoanhso = new System.Windows.Forms.TextBox();
            this.txttongdoanhso = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.tbtongdonhang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbdonhuy = new System.Windows.Forms.TextBox();
            this.bttimkiem = new System.Windows.Forms.Button();
            this.cbtk = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.masanpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tensanpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btxuatfile = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Tcthongkedoanhso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartdoanhso)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1183, 987);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Controls.Add(this.dtngaycuoi);
            this.panel3.Controls.Add(this.dtngaydau);
            this.panel3.Controls.Add(this.btweek);
            this.panel3.Controls.Add(this.btmonth);
            this.panel3.Controls.Add(this.bt90day);
            this.panel3.Controls.Add(this.btngay);
            this.panel3.Controls.Add(this.lbthoigian);
            this.panel3.Location = new System.Drawing.Point(5, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1173, 748);
            this.panel3.TabIndex = 1;
            // 
            // dtngaycuoi
            // 
            this.dtngaycuoi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtngaycuoi.Location = new System.Drawing.Point(970, 16);
            this.dtngaycuoi.Name = "dtngaycuoi";
            this.dtngaycuoi.Size = new System.Drawing.Size(120, 22);
            this.dtngaycuoi.TabIndex = 7;
            // 
            // dtngaydau
            // 
            this.dtngaydau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtngaydau.Location = new System.Drawing.Point(801, 16);
            this.dtngaydau.Name = "dtngaydau";
            this.dtngaydau.Size = new System.Drawing.Size(120, 22);
            this.dtngaydau.TabIndex = 6;
            // 
            // btweek
            // 
            this.btweek.Location = new System.Drawing.Point(290, 6);
            this.btweek.Name = "btweek";
            this.btweek.Size = new System.Drawing.Size(78, 32);
            this.btweek.TabIndex = 4;
            this.btweek.Text = "7 Ngày";
            this.btweek.UseVisualStyleBackColor = true;
            this.btweek.Click += new System.EventHandler(this.btweek_Click);
            // 
            // btmonth
            // 
            this.btmonth.Location = new System.Drawing.Point(406, 6);
            this.btmonth.Name = "btmonth";
            this.btmonth.Size = new System.Drawing.Size(78, 32);
            this.btmonth.TabIndex = 3;
            this.btmonth.Text = "1 Tháng ";
            this.btmonth.UseVisualStyleBackColor = true;
            this.btmonth.Click += new System.EventHandler(this.btmonth_Click);
            // 
            // bt90day
            // 
            this.bt90day.Location = new System.Drawing.Point(531, 6);
            this.bt90day.Name = "bt90day";
            this.bt90day.Size = new System.Drawing.Size(78, 32);
            this.bt90day.TabIndex = 2;
            this.bt90day.Text = "3 Tháng";
            this.bt90day.UseVisualStyleBackColor = true;
            this.bt90day.Click += new System.EventHandler(this.bt90day_Click);
            // 
            // btngay
            // 
            this.btngay.Location = new System.Drawing.Point(174, 6);
            this.btngay.Name = "btngay";
            this.btngay.Size = new System.Drawing.Size(86, 32);
            this.btngay.TabIndex = 1;
            this.btngay.Text = "Hôm Nay";
            this.btngay.UseVisualStyleBackColor = true;
            this.btngay.Click += new System.EventHandler(this.btngay_Click);
            // 
            // lbthoigian
            // 
            this.lbthoigian.AutoSize = true;
            this.lbthoigian.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbthoigian.Location = new System.Drawing.Point(25, 11);
            this.lbthoigian.Name = "lbthoigian";
            this.lbthoigian.Size = new System.Drawing.Size(90, 20);
            this.lbthoigian.TabIndex = 0;
            this.lbthoigian.Text = "Thời Gian";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trogiup);
            this.panel2.Controls.Add(this.trangchu);
            this.panel2.Location = new System.Drawing.Point(4, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1174, 39);
            this.panel2.TabIndex = 0;
            // 
            // trogiup
            // 
            this.trogiup.Location = new System.Drawing.Point(1088, 4);
            this.trogiup.Name = "trogiup";
            this.trogiup.Size = new System.Drawing.Size(86, 34);
            this.trogiup.TabIndex = 1;
            this.trogiup.Text = "Trợ giúp ";
            this.trogiup.UseVisualStyleBackColor = true;
            // 
            // trangchu
            // 
            this.trangchu.Location = new System.Drawing.Point(30, 1);
            this.trangchu.Name = "trangchu";
            this.trangchu.Size = new System.Drawing.Size(95, 37);
            this.trangchu.TabIndex = 0;
            this.trangchu.Text = "Trang chủ";
            this.trangchu.UseVisualStyleBackColor = true;
            this.trangchu.Click += new System.EventHandler(this.trangchu_Click);
            // 
            // tcnhanvien
            // 
            this.tcnhanvien.Location = new System.Drawing.Point(4, 25);
            this.tcnhanvien.Name = "tcnhanvien";
            this.tcnhanvien.Padding = new System.Windows.Forms.Padding(3);
            this.tcnhanvien.Size = new System.Drawing.Size(1157, 672);
            this.tcnhanvien.TabIndex = 3;
            this.tcnhanvien.Text = "Nhân viên";
            this.tcnhanvien.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btxuatfile);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.cbtk);
            this.tabPage1.Controls.Add(this.bttimkiem);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1157, 672);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Thông tin kho";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Tcthongkedoanhso
            // 
            this.Tcthongkedoanhso.Controls.Add(this.label2);
            this.Tcthongkedoanhso.Controls.Add(this.tbdonhuy);
            this.Tcthongkedoanhso.Controls.Add(this.label1);
            this.Tcthongkedoanhso.Controls.Add(this.tbtongdonhang);
            this.Tcthongkedoanhso.Controls.Add(this.tbtongdoanhso);
            this.Tcthongkedoanhso.Controls.Add(this.txttongdoanhso);
            this.Tcthongkedoanhso.Controls.Add(this.chartdoanhso);
            this.Tcthongkedoanhso.Location = new System.Drawing.Point(4, 25);
            this.Tcthongkedoanhso.Name = "Tcthongkedoanhso";
            this.Tcthongkedoanhso.Padding = new System.Windows.Forms.Padding(3);
            this.Tcthongkedoanhso.Size = new System.Drawing.Size(1157, 672);
            this.Tcthongkedoanhso.TabIndex = 0;
            this.Tcthongkedoanhso.Text = "Thống kê doanh số";
            this.Tcthongkedoanhso.UseVisualStyleBackColor = true;
            // 
            // chartdoanhso
            // 
            chartArea1.Name = "ChartArea1";
            this.chartdoanhso.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartdoanhso.Legends.Add(legend1);
            this.chartdoanhso.Location = new System.Drawing.Point(20, 170);
            this.chartdoanhso.Name = "chartdoanhso";
            this.chartdoanhso.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.Navy;
            series1.Name = "Doanh So";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Loi Nhuan";
            this.chartdoanhso.Series.Add(series1);
            this.chartdoanhso.Series.Add(series2);
            this.chartdoanhso.Size = new System.Drawing.Size(509, 421);
            this.chartdoanhso.TabIndex = 0;
            this.chartdoanhso.Text = "chart1";
            // 
            // tbtongdoanhso
            // 
            this.tbtongdoanhso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtongdoanhso.Location = new System.Drawing.Point(47, 57);
            this.tbtongdoanhso.Multiline = true;
            this.tbtongdoanhso.Name = "tbtongdoanhso";
            this.tbtongdoanhso.Size = new System.Drawing.Size(210, 57);
            this.tbtongdoanhso.TabIndex = 1;
            // 
            // txttongdoanhso
            // 
            this.txttongdoanhso.AutoSize = true;
            this.txttongdoanhso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttongdoanhso.Location = new System.Drawing.Point(44, 27);
            this.txttongdoanhso.Name = "txttongdoanhso";
            this.txttongdoanhso.Size = new System.Drawing.Size(121, 18);
            this.txttongdoanhso.TabIndex = 2;
            this.txttongdoanhso.Text = "Tổng doanh số";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Tcthongkedoanhso);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tcnhanvien);
            this.tabControl1.Location = new System.Drawing.Point(5, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1165, 701);
            this.tabControl1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(608, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Số đơn hàng";
            // 
            // tbtongdonhang
            // 
            this.tbtongdonhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtongdonhang.Location = new System.Drawing.Point(557, 57);
            this.tbtongdonhang.Multiline = true;
            this.tbtongdonhang.Name = "tbtongdonhang";
            this.tbtongdonhang.Size = new System.Drawing.Size(210, 57);
            this.tbtongdonhang.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(868, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Đơn hàng hủy";
            // 
            // tbdonhuy
            // 
            this.tbdonhuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbdonhuy.Location = new System.Drawing.Point(817, 57);
            this.tbdonhuy.Multiline = true;
            this.tbdonhuy.Name = "tbdonhuy";
            this.tbdonhuy.Size = new System.Drawing.Size(210, 57);
            this.tbdonhuy.TabIndex = 8;
            // 
            // bttimkiem
            // 
            this.bttimkiem.Location = new System.Drawing.Point(17, 19);
            this.bttimkiem.Name = "bttimkiem";
            this.bttimkiem.Size = new System.Drawing.Size(98, 41);
            this.bttimkiem.TabIndex = 0;
            this.bttimkiem.Text = "Tìm Kiếm";
            this.bttimkiem.UseVisualStyleBackColor = true;
            // 
            // cbtk
            // 
            this.cbtk.FormattingEnabled = true;
            this.cbtk.Location = new System.Drawing.Point(148, 26);
            this.cbtk.Name = "cbtk";
            this.cbtk.Size = new System.Drawing.Size(198, 24);
            this.cbtk.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.masanpham,
            this.tensanpham,
            this.soluong});
            this.dataGridView1.Location = new System.Drawing.Point(6, 111);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1145, 560);
            this.dataGridView1.TabIndex = 2;
            // 
            // masanpham
            // 
            this.masanpham.DataPropertyName = "masanpham";
            this.masanpham.HeaderText = "Mã sản phẩm";
            this.masanpham.MinimumWidth = 6;
            this.masanpham.Name = "masanpham";
            this.masanpham.Width = 125;
            // 
            // tensanpham
            // 
            this.tensanpham.DataPropertyName = "tensanpham";
            this.tensanpham.HeaderText = "Tên sản phẩm";
            this.tensanpham.MinimumWidth = 6;
            this.tensanpham.Name = "tensanpham";
            this.tensanpham.Width = 125;
            // 
            // soluong
            // 
            this.soluong.DataPropertyName = "soluong";
            this.soluong.HeaderText = "Số lượng";
            this.soluong.MinimumWidth = 6;
            this.soluong.Name = "soluong";
            this.soluong.Width = 125;
            // 
            // btxuatfile
            // 
            this.btxuatfile.Location = new System.Drawing.Point(992, 28);
            this.btxuatfile.Name = "btxuatfile";
            this.btxuatfile.Size = new System.Drawing.Size(117, 43);
            this.btxuatfile.TabIndex = 3;
            this.btxuatfile.Text = "FileXuất ";
            this.btxuatfile.UseVisualStyleBackColor = true;
            // 
            // TongQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 796);
            this.Controls.Add(this.panel1);
            this.Name = "TongQuan";
            this.Text = "Tổng  quan";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.Tcthongkedoanhso.ResumeLayout(false);
            this.Tcthongkedoanhso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartdoanhso)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button trogiup;
        private System.Windows.Forms.Button trangchu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btweek;
        private System.Windows.Forms.Button btmonth;
        private System.Windows.Forms.Button bt90day;
        private System.Windows.Forms.Button btngay;
        private System.Windows.Forms.Label lbthoigian;
        private System.Windows.Forms.DateTimePicker dtngaycuoi;
        private System.Windows.Forms.DateTimePicker dtngaydau;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Tcthongkedoanhso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbtongdonhang;
        private System.Windows.Forms.TextBox tbtongdoanhso;
        private System.Windows.Forms.Label txttongdoanhso;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartdoanhso;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tcnhanvien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbdonhuy;
        private System.Windows.Forms.Button bttimkiem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbtk;
        private System.Windows.Forms.Button btxuatfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn masanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn tensanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
    }
}