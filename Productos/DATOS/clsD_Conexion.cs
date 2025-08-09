using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace capaDatos
{
    public class clsD_Conexion
    {

        public SqlConnection cn = new SqlConnection("Data Source = DESKTOP-OAG4Q0D\\SQLEXPRESS; Persist Security Info=True;User ID = sa; Password=12345");

        public SqlConnection OpenConnecion()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            return cn;
        }


        public SqlConnection CloseConnecion()
        {
            if (cn.State == ConnectionState.Open)
            {

                cn.Close();
            }
            return cn;
        }


    }
}
