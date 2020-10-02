using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class CHITIETNHAPKHO
    {
        private String mapn, masp;
        private int soluong;

        public CHITIETNHAPKHO() { }

        public CHITIETNHAPKHO(String mapn, String masp, int soluong)
        {
            this.mapn = mapn;
            this.masp = masp;
            this.soluong = soluong;
        }

        public String getMapn()
        {
            return mapn;
        }

        public String getMasp()
        {
            return masp;
        }

        public int getSoluong()
        {
            return soluong;
        }

        public void setMapn(String mapn)
        {
            this.mapn = mapn;
        }

        public void setMasp(String masp)
        {
            this.masp = masp;
        }

        public void setSoluong(int soluong)
        {
            this.soluong = soluong;
        }
    }
}
