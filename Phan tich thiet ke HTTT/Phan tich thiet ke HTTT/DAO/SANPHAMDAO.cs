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
    public class SANPHAMDAO
    {
        public static List<SANPHAM> getDSSANPHAM()
        {
            List<SANPHAM> ds = new List<SANPHAM>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from sanpham");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                SANPHAM sp = new SANPHAM(dr["masp"].ToString().Trim(), dr["tensp"].ToString().Trim(), Decimal.Parse(dr["gia"].ToString().Trim()), int.Parse(dr["soluong"].ToString().Trim()), dr["maloai"].ToString().Trim());
                ds.Add(sp);
            }
            return ds;
        }

        public static void ThemSP(List<SANPHAM> dsSP, String masp, String tensp, Decimal gia, int soluong, String maloai)
        {
            SANPHAM sp = new SANPHAM(masp, tensp, gia, soluong, maloai);
            dsSP.Add(sp);
        }

        public static void SuaSP(List<SANPHAM> dsSP, SANPHAM spmuondoi)
        {
            foreach(SANPHAM sp in dsSP)
            {
               if(sp.getMasp().Equals(spmuondoi.getMasp()))
               {
                   sp.setTensp(spmuondoi.getTensp());
                   sp.setGia(spmuondoi.getGia());
                   sp.setMaloai(spmuondoi.getMaloai());
               }
            }
        }

        public static void XoaSP(List<SANPHAM> dsSP, String masp)
        {
            dsSP.RemoveAll(sp => sp.getMasp().Equals(masp));
        }

        public static String TenSP(List<SANPHAM> dsSP, String masp)
        {
            foreach (SANPHAM sp in dsSP)
                if (sp.getMasp().Equals(masp))
                    return sp.getTensp();
            return "Không có";
        }

        public static Decimal Gia(List<SANPHAM> dsSP, String tensp)
        {
            foreach (SANPHAM sp in dsSP)
                if (sp.getTensp().Equals(tensp))
                    return sp.getGia();
            return 0;
        }

        public static Decimal GiaMaSP(List<SANPHAM> dsSP, String masp)
        {
            foreach (SANPHAM sp in dsSP)
                if (sp.getMasp().Equals(masp))
                    return sp.getGia();
            return 0;
        }

        public static String MaSPTuDong(List<SANPHAM> dsSP)
        {
            int i = dsSP.Count + 1;
            if (i < 10)
                return "SP00" + i;
            else if (i < 100)
                return "SP0" + i;
            else
                return "SP" + i;
        }

        public static Boolean KiemTraTrungMaSP(List<SANPHAM> dsSP, String masp)
        {
            foreach (SANPHAM sp in dsSP)
                if (sp.getMasp().Equals(masp))
                    return true;
            return false;
        }

        public static String MaSPTheoTenSP(List<SANPHAM> dsSP, String tensp)
        {
            foreach (SANPHAM sp in dsSP)
                if (sp.getTensp().Equals(tensp))
                    return sp.getMasp();
            return "Không có";
        }

        public static Boolean KiemTraTonTaiMaSP(List<CHITIETHOADON> dsCTHD, String masp)
        {
            foreach (CHITIETHOADON ct in dsCTHD)
                if (ct.getMasp().Equals(masp))
                    return true;
            return false;
        }

        public static String KiemTraMaSPTuDongTang(List<SANPHAM> dsSP, String masp)
        {
            foreach (SANPHAM sp in dsSP)
            {
                if (sp.getMasp().Equals(masp))
                {
                    try
                    {
                        int duoi = int.Parse(masp.Substring(2));
                        duoi++;
                        if (duoi < 10)
                            masp = "SP00" + duoi;
                        else if (duoi < 100)
                            masp = "SP0" + duoi;
                        else
                            masp = "SP" + duoi;
                    }
                    catch (Exception) { }
                }
            }
            return masp;
        }
    }
}
