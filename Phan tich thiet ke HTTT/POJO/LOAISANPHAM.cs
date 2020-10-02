using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_tich_thiet_ke_HTTT.POJO
{
    public class LOAISANPHAM
    {
        private String maloai, tenloai;

        public LOAISANPHAM() { }

        public LOAISANPHAM(String maloai, String tenloai)
        {
            this.maloai = maloai;
            this.tenloai = tenloai;
        }

        public String getMaloai()
        {
            return this.maloai;
        }

        public String getTenloai()
        {
            return this.tenloai;
        }

        public void setMaloai(String maloai)
        {
            this.maloai = maloai;
        }

        public void setTenloai(String tenloai)
        {
            this.tenloai = tenloai;
        }

        public void xuat()
        {
            Console.WriteLine("Ma loai san pham: " + maloai + " Ten loai san pham: " + tenloai);
        }
    }
}
