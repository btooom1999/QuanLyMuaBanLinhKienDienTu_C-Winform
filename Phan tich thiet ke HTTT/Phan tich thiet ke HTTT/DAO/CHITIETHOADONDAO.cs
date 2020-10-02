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
    public class CHITIETHOADONDAO
    {
        public static List<CHITIETHOADON> getDSCTHD()
        {
            List<CHITIETHOADON> ds = new List<CHITIETHOADON>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from ct_hoadon");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                CHITIETHOADON cthd = new CHITIETHOADON(dr["mahd"].ToString().Trim(), dr["masp"].ToString().Trim(), int.Parse(dr["soluong"].ToString().Trim()));
                ds.Add(cthd);
            }
            return ds;
        }

        public static List<CHITIETHOADON> dsCTHDTheoMaHD(List<CHITIETHOADON> dsCTHD, String mahd)
        {
            List<CHITIETHOADON> ds = new List<CHITIETHOADON>();
            foreach (CHITIETHOADON cthd in dsCTHD)
                if (cthd.getMahd().Equals(mahd))
                    ds.Add(cthd);
            return ds;
        }

        public static void ThemCTHD(List<CHITIETHOADON> dsCTHD, String mahd, String masp, int soluong)
        {
            CHITIETHOADON cthd = new CHITIETHOADON(mahd, masp, soluong);
            dsCTHD.Add(cthd);
        }

        public static void SuaCTHD(List<CHITIETHOADON> dsCTHD, String mahd, String masp, int soluong)
        {
            foreach (CHITIETHOADON cthd in dsCTHD)
                if (cthd.getMahd().Equals(mahd) && cthd.getMasp().Equals(masp))
                    cthd.setSoluong(soluong);
        }

        public static void XoaCTHD(List<CHITIETHOADON> dsCTHD, String mahd, String masp)
        {
            dsCTHD.RemoveAll(cthd => cthd.getMahd().Equals(mahd) && cthd.getMasp().Equals(masp));
        }

        public static Boolean KiemTraMaHDMaSPTrung(List<CHITIETHOADON> dsCTHD, String mahd, String masp)
        {
            foreach (CHITIETHOADON cthd in dsCTHD)
                if (cthd.getMahd().Equals(mahd) && cthd.getMasp().Equals(masp))
                    return true;
            return false;
        }
    }
}
