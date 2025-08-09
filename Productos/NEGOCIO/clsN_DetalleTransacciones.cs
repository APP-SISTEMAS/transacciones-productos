using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class clsN_DetalleTransacciones
    {


        string query;
        public DataTable consultaDetalleTransacciones()
        {

            query = "SELECT *   FROM Tienda.dbo.Fact_DetalleTransacciones";

            return DATOS.clsD_Productos.consultasSQL(query);
        }

    }
}
