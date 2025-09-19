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
    public partial class frmCategorias : frmPlantilla
    {
        private Mensajes mensaje = new Mensajes();

        public frmCategorias()
        {
            InitializeComponent();
        }

        #region Métodos

        private void listarCategoria()
        {
            try
            {
                dgvListado.DataSource = bCategoria.listarCategoria();
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
                string categoria = dgvListado.Rows[filaSeleccionada].Cells["CATEGORIA"].Value?.ToString();
                string descripcion = dgvListado.Rows[filaSeleccionada].Cells["DESCRIPCION"].Value?.ToString();

                frmAgregarCategoria frm = new frmAgregarCategoria(id, categoria, descripcion);
                frm.registroAgregado += listarCategoria;
                mostrarModal.MostrarConCapaTransparente(this, frm);
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
                    string resultado = bCategoria.eliminarCategoria(id);

                    if (resultado.Contains("éxito"))
                    {
                        mensaje.mensajeOk(resultado);
                    }
                    else
                    {
                        mensaje.mensajeInformacion(resultado);
                    }

                    listarCategoria();
                }
            }

            catch (Exception)
            {
                mensaje.mensajeError("Error al eliminar el registro.");
            }
        }
        #endregion

        #region Eventos del Formulario

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            listarCategoria();
        }

        #endregion

        #region Botones de Comando

        private void iconAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarCategoria frm = new frmAgregarCategoria();
            frm.registroAgregado += listarCategoria;
            mostrarModal.MostrarConCapaTransparente(this, frm);
        }

        private void iconEditar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow != null)
            {
                seleccionarRegistros(dgvListado.CurrentRow.Index);
            }
        }

        private void iconEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow != null)
            {
                EliminarRegistro(dgvListado.CurrentRow.Index);
            }
        }

        #endregion

        #region Cajas de texto

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = bCategoria.buscarCategoria(txtBuscar.Text.Trim());
                if (dgvListado.Rows.Count > 0)
                {
                    iconEditar.Enabled = true;
                    iconEliminar.Enabled = true;
                }
                else
                {
                    iconEditar.Enabled = false;
                    iconEliminar.Enabled = false;
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al buscar registros.");
            }
        }

        #endregion
    }
}
