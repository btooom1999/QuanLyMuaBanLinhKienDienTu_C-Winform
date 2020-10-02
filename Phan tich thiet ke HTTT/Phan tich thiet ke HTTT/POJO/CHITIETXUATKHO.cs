using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class CHITIETXUATKHO
    {
        private String mapx, masp;
        private int soluong;

        public CHITIETXUATKHO() { }

        public CHITIETXUATKHO(String mapx, String masp, int soluong)
        {
            this.mapx = mapx;
            this.masp = masp;
            this.soluong = soluong;
        }

        public String getMapx()
        {
            return mapx;
        }

        public String getMasp()
        {
            return masp;
        }

        public int getSoluong()
        {
            return soluong;
        }

        public void setMapx(String mapx)
        {
            this.mapx = mapx;
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
