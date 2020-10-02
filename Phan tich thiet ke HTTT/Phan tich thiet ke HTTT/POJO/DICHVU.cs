using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class DICHVU
    {
        private String madv, tendv;
        private Decimal gia;

        public DICHVU() { }

        public DICHVU(String madv, String tendv, Decimal gia)
        {
            this.madv = madv;
            this.tendv = tendv;
            this.gia = gia;
        }

        public String getMadv()
        {
            return madv;
        }

        public String getTendv()
        {
            return tendv;
        }

        public Decimal getGia()
        {
            return gia;
        }

        public void setMadv(String madv) 
        {
            this.madv = madv;
        }

        public void setTendv(String tendv)
        {
            this.tendv = tendv;
        }

        public void setGia(Decimal gia)
        {
            this.gia = gia;
        }
    }
}
