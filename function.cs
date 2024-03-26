using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.NavigatorButtons;
namespace Quanlikhachsan
{
    internal class function
    {
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-S0411J9\\SQLEXPRESS;Initial Catalog=QLY_KHACHSAN;Integrated Security=True";
            return con;
        }

        public DataSet getData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds; 
        }

        public void setData(String query, String message)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(message, "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public SqlDataReader getForCombo(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
