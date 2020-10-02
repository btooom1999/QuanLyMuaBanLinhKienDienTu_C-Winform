using Phan_tich_thiet_ke_HTTT.DAO;
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
    public partial class KiemTraKetNoiDatabase : Form
    {
        public KiemTraKetNoiDatabase()
        {
            InitializeComponent();
        }

        public static String _server = "";
        public static String _user = "";
        public static String _password = "";

        ConnectionDB cn = new ConnectionDB();
        private void KiemTraKetNoiDatabase_Load(object sender, EventArgs e)
        {

        }

        private void btnKetnoi_Click(object sender, EventArgs e)
        {
            if (txtDatabase.Text.Equals("QL_MUABANLINHKIEN1") && cn.kiemtraketnoidatabase(txtServer.Text, txtUser.Text, txtPassword.Text))
            {
                MessageBox.Show("Kết nối cơ sở dữ liệu thành công");
                _server = txtServer.Text;
                _user = txtUser.Text;
                _password = txtPassword.Text;
                DangNhap dn = new DangNhap();
                dn.Show();
            }
            else
            {
                MessageBox.Show("Kết nối cơ sở dữ liệu thất bại");
            }
        }
    }
}
