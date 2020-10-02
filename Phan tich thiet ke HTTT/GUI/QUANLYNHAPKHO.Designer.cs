namespace Phan_tich_thiet_ke_HTTT
{
    partial class QuanLyNhapKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyNhapKho));
            this.cbboxMaNK = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvCTNK = new System.Windows.Forms.DataGridView();
            this.mahd1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tensp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbboxTenSP = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLuuCTNK = new System.Windows.Forms.Button();
            this.btnXoaCTNK = new System.Windows.Forms.Button();
            this.btnThemCTNK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaNK = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvNK = new System.Windows.Forms.DataGridView();
            this.mahd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaylap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MANV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenncc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cbboxTenNCC = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dateNgayLap = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTNK)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNK)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbboxMaNK
            // 
            this.cbboxMaNK.FormattingEnabled = true;
            this.cbboxMaNK.Location = new System.Drawing.Point(238, 36);
            this.cbboxMaNK.Name = "cbboxMaNK";
            this.cbboxMaNK.Size = new System.Drawing.Size(204, 28);
            this.cbboxMaNK.TabIndex = 8;
            this.cbboxMaNK.Text = "--Chọn--";
            this.cbboxMaNK.SelectedIndexChanged += new System.EventHandler(this.cbboxMaNK_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(93, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 18);
            this.label9.TabIndex = 8;
            this.label9.Text = "Mã nhập kho";
            // 
            // dgvCTNK
            // 
            this.dgvCTNK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTNK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTNK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mahd1,
            this.Tensp,
            this.SL});
            this.dgvCTNK.Location = new System.Drawing.Point(6, 169);
            this.dgvCTNK.Name = "dgvCTNK";
            this.dgvCTNK.RowTemplate.Height = 24;
            this.dgvCTNK.Size = new System.Drawing.Size(521, 177);
            this.dgvCTNK.TabIndex = 7;
            this.dgvCTNK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTNK_CellClick);
            // 
            // mahd1
            // 
            this.mahd1.HeaderText = "Mã nhập kho";
            this.mahd1.Name = "mahd1";
            // 
            // Tensp
            // 
            this.Tensp.HeaderText = "Tên sản phẩm";
            this.Tensp.Name = "Tensp";
            // 
            // SL
            // 
            this.SL.HeaderText = "Số lượng";
            this.SL.Name = "SL";
            // 
            // cbboxTenSP
            // 
            this.cbboxTenSP.FormattingEnabled = true;
            this.cbboxTenSP.Location = new System.Drawing.Point(238, 77);
            this.cbboxTenSP.Name = "cbboxTenSP";
            this.cbboxTenSP.Size = new System.Drawing.Size(204, 28);
            this.cbboxTenSP.TabIndex = 9;
            this.cbboxTenSP.Text = "--Chọn--";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(238, 122);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(204, 27);
            this.txtSoLuong.TabIndex = 10;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số lượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên sản phẩm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLuuCTNK);
            this.groupBox2.Controls.Add(this.btnXoaCTNK);
            this.groupBox2.Controls.Add(this.btnThemCTNK);
            this.groupBox2.Controls.Add(this.cbboxMaNK);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dgvCTNK);
            this.groupBox2.Controls.Add(this.cbboxTenSP);
            this.groupBox2.Controls.Add(this.txtSoLuong);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(848, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(533, 417);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết nhập kho";
            // 
            // btnLuuCTNK
            // 
            this.btnLuuCTNK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLuuCTNK.ForeColor = System.Drawing.Color.Blue;
            this.btnLuuCTNK.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuCTNK.Image")));
            this.btnLuuCTNK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuCTNK.Location = new System.Drawing.Point(226, 353);
            this.btnLuuCTNK.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuuCTNK.Name = "btnLuuCTNK";
            this.btnLuuCTNK.Size = new System.Drawing.Size(112, 43);
            this.btnLuuCTNK.TabIndex = 12;
            this.btnLuuCTNK.Text = "Save";
            this.btnLuuCTNK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuCTNK.UseVisualStyleBackColor = true;
            this.btnLuuCTNK.Click += new System.EventHandler(this.btnLuuCTNK_Click);
            // 
            // btnXoaCTNK
            // 
            this.btnXoaCTNK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoaCTNK.ForeColor = System.Drawing.Color.Blue;
            this.btnXoaCTNK.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaCTNK.Image")));
            this.btnXoaCTNK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaCTNK.Location = new System.Drawing.Point(346, 353);
            this.btnXoaCTNK.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaCTNK.Name = "btnXoaCTNK";
            this.btnXoaCTNK.Size = new System.Drawing.Size(112, 43);
            this.btnXoaCTNK.TabIndex = 13;
            this.btnXoaCTNK.Text = "Delete";
            this.btnXoaCTNK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaCTNK.UseVisualStyleBackColor = true;
            this.btnXoaCTNK.Click += new System.EventHandler(this.btnXoaCTNK_Click);
            // 
            // btnThemCTNK
            // 
            this.btnThemCTNK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThemCTNK.ForeColor = System.Drawing.Color.Blue;
            this.btnThemCTNK.Image = ((System.Drawing.Image)(resources.GetObject("btnThemCTNK.Image")));
            this.btnThemCTNK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemCTNK.Location = new System.Drawing.Point(106, 353);
            this.btnThemCTNK.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemCTNK.Name = "btnThemCTNK";
            this.btnThemCTNK.Size = new System.Drawing.Size(112, 43);
            this.btnThemCTNK.TabIndex = 11;
            this.btnThemCTNK.Text = "Insert";
            this.btnThemCTNK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemCTNK.UseVisualStyleBackColor = true;
            this.btnThemCTNK.Click += new System.EventHandler(this.btnThemCTNK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(476, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "QUẢN LÝ NHẬP KHO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(115, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã nhập kho";
            // 
            // txtMaNK
            // 
            this.txtMaNK.Location = new System.Drawing.Point(241, 39);
            this.txtMaNK.Name = "txtMaNK";
            this.txtMaNK.Size = new System.Drawing.Size(161, 27);
            this.txtMaNK.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(115, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ngày lập";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(424, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(565, 81);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(161, 27);
            this.txtGhiChu.TabIndex = 3;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.Blue;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(204, 353);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(112, 43);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Insert";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvNK
            // 
            this.dgvNK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mahd,
            this.ngaylap,
            this.MANV,
            this.tenncc,
            this.gc});
            this.dgvNK.Location = new System.Drawing.Point(6, 169);
            this.dgvNK.Name = "dgvNK";
            this.dgvNK.RowTemplate.Height = 24;
            this.dgvNK.Size = new System.Drawing.Size(821, 177);
            this.dgvNK.TabIndex = 8;
            this.dgvNK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNK_CellClick);
            // 
            // mahd
            // 
            this.mahd.HeaderText = "Mã phiếu nhập kho";
            this.mahd.Name = "mahd";
            // 
            // ngaylap
            // 
            this.ngaylap.HeaderText = "Ngày lập";
            this.ngaylap.Name = "ngaylap";
            // 
            // MANV
            // 
            this.MANV.HeaderText = "Mã nhân viên";
            this.MANV.Name = "MANV";
            // 
            // tenncc
            // 
            this.tenncc.HeaderText = "Tên nhà cung cấp";
            this.tenncc.Name = "tenncc";
            // 
            // gc
            // 
            this.gc.HeaderText = "Ghi chú";
            this.gc.Name = "gc";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(424, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 18);
            this.label8.TabIndex = 66;
            this.label8.Text = "Tên nhà cung cấp";
            // 
            // cbboxTenNCC
            // 
            this.cbboxTenNCC.FormattingEnabled = true;
            this.cbboxTenNCC.Location = new System.Drawing.Point(565, 35);
            this.cbboxTenNCC.Name = "cbboxTenNCC";
            this.cbboxTenNCC.Size = new System.Drawing.Size(161, 28);
            this.cbboxTenNCC.TabIndex = 1;
            this.cbboxTenNCC.Text = "--Chọn--";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.dateNgayLap);
            this.groupBox1.Controls.Add(this.cbboxTenNCC);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dgvNK);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMaNK);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 417);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập kho";
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.Blue;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(324, 353);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(112, 43);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Save";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.Blue;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(565, 353);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(112, 43);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Update";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click_1);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.Blue;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(444, 353);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(112, 43);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Delete";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dateNgayLap
            // 
            this.dateNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dateNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayLap.Location = new System.Drawing.Point(241, 81);
            this.dateNgayLap.Name = "dateNgayLap";
            this.dateNgayLap.Size = new System.Drawing.Size(161, 27);
            this.dateNgayLap.TabIndex = 2;
            // 
            // QuanLyNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1393, 574);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "QuanLyNhapKho";
            this.Text = "Quản lý nhập kho";
            this.Load += new System.EventHandler(this.QuanLyNhapKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTNK)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNK)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbboxMaNK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvCTNK;
        private System.Windows.Forms.ComboBox cbboxTenSP;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXoaCTNK;
        private System.Windows.Forms.Button btnThemCTNK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaNK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvNK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbboxTenNCC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahd1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tensp;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL;
        private System.Windows.Forms.DateTimePicker dateNgayLap;
        private System.Windows.Forms.Button btnLuuCTNK;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaylap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MANV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenncc;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc;
    }
}