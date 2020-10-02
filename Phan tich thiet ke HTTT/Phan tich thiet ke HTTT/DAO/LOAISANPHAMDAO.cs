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
    public class LOAISANPHAMDAO
    {
        public static List<LOAISANPHAM> getDSLOAISANPHAM()
        {
            List<LOAISANPHAM> ds = new List<LOAISANPHAM>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from loaisp");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                LOAISANPHAM lsp = new LOAISANPHAM(dr["MALOAI"].ToString().Trim(), dr["TENLOAI"].ToString().Trim());
                ds.Add(lsp);
            }
            return ds;
        }

        public static void ThemLoaiSP(List<LOAISANPHAM> dsLSP, String maloai, String tenloai)
        {
            LOAISANPHAM lsp = new LOAISANPHAM(maloai, tenloai);
            dsLSP.Add(lsp);
        }

        public static void SuaLoaiSP(List<LOAISANPHAM> dsLSP, String maloai, String tenloai)
        {
            foreach (LOAISANPHAM lsp in dsLSP)
                if (lsp.getMaloai().Equals(maloai))
                    lsp.setTenloai(tenloai);
        }

        public static void XoaLoaiSP(List<LOAISANPHAM> dsLSP, String maloai)
        {
            dsLSP.RemoveAll(lsp => lsp.getMaloai().Equals(maloai));
        }

        public static String TenLoaiSP(List<LOAISANPHAM> dsLSP, String maloai)
        {
            foreach (LOAISANPHAM lsp in dsLSP)
                if (lsp.getMaloai().Equals(maloai))
                    return lsp.getTenloai();
            return "Khong co";
        }

        public static String MaLoaiSPTuDong(List<LOAISANPHAM> dsLSP)
        {
            int i = dsLSP.Count + 1;
            if (i < 10)
                return "LSP00" + i;
            else if (i < 100)
                return "LSP0" + i;
            else
                return "LSP" + i;
        }

        public static Boolean KiemTraTrungMaLoaiSP(List<LOAISANPHAM> dsLSP, String malsp)
        {
            foreach (LOAISANPHAM lsp in dsLSP)
                if (lsp.getMaloai().Equals(malsp))
                    return true;
            return false;
        }

        public static String MaLoaiSPTheoTenLSP(List<LOAISANPHAM> dsLSP, String tenlsp)
        {
            foreach (LOAISANPHAM lsp in dsLSP)
                if (lsp.getTenloai().Equals(tenlsp))
                    return lsp.getMaloai();
            return "Không có";
        }

        public static String KiemTraMaLSPTuDongTang(List<LOAISANPHAM> dsLSP, String malsp)
        {
            foreach (LOAISANPHAM lsp in dsLSP)
            {
                if (lsp.getMaloai().Equals(malsp))
                {
                    try
                    {
                        int duoi = int.Parse(malsp.Substring(3));
                        duoi++;
                        if (duoi < 10)
                            malsp = "LSP00" + duoi;
                        else if (duoi < 100)
                            malsp = "LSP0" + duoi;
                        else
                            malsp = "LSP" + duoi;
                    }
                    catch (Exception) { }
                }
            }
            return malsp;
        }
    }
}
