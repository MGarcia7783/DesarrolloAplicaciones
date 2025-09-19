using Sistema.BLL;
using Sistema.Entity;
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
    public partial class AgregarProducto : Form
    {
        private Mensajes mensaje = new Mensajes();
        public event Action registroAgregado;
        Boolean actualizarRegistro = false;
        public AgregarProducto()
        {
            InitializeComponent();

            InicializarCombo();
            cboPresentacion.SelectedIndex = 0;
            cboReceta.SelectedIndex = 0;
            dtpFechaVencimiento.Value = DateTime.Now;

            this.KeyPress += Utilidades.PasarFocus;
            this.KeyDown += Utilidades.ControlEsc;
        }

        public AgregarProducto(int id, string codigo, Boolean impuesto, string producto, string formatoCompra, string categoria, string laboratorio, int stock, int stockMinimo, string ventaReceta, decimal precioCompra, decimal precioVenta, Boolean tieneReceta, DateTime? fechaVencimiento)
        {
            InitializeComponent();

            InicializarCombo();

            this.KeyPress += Utilidades.PasarFocus;
            this.KeyDown += Utilidades.ControlEsc;

            txtId.Text = id.ToString();
            txtCodigo.Text = codigo;
            txtProducto.Text = producto;
            chkImpuesto.Checked = impuesto;
            cboPresentacion.Text = formatoCompra;
            cboCategoria.Text = categoria;
            cboLaboratorio.Text = laboratorio;
            txtStock.Text = stock.ToString();
            txtStockMinimo.Text = stockMinimo.ToString();
            cboReceta.Text = ventaReceta;
            txtPrecioCompra.Text = precioCompra.ToString();
            txtPrecioVenta.Text = precioVenta.ToString();
            chkTieneVencimiento.Checked = tieneReceta;

            if(tieneReceta && fechaVencimiento.HasValue)
            {
                dtpFechaVencimiento.Value = fechaVencimiento.Value;
            }

            txtStock.Enabled = false;
            actualizarRegistro = true;
        }

        #region Metodos

        private void CargarCategorias()
        {
            try
            {
                var categoria = bCategoria.listarCategoria();
                if(categoria != null && categoria.Rows.Count > 0)
                {
                    cboCategoria.DataSource = categoria;
                    cboCategoria.ValueMember = "ID";
                    cboCategoria.DisplayMember = "CATEGORIA";
                    cboCategoria.SelectedIndex = 0;
                }
            }
            catch(Exception)
            {
                mensaje.mensajeError("Error al cargar las categorías.");
            }
        }

        private void CargarLaboratorios()
        {
            try
            {
                var laboratorio = bLaboratorio.listarLaboratorio();
                if (laboratorio != null && laboratorio.Rows.Count > 0)
                {
                    cboLaboratorio.DataSource = laboratorio;
                    cboLaboratorio.ValueMember = "ID";
                    cboLaboratorio.DisplayMember = "LABORATORIO";
                    cboLaboratorio.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al cargar los laboratorios.");
            }
        }

        private void InicializarCombo()
        {
            try
            {
                CargarCategorias();
                CargarLaboratorios();
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al cargar combos.");
            }
        }

        private void errorControl(string campo)
        {
            switch (campo)
            {
                case "codigo":
                    errorIcono.SetError(txtCodigo, "Este campo es obligatorio.");
                    txtCodigo.Focus();
                    break;

                case "nombreProducto":
                    errorIcono.SetError(txtProducto, "Este campo es obligatorio.");
                    txtProducto.Focus();
                    break;

                case "formatoCompra":
                    errorIcono.SetError(cboPresentacion, "Este campo es obligatorio.");
                    cboPresentacion.Focus();
                    break;

                case "idCategoria":
                    errorIcono.SetError(cboCategoria, "Seleccione un elemento de la lista.");
                    cboCategoria.Focus();
                    break;

                case "idLaboratorio":
                    errorIcono.SetError(cboLaboratorio, "Seleccione un elemento de la lista.");
                    cboLaboratorio.Focus();
                    break;

                case "stock":
                    errorIcono.SetError(txtStock, "El stock debe ser un número mayor a cero.");
                    txtStock.Focus();
                    break;

                case "stockMinimo":
                    errorIcono.SetError(txtStockMinimo, "El stock mínimo debe ser un número mayor a cero.");
                    txtStockMinimo.Focus();
                    break;

                case "ventaReceta":
                    errorIcono.SetError(cboPresentacion, "Seleccione un elemento de la lista.");
                    cboPresentacion.Focus();
                    break;

                case "precioCompra":
                    errorIcono.SetError(txtPrecioCompra, "El precio de compra debe ser un número mayor a cero.");
                    txtPrecioCompra.Focus();
                    break;

                case "precioVenta":
                    errorIcono.SetError(txtPrecioVenta, "El precio de venta debe ser un número mayor a cero.");
                    txtPrecioVenta.Focus();
                    break;
            }
        }

        private void LimpiarControles()
        {
            txtPrecioCompra.Text = "0";
            txtCodigo.Clear();
            chkImpuesto.Checked = false;
            txtProducto.Clear();
            cboPresentacion.SelectedIndex = 0;
            cboCategoria.SelectedIndex = 0;
            cboLaboratorio.SelectedIndex = 0;
            txtStock.Text = "0";
            txtStockMinimo.Text = "0";
            cboReceta.SelectedIndex = 0;
            chkTieneVencimiento.Checked = false;
            dtpFechaVencimiento.Value = DateTime.Now;
            txtPrecioCompra.Text = "0.00";
            txtPrecioVenta.Text = "0.00";
            txtCodigo.Focus();
        }

        #endregion

        #region Botones de comando

        private void iconCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                errorIcono.Clear();
                if(!int.TryParse(cboCategoria.SelectedValue?.ToString(), out int idCategoria))
                {
                    mensaje.mensajeValidacion("Debe especificar una categoría válida.");
                    errorIcono.SetError(cboCategoria, "Este campo es obligatorio.");
                    cboCategoria.Focus();
                    return;
                }

                if (!int.TryParse(cboLaboratorio.SelectedValue?.ToString(), out int idLaboratorio))
                {
                    mensaje.mensajeValidacion("Debe especificar un laboratorio válido.");
                    errorIcono.SetError(cboLaboratorio, "Este campo es obligatorio.");
                    cboLaboratorio.Focus();
                    return;
                }

                if (!decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra))
                {
                    mensaje.mensajeValidacion("El precio de compra no tiene un formato válido.");
                    errorIcono.SetError(txtPrecioCompra, "El precio de compra debe ser un número mayor a cero.");
                    txtPrecioCompra.Focus();
                    return;
                }

                if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta))
                {
                    mensaje.mensajeValidacion("El precio de venta no tiene un formato válido.");
                    errorIcono.SetError(txtPrecioVenta, "El precio de venta debe ser un número mayor a cero.");
                    txtPrecioVenta.Focus();
                    return;
                }

                string grbarImpuesto = chkImpuesto.Checked ? "G" : "E";

                oProducto producto = new oProducto()
                {
                    codigo = txtCodigo.Text.Trim(),
                    impuesto = grbarImpuesto,
                    nombreProducto = txtProducto.Text.Trim(),
                    formatoCompra = cboPresentacion.Text.Trim(),
                    idCategoria = Convert.ToInt32(cboCategoria.SelectedValue),
                    idLaboratorio = Convert.ToInt32(cboLaboratorio.SelectedValue),
                    stock = Convert.ToInt32(txtStock.Text.Trim()),
                    stockMinimo = Convert.ToInt32(txtStockMinimo.Text.Trim()),
                    ventaConReceta = cboReceta.Text.Trim(),
                    precioCompra = Convert.ToDecimal(txtPrecioCompra.Text.Trim()),
                    precioVenta = Convert.ToDecimal(txtPrecioVenta.Text.Trim()),
                    tieneVencimiento = chkTieneVencimiento.Checked,
                    fechaVencimiento = chkTieneVencimiento.Checked ? dtpFechaVencimiento.Value : (DateTime?)null
                };

                resultadoOperacion resultado;

                if(int.TryParse(txtId.Text.Trim(), out int idProducto) && idProducto == 0)
                {
                    resultado = bProducto.registrarProducto(producto);
                }
                else
                {
                    producto.idProducto = idProducto;
                    resultado = bProducto.editarProducto(producto);
                }

                if (!resultado.esValido)
                {
                    mensaje.mensajeValidacion(resultado.mensaje);

                    if (!String.IsNullOrWhiteSpace(resultado.campoInvalido))
                    {
                        errorControl(resultado.campoInvalido);
                    }

                    return;
                }

                mensaje.mensajeOk(resultado.mensaje);
                registroAgregado?.Invoke();
                LimpiarControles();
            }
            catch(Exception)
            {
                mensaje.mensajeError("Ocurrio un error inesperado.");
            }
        }

        #endregion

        #region Cajas de texto

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.numerosEnteros(e, txtStock.Text.Trim());
        }

        private void txtStockMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.numerosEnteros(e, txtStockMinimo.Text.Trim());
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.validarDecimal(sender, e);
        }

        private void txtPrecioCompra_Leave(object sender, EventArgs e)
        {
            Utilidades.formatoDecimal((Control)sender);
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.validarDecimal(sender, e);
        }

        private void txtPrecioVenta_Leave(object sender, EventArgs e)
        {
            Utilidades.formatoDecimal((Control)sender);
        }

        private void txtStock_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStock.Text))
                txtStock.Text = "0";
        }

        private void txtStockMinimo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStockMinimo.Text))
                txtStockMinimo.Text = "0";
        }

        #endregion
    }
}
