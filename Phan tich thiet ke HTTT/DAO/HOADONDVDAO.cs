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
    public class HOADONDVDAO
    {
        public static List<HOADON> getDSHDV()
        {
            List<HOADON> ds = new List<HOADON>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from hd_dichvu");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                HOADON hd = new HOADON(dr["sohd"].ToString().Trim(), dr["tenkh"].ToString().Trim(), dr["sdt"].ToString().Trim(), dr["ngaylap"].ToString().Trim(), dr["manv"].ToString().Trim());
                ds.Add(hd);
            }
            return ds;
        }

        public static void ThemHDDV(List<HOADON> dsHDDV, String sohd, String tenkh, String sdt, String ngaylap, String manv)
        {
            HOADON hd = new HOADON(sohd, tenkh, sdt, ngaylap, manv);
            dsHDDV.Add(hd);
        }

        public static String MaHDDVTuDong(List<HOADON> dsHDDV)
        {
            int i = dsHDDV.Count + 1;
            if (i < 10)
                return "HDDV00" + i;
            else if (i < 100)
                return "HDDV0" + i;
            else
                return "HDDV" + i;
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
