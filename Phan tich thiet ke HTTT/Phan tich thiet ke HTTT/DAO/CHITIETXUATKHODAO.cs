using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Phan_tich_thiet_ke_HTTT.POJO;

namespace Phan_tich_thiet_ke_HTTT.DAO
{
    public class CHITIETXUATKHODAO
    {
        public static List<CHITIETXUATKHO> getDSCTXK()
        {
            List<CHITIETXUATKHO> ds = new List<CHITIETXUATKHO>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from ct_phieuxuat");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                CHITIETXUATKHO ctnk = new CHITIETXUATKHO(dr["mapx"].ToString().Trim(), dr["masp"].ToString().Trim(), int.Parse(dr["soluong"].ToString().Trim()));
                ds.Add(ctnk);
            }
            return ds;
        }

        public static List<CHITIETXUATKHO> dsCTXKTheoMaXK(List<CHITIETXUATKHO> dsCTXK, String mapx)
        {
            List<CHITIETXUATKHO> ds = new List<CHITIETXUATKHO>();
            foreach (CHITIETXUATKHO ct in dsCTXK)
                if (ct.getMapx().Equals(mapx))
                    ds.Add(ct);
            return ds;
        }

        public static void ThemCTXK(List<CHITIETXUATKHO> dsCTXK, String mapx, String masp, int soluong)
        {
            CHITIETXUATKHO ct = new CHITIETXUATKHO(mapx, masp, soluong);
            dsCTXK.Add(ct);
        }

        public static void XoaCTXK(List<CHITIETXUATKHO> dsCTXK, String mapx, String masp)
        {
            dsCTXK.RemoveAll(ct => ct.getMapx().Equals(mapx) && ct.getMasp().Equals(masp));
        }

        public static void SuaCTXK(List<CHITIETXUATKHO> dsCTXK, String mapx, String masp, int soluong)
        {
            foreach (CHITIETXUATKHO ct in dsCTXK)
                if (ct.getMapx().Equals(mapx) && ct.getMasp().Equals(masp))
                    ct.setSoluong(soluong);
        }

        public static Boolean KTMaXKMaSPTrung(List<CHITIETXUATKHO> dsCTXK, String mapx, String masp)
        {
            foreach (CHITIETXUATKHO ct in dsCTXK)
                if (ct.getMapx().Equals(mapx) && ct.getMasp().Equals(masp))
                    return true;
            return false;
        }

        public static Boolean KTTonTaiMaNK(List<CHITIETXUATKHO> dsCTXK, String mapx)
        {
            foreach (CHITIETXUATKHO ct in dsCTXK)
                if (ct.getMapx().Equals(mapx))
                    return true;
            return false;
        }

        public static Boolean KTSoLuongXuatKho(List<SANPHAM> dsSP, String masp, int soluong)
        {
            foreach (SANPHAM sp in dsSP)
                if (sp.getMasp().Equals(masp) && sp.getSoluong() < soluong)
                    return true;
            return false;
        }

        public static void CapNhatSoLuongSPKhiThemXuatKho(List<SANPHAM> dsSP, String masp, int soluong)
        {
            foreach (SANPHAM sp in dsSP)
                if (sp.getMasp().Equals(masp))
                    sp.setXoaSoluong(soluong);
        }

        public static void CapNhatSoLuongSPKhiXoaXuatKho(List<SANPHAM> dsSP, String masp, int soluong)
        {
            foreach (SANPHAM sp in dsSP)
                if (sp.getMasp().Equals(masp))
                    sp.setThemSoluong(soluong);
        }
    }
}
