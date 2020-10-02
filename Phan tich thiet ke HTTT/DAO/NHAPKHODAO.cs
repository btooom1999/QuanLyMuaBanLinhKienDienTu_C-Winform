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
    public class NHAPKHODAO
    {
        public static List<NHAPKHO> getDSNK()
        {
            List<NHAPKHO> ds = new List<NHAPKHO>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from phieunhap_kho");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                NHAPKHO nk = new NHAPKHO(dr["mapn"].ToString().Trim(), dr["mancc"].ToString().Trim(), DateTime.Parse(dr["ngaylap"].ToString().Trim()).ToString("dd/MM/yyyy"), dr["manv"].ToString().Trim(), dr["ghichu"].ToString().Trim());
                ds.Add(nk);
            }
            return ds;
        }

        public static void ThemNK(List<NHAPKHO> dsNK, String mapn, String mancc, String ngaylap, String manv, String ghichu)
        {
            NHAPKHO nk = new NHAPKHO(mapn, mancc, ngaylap, manv, ghichu);
            dsNK.Add(nk);
        }

        public static void XoaNK(List<NHAPKHO> dsNK, String mapn)
        {
            dsNK.RemoveAll(nk => nk.getMapn().Equals(mapn));
        }

        public static void SuaNK(List<NHAPKHO> dsNK, String mapn, String mancc, String ngaylap, String ghichu)
        {
            foreach(NHAPKHO nk in dsNK)
                if (nk.getMapn().Equals(mapn))
                {
                    nk.setMancc(mancc);
                    nk.setNgaylap(ngaylap);
                    nk.setGhichu(ghichu);
                }
        }

        public static String MaNKTuDong(List<NHAPKHO> dsNK)
        {
            int i = dsNK.Count + 1;
            if (i < 10)
                return "NK00" + i;
            else if (i < 100)
                return "NK0" + i;
            else
                return "NK" + i;
        }

        public static Boolean KiemTraMaPNTrung(List<NHAPKHO> dsNK, String mapn)
        {
            foreach (NHAPKHO nk in dsNK)
                if (nk.getMapn().Equals(mapn))
                    return true;
            return false;
        }

        public static String KiemTraMaNKTuDongTang(List<NHAPKHO> dsNK, String mank)
        {
            foreach (NHAPKHO nk in dsNK)
            {
                if (nk.getMapn().Equals(mank))
                {
                    try
                    {
                        int duoi = int.Parse(mank.Substring(2));
                        duoi++;
                        if (duoi < 10)
                            mank = "NK00" + duoi;
                        else if (duoi < 100)
                            mank = "NK0" + duoi;
                        else
                            mank = "NK" + duoi;
                    }
                    catch (Exception) { }
                }
            }
            return mank;
        }
    }
}
