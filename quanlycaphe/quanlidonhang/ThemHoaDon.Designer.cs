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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemHoaDon));
            this.maNhanVien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSanPhamDuocThem = new System.Windows.Forms.DataGridView();
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
            this.tongTienHoaDon = new System.Windows.Forms.TextBox();
            this.thanhToan = new System.Windows.Forms.Button();
            this.huyHoaDon = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbbBan = new System.Windows.Forms.ComboBox();
            this.themKhachHang = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.maHoaDon = new System.Windows.Forms.TextBox();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Giaa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPhamDuocThem)).BeginInit();
            this.SuspendLayout();
            // 
            // maNhanVien
            // 
            this.maNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maNhanVien.Location = new System.Drawing.Point(381, 145);
            this.maNhanVien.Margin = new System.Windows.Forms.Padding(5);
            this.maNhanVien.Name = "maNhanVien";
            this.maNhanVien.Size = new System.Drawing.Size(294, 20);
            this.maNhanVien.TabIndex = 3;
            this.maNhanVien.TextChanged += new System.EventHandler(this.maNhanVien_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 146);
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
            this.label1.Location = new System.Drawing.Point(116, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khách hàng";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvSanPhamDuocThem
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvSanPhamDuocThem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSanPhamDuocThem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPhamDuocThem.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPhamDuocThem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSanPhamDuocThem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvSanPhamDuocThem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSanPhamDuocThem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSanPhamDuocThem.ColumnHeadersHeight = 35;
            this.dgvSanPhamDuocThem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSanPhamDuocThem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.Column2,
            this.SoLg,
            this.Giaa,
            this.Column1,
            this.Column3});
            this.dgvSanPhamDuocThem.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvSanPhamDuocThem.EnableHeadersVisualStyles = false;
            this.dgvSanPhamDuocThem.GridColor = System.Drawing.Color.LightGray;
            this.dgvSanPhamDuocThem.Location = new System.Drawing.Point(119, 315);
            this.dgvSanPhamDuocThem.Margin = new System.Windows.Forms.Padding(5);
            this.dgvSanPhamDuocThem.Name = "dgvSanPhamDuocThem";
            this.dgvSanPhamDuocThem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSanPhamDuocThem.RowHeadersVisible = false;
            this.dgvSanPhamDuocThem.RowTemplate.Height = 30;
            this.dgvSanPhamDuocThem.Size = new System.Drawing.Size(754, 284);
            this.dgvSanPhamDuocThem.TabIndex = 13;
            this.dgvSanPhamDuocThem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPhamDuocThem_CellClick_1);
            this.dgvSanPhamDuocThem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPhamDuocThem_CellContentClick);
            // 
            // cbxMaKhachHang
            // 
            this.cbxMaKhachHang.FormattingEnabled = true;
            this.cbxMaKhachHang.Location = new System.Drawing.Point(380, 105);
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
            this.label3.Location = new System.Drawing.Point(117, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ngày lập hóa đơn";
            // 
            // ngayLapHoaDon
            // 
            this.ngayLapHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ngayLapHoaDon.Location = new System.Drawing.Point(381, 185);
            this.ngayLapHoaDon.Margin = new System.Windows.Forms.Padding(5);
            this.ngayLapHoaDon.Name = "ngayLapHoaDon";
            this.ngayLapHoaDon.Size = new System.Drawing.Size(294, 20);
            this.ngayLapHoaDon.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(117, 270);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "Chọn sản phẩm";
            // 
            // chonSanPham
            // 
            this.chonSanPham.FormattingEnabled = true;
            this.chonSanPham.Location = new System.Drawing.Point(382, 268);
            this.chonSanPham.Name = "chonSanPham";
            this.chonSanPham.Size = new System.Drawing.Size(203, 21);
            this.chonSanPham.TabIndex = 13;
            this.chonSanPham.Text = "Chọn sản phẩm";
            this.chonSanPham.SelectedIndexChanged += new System.EventHandler(this.chonSanPham_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(758, 245);
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
            this.label6.Location = new System.Drawing.Point(620, 246);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tên sản phẩm";
            // 
            // tenSanPhamDuocChon
            // 
            this.tenSanPhamDuocChon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tenSanPhamDuocChon.Location = new System.Drawing.Point(624, 270);
            this.tenSanPhamDuocChon.Margin = new System.Windows.Forms.Padding(5);
            this.tenSanPhamDuocChon.Name = "tenSanPhamDuocChon";
            this.tenSanPhamDuocChon.Size = new System.Drawing.Size(113, 20);
            this.tenSanPhamDuocChon.TabIndex = 13;
            this.tenSanPhamDuocChon.TextChanged += new System.EventHandler(this.tenSanPhamDuocChon_TextChanged);
            // 
            // soLuong
            // 
            this.soLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.soLuong.Location = new System.Drawing.Point(762, 270);
            this.soLuong.Margin = new System.Windows.Forms.Padding(5);
            this.soLuong.Name = "soLuong";
            this.soLuong.Size = new System.Drawing.Size(113, 20);
            this.soLuong.TabIndex = 15;
            this.soLuong.TextChanged += new System.EventHandler(this.soLuong_TextChanged);
            // 
            // themSanPham
            // 
            this.themSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themSanPham.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themSanPham.Image = ((System.Drawing.Image)(resources.GetObject("themSanPham.Image")));
            this.themSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.themSanPham.Location = new System.Drawing.Point(876, 376);
            this.themSanPham.Margin = new System.Windows.Forms.Padding(5);
            this.themSanPham.Name = "themSanPham";
            this.themSanPham.Size = new System.Drawing.Size(146, 42);
            this.themSanPham.TabIndex = 38;
            this.themSanPham.Text = "Thêm sản phẩm";
            this.themSanPham.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.themSanPham.UseVisualStyleBackColor = true;
            this.themSanPham.Click += new System.EventHandler(this.themSanPham_Click);
            // 
            // xoaSanPham
            // 
            this.xoaSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xoaSanPham.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoaSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xoaSanPham.Location = new System.Drawing.Point(876, 526);
            this.xoaSanPham.Margin = new System.Windows.Forms.Padding(5);
            this.xoaSanPham.Name = "xoaSanPham";
            this.xoaSanPham.Size = new System.Drawing.Size(146, 42);
            this.xoaSanPham.TabIndex = 39;
            this.xoaSanPham.Text = "Xóa sản phẩm";
            this.xoaSanPham.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.xoaSanPham.UseVisualStyleBackColor = true;
            this.xoaSanPham.Click += new System.EventHandler(this.xoaSanPham_Click);
            // 
            // suaSoLuong
            // 
            this.suaSoLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suaSoLuong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suaSoLuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.suaSoLuong.Location = new System.Drawing.Point(876, 451);
            this.suaSoLuong.Margin = new System.Windows.Forms.Padding(5);
            this.suaSoLuong.Name = "suaSoLuong";
            this.suaSoLuong.Size = new System.Drawing.Size(146, 42);
            this.suaSoLuong.TabIndex = 40;
            this.suaSoLuong.Text = "Sửa số lượng";
            this.suaSoLuong.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.suaSoLuong.UseVisualStyleBackColor = true;
            this.suaSoLuong.Click += new System.EventHandler(this.suaSoLuong_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(117, 625);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 19);
            this.label7.TabIndex = 41;
            this.label7.Text = "Tổng tiền hóa đơn";
            // 
            // tongTienHoaDon
            // 
            this.tongTienHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tongTienHoaDon.Location = new System.Drawing.Point(382, 627);
            this.tongTienHoaDon.Margin = new System.Windows.Forms.Padding(5);
            this.tongTienHoaDon.Name = "tongTienHoaDon";
            this.tongTienHoaDon.Size = new System.Drawing.Size(294, 20);
            this.tongTienHoaDon.TabIndex = 44;
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
            this.thanhToan.Click += new System.EventHandler(this.thanhToan_Click);
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
            this.huyHoaDon.Click += new System.EventHandler(this.huyHoaDon_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(397, -6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(236, 45);
            this.label10.TabIndex = 49;
            this.label10.Text = "Thêm hóa đơn";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(117, 219);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 19);
            this.label11.TabIndex = 50;
            this.label11.Text = "Bàn";
            // 
            // cbbBan
            // 
            this.cbbBan.FormattingEnabled = true;
            this.cbbBan.Location = new System.Drawing.Point(381, 223);
            this.cbbBan.Name = "cbbBan";
            this.cbbBan.Size = new System.Drawing.Size(294, 21);
            this.cbbBan.TabIndex = 51;
            // 
            // themKhachHang
            // 
            this.themKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.themKhachHang.Location = new System.Drawing.Point(682, 103);
            this.themKhachHang.Margin = new System.Windows.Forms.Padding(5);
            this.themKhachHang.Name = "themKhachHang";
            this.themKhachHang.Size = new System.Drawing.Size(138, 23);
            this.themKhachHang.TabIndex = 52;
            this.themKhachHang.Text = "Thêm khách hàng";
            this.themKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.themKhachHang.UseVisualStyleBackColor = true;
            this.themKhachHang.Click += new System.EventHandler(this.themKhachHang_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(116, 69);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 19);
            this.label12.TabIndex = 53;
            this.label12.Text = "Mã hóa đơn";
            // 
            // maHoaDon
            // 
            this.maHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maHoaDon.Location = new System.Drawing.Point(380, 68);
            this.maHoaDon.Margin = new System.Windows.Forms.Padding(5);
            this.maHoaDon.Name = "maHoaDon";
            this.maHoaDon.Size = new System.Drawing.Size(294, 20);
            this.maHoaDon.TabIndex = 54;
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSanPham";
            this.MaSP.HeaderText = "Mã sản phẩm";
            this.MaSP.Name = "MaSP";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenSanPham";
            this.Column2.HeaderText = "Tên sản phẩm";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SoLg
            // 
            this.SoLg.DataPropertyName = "SoLuong";
            this.SoLg.HeaderText = "Số lượng";
            this.SoLg.Name = "SoLg";
            // 
            // Giaa
            // 
            this.Giaa.DataPropertyName = "Gia";
            this.Giaa.HeaderText = "Giá";
            this.Giaa.Name = "Giaa";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Khuyến mãi";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Giá(KM)";
            this.Column3.Name = "Column3";
            // 
            // ThemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 733);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.maHoaDon);
            this.Controls.Add(this.themKhachHang);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbbBan);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ngayLapHoaDon);
            this.Controls.Add(this.huyHoaDon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.thanhToan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxMaKhachHang);
            this.Controls.Add(this.maNhanVien);
            this.Controls.Add(this.tongTienHoaDon);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemHoaDon";
            this.Load += new System.EventHandler(this.ThemHoaDon_Load);
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
        private System.Windows.Forms.TextBox tongTienHoaDon;
        private System.Windows.Forms.Button thanhToan;
        private System.Windows.Forms.Button huyHoaDon;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbbBan;
        private System.Windows.Forms.Button themKhachHang;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox maHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Giaa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}