using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class XUATKHO
    {
        private String mapx, ngaylap, manv, ghichu;

        public XUATKHO() { }

        public XUATKHO(String mapx, String ngaylap, String manv, String ghichu)
        {
            this.mapx = mapx;
            this.ngaylap = ngaylap;
            this.manv = manv;
            this.ghichu = ghichu;
        }

        public String getMapx()
        {
            return mapx;
        }

        public String getNgaylap()
        {
            return ngaylap;
        }

        public String getManv()
        {
            return manv;
        }

        public String getGhichu()
        {
            return ghichu;
        }

        public void setMapx(String mapx)
        {
            this.mapx = mapx;
        }

        public void setNgaylap(String ngaylap)
        {
            this.ngaylap = ngaylap;
        }

        public void setManv(String manv)
        {
            this.manv = manv;
        }

        public void setGhichu(String ghichu)
        {
            this.ghichu = ghichu;
        }
    }
}
