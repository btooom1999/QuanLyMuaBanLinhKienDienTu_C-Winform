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

namespace Phan_tich_thiet_ke_HTTT.GUI
{
    public partial class QuanLySuaChua : Form
    {
        public QuanLySuaChua()
        {
            InitializeComponent();
            cbboxMaHD.DropDownStyle = ComboBoxStyle.DropDownList;
            cbboxTenSP.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        List<HOADON> dsHDDV = HOADONDVDAO.getDSHDV();
        public static List<CHITIETHOADON> dsCTHDDV = CHITIETHOADONDVDAO.getDSCTHDDV();

        ConnectionDB cn = new ConnectionDB();

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm hóa đơn mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                txtMaHD.Text = HOADONDVDAO.MaHDDVTuDong(dsHDDV);
                txtSDT.Enabled = true;
                txtTenKH.Enabled = true;
                dateNgayLapHD.Enabled = true;
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
            }
        }

        public void loaddulieuhoadondichvu()
        {
            dgvHDDV.Rows.Clear();
            foreach(HOADON hd in dsHDDV){
                dgvHDDV.Rows.Add(hd.getMahd(), hd.getTenkh(), hd.getSdt(), hd.getNgaylap(), hd.getManv());
                cbboxMaHD.Items.Add(hd.getMahd());
            }
        }

        public void loadcomboboxtendichvu()
        {
            foreach (DICHVU dv in QuanLyDichVu.dsDV)
                cbboxTenSP.Items.Add(dv.getTendv());
        }

        public void loaddulieuchitiethoadondichvu()
        {
            dgvCTHDDV.Rows.Clear();
            foreach (CHITIETHOADON cthd in dsCTHDDV)
                dgvCTHDDV.Rows.Add(cthd.getMahd(), DICHVUDAO.TenDV(QuanLyDichVu.dsDV, cthd.getMasp()), cthd.getSoluong(), cthd.thanhtien(DICHVUDAO.GiaMaDV(QuanLyDichVu.dsDV, cthd.getMasp())));
        }

        public void LamMoiHDDV()
        {
            txtMaHD.Enabled = false;
            txtTenKH.Enabled = false;
            txtSDT.Enabled = false;
            dateNgayLapHD.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            txtMaHD.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
        }

        public void LamMoiCTHDDV()
        {
            cbboxTenSP.Enabled = false;
            txtSoLuong.Enabled = false;
            txtTongTien.Enabled = false;
            btnThemCTHD.Enabled = false;
            btnLuuCTHD.Enabled = false;
            btnXoaCTHD.Enabled = false;
            btnSuaCTHD.Enabled = false;
            btnIn.Enabled = false;
            cbboxMaHD.SelectedIndex = -1;
            cbboxTenSP.SelectedIndex = -1;
            cbboxMaHD.Text = "--Chọn--";
            cbboxTenSP.Text = "--Chọn--";
        }

        private void QuanLySuaChua_Load(object sender, EventArgs e)
        {
            dgvCTHDDV.ReadOnly = true;
            dgvHDDV.ReadOnly = true;
            dgvCTHDDV.Enabled = false;
            LamMoiHDDV();
            LamMoiCTHDDV();
            loaddulieuhoadondichvu();
            loadcomboboxtendichvu();
            loaddulieuchitiethoadondichvu();
        }

        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm dữ liệu vào hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                btnThemCTHD.Enabled = false;
                btnLuuCTHD.Enabled = true;
                btnXoaCTHD.Enabled = false;
                btnSuaCTHD.Enabled = false;
                cbboxTenSP.Enabled = true;
                txtSoLuong.Enabled = true;
                cbboxTenSP.SelectedIndex = -1;
                cbboxTenSP.Text = "--Chọn--";
                txtSoLuong.Text = "0";
            }
        }

        public Decimal tongtien()
        {
            Decimal tong = 0;
            for (int i = 0; i < dgvCTHDDV.RowCount - 1; i++)
                tong += Decimal.Parse(dgvCTHDDV.Rows[i].Cells[3].Value.ToString());
            return tong;
        }

        private void cbboxMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCTHDDV.Rows.Clear();
            dgvCTHDDV.Enabled = true;
            btnThemCTHD.Enabled = true;
            btnIn.Enabled = true;
            List<CHITIETHOADON> ds = CHITIETHOADONDVDAO.dsCTHDDVTheoMaHD(dsCTHDDV, cbboxMaHD.SelectedItem.ToString().Trim());
            foreach (CHITIETHOADON cthd in ds)
                dgvCTHDDV.Rows.Add(cthd.getMahd(), DICHVUDAO.TenDV(QuanLyDichVu.dsDV, cthd.getMasp()), cthd.getSoluong(), cthd.thanhtien(DICHVUDAO.GiaMaDV(QuanLyDichVu.dsDV, cthd.getMasp())));
            txtTongTien.Text = "" + tongtien();
        }

        public Boolean kttxtHDDV()
        {
            if (txtTenKH.Text.Equals("") || txtSDT.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hóa đơn dịch vụ");
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kttxtHDDV())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "insert into hd_dichvu values ('" + txtMaHD.Text.Trim() + "', '" + dateNgayLapHD.Text.Trim() + "', N'" + txtTenKH.Text.Trim() + "', '" + txtSDT.Text.Trim() + "', 0, '"+DangNhap.MaNV+"')";
                    cn.themxoasua(sql);
                    HOADONDVDAO.ThemHDDV(dsHDDV, txtMaHD.Text.Trim(), txtTenKH.Text.Trim(), txtSDT.Text.Trim(), dateNgayLapHD.Text.Trim(), DangNhap.MaNV);
                    dgvHDDV.Rows.Add(txtMaHD.Text.Trim(), txtTenKH.Text.Trim(), txtSDT.Text.Trim(), dateNgayLapHD.Text.Trim(), DangNhap.MaNV);
                    cbboxMaHD.Items.Add(txtMaHD.Text.Trim());
                    LamMoiHDDV();
                }
            }
        }

        public Boolean kttxtCTHD()
        {
            if (cbboxTenSP.SelectedIndex < 0 || txtSoLuong.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin chi tiết hóa đơn dịch vụ");
                return false;
            }
            return true;
        }

        public Boolean ktmahddvmadvtrung()
        {
            if (CHITIETHOADONDVDAO.KTMaHDVMaSPTrung(dsCTHDDV, cbboxMaHD.SelectedItem.ToString().Trim(), DICHVUDAO.MaDVTheoTenDV(QuanLyDichVu.dsDV, cbboxTenSP.SelectedItem.ToString().Trim())))
            {
                MessageBox.Show("Dữ liệu này đã tồn tại, không thể lưu");
                return false;
            }
            return true;
        }

        private void btnLuuCTHD_Click(object sender, EventArgs e)
        {
            if (kttxtCTHD() && ktmahddvmadvtrung())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm dữ liệu cho chi tiết hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "insert into ct_hd_dichvu values ('" + cbboxMaHD.SelectedItem.ToString().Trim() + "', '" + DICHVUDAO.MaDVTheoTenDV(QuanLyDichVu.dsDV, cbboxTenSP.SelectedItem.ToString().Trim()) + "', " + int.Parse(txtSoLuong.Text.Trim()) + ", " + int.Parse(txtSoLuong.Text.Trim()) + " * " + DICHVUDAO.GiaMaDV(QuanLyDichVu.dsDV, DICHVUDAO.MaDVTheoTenDV(QuanLyDichVu.dsDV, cbboxTenSP.SelectedItem.ToString().Trim())) + ")";
                    cn.themxoasua(sql);
                    CHITIETHOADONDVDAO.ThemCTHDDV(dsCTHDDV, cbboxMaHD.SelectedItem.ToString().Trim(), DICHVUDAO.MaDVTheoTenDV(QuanLyDichVu.dsDV, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()));
                    dgvCTHDDV.Rows.Add(cbboxMaHD.SelectedItem.ToString().Trim(), cbboxTenSP.SelectedItem.ToString().Trim(), int.Parse(txtSoLuong.Text.Trim()), int.Parse(txtSoLuong.Text.Trim()) * DICHVUDAO.GiaMaDV(QuanLyDichVu.dsDV, DICHVUDAO.MaDVTheoTenDV(QuanLyDichVu.dsDV, cbboxTenSP.SelectedItem.ToString().Trim())));
                    cbboxTenSP.Enabled = false;
                    txtSoLuong.Enabled = false;
                    txtTongTien.Enabled = false;
                    btnThemCTHD.Enabled = true;
                    btnLuuCTHD.Enabled = false;
                    txtTongTien.Text = "" + tongtien();
                    MessageBox.Show("Thêm thành công");
                }
            }
        }

        private void btnSuaCTHD_Click(object sender, EventArgs e)
        {
            if (kttxtCTHD())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa dữ liệu của chi tiết hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "update ct_hd_dichvu set soluongdv = " + int.Parse(txtSoLuong.Text.Trim()) + " where sohd = '" + cbboxMaHD.SelectedItem.ToString().Trim() + "' and madv = '" + DICHVUDAO.MaDVTheoTenDV(QuanLyDichVu.dsDV, cbboxTenSP.SelectedItem.ToString().Trim()) + "' exec dbo.thanhtiencthddv @sohd = '" + cbboxMaHD.SelectedItem.ToString().Trim() + "', @madv = '" + DICHVUDAO.MaDVTheoTenDV(QuanLyDichVu.dsDV, cbboxTenSP.SelectedItem.ToString().Trim()) + "' exec dbo.tongtienhddv @sohd = '" + cbboxMaHD.SelectedItem.ToString().Trim() + "'";
                    cn.themxoasua(sql);
                    CHITIETHOADONDVDAO.SuaCTHDDV(dsCTHDDV, cbboxMaHD.SelectedItem.ToString().Trim(), DICHVUDAO.MaDVTheoTenDV(QuanLyDichVu.dsDV, cbboxTenSP.SelectedItem.ToString().Trim()), int.Parse(txtSoLuong.Text.Trim()));
                    DataGridViewRow row = dgvCTHDDV.Rows[indexCTHDDV];
                    row.Cells[2].Value = int.Parse(txtSoLuong.Text.Trim());
                    row.Cells[3].Value = int.Parse(txtSoLuong.Text.Trim()) * DICHVUDAO.GiaMaDV(QuanLyDichVu.dsDV, DICHVUDAO.MaDVTheoTenDV(QuanLyDichVu.dsDV, cbboxTenSP.SelectedItem.ToString().Trim()));
                    txtTongTien.Text = "" + tongtien();
                    MessageBox.Show("Sửa thành công");
                }
            }
        }

        int indexCTHDDV;
        private void dgvCTHDDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexCTHDDV = e.RowIndex;
            if(indexCTHDDV < 0 || indexCTHDDV >= dgvCTHDDV.RowCount - 1)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng hoặc cột để sửa hoặc xóa");
                return;
            }
            cbboxTenSP.Text = dgvCTHDDV.Rows[indexCTHDDV].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvCTHDDV.Rows[indexCTHDDV].Cells[2].Value.ToString();
            cbboxMaHD.Text = dgvCTHDDV.Rows[indexCTHDDV].Cells[0].Value.ToString();
            btnThemCTHD.Enabled = true;
            btnLuuCTHD.Enabled = false;
            btnXoaCTHD.Enabled = true;
            btnSuaCTHD.Enabled = true;
            btnIn.Enabled = true;
            cbboxTenSP.Enabled = false;
            txtSoLuong.Enabled = true;
        }

        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu chi tiết hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                String sql = "delete from ct_hd_dichvu where sohd = '" + cbboxMaHD.SelectedItem.ToString().Trim() + "' and madv = '" + DICHVUDAO.MaDVTheoTenDV(QuanLyDichVu.dsDV, cbboxTenSP.SelectedItem.ToString().Trim()) + "' exec dbo.tongtienhddv @sohd = '" + cbboxMaHD.SelectedItem.ToString().Trim() + "'";
                cn.themxoasua(sql);
                CHITIETHOADONDVDAO.XoaCTHDDV(dsCTHDDV, cbboxMaHD.SelectedItem.ToString().Trim(), DICHVUDAO.MaDVTheoTenDV(QuanLyDichVu.dsDV, cbboxTenSP.SelectedItem.ToString().Trim()));
                dgvCTHDDV.Rows.RemoveAt(indexCTHDDV);
                txtTongTien.Text = "" + tongtien();
                MessageBox.Show("Xóa thành công");
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

        private void QuanLySuaChua_FormClosed(object sender, FormClosedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            List<CHITIETHOADON> ds = CHITIETHOADONDVDAO.dsCTHDDVTheoMaHD(dsCTHDDV, cbboxMaHD.SelectedItem.ToString().Trim());
            string line4 = "";
            string mahd = "";
            foreach (CHITIETHOADON sp in ds)
            {

                int lengthten = DICHVUDAO.TenDV(QuanLyDichVu.dsDV, sp.getMasp()).Length;
                int lengthsoluong = sp.getSoluong().ToString().Length;
                int length = 20 - lengthten;
                int length2 = 16 - lengthsoluong;
                string khoangcach = "";
                string khoangcach2 = "";
                for (int i = 0; i < length; i++)
                {
                    khoangcach += " ";
                }
                for (int i = 0; i < length2; i++)
                {
                    khoangcach2 += " ";
                }

                mahd = sp.getMahd();
                line4 += DICHVUDAO.TenDV(QuanLyDichVu.dsDV, sp.getMasp()) + khoangcach + sp.getSoluong() + khoangcach2 + sp.thanhtien(SANPHAMDAO.GiaMaSP(QuanLyHangHoa.dsSP, sp.getMasp())) + "\n";
            }
            string[] lines = { "                                Hóa Đơn\n", "Tên khách hàng: " + HOADONDVDAO.TenKhachHang(dsHDDV, mahd) + "\n", "Mã hóa đơn: " + mahd + "\n", "Tên Sản Phẩm      Số lượng      Thành tiền", line4, "Tổng tiền: " + txtTongTien.Text };
            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file.    You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(@"C:\DevPrograms\DoAnCongNghePhanMem (2)\Phan tich thiet ke HTTT\Phan tich thiet ke HTTT\BanIn\In.txt", lines);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\DevPrograms\DoAnCongNghePhanMem (2)\Phan tich thiet ke HTTT\Phan tich thiet ke HTTT\BanIn\In.txt"; // Your absolute PATH 

            Process.Start(startInfo);
        }
    }
}
