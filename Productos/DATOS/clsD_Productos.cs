using capaDatos;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using ENTIDAD;


namespace DATOS
{
    public class clsD_Productos
    {

        public static DataTable consultasSQL(string query)
        {
            clsD_Conexion c = new clsD_Conexion();
            DataTable dtConsultas = new DataTable();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, c.OpenConnecion());
                adapter.SelectCommand.CommandTimeout = 0;
                adapter.Fill(dtConsultas);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error Base de Datos***", MessageBoxButtons.OK, MessageBoxIcon.Error);
                c.CloseConnecion();
            }


            return dtConsultas;
        }



        public static DataTable buscarSQL(string query)
        {
            clsD_Conexion c = new clsD_Conexion();
            DataTable dtConsultas = new DataTable();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, c.OpenConnecion());
                adapter.SelectCommand.CommandTimeout = 0;
                adapter.Fill(dtConsultas);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error Base de Datos***", MessageBoxButtons.OK, MessageBoxIcon.Error);
                c.CloseConnecion();
            }


            return dtConsultas;
        }



        public static string insertarRegistroProducto(clsE_Fact_Productos clsE_Fact_Productos)
        {
            clsD_Conexion c = new clsD_Conexion();
            String mensaje;
          //  clsE_Fact_Productos eProductos = new clsE_Fact_Productos();

            try
            {
                SqlCommand cmd = new SqlCommand("Tienda.dbo.spInsertar_Productos", c.OpenConnecion());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = clsE_Fact_Productos.Codigo;// eProductos.Codigo;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = clsE_Fact_Productos.Descripcion;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = clsE_Fact_Productos.Cantidad;
                cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = clsE_Fact_Productos.Estado;

                int resultado = cmd.ExecuteNonQuery();
                mensaje = resultado == 1 ? "OK" : "";
           
            }

            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error Base de Datos***", MessageBoxButtons.OK, MessageBoxIcon.Error);
                c.CloseConnecion();
               
            }

            return mensaje;

        }


    }
}
