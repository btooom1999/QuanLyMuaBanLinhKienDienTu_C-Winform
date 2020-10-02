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

namespace Phan_tich_thiet_ke_HTTT
{
    public partial class QuanLyHangHoa : Form
    {
        public static List<LOAISANPHAM> dsLSP = LOAISANPHAMDAO.getDSLOAISANPHAM();
        public static List<SANPHAM> dsSP = SANPHAMDAO.getDSSANPHAM();

        ConnectionDB cn = new ConnectionDB();

        public QuanLyHangHoa()
        {
            InitializeComponent();
            cbboxTenLSP.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void loaddulieuloaisanpham()
        {
            dgvLSP.Rows.Clear();
            foreach (LOAISANPHAM lsp in dsLSP)
            {
                dgvLSP.Rows.Add(lsp.getMaloai(), lsp.getTenloai());
                cbboxTenLSP.Items.Add(lsp.getTenloai());
            }
        }

        public void loaddulieusanpham()
        {
            dgvSP.Rows.Clear();
            foreach (SANPHAM sp in dsSP)
                dgvSP.Rows.Add(sp.getMasp(), sp.getTensp(), sp.getGia(), LOAISANPHAMDAO.TenLoaiSP(dsLSP, sp.getMaloai()));
        }

        public void LamMoiSP()
        {
            txtGia.Enabled = false;
            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            cbboxTenLSP.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtGia.Text = "0";
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            cbboxTenLSP.SelectedIndex = -1;
            cbboxTenLSP.Text = "--Chọn--";
        }

        public void LamMoiLSP()
        {
            txtMaLSP.Enabled = false;
            txtTenLSP.Enabled = false;
            btnThemLSP.Enabled = true;
            btnLuuLSP.Enabled = false;
            btnXoaLSP.Enabled = false;
            btnSuaLSP.Enabled = false;
            txtMaLSP.Text = "";
            txtTenLSP.Text = "";
        }

        private void QLHH_Load(object sender, EventArgs e)
        {
            LamMoiSP();
            LamMoiLSP();
            loaddulieuloaisanpham();
            loaddulieusanpham();
        }

        int indexLSP;

        private void dgvLSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexLSP = e.RowIndex;
            if (indexLSP < 0 || indexLSP >= dgvLSP.Rows.Count - 1)
            {
                MessageBox.Show("Vui lòng nhập đúng dòng để sửa hoặc xóa");
                return;
            }
            txtMaLSP.Enabled = false;
            txtMaLSP.Text = dgvLSP.Rows[indexLSP].Cells[0].Value.ToString();
            txtTenLSP.Text = dgvLSP.Rows[indexLSP].Cells[1].Value.ToString();
            btnThemLSP.Enabled = true;
            btnLuuLSP.Enabled = false;
            btnXoaLSP.Enabled = true;
            btnSuaLSP.Enabled = true;
            txtTenLSP.Enabled = true;
        }

        private void btnXoaLSP_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa thông tin loại sản phẩm này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                String sql = "delete from loaisp where maloai = '" + txtMaLSP.Text.Trim() + "'";
                cn.themxoasua(sql);
                LOAISANPHAMDAO.XoaLoaiSP(dsLSP, txtMaLSP.Text.Trim());
                dgvLSP.Rows.RemoveAt(indexLSP);
                cbboxTenLSP.Items.Remove(txtTenLSP.Text.Trim());
                MessageBox.Show("Xóa thành công");
            }
        }

        private void btnSuaLSP_Click(object sender, EventArgs e)
        {
            if (kttxtLSP())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa thông tin loại sản phẩm này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "update loaisp set tenloai = N'" + txtTenLSP.Text.Trim() + "' where maloai = '" + txtMaLSP.Text.Trim() + "'";
                    cn.themxoasua(sql);
                    LOAISANPHAMDAO.SuaLoaiSP(dsLSP, txtMaLSP.Text.Trim(), txtTenLSP.Text.Trim());
                    cbboxTenLSP.Items.Remove(dgvLSP.Rows[indexLSP].Cells[1].Value.ToString());
                    cbboxTenLSP.Items.Add(txtTenLSP.Text.Trim());
                    DataGridViewRow row = dgvLSP.Rows[indexLSP];
                    row.Cells[1].Value = txtTenLSP.Text.Trim();
                    MessageBox.Show("Sửa thành công");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm thông tin loại sản phẩm mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                txtGia.Enabled = true;
                txtTenSP.Enabled = true;
                cbboxTenLSP.Enabled = true;
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                txtMaSP.Text = SANPHAMDAO.KiemTraMaSPTuDongTang(dsSP, SANPHAMDAO.MaSPTuDong(dsSP));
                txtTenSP.Focus();
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (kttxtSP())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa thông tin sản phẩm này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "update sanpham set tensp = N'" + txtTenSP.Text.Trim() + "', gia = " + Decimal.Parse(txtGia.Text.Trim()) + ", maloai = '" + LOAISANPHAMDAO.MaLoaiSPTheoTenLSP(QuanLyHangHoa.dsLSP, cbboxTenLSP.SelectedItem.ToString().Trim()) + "' where masp = '" + txtMaSP.Text.Trim() + "'";
                    cn.themxoasua(sql);
                    SANPHAM sp = new SANPHAM(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), Decimal.Parse(txtGia.Text.Trim()), 0, LOAISANPHAMDAO.MaLoaiSPTheoTenLSP(QuanLyHangHoa.dsLSP, cbboxTenLSP.SelectedItem.ToString().Trim()));
                    SANPHAMDAO.SuaSP(dsSP, sp);
                    DataGridViewRow row = dgvSP.Rows[indexSP];
                    row.Cells[1].Value = txtTenSP.Text.Trim();
                    row.Cells[2].Value = txtGia.Text.Trim();
                    row.Cells[3].Value = cbboxTenLSP.SelectedItem.ToString().Trim();
                    MessageBox.Show("Sửa thành công");
                }
            }
        }

        int indexSP;

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexSP = e.RowIndex;
            if (indexSP < 0 || indexSP >= dgvSP.Rows.Count - 1)
            {
                MessageBox.Show("Vui lòng nhập đúng dòng để sửa hoặc xóa");
                return;
            }
            txtMaSP.Enabled = false;
            txtMaSP.Text = dgvSP.Rows[indexSP].Cells[0].Value.ToString();
            txtTenSP.Text = dgvSP.Rows[indexSP].Cells[1].Value.ToString();
            txtGia.Text = dgvSP.Rows[indexSP].Cells[2].Value.ToString();
            cbboxTenLSP.Text = dgvSP.Rows[indexSP].Cells[3].Value.ToString();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtGia.Enabled = true;
            txtTenSP.Enabled = true;
            cbboxTenLSP.Enabled = true;
        }

        public Boolean kttontaimasp()
        {
            if (SANPHAMDAO.KiemTraTonTaiMaSP(QuanLyBanHang.dsCTHD, txtMaSP.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm này có dữ liệu, không thể xóa");
                return false;
            }
            return true;
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (kttontaimasp())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa thông tin sản phẩm này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "delete from sanpham where masp = '" + txtMaSP.Text.Trim() + "'";
                    cn.themxoasua(sql);
                    SANPHAMDAO.XoaSP(dsSP, txtMaSP.Text.Trim());
                    dgvSP.Rows.RemoveAt(indexSP);
                    MessageBox.Show("Xóa thành công");
                }
            }
        }

        public Boolean kttxtSP()
        {
            if (txtGia.Text.Equals("") || txtTenSP.Text.Equals("") || cbboxTenLSP.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm");
                return false;
            }
            return true;
        }

        public Boolean kttrungmasp()
        {
            if (SANPHAMDAO.KiemTraTrungMaSP(dsSP, txtMaSP.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại, không thể lưu");
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kttxtSP() && kttrungmasp())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu thông tin sản phẩm này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "insert into sanpham values ('" + txtMaSP.Text.Trim() + "', N'" + txtTenSP.Text.Trim() + "', " + Decimal.Parse(txtGia.Text.Trim()) + ", 0, '" + LOAISANPHAMDAO.MaLoaiSPTheoTenLSP(QuanLyHangHoa.dsLSP, cbboxTenLSP.SelectedItem.ToString().Trim()) + "')";
                    cn.themxoasua(sql);
                    SANPHAMDAO.ThemSP(dsSP, txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), Decimal.Parse(txtGia.Text.Trim()), 0, LOAISANPHAMDAO.MaLoaiSPTheoTenLSP(QuanLyHangHoa.dsLSP, cbboxTenLSP.SelectedItem.ToString().Trim()));
                    dgvSP.Rows.Add(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), Decimal.Parse(txtGia.Text.Trim()), cbboxTenLSP.SelectedItem.ToString().Trim());
                    MessageBox.Show("Lưu thành công");
                    btnLuu.Enabled = false;
                    btnThem.Enabled = true;
                }
            }
        }

        public Boolean kttxtLSP()
        {
            if (txtTenLSP.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng ghi đầy đủ thông tin loại sản phẩm");
                return false;
            }
            return true;
        }

        public Boolean kttrungmalsp()
        {
            if (LOAISANPHAMDAO.KiemTraTrungMaLoaiSP(dsLSP, txtMaLSP.Text.Trim()))
            {
                MessageBox.Show("Mã loại sản phẩm này đã tồn tại, không thể lưu");
                return false;
            }
            return true;
        }

        private void btnLuuLSP_Click(object sender, EventArgs e)
        {
            if (kttxtLSP() && kttrungmalsp())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu thông tin loại sản phẩm này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "insert into loaisp values ('" + txtMaLSP.Text.Trim() + "', N'" + txtTenLSP.Text.Trim() + "', 'K001')";
                    cn.themxoasua(sql);
                    dgvLSP.Rows.Add(txtMaLSP.Text.Trim(), txtTenLSP.Text.Trim());
                    LOAISANPHAMDAO.ThemLoaiSP(dsLSP, txtMaLSP.Text.Trim(), txtTenLSP.Text.Trim());
                    cbboxTenLSP.Items.Add(txtTenLSP.Text.Trim());
                    MessageBox.Show("Lưu thành công");
                    btnThemLSP.Enabled = true;
                    btnLuuLSP.Enabled = false;
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiSP();
        }

        private void btnLamMoiLSP_Click(object sender, EventArgs e)
        {
            LamMoiLSP();
        }

        private void btnThemLSP_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm thông tin loại sản phẩm mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                btnThemLSP.Enabled = false;
                btnLuuLSP.Enabled = true;
                btnXoaLSP.Enabled = false;
                btnSuaLSP.Enabled = false;
                txtTenLSP.Enabled = true;
                txtMaLSP.Text = LOAISANPHAMDAO.KiemTraMaLSPTuDongTang(dsLSP, LOAISANPHAMDAO.MaLoaiSPTuDong(dsLSP));
            }
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
