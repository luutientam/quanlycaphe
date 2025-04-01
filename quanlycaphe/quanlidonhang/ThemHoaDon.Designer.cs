namespace quanlycaphe.quanlidonhang
{
    partial class ThemHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemHoaDon));
            this.maNhanVien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSanPhamDuocThem = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxMaKhachHang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ngayLapHoaDon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chonSanPham = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tenSanPhamDuocChon = new System.Windows.Forms.TextBox();
            this.soLuong = new System.Windows.Forms.TextBox();
            this.themSanPham = new System.Windows.Forms.Button();
            this.xoaSanPham = new System.Windows.Forms.Button();
            this.suaSoLuong = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tongTienHoaDon = new System.Windows.Forms.TextBox();
            this.tongTienHoaDonKhuyenMai = new System.Windows.Forms.TextBox();
            this.khuyenMai = new System.Windows.Forms.ComboBox();
            this.thanhToan = new System.Windows.Forms.Button();
            this.huyHoaDon = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPhamDuocThem)).BeginInit();
            this.SuspendLayout();
            // 
            // maNhanVien
            // 
            this.maNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maNhanVien.Location = new System.Drawing.Point(380, 104);
            this.maNhanVien.Margin = new System.Windows.Forms.Padding(5);
            this.maNhanVien.Name = "maNhanVien";
            this.maNhanVien.Size = new System.Drawing.Size(294, 20);
            this.maNhanVien.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã nhân viên";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khách hàng";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvSanPhamDuocThem
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvSanPhamDuocThem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSanPhamDuocThem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPhamDuocThem.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPhamDuocThem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSanPhamDuocThem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvSanPhamDuocThem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSanPhamDuocThem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSanPhamDuocThem.ColumnHeadersHeight = 35;
            this.dgvSanPhamDuocThem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSanPhamDuocThem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.dgvSanPhamDuocThem.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvSanPhamDuocThem.EnableHeadersVisualStyles = false;
            this.dgvSanPhamDuocThem.GridColor = System.Drawing.Color.LightGray;
            this.dgvSanPhamDuocThem.Location = new System.Drawing.Point(119, 240);
            this.dgvSanPhamDuocThem.Margin = new System.Windows.Forms.Padding(5);
            this.dgvSanPhamDuocThem.Name = "dgvSanPhamDuocThem";
            this.dgvSanPhamDuocThem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSanPhamDuocThem.RowHeadersVisible = false;
            this.dgvSanPhamDuocThem.RowTemplate.Height = 30;
            this.dgvSanPhamDuocThem.Size = new System.Drawing.Size(754, 310);
            this.dgvSanPhamDuocThem.TabIndex = 13;
            this.dgvSanPhamDuocThem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPhamDuocThem_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaSanPham";
            this.Column1.HeaderText = "Mã sản phẩm";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenSanPham";
            this.Column2.HeaderText = "Tên sản phẩm";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "SoLuong";
            this.Column4.HeaderText = "Số lượng";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Gia";
            this.Column3.HeaderText = "Giá";
            this.Column3.Name = "Column3";
            // 
            // cbxMaKhachHang
            // 
            this.cbxMaKhachHang.FormattingEnabled = true;
            this.cbxMaKhachHang.Location = new System.Drawing.Point(380, 65);
            this.cbxMaKhachHang.Name = "cbxMaKhachHang";
            this.cbxMaKhachHang.Size = new System.Drawing.Size(294, 21);
            this.cbxMaKhachHang.TabIndex = 10;
            this.cbxMaKhachHang.Text = "Mã khách hàng - Tên";
            this.cbxMaKhachHang.SelectedIndexChanged += new System.EventHandler(this.cbxMaKhachHang_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(116, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ngày lập hóa đơn";
            // 
            // ngayLapHoaDon
            // 
            this.ngayLapHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ngayLapHoaDon.Location = new System.Drawing.Point(380, 141);
            this.ngayLapHoaDon.Margin = new System.Windows.Forms.Padding(5);
            this.ngayLapHoaDon.Name = "ngayLapHoaDon";
            this.ngayLapHoaDon.Size = new System.Drawing.Size(294, 20);
            this.ngayLapHoaDon.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(115, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "Chọn sản phẩm";
            // 
            // chonSanPham
            // 
            this.chonSanPham.FormattingEnabled = true;
            this.chonSanPham.Location = new System.Drawing.Point(380, 200);
            this.chonSanPham.Name = "chonSanPham";
            this.chonSanPham.Size = new System.Drawing.Size(203, 21);
            this.chonSanPham.TabIndex = 13;
            this.chonSanPham.Text = "Chọn sản phẩm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(756, 177);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Số lượng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(618, 178);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tên sản phẩm";
            // 
            // tenSanPhamDuocChon
            // 
            this.tenSanPhamDuocChon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tenSanPhamDuocChon.Location = new System.Drawing.Point(622, 202);
            this.tenSanPhamDuocChon.Margin = new System.Windows.Forms.Padding(5);
            this.tenSanPhamDuocChon.Name = "tenSanPhamDuocChon";
            this.tenSanPhamDuocChon.Size = new System.Drawing.Size(113, 20);
            this.tenSanPhamDuocChon.TabIndex = 13;
            // 
            // soLuong
            // 
            this.soLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.soLuong.Location = new System.Drawing.Point(760, 201);
            this.soLuong.Margin = new System.Windows.Forms.Padding(5);
            this.soLuong.Name = "soLuong";
            this.soLuong.Size = new System.Drawing.Size(113, 20);
            this.soLuong.TabIndex = 15;
            // 
            // themSanPham
            // 
            this.themSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themSanPham.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themSanPham.Image = ((System.Drawing.Image)(resources.GetObject("themSanPham.Image")));
            this.themSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.themSanPham.Location = new System.Drawing.Point(876, 313);
            this.themSanPham.Margin = new System.Windows.Forms.Padding(5);
            this.themSanPham.Name = "themSanPham";
            this.themSanPham.Size = new System.Drawing.Size(146, 42);
            this.themSanPham.TabIndex = 38;
            this.themSanPham.Text = "Thêm sản phẩm";
            this.themSanPham.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.themSanPham.UseVisualStyleBackColor = true;
            // 
            // xoaSanPham
            // 
            this.xoaSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xoaSanPham.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoaSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xoaSanPham.Location = new System.Drawing.Point(876, 463);
            this.xoaSanPham.Margin = new System.Windows.Forms.Padding(5);
            this.xoaSanPham.Name = "xoaSanPham";
            this.xoaSanPham.Size = new System.Drawing.Size(146, 42);
            this.xoaSanPham.TabIndex = 39;
            this.xoaSanPham.Text = "Xóa sản phẩm";
            this.xoaSanPham.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.xoaSanPham.UseVisualStyleBackColor = true;
            // 
            // suaSoLuong
            // 
            this.suaSoLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suaSoLuong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suaSoLuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.suaSoLuong.Location = new System.Drawing.Point(876, 388);
            this.suaSoLuong.Margin = new System.Windows.Forms.Padding(5);
            this.suaSoLuong.Name = "suaSoLuong";
            this.suaSoLuong.Size = new System.Drawing.Size(146, 42);
            this.suaSoLuong.TabIndex = 40;
            this.suaSoLuong.Text = "Sửa số lượng";
            this.suaSoLuong.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.suaSoLuong.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(115, 558);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 19);
            this.label7.TabIndex = 41;
            this.label7.Text = "Tổng tiền hóa đơn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(115, 647);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 19);
            this.label8.TabIndex = 42;
            this.label8.Text = "Tổng tiền hóa đơn(KM)";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(115, 600);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 19);
            this.label9.TabIndex = 43;
            this.label9.Text = "Khuyến mại";
            // 
            // tongTienHoaDon
            // 
            this.tongTienHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tongTienHoaDon.Location = new System.Drawing.Point(380, 560);
            this.tongTienHoaDon.Margin = new System.Windows.Forms.Padding(5);
            this.tongTienHoaDon.Name = "tongTienHoaDon";
            this.tongTienHoaDon.Size = new System.Drawing.Size(294, 20);
            this.tongTienHoaDon.TabIndex = 44;
            // 
            // tongTienHoaDonKhuyenMai
            // 
            this.tongTienHoaDonKhuyenMai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tongTienHoaDonKhuyenMai.Location = new System.Drawing.Point(380, 646);
            this.tongTienHoaDonKhuyenMai.Margin = new System.Windows.Forms.Padding(5);
            this.tongTienHoaDonKhuyenMai.Name = "tongTienHoaDonKhuyenMai";
            this.tongTienHoaDonKhuyenMai.Size = new System.Drawing.Size(294, 20);
            this.tongTienHoaDonKhuyenMai.TabIndex = 45;
            // 
            // khuyenMai
            // 
            this.khuyenMai.FormattingEnabled = true;
            this.khuyenMai.Location = new System.Drawing.Point(380, 601);
            this.khuyenMai.Name = "khuyenMai";
            this.khuyenMai.Size = new System.Drawing.Size(294, 21);
            this.khuyenMai.TabIndex = 46;
            this.khuyenMai.Text = "Khuyến mãi";
            // 
            // thanhToan
            // 
            this.thanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thanhToan.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thanhToan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.thanhToan.Location = new System.Drawing.Point(674, 677);
            this.thanhToan.Margin = new System.Windows.Forms.Padding(5);
            this.thanhToan.Name = "thanhToan";
            this.thanhToan.Size = new System.Drawing.Size(146, 42);
            this.thanhToan.TabIndex = 47;
            this.thanhToan.Text = "Thanh toán";
            this.thanhToan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.thanhToan.UseVisualStyleBackColor = true;
            // 
            // huyHoaDon
            // 
            this.huyHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.huyHoaDon.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.huyHoaDon.Location = new System.Drawing.Point(250, 677);
            this.huyHoaDon.Margin = new System.Windows.Forms.Padding(5);
            this.huyHoaDon.Name = "huyHoaDon";
            this.huyHoaDon.Size = new System.Drawing.Size(146, 42);
            this.huyHoaDon.TabIndex = 48;
            this.huyHoaDon.Text = "Hủy";
            this.huyHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.huyHoaDon.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(395, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(236, 45);
            this.label10.TabIndex = 49;
            this.label10.Text = "Thêm hóa đơn";
            // 
            // ThemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 733);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ngayLapHoaDon);
            this.Controls.Add(this.huyHoaDon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.thanhToan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxMaKhachHang);
            this.Controls.Add(this.maNhanVien);
            this.Controls.Add(this.khuyenMai);
            this.Controls.Add(this.tongTienHoaDonKhuyenMai);
            this.Controls.Add(this.tongTienHoaDon);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.suaSoLuong);
            this.Controls.Add(this.xoaSanPham);
            this.Controls.Add(this.themSanPham);
            this.Controls.Add(this.soLuong);
            this.Controls.Add(this.tenSanPhamDuocChon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chonSanPham);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvSanPhamDuocThem);
            this.Name = "ThemHoaDon";
            this.Text = "ThemHoaDon";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPhamDuocThem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox maNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSanPhamDuocThem;
        private System.Windows.Forms.ComboBox cbxMaKhachHang;
        private System.Windows.Forms.TextBox ngayLapHoaDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox chonSanPham;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tenSanPhamDuocChon;
        private System.Windows.Forms.TextBox soLuong;
        private System.Windows.Forms.Button themSanPham;
        private System.Windows.Forms.Button xoaSanPham;
        private System.Windows.Forms.Button suaSoLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tongTienHoaDon;
        private System.Windows.Forms.TextBox tongTienHoaDonKhuyenMai;
        private System.Windows.Forms.ComboBox khuyenMai;
        private System.Windows.Forms.Button thanhToan;
        private System.Windows.Forms.Button huyHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label10;
    }
}