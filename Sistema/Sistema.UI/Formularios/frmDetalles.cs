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
    public partial class frmDetalles : Form
    {
        private Mensajes mensaje = new Mensajes();
        private int idPedido;

        public frmDetalles(int id, tipoFormulario invocador)
        {
            InitializeComponent();

            formularioInvocador = invocador;

            this.idPedido = id;
        }

        #region Métodos

        public enum tipoFormulario
        {
            venta,
            compra
        }

        public tipoFormulario formularioInvocador { get; set; }

        private void buscarDetallePedido(int id)
        {
            try
            {
                if (formularioInvocador == tipoFormulario.venta)
                {
                    dgvListado.DataSource = bPedido.buscarDetallePedido(id);

                    dgvListado.Columns["PRECIO"].DefaultCellStyle.Format = "N2";
                }
                else if (formularioInvocador == tipoFormulario.compra)
                {
                    dgvListado.DataSource = bCompra.buscarDetalleCompra(id);

                    dgvListado.Columns["P_COMPRA"].DefaultCellStyle.Format = "N2";
                    dgvListado.Columns["P_VENTA"].DefaultCellStyle.Format = "N2";
                }

                dgvListado.Columns[0].Visible = false;
                dgvListado.Columns[1].Visible = false;
            }

            catch (Exception)
            {
                mensaje.mensajeError("Error al cargar registros.");
            }
        }

        #endregion

        private void iconSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDetalles_Load(object sender, EventArgs e)
        {
            buscarDetallePedido(idPedido);
        }
    }
}
