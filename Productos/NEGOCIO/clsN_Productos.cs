using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDAD;
using DATOS;

namespace NEGOCIO
{
    public class clsN_Productos
    {

        string query;
        public DataTable consultaProductos()
        {

            query = "SELECT Id, Codigo, Descripcion, Cantidad, CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Desabilitado' END As Estado   FROM Tienda.dbo.Fact_Productos";

           return DATOS.clsD_Productos.consultasSQL(query);
        }

        public DataTable buscarProductos(clsE_Fact_Productos productos)
        {

            query = "SELECT Id, Codigo, Descripcion, Cantidad, CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Desabilitado' END As Estado   FROM Tienda.dbo.Fact_Productos where  codigo = '"+ productos.Codigo  + "'";

            return DATOS.clsD_Productos.consultasSQL(query);
        }

        //GENERA LA CONSULTA PARA LAS VALIDACIONES DE PRODUCTOS UNICOS
        public DataTable buscarProductosExistentes(clsE_Fact_Productos E_productos)
        {

            query = "SELECT Id, Codigo, Descripcion, Cantidad, CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Desabilitado' END As Estado   FROM Tienda.dbo.Fact_Productos where  codigo = '" + E_productos.Codigo + "'  AND Descripcion = '" + E_productos.Descripcion + "'";

            return DATOS.clsD_Productos.consultasSQL(query);
        }


        //GENERA EL PROCEO DE INSERTA EL REQISTROS DEL PRODUCTO EN LA BD
        public string insertarProducto(clsE_Fact_Productos E_productos)
        {

           // query = "SELECT Id, Codigo, Descripcion, Cantidad, CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Desabilitado' END As Estado   FROM Tienda.dbo.Fact_Productos where  codigo = '" + E_productos.Codigo + "'  AND Descripcion = '" + E_productos.Descripcion + "'";

            return DATOS.clsD_Productos.insertarRegistroProducto(E_productos);
        }

    }
}
