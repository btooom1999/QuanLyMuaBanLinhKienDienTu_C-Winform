using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Phan_tich_thiet_ke_HTTT.DAO
{
    public class ConnectionDB
    {
        private SqlDataAdapter da;
        private SqlConnection cn;
        private String ketnoi = "Data Source="+GUI.KiemTraKetNoiDatabase._server+ ";Initial Catalog=QL_MUABANLINHKIEN1;User ID=" + GUI.KiemTraKetNoiDatabase._user+";Password="+GUI.KiemTraKetNoiDatabase._password+"";

        public Boolean kiemtraketnoidatabase(String server, String user, String password)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=" + server + ";Initial Catalog=QL_MUABANLINHKIEN1;User ID=" + user + ";Password=" + password + "");
                cn.Open();
                cn.Close();
            }
            catch (Exception) { return false; }
            return true;
        }

        public SqlDataAdapter getDa(String sql)
        {
            cn = new SqlConnection(ketnoi);
            cn.Open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            da = new SqlDataAdapter(cmd);    
            return da;
        }

        public void close()
        {
            this.cn.Close();
        }

        public void themxoasua(String sql)
        {   
            cn = new SqlConnection(ketnoi);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            close();
        }
    }
}
