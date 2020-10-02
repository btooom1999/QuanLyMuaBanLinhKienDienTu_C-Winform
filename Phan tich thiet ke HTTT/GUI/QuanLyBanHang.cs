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
    public partial class QuanLyBanHang : Form
    {
        public QuanLyBanHang()
        {
            InitializeComponent();
            cbboxMaHD.DropDownStyle = ComboBoxStyle.DropDownList;
            cbboxTenSP.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        List<HOADON> dsHD = HOADONDAO.getDSHD();
        public static List<CHITIETHOADON> dsCTHD = CHITIETHOADONDAO.getDSCTHD();

        ConnectionDB cn = new ConnectionDB();

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm hóa đơn mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
                txtTenKH.Enabled = true;
                txtSDT.Enabled = true;
                dateNgayLapHD.Enabled = true;
                txtMaHD.Text = "";
                txtTenKH.Text = "";
                txtSDT.Text = "";
                txtMaHD.Text = HOADONDAO.MaHDTuDong(dsHD);
            }
        }

        public void loaddulieuhoadon()
        {
            dgvHD.Rows.Clear();
            foreach (HOADON hd in dsHD)
            {
                dgvHD.Rows.Add(hd.getMahd(), hd.getTenkh(), hd.getSdt(), hd.getNgaylap(), hd.getManv());
                cbboxMaHD.Items.Add(hd.getMahd());
            }
        }

        public void loaddulieutensanpham()
        {
            foreach (SANPHAM sp in QuanLyHangHoa.dsSP)
                cbboxTenSP.Items.Add(sp.getTensp());
        }

        public void loaddulieuchitiethoadon()
        {
            dgvCTHD.Rows.Clear();
            foreach (CHITIETHOADON cthd in dsCTHD)
                dgvCTHD.Rows.Add(cthd.getMahd(), SANPHAMDAO.TenSP(QuanLyHangHoa.dsSP, cthd.getMasp()), cthd.getSoluong(), cthd.thanhtien(SANPHAMDAO.GiaMaSP(QuanLyHangHoa.dsSP, cthd.getMasp())));
        }

        public void LamMoiHD()
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            txtMaHD.Enabled = false;
            txtTenKH.Enabled = false;
            txtSDT.Enabled = false;
            dateNgayLapHD.Enabled = false;
            txtMaHD.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
        }

        public void LamMoiCTHD()
        {
            btnThemCTHD.Enabled = false;
            btnLuuCTHD.Enabled = false;
            btnSuaCTHD.Enabled = false;
            btnXoaCTHD.Enabled = false;
            txtSoLuong.Enabled = false;
            txtTongTien.Enabled = false;
            cbboxTenSP.Enabled = false;
            btnInCTHD.Enabled = false;
            txtSoLuong.Text = "0";
            txtTongTien.Text = "0";
            cbboxMaHD.SelectedIndex = -1;
            cbboxTenSP.SelectedIndex = -1;
            cbboxMaHD.Text = "--Chọn--";
            cbboxTenSP.Text = "--Chọn--";
        }

        private void QuanLyBanHang_Load(object sender, EventArgs e)
        {
            dgvHD.ReadOnly = true;
            dgvCTHD.ReadOnly = true;
            dgvCTHD.Enabled = false;
            LamMoiHD();
            LamMoiCTHD();
            loaddulieuhoadon();
            loaddulieutensanpham();
            loaddulieuchitiethoadon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm dữ liệu vào hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                btnThemCTHD.Enabled = false;
                btnLuuCTHD.Enabled = true;
                btnSuaCTHD.Enabled = false;
                btnXoaCTHD.Enabled = false;
                txtSoLuong.Enabled = true;
                cbboxTenSP.Enabled = true;
                cbboxTenSP.SelectedIndex = -1;
                cbboxTenSP.Text = "--Chọn--";
                txtSoLuong.Text = "0";
            }
        }

        public Decimal TongTien()
        {
            Decimal tong = 0;
            for(int i = 0; i < dgvCTHD.RowCount - 1; i++)
                tong += Decimal.Parse(dgvCTHD.Rows[i].Cells[3].Value.ToString());
            return tong;
        }

        private void cbboxMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCTHD.Rows.Clear();
            dgvCTHD.Enabled = true;
            btnThemCTHD.Enabled = true;
            btnLuuCTHD.Enabled = false;
            btnSuaCTHD.Enabled = false;
            btnXoaCTHD.Enabled = false;
            btnInCTHD.Enabled = true;
            txtSoLuong.Enabled = false;
            List<CHITIETHOADON> ds = CHITIETHOADONDAO.dsCTHDTheoMaHD(dsCTHD, cbboxMaHD.SelectedItem.ToString().Trim());
            foreach (CHITIETHOADON cthd in ds)
            {
                dgvCTHD.Rows.Add(cthd.getMahd(), SANPHAMDAO.TenSP(QuanLyHangHoa.dsSP, cthd.getMasp()), cthd.getSoluong(), cthd.thanhtien(SANPHAMDAO.GiaMaSP(QuanLyHangHoa.dsSP, cthd.getMasp())));
            }
            txtTongTien.Text = "" + TongTien();
        }

        public Boolean kttxtHD()
        {
            if (txtTenKH.Text.Equals("") || txtSDT.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cho hóa đơn");
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kttxtHD())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "set dateformat dmy insert into hoadon values ('" + txtMaHD.Text.Trim() + "', N'" + txtTenKH.Text.Trim() + "', '" + txtSDT.Text.Trim() + "', '" + dateNgayLapHD.Text.Trim() + "', 0, '"+DangNhap.MaNV+"')";
                    cn.themxoasua(sql);
                    HOADONDAO.ThemHD(dsHD, txtMaHD.Text.Trim(), txtTenKH.Text.Trim(), txtSDT.Text.Trim(), dateNgayLapHD.Text.Trim(), DangNhap.MaNV);
                    dgvHD.Rows.Add(txtMaHD.Text.Trim(), txtTenKH.Text.Trim(), txtSDT.Text.Trim(), dateNgayLapHD.Text.Trim(), DangNhap.MaNV);
                    cbboxMaHD.Items.Add(txtMaHD.Text.Trim());
                    LamMoiHD();
                }
            }
        }

        public Boolean kttxt()
        {
            if (txtSoLuong.Text.Equals("") || cbboxTenSP.SelectedIndex < 0 || cbboxMaHD.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin chi tiết hóa đơn");
                return false;
            }
            return true;
        }

        public Boolean ktmahdmasptrung()
        {
            if (CHITIETHOADONDAO.KiemTraMaHDMaSPTrung(dsCTHD, cbboxMaHD.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim())))
            {
                MessageBox.Show("Dữ liệu này đã tồn tại, không thể lưu");
                return false;
            }
            return true;
        }

        private void btnLuuCTHD_Click(object sender, EventArgs e)
        {
            if (kttxt() && ktmahdmasptrung())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu dữ liệu cho hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "insert into ct_hoadon values ('" + cbboxMaHD.SelectedItem.ToString().Trim() + "', '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "', " + int.Parse(txtSoLuong.Text.Trim()) + ", " + int.Parse(txtSoLuong.Text.Trim()) * SANPHAMDAO.GiaMaSP(QuanLyHangHoa.dsSP, SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim())) + ") exec dbo.tongtienhd @mahd = '" + cbboxMaHD.SelectedItem.ToString().Trim() + "'";
                    cn.themxoasua(sql);
                    CHITIETHOADONDAO.ThemCTHD(dsCTHD, cbboxMaHD.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()));
                    dgvCTHD.Rows.Add(cbboxMaHD.SelectedItem.ToString().Trim(), cbboxTenSP.SelectedItem.ToString().Trim(), int.Parse(txtSoLuong.Text.Trim()), int.Parse(txtSoLuong.Text.Trim()) * SANPHAMDAO.GiaMaSP(QuanLyHangHoa.dsSP, SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim())));
                    txtTongTien.Text = "" + TongTien();
                    btnThemCTHD.Enabled = true;
                    btnLuuCTHD.Enabled = false;
                    cbboxTenSP.Enabled = false;
                    txtSoLuong.Enabled = false;
                }
            }
        }

        private void btnSuaCTHD_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa dữ liệu cho hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                String sql = "update ct_hoadon set soluong = " + int.Parse(txtSoLuong.Text.Trim()) + " where mahd = '" + cbboxMaHD.SelectedItem.ToString().Trim() + "' and masp = '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "' exec dbo.thanhtiencthd @mahd = '" + cbboxMaHD.SelectedItem.ToString().Trim() + "', @masp = '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "' exec dbo.tongtienhd @mahd = '" + cbboxMaHD.SelectedItem.ToString().Trim() + "'";
                cn.themxoasua(sql);
                CHITIETHOADONDAO.SuaCTHD(dsCTHD, cbboxMaHD.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()));
                DataGridViewRow row = dgvCTHD.Rows[indexCTHD];
                row.Cells[2].Value = txtSoLuong.Text.Trim();
                row.Cells[3].Value = int.Parse(txtSoLuong.Text.Trim()) * SANPHAMDAO.GiaMaSP(QuanLyHangHoa.dsSP, SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()));
            }
            txtTongTien.Text = "" + TongTien();
        }

        private void btnInCTHD_Click(object sender, EventArgs e)
        {
            List<CHITIETHOADON> ds = CHITIETHOADONDAO.dsCTHDTheoMaHD(dsCTHD, cbboxMaHD.SelectedItem.ToString().Trim());
            string line4 = "";
            string mahd="";
            foreach (CHITIETHOADON sp in ds)
            {

                int lengthten = SANPHAMDAO.TenSP(QuanLyHangHoa.dsSP, sp.getMasp()).Length;
                int length = 20 - lengthten;
                string khoangcach = "";
                for (int i = 0; i < length; i++)
                {
                    khoangcach += " ";
                }
                
                mahd = sp.getMahd();
                line4 +=SANPHAMDAO.TenSP(QuanLyHangHoa.dsSP, sp.getMasp()) + khoangcach+ sp.getSoluong() + "           " + sp.thanhtien(SANPHAMDAO.GiaMaSP(QuanLyHangHoa.dsSP, sp.getMasp())) + "\n";
            }
            string[] lines = { "                                Hóa Đơn\n", "Tên khách hàng: " + HOADONDAO.TenKhachHang(dsHD, mahd) + "\n", "Mã hóa đơn: " + mahd+"\n", "Tên Sản Phẩm      Số lượng      Thành tiền", line4, "Tổng tiền: " + txtTongTien.Text };
            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file.    You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(@"C:\DevPrograms\DoAnCongNghePhanMem (2)\Phan tich thiet ke HTTT\Phan tich thiet ke HTTT\BanIn\In.txt", lines);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\DevPrograms\DoAnCongNghePhanMem (2)\Phan tich thiet ke HTTT\Phan tich thiet ke HTTT\BanIn\In.txt"; // Your absolute PATH 

            Process.Start(startInfo);
        }

        int indexCTHD;
        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexCTHD = e.RowIndex;
            if (indexCTHD < 0 || indexCTHD > dgvCTHD.RowCount - 1)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng hoặc cột để sửa");
                return;
            }
            cbboxTenSP.Text = dgvCTHD.Rows[indexCTHD].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvCTHD.Rows[indexCTHD].Cells[2].Value.ToString();
            cbboxMaHD.Text = dgvCTHD.Rows[indexCTHD].Cells[0].Value.ToString();
            btnThemCTHD.Enabled = true;
            btnLuuCTHD.Enabled = false;
            btnSuaCTHD.Enabled = true;
            btnXoaCTHD.Enabled = true;
            btnInCTHD.Enabled = true;
            txtSoLuong.Enabled = true;
        }

        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu cho hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                String sql = "delete from ct_hoadon where mahd = '" + cbboxMaHD.SelectedItem.ToString().Trim() + "' and masp = '" + SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()) + "' exec dbo.tongtienhd @mahd = '" + cbboxMaHD.SelectedItem.ToString().Trim() + "'";
                cn.themxoasua(sql);
                CHITIETHOADONDAO.XoaCTHD(dsCTHD, cbboxMaHD.SelectedItem.ToString().Trim(), SANPHAMDAO.MaSPTheoTenSP(QuanLyHangHoa.dsSP, cbboxTenSP.SelectedItem.ToString().Trim()));
                dgvCTHD.Rows.RemoveAt(indexCTHD);
                txtTongTien.Text = "" + TongTien();
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

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Textbox này chỉ cho nhập số, vui lòng nhập số");
                e.Handled = true;
            }
        }

        private void QuanLyBanHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
        }
    }
}
