using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class PHIEUDATHANG
    {
        private String sophieu, ngaylap, manql;

        public PHIEUDATHANG() { }

        public PHIEUDATHANG(String sophieu, String ngaylap, String manql) 
        {
            this.sophieu = sophieu;
            this.ngaylap = ngaylap;
            this.manql = manql;
        }

        public String getSophieu()
        {
            return sophieu;
        }

        public String getNgaylap()
        {
            return ngaylap;
        }

        public String getManql()
        {
            return manql;
        }

        public void setSophieu(String sophieu)
        {
            this.sophieu = sophieu;
        }

        public void setNgaylap(String ngaylap)
        {
            this.ngaylap = ngaylap;
        }

        public void setManql(String manql)
        {
            this.manql = manql;
        }

        public Decimal tongtien(Decimal tien)
        {
            return tien;
        }
    }
}
