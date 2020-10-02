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
    public class CHITIETPHIEUDATHANGDAO
    {
        public static List<CHITIETPHIEUDATHANG> getDSCTPDH()
        {
            List<CHITIETPHIEUDATHANG> ds = new List<CHITIETPHIEUDATHANG>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from ct_phieudathang");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                CHITIETPHIEUDATHANG ctpdh = new CHITIETPHIEUDATHANG(dr["sophieu"].ToString().Trim(), dr["masp"].ToString().Trim(), int.Parse(dr["soluong"].ToString().Trim()), Decimal.Parse(dr["giatien"].ToString().Trim()));
                ds.Add(ctpdh);
            }
            return ds;
        }

        public static List<CHITIETPHIEUDATHANG> dsCTPDHTheoMaHD(List<CHITIETPHIEUDATHANG> dsCTPDH, String sophieu)
        {
            List<CHITIETPHIEUDATHANG> ds = new List<CHITIETPHIEUDATHANG>();
            foreach (CHITIETPHIEUDATHANG ct in dsCTPDH)
                if (ct.getSophieu().Equals(sophieu))
                    ds.Add(ct);
            return ds;
        }

        public static void ThemCTPDH(List<CHITIETPHIEUDATHANG> dsCTPDH, String sophieu, String masp, int soluong, Decimal giatien)
        {
            CHITIETPHIEUDATHANG ct = new CHITIETPHIEUDATHANG(sophieu, masp, soluong, giatien);
            dsCTPDH.Add(ct);
        }

        public static void XoaCTPDH(List<CHITIETPHIEUDATHANG> dsCTPDH, String sophieu, String masp)
        {
            dsCTPDH.RemoveAll(ct => ct.getSophieu().Equals(sophieu) && ct.getMasp().Equals(masp));
        }

        public static void SuaCTPDH(List<CHITIETPHIEUDATHANG> dsCTPDH, String sophieu, String masp, int soluong, Decimal giatien)
        {
            foreach (CHITIETPHIEUDATHANG ct in dsCTPDH)
                if (ct.getSophieu().Equals(sophieu) && ct.getMasp().Equals(masp))
                {
                    ct.setSoluong(soluong);
                    ct.setGiatien(giatien);
                }
        }

        public static Boolean KTMaPDHMaSPTrung(List<CHITIETPHIEUDATHANG> dsCTPDH, String sophieu, String masp)
        {
            foreach (CHITIETPHIEUDATHANG ct in dsCTPDH)
                if (ct.getSophieu().Equals(sophieu) && ct.getMasp().Equals(masp))
                    return true;
            return false;
        }

        public static Boolean KTTonTaiDuLieu(List<CHITIETPHIEUDATHANG> dsCTPDH, String sophieu)
        {
            foreach (CHITIETPHIEUDATHANG ct in dsCTPDH)
                if (ct.getSophieu().Equals(sophieu))
                    return true;
            return false;
        }
    }
}
