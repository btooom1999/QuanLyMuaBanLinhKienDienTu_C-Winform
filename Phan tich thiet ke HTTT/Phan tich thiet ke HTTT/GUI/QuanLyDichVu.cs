using Phan_tich_thiet_ke_HTTT.DAO;
using Phan_tich_thiet_ke_HTTT.POJO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_tich_thiet_ke_HTTT.GUI
{
    public partial class QuanLyDichVu : Form
    {
        public QuanLyDichVu()
        {
            InitializeComponent();
        }

        public static List<DICHVU> dsDV = DICHVUDAO.getDSDV();

        ConnectionDB cn = new ConnectionDB();

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm dịch vụ mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                txtTenDV.Enabled = true;
                txtMaDV.Enabled = false;
                txtGia.Enabled = true;
                txtMaDV.Text = DICHVUDAO.KiemTraMaDVTuDongTang(dsDV, DICHVUDAO.MaDVTuDong(dsDV));
                txtGia.Text = "0";
                txtTenDV.Text = "";
                txtTenDV.Focus();
            }
        }

        public void loaddulieudichvu(){
            dgvDV.Rows.Clear();
            foreach (DICHVU dv in dsDV)
                dgvDV.Rows.Add(dv.getMadv(), dv.getTendv(), dv.getGia());
        }

        public void LamMoi()
        {
            txtGia.Enabled = false;
            txtMaDV.Enabled = false;
            txtTenDV.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtGia.Text = "0";
            txtMaDV.Text = "";
            txtTenDV.Text = "";
            loaddulieudichvu();
        }

        private void QuanLyDichVu_Load(object sender, EventArgs e)
        {
            LamMoi();
            loaddulieudichvu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (kttxt())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa dịch vụ này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "update dichvu set tendv = N'" + txtTenDV.Text.Trim() + "', dongia = " + Decimal.Parse(txtGia.Text.Trim()) + " where madv = '" + txtMaDV.Text.Trim() + "'";
                    cn.themxoasua(sql);
                    DICHVUDAO.SuaDV(dsDV, txtMaDV.Text.Trim(), txtTenDV.Text.Trim(), Decimal.Parse(txtGia.Text.Trim()));
                    DataGridViewRow row = dgvDV.Rows[index];
                    row.Cells[1].Value = txtTenDV.Text.Trim();
                    row.Cells[2].Value = txtGia.Text.Trim();
                    MessageBox.Show("Sửa thành công");
                }
            }
        }

        int index;

        private void dgvDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;

            if (index < 0 || index >= dgvDV.RowCount - 1)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng để thực hiện xóa hoặc sửa");
                return;
            }

            txtMaDV.Text = dgvDV.Rows[index].Cells[0].Value.ToString();
            txtTenDV.Text = dgvDV.Rows[index].Cells[1].Value.ToString();
            txtGia.Text = dgvDV.Rows[index].Cells[2].Value.ToString();

            txtMaDV.Enabled = false;
            txtGia.Enabled = true;
            txtTenDV.Enabled = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        public Boolean kttontaimadv()
        {
            if (DICHVUDAO.KiemTraTonTaiMaDV(QuanLySuaChua.dsCTHDDV, txtMaDV.Text.Trim()))
            {
                MessageBox.Show("Mã dịch vụ này có dữ liệu, không thể xóa");
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (kttontaimadv())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "delete from dichvu where madv = '" + txtMaDV.Text.Trim() + "'";
                    cn.themxoasua(sql);
                    DICHVUDAO.XoaDV(dsDV, txtMaDV.Text.Trim());
                    dgvDV.Rows.RemoveAt(index);
                    MessageBox.Show("Xóa thành công");
                }
            }
        }

        public Boolean kttxt()
        {
            if (txtGia.Text.Equals("") || txtTenDV.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return false;
            }
            return true;
        }

        public Boolean kttrung()
        {
            if (DICHVUDAO.KiemTraTrungMaDV(dsDV, txtMaDV.Text.Trim()))
            {
                MessageBox.Show("Mã dịch vụ này đã tồn tại, không thể lưu");
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kttxt() && kttrung())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu dịch vụ này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "insert into dichvu values ('" + txtMaDV.Text.Trim() + "', N'" + txtTenDV.Text.Trim() + "', " + Decimal.Parse(txtGia.Text.Trim()) + ")";
                    cn.themxoasua(sql);
                    DICHVUDAO.ThemDV(dsDV, txtMaDV.Text.Trim(), txtTenDV.Text.Trim(), Decimal.Parse(txtGia.Text.Trim()));
                    dgvDV.Rows.Add(txtMaDV.Text.Trim(), txtTenDV.Text.Trim(), Decimal.Parse(txtGia.Text.Trim()));
                    MessageBox.Show("Lưu thành công");
                    btnThem.Enabled = true;
                    btnLuu.Enabled = false;
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Textbox này chỉ cho nhập số, vui lòng nhập số");
                e.Handled = true;
            }
        }
    }
}
