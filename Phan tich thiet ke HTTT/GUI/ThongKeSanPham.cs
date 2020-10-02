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
    public partial class ThongKeSanPham : Form
    {
        public ThongKeSanPham()
        {
            InitializeComponent();
        }

        List<SANPHAM> dsSP = SANPHAMDAO.getDSSANPHAM();

        public void loaddulieu()
        {
            int tong = 0;
            dgvTK.Rows.Clear();
            foreach (SANPHAM sp in dsSP)
            {
                dgvTK.Rows.Add(sp.getMasp(), sp.getTensp(), sp.getSoluong());
                tong += sp.getSoluong();
            }
            txtTong.Text = "" + tong;
            btnIn.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string line4 = "";
            int khoangcachtutensangsoluong = 22;
            foreach (SANPHAM sp in dsSP)
            {
                int lengthten = sp.getTensp().Length;
                int length = 22 - lengthten;
                string khoangcach = "";
                for (int i = 0; i < length; i++)
                {
                    khoangcach += " ";
                }
                line4 += sp.getMasp() + "          " + sp.getTensp() + khoangcach + sp.getSoluong() + "\n";
            }
            string[] lines = { "                                Thống Kê Sản Phẩm\n", "Danh sách sản phẩm\n", "Mã Sản Phẩm    Tên Sản Phẩm      Số lượng Tồn", line4,"Tổng sản phẩm tồn: "+txtTong.Text};
            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file.    You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(@"C:\DevPrograms\DoAnCongNghePhanMem (2)\Phan tich thiet ke HTTT\Phan tich thiet ke HTTT\BanIn\In.txt", lines);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\DevPrograms\DoAnCongNghePhanMem (2)\Phan tich thiet ke HTTT\Phan tich thiet ke HTTT\BanIn\In.txt"; // Your absolute PATH 

            Process.Start(startInfo);
        }

        private void ThongKeSanPham_Load(object sender, EventArgs e)
        {
            dgvTK.Rows.Clear();
            int count = 0;
            foreach (SANPHAM sp in dsSP)
            {
                dgvTK.Rows.Add(sp.getMasp(), sp.getTensp(), sp.getSoluong());
                count++;
            }



            txtTong.Text = count.ToString();
        }
    }
}
