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
    public class XUATKHODAO
    {
        public static List<XUATKHO> getDSXK()
        {
            List<XUATKHO> ds = new List<XUATKHO>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from phieuxuat_kho");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                XUATKHO nk = new XUATKHO(dr["mapx"].ToString().Trim(), DateTime.Parse(dr["ngaylap"].ToString().Trim()).ToString("dd/MM/yyyy"), dr["manv"].ToString().Trim(), dr["ghichu"].ToString().Trim());
                ds.Add(nk);
            }
            return ds;
        }

        public static void ThemXK(List<XUATKHO> dsXK, String mapx, String ngaylap, String manv, String ghichu)
        {
            XUATKHO xk = new XUATKHO(mapx, ngaylap, manv, ghichu);
            dsXK.Add(xk);
        }

        public static void XoaXK(List<XUATKHO> dsXK, String mapx)
        {
            dsXK.RemoveAll(xk => xk.getMapx().Equals(mapx));
        }

        public static void SuaXK(List<XUATKHO> dsXK, String mapx, String ngaylap, String ghichu)
        {
            foreach(XUATKHO xk in dsXK)
                if (xk.getMapx().Equals(mapx))
                {
                    xk.setNgaylap(ngaylap);
                    xk.setGhichu(ghichu);
                }
        }

        public static String MaXKTuDong(List<XUATKHO> dsXK)
        {
            int i = dsXK.Count + 1;
            if (i < 10)
                return "XK00" + i;
            else if (i < 100)
                return "XK0" + i;
            else
                return "XK" + i;
        }

        public static Boolean KiemTraMaXKTrung(List<XUATKHO> dsXK, String mapx)
        {
            foreach (XUATKHO xk in dsXK)
                if (xk.getMapx().Equals(mapx))
                    return true;
            return false;
        }

        public static String KiemTraMaXKTuDongTang(List<XUATKHO> dsXK, String maxk)
        {
            foreach (XUATKHO xk in dsXK)
            {
                if (xk.getMapx().Equals(maxk))
                {
                    try
                    {
                        int duoi = int.Parse(maxk.Substring(2));
                        duoi++;
                        if (duoi < 10)
                            maxk = "XK00" + duoi;
                        else if (duoi < 100)
                            maxk = "XK0" + duoi;
                        else
                            maxk = "XK" + duoi;
                    }
                    catch (Exception) { }
                }
            }
            return maxk;
        }
    }
}
