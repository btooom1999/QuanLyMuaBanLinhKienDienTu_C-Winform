using Phan_tich_thiet_ke_HTTT.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Phan_tich_thiet_ke_HTTT.DAO
{
    public class HOADONDAO
    {
        public static List<HOADON> getDSHD()
        {
            List<HOADON> ds = new List<HOADON>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from hoadon");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                HOADON hd = new HOADON(dr["mahd"].ToString().Trim(), dr["tenkh"].ToString().Trim(), dr["sdt"].ToString().Trim(), dr["ngaylap"].ToString().Trim(), dr["manv"].ToString().Trim());
                ds.Add(hd);
            }
            return ds;
        }

        public static void ThemHD(List<HOADON> dsHD, string mahd, string tenkh, string sdt, string ngaylap, string manv)
        {
            HOADON hd = new HOADON(mahd, tenkh, sdt, ngaylap, manv);
            dsHD.Add(hd);
        }

        public static String MaHDTuDong(List<HOADON> dsHD)
        {
            int i = dsHD.Count + 1;
            if (i < 10)
                return "HD00" + i;
            else if (i < 100)
                return "HD0" + i;
            else
                return "HD" + i;
        }

        public static Decimal TongTien(List<CHITIETHOADON> dsCTHD, String mahd, Decimal gia)
        {
            Decimal tong = 0;
            foreach (CHITIETHOADON cthd in dsCTHD)
                if (cthd.getMahd().Equals(mahd))
                    tong += cthd.thanhtien(gia);
            return tong;
        }

        public static String TenKhachHang(List<HOADON> dsHD, String mahd)
        {
            foreach (HOADON hd in dsHD)
                if (hd.getMahd().Equals(mahd))
                    return hd.getTenkh();
            return "Khách lẻ";
        }
    }
}
