namespace Phan_tich_thiet_ke_HTTT
{
    partial class QuanLyDatHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyDatHang));
            this.dgvPDH = new System.Windows.Forms.DataGridView();
            this.mahd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaylap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dateNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXoaCTPDH = new System.Windows.Forms.Button();
            this.btnThemCTPDH = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvCTPDH = new System.Windows.Forms.DataGridView();
            this.mahd1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tensp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dongia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnLuuCTPDH = new System.Windows.Forms.Button();
            this.btnSuaCTPDH = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbboxTenSP = new System.Windows.Forms.ComboBox();
            this.cbboxMaPhieu = new System.Windows.Forms.ComboBox();
            this.txtTenNhaCungCap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDH)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPDH)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPDH
            // 
            this.dgvPDH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPDH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mahd,
            this.ngaylap,
            this.TENNV});
            this.dgvPDH.Location = new System.Drawing.Point(7, 196);
            this.dgvPDH.Name = "dgvPDH";
            this.dgvPDH.RowTemplate.Height = 24;
            this.dgvPDH.Size = new System.Drawing.Size(595, 177);
            this.dgvPDH.TabIndex = 8;
            this.dgvPDH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPDH_CellClick);
            // 
            // mahd
            // 
            this.mahd.HeaderText = "Mã phiếu";
            this.mahd.Name = "mahd";
            // 
            // ngaylap
            // 
            this.ngaylap.HeaderText = "Ngày lập";
            this.ngaylap.Name = "ngaylap";
            // 
            // TENNV
            // 
            this.TENNV.HeaderText = "Người quản lý";
            this.TENNV.Name = "TENNV";
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.Blue;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(129, 380);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(112, 43);
            this.btnThem.TabIndex = 65;
            this.btnThem.Text = "Insert";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(126, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ngày lập";
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(295, 44);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(186, 24);
            this.txtMaPhieu.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.dateNgayLap);
            this.groupBox1.Controls.Add(this.dgvPDH);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMaPhieu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 437);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phiếu đặt hàng";
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.Blue;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(249, 380);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(112, 43);
            this.btnLuu.TabIndex = 77;
            this.btnLuu.Text = "Save";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.Blue;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(369, 380);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(112, 43);
            this.btnXoa.TabIndex = 75;
            this.btnXoa.Text = "Delete";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dateNgayLap
            // 
            this.dateNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dateNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayLap.Location = new System.Drawing.Point(295, 96);
            this.dateNgayLap.Name = "dateNgayLap";
            this.dateNgayLap.Size = new System.Drawing.Size(186, 24);
            this.dateNgayLap.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(126, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã phiếu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(524, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 38);
            this.label1.TabIndex = 17;
            this.label1.Text = "QUẢN LÝ ĐẶT HÀNG";
            // 
            // btnXoaCTPDH
            // 
            this.btnXoaCTPDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoaCTPDH.ForeColor = System.Drawing.Color.Blue;
            this.btnXoaCTPDH.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaCTPDH.Image")));
            this.btnXoaCTPDH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaCTPDH.Location = new System.Drawing.Point(282, 380);
            this.btnXoaCTPDH.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaCTPDH.Name = "btnXoaCTPDH";
            this.btnXoaCTPDH.Size = new System.Drawing.Size(112, 43);
            this.btnXoaCTPDH.TabIndex = 71;
            this.btnXoaCTPDH.Text = "Delete";
            this.btnXoaCTPDH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaCTPDH.UseVisualStyleBackColor = true;
            this.btnXoaCTPDH.Click += new System.EventHandler(this.btnXoaCTPDH_Click);
            // 
            // btnThemCTPDH
            // 
            this.btnThemCTPDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThemCTPDH.ForeColor = System.Drawing.Color.Blue;
            this.btnThemCTPDH.Image = ((System.Drawing.Image)(resources.GetObject("btnThemCTPDH.Image")));
            this.btnThemCTPDH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemCTPDH.Location = new System.Drawing.Point(42, 380);
            this.btnThemCTPDH.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemCTPDH.Name = "btnThemCTPDH";
            this.btnThemCTPDH.Size = new System.Drawing.Size(112, 43);
            this.btnThemCTPDH.TabIndex = 70;
            this.btnThemCTPDH.Text = "Insert";
            this.btnThemCTPDH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemCTPDH.UseVisualStyleBackColor = true;
            this.btnThemCTPDH.Click += new System.EventHandler(this.btnThemCTPDH_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Mã phiếu";
            // 
            // dgvCTPDH
            // 
            this.dgvCTPDH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTPDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTPDH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mahd1,
            this.Tensp,
            this.sl,
            this.dongia,
            this.thanhtien});
            this.dgvCTPDH.Location = new System.Drawing.Point(22, 196);
            this.dgvCTPDH.Name = "dgvCTPDH";
            this.dgvCTPDH.RowTemplate.Height = 24;
            this.dgvCTPDH.Size = new System.Drawing.Size(638, 177);
            this.dgvCTPDH.TabIndex = 7;
            this.dgvCTPDH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTPDH_CellClick);
            // 
            // mahd1
            // 
            this.mahd1.HeaderText = "Mã phiếu";
            this.mahd1.Name = "mahd1";
            // 
            // Tensp
            // 
            this.Tensp.HeaderText = "Tên sản phẩm";
            this.Tensp.Name = "Tensp";
            // 
            // sl
            // 
            this.sl.HeaderText = "Số lượng";
            this.sl.Name = "sl";
            // 
            // dongia
            // 
            this.dongia.HeaderText = "Đơn giá";
            this.dongia.Name = "dongia";
            // 
            // thanhtien
            // 
            this.thanhtien.HeaderText = "Thành tiền";
            this.thanhtien.Name = "thanhtien";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên sản phẩm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTenNhaCungCap);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnIn);
            this.groupBox2.Controls.Add(this.btnLuuCTPDH);
            this.groupBox2.Controls.Add(this.btnSuaCTPDH);
            this.groupBox2.Controls.Add(this.txtTongTien);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtDonGia);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtSoLuong);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbboxTenSP);
            this.groupBox2.Controls.Add(this.cbboxMaPhieu);
            this.groupBox2.Controls.Add(this.btnXoaCTPDH);
            this.groupBox2.Controls.Add(this.btnThemCTPDH);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dgvCTPDH);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(643, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 437);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết phiếu đặt hàng";
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnIn.ForeColor = System.Drawing.Color.Blue;
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(522, 380);
            this.btnIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(112, 43);
            this.btnIn.TabIndex = 83;
            this.btnIn.Text = "Print";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnLuuCTPDH
            // 
            this.btnLuuCTPDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLuuCTPDH.ForeColor = System.Drawing.Color.Blue;
            this.btnLuuCTPDH.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuCTPDH.Image")));
            this.btnLuuCTPDH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuCTPDH.Location = new System.Drawing.Point(162, 380);
            this.btnLuuCTPDH.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuuCTPDH.Name = "btnLuuCTPDH";
            this.btnLuuCTPDH.Size = new System.Drawing.Size(112, 43);
            this.btnLuuCTPDH.TabIndex = 79;
            this.btnLuuCTPDH.Text = "Save";
            this.btnLuuCTPDH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuCTPDH.UseVisualStyleBackColor = true;
            this.btnLuuCTPDH.Click += new System.EventHandler(this.btnLuuCTPDH_Click);
            // 
            // btnSuaCTPDH
            // 
            this.btnSuaCTPDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSuaCTPDH.ForeColor = System.Drawing.Color.Blue;
            this.btnSuaCTPDH.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaCTPDH.Image")));
            this.btnSuaCTPDH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaCTPDH.Location = new System.Drawing.Point(402, 380);
            this.btnSuaCTPDH.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuaCTPDH.Name = "btnSuaCTPDH";
            this.btnSuaCTPDH.Size = new System.Drawing.Size(112, 43);
            this.btnSuaCTPDH.TabIndex = 78;
            this.btnSuaCTPDH.Text = "Update";
            this.btnSuaCTPDH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaCTPDH.UseVisualStyleBackColor = true;
            this.btnSuaCTPDH.Click += new System.EventHandler(this.btnSuaCTPDH_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(472, 142);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(162, 24);
            this.txtTongTien.TabIndex = 82;
            this.txtTongTien.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(364, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 81;
            this.label10.Text = "Tổng tiền";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(472, 97);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(162, 24);
            this.txtDonGia.TabIndex = 80;
            this.txtDonGia.Text = "0";
            this.txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(364, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 79;
            this.label8.Text = "Đơn giá";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(472, 48);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(162, 24);
            this.txtSoLuong.TabIndex = 78;
            this.txtSoLuong.Text = "0";
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(364, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 77;
            this.label7.Text = "Số lượng";
            // 
            // cbboxTenSP
            // 
            this.cbboxTenSP.FormattingEnabled = true;
            this.cbboxTenSP.Location = new System.Drawing.Point(176, 97);
            this.cbboxTenSP.Name = "cbboxTenSP";
            this.cbboxTenSP.Size = new System.Drawing.Size(162, 26);
            this.cbboxTenSP.TabIndex = 76;
            this.cbboxTenSP.Text = "--Chọn--";
            // 
            // cbboxMaPhieu
            // 
            this.cbboxMaPhieu.FormattingEnabled = true;
            this.cbboxMaPhieu.Location = new System.Drawing.Point(176, 52);
            this.cbboxMaPhieu.Name = "cbboxMaPhieu";
            this.cbboxMaPhieu.Size = new System.Drawing.Size(162, 26);
            this.cbboxMaPhieu.TabIndex = 75;
            this.cbboxMaPhieu.Text = "--Chọn--";
            this.cbboxMaPhieu.SelectedIndexChanged += new System.EventHandler(this.cbboxMaPhieu_SelectedIndexChanged);
            // 
            // txtTenNhaCungCap
            // 
            this.txtTenNhaCungCap.Location = new System.Drawing.Point(176, 144);
            this.txtTenNhaCungCap.Name = "txtTenNhaCungCap";
            this.txtTenNhaCungCap.Size = new System.Drawing.Size(162, 24);
            this.txtTenNhaCungCap.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 20);
            this.label6.TabIndex = 84;
            this.label6.Text = "Tên nhà cung cấp";
            // 
            // QuanLyDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1336, 548);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "QuanLyDatHang";
            this.Text = "Quản lý đặt hàng";
            this.Load += new System.EventHandler(this.QuanLyDatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPDH)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPDH;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXoaCTPDH;
        private System.Windows.Forms.Button btnThemCTPDH;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvCTPDH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbboxTenSP;
        private System.Windows.Forms.ComboBox cbboxMaPhieu;
        private System.Windows.Forms.DateTimePicker dateNgayLap;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaylap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahd1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tensp;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dongia;
        private System.Windows.Forms.DataGridViewTextBoxColumn thanhtien;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuuCTPDH;
        private System.Windows.Forms.Button btnSuaCTPDH;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.TextBox txtTenNhaCungCap;
        private System.Windows.Forms.Label label6;
    }
}