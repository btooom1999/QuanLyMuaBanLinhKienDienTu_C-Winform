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
    public partial class QuanLyXuatKho : Form
    {
        public QuanLyXuatKho()
        {
            InitializeComponent();
            cbboxTenSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cbboxMaXK.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        List<XUATKHO> dsXK = XUATKHODAO.getDSXK();
        List<CHITIETXUATKHO> dsCTXK = CHITIETXUATKHODAO.getDSCTXK();

        ConnectionDB cn = new ConnectionDB();

        public void loaddulieuxuatkho()
        {
            dgvXK.Rows.Clear();
            foreach (XUATKHO xk in dsXK)
            {
                dgvXK.Rows.Add(xk.getMapx(), xk.getNgaylap(), xk.getManv(), xk.getGhichu());
                cbboxMaXK.Items.Add(xk.getMapx());
            }
        }

        public void loaddulieutensanpham()
        {
            foreach (SANPHAM sp in QuanLyHangHoa.dsSP)
                cbboxTenSP.Items.Add(sp.getTensp());
        }

        public void loaddulieuchitietxuatkho()
        {
            dgvCTXK.Rows.Clear();
            foreach (CHITIETXUATKHO ct in dsCTXK)
                dgvCTXK.Rows.Add(ct.getMapx(), SANPHAMDAO.TenSP(QuanLyHangHoa.dsSP, ct.getMasp()), ct.getSoluong());
        }

        public void LamMoiXK()
        {
            txtMaXK.Enabled = false;
            txtGhiChu.Enabled = false;
            dateNgayLap.Enabled = false;
            //btnThem.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        public void LamMoiCTXK()
        {
            cbboxTenSP.Enabled = false;
            txtSoLuong.Enabled = false;
            btnThemCTXK.Enabled = false;
            btnLuuCTXK.Enabled = false;
            btnXoaCTXK.Enabled = false;
            cbboxTenSP.SelectedIndex = -1;
            cbboxTenSP.Text = "--Chọn--";
            txtSoLuong.Text = "0";
        }

        private void QuanLyXuatKho_Load(object sender, EventArgs e)
        {
            LamMoiXK();
            LamMoiCTXK();
            dgvXK.ReadOnly = true;
            dgvCTXK.ReadOnly = true;
            dgvCTXK.Enabled = false;
            loaddulieuxuatkho();
            loaddulieutensanpham();
            loaddulieuchitietxuatkho();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn tạo dữ liệu xuất kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                txtMaXK.Text = XUATKHODAO.KiemTraMaXKTuDongTang(dsXK, XUATKHODAO.MaXKTuDong(dsXK));
                txtGhiChu.Enabled = true;
                txtSoLuong.Enabled = true;
                dateNgayLap.Enabled = true;
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                dateNgayLap.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (kttxtxk())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa dữ liệu xuất kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "set dateformat dmy update phieuxuat_kho set ngaylap = '" + dateNgayLap.Text.Trim() + "', ghichu = N'" + txtGhiChu.Text.Trim() + "' where mapx = '" + txtMaXK.Text.Trim() + "'";
                    cn.themxoasua(sql);
                    XUATKHODAO.SuaXK(dsXK, txtMaXK.Text.Trim(), dateNgayLap.Text.Trim(), txtGhiChu.Text.Trim());
                    DataGridViewRow row = dgvXK.Rows[indexXK];
                    row.Cells[1].Value = dateNgayLap.Text.Trim();
                    row.Cells[3].Value = txtGhiChu.Text.Trim();
                    MessageBox.Show("Sửa thành công");
                }
            }
        }

        public Boolean kttontaimaxk()
        {
            if (CHITIETXUATKHODAO.KTTonTaiMaNK(dsCTXK, txtMaXK.Text.Trim()))
            {
                MessageBox.Show("Mã xuất kho này có dữ liệu, không thể xóa");
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (kttontaimaxk())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu xuất kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "delete from phieuxuat_kho where mapx = '" + txtMaXK.Text.Trim() + "'";
                    cn.themxoasua(sql);
                    XUATKHODAO.XoaXK(dsXK, txtMaXK.Text.Trim());
                    dgvXK.Rows.RemoveAt(indexXK);
                    MessageBox.Show("Xóa thành công");
                }
            }
        }

        int indexXK;

        private void dgvXK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexXK = e.RowIndex;
            if (indexXK < 0 || indexXK >= dgvXK.RowCount - 1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin xuất kho");
                return;
            }
            txtMaXK.Text = dgvXK.Rows[indexXK].Cells[0].Value.ToString();
            dateNgayLap.Value = DateTime.ParseExact(dgvXK.Rows[indexXK].Cells[1].Value.ToString(), "dd/MM/yyyy", null);
            txtGhiChu.Text = dgvXK.Rows[indexXK].Cells[3].Value.ToString();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtGhiChu.Enabled = true;
            dateNgayLap.Enabled = true;
        }

        private void btnThemCTXK_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn tạo dữ liệu chi tiết xuất kho mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                cbboxTenSP.Enabled = true;
                txtSoLuong.Enabled = true;
                btnThemCTXK.Enabled = false;
                btnLuuCTXK.Enabled = true;
                btnXoaCTXK.Enabled = false;
                cbboxTenSP.SelectedIndex = -1;
                cbboxTenSP.Text = "--Chọn--";
                txtSoLuong.Text = "0";
                cbboxTenSP.Focus();
            }
        }

        private void btnSuaCTXK_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa dữ liệu cho chi tiết xuất kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                String sql = "update ct_phieuxuat set soluong = " + int.Parse(txtSoLuong.Text.Trim()) + " where mapx = '" + cbboxMaXK.SelectedItem.ToString().Trim() + "' and masp = '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "'";
                cn.themxoasua(sql);
                CHITIETXUATKHODAO.SuaCTXK(dsCTXK, cbboxMaXK.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()));
                DataGridViewRow row = dgvCTXK.Rows[indexCTNK];
                row.Cells[2].Value = txtSoLuong.Text.Trim();
                MessageBox.Show("Sửa thành công");
            }
        }

        private void btnXoaCTXK_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu cho chi tiết xuất kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                String sql = "delete from ct_phieuxuat where mapx = '" + cbboxMaXK.SelectedItem.ToString().Trim() + "' and masp = '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "'";
                cn.themxoasua(sql);
                CHITIETXUATKHODAO.XoaCTXK(dsCTXK, cbboxMaXK.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()));
                dgvCTXK.Rows.RemoveAt(indexCTNK);
                MessageBox.Show("Xóa thành công");
            }
        }

        int indexCTNK;

        private void dgvCTXK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexCTNK = e.RowIndex;
            if (indexCTNK < 0 || indexCTNK >= dgvCTXK.RowCount - 1)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng hoặc cột để xóa hoặc sửa");
                return;
            }
            cbboxTenSP.Text = dgvCTXK.Rows[indexCTNK].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvCTXK.Rows[indexCTNK].Cells[2].Value.ToString();
            cbboxMaXK.Text = dgvCTXK.Rows[indexCTNK].Cells[0].Value.ToString();
            cbboxTenSP.Enabled = false;
            txtSoLuong.Enabled = true;
            btnThemCTXK.Enabled = true;
            btnLuuCTXK.Enabled = false;
             
            btnXoaCTXK.Enabled = true;
        }

        private void cbboxMaXK_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCTXK.Rows.Clear();
            dgvCTXK.Enabled = true;
            btnThemCTXK.Enabled = true;
            List<CHITIETXUATKHO> ds = CHITIETXUATKHODAO.dsCTXKTheoMaXK(dsCTXK, cbboxMaXK.SelectedItem.ToString().Trim());
            foreach (CHITIETXUATKHO ct in ds)
                dgvCTXK.Rows.Add(ct.getMapx(), SANPHAMDAO.TenSP(QuanLyHangHoa.dsSP, ct.getMasp()), ct.getSoluong());
        }

        public Boolean kttxtxk()
        {
            if (txtGhiChu.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin xuất kho");
                return false;
            }
            return true;
        }

        public Boolean ktmaxktrung()
        {
            if (XUATKHODAO.KiemTraMaXKTrung(dsXK, txtMaXK.Text.Trim()))
            {
                MessageBox.Show("Đã có mã xuất kho này trong dữ liệu, không thể lưu");
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kttxtxk() && ktmaxktrung())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu dữ liệu xuất kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "set dateformat dmy insert into phieuxuat_kho values ('" + txtMaXK.Text.Trim() + "', '" + dateNgayLap.Text.Trim() + "', '" + DangNhap.MaNV + "', N'" + txtGhiChu.Text.Trim() + "')";
                    cn.themxoasua(sql);
                    XUATKHODAO.ThemXK(dsXK, txtMaXK.Text.Trim(), dateNgayLap.Text.Trim(), DangNhap.MaNV, txtGhiChu.Text.Trim());
                    dgvXK.Rows.Add(txtMaXK.Text.Trim(), dateNgayLap.Text.Trim(), DangNhap.MaNV, txtGhiChu.Text.Trim());
                    cbboxMaXK.Items.Add(txtMaXK.Text.Trim());
                    MessageBox.Show("Thêm thành công");
                }
            }
        }

        public Boolean kttxtctxk()
        {
            if (txtSoLuong.Text.Equals("") || cbboxTenSP.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng ghi đầy đủ thông tin chi tiết xuất kho");
                return false;
            }
            return true;
        }

        public Boolean ktmaxkmasptrung()
        {
            if (CHITIETXUATKHODAO.KTMaXKMaSPTrung(dsCTXK, cbboxMaXK.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim())))
            {
                MessageBox.Show("Đã tồn tại dữ liệu này, không thể lưu");
                return false;
            }
            return true;
        }

        public Boolean ktsoluong()
        {
            if(CHITIETXUATKHODAO.KTSoLuongXuatKho(QuanLyHangHoa.dsSP, SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim())))
            {
                MessageBox.Show("Số lượng không đủ, không thể xuất kho");
                return false;
            }
            return true;
        }

        private void btnLuuCTXK_Click(object sender, EventArgs e)
        {

            if (kttxtctxk() && ktmaxkmasptrung() && ktsoluong())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu dữ liệu cho chi tiết xuất kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "insert into ct_phieuxuat values ('" + cbboxMaXK.SelectedItem.ToString().Trim() + "', '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "', " + int.Parse(txtSoLuong.Text.Trim()) + ")";
                    cn.themxoasua(sql);
                    CHITIETXUATKHODAO.ThemCTXK(dsCTXK, cbboxMaXK.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()));
                    dgvCTXK.Rows.Add(cbboxMaXK.SelectedItem.ToString().Trim(), cbboxTenSP.SelectedItem.ToString().Trim(), int.Parse(txtSoLuong.Text.Trim()));
                    CHITIETXUATKHODAO.CapNhatSoLuongSPKhiThemXuatKho(QuanLyHangHoa.dsSP, SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()));
                    MessageBox.Show("Thêm thành công");
                }
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Textbox này chỉ cho nhập số, vui lòng nhập số");
                e.Handled = true;
            }
        }

        private void cbboxTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}