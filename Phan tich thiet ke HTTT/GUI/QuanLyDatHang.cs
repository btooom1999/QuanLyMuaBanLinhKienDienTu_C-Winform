using Phan_tich_thiet_ke_HTTT.DAO;
using Phan_tich_thiet_ke_HTTT.POJO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_tich_thiet_ke_HTTT
{
    public partial class QuanLyDatHang : Form
    {
        public QuanLyDatHang()
        {
            InitializeComponent();
            cbboxMaPhieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbboxTenSP.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //List<BANQUANLY> dsNQL = BANQUANLYDAO.getDSBQL();
        List<PHIEUDATHANG> dsPDH = PHIEUDATHANGDAO.getDSPDT();
        List<CHITIETPHIEUDATHANG> dsCTPDH = CHITIETPHIEUDATHANGDAO.getDSCTPDH();

        ConnectionDB cn = new ConnectionDB();

        //public void loaddulieutennql()
        //{
        //    foreach (BANQUANLY bql in dsNQL)
        //        cbboxTenQL.Items.Add(bql.getTennql());
        //}

        public void loaddulieuphieudathang()
        {
            dgvPDH.Rows.Clear();
            foreach (PHIEUDATHANG pdh in dsPDH)
            {
                dgvPDH.Rows.Add(pdh.getSophieu(), pdh.getNgaylap(), pdh.getManql());
                cbboxMaPhieu.Items.Add(pdh.getSophieu());
            }
        }

        public void loaddulieutensanpham()
        {
            foreach (SANPHAM sp in QuanLyHangHoa.dsSP)
                cbboxTenSP.Items.Add(sp.getTensp());
        }

        public void loaddulieuchitietphieudathang()
        {
            dgvCTPDH.Rows.Clear();
            foreach (CHITIETPHIEUDATHANG ct in dsCTPDH)
                dgvCTPDH.Rows.Add(ct.getSophieu(), SANPHAMDAO.TenSP(QuanLyHangHoa.dsSP, ct.getMasp()), ct.getSoluong(), ct.getGiatien(), ct.thanhtien());
        }

        public void LamMoiPDH()
        {
            txtMaPhieu.Enabled = false;
            dateNgayLap.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }

        public void LamMoiCTPDH()
        {
            cbboxMaPhieu.Enabled = true;
            cbboxTenSP.Enabled = false;
            txtDonGia.Enabled = false;
            txtSoLuong.Enabled = false;
            txtTongTien.Enabled = false;
            btnThemCTPDH.Enabled = false;
            btnLuuCTPDH.Enabled = false;
            btnXoaCTPDH.Enabled = false;
            btnSuaCTPDH.Enabled = false;
            btnIn.Enabled = false;
            cbboxMaPhieu.SelectedIndex = -1;
            cbboxTenSP.SelectedIndex = -1;
            cbboxMaPhieu.Text = "--Chọn--";
            cbboxTenSP.Text = "--Chọn--";
            txtSoLuong.Text = "0";
            txtDonGia.Text = "0";
            txtTongTien.Text = "0";
        }

        private void QuanLyDatHang_Load(object sender, EventArgs e)
        {
            LamMoiPDH();
            LamMoiCTPDH();
            dgvCTPDH.ReadOnly = true;
            dgvPDH.ReadOnly = true;
            //loaddulieutennql();
            loaddulieutensanpham();
            loaddulieuphieudathang();
            loaddulieuchitietphieudathang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm phiếu đặt hàng mới?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                txtMaPhieu.Text = PHIEUDATHANGDAO.KiemTraMaPDHTuDongTang(dsPDH, PHIEUDATHANGDAO.MaPDHTuDong(dsPDH));
                dateNgayLap.Enabled = true;
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String sql = "delete from phieudathang where sophieu = '"+txtMaPhieu.Text.Trim()+"'";
            cn.themxoasua(sql);
        }

        int indexPDH;

        private void dgvPDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexPDH = e.RowIndex;
            if (indexPDH < 0 || indexPDH >= dgvPDH.RowCount - 1)
            {
                MessageBox.Show("Vui lòng nhâp đúng dòng hoặc cột để xóa");
                return;
            }
            txtMaPhieu.Text = dgvPDH.Rows[indexPDH].Cells[0].Value.ToString();
            dateNgayLap.Value = DateTime.ParseExact(dgvPDH.Rows[indexPDH].Cells[1].Value.ToString(), "dd/MM/yyyy", null);
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            dateNgayLap.Enabled = false;
        }

        private void btnThemCTPDH_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm dữ liệu cho phiếu đặt hàng này?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                cbboxTenSP.Enabled = true;
                txtDonGia.Enabled = true;
                txtSoLuong.Enabled = true;
                btnThemCTPDH.Enabled = false;
                btnLuuCTPDH.Enabled = true;
                btnXoaCTPDH.Enabled = false;
                btnSuaCTPDH.Enabled = false;
                cbboxTenSP.SelectedIndex = -1;
                cbboxTenSP.Text = "--Chọn--";
                txtDonGia.Text = "0";
                txtSoLuong.Text = "0";
            }
        }

        private void btnXoaCTPDH_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa phiếu đặt hàng này?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                String sql = "delete from ct_phieudathang where sophieu = '" + cbboxMaPhieu.SelectedItem.ToString().Trim() + "' and masp = '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "' exec dbo.tongtienpdh @sophieu = '" + cbboxMaPhieu.SelectedItem.ToString().Trim() + "'";
                cn.themxoasua(sql);
                CHITIETPHIEUDATHANGDAO.XoaCTPDH(dsCTPDH, cbboxMaPhieu.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()));
                dgvCTPDH.Rows.RemoveAt(indexCTPDH);
                txtTongTien.Text = "" + tongtien();
                MessageBox.Show("Xoá dữ liệu cho phiếu đặt hàng thành công");
            }
        }

        int indexCTPDH;

        private void dgvCTPDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexCTPDH = e.RowIndex;

            cbboxMaPhieu.Text = dgvCTPDH.Rows[indexCTPDH].Cells[0].Value.ToString();
            cbboxTenSP.Text = dgvCTPDH.Rows[indexCTPDH].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvCTPDH.Rows[indexCTPDH].Cells[2].Value.ToString();
            txtDonGia.Text = dgvCTPDH.Rows[indexCTPDH].Cells[3].Value.ToString();

            btnThemCTPDH.Enabled = true;
            btnLuuCTPDH.Enabled = false;
            btnXoaCTPDH.Enabled = true;
            btnSuaCTPDH.Enabled = true;
            cbboxTenSP.Enabled = false;
            txtDonGia.Enabled = true;
            txtSoLuong.Enabled = true;
        }

        public Decimal tongtien()
        {
            Decimal tong = 0;
            for(int i = 0; i < dgvCTPDH.RowCount - 1; i++)
                tong += Decimal.Parse(dgvCTPDH.Rows[i].Cells[4].Value.ToString());
            return tong;
        }

        private void cbboxMaPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCTPDH.Rows.Clear();
            btnThemCTPDH.Enabled = true;
            btnIn.Enabled = true;
            List<CHITIETPHIEUDATHANG> ds = CHITIETPHIEUDATHANGDAO.dsCTPDHTheoMaHD(dsCTPDH, cbboxMaPhieu.SelectedItem.ToString().Trim());
            foreach(CHITIETPHIEUDATHANG ct in ds)
                dgvCTPDH.Rows.Add(ct.getSophieu(), SANPHAMDAO.TenSP(QuanLyHangHoa.dsSP, ct.getMasp()), ct.getSoluong(), ct.getGiatien(), ct.thanhtien());
            txtTongTien.Text = "" + tongtien();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu phiếu đặt hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                String sql = "set dateformat dmy insert into phieudathang values ('" + txtMaPhieu.Text.Trim() + "', '" + dateNgayLap.Text.Trim() + "', '" + DangNhap.MaNV + "', 0)";
                cn.themxoasua(sql);
                PHIEUDATHANGDAO.ThemPDH(dsPDH, txtMaPhieu.Text.Trim(), dateNgayLap.Text.Trim(), DangNhap.MaNV);
                dgvPDH.Rows.Add(txtMaPhieu.Text.Trim(), dateNgayLap.Text.Trim(), DangNhap.MaNV);
                cbboxMaPhieu.Items.Add(txtMaPhieu.Text.Trim());
                MessageBox.Show("Lưu phiếu đặt hàng thành công");
            }
        }

        public Boolean kttxtctpdh()
        {
            if (cbboxTenSP.SelectedIndex < 0 || txtDonGia.Text.Equals("") || txtSoLuong.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin chi tiết phiếu đặt hàng");
                return false;
            }
            return true;
        }

        public Boolean ktmapdhmasptrung()
        {
            if (CHITIETPHIEUDATHANGDAO.KTMaPDHMaSPTrung(dsCTPDH, cbboxMaPhieu.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim())))
            {
                MessageBox.Show("Dữ liệu này đã tồn tại, không thể lưu");
                return false;
            }
            return true;
        }

        private void btnLuuCTPDH_Click(object sender, EventArgs e)
        {
            if (kttxtctpdh() && ktmapdhmasptrung())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu dữ liệu cho phiếu đặt hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "insert into ct_phieudathang values ('" + cbboxMaPhieu.SelectedItem.ToString().Trim() + "', '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "', " + int.Parse(txtSoLuong.Text.Trim()) + ", " + Decimal.Parse(txtDonGia.Text.Trim()) + ", " + int.Parse(txtSoLuong.Text.Trim()) * Decimal.Parse(txtDonGia.Text.Trim()) + ") exec dbo.tongtienpdh @sophieu = '" + cbboxMaPhieu.SelectedItem.ToString().Trim() + "'";
                    cn.themxoasua(sql);
                    CHITIETPHIEUDATHANGDAO.ThemCTPDH(dsCTPDH, cbboxMaPhieu.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()), Decimal.Parse(txtDonGia.Text.Trim()));
                    dgvCTPDH.Rows.Add(cbboxMaPhieu.SelectedItem.ToString().Trim(), cbboxTenSP.SelectedItem.ToString().Trim(), int.Parse(txtSoLuong.Text.Trim()), Decimal.Parse(txtDonGia.Text.Trim()), int.Parse(txtSoLuong.Text.Trim()) * Decimal.Parse(txtDonGia.Text.Trim()));
                    txtTongTien.Text = "" + tongtien();
                    MessageBox.Show("Lưu dữ liệu cho phiếu đặt hàng thành công");
                    btnThemCTPDH.Enabled = true;
                    btnLuuCTPDH.Enabled = false;
                }
            }
        }

        public Boolean kttontaidulieu()
        {
            if (CHITIETPHIEUDATHANGDAO.KTTonTaiDuLieu(dsCTPDH, txtMaPhieu.Text.Trim()))
            {
                MessageBox.Show("Phiếu này có dữ liệu, không thể xóa");
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (kttontaidulieu())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa phiếu đặt hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "delete from phieudathang where sophieu = '" + txtMaPhieu.Text.Trim() + "'";
                    cn.themxoasua(sql);
                    PHIEUDATHANGDAO.XoaPDH(dsPDH, txtMaPhieu.Text.Trim());
                    dgvPDH.Rows.RemoveAt(indexPDH);
                    cbboxMaPhieu.Items.Remove(txtMaPhieu.Text.Trim());
                    MessageBox.Show("Xóa phiếu đặt hàng thành công");
                }
            }
        }

        private void btnSuaCTPDH_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa phiếu đặt hàng này?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                String sql = "update ct_phieudathang set soluong = " + int.Parse(txtSoLuong.Text.Trim()) + ", giatien = " + Decimal.Parse(txtDonGia.Text.Trim()) + ", thanhtien = " + int.Parse(txtSoLuong.Text.Trim()) * Decimal.Parse(txtDonGia.Text.Trim()) + " where sophieu = '" + cbboxMaPhieu.SelectedItem.ToString().Trim() + "' and masp = '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "' exec dbo.tongtienpdh @sophieu = '" + cbboxMaPhieu.SelectedItem.ToString().Trim() + "'";
                cn.themxoasua(sql);
                CHITIETPHIEUDATHANGDAO.SuaCTPDH(dsCTPDH, cbboxMaPhieu.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()), Decimal.Parse(txtDonGia.Text.Trim()));
                DataGridViewRow row = dgvCTPDH.Rows[indexCTPDH];
                row.Cells[2].Value = int.Parse(txtSoLuong.Text.Trim());
                row.Cells[3].Value = Decimal.Parse(txtDonGia.Text.Trim());
                row.Cells[4].Value = int.Parse(txtSoLuong.Text.Trim()) * Decimal.Parse(txtDonGia.Text.Trim());
                txtTongTien.Text = "" + tongtien();
                MessageBox.Show("Sửa dữ liệu của phiếu đặt hàng thành công");
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

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Textbox này chỉ cho nhập số, vui lòng nhập số");
                e.Handled = true;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            List<CHITIETPHIEUDATHANG> ds = CHITIETPHIEUDATHANGDAO.dsCTPDHTheoMaHD(dsCTPDH, cbboxMaPhieu.SelectedItem.ToString().Trim());
            string line4 = "";

            string getSoPhieu = "";
            foreach (CHITIETPHIEUDATHANG sp in ds)
            {

                int lengthten = SANPHAMDAO.TenSP(QuanLyHangHoa.dsSP, sp.getMasp()).Length;
                int lengthsoluong = sp.getSoluong().ToString().Length;
                int lengthgiatien = sp.getGiatien().ToString().Length;
                int length = 21 - lengthten;
                int length2 = 11 - lengthsoluong;
                int length3 = 16 - lengthgiatien;
                string khoangcach = "";
                string khoangcach2 = "";
                string khoangcach3 = "";
                for (int i = 0; i < length; i++)
                {
                    khoangcach += " ";
                }
                for (int i = 0; i < length2; i++)
                {
                    khoangcach2 += " ";
                }
                for (int i = 0; i < length3; i++)
                {
                    khoangcach3 += " ";
                }
                getSoPhieu = sp.getSophieu();

                line4 += SANPHAMDAO.TenSP(QuanLyHangHoa.dsSP, sp.getMasp()) + khoangcach + sp.getSoluong()+ khoangcach2+ sp.getGiatien() + khoangcach3 + sp.thanhtien() +"\n";
            }
            string[] lines = { "                                Phiếu Đặt Hàng\n", "Tên nhà cung cấp: " +txtTenNhaCungCap.Text+ "\n", "Mã phiếu: " +getSoPhieu +"\n", "Tên Sản Phẩm      Số lượng      Đơn giá         Thành tiền", line4, "Tổng tiền: " + txtTongTien.Text };
            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file.    You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(@"C:\DevPrograms\DoAnCongNghePhanMem (2)\Phan tich thiet ke HTTT\Phan tich thiet ke HTTT\BanIn\In.txt", lines);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\DevPrograms\DoAnCongNghePhanMem (2)\Phan tich thiet ke HTTT\Phan tich thiet ke HTTT\BanIn\In.txt"; // Your absolute PATH 

            Process.Start(startInfo);
        }
    }
}
