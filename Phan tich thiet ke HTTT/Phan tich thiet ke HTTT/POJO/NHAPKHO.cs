using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class NHAPKHO
    {
        private String mapn, mancc, ngaylap, manv, ghichu;

        public NHAPKHO() { }

        public NHAPKHO(String mapn, String mancc, String ngaylap, String manv, String ghichu)
        {
            this.mapn = mapn;
            this.mancc = mancc;
            this.ngaylap = ngaylap;
            this.manv = manv;
            this.ghichu = ghichu;
        }

        public String getMapn()
        {
            return mapn;
        }

        public String getMancc()
        {
            return mancc;
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

        public void setMapn(String mapn)
        {
            this.mapn = mapn;
        }

        public void setMancc(String mancc)
        {
            this.mancc = mancc;
        }

        public void setMasp(String mancc)
        {
            this.mancc = mancc;
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
