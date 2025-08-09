using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class clsE_Fact_DetalleTransacciones
    {


        public int Num { get; set; }
        public int IdProducto { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoTransaccion { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }

    }
}
