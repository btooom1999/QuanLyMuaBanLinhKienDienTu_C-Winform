using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class NHANVIEN
    {
        private String manv, tennv, ngaysinh, gioitinh, diachi, sdt, ngayvaolam, chucvu, taikhoan, matkhau, manql;

        public NHANVIEN() { }

        public NHANVIEN(String manv, String tennv, String ngaysinh, String gioitinh, String diachi, String sdt, String ngayvaolam, String chucvu, String taikhoan, String matkhau, String manql)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.sdt = sdt;
            this.ngayvaolam = ngayvaolam;
            this.chucvu = chucvu;
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.manql = manql;
        }

        public String getManv()
        {
            return manv;
        }

        public String getTennv()
        {
            return tennv;
        }

        public String getNgaysinh()
        {
            return ngaysinh;
        }

        public String getGioitinh()
        {
            return gioitinh;
        }

        public String getDiachi()
        {
            return diachi;
        }

        public String getSdt()
        {
            return sdt;
        }

        public String getNgayvaolam()
        {
            return ngayvaolam;
        }

        public String getChucvu()
        {
            return chucvu;
        }

        public String getTaikhoan()
        {
            return taikhoan;
        }

        public String getMatkhau()
        {
            return matkhau;
        }

        public String getManql()
        {
            return manql;
        }

        public void setManv(String manv)
        {
            this.manv = manv;
        }

        public void setTennv(String tennv)
        {
            this.tennv = tennv;
        }

        public void setNgaysinh(String ngaysinh)
        {
            this.ngaysinh = ngaysinh;
        }

        public void setGioitinh(String gioitinh)
        {
            this.gioitinh = gioitinh;
        }

        public void setDiachi(String diachi)
        {
            this.diachi = diachi;
        }

        public void setSdt(String sdt)
        {
            this.sdt = sdt;
        }

        public void setNgayvaolam(String ngayvaolam)
        {
            this.ngayvaolam = ngayvaolam;
        }

        public void setChucvu(String chucvu)
        {
            this.chucvu = chucvu;
        }

        public void setTaikhoan(String taikhoan)
        {
            this.taikhoan = taikhoan;
        }

        public void setMatkhau(String matkhau)
        {
            this.matkhau = matkhau;
        }

        public void setManql(String manql)
        {
            this.manql = manql;
        }
    }
}
