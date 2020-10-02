using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phan_tich_thiet_ke_HTTT.GUI;
namespace Phan_tich_thiet_ke_HTTT
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        public void Enabled()
        {
            if (DangNhap.ChucVu.Equals("Nhân viên kho"))
            {
                sảnPhẩmToolStripMenuItem.Enabled = false;
                nhânViênToolStripMenuItem.Enabled = false;
                dịchVụToolStripMenuItem.Enabled = false;
                đặtHàngToolStripMenuItem.Enabled = false;
                nhàCungCấpToolStripMenuItem.Enabled = false;
            }
            else if (DangNhap.ChucVu.Equals("Giám đốc"))
            {
                sảnPhẩmToolStripMenuItem.Enabled = false;
                dịchVụToolStripMenuItem.Enabled = false;
                khoToolStripMenuItem.Enabled = false;
                đặtHàngToolStripMenuItem.Enabled = false;
                nhàCungCấpToolStripMenuItem.Enabled = false;
            }
            else
            {
                khoToolStripMenuItem.Enabled = false;
            }
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyHangHoa hh = new QuanLyHangHoa();
            if (Application.OpenForms.OfType<QuanLyHangHoa>().Any())
            {
                Application.OpenForms.OfType<QuanLyHangHoa>().First().Close();
            }
            hh.MdiParent = this;
            hh.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

            QuanLyNhanVien nv = new QuanLyNhanVien();
                if (Application.OpenForms.OfType<QuanLyNhanVien>().Any())
                {
                    Application.OpenForms.OfType<QuanLyNhanVien>().First().Close();
                }
                nv.MdiParent = this;
                nv.Show();
          
            
        }

        private void nhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            QuanLyNhapKho nk = new QuanLyNhapKho();
            if (Application.OpenForms.OfType<QuanLyNhapKho>().Any())
            {
                Application.OpenForms.OfType<QuanLyNhapKho>().First().Close();
            }
            nk.MdiParent = this;
            nk.Show();
        }

        private void xuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyXuatKho xl = new QuanLyXuatKho();
            if (Application.OpenForms.OfType<QuanLyXuatKho>().Any())
            {
                Application.OpenForms.OfType<QuanLyXuatKho>().First().Close();
            }
            xl.MdiParent = this;
            xl.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeSanPham tk = new ThongKeSanPham();
            if (Application.OpenForms.OfType<ThongKeSanPham>().Any())
            {
                Application.OpenForms.OfType<ThongKeSanPham>().First().Close();
            }
            tk.MdiParent = this;
            tk.Show();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.QuanLyDichVu dv = new GUI.QuanLyDichVu();
            if (Application.OpenForms.OfType<GUI.QuanLyDichVu>().Any())
            {
                Application.OpenForms.OfType<GUI.QuanLyDichVu>().First().Close();
            }
            dv.MdiParent = this;
            dv.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Enabled();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.QuanLyNhaCungCap dv = new GUI.QuanLyNhaCungCap();
            if (Application.OpenForms.OfType<GUI.QuanLyNhaCungCap>().Any())
            {
                Application.OpenForms.OfType<GUI.QuanLyNhaCungCap>().First().Close();
            }
            dv.MdiParent = this;
            dv.Show();
        }

        private void đặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyDatHang dv = new QuanLyDatHang();
            if (Application.OpenForms.OfType<QuanLyDatHang>().Any())
            {
                Application.OpenForms.OfType<QuanLyDatHang>().First().Close();
            }
            dv.MdiParent = this;
            dv.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DangNhap frm = new DangNhap();
                frm.Show();
                
            }
        }
    }
}
