namespace quanlycaphe.quanlidonhang
{
    partial class Dasboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dasboard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timKiem = new System.Windows.Forms.Button();
            this.txtTenKM_TK = new System.Windows.Forms.TextBox();
            this.dgvDanhSachHoaDon = new System.Windows.Forms.DataGridView();
            this.nhapExcel = new System.Windows.Forms.Button();
            this.themHoaDon = new System.Windows.Forms.Button();
            this.xuatExcel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDuongDan = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHoaDon)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timKiem);
            this.groupBox1.Controls.Add(this.themHoaDon);
            this.groupBox1.Controls.Add(this.txtTenKM_TK);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, -11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1182, 107);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // timKiem
            // 
            this.timKiem.BackColor = System.Drawing.Color.Cornsilk;
            this.timKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timKiem.Image = ((System.Drawing.Image)(resources.GetObject("timKiem.Image")));
            this.timKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timKiem.Location = new System.Drawing.Point(1027, 29);
            this.timKiem.Margin = new System.Windows.Forms.Padding(5);
            this.timKiem.Name = "timKiem";
            this.timKiem.Size = new System.Drawing.Size(119, 54);
            this.timKiem.TabIndex = 9;
            this.timKiem.Text = "Tìm kiếm";
            this.timKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.timKiem.UseVisualStyleBackColor = false;
            this.timKiem.Click += new System.EventHandler(this.txtTimKiem_Click);
            // 
            // txtTenKM_TK
            // 
            this.txtTenKM_TK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenKM_TK.Location = new System.Drawing.Point(645, 43);
            this.txtTenKM_TK.Margin = new System.Windows.Forms.Padding(5);
            this.txtTenKM_TK.Name = "txtTenKM_TK";
            this.txtTenKM_TK.Size = new System.Drawing.Size(352, 29);
            this.txtTenKM_TK.TabIndex = 3;
            // 
            // dgvDanhSachHoaDon
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvDanhSachHoaDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSachHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachHoaDon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDanhSachHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDanhSachHoaDon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDanhSachHoaDon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSachHoaDon.ColumnHeadersHeight = 35;
            this.dgvDanhSachHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDanhSachHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column8,
            this.Column4});
            this.dgvDanhSachHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvDanhSachHoaDon.EnableHeadersVisualStyles = false;
            this.dgvDanhSachHoaDon.GridColor = System.Drawing.Color.LightGray;
            this.dgvDanhSachHoaDon.Location = new System.Drawing.Point(1, 121);
            this.dgvDanhSachHoaDon.Margin = new System.Windows.Forms.Padding(5);
            this.dgvDanhSachHoaDon.Name = "dgvDanhSachHoaDon";
            this.dgvDanhSachHoaDon.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDanhSachHoaDon.RowHeadersVisible = false;
            this.dgvDanhSachHoaDon.RowTemplate.Height = 30;
            this.dgvDanhSachHoaDon.Size = new System.Drawing.Size(1182, 464);
            this.dgvDanhSachHoaDon.TabIndex = 13;
            this.dgvDanhSachHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhuyenMai_CellContentClick);
            // 
            // nhapExcel
            // 
            this.nhapExcel.BackColor = System.Drawing.Color.Turquoise;
            this.nhapExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nhapExcel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhapExcel.Image = ((System.Drawing.Image)(resources.GetObject("nhapExcel.Image")));
            this.nhapExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nhapExcel.Location = new System.Drawing.Point(61, 144);
            this.nhapExcel.Margin = new System.Windows.Forms.Padding(5);
            this.nhapExcel.Name = "nhapExcel";
            this.nhapExcel.Size = new System.Drawing.Size(146, 42);
            this.nhapExcel.TabIndex = 25;
            this.nhapExcel.Text = "Nhập excel";
            this.nhapExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.nhapExcel.UseVisualStyleBackColor = false;
            // 
            // themHoaDon
            // 
            this.themHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themHoaDon.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("themHoaDon.Image")));
            this.themHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.themHoaDon.Location = new System.Drawing.Point(61, 32);
            this.themHoaDon.Margin = new System.Windows.Forms.Padding(5);
            this.themHoaDon.Name = "themHoaDon";
            this.themHoaDon.Size = new System.Drawing.Size(146, 51);
            this.themHoaDon.TabIndex = 31;
            this.themHoaDon.Text = "Thêm mới";
            this.themHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.themHoaDon.UseVisualStyleBackColor = true;
            this.themHoaDon.Click += new System.EventHandler(this.buttonThemMoi_Click);
            // 
            // xuatExcel
            // 
            this.xuatExcel.BackColor = System.Drawing.Color.PeachPuff;
            this.xuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xuatExcel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xuatExcel.Location = new System.Drawing.Point(983, 144);
            this.xuatExcel.Margin = new System.Windows.Forms.Padding(5);
            this.xuatExcel.Name = "xuatExcel";
            this.xuatExcel.Size = new System.Drawing.Size(163, 42);
            this.xuatExcel.TabIndex = 35;
            this.xuatExcel.Text = "Xuất excel";
            this.xuatExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.xuatExcel.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonBrowse);
            this.groupBox2.Controls.Add(this.txtDuongDan);
            this.groupBox2.Controls.Add(this.xuatExcel);
            this.groupBox2.Controls.Add(this.nhapExcel);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1, 570);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(1182, 252);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaHoaDon";
            this.Column1.HeaderText = "Mã hóa đơn";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenKhachHang";
            this.Column2.HeaderText = "Tên khách hàng";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NhanVienLapHoaDon";
            this.Column3.HeaderText = "Nhân viên lập hóa đơn";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NgayLapHoaDon";
            this.Column5.HeaderText = "Ngày lập hóa đơn";
            this.Column5.Name = "Column5";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "TongTienKM";
            this.Column8.HeaderText = "Tổng tiền(KM)";
            this.Column8.Name = "Column8";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MaKM";
            this.Column4.HeaderText = "Mã KM";
            this.Column4.Name = "Column4";
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDuongDan.Location = new System.Drawing.Point(458, 153);
            this.txtDuongDan.Margin = new System.Windows.Forms.Padding(5);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.Size = new System.Drawing.Size(352, 29);
            this.txtDuongDan.TabIndex = 32;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.BackColor = System.Drawing.Color.NavajoWhite;
            this.buttonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowse.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowse.ForeColor = System.Drawing.Color.Brown;
            this.buttonBrowse.Image = ((System.Drawing.Image)(resources.GetObject("buttonBrowse.Image")));
            this.buttonBrowse.Location = new System.Drawing.Point(833, 153);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(5);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(114, 29);
            this.buttonBrowse.TabIndex = 36;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonBrowse.UseVisualStyleBackColor = false;
            // 
            // Dasboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1184, 811);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvDanhSachHoaDon);
            this.Name = "Dasboard";
            this.Text = "   ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHoaDon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button timKiem;
        private System.Windows.Forms.TextBox txtTenKM_TK;
        private System.Windows.Forms.DataGridView dgvDanhSachHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button nhapExcel;
        private System.Windows.Forms.Button themHoaDon;
        private System.Windows.Forms.Button xuatExcel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox txtDuongDan;
    }
}