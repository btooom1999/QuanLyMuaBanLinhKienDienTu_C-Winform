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
    public class NHACUNGCAPDAO
    {
        public static List<NHACUNGCAP> getDSNCC()
        {
            List<NHACUNGCAP> ds = new List<NHACUNGCAP>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from nhacc");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                NHACUNGCAP ncc = new NHACUNGCAP(dr["mancc"].ToString().Trim(), dr["tenncc"].ToString().Trim(), dr["diachi"].ToString().Trim(), dr["sdt"].ToString().Trim());
                ds.Add(ncc);
            }
            return ds;
        }

        public static void ThemNCC(List<NHACUNGCAP> dsNCC, String mancc, String tenncc, String diachi, String sdt)
        {
            NHACUNGCAP ncc = new NHACUNGCAP(mancc, tenncc, diachi, sdt);
            dsNCC.Add(ncc);
        }

        public static void SuaNCC(List<NHACUNGCAP> dsNCC, String mancc, String tenncc, String diachi, String sdt)
        { 
            foreach(NHACUNGCAP ncc in dsNCC)
                if (ncc.getMancc().Equals(mancc))
                {
                    ncc.setTenncc(tenncc);
                    ncc.setDiachi(diachi);
                    ncc.setSdt(sdt);
                }
        }

        public static void XoaNCC(List<NHACUNGCAP> dsNCC, String mancc)
        {
            dsNCC.RemoveAll(ncc => ncc.getMancc().Equals(mancc));
        }

        public static String TenNCC(List<NHACUNGCAP> dsNCC, String mancc)
        {
            foreach (NHACUNGCAP ncc in dsNCC)
                if (ncc.getMancc().Equals(mancc))
                    return ncc.getTennc();
            return "Không có";
        }

        public static String MaNCCTuDong(List<NHACUNGCAP> dsNCC)
        {
            int i = dsNCC.Count + 1;
            if (i < 10)
                return "NCC00" + i;
            else if (i < 100)
                return "NCC0" + i;
            else
                return "NCC" + i;
        }

        public static Boolean KiemTraTrungMaNCC(List<NHACUNGCAP> dsNCC, String mancc)
        {
            foreach (NHACUNGCAP ncc in dsNCC)
                if (ncc.getMancc().Equals(mancc))
                    return true;
            return false;
        }

        public static String MaNCCTheoTenNCC(List<NHACUNGCAP> dsNCC, String tenncc)
        {
            foreach (NHACUNGCAP ncc in dsNCC)
            {
                if (ncc.getTennc().Equals(tenncc))
                    return ncc.getMancc();
            }
            return "Không có";
        }

        public static Boolean KiemTraTonTaiMaNCC(List<NHAPKHO> dsCTNK, String mancc)
        {
            foreach (NHAPKHO ct in dsCTNK)
                if (ct.getMancc().Equals(mancc))
                    return true;
            return false;
        }

        public static String KiemTraMaNCCTuDongTang(List<NHACUNGCAP> dsNCC, String mancc)
        {
            foreach (NHACUNGCAP ncc in dsNCC)
            {
                if (ncc.getMancc().Equals(mancc))
                {
                    try
                    {
                        int duoi = int.Parse(mancc.Substring(3));
                        duoi++;
                        if (duoi < 10)
                            mancc = "NCC00" + duoi;
                        else if (duoi < 100)
                            mancc = "NCC0" + duoi;
                        else
                            mancc = "NCC" + duoi;
                    }
                    catch (Exception) { }
                }
            }
            return mancc;
        }
    }
}
