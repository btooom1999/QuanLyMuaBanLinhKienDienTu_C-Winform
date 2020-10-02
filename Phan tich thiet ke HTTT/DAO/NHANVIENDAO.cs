using Phan_tich_thiet_ke_HTTT.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace Phan_tich_thiet_ke_HTTT.DAO
{
    public class NHANVIENDAO
    {
        public static List<NHANVIEN> getDSNV()
        {
            List<NHANVIEN> ds = new List<NHANVIEN>();
            ConnectionDB cn = new ConnectionDB();
            SqlDataAdapter da = cn.getDa("select * from nhanvien");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.close();
            foreach (DataRow dr in dt.Rows)
            {
                NHANVIEN nv = new NHANVIEN(dr["manv"].ToString().Trim(), dr["tennv"].ToString().Trim(), DateTime.Parse(dr["ngaysinh"].ToString().Trim()).ToString("dd/MM/yyyy"), dr["gioitinh"].ToString().Trim(), dr["diachi"].ToString().Trim(), dr["sdt"].ToString().Trim(), Convert.ToDateTime(dr["ngayvaolam"].ToString().Trim()).ToString("dd/MM/yyyy"), dr["chucvu"].ToString().Trim(), dr["taikhoan"].ToString().Trim(), dr["matkhau"].ToString().Trim(), dr["manql"].ToString().Trim());
                ds.Add(nv);
            }
            return ds;
        }

        public static void ThemNV(List<NHANVIEN> dsNV, String manv, String tennv, String ngaysinh, String gioitinh, String diachi, String sdt, String ngayvaolam, String chucvu, String taikhoan, String matkhau, String manql)
        {
            NHANVIEN nv = new NHANVIEN(manv, tennv, ngaysinh, gioitinh, diachi, sdt, ngayvaolam, chucvu, taikhoan, matkhau, manql);
            dsNV.Add(nv);
        }

        public static void SuaNV(List<NHANVIEN> dsNV, String manv, String tennv, String ngaysinh, String gioitinh, String diachi, String sdt, String ngayvaolam, String chucvu, String taikhoan, String matkhau, String manql)
        {
            foreach(NHANVIEN nv in dsNV)
                if(nv.getManv().Equals(manv))
                {
                    nv.setTennv(tennv);
                    nv.setNgaysinh(ngaysinh);
                    nv.setGioitinh(gioitinh);
                    nv.setDiachi(diachi);
                    nv.setSdt(sdt);
                    nv.setNgayvaolam(ngayvaolam);
                    nv.setChucvu(chucvu);
                    nv.setTaikhoan(taikhoan);
                    nv.setMatkhau(matkhau);
                    nv.setManql(manql);
                }
        }

        public static void XoaNV(List<NHANVIEN> dsNV, String manv)
        {
            dsNV.RemoveAll(nv => nv.getManv().Equals(manv));
        }

        public static String MaNV(List<NHANVIEN> dsNV, String tennv)
        {
            foreach (NHANVIEN nv in dsNV)
                if (nv.getTennv().Equals(tennv))
                    return nv.getManv();
            return "Không có";
        }

        public static String TenNV(List<NHANVIEN> dsNV, String manv)
        {
            foreach (NHANVIEN nv in dsNV)
                if (nv.getManv().Equals(manv))
                    return nv.getTennv();
            return "Không có";
        }

        public static String MaNVTuDong(List<NHANVIEN> dsNV)
        {
            int i = dsNV.Count + 1;
            if (i < 10)
                return "NV00" + i;
            else if (i < 100)
                return "NV0" + i;
            else
                return "NV" + i;
        }

        public static Boolean KiemTraTrungMaNV(List<NHANVIEN> dsNV, String manv)
        {
            foreach (NHANVIEN nv in dsNV)
                if (nv.getManv().Equals(manv))
                    return true;
            return false;
        }

        public static Boolean KiemTraDangNhap(List<NHANVIEN> dsNV, String taikhoan, String matkhau, String chucvu)
        {
            foreach (NHANVIEN nv in dsNV)
                if (nv.getTaikhoan().Equals(taikhoan) && nv.getMatkhau().Equals(matkhau) && nv.getChucvu().Equals(chucvu))
                    return true;
            return false;
        }

        public static Boolean KiemTraTaiKhoan(List<NHANVIEN> dsNV, String taikhoan)
        {
            foreach (NHANVIEN nv in dsNV)
                if (nv.getTaikhoan().Equals(taikhoan))
                    return true;
            return false;
        }

        public static Boolean KiemTraTaiKhoanKhiThayDoi(List<NHANVIEN> dsNV, String manv, String taikhoan)
        {
            foreach (NHANVIEN nv in dsNV)
                if (!nv.getManv().Equals(manv) && nv.getTaikhoan().Equals(taikhoan))
                    return true;
            return false;
        }

        public static String MaNVTheoTaiKhoanDN(List<NHANVIEN> dsNV, String taikhoan)
        {
            foreach (NHANVIEN nv in dsNV)
                if (nv.getTaikhoan().Equals(taikhoan))
                    return nv.getManv();
            return "Không có";
        }

        public static String KiemTraMaNVTuDongTang(List<NHANVIEN> dsNV, String manv)
        {
            foreach (NHANVIEN nv in dsNV)
            {
                if (nv.getManv().Equals(manv))
                {
                    try
                    {
                        int duoi = int.Parse(manv.Substring(2));
                        duoi++;
                        if (duoi < 10)
                            manv = "NV00" + duoi;
                        else if (duoi < 100)
                            manv = "NV0" + duoi;
                        else
                            manv = "NV" + duoi;
                    }
                    catch (Exception) { }
                }
            }
            return manv;
        }

        public static Boolean KiemTraMaNQL(List<NHANVIEN> dsNV, String manql)
        {
            foreach (NHANVIEN nv in dsNV)
                if (nv.getManv().Equals(manql))
                    return true;
            return false;
        }
    }
}
