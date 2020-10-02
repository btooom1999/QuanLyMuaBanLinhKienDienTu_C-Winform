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
    public class DICHVUDAO
    {
        public static List<DICHVU> getDSDV()
        {
            List<DICHVU> ds = new List<DICHVU>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from dichvu");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                DICHVU dv = new DICHVU(dr["madv"].ToString().Trim(), dr["tendv"].ToString().Trim(), Decimal.Parse(dr["dongia"].ToString().Trim()));
                ds.Add(dv);
            }
            return ds;
        }

        public static Decimal GiaMaDV(List<DICHVU> dsDV, String madv)
        {
            foreach (DICHVU dv in dsDV)
                if (dv.getMadv().Equals(madv))
                    return dv.getGia();
            return 0;
        }

        public static String TenDV(List<DICHVU> dsDV, String madv)
        {
            foreach (DICHVU dv in dsDV)
                if (dv.getMadv().Equals(madv))
                    return dv.getTendv();
            return "Không có";
        }

        public static void ThemDV(List<DICHVU> dsDV, String madv, String tendv, Decimal gia)
        {
            DICHVU dv = new DICHVU(madv, tendv, gia);
            dsDV.Add(dv);
        }

        public static void SuaDV(List<DICHVU> dsDV, String madv, String tendv, Decimal gia)
        {
            foreach(DICHVU dv in dsDV)
                if (dv.getMadv().Equals(madv))
                {
                    dv.setGia(gia);
                    dv.setTendv(tendv);
                }
        }

        public static void XoaDV(List<DICHVU> dsDV, String madv)
        {
            dsDV.RemoveAll(dv => dv.getMadv().Equals(madv));
        }

        public static String MaDVTuDong(List<DICHVU> dsDV)
        {
            int i = dsDV.Count + 1;
            if (i < 10)
                return "DV00" + i;
            else if (i < 100)
                return "DV0" + i;
            else
                return "DV" + i;
        }

        public static Boolean KiemTraTrungMaDV(List<DICHVU> dsDV, String madv)
        {
            foreach (DICHVU dv in dsDV)
                if (dv.getMadv().Equals(madv))
                    return true;
            return false;
        }

        public static String MaDVTheoTenDV(List<DICHVU> dsDV, String tendv)
        {
            foreach (DICHVU dv in dsDV)
                if (dv.getTendv().Equals(tendv))
                    return dv.getMadv();
            return "Không có";
        }

        public static Boolean KiemTraTonTaiMaDV(List<CHITIETHOADON> dsCTHDDV, String madv)
        {
            foreach (CHITIETHOADON ct in dsCTHDDV)
                if (ct.getMasp().Equals(madv))
                    return true;
            return false;
        }

        public static String KiemTraMaDVTuDongTang(List<DICHVU> dsDV, String madv)
        {
            foreach (DICHVU dv in dsDV)
            {
                if (dv.getMadv().Equals(madv))
                {
                    try
                    {
                        int duoi = int.Parse(madv.Substring(2));
                        duoi++;
                        if (duoi < 10)
                            madv = "DV00" + duoi;
                        else if (duoi < 100)
                            madv = "DV0" + duoi;
                        else
                            madv = "DV" + duoi;
                    }
                    catch (Exception) { }
                }
            }
            return madv;
        }

       
    }
}
