namespace Phan_tich_thiet_ke_HTTT
{
    partial class ThongKeSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongKeSanPham));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTK = new System.Windows.Forms.DataGridView();
            this.msp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tensp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnTK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTong = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(74, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 36);
            this.label1.TabIndex = 80;
            this.label1.Text = "THỐNG KÊ SẢN PHẨM";
            // 
            // dgvTK
            // 
            this.dgvTK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.msp,
            this.tensp,
            this.slton});
            this.dgvTK.Location = new System.Drawing.Point(71, 84);
            this.dgvTK.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTK.Name = "dgvTK";
            this.dgvTK.RowTemplate.Height = 24;
            this.dgvTK.Size = new System.Drawing.Size(355, 119);
            this.dgvTK.TabIndex = 81;
            // 
            // msp
            // 
            this.msp.HeaderText = "Mã sản phẩm";
            this.msp.Name = "msp";
            // 
            // tensp
            // 
            this.tensp.HeaderText = "Tên sản phẩm";
            this.tensp.Name = "tensp";
            // 
            // slton
            // 
            this.slton.HeaderText = "Số lượng tồn";
            this.slton.Name = "slton";
            // 
            // btnIn
            // 
            this.btnIn.Enabled = false;
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnIn.ForeColor = System.Drawing.Color.Blue;
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(260, 265);
            this.btnIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(166, 49);
            this.btnIn.TabIndex = 83;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnTK
            // 
            this.btnTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTK.ForeColor = System.Drawing.Color.Blue;
            this.btnTK.Image = ((System.Drawing.Image)(resources.GetObject("btnTK.Image")));
            this.btnTK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTK.Location = new System.Drawing.Point(70, 265);
            this.btnTK.Margin = new System.Windows.Forms.Padding(4);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(166, 49);
            this.btnTK.TabIndex = 82;
            this.btnTK.Text = "Thống kê";
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(165, 224);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 84;
            this.label2.Text = "Tổng sản phẩm";
            // 
            // txtTong
            // 
            this.txtTong.Enabled = false;
            this.txtTong.Location = new System.Drawing.Point(314, 222);
            this.txtTong.Margin = new System.Windows.Forms.Padding(4);
            this.txtTong.Name = "txtTong";
            this.txtTong.Size = new System.Drawing.Size(112, 24);
            this.txtTong.TabIndex = 85;
            // 
            // ThongKeSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(498, 393);
            this.Controls.Add(this.txtTong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.dgvTK);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThongKeSanPham";
            this.Text = "Thống kê sản phẩm";
            this.Load += new System.EventHandler(this.ThongKeSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn msp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tensp;
        private System.Windows.Forms.DataGridViewTextBoxColumn slton;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTong;
    }
}