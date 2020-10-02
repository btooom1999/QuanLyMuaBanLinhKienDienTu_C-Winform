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
    public partial class QuanLyNhaCungCap : Form
    {
        public QuanLyNhaCungCap()
        {
            InitializeComponent();
        }

        public static List<NHACUNGCAP> dsNCC = NHACUNGCAPDAO.getDSNCC();

        ConnectionDB cn = new ConnectionDB();

        public void loaddulieunhacungcap()
        {
            dgvNCC.Rows.Clear();
            foreach (NHACUNGCAP ncc in dsNCC)
                dgvNCC.Rows.Add(ncc.getMancc(), ncc.getTennc(), ncc.getDiachi(), ncc.getSdt());
        }

        public void LamMoi()
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtDiaChi.Enabled = false;
            txtMaNCC.Enabled = false;
            txtSDT.Enabled = false;
            txtTenNCC.Enabled = false;
            txtDiaChi.Text = "";
            txtMaNCC.Text = "";
            txtSDT.Text = "";
            txtTenNCC.Text = "";
        }

        private void QuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            LamMoi();
            loaddulieunhacungcap();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            txtTenNCC.Enabled = true;
            txtDiaChi.Text = "";
            txtMaNCC.Text = NHACUNGCAPDAO.KiemTraMaNCCTuDongTang(dsNCC, NHACUNGCAPDAO.MaNCCTuDong(dsNCC));
            txtSDT.Text = "";
            txtTenNCC.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (kttxt())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa nhà cung cấp này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "update nhacc set tenncc = '" + txtTenNCC.Text.Trim() + "', diachi = '" + txtDiaChi.Text.Trim() + "', sdt = '" + txtSDT.Text.Trim() + "' where mancc = '" + txtMaNCC.Text.Trim() + "'";
                    cn.themxoasua(sql);
                    NHACUNGCAPDAO.SuaNCC(dsNCC, txtMaNCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDiaChi.Text.Trim(), txtSDT.Text.Trim());
                    DataGridViewRow row = dgvNCC.Rows[index];
                    row.Cells[1].Value = txtTenNCC.Text.Trim();
                    row.Cells[2].Value = txtDiaChi.Text.Trim();
                    row.Cells[3].Value = txtSDT.Text.Trim();
                }
            }
        }

        public Boolean kttontaimancc()
        {
            if (NHACUNGCAPDAO.KiemTraTonTaiMaNCC(QuanLyNhapKho.dsNK, txtMaNCC.Text.Trim()))
            {
                MessageBox.Show("Mã nhà cung cấp này còn dữ liệu, không thể xóa");
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (kttontaimancc())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "delete from nhacc where mancc = '" + txtMaNCC.Text.Trim() + "'";
                    cn.themxoasua(sql);
                    NHACUNGCAPDAO.XoaNCC(dsNCC, txtMaNCC.Text.Trim());
                    dgvNCC.Rows.RemoveAt(index);
                    MessageBox.Show("Xóa thành công");
                }
            }
        }

        int index;

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index < 0 || index >= dgvNCC.RowCount - 1)
            {
                MessageBox.Show("Vui lòng nhập đúng dòng hoặc cột để xóa hoặc sửa");
                return;
            }
            txtTenNCC.Text = dgvNCC.Rows[index].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNCC.Rows[index].Cells[2].Value.ToString();
            txtSDT.Text = dgvNCC.Rows[index].Cells[3].Value.ToString();
            txtMaNCC.Text = dgvNCC.Rows[index].Cells[0].Value.ToString();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            txtTenNCC.Enabled = true;
        }

        public Boolean kttxt()
        {
            if (txtDiaChi.Text.Equals("") || txtMaNCC.Text.Equals("") || txtSDT.Text.Equals("") || txtTenNCC.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return false;
            }
            return true;
        }

        public Boolean kttrungmancc()
        {
            if (NHACUNGCAPDAO.KiemTraTrungMaNCC(dsNCC, txtMaNCC.Text.Trim()))
            {
                MessageBox.Show("Mã nhà cung cấp này đã tồn tại, không thể lưu");
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kttxt() && kttrungmancc())
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn lưu nhà cung cấp này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    String sql = "insert into nhacc values ('" + txtMaNCC.Text.Trim() + "', N'" + txtTenNCC.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', '" + txtSDT.Text.Trim() + "')";
                    cn.themxoasua(sql);
                    NHACUNGCAPDAO.ThemNCC(dsNCC, txtMaNCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDiaChi.Text.Trim(), txtSDT.Text.Trim());
                    dgvNCC.Rows.Add(txtMaNCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDiaChi.Text.Trim(), txtSDT.Text.Trim());
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
    }
}
