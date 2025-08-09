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
        clsE_Fact_DetalleTransacciones E_Transacionproductos = new clsE_Fact_DetalleTransacciones();

        #endregion
        public frm_Transacciones()
        {
            InitializeComponent();
        }

        private void frm_Transacciones_Load(object sender, EventArgs e)
        {
            this.txtDescripcion.ReadOnly = true;
           // cargarDetallTransacciones();


        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {

            this.Close();

        }


        private void buscarDetalleTransaciones()
        {
            try
            {

                //  E_Transacionproductos.IdProducto = Convert.ToInt32(this.txtCodigo.Text);

                DataTable detalleTransaciones = new DataTable();
                detalleTransaciones = detalleTransacionesProducto.buscarDetalleTransacionesProductos(this.txtCodigo.Text);

                if (detalleTransaciones.Rows.Count > 0)
                {
                    dtgDetalleTransacciones.DataSource = detalleTransaciones;
                    
                }
                else
                {
                    MessageBox.Show("No hay informacion del codigo del producto para visualizar", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay informacion del codigo del producto para visualizar", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        #region FUNCIONES


        private void limpiarCampos()
        {
            this.txtCodigo.Text = "";

            this.txtDescripcion.Text = "";

          //  this.cbxEstado.Text = "";

            this.txtCantidad.Text = "";

        }




        private void seleccionarRegistros_Transaciones()
        {



        }



        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje;

            try
            {
                if (string.IsNullOrEmpty(this.txtCodigo.Text) ||
                  string.IsNullOrEmpty(this.txtCantidad.Text) ||
                   string.IsNullOrEmpty(this.cbxTipo.Text))
                {
                    MessageBox.Show("No se permiten campos vacios", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {


                }
                if (Convert.ToInt32(this.txtCantidad.Text) <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a 0", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DataTable validarInformacion = new DataTable();
                    clsE_Fact_DetalleTransacciones e_transaciones = new clsE_Fact_DetalleTransacciones();
                    clsE_Fact_Productos e_productos = new clsE_Fact_Productos();
                    e_productos.Codigo = this.txtCodigo.Text;
                  //  e_productos.Id = Convert.ToInt32(this.txtId.Text);
                    e_transaciones.Fecha = Convert.ToDateTime(this.dateTimePicker1.Text);
                    e_transaciones.TipoTransaccion = this.cbxTipo.Text;
                    e_transaciones.Cantidad = Convert.ToInt32(this.txtCantidad.Text);
                    e_transaciones.Observacion = this.txtObser.Text;
                    //SE VALIDA SI EXISTE EL CODIGO O LA DESCRIPCION DEL PRODUCTO

                    mensaje = detalleTransacionesProducto.insertarTransacionProducto(e_productos, e_transaciones);

                    //validarInformacion = producto.buscarProductosExistentes(E_productos);

                    //if (validarInformacion.Rows.Count > 0)
                    //{
                    //    MessageBox.Show("El codigo de producto / Descripcion  ya existen en la Base de datos", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    this.txtCodigo.Focus();
                    //}
                    //else
                    //{
                    //    mensaje = producto.insertarProducto(E_productos);

                    //}



                }


            }
            catch
            {
                MessageBox.Show("Error", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                MessageBox.Show("Ingrese el codigo del producto", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                try
                {
                    DataTable dtInformacionDetalle = new DataTable();
                    dtInformacionDetalle = detalleTransacionesProducto.consultaDetalleTransacciones(this.txtCodigo.Text);
                    dtgDetalleTransacciones.DataSource = dtInformacionDetalle;
                    //configuracionDtg_DetalleTrasnacionesProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No hay informacion de las transaciones para visualizar", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dtgDetalleTransacciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarRegistros_Transaciones();
    }
    }
}
