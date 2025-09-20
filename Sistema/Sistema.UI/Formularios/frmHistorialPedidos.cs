using Sistema.BLL;
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
    public partial class frmHistorialPedidos : Form
    {
        private Mensajes mensaje = new Mensajes();

        public frmHistorialPedidos()
        {
            InitializeComponent();
        }

        #region Métodos

        private void ListarPedidos()
        {
            try
            {
                dgvListado.DataSource = bPedido.listarPedido();
                if(dgvListado.Rows.Count > 0 )
                {
                    txtBuscar.Focus();
                }

                dgvListado.Columns[0].Visible = false;

                dgvListado.Columns["SUBTOTAL"].DefaultCellStyle.Format = "N2";
                dgvListado.Columns["IMPUESTO"].DefaultCellStyle.Format = "N2";
                dgvListado.Columns["TOTAL"].DefaultCellStyle.Format = "N2";
            }
            catch(Exception)
            {
                mensaje.mensajeError("Error al cargar registros.");
            }
        }
        #endregion

        #region Eventos del Formulario

        private void frmHistorialPedidos_Load(object sender, EventArgs e)
        {
            ListarPedidos();
        }

        #endregion

        #region Botones de comando
        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtBuscar.Text))
                {
                    mensaje.mensajeInformacion("Debe especificar el número de factura.");
                    txtBuscar.Focus();
                }

                dgvListado.DataSource = bPedido.buscarPedido(txtBuscar.Text.Trim());
                if(dgvListado.Rows.Count == 0 )
                {
                    mensaje.mensajeInformacion("No existe ningún registro para la consulta solicitada.");
                    txtBuscar.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al buscar registros.");
            }
        }

        private void iconActualizar_Click(object sender, EventArgs e)
        {
            ListarPedidos();
            txtBuscar.Clear();
            txtBuscar.Focus();
        }
        #endregion

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvListado.Rows.Count >= 1)
                {
                    int id = int.TryParse(dgvListado.CurrentRow.Cells["ID"].Value?.ToString(), out int result) ? result : 0;

                    if(id == 0)
                    {
                        mensaje.mensajeValidacion("ID de la venta no es válido.");
                    }
                    else
                    {
                        frmDetalles frm = new frmDetalles(id, frmDetalles.tipoFormulario.venta);
                        mostrarModal.MostrarConCapaTransparente(this, frm);
                    }
                }
            }   
            catch(Exception)
            {
                mensaje.mensajeError("Error al cargar los detalles.");
            }
        }
    }
}
