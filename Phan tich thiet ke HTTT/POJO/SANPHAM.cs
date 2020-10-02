using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class SANPHAM
    {
        private String masp, tensp, maloai;
        private Decimal gia;
        private int soluong;

        public SANPHAM() { }

        public SANPHAM(String masp, String tensp, Decimal gia, int soluong, String maloai)
        {
            this.masp = masp;
            this.tensp = tensp;
            this.gia = gia;
            this.soluong = soluong;
            this.maloai = maloai;
        }

        public String getMasp()
        {
            return masp;
        }

        public String getTensp()
        {
            return tensp;
        }

        public Decimal getGia()
        {
            return gia;
        }

        public int getSoluong()
        {
            return soluong;
        }

        public String getMaloai()
        {
            return maloai;
        }

        public void setMasp(String masp)
        {
            this.masp = masp;
        }

        public void setTensp(String tensp)
        {
            this.tensp = tensp;
        }

        public void setGia(Decimal gia)
        {
            this.gia = gia;
        }

        public void setThemSoluong(int soluong)
        {
            this.soluong += soluong;
        }

        public void setXoaSoluong(int soluong)
        {
            this.soluong -= soluong;
        }

        public void setMaloai(String maloai)
        {
            this.maloai = maloai;
        }
    }
}
