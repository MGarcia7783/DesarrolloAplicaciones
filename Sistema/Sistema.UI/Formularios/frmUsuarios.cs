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
    public partial class frmUsuarios : frmPlantilla
    {
        private Mensajes mensaje = new Mensajes();

        public frmUsuarios()
        {
            InitializeComponent();
        }

        #region Métodos

        private void listarUsuario()
        {
            try
            {
                dgvListado.DataSource = bUsuario.listarUsuario();
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
                dgvListado.Columns[3].Width = 200;

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
                string dniUsuario = dgvListado.Rows[filaSeleccionada].Cells["IDENTIFICACION"].Value?.ToString();
                string nombreUsuario = dgvListado.Rows[filaSeleccionada].Cells["USUARIO"].Value?.ToString();
                string codigoUsuario = dgvListado.Rows[filaSeleccionada].Cells["CODIGO"].Value?.ToString();
                string email = dgvListado.Rows[filaSeleccionada].Cells["EMAIL"].Value?.ToString();
                string rol = dgvListado.Rows[filaSeleccionada].Cells["ROL"].Value?.ToString();

                frmAgregarUsuario frm = new frmAgregarUsuario(id, dniUsuario, nombreUsuario, codigoUsuario, email, rol);
                frm.registroAgregado += listarUsuario;
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
                    string resultado = bUsuario.eliminarUsuario(id);

                    if (resultado.Contains("éxito"))
                    {
                        mensaje.mensajeOk(resultado);
                    }
                    else
                    {
                        mensaje.mensajeInformacion(resultado);
                    }

                    listarUsuario();
                }
            }

            catch (Exception)
            {
                mensaje.mensajeError("Error al eliminar el registro.");
            }
        }

        #endregion

        #region Botones de Comando

        private void iconAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarUsuario frm = new frmAgregarUsuario();
            frm.registroAgregado += listarUsuario;
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


        #region Eventos del Formulario

        #endregion
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            listarUsuario();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = bUsuario.buscarUsuario(txtBuscar.Text.Trim());
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
    }
}
