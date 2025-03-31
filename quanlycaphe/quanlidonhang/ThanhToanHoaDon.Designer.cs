namespace quanlycaphe.quanlidonhang
{
    partial class ThanhToanHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLoadThongTinSanPham = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quayLai = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nhanVienLapHoaDon = new System.Windows.Forms.TextBox();
            this.maKhuyenMai = new System.Windows.Forms.TextBox();
            this.khachHang = new System.Windows.Forms.TextBox();
            this.ngayLapHoaDon = new System.Windows.Forms.TextBox();
            this.tongTien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maHoaDon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadThongTinSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Gia";
            this.Column3.HeaderText = "Giá";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenSanPham";
            this.Column2.HeaderText = "Tên sản phẩm";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "stt";
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            // 
            // dgvLoadThongTinSanPham
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvLoadThongTinSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLoadThongTinSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoadThongTinSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoadThongTinSanPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoadThongTinSanPham.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvLoadThongTinSanPham.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLoadThongTinSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLoadThongTinSanPham.ColumnHeadersHeight = 35;
            this.dgvLoadThongTinSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLoadThongTinSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.dgvLoadThongTinSanPham.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvLoadThongTinSanPham.EnableHeadersVisualStyles = false;
            this.dgvLoadThongTinSanPham.GridColor = System.Drawing.Color.LightGray;
            this.dgvLoadThongTinSanPham.Location = new System.Drawing.Point(78, 160);
            this.dgvLoadThongTinSanPham.Margin = new System.Windows.Forms.Padding(5);
            this.dgvLoadThongTinSanPham.Name = "dgvLoadThongTinSanPham";
            this.dgvLoadThongTinSanPham.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLoadThongTinSanPham.RowHeadersVisible = false;
            this.dgvLoadThongTinSanPham.RowTemplate.Height = 30;
            this.dgvLoadThongTinSanPham.Size = new System.Drawing.Size(373, 190);
            this.dgvLoadThongTinSanPham.TabIndex = 61;
            this.dgvLoadThongTinSanPham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoadThongTinSanPham_CellContentClick);
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "SoLuong";
            this.Column4.HeaderText = "Số lượng";
            this.Column4.Name = "Column4";
            // 
            // quayLai
            // 
            this.quayLai.Location = new System.Drawing.Point(376, 624);
            this.quayLai.Name = "quayLai";
            this.quayLai.Size = new System.Drawing.Size(75, 23);
            this.quayLai.TabIndex = 60;
            this.quayLai.Text = "Quay lại";
            this.quayLai.UseVisualStyleBackColor = true;
            this.quayLai.Click += new System.EventHandler(this.quayLai_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(103, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(324, 45);
            this.label8.TabIndex = 59;
            this.label8.Text = "Thanh toán hóa đơn";
            this.label8.Click += new System.EventHandler(this.label8_Click_1);
            // 
            // nhanVienLapHoaDon
            // 
            this.nhanVienLapHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nhanVienLapHoaDon.Location = new System.Drawing.Point(229, 558);
            this.nhanVienLapHoaDon.Margin = new System.Windows.Forms.Padding(5);
            this.nhanVienLapHoaDon.Name = "nhanVienLapHoaDon";
            this.nhanVienLapHoaDon.Size = new System.Drawing.Size(222, 20);
            this.nhanVienLapHoaDon.TabIndex = 58;
            this.nhanVienLapHoaDon.TextChanged += new System.EventHandler(this.nhanVienLapHoaDon_TextChanged);
            // 
            // maKhuyenMai
            // 
            this.maKhuyenMai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maKhuyenMai.Location = new System.Drawing.Point(229, 511);
            this.maKhuyenMai.Margin = new System.Windows.Forms.Padding(5);
            this.maKhuyenMai.Name = "maKhuyenMai";
            this.maKhuyenMai.Size = new System.Drawing.Size(222, 20);
            this.maKhuyenMai.TabIndex = 57;
            this.maKhuyenMai.TextChanged += new System.EventHandler(this.maKhuyenMai_TextChanged);
            // 
            // khachHang
            // 
            this.khachHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.khachHang.Location = new System.Drawing.Point(229, 461);
            this.khachHang.Margin = new System.Windows.Forms.Padding(5);
            this.khachHang.Name = "khachHang";
            this.khachHang.Size = new System.Drawing.Size(222, 20);
            this.khachHang.TabIndex = 56;
            this.khachHang.TextChanged += new System.EventHandler(this.khachHang_TextChanged);
            // 
            // ngayLapHoaDon
            // 
            this.ngayLapHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ngayLapHoaDon.Location = new System.Drawing.Point(229, 413);
            this.ngayLapHoaDon.Margin = new System.Windows.Forms.Padding(5);
            this.ngayLapHoaDon.Name = "ngayLapHoaDon";
            this.ngayLapHoaDon.Size = new System.Drawing.Size(222, 20);
            this.ngayLapHoaDon.TabIndex = 55;
            this.ngayLapHoaDon.TextChanged += new System.EventHandler(this.ngayLapHoaDon_TextChanged);
            // 
            // tongTien
            // 
            this.tongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tongTien.Location = new System.Drawing.Point(229, 360);
            this.tongTien.Margin = new System.Windows.Forms.Padding(5);
            this.tongTien.Name = "tongTien";
            this.tongTien.Size = new System.Drawing.Size(222, 20);
            this.tongTien.TabIndex = 54;
            this.tongTien.TextChanged += new System.EventHandler(this.tongTien_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(74, 411);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 19);
            this.label7.TabIndex = 53;
            this.label7.Text = "Ngày lập hóa đơn";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(74, 459);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 19);
            this.label6.TabIndex = 52;
            this.label6.Text = "Khách hàng";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(74, 509);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 19);
            this.label5.TabIndex = 51;
            this.label5.Text = "Mã khuyến mại";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 556);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 19);
            this.label4.TabIndex = 50;
            this.label4.Text = "Nhân viên lập hóa đơn";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 361);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 49;
            this.label2.Text = "Tổng giá";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 135);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 19);
            this.label1.TabIndex = 48;
            this.label1.Text = "Thông tin sản phẩm";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // maHoaDon
            // 
            this.maHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maHoaDon.Location = new System.Drawing.Point(229, 96);
            this.maHoaDon.Margin = new System.Windows.Forms.Padding(5);
            this.maHoaDon.Name = "maHoaDon";
            this.maHoaDon.Size = new System.Drawing.Size(222, 20);
            this.maHoaDon.TabIndex = 47;
            this.maHoaDon.TextChanged += new System.EventHandler(this.maHoaDon_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 46;
            this.label3.Text = "Mã hóa đơn";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // ThanhToanHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 674);
            this.Controls.Add(this.dgvLoadThongTinSanPham);
            this.Controls.Add(this.quayLai);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nhanVienLapHoaDon);
            this.Controls.Add(this.maKhuyenMai);
            this.Controls.Add(this.khachHang);
            this.Controls.Add(this.ngayLapHoaDon);
            this.Controls.Add(this.tongTien);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maHoaDon);
            this.Controls.Add(this.label3);
            this.Name = "ThanhToanHoaDon";
            this.Text = "ThanhToanHoaDon";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadThongTinSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridView dgvLoadThongTinSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button quayLai;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nhanVienLapHoaDon;
        private System.Windows.Forms.TextBox maKhuyenMai;
        private System.Windows.Forms.TextBox khachHang;
        private System.Windows.Forms.TextBox ngayLapHoaDon;
        private System.Windows.Forms.TextBox tongTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox maHoaDon;
        private System.Windows.Forms.Label label3;
    }
}