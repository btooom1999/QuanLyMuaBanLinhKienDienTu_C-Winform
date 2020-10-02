using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class NHACUNGCAP
    {
        private String mancc, tenncc, diachi, sdt;

        public NHACUNGCAP() { }

        public NHACUNGCAP(String mancc, String tenncc, String diachi, String sdt) 
        {
            this.mancc = mancc;
            this.tenncc = tenncc;
            this.diachi = diachi;
            this.sdt = sdt;
        }

        public String getMancc()
        {
            return mancc;
        }

        public String getTennc()
        {
            return tenncc;
        }

        public String getDiachi(){
            return diachi;
        }

        public String getSdt()
        {
            return sdt;
        }

        public void setMancc(String mancc)
        {
            this.mancc = mancc;
        }

        public void setTenncc(String tenncc)
        {
            this.tenncc = tenncc;
        }

        public void setDiachi(String diachi)
        {
            this.diachi = diachi;
        }

        public void setSdt(String sdt)
        {
            this.sdt = sdt;
        }
    }
}
