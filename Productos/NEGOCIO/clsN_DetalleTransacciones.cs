using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class clsN_DetalleTransacciones
    {


        string query;
        public DataTable consultaDetalleTransacciones(string codigo)
        {

            query = "SELECT Id, Fecha, codigo, descripcion, CASE WHEN TipoTransaccion = 'E' THEN 'ENTRADA' ELSE 'SALIDA' END AS Tupo, b.Cantidad, Observacion FROM Tienda.dbo.Fact_Productos as a inner join Tienda.dbo.Fact_DetalleTransacciones as b on a.Id = b.IdProducto  where a.Codigo= '" + codigo + "'";
            

            return DATOS.clsD_Productos.consultasSQL(query);
        }



        //GENERA EL PROCEO DE INSERTA EL REQISTROS DEL PRODUCTO EN LA BD
        public string insertarTransacionProducto(clsE_Fact_Productos E_productos, clsE_Fact_DetalleTransacciones E_transacion)
        {

            // query = "SELECT Id, Codigo, Descripcion, Cantidad, CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Desabilitado' END As Estado   FROM Tienda.dbo.Fact_Productos where  codigo = '" + E_productos.Codigo + "'  AND Descripcion = '" + E_productos.Descripcion + "'";

            return DATOS.clsD_Productos.insertarTransacionProductos(E_productos, E_transacion);
        }

        public DataTable buscarDetalleTransacionesProductos(string codigo)
        {

            query = "SELECT Id, Fecha, codigo, descripcion, CASE WHEN TipoTransaccion = 'E' THEN 'ENTRADA' ELSE 'SALIDA' END AS Tupo, b.Cantidad, Observacion FROM Fact_Productos as a inner join Fact_DetalleTransacciones as b on a.Id = b.IdProducto where where a.Codigo= '" + codigo + "'";

            return DATOS.clsD_Productos.consultasSQL(query);
        }



    }
}
