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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            cbboxChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public Boolean kttxt()
        {
            if (txtTaiKhoan.Text.Equals("") || txtMatKhau.Text.Equals("") || cbboxChucVu.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để đăng nhập");
                return false;
            }
            return true;
        }

        public Boolean ktdangnhap()
        {
            if (NHANVIENDAO.KiemTraDangNhap(QuanLyNhanVien.dsNV, txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim(), cbboxChucVu.SelectedItem.ToString().Trim()) == false)
            {
                MessageBox.Show("Vui lòng nhập đúng tài khoản, mật khẩu hoặc chức vụ của mình");
                return false;
            }
            return true;
        }

        public static String MaNV = "";
        public static String ChucVu = "";
        private void btnDN_Click(object sender, EventArgs e)
        {
            if (kttxt())
            {
                if (txtTaiKhoan.Text.Trim().Equals("giamdoc") && txtMatKhau.Text.Trim().Equals("giamdoc") && cbboxChucVu.SelectedItem.ToString().Trim().Equals("Giám đốc"))
                {
                    ChucVu = cbboxChucVu.SelectedItem.ToString().Trim();
                    Menu m = new Menu();
                    m.Show();
                    this.Hide();
                }
                else if (ktdangnhap())
                {
                    MaNV = NHANVIENDAO.MaNVTheoTaiKhoanDN(QuanLyNhanVien.dsNV, txtTaiKhoan.Text.Trim());
                    ChucVu = cbboxChucVu.SelectedItem.ToString().Trim();
                    if (cbboxChucVu.SelectedItem.ToString().Trim().Equals("Quản lý"))
                    {
                        Menu m = new Menu();
                        m.Show();
                        this.Hide();
                    }
                    else if (cbboxChucVu.SelectedItem.ToString().Trim().Equals("Nhân viên bán hàng"))
                    {
                        QuanLyBanHang bh = new QuanLyBanHang();
                        bh.Show();
                        this.Hide();
                    }
                    else if (cbboxChucVu.SelectedItem.ToString().Trim().Equals("Nhân viên kỹ thuật"))
                    {
                        GUI.QuanLySuaChua sc = new GUI.QuanLySuaChua();
                        sc.Show();
                        this.Hide();
                    }
                    else if (cbboxChucVu.SelectedItem.ToString().Trim().Equals("Nhân viên kho"))
                    {
                        Menu m = new Menu();
                        m.Show();
                        this.Hide();
                    }
                }
            }
        }
    }
}
