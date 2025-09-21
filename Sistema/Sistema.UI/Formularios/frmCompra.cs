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
    public partial class frmCompra : Form
    {
        private DataTable detalleCompra = new DataTable();
        private Mensajes mensaje = new Mensajes();

        public frmCompra()
        {
            InitializeComponent();
        }

        #region Métodos

        private void CrearTabla()
        {
            try
            {
                detalleCompra.Columns.Add("idProducto", System.Type.GetType("System.Int32"));                
                detalleCompra.Columns.Add("nombreProducto", System.Type.GetType("System.String"));
                detalleCompra.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
                detalleCompra.Columns.Add("precioCompra", System.Type.GetType("System.Decimal"));
                detalleCompra.Columns.Add("precioVenta", System.Type.GetType("System.Decimal"));
                detalleCompra.Columns.Add("impuesto", System.Type.GetType("System.String"));

                dgvDetalle.DataSource = detalleCompra;
                FormatoTabla();
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al crear el DataTable.");
            }
        }

        private void FormatoTabla()
        {
            dgvDetalle.Columns[0].Visible = false;            
            dgvDetalle.Columns[1].HeaderText = "PRODUCTO";
            dgvDetalle.Columns[2].HeaderText = "CANTIDAD";
            dgvDetalle.Columns[3].HeaderText = "P_COMPRA";
            dgvDetalle.Columns[4].HeaderText = "P_VENTA";
            dgvDetalle.Columns[5].Visible = false;

            dgvDetalle.Columns["precioCompra"].DefaultCellStyle.Format = "N2";
            dgvDetalle.Columns["precioVenta"].DefaultCellStyle.Format = "N2";

            dgvDetalle.Columns["nombreProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvDetalle.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetalle.Columns[1].ReadOnly = true;
        }

        private void AjustarColumnas()
        {
            try
            {
                if (detalleCompra.Columns.Count == 0)
                    return;

                int anchodisponible = dgvDetalle.ClientSize.Width;

                int anchoCant = 120;
                int anchoPrecio = 130;

                int anchoProducto = anchodisponible - (anchoCant + (anchoPrecio * 2) + 20);

                dgvDetalle.Columns["cantidad"].Width = anchoCant;
                dgvDetalle.Columns["nombreProducto"].Width = anchoProducto;
                dgvDetalle.Columns["precioCompra"].Width = anchoPrecio;
                dgvDetalle.Columns["precioVenta"].Width = anchoPrecio;

            }
            catch (Exception)
            {
                mensaje.mensajeError("Ocurrió un error al ajustar el diseño del DataGridView.");
            }
        }

        private void BuscarProducto()
        {
            try
            {
                var producto = bProducto.buscarTodosProducto(0, txtBuscar.Text.Trim());
                if (producto.Rows.Count > 0)
                {
                    lblId.Text = producto.Rows[0]["ID"].ToString();
                    lblProducto.Text = producto.Rows[0]["PRODUCTO"].ToString();
                    lblStock.Text = producto.Rows[0]["STOCK"].ToString();
                    lblPrecioCompra.Text = Convert.ToDecimal(producto.Rows[0]["P_COMPRA"]).ToString("N2");
                    lblPrecioVenta.Text = Convert.ToDecimal(producto.Rows[0]["P_VENTA"]).ToString("N2");                    
                    lblGrabaImpuesto.Text = producto.Rows[0]["IMPUESTO"].ToString();

                    lblDetalle.Visible = true;
                    lblProducto.Visible = true;
                    lblPrecioTitulo.Visible = true;
                    lblPrecioCompra.Visible = true;
                    lblStockTitulo.Visible = true;
                    lblStock.Visible = true;
                    txtBuscar.Focus();
                }
                else
                {
                    LimpiarControles();
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al buscar el producto.");
            }
        }

        private void LimpiarControles()
        {
            lblId.Text = "0";
            lblProducto.Text = "";
            lblStock.Text = "0";
            lblPrecioCompra.Text = "0";
            lblPrecioVenta.Text = "0";

            lblDetalle.Visible = false;
            lblProducto.Visible = false;
            lblPrecioTitulo.Visible = false;
            lblPrecioCompra.Visible = false;
            lblStockTitulo.Visible = false;
            lblStock.Visible = false;
            txtBuscar.Focus();
        }

        public void AgregarProductos(int idProducto, string producto, int cantidad, decimal precioCompra, decimal precioVenta, string impuesto)
        {
            try
            {
                bool registroDuplicado = false;

                foreach (DataGridViewRow fila in dgvDetalle.Rows)
                {
                    if (fila.Cells["idProducto"].Value != null && Convert.ToInt32(fila.Cells["idProducto"].Value) == idProducto)
                    {
                        mensaje.mensajeInformacion("El producto ya se encuentra en la lista.");
                        registroDuplicado = true;
                        break;
                    }
                }

                if (!registroDuplicado)
                {
                    DataRow nuevaFila = detalleCompra.NewRow();
                    nuevaFila["idProducto"] = idProducto;
                    nuevaFila["nombreProducto"] = producto;
                    nuevaFila["cantidad"] = cantidad;                    
                    nuevaFila["precioCompra"] = precioCompra;
                    nuevaFila["precioVenta"] = precioVenta;
                    nuevaFila["impuesto"] = impuesto;
                    detalleCompra.Rows.Add(nuevaFila);
                }

                LimpiarControles();
                iconGuardar.Enabled = true;
                CalcularTotales();

                Variables.idProducto = 0;
                Variables.nombreProducto = "";
                Variables.precioCompra = 0;
                Variables.precioVenta = 0;
                Variables.stock = 0;
                Variables.impuesto = "";

                txtBuscar.Focus();


            }
            catch (Exception)
            {
                mensaje.mensajeError("Ocurrió un error al agregar registro al DataTable.");
            }
        }

        private void CalcularTotales()
        {
            try
            {
                decimal subTotal = 0;
                decimal impuestoTotal = 0;
                const decimal tasaImpuesto = 0.15m;

                foreach (DataRow fila in detalleCompra.Rows)
                {
                    int cantidad = Convert.ToInt32(fila["cantidad"]);
                    decimal precio = Convert.ToDecimal(fila["precioCompra"]);
                    string impuesto = fila["impuesto"].ToString();

                    decimal totalFila = cantidad * precio;

                    if (impuesto == "G")
                    {
                        decimal precioSinImpuesto = totalFila / (1 + tasaImpuesto);
                        decimal sumaImpuesto = totalFila - precioSinImpuesto;

                        subTotal += precioSinImpuesto;
                        impuestoTotal += sumaImpuesto;
                    }
                    else
                    {
                        subTotal += totalFila;
                    }
                }

                decimal totalGeneral = subTotal + impuestoTotal;

                lblSubtotal.Text = subTotal.ToString("N2");
                lblImpuesto.Text = impuestoTotal.ToString("N2");
                lblTotal.Text = totalGeneral.ToString("N2");
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al calcular totales.");
            }
        }

        private void Txt_KeyPressCantidad(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox txt)
                Utilidades.numerosEnteros(e, txt.Text);
        }

        private void Txt_KeyPressPrecio(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox txt)
                Utilidades.validarDecimal(sender, e);
        }

        private void errorControl(string campo)
        {
            switch (campo)
            {
                case "numeroFactura":
                    errorIcono.SetError(txtFacturaCompra, "Este campo es obligatorio.");
                    txtFacturaCompra.Focus();
                    break;

                case "totalGeneral":
                    errorIcono.SetError(lblTotal, "Este campo es obligatorio.");
                    break;
            }
        }

        private void BloquearControles()
        {
            gunaCarrito.Enabled = false;
            gunaProducto.Enabled = false;
            gunaDetalleCompra.Enabled = false;
            iconGuardar.Enabled = false;
            iconNuevo.Enabled = true;
        }

        private void DesbloquearControles()
        {
            gunaCarrito.Enabled = true;
            gunaProducto.Enabled = true;
            gunaDetalleCompra.Enabled= true;
            iconGuardar.Enabled = true;
            iconNuevo.Enabled = false;
            detalleCompra.Clear();
            lblSubtotal.Text = "0.00";
            lblImpuesto.Text = "0.00";
            lblTotal.Text = "0.00";
            txtFacturaCompra.Text = "";
            txtObservacion.Text = "";
            dtpFechaCompra.Value = DateTime.Now;

            txtBuscar.Focus();
        }

        #endregion

        #region Botones de comando

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion

        #region Eventos del Formulario        

        private void frmCompra_Load(object sender, EventArgs e)
        {
            CrearTabla();
            dtpFechaCompra.Value = DateTime.Now;
        }

        private void frmCompra_Shown(object sender, EventArgs e)
        {
            AjustarColumnas();
        }

        private void frmCompra_Resize(object sender, EventArgs e)
        {
            AjustarColumnas();
        }

        #endregion

        #region Cajas de Texto

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    if (lblId.Text.Trim() != "0")
                    {
                        Variables.precioCompra = decimal.TryParse(lblPrecioCompra.Text, out decimal precioCompra) ? precioCompra: 0;
                        Variables.precioVenta = decimal.TryParse(lblPrecioVenta.Text, out decimal precioVenta) ? precioVenta: 0;
                        Variables.cantidad = 1;

                        int stock = int.TryParse(lblStock.Text, out int result) ? result : 0;

                        int.TryParse(lblId.Text, out int idProducto);
                        string nombreProducto = lblProducto.Text;
                        string impuesto = lblGrabaImpuesto.Text;

                        AgregarProductos(idProducto, nombreProducto, Variables.cantidad, Variables.precioCompra, Variables.precioVenta, impuesto);
                        txtBuscar.Clear();
                    }
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error inesperado al agregar registros al DataTable.");
            }
        }


        #endregion

        #region Eventos del DataGridView

        private void dgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if(e.Control is TextBox txt)
                {
                    if (dgvDetalle.CurrentCell.ColumnIndex == 2)
                    {
                        txt.KeyPress -= Txt_KeyPressCantidad;
                        txt.KeyPress += Txt_KeyPressCantidad;
                    }
                    else if (dgvDetalle.CurrentCell.ColumnIndex == 3 || dgvDetalle.CurrentCell.ColumnIndex == 4)
                    {
                        txt.KeyPress -= Txt_KeyPressPrecio;
                        txt.KeyPress += Txt_KeyPressPrecio;
                    }
                }
                
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al validar datos.");
            }
        }

        private void dgvDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                var col = dgvDetalle.Columns[e.ColumnIndex].Name;
                if (col != "precioCompra" && col != "precioVenta") return;

                if (!decimal.TryParse(e.FormattedValue?.ToString(), out decimal nuevoValor))
                {
                    mensaje.mensajeInformacion("Debe ingresar un valor numérico.");
                    e.Cancel = true;
                    return;
                }

                decimal compra = col == "precioCompra" ? nuevoValor : Convert.ToDecimal(dgvDetalle.Rows[e.RowIndex].Cells["precioCompra"].Value ?? 0);
                decimal venta = col == "precioVenta" ? nuevoValor : Convert.ToDecimal(dgvDetalle.Rows[e.RowIndex].Cells["precioVenta"].Value ?? 0);

                if(compra > venta)
                {
                    mensaje.mensajeValidacion("El precio de compra no puede ser mayor al de venta.");
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al validar los datos.");
            }
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDetalle.Rows[e.RowIndex] != null)
                {
                    DataGridViewRow fila = dgvDetalle.Rows[e.RowIndex];

                    if (fila.Cells["cantidad"].Value != null && fila.Cells["precioCompra"].Value != null && fila.Cells["precioVenta"].Value != null)
                    {
                        CalcularTotales();
                    }
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al editar registro.");
            }
        }

        private void dgvDetalle_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                CalcularTotales();
                txtBuscar.Focus();
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al eliminar registro.");
            }
        }

        #endregion

        private void iconNuevo_Click(object sender, EventArgs e)
        {
            DesbloquearControles();
        }

        private void iconGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                errorIcono.Clear();

                if (dgvDetalle.Rows.Count == 0)
                {
                    mensaje.mensajeValidacion("Debe agregar al menos un producto al carrito.");
                    return;
                }

                if (!decimal.TryParse(lblSubtotal.Text.Trim(), out decimal subTotal))
                {
                    mensaje.mensajeError("No se pudo obtener el subtotal. Verifique que es un valor válido.");
                    return;
                }

                if (!decimal.TryParse(lblImpuesto.Text.Trim(), out decimal impuesto))
                {
                    mensaje.mensajeError("No se pudo obtener el impuesto. Verifique que es un valor válido.");
                    return;
                }

                if (!decimal.TryParse(lblTotal.Text.Trim(), out decimal total) && total <= 0)
                {
                    mensaje.mensajeError("El total de la venta debe ser mayor a cero.");
                    return;
                }

                oCompra compra = new oCompra()
                {
                    numeroFactura = txtFacturaCompra.Text.Trim(),
                    fechaCompra = dtpFechaCompra.Value.Date,
                    observacion = txtObservacion.Text.Trim(),
                    subTotal = subTotal,
                    impuesto = impuesto,
                    totalGeneral = total,
                    idUsuario = Variables.idUsuario,
                    detalleCompra = detalleCompra
                };

                var resultado = bCompra.registrarCompra(compra);

                if (!resultado.esValido)
                {
                    mensaje.mensajeValidacion(resultado.mensaje);

                    if(!string.IsNullOrWhiteSpace(resultado.campoInvalido))
                    {
                        errorControl(resultado.campoInvalido);
                    }

                    return;
                }

                mensaje.mensajeOk(resultado.mensaje);
                BloquearControles();

            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al guardar el registro.");
            }
        }

        private void txtBuscar_IconLeftClick(object sender, EventArgs e)
        {
            frmBuscarProductos frm = new frmBuscarProductos(frmBuscarProductos.tipoFormulario.compra);
            frm.Owner = this;

            //Obtener la posición del gunaProducto
            Point ubicacion = gunaDetalleCompra.PointToScreen(Point.Empty);

            // Mover formulario buscar producto
            int x = ubicacion.X + gunaDetalleCompra.Width - frm.Width;
            int y = ubicacion.Y + gunaDetalleCompra.Height - frm.Height;

            frm.Location = new Point(x, y);

            mostrarModal.MostrarConCapaTransparente(this, frm);
        }

        private void frmCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtBuscar_IconLeftClick(sender, e);
            }

            if (e.KeyCode == Keys.F12)
            {
                iconGuardar_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                iconNuevo_Click(sender, e);
            }
        }
    }
}
