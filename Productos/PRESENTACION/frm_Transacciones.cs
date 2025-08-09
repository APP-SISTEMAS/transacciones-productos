using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ENTIDAD;
using NEGOCIO;

namespace PRESENTACION
{
    public partial class frm_Transacciones : Form
    {

        #region Variables
    
        string mensaje;
        clsN_DetalleTransacciones detalleTransacionesProducto = new clsN_DetalleTransacciones();
        clsE_Fact_Productos E_productos = new clsE_Fact_Productos();
        #endregion
        public frm_Transacciones()
        {
            InitializeComponent();
        }

        private void frm_Transacciones_Load(object sender, EventArgs e)
        {
            this.txtCodigo.ReadOnly = true;
            this.txtDescripcion.ReadOnly = true;
            cargarDetallTransacciones();


        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {

            this.Close();

        }


        #region FUNCIONES


        private void limpiarCampos()
        {
            this.txtCodigo.Text = "";

            this.txtDescripcion.Text = "";

          //  this.cbxEstado.Text = "";

            this.txtCantidad.Text = "";

        }


        //CARGA LOS TODOS LOS PRODUCTOS
        private void cargarDetallTransacciones()
        {
            try
            {
                DataTable dtInformacionDetalle = new DataTable();
                dtInformacionDetalle = detalleTransacionesProducto.consultaDetalleTransacciones();
                dtgDetalleTransacciones.DataSource = dtInformacionDetalle;
                //configuracionDtg_DetalleTrasnacionesProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay informacion de las transaciones para visualizar", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       


        #endregion
    }
}
