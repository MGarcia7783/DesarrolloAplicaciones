using Sistema.BLL;
using Sistema.UI.FormulariosBase;
using Sistema.UI.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.UI.Formularios
{
    public partial class frmProductos : frmPlantilla
    {
        private Mensajes mensaje = new Mensajes();
        public frmProductos()
        {
            InitializeComponent();
        }

        #region Métodos

        private void listarTodosProducto()
        {
            try
            {
                dgvListado.DataSource = bProducto.listarTodosProductos();
                if (dgvListado.Rows.Count > 0)
                {
                    iconEditar.Enabled = true;
                    iconEliminar.Enabled = true;
                    txtBuscar.Enabled = true;
                }
                else
                {
                    iconEditar.Enabled = false;
                    iconEliminar.Enabled = false;
                    txtBuscar.Enabled = false;
                }

                dgvListado.Columns[0].Visible = false;
                dgvListado.Columns[3].Visible = false;
                dgvListado.Columns[4].Visible = false;
                dgvListado.Columns[9].Visible = false;
                dgvListado.Columns[10].Visible = false;
                dgvListado.Columns[11].Visible = false;
                dgvListado.Columns[12].Visible = false;

                txtBuscar.Focus();
            }

            catch (Exception)
            {
                mensaje.mensajeError("Error al cargar registros.");
            }
        }

        private void seleccionarRegistros(int filaSeleccionada)
        {
            try
            {
                int id = Convert.ToInt32(dgvListado.Rows[filaSeleccionada].Cells["ID"].Value);
                string Producto = dgvListado.Rows[filaSeleccionada].Cells["Producto"].Value?.ToString();
                string email = dgvListado.Rows[filaSeleccionada].Cells["EMAIL"].Value?.ToString();
                string telefono = dgvListado.Rows[filaSeleccionada].Cells["TELEFONO"].Value?.ToString();
                string contacto = dgvListado.Rows[filaSeleccionada].Cells["CONTACTO"].Value?.ToString();

                //frmAgregarProducto frm = new frmAgregarProducto(id, Producto, email, telefono, contacto);
                //frm.registroAgregado += listarProducto;
                //mostrarModal.MostrarConCapaTransparente(this, frm);
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al seleccionar el registro.");
            }
        }

        private void EliminarRegistro(int filaSeleccionada)
        {
            try
            {
                if (mensaje.mensajeConfirmacion("¿Seguro que desea eliminar el registro?") == DialogResult.OK)
                {
                    int id = Convert.ToInt32(dgvListado.Rows[filaSeleccionada].Cells["ID"].Value);
                    string resultado = bProducto.eliminarProducto(id);

                    if (resultado.Contains("éxito"))
                    {
                        mensaje.mensajeOk(resultado);
                    }
                    else
                    {
                        mensaje.mensajeInformacion(resultado);
                    }

                    listarTodosProducto();
                }
            }

            catch (Exception)
            {
                mensaje.mensajeError("Error al eliminar el registro.");
            }
        }
        #endregion

        #region Eventos del Formulario

        private void frmProductos_Load(object sender, EventArgs e)
        {
            listarTodosProducto();
        }


        #endregion

        private void iconAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto frm = new AgregarProducto();
            frm.registroAgregado += listarTodosProducto;
            mostrarModal.MostrarConCapaTransparente(this, frm);
        }
    }
}
