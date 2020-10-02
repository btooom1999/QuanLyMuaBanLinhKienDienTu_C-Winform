using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class BANQUANLY
    {
        private String manql, tennql, ngaysinh, sdt, diachi;

        public BANQUANLY() { }

        public BANQUANLY(String manql, String tennql, String ngaysinh, String sdt, String diachi) {
            this.manql = manql;
            this.tennql = tennql;
            this.ngaysinh = ngaysinh;
            this.sdt = sdt;
            this.diachi = diachi;
        }

        public String getManql()
        {
            return manql;
        }

        public String getTennql()
        {
            return tennql;
        }

        public String getNgaysinh()
        {
            return ngaysinh;
        }

        public String getSdt()
        {
            return sdt;
        }

        public String getDiachi()
        {
            return diachi;
        }

        public void setManql(String manql)
        {
            this.manql = manql;
        }

        public void setTennql(String tennql)
        {
            this.tennql = tennql;
        }

        public void setNgaysinh(String ngaysinh)
        {
            this.ngaysinh = ngaysinh;
        }

        public void setSdt(String sdt)
        {
            this.sdt = sdt;
        }

        public void setDiachi(String diachi)
        {
            this.diachi = diachi;
        }
    }
}
