using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class CHITIETPHIEUDATHANG
    {
        private String sophieu, masp;
        private int soluong;
        private Decimal giatien;

        public CHITIETPHIEUDATHANG() { }

        public CHITIETPHIEUDATHANG(String sophieu, String masp, int soluong, Decimal giatien) 
        {
            this.sophieu = sophieu;
            this.masp = masp;
            this.soluong = soluong;
            this.giatien = giatien;
        }

        public String getSophieu()
        {
            return sophieu;
        }

        public String getMasp()
        {
            return masp;
        }

        public int getSoluong()
        {
            return soluong;
        }

        public Decimal getGiatien()
        {
            return giatien;
        }

        public void setSophieu(String sophieu)
        {
            this.sophieu = sophieu;
        }

        public void setMasp(String masp)
        {
            this.masp = masp;
        }

        public void setSoluong(int soluong)
        {
            this.soluong = soluong;
        }

        public void setGiatien(Decimal giatien)
        {
            this.giatien = giatien;
        }

        public Decimal thanhtien()
        {
            return soluong * giatien;
        }
    }
}
