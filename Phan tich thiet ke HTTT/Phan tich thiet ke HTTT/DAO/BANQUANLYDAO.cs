using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Phan_tich_thiet_ke_HTTT.POJO;

namespace Phan_tich_thiet_ke_HTTT.DAO
{
    public class BANQUANLYDAO
    {
        //public static List<BANQUANLY> getDSBQL()
        //{
        //    List<BANQUANLY> ds = new List<BANQUANLY>();
        //    ConnectionDB cn = new ConnectionDB();
        //    SqlDataAdapter da = cn.getDa("select * from banql");
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    cn.close();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        BANQUANLY bql = new BANQUANLY(dr["manql"].ToString().Trim(), dr["tennql"].ToString().Trim(), dr["ngaysinh"].ToString().Trim(), dr["sdt"].ToString().Trim(), dr["diachi"].ToString().Trim());
        //        ds.Add(bql);
        //    }
        //    return ds;
        //}

        //public static String MaNQL(List<BANQUANLY> dsNQL, String tennql)
        //{
        //    foreach(BANQUANLY bql in dsNQL)
        //    {
        //        if(bql.getTennql().Equals(tennql))
        //            return bql.getManql();
        //    }
        //    return "Không có";
        //}

        //public static String TenNQL(List<BANQUANLY> dsNQL, String manql)
        //{
        //    foreach (BANQUANLY bql in dsNQL)
        //    {
        //        if (bql.getManql().Equals(manql))
        //            return bql.getTennql();
        //    }
        //    return "Không có";
        //}
    }
}
