namespace quanlycaphe
{
    partial class BaoCao
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bttrangchu = new System.Windows.Forms.Button();
            this.bttrogiup = new System.Windows.Forms.Button();
            this.dgvbaocao = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lbtrangthaidon = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbtrangthai = new System.Windows.Forms.ComboBox();
            this.cbnguonhang = new System.Windows.Forms.ComboBox();
            this.cbnhanvien = new System.Windows.Forms.ComboBox();
            this.dtngaybd = new System.Windows.Forms.DateTimePicker();
            this.btbaocao = new System.Windows.Forms.Button();
            this.btxuatfile = new System.Windows.Forms.Button();
            this.bthomnay = new System.Windows.Forms.Button();
            this.bt7ngay = new System.Windows.Forms.Button();
            this.bt1thang = new System.Windows.Forms.Button();
            this.bt3thang = new System.Windows.Forms.Button();
            this.madonhang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayht = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manhanvien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbaocao)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt3thang);
            this.panel1.Controls.Add(this.bt1thang);
            this.panel1.Controls.Add(this.bt7ngay);
            this.panel1.Controls.Add(this.bthomnay);
            this.panel1.Controls.Add(this.btxuatfile);
            this.panel1.Controls.Add(this.btbaocao);
            this.panel1.Controls.Add(this.dtngaybd);
            this.panel1.Controls.Add(this.cbnhanvien);
            this.panel1.Controls.Add(this.cbnguonhang);
            this.panel1.Controls.Add(this.cbtrangthai);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbtrangthaidon);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvbaocao);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1197, 847);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.bttrogiup);
            this.panel2.Controls.Add(this.bttrangchu);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1194, 52);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(447, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Báo Cáo Doanh Thu";
            // 
            // bttrangchu
            // 
            this.bttrangchu.Location = new System.Drawing.Point(3, 2);
            this.bttrangchu.Name = "bttrangchu";
            this.bttrangchu.Size = new System.Drawing.Size(135, 46);
            this.bttrangchu.TabIndex = 1;
            this.bttrangchu.Text = "Trang Chủ";
            this.bttrangchu.UseVisualStyleBackColor = true;
            this.bttrangchu.Click += new System.EventHandler(this.bttrangchu_Click);
            // 
            // bttrogiup
            // 
            this.bttrogiup.Location = new System.Drawing.Point(1098, 6);
            this.bttrogiup.Name = "bttrogiup";
            this.bttrogiup.Size = new System.Drawing.Size(87, 38);
            this.bttrogiup.TabIndex = 2;
            this.bttrogiup.Text = "GiúpTrợ ";
            this.bttrogiup.UseVisualStyleBackColor = true;
            // 
            // dgvbaocao
            // 
            this.dgvbaocao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbaocao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.madonhang,
            this.tongtien,
            this.ngayht,
            this.manhanvien,
            this.trangthai});
            this.dgvbaocao.Location = new System.Drawing.Point(7, 226);
            this.dgvbaocao.Name = "dgvbaocao";
            this.dgvbaocao.RowHeadersWidth = 51;
            this.dgvbaocao.RowTemplate.Height = 24;
            this.dgvbaocao.Size = new System.Drawing.Size(1187, 609);
            this.dgvbaocao.TabIndex = 1;
            this.dgvbaocao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbaocao_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Theo Thời Gian";
            // 
            // lbtrangthaidon
            // 
            this.lbtrangthaidon.AutoSize = true;
            this.lbtrangthaidon.Location = new System.Drawing.Point(29, 154);
            this.lbtrangthaidon.Name = "lbtrangthaidon";
            this.lbtrangthaidon.Size = new System.Drawing.Size(100, 16);
            this.lbtrangthaidon.TabIndex = 3;
            this.lbtrangthaidon.Text = "Trạng Thái Đơn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nguồn Hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nhân Viên";
            // 
            // cbtrangthai
            // 
            this.cbtrangthai.FormattingEnabled = true;
            this.cbtrangthai.Location = new System.Drawing.Point(163, 146);
            this.cbtrangthai.Name = "cbtrangthai";
            this.cbtrangthai.Size = new System.Drawing.Size(182, 24);
            this.cbtrangthai.TabIndex = 6;
            // 
            // cbnguonhang
            // 
            this.cbnguonhang.FormattingEnabled = true;
            this.cbnguonhang.Location = new System.Drawing.Point(554, 90);
            this.cbnguonhang.Name = "cbnguonhang";
            this.cbnguonhang.Size = new System.Drawing.Size(168, 24);
            this.cbnguonhang.TabIndex = 7;
            // 
            // cbnhanvien
            // 
            this.cbnhanvien.FormattingEnabled = true;
            this.cbnhanvien.Location = new System.Drawing.Point(554, 151);
            this.cbnhanvien.Name = "cbnhanvien";
            this.cbnhanvien.Size = new System.Drawing.Size(174, 24);
            this.cbnhanvien.TabIndex = 8;
            // 
            // dtngaybd
            // 
            this.dtngaybd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtngaybd.Location = new System.Drawing.Point(159, 88);
            this.dtngaybd.Name = "dtngaybd";
            this.dtngaybd.Size = new System.Drawing.Size(185, 22);
            this.dtngaybd.TabIndex = 9;
            // 
            // btbaocao
            // 
            this.btbaocao.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btbaocao.Location = new System.Drawing.Point(1036, 77);
            this.btbaocao.Name = "btbaocao";
            this.btbaocao.Size = new System.Drawing.Size(110, 41);
            this.btbaocao.TabIndex = 10;
            this.btbaocao.Text = "Báo Cáo";
            this.btbaocao.UseVisualStyleBackColor = false;
            this.btbaocao.Click += new System.EventHandler(this.btbaocao_Click);
            // 
            // btxuatfile
            // 
            this.btxuatfile.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btxuatfile.Location = new System.Drawing.Point(1036, 143);
            this.btxuatfile.Name = "btxuatfile";
            this.btxuatfile.Size = new System.Drawing.Size(110, 39);
            this.btxuatfile.TabIndex = 11;
            this.btxuatfile.Text = "Xuất File";
            this.btxuatfile.UseVisualStyleBackColor = false;
            this.btxuatfile.Click += new System.EventHandler(this.btxuatfile_Click);
            // 
            // bthomnay
            // 
            this.bthomnay.Location = new System.Drawing.Point(774, 86);
            this.bthomnay.Name = "bthomnay";
            this.bthomnay.Size = new System.Drawing.Size(101, 36);
            this.bthomnay.TabIndex = 12;
            this.bthomnay.Text = "Hôm Nay";
            this.bthomnay.UseVisualStyleBackColor = true;
            // 
            // bt7ngay
            // 
            this.bt7ngay.Location = new System.Drawing.Point(774, 143);
            this.bt7ngay.Name = "bt7ngay";
            this.bt7ngay.Size = new System.Drawing.Size(102, 36);
            this.bt7ngay.TabIndex = 13;
            this.bt7ngay.Text = "7 Ngày";
            this.bt7ngay.UseVisualStyleBackColor = true;
            // 
            // bt1thang
            // 
            this.bt1thang.Location = new System.Drawing.Point(907, 83);
            this.bt1thang.Name = "bt1thang";
            this.bt1thang.Size = new System.Drawing.Size(88, 39);
            this.bt1thang.TabIndex = 14;
            this.bt1thang.Text = "1 tháng";
            this.bt1thang.UseVisualStyleBackColor = true;
            // 
            // bt3thang
            // 
            this.bt3thang.Location = new System.Drawing.Point(907, 143);
            this.bt3thang.Name = "bt3thang";
            this.bt3thang.Size = new System.Drawing.Size(80, 35);
            this.bt3thang.TabIndex = 15;
            this.bt3thang.Text = "3 tháng";
            this.bt3thang.UseVisualStyleBackColor = true;
            // 
            // madonhang
            // 
            this.madonhang.DataPropertyName = "madonhang";
            this.madonhang.HeaderText = "Mã Đơn Hàng";
            this.madonhang.MinimumWidth = 6;
            this.madonhang.Name = "madonhang";
            this.madonhang.Width = 125;
            // 
            // tongtien
            // 
            this.tongtien.DataPropertyName = "tongtien";
            this.tongtien.HeaderText = "Tổng Tiền";
            this.tongtien.MinimumWidth = 6;
            this.tongtien.Name = "tongtien";
            this.tongtien.Width = 125;
            // 
            // ngayht
            // 
            this.ngayht.DataPropertyName = "NgayDat";
            this.ngayht.HeaderText = "Ngày HT";
            this.ngayht.MinimumWidth = 6;
            this.ngayht.Name = "ngayht";
            this.ngayht.Width = 125;
            // 
            // manhanvien
            // 
            this.manhanvien.DataPropertyName = "manhanvien";
            this.manhanvien.HeaderText = "Mã Nhân Viên";
            this.manhanvien.MinimumWidth = 6;
            this.manhanvien.Name = "manhanvien";
            this.manhanvien.Width = 125;
            // 
            // trangthai
            // 
            this.trangthai.DataPropertyName = "trangthai";
            this.trangthai.HeaderText = "Trang Thai";
            this.trangthai.MinimumWidth = 6;
            this.trangthai.Name = "trangthai";
            this.trangthai.Width = 125;
            // 
            // BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 850);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BaoCao";
            this.Text = "BaoCao";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbaocao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bttrogiup;
        private System.Windows.Forms.Button bttrangchu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvbaocao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbtrangthai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbtrangthaidon;
        private System.Windows.Forms.Button btbaocao;
        private System.Windows.Forms.DateTimePicker dtngaybd;
        private System.Windows.Forms.ComboBox cbnhanvien;
        private System.Windows.Forms.ComboBox cbnguonhang;
        private System.Windows.Forms.Button btxuatfile;
        private System.Windows.Forms.Button bt3thang;
        private System.Windows.Forms.Button bt1thang;
        private System.Windows.Forms.Button bt7ngay;
        private System.Windows.Forms.Button bthomnay;
        private System.Windows.Forms.DataGridViewTextBoxColumn madonhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayht;
        private System.Windows.Forms.DataGridViewTextBoxColumn manhanvien;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthai;
    }
}