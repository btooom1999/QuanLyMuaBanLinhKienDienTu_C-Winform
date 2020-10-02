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
    public class CHITIETHOADONDVDAO
    {
        public static List<CHITIETHOADON> getDSCTHDDV()
        {
            List<CHITIETHOADON> ds = new List<CHITIETHOADON>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from ct_hd_dichvu");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                CHITIETHOADON cthd = new CHITIETHOADON(dr["sohd"].ToString().Trim(), dr["madv"].ToString().Trim(), int.Parse(dr["soluongdv"].ToString().Trim()));
                ds.Add(cthd);
            }
            return ds;
        }

        public static List<CHITIETHOADON> dsCTHDDVTheoMaHD(List<CHITIETHOADON> dsCTHDDV, String mahd)
        {
            List<CHITIETHOADON> ds = new List<CHITIETHOADON>();
            foreach (CHITIETHOADON cthd in dsCTHDDV)
                if (cthd.getMahd().Equals(mahd))
                    ds.Add(cthd);
            return ds;
        }

        public static void ThemCTHDDV(List<CHITIETHOADON> dsCTHDDV, String sohd, String madv, int soluongdv)
        {
            CHITIETHOADON ct = new CHITIETHOADON(sohd, madv, soluongdv);
            dsCTHDDV.Add(ct);
        }

        public static void XoaCTHDDV(List<CHITIETHOADON> dsCTHDDV, String sohd, String madv)
        {
            dsCTHDDV.RemoveAll(ct => ct.getMahd().Equals(sohd) && ct.getMasp().Equals(madv));
        }

        public static void SuaCTHDDV(List<CHITIETHOADON> dsCTHDDV, String sohd, String madv, int soluongdv)
        {
            foreach (CHITIETHOADON ct in dsCTHDDV)
                if (ct.getMahd().Equals(sohd) && ct.getMasp().Equals(madv))
                    ct.setSoluong(soluongdv);
        }

        public static Boolean KTMaHDVMaSPTrung(List<CHITIETHOADON> dsCTHDDV, String sohd, String madv)
        {
            foreach (CHITIETHOADON ct in dsCTHDDV)
                if (ct.getMahd().Equals(sohd) && ct.getMasp().Equals(madv))
                    return true;
            return false;
        }
    }
}
