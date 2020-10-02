using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class HOADON
    {
        private String mahd, tenkh, sdt, ngaylap, manv;

        public HOADON() { }

        public HOADON(String mahd, String tenkh, String sdt, String ngaylap, String manv) {
            this.mahd = mahd;
            this.tenkh = tenkh;
            this.sdt = sdt;
            this.ngaylap = ngaylap;
            this.manv = manv;
        }

        public String getMahd()
        {
            return mahd;
        }

        public String getTenkh()
        {
            return tenkh;
        }

        public String getSdt()
        {
            return sdt;
        }

        public String getNgaylap()
        {
            return ngaylap;
        }

        public String getManv()
        {
            return manv;
        }

        public void setMahd(String mahd)
        {
            this.mahd = mahd;
        }

        public void setTenkh(String tenkh)
        {
            this.tenkh = tenkh;
        }

        public void setSdt(String sdt)
        {
            this.sdt = sdt;
        }

        public void setNgaylap(String ngaylap)
        {
            this.ngaylap = ngaylap;
        }

        public void setManv(String manv)
        {
            this.manv = manv;
        }
    }
}
