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
    public class CHITIETNHAPKHODAO
    {
        public static List<CHITIETNHAPKHO> getDSCTNK()
        {
            List<CHITIETNHAPKHO> ds = new List<CHITIETNHAPKHO>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from ct_phieunhap");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                CHITIETNHAPKHO ctnk = new CHITIETNHAPKHO(dr["mapn"].ToString().Trim(), dr["masp"].ToString().Trim(), int.Parse(dr["soluong"].ToString().Trim()));
                ds.Add(ctnk);
            }
            return ds;
        }

        public static List<CHITIETNHAPKHO> dsCTNKTheoMaNK(List<CHITIETNHAPKHO> dsCTNK, String mapn)
        {
            List<CHITIETNHAPKHO> ds = new List<CHITIETNHAPKHO>();
            foreach (CHITIETNHAPKHO ct in dsCTNK)
                if (ct.getMapn().Equals(mapn))
                    ds.Add(ct);
            return ds;
        }

        public static void ThemCTNK(List<CHITIETNHAPKHO> dsCTNK, String mapn, String masp, int soluong)
        {
            CHITIETNHAPKHO ct = new CHITIETNHAPKHO(mapn, masp, soluong);
            dsCTNK.Add(ct);
        }

        public static void XoaCTNK(List<CHITIETNHAPKHO> dsCTNK, String mapn, String masp)
        {
            dsCTNK.RemoveAll(ct => ct.getMapn().Equals(mapn) && ct.getMasp().Equals(masp));
        }

        public static void SuaCTNK(List<CHITIETNHAPKHO> dsCTNK, String mapn, String masp, int soluong)
        {
            foreach (CHITIETNHAPKHO ct in dsCTNK)
                if (ct.getMapn().Equals(mapn) && ct.getMasp().Equals(masp))
                    ct.setSoluong(soluong);
        }

        public static Boolean KTMaNKMaSPTrung(List<CHITIETNHAPKHO> dsCTNK, String mapn, String masp)
        {
            foreach (CHITIETNHAPKHO ct in dsCTNK)
                if (ct.getMapn().Equals(mapn) && ct.getMasp().Equals(masp))
                    return true;
            return false;
        }

        public static Boolean KTTonTaiMaNK(List<CHITIETNHAPKHO> dsCTNK, String mapn)
        {
            foreach (CHITIETNHAPKHO ct in dsCTNK)
                if (ct.getMapn().Equals(mapn))
                    return true;
            return false;
        }

        public static void CapNhatSoLuongSPKhiThemNhapKho(List<SANPHAM> dsSP, String masp, int soluong)
        {
            foreach (SANPHAM sp in dsSP)
                if (sp.getMasp().Equals(masp))
                    sp.setThemSoluong(soluong);
        }

        public static void CapNhatSoLuongSPKhiXoaNhapKho(List<SANPHAM> dsSP, String masp, int soluong)
        {
            foreach (SANPHAM sp in dsSP)
                if (sp.getMasp().Equals(masp))
                    sp.setXoaSoluong(soluong);
        }
    }
}
