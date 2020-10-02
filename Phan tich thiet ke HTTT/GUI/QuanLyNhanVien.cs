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
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
            cbboxChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //List<BANQUANLY> dsNQL = BANQUANLYDAO.getDSBQL();
        public static List<NHANVIEN> dsNV = NHANVIENDAO.getDSNV();

        ConnectionDB cn = new ConnectionDB();

        public void loaddanhsachnhanvien()
        {
            dgvNV.Rows.Clear();
            foreach (NHANVIEN nv in dsNV)
                dgvNV.Rows.Add(nv.getManv(), nv.getTennv(), nv.getNgaysinh(), nv.getGioitinh(), nv.getDiachi(), nv.getSdt(), nv.getNgayvaolam(), nv.getChucvu(), nv.getTaikhoan(), nv.getMatkhau(), nv.getManql());
        }

        public String gioitinh()
        {
            if (rdNam.Checked)
                return "Nam";
            return "Nữ";
        }

        public void LamMoi()
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtTenNV.Enabled = false;
            txtDiaChi.Enabled = false;
            txtMaNV.Enabled = false;
            txtMatKhau.Enabled = false;
            txtSDT.Enabled = false;
            txtMaNQL.Enabled = false;
            cbboxChucVu.Enabled = false;
            dateNgaySinh.Enabled = false;
            dateNgayVaoLam.Enabled = false;
            rdNam.Enabled = false;
            rdNu.Enabled = false;
            rdNam.Checked = false;
            rdNu.Checked = false;
            txtMaNV.Text = "";
            txtDiaChi.Text = "";
            txtMatKhau.Text = "";
            txtSDT.Text = "";
            txtTaiKhoan.Text = "";
            txtTenNV.Text = "";
            cbboxChucVu.SelectedIndex = -1;
            cbboxChucVu.Text = "--Chọn--";
        }

        public void Enabled()
        {
            if(DangNhap.ChucVu.Equals("Quản lý"))
            {
                txtMaNQL.Enabled = false;
                txtMaNQL.Text = DangNhap.MaNV;
                cbboxChucVu.Items.Add("Nhân viên bán hàng");
                cbboxChucVu.Items.Add("Nhân viên kỹ thuật");
                cbboxChucVu.Items.Add("Nhân viên kho");
            }
            else
            {
                txtMaNQL.Enabled = true;
                cbboxChucVu.Items.Add("Quản lý");
                txtMaNQL.Text = txtMaNV.Text.Trim();
                txtMaNQL.Enabled = false;
            }
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LamMoi();
            loaddanhsachnhanvien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm nhân viên mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                cbboxChucVu.Items.Clear();
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                txtTaiKhoan.Enabled = true;
                txtTenNV.Enabled = true;
                txtDiaChi.Enabled = true;
                txtMatKhau.Enabled = true;
                txtSDT.Enabled = true;
                cbboxChucVu.Enabled = true;
                dateNgaySinh.Enabled = true;
                dateNgayVaoLam.Enabled = true;
                rdNam.Enabled = true;
                rdNu.Enabled = true;
                rdNam.Checked = true;
                txtDiaChi.Text = "";
                txtMatKhau.Text = "";
                txtSDT.Text = "";
                txtTaiKhoan.Text = "";
                txtTenNV.Text = "";
                cbboxChucVu.SelectedIndex = -1;
                cbboxChucVu.Text = "--Chọn--";
                txtMaNV.Text = NHANVIENDAO.KiemTraMaNVTuDongTang(dsNV, NHANVIENDAO.MaNVTuDong(dsNV));
                Enabled();
                txtTenNV.Focus();
            }
        }

        public Boolean kttaikhoankhithaydoi()
        {
            if (NHANVIENDAO.KiemTraTaiKhoanKhiThayDoi(dsNV, txtMaNV.Text.Trim(), txtTaiKhoan.Text.Trim()))
            {
                MessageBox.Show("Tài khoản này của nhân viên khác, không thể sửa");
                return false;
            }
            return true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (kttxt() && kttaikhoankhithaydoi())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "set dateformat dmy update nhanvien set tennv = N'" + txtTenNV.Text.Trim() + "', ngaysinh = '" + dateNgaySinh.Text.Trim() + "', gioitinh = N'" + gioitinh() + "', diachi = N'" + txtDiaChi.Text.Trim() + "', sdt = '" + txtSDT.Text.Trim() + "', ngayvaolam = '" + dateNgayVaoLam.Text.Trim() + "', chucvu = N'" + cbboxChucVu.SelectedItem.ToString().Trim() + "', taikhoan = '" + txtTaiKhoan.Text.Trim() + "', matkhau = '" + txtMatKhau.Text.Trim() + "', manql = '" + txtMaNQL.Text.Trim() + "' where manv = '" + txtMaNV.Text.Trim() + "'";
                    cn.themxoasua(sql);
                    NHANVIENDAO.SuaNV(dsNV, txtMaNV.Text.Trim(), txtTenNV.Text.Trim(), dateNgaySinh.Text.Trim(), gioitinh(), txtDiaChi.Text.Trim(), txtSDT.Text.Trim(), dateNgayVaoLam.Text.Trim(), cbboxChucVu.Text.Trim(), txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim(), txtMaNQL.Text.Trim());
                    DataGridViewRow row = dgvNV.Rows[index];
                    row.Cells[1].Value = txtTenNV.Text.Trim();
                    row.Cells[2].Value = dateNgaySinh.Text.Trim();
                    row.Cells[3].Value = gioitinh();
                    row.Cells[4].Value = txtDiaChi.Text.Trim();
                    row.Cells[5].Value = txtSDT.Text.Trim();
                    row.Cells[6].Value = dateNgayVaoLam.Text.Trim();
                    row.Cells[7].Value = cbboxChucVu.Text.Trim();
                    row.Cells[8].Value = txtTaiKhoan.Text.Trim();
                    row.Cells[9].Value = txtMatKhau.Text.Trim();
                    row.Cells[10].Value = txtMaNQL.Text.Trim();
                    MessageBox.Show("Sửa thành công");
                }
            }
        }

        public void radiogioitinh(String gioitinh) {
            if (gioitinh == "Nam")
                rdNam.Checked = true;
            else
                rdNu.Checked = true;
        }

        int index;

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index < 0 || index >= dgvNV.RowCount - 1)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng hoặc cột để xóa hoặc sửa");
                return;
            }        
            txtTenNV.Text = dgvNV.Rows[index].Cells[1].Value.ToString();
            dateNgaySinh.Value = DateTime.ParseExact(dgvNV.Rows[index].Cells[2].Value.ToString(), "dd/MM/yyyy", null);
            radiogioitinh(dgvNV.Rows[index].Cells[3].Value.ToString());
            txtDiaChi.Text = dgvNV.Rows[index].Cells[4].Value.ToString();
            txtSDT.Text = dgvNV.Rows[index].Cells[5].Value.ToString();
            dateNgayVaoLam.Value = DateTime.ParseExact(dgvNV.Rows[index].Cells[6].Value.ToString(), "dd/MM/yyyy", null);
            cbboxChucVu.Text = dgvNV.Rows[index].Cells[7].Value.ToString();
            txtTaiKhoan.Text = dgvNV.Rows[index].Cells[8].Value.ToString();
            txtMatKhau.Text = dgvNV.Rows[index].Cells[9].Value.ToString();
            txtMaNQL.Text = dgvNV.Rows[index].Cells[10].Value.ToString();
            txtMaNV.Text = dgvNV.Rows[index].Cells[0].Value.ToString();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtTaiKhoan.Enabled = true;
            txtTenNV.Enabled = true;
            txtDiaChi.Enabled = true;
            txtMatKhau.Enabled = true;
            txtSDT.Enabled = true;
            cbboxChucVu.Enabled = true;
            dateNgaySinh.Enabled = true;
            dateNgayVaoLam.Enabled = true;
            rdNam.Enabled = true;
            rdNu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                String sql = "delete from nhanvien where manv = '" + txtMaNV.Text.Trim() + "'";
                cn.themxoasua(sql);
                NHANVIENDAO.XoaNV(dsNV, txtMaNV.Text.Trim());
                dgvNV.Rows.RemoveAt(index);
                MessageBox.Show("Xóa thành công");
            }
        }

        public Boolean kttxt()
        {
            if(txtMaNV.Text.Equals("") || txtDiaChi.Text.Equals("") || txtMatKhau.Text.Equals("") || txtSDT.Text.Equals("") || txtTaiKhoan.Text.Equals("") || txtTenNV.Text.Equals("") || cbboxChucVu.SelectedIndex < 0 || txtMaNQL.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return false;
            }
            return true;
        }

        public Boolean kttrungmanv()
        {
            if (NHANVIENDAO.KiemTraTrungMaNV(dsNV, txtMaNV.Text.Trim()))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại, không thể lưu");
                return false;
            }
            return true;
        }

        public Boolean kttaikhoan()
        {
            if (NHANVIENDAO.KiemTraTaiKhoan(dsNV, txtTaiKhoan.Text.Trim()))
            {
                MessageBox.Show("Tài khoản này đã tồn tại, không thể lưu");
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kttxt() && kttrungmanv() && kttaikhoan())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "set dateformat dmy insert into nhanvien values ('" + txtMaNV.Text.Trim() + "', N'" + txtTenNV.Text.Trim() + "', '" + dateNgaySinh.Text.Trim() + "', N'" + gioitinh() + "', N'" + txtDiaChi.Text.Trim() + "', '" + txtSDT.Text.Trim() + "', '" + dateNgayVaoLam.Text.Trim() + "', N'" + cbboxChucVu.SelectedItem.ToString().Trim() + "', '" + txtTaiKhoan.Text.Trim() + "', '" + txtMatKhau.Text.Trim() + "', '" + txtMaNQL.Text.Trim() + "')";
                    cn.themxoasua(sql);
                    NHANVIENDAO.ThemNV(dsNV, txtMaNV.Text.Trim(), txtTenNV.Text.Trim(), dateNgaySinh.Text.Trim(), gioitinh(), txtDiaChi.Text.Trim(), txtSDT.Text.Trim(), dateNgayVaoLam.Text.Trim(), cbboxChucVu.SelectedItem.ToString().Trim(), txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim(), txtMaNQL.Text.Trim());
                    dgvNV.Rows.Add(txtMaNV.Text.Trim(), txtTenNV.Text.Trim(), dateNgaySinh.Text.Trim(), gioitinh(), txtDiaChi.Text.Trim(), txtSDT.Text.Trim(), dateNgayVaoLam.Text.Trim(), cbboxChucVu.SelectedItem.ToString().Trim(), txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim(), txtMaNQL.Text.Trim());
                    MessageBox.Show("Thêm thành công");
                    btnThem.Enabled = true;
                    btnLuu.Enabled = false;
                }
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
    }
}
