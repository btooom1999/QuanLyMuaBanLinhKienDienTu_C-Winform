using Phan_tich_thiet_ke_HTTT.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Phan_tich_thiet_ke_HTTT.DAO
{
    public class PHIEUDATHANGDAO
    {
        public static List<PHIEUDATHANG> getDSPDT()
        {
            List<PHIEUDATHANG> ds = new List<PHIEUDATHANG>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from phieudathang");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                PHIEUDATHANG pdh = new PHIEUDATHANG(dr["sophieu"].ToString().Trim(), DateTime.Parse(dr["ngaylap"].ToString().Trim()).ToString("dd/MM/yyyy"), dr["manql"].ToString().Trim());
                ds.Add(pdh);
            }
            return ds;
        }

        public static void ThemPDH(List<PHIEUDATHANG> dsPDH, String sophieu, String ngaylap, String manql)
        {
            PHIEUDATHANG pdh = new PHIEUDATHANG(sophieu, ngaylap, manql);
            dsPDH.Add(pdh);
        }

        public static void XoaPDH(List<PHIEUDATHANG> dsPDH, String sophieu)
        {
            dsPDH.RemoveAll(pdh => pdh.getSophieu().Equals(sophieu));
        }

        public static String MaPDHTuDong(List<PHIEUDATHANG> dsPDH)
        {
            int i = dsPDH.Count + 1;
            if (i < 10)
                return "PDH00" + i;
            else if (i < 100)
                return "PDH0" + i;
            else
                return "PDH" + i;
        }

        public static String KiemTraMaPDHTuDongTang(List<PHIEUDATHANG> dsPDH, String sophieu)
        {
            foreach (PHIEUDATHANG pdh in dsPDH)
            {
                if (pdh.getSophieu().Equals(sophieu))
                {
                    try
                    {
                        int duoi = int.Parse(sophieu.Substring(3));
                        duoi++;
                        if (duoi < 10)
                            sophieu = "PDH00" + duoi;
                        else if (duoi < 100)
                            sophieu = "PDH0" + duoi;
                        else
                            sophieu = "PDH" + duoi;
                    }
                    catch (Exception) { }
                }
            }
            return sophieu;
        }
    }
}
