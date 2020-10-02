using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class CHITIETHOADON
    {
        private String mahd, masp;
        private int soluong;

        public CHITIETHOADON() { }

        public CHITIETHOADON(String mahd, String masp, int soluong) 
        {
            this.mahd = mahd;
            this.masp = masp;
            this.soluong = soluong;
        }

        public String getMahd()
        {
            return mahd;
        }

        public String getMasp()
        {
            return masp;
        }

        public int getSoluong()
        {
            return soluong;
        }

        public void setMahd(String mahd)
        {
            this.mahd = mahd;
        }

        public void setMasp(String masp)
        {
            this.masp = masp;
        }

        public void setSoluong(int soluong)
        {
            this.soluong = soluong;
        }

        public Decimal thanhtien(Decimal gia)
        {
            return soluong * gia;
        }
    }
}
