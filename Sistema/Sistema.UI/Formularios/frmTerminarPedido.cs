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
    public partial class frmTerminarPedido : Form
    {
        private Mensajes mensaje = new Mensajes();

        public frmTerminarPedido(decimal totalGeneral)
        {
            InitializeComponent();

            this.KeyPress += Utilidades.PasarFocus;
            this.KeyDown += Utilidades.ControlEsc;

            txtTotalVenta.Text = totalGeneral.ToString("N2");
        }

        #region Métodos

        private bool ValidarCheckBox()
        {
            try
            {
                if(!chkEfectivo.Checked && !chkTarjeta.Checked)
                {
                    mensaje.mensajeValidacion("Debe seleccionar al menos un método de pago.");
                    return false;
                }

                if(chkEfectivo.Checked && !chkTarjeta.Checked)
                {
                    txtEfectivo.ReadOnly = false;
                    txtTarjeta.ReadOnly = true;

                    txtTarjeta.Text = "0.00";
                    txtEfectivo.Focus();

                    return true;
                }

                if (!chkEfectivo.Checked && chkTarjeta.Checked)
                {
                    txtEfectivo.ReadOnly = true;
                    txtTarjeta.ReadOnly = false;

                    txtEfectivo.Text = "0.00";
                    txtTarjeta.Focus();                    

                    return true;
                }

                if (chkEfectivo.Checked && chkTarjeta.Checked)
                {
                    txtEfectivo.ReadOnly = false;
                    txtTarjeta.ReadOnly = false;

                    txtEfectivo.Focus();

                    return true;
                }

                return false;
            }
            catch(Exception)
            {
                mensaje.mensajeError("Errros al validar método de pago.");
                return false;
            }
        }

        private bool CalcularCambio()
        {
            decimal pagoEfectivo = 0;
            decimal pagoTarjeta = 0;

            if(chkEfectivo.Checked)
            {
                if(!decimal.TryParse(txtEfectivo.Text.Trim(), out pagoEfectivo))
                {
                    mensaje.mensajeValidacion("El monto en efectivo no es válido.");
                    txtEfectivo.Focus();
                    return false;
                }
            }

            if (chkTarjeta.Checked)
            {
                if (!decimal.TryParse(txtTarjeta.Text.Trim(), out pagoTarjeta))
                {
                    mensaje.mensajeValidacion("El monto en tarjeta no es válido.");
                    txtTarjeta.Focus();
                    return false;
                }
            }

            if(!decimal.TryParse(txtTotalVenta.Text.Trim(), out decimal totalVenta))
            {
                mensaje.mensajeError("Error al obtener el total de la venta.");
                return false;
            }

            decimal totalPagado = pagoEfectivo + pagoTarjeta;
            decimal cambio = totalPagado - totalVenta;

            Variables.cambio = cambio;

            txtCambio.Text = cambio.ToString("N2");
            return true;
        }

        #endregion

        #region Cajas de Texto

        private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularCambio();
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.validarDecimal(sender, e);
        }

        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            Utilidades.formatoDecimal((Control)sender);
        }

        private void txtTarjeta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularCambio();
            }
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.validarDecimal(sender, e);
        }

        private void txtTarjeta_Leave(object sender, EventArgs e)
        {
            Utilidades.formatoDecimal((Control)sender);
        }

        #endregion

        #region Botones de comando

        #endregion

        #region Eventos del Formulario

        private void frmTerminarPedido_Load(object sender, EventArgs e)
        {
            ValidarCheckBox();
        }

        #endregion

        private void iconCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(!ValidarCheckBox())
                {
                    mensaje.mensajeValidacion("Debe seleccionar al menos un método de pago.");
                    return;
                }

                if (!CalcularCambio())
                    return;

                if(Variables.cambio >= 0)
                {
                    Variables.terminarVenta = 1;
                    Variables.montoEfectivo = Convert.ToDecimal(txtEfectivo.Text.Trim());
                    Variables.montoTarjeta = Convert.ToDecimal(txtTarjeta.Text.Trim());
                    Close();
                }
                else
                {
                    mensaje.mensajeValidacion("El monto ingresado no cubre el total de la venta.");
                }
            }
            catch(Exception)
            {
                mensaje.mensajeError("Error al imprimir el voucher. Es probable que la venta no se complete.");
            }
        }

        private void chkEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            ValidarCheckBox();
        }

        private void chkTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            ValidarCheckBox();
        }
    }
}
