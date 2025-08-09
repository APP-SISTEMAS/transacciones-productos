using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRESENTACION
{
    public partial class frm_RegistroProductos : Form
    {
        #region Variables
           DataTable dtInformacionProductos = new DataTable();
        string mensaje;
           clsN_Productos producto = new clsN_Productos();
           clsE_Fact_Productos E_productos = new clsE_Fact_Productos();
            #endregion
        public frm_RegistroProductos()
        {
            InitializeComponent();
        }

        private void frm_RegistroProductos_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(this.txtCodigo.Text) ||
                   string.IsNullOrEmpty(this.txtDescripcion.Text) ||
                   string.IsNullOrEmpty(this.txtCantidad.Text) ||
                   string.IsNullOrEmpty(this.cbxEstado.Text))
                {
                    MessageBox.Show("No se permiten campos vacios", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                { 
                
                
                } if (Convert.ToInt32(this.txtCantidad.Text) <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a 0", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DataTable validarInformacion = new DataTable();
                    clsE_Fact_Productos E_Productos = new clsE_Fact_Productos();
                    E_productos.Codigo = this.txtCodigo.Text;
                    E_productos.Descripcion = this.txtDescripcion.Text;
                    E_productos.Cantidad = Convert.ToInt32(this.txtCantidad.Text);
                    E_productos.Estado = this.cbxEstado.Text;

                    //SE VALIDA SI EXISTE EL CODIGO O LA DESCRIPCION DEL PRODUCTO

                    validarInformacion = producto.buscarProductosExistentes(E_productos);
                    if (validarInformacion.Rows.Count > 0)
                    {
                        MessageBox.Show("El codigo de producto / Descripcion  ya existen en la Base de datos", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtCodigo.Focus();
                    }
                    else
                    {
                        mensaje = producto.insertarProducto(E_productos);

                    }



                }


            }
            catch 
            {
                MessageBox.Show("Error", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


        #region FUNCIONES


        private void limpiarCampos()
        {
            this.txtCodigo.Text = "";

            this.txtDescripcion.Text = "";

            this.cbxEstado.Text = "";

            this.txtCantidad.Text = "";

        }

        //CONFIGURACION DEL DATA GRID
        private void configuracionDtg_Productos()
        {
            this.dtgListaProductos.Columns[0].HeaderText = "Id";
            this.dtgListaProductos.Columns[1].HeaderText = "Codigo";
            this.dtgListaProductos.Columns[2].HeaderText = "Descripcio";
            this.dtgListaProductos.Columns[3].HeaderText = "Cantidad Existencia";
            this.dtgListaProductos.Columns[4].HeaderText = "Opcion";

            this.dtgListaProductos.Columns[0].Width = 50;
            this.dtgListaProductos.Columns[1].Width = 120;
            this.dtgListaProductos.Columns[2].Width = 120;
            this.dtgListaProductos.Columns[3].Width = 200;
            this.dtgListaProductos.Columns[4].Width = 50;

        }


        //CARGA LOS TODOS LOS PRODUCTOS
        private void cargarProductos()
        {
            try
            {
                dtInformacionProductos = producto.consultaProductos();
                dtgListaProductos.DataSource = dtInformacionProductos;
                configuracionDtg_Productos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay informacion de los productos para visualizar", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //PERMITE BUSCAR LOS PRODUCTOS POR CODIGO
        private void buscarProductos()
        {
            try
            {
                dtInformacionProductos.Dispose(); //SE LIBERA EL DATATABLE
                E_productos.Codigo = this.txtCodigo.Text;
                dtInformacionProductos = producto.buscarProductos(E_productos);


                if (dtInformacionProductos.Rows.Count > 0)
                {
                    dtgListaProductos.DataSource = dtInformacionProductos;
                    configuracionDtg_Productos();
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



        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                MessageBox.Show("Ingrese el codigo del producto", "Informacion***", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                buscarProductos();
            }
                


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frm_Transacciones transaciones = new frm_Transacciones();
            transaciones.ShowDialog();
            transaciones.Show();
           
                
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}
