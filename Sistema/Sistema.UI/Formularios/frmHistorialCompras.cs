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
    public partial class frmHistorialCompras : Form
    {
        private Mensajes mensaje = new Mensajes();

        public frmHistorialCompras()
        {
            InitializeComponent();
        }

        #region Métodos

        private void ListarCompras()
        {
            try
            {
                dgvListado.DataSource = bCompra.listarCompra();
                if (dgvListado.Rows.Count > 0)
                {
                    dtpFechaInicio.Focus();
                }

                dgvListado.Columns[0].Visible = false;

                dgvListado.Columns["SUBTOTAL"].DefaultCellStyle.Format = "N2";
                dgvListado.Columns["IMPUESTO"].DefaultCellStyle.Format = "N2";
                dgvListado.Columns["TOTAL"].DefaultCellStyle.Format = "N2";
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al cargar registros.");
            }
        }

        #endregion

        #region Botones de Comando

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconActualizar_Click(object sender, EventArgs e)
        {
            ListarCompras();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFinal.Value = DateTime.Now;
        }

        private void iconBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFinal = dtpFechaFinal.Value.Date;

                if (fechaInicio > fechaFinal)
                {
                    mensaje.mensajeInformacion("La fecha inicial no puede ser mayor que la fecha final.");
                    dtpFechaInicio.Focus();
                    return;
                }

                dgvListado.DataSource = bCompra.buscarCompra(fechaInicio, fechaFinal);
                if (dgvListado.Rows.Count == 0)
                {
                    mensaje.mensajeInformacion("No existe ningún registro para la consulta solicitada.");
                    dtpFechaInicio.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al buscar registros.");
            }
        }

        #endregion


        #region Eventos del Formulario

        private void frmHistorialCompras_Load(object sender, EventArgs e)
        {
            ListarCompras();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFinal.Value = DateTime.Now;
        }

        #endregion

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvListado.Rows.Count >= 1)
                {
                    int id = int.TryParse(dgvListado.CurrentRow.Cells["ID"].Value?.ToString(), out int result) ? result : 0;

                    if (id == 0)
                    {
                        mensaje.mensajeValidacion("ID de la venta no es válido.");
                    }
                    else
                    {
                        frmDetalles frm = new frmDetalles(id, frmDetalles.tipoFormulario.compra);
                        mostrarModal.MostrarConCapaTransparente(this, frm);
                    }
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al cargar los detalles.");
            }
        }
    }
    
}
