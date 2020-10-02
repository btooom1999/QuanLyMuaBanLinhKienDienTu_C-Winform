using Phan_tich_thiet_ke_HTTT.DAO;
using Phan_tich_thiet_ke_HTTT.GUI;
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
    public partial class QuanLyNhapKho : Form
    {
        public QuanLyNhapKho()
        {
            InitializeComponent();
            cbboxMaNK.DropDownStyle = ComboBoxStyle.DropDownList;
            cbboxTenNCC.DropDownStyle = ComboBoxStyle.DropDownList;
            cbboxTenSP.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static List<NHAPKHO> dsNK = NHAPKHODAO.getDSNK();
        List<CHITIETNHAPKHO> dsCTNK = CHITIETNHAPKHODAO.getDSCTNK();

        ConnectionDB cn = new ConnectionDB();

        public void loaddulieutennhacungcap()
        {
            foreach (NHACUNGCAP ncc in QuanLyNhaCungCap.dsNCC)
                cbboxTenNCC.Items.Add(ncc.getTennc());
        }

        public void loaddulieunhapkho()
        {
            dgvNK.Rows.Clear();
            foreach (NHAPKHO nk in dsNK)
            {
                dgvNK.Rows.Add(nk.getMapn(), nk.getNgaylap(), nk.getManv(), NHACUNGCAPDAO.TenNCC(QuanLyNhaCungCap.dsNCC, nk.getMancc()), nk.getGhichu());
                cbboxMaNK.Items.Add(nk.getMapn());
            }
        }

        public void loaddulieutensanpham()
        {
            foreach (SANPHAM sp in QuanLyHangHoa.dsSP)
                cbboxTenSP.Items.Add(sp.getTensp());
        }

        public void loaddulieuchitietnhapkho()
        {
            dgvCTNK.Rows.Clear();
            foreach (CHITIETNHAPKHO ct in dsCTNK)
                dgvCTNK.Rows.Add(ct.getMapn(), SANPHAMDAO.TenSP(QuanLyHangHoa.dsSP, ct.getMasp()), ct.getSoluong());
        }

        public void LamMoiNK()
        {
            txtMaNK.Enabled = false;
            txtGhiChu.Enabled = false;
            dateNgayLap.Enabled = false;
            cbboxTenNCC.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtMaNK.Text = "";
            txtGhiChu.Text = "";
            cbboxTenNCC.SelectedIndex = -1;
            cbboxTenNCC.Text = "--Chọn--";
        }

        public void LamMoiCTNK()
        {
            cbboxMaNK.Enabled = true;
            cbboxTenSP.Enabled = false;
            txtSoLuong.Enabled = false;
            btnThemCTNK.Enabled = false;
            btnLuuCTNK.Enabled = false;
            btnXoaCTNK.Enabled = false;
            cbboxMaNK.SelectedIndex = -1;
            cbboxTenSP.SelectedIndex = -1;
            cbboxMaNK.Text = "--Chọn--";
            cbboxTenSP.Text = "--Chọn--";
            txtSoLuong.Text = "0";
        }

        private void QuanLyNhapKho_Load(object sender, EventArgs e)
        {
            LamMoiNK();
            LamMoiCTNK();
            dgvNK.ReadOnly = true;
            dgvCTNK.ReadOnly = true;
            dgvCTNK.Enabled = false;
            loaddulieutennhacungcap();
            loaddulieunhapkho();
            loaddulieutensanpham();
            loaddulieuchitietnhapkho();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn tạo dữ liệu nhập kho mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                txtGhiChu.Enabled = true;
                dateNgayLap.Enabled = true;
                cbboxTenNCC.Enabled = true;
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                txtMaNK.Text = "";
                txtGhiChu.Text = "";
                cbboxTenNCC.SelectedIndex = -1;
                cbboxTenNCC.Text = "--Chọn--";
                txtMaNK.Text = NHAPKHODAO.KiemTraMaNKTuDongTang(dsNK, NHAPKHODAO.MaNKTuDong(dsNK));
                cbboxTenNCC.Focus();
            }
        }

        int indexNK;

        private void dgvNK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexNK = e.RowIndex;
            if (indexNK < 0 || indexNK >= dgvNK.RowCount - 1)
            {
                MessageBox.Show("Vui lòng nhập đúng dòng hoặc cột để xóa hoặc sửa");
                return;
            }
            txtMaNK.Text = dgvNK.Rows[indexNK].Cells[0].Value.ToString();
            dateNgayLap.Value = DateTime.ParseExact(dgvNK.Rows[indexNK].Cells[1].Value.ToString(), "dd/MM/yyyy", null);
            cbboxTenNCC.Text = dgvNK.Rows[indexNK].Cells[3].Value.ToString();
            txtGhiChu.Text = dgvNK.Rows[indexNK].Cells[4].Value.ToString();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtGhiChu.Enabled = true;
            cbboxTenNCC.Enabled = true;
            dateNgayLap.Enabled = true;
        }

        private void btnThemCTNK_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn tạo dữ liệu cho chi tiết nhập kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                cbboxTenSP.Enabled = true;
                txtSoLuong.Enabled = true;
                btnThemCTNK.Enabled = false;
                btnLuuCTNK.Enabled = true;
                btnXoaCTNK.Enabled = false;
                cbboxTenSP.SelectedIndex = -1;
                cbboxTenSP.Text = "--Chọn--";
                txtSoLuong.Text = "0";
                cbboxTenSP.Focus();
            }
        }

        private void btnSuaCTNK_Click(object sender, EventArgs e)
        {
            if (kttxtctnk())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa dữ liệu cho chi tiết nhập kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "update ct_phieunhap set soluong = " + int.Parse(txtSoLuong.Text.Trim()) + " where mapn = '" + cbboxMaNK.SelectedItem.ToString().Trim() + "' and masp = '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "'";
                    cn.themxoasua(sql);
                    CHITIETNHAPKHODAO.SuaCTNK(dsCTNK, cbboxMaNK.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()));
                    DataGridViewRow row = dgvCTNK.Rows[indexCTNK];
                    row.Cells[2].Value = txtSoLuong.Text.Trim();
                }
            }
        }

        private void btnXoaCTNK_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu cho chi tiết nhập kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                String sql = "delete from ct_phieunhap where mapn = '" + cbboxMaNK.SelectedItem.ToString().Trim() + "' and masp = '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "'";
                cn.themxoasua(sql);
                CHITIETNHAPKHODAO.XoaCTNK(dsCTNK, cbboxMaNK.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()));
                dgvCTNK.Rows.RemoveAt(indexCTNK);
                CHITIETNHAPKHODAO.CapNhatSoLuongSPKhiXoaNhapKho(QuanLyHangHoa.dsSP, SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()));
                MessageBox.Show("Xóa thành công");
            }
        }

        int indexCTNK;

        private void dgvCTNK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexCTNK = e.RowIndex;

            if (indexCTNK < 0 || indexCTNK >= dgvCTNK.RowCount - 1)
            {
                MessageBox.Show("Vui lòng nhập đúng dòng hoặc cột để xóa hoặc sửa");
                return;
            }
            cbboxTenSP.Text = dgvCTNK.Rows[indexCTNK].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvCTNK.Rows[indexCTNK].Cells[2].Value.ToString();
            cbboxMaNK.Text = dgvCTNK.Rows[indexCTNK].Cells[0].Value.ToString();
            btnThemCTNK.Enabled = true;
            btnLuuCTNK.Enabled = false;
            btnXoaCTNK.Enabled = true;
            txtSoLuong.Enabled = true;
            cbboxTenSP.Enabled = false;
        }

        private void cbboxMaNK_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCTNK.Rows.Clear();
            dgvCTNK.Enabled = true;
            btnThemCTNK.Enabled = true;
            List<CHITIETNHAPKHO> ds = CHITIETNHAPKHODAO.dsCTNKTheoMaNK(dsCTNK, cbboxMaNK.SelectedItem.ToString().Trim());
            foreach (CHITIETNHAPKHO ct in ds)
                dgvCTNK.Rows.Add(ct.getMapn(), SANPHAMDAO.TenSP(QuanLyHangHoa.dsSP, ct.getMasp()), ct.getSoluong());
        }

        public Boolean kttxt()
        {
            if (cbboxTenNCC.SelectedIndex < 0 || txtGhiChu.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return false;
            }
            return true;
        }

        public Boolean ktmanktrung()
        {
            if (NHAPKHODAO.KiemTraMaPNTrung(dsNK, txtMaNK.Text.Trim()))
            {
                MessageBox.Show("Đã tồn tại mã nhập kho này trong dữ liệu, không thể lưu");
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kttxt() && ktmanktrung())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu dữ liệu nhập kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "set dateformat dmy insert into phieunhap_kho values ('" + txtMaNK.Text.Trim() + "', '" + NHACUNGCAPDAO.MaNCCTheoTenNCC(QuanLyNhaCungCap.dsNCC, cbboxTenSP.SelectedItem.ToString().Trim()) + "', '" + dateNgayLap.Text.Trim() + "', '" + DangNhap.MaNV + "', N'" + txtGhiChu.Text.Trim() + "')";
                    cn.themxoasua(sql);
                    NHAPKHODAO.ThemNK(dsNK, txtMaNK.Text.Trim(), NHACUNGCAPDAO.MaNCCTheoTenNCC(QuanLyNhaCungCap.dsNCC, cbboxTenSP.SelectedItem.ToString().Trim()), dateNgayLap.Text.Trim(), DangNhap.MaNV, txtGhiChu.Text.Trim());
                    dgvNK.Rows.Add(txtMaNK.Text.Trim(), dateNgayLap.Text.Trim(), DangNhap.MaNV, cbboxTenNCC.SelectedItem.ToString().Trim(), txtGhiChu.Text.Trim());
                    cbboxMaNK.Items.Add(txtMaNK.Text.Trim());
                    btnThem.Enabled = true;
                    btnLuu.Enabled = false;
                    MessageBox.Show("Thêm thành công");
                }
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (kttxt())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa dữ liệu nhập kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "set dateformat dmy update phieunhap_kho set mancc = '" + NHACUNGCAPDAO.MaNCCTheoTenNCC(QuanLyNhaCungCap.dsNCC, cbboxTenSP.SelectedItem.ToString().Trim()) + "', ngaylap = '" + dateNgayLap.Text.Trim() + "', ghichu = N'" + txtGhiChu.Text.Trim() + "' where mapn = '" + txtMaNK.Text.Trim() + "'";
                    cn.themxoasua(sql);
                    NHAPKHODAO.SuaNK(dsNK, txtMaNK.Text.Trim(), NHACUNGCAPDAO.MaNCCTheoTenNCC(QuanLyNhaCungCap.dsNCC, cbboxTenSP.SelectedItem.ToString().Trim()), dateNgayLap.Text.Trim(), txtGhiChu.Text.Trim());
                    DataGridViewRow row = dgvNK.Rows[indexNK];
                    row.Cells[1].Value = dateNgayLap.Text.Trim();
                    row.Cells[3].Value = cbboxTenNCC.SelectedItem.ToString().Trim();
                    row.Cells[4].Value = txtGhiChu.Text.Trim();
                    MessageBox.Show("Sửa thành công");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu nhập kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                String sql = "delete from phieunhap_kho where mapn = '" + txtMaNK.Text.Trim() + "'";
                cn.themxoasua(sql);
                NHAPKHODAO.XoaNK(dsNK, txtMaNK.Text.Trim());
                dgvNK.Rows.RemoveAt(indexNK);
                MessageBox.Show("Xòa thành công");
            }
        }

        public Boolean kttxtctnk()
        {
            if (cbboxTenSP.SelectedIndex < 0 || txtSoLuong.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng ghi đầy đủ thông tin");
                return false;
            }
            return true;
        }

        public Boolean kttxtctnktrung()
        {
            if (CHITIETNHAPKHODAO.KTMaNKMaSPTrung(dsCTNK, cbboxMaNK.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim())))
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong danh sách, không thể lưu");
                return false;
            }
            return true;
        }

        private void btnLuuCTNK_Click(object sender, EventArgs e)
        {
            if (kttxtctnk() && kttxtctnktrung())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu dữ liệu cho chi tiết nhập kho này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "insert into ct_phieunhap values ('" + cbboxMaNK.SelectedItem.ToString().Trim() + "', '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "', " + int.Parse(txtSoLuong.Text.Trim()) + ")";
                    cn.themxoasua(sql);
                    CHITIETNHAPKHODAO.ThemCTNK(dsCTNK, cbboxMaNK.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()));
                    dgvCTNK.Rows.Add(cbboxMaNK.SelectedItem.ToString().Trim(), cbboxTenSP.SelectedItem.ToString().Trim(), int.Parse(txtSoLuong.Text.Trim()));
                    CHITIETNHAPKHODAO.CapNhatSoLuongSPKhiThemNhapKho(QuanLyHangHoa.dsSP, SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()));
                    btnLuuCTNK.Enabled = false;
                    btnThemCTNK.Enabled = true;
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
    }
}
