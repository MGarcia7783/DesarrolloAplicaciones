using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.UI.FormulariosBase;
using Sistema.UI.Modulos;

namespace Sistema.UI.Formularios
{
    public partial class frmLaboratorio : frmPlantilla
    {
        private Mensajes mensaje = new Mensajes();
        public frmLaboratorio()
        {
            InitializeComponent();
        }

        #region Métodos

        private void listarLaboratorio()
        {
            try
            {
                dgvListado.DataSource = bLaboratorio.listarLaboratorio();
                if(dgvListado.Rows.Count > 0)
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
                dgvListado.Columns[1].Width = 450;
                dgvListado.Columns[1].Width = 350;
                dgvListado.Columns[1].Width = 200;
                dgvListado.Columns[1].Width = 350;

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
                string laboratorio = dgvListado.Rows[filaSeleccionada].Cells["LABORATORIO"].Value?.ToString();
                string email = dgvListado.Rows[filaSeleccionada].Cells["EMAIL"].Value?.ToString();
                string telefono = dgvListado.Rows[filaSeleccionada].Cells["TELEFONO"].Value?.ToString();
                string contacto = dgvListado.Rows[filaSeleccionada].Cells["CONTACTO"].Value?.ToString();

                frmAgregarLaboratorio frm = new frmAgregarLaboratorio(id, laboratorio, email, telefono, contacto);
                frm.registroAgregado += listarLaboratorio;
                mostrarModal.MostrarConCapaTransparente(this, frm);
            }
            catch(Exception)
            {
                mensaje.mensajeError("Error al seleccionar el registro.");
            }
        }

        private void EliminarRegistro(int filaSeleccionada)
        {
            try
            {
                if(mensaje.mensajeConfirmacion("¿Seguro que desea eliminar el registro?") == DialogResult.OK)
                {
                    int id = Convert.ToInt32(dgvListado.Rows[filaSeleccionada].Cells["ID"].Value);
                    string resultado = bLaboratorio.eliminarLaboratorio(id);

                    if(resultado.Contains("éxito"))
                    {
                        mensaje.mensajeOk(resultado);
                    }
                    else
                    {
                        mensaje.mensajeInformacion(resultado);
                    }

                    listarLaboratorio();
                }
            }

            catch (Exception)
            {
                mensaje.mensajeError("Error al eliminar el registro.");
            }
        }
        #endregion

        #region Eventos del formulario

        private void frmLaboratorio_Load(object sender, EventArgs e)
        {
            listarLaboratorio();
        }

        #endregion

        #region Botones de comando

        private void iconAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarLaboratorio frm = new frmAgregarLaboratorio();
            frm.registroAgregado += listarLaboratorio;
            mostrarModal.MostrarConCapaTransparente(this, frm);
        }

        private void iconEditar_Click(object sender, EventArgs e)
        {
            if(dgvListado.CurrentRow != null)
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

        #region Cajas de Texto

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = bLaboratorio.buscarLaboratorio(txtBuscar.Text.Trim());
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
            catch(Exception)
            {
                mensaje.mensajeError("Error al buscar registros.");
            }
        }

        #endregion
    }
}
