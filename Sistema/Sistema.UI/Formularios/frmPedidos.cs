using Sistema.BLL;
using Sistema.Entity;
using Sistema.UI.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.UI.Formularios
{
    public partial class frmPedidos : Form
    {
        private DataTable detalleVenta = new DataTable();
        private Mensajes mensaje = new Mensajes();  

        public frmPedidos()
        {
            InitializeComponent();
        }

        #region Métodos

        private void CrearTabla()
        {
            try
            {
                detalleVenta.Columns.Add("idProducto", System.Type.GetType("System.Int32"));
                detalleVenta.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
                detalleVenta.Columns.Add("nombreProducto", System.Type.GetType("System.String"));
                detalleVenta.Columns.Add("precio", System.Type.GetType("System.Decimal"));
                detalleVenta.Columns.Add("stock", System.Type.GetType("System.Int32"));
                detalleVenta.Columns.Add("impuesto", System.Type.GetType("System.String"));

                dgvDetalle.DataSource = detalleVenta;
                FormatoTabla();
            }
            catch (Exception)
            {
                mensaje.mensajeError("Errro al crear el DataTable.");
            }
        }

        private void FormatoTabla()
        {
            dgvDetalle.Columns[0].Visible = false;
            dgvDetalle.Columns[1].HeaderText = "CANT";
            dgvDetalle.Columns[2].HeaderText = "PRODUCTO";
            dgvDetalle.Columns[3].HeaderText = "PRECIO";
            dgvDetalle.Columns[4].Visible = false;
            dgvDetalle.Columns[5].Visible = false;

            dgvDetalle.Columns["precio"].DefaultCellStyle.Format = "N2";

            dgvDetalle.Columns["nombreProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvDetalle.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   
            dgvDetalle.Columns["PRECIO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetalle.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["PRECIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetalle.Columns[2].ReadOnly = true;
            dgvDetalle.Columns[3].ReadOnly = true;
        }

        private void AjustarColumnas()
        {
            try
            {
                if (detalleVenta.Columns.Count == 0)
                    return;

                int anchodisponible = dgvDetalle.ClientSize.Width;

                int anchoCant = 120;
                int anchoPrecio = 200;

                int anchoProducto = anchodisponible - (anchoCant + anchoPrecio + 20);

                dgvDetalle.Columns["cantidad"].Width = anchoCant;
                dgvDetalle.Columns["nombreProducto"].Width = anchoProducto;
                dgvDetalle.Columns["precio"].Width = anchoPrecio;

            }
            catch(Exception)
            {
                mensaje.mensajeError("Ocurrió un error al ajustar el diseño del DataGridView.");
            }
        }

        private void BuscarProducto()
        {
            try
            {
                var producto = bProducto.buscarProducto(0, txtBuscar.Text.Trim());
                if (producto.Rows.Count > 0)
                {
                    lblId.Text = producto.Rows[0]["ID"].ToString();
                    lblProducto.Text = producto.Rows[0]["PRODUCTO"].ToString();
                    lblPrecioNumero.Text = Convert.ToDecimal(producto.Rows[0]["P_VENTA"]).ToString("N2");
                    lblRecetaNumero.Text = producto.Rows[0]["RECETA"].ToString();
                    lblStock.Text = producto.Rows[0]["STOCK"].ToString();
                    lblGrabaImpuesto.Text = producto.Rows[0]["IMPUESTO"].ToString();

                    lblDetalle.Visible = true;
                    lblProducto.Visible = true;
                    lblPrecio.Visible = true;
                    lblPrecioNumero.Visible = true;
                    lblRecetaNumero.Visible = true;
                    lblReceta.Visible = true;
                    lblStockTitulo.Visible = true;
                    lblStock.Visible = true;
                    txtBuscar.Focus();
                }
                else
                {
                    LimpiarControles();
                }
            }
            catch(Exception)
            {
                mensaje.mensajeError("Error al buscar el producto.");
            }
        }

        private void LimpiarControles()
        {
            lblId.Text = "0";
            lblProducto.Text = "";
            lblStock.Text = "0";
            lblPrecioNumero.Text = "0";

            lblDetalle.Visible = false;
            lblProducto.Visible = false;
            lblPrecio.Visible = false;
            lblPrecioNumero.Visible = false;
            lblRecetaNumero.Visible = false;
            lblReceta.Visible = false;
            lblStockTitulo.Visible = false;
            lblStock.Visible = false;
            txtBuscar.Focus();
        }

        private void buscarCaja()
        {
            try
            {
                var cajaAbierta = bCaja.buscarCaja(Variables.idUsuario);
                if (cajaAbierta != null && cajaAbierta.Rows.Count > 0)
                {
                    var id = cajaAbierta.Rows[0]["ID"];
                    if(id != DBNull.Value)
                    {
                        Variables.idCaja = Convert.ToInt32(id);
                    }
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error alobtener la caja disponible.");
            }
        }

        public void AgregarProductos(int idProducto, string producto, decimal precio, int stock, string impuesto)
        {
            try
            {
                bool registroDuplicado = false;

                foreach (DataGridViewRow fila in dgvDetalle.Rows)
                {
                    if (fila.Cells["idProducto"].Value != null  && Convert.ToInt32(fila.Cells["idProducto"].Value) == idProducto)
                    {
                        mensaje.mensajeInformacion("El producto ya se encuentra en la lista.");
                        registroDuplicado = true;
                        break;
                    }
                }

                if(!registroDuplicado)
                {
                    DataRow nuevaFila = detalleVenta.NewRow();
                    nuevaFila["idProducto"] = idProducto;
                    nuevaFila["cantidad"] = 1;
                    nuevaFila["nombreProducto"] = producto;
                    nuevaFila["precio"] = precio;
                    nuevaFila["stock"] = stock;
                    nuevaFila["impuesto"] = impuesto;
                    detalleVenta.Rows.Add(nuevaFila);
                }

                LimpiarControles();
                iconGuardar.Enabled = true;
                CalcularTotales();

                txtBuscar.Focus();


            }
            catch(Exception)
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

                foreach(DataRow fila in detalleVenta.Rows)
                {
                    int cantidad = Convert.ToInt32(fila["cantidad"]);
                    decimal precio = Convert.ToDecimal(fila["precio"]);
                    string impuesto = fila["impuesto"].ToString();

                    decimal totalFila = cantidad * precio;

                    if(impuesto == "G")
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
            catch(Exception)
            {
                mensaje.mensajeError("Error al calcular totales.");
            }
        }

        private void Txt_KeyPressCantidad(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox txt)
                Utilidades.numerosEnteros(e, txt.Text);
        }

        private void BloquearControles()
        {
            gunaCarrito.Enabled = false;
            gunaProducto.Enabled = false;
            iconGuardar.Enabled = false;
            iconImprimir.Enabled = true;
            iconNuevo.Enabled = true;
        }

        private void DesbloquearControles()
        {
            gunaCarrito.Enabled = true;
            gunaProducto.Enabled = true;
            iconGuardar.Enabled = true;
            iconImprimir.Enabled = false;
            iconNuevo.Enabled = false;
            detalleVenta.Clear();
            lblSubtotal.Text = "0.00";
            lblImpuesto.Text = "0.00";
            lblTotal.Text = "0.00";

            Variables.terminarVenta = 0;
            Variables.numeroPedido = "";

            txtBuscar.Focus();
        }

        private void imprimirVoucher(object sender, PrintPageEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;

                // === Fuentes ===
                Font fontTitulo = new Font("Consolas", 11, FontStyle.Bold);
                Font fontNormal = new Font("Consolas", 9);
                Font fontNegrita = new Font("Consolas", 9, FontStyle.Bold);

                // === Formatos ===
                StringFormat formatoDerecha = new StringFormat { Alignment = StringAlignment.Far };
                StringFormat formatoCentro = new StringFormat { Alignment = StringAlignment.Center };

                // === Coordenadas base ===
                float y = 20;
                float lineHeight = fontNormal.GetHeight();
                float etiquetaX = 80f;
                float precioX = 150f;
                float columnaEtiquetaAncho = 80f;
                float anchoVoucher = 280f;

                // === ENCABEZADO ===
                RectangleF rect = new RectangleF(0, y, anchoVoucher, lineHeight);
                g.DrawString("FARMACIA LA PREFERIDA", fontTitulo, Brushes.Black, rect, formatoCentro); y += lineHeight + 10;

                rect = new RectangleF(0, y, anchoVoucher, lineHeight);
                g.DrawString("Tel: 2266-0000", fontNormal, Brushes.Black, rect, formatoCentro); y += lineHeight;

                rect = new RectangleF(0, y, anchoVoucher, lineHeight);
                g.DrawString("RUC: 0011223344", fontNormal, Brushes.Black, rect, formatoCentro); y += lineHeight + 5;

                g.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal, Brushes.Black, 10, y); y += lineHeight;
                g.DrawString("N° Pedido: " + Variables.numeroPedido, fontNormal, Brushes.Black, 10, y); y += lineHeight + 5;

                // === Separadores ===
                g.DrawString(new string('-', 40), fontNormal, Brushes.Black, 0, y); y += lineHeight;
                g.DrawString("Detalle de la venta", fontNormal, Brushes.Black, 10, y); y += lineHeight;
                g.DrawString(new string('-', 40), fontNormal, Brushes.Black, 0, y); y += lineHeight;

                // === DETALLE DE PRODUCTOS ===
                foreach (DataGridViewRow fila in dgvDetalle.Rows)
                {
                    if (fila.IsNewRow) continue;

                    int cantidad = Convert.ToInt32(fila.Cells["cantidad"].Value);
                    string producto = fila.Cells["nombreProducto"].Value?.ToString() ?? "";
                    decimal precio = Convert.ToDecimal(fila.Cells["precio"].Value);
                    string impuesto = fila.Cells["impuesto"].Value?.ToString() ?? "E";

                    if (producto.Length > 15)
                        producto = producto.Substring(0, 15);

                    string linea = $"{cantidad,3}  {producto,-15} {precio,15} {impuesto,-1}";
                    g.DrawString(linea, fontNormal, Brushes.Black, 0, y);
                    y += lineHeight;
                }

                // === TOTALES ===
                y += 10;
                g.DrawString(new string('-', 40), fontNormal, Brushes.Black, 0, y); y += lineHeight;

                g.DrawString("SUBTOTAL:", fontNormal, Brushes.Black, etiquetaX + columnaEtiquetaAncho, y, formatoDerecha);
                g.DrawString(lblSubtotal.Text.PadLeft(15), fontNormal, Brushes.Black, precioX, y); y += lineHeight;

                g.DrawString("IMPUESTO:", fontNormal, Brushes.Black, etiquetaX + columnaEtiquetaAncho, y, formatoDerecha);
                g.DrawString(lblImpuesto.Text.PadLeft(15), fontNormal, Brushes.Black, precioX, y); y += lineHeight;

                g.DrawString("TOTAL:", fontNegrita, Brushes.Black, etiquetaX + columnaEtiquetaAncho, y, formatoDerecha);
                g.DrawString(lblTotal.Text.PadLeft(15), fontNegrita, Brushes.Black, precioX, y); y += lineHeight;

                string Efectivo = Convert.ToDecimal(Variables.montoEfectivo).ToString("N2").PadLeft(15);
                string Tarjeta = Convert.ToDecimal(Variables.montoTarjeta).ToString("N2").PadLeft(15);
                string Cambio = Convert.ToDecimal(Variables.cambio).ToString("N2").PadLeft(15);

                g.DrawString("EFECTIVO:", fontNormal, Brushes.Black, etiquetaX + columnaEtiquetaAncho, y, formatoDerecha);
                g.DrawString(Efectivo, fontNormal, Brushes.Black, precioX, y); y += lineHeight;

                g.DrawString("TARJETA:", fontNormal, Brushes.Black, etiquetaX + columnaEtiquetaAncho, y, formatoDerecha);
                g.DrawString(Tarjeta, fontNormal, Brushes.Black, precioX, y); y += lineHeight;

                g.DrawString("CAMBIO:", fontNegrita, Brushes.Black, etiquetaX + columnaEtiquetaAncho, y, formatoDerecha);
                g.DrawString(Cambio, fontNegrita, Brushes.Black, precioX, y); y += lineHeight + 20;

                // === MENSAJE FINAL CENTRADO ===
                rect = new RectangleF(0, y, anchoVoucher, lineHeight);
                g.DrawString("Gracias por su compra", fontNormal, Brushes.Black, rect, formatoCentro); y += lineHeight;

                rect = new RectangleF(0, y, anchoVoucher, lineHeight);
                g.DrawString("¡Vuelva pronto!", fontNormal, Brushes.Black, rect, formatoCentro);
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al imprimir el voucher.");
            }
        }


        #endregion

        #region Botones de comando

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Variables.idCaja == 0)
                {
                    mensaje.mensajeInformacion("Es necesario aperturar la caja para continuar.");
                    return;
                }

                if (dgvDetalle.Rows.Count == 0)
                {
                    mensaje.mensajeValidacion("Debe agregar al menos un producto al carrito de compra.");
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

                frmTerminarPedido frm = new frmTerminarPedido(total);
                mostrarModal.MostrarConCapaTransparente(this, frm);

                if(Variables.terminarVenta == 1)
                {
                    oPedido pedido = new oPedido()
                    {
                        idUsuario = Variables.idUsuario,
                        idCaja = Variables.idCaja,
                        subTotal = subTotal,
                        impuesto = impuesto,
                        totalGeneral = total,
                        montoEfectivo = Variables.montoEfectivo,
                        montoTarjeta = Variables.montoTarjeta,
                        cambio = Variables.cambio,
                        detalles = detalleVenta
                    };

                    var resultado = bPedido.registrarPedido(pedido);

                    if(!resultado.esValido)
                    {
                        mensaje.mensajeValidacion(resultado.mensaje);
                        return;
                    }

                    Variables.numeroPedido = resultado.numeroPedido;

                    iconImprimir_Click(this, EventArgs.Empty);
                    BloquearControles();

                    Variables.montoEfectivo = 0;
                    Variables.montoTarjeta = 0;
                    Variables.cambio = 0;
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al guardar el registro.");
            }




        }

        private void txtBuscar_IconLeftClick(object sender, EventArgs e)
        {
            frmBuscarProductos frm = new frmBuscarProductos(frmBuscarProductos.tipoFormulario.venta);
            frm.Owner = this;

            //Obtener la posición del gunaProducto
            Point ubicacion = gunaProducto.PointToScreen(Point.Empty);
            
            // Mover formulario buscar producto
            int x = ubicacion.X + gunaProducto.Width - frm.Width;
            int y = ubicacion.Y + gunaProducto.Height - frm.Height;

            frm.Location = new Point(x, y);

            mostrarModal.MostrarConCapaTransparente(this, frm);
        }

        private void iconNuevo_Click(object sender, EventArgs e)
        {
            DesbloquearControles();
        }

        private void iconImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();

                // Crear el documento
                printDoc = new PrintDocument();

                // Altura dinámica
                int filas = dgvDetalle.Rows.Count;
                int altoBase = 300;
                int altoPorFila = 40;
                int alturaFinal = altoBase + (filas * altoPorFila);

                // Configurar tamaño de papel personalizado
                PaperSize papel = new PaperSize("Voucher", 280, alturaFinal);
                printDoc.DefaultPageSettings.PaperSize = papel;

                // Asignar el evento
                printDoc.PrintPage += imprimirVoucher;

                // Mostrar vista previa centrada
                PrintPreviewDialog preview = new PrintPreviewDialog
                {
                    Document = printDoc,
                    Width = 400,
                    Height = 600,
                    StartPosition = FormStartPosition.CenterScreen
                };

                // Zoom 100%
                foreach (Control c in preview.Controls)
                {
                    if (c is PrintPreviewControl ctrl)
                    {
                        ctrl.AutoZoom = true;
                        break;
                    }
                }

                preview.ShowDialog();
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al mostrar vista previa.");
            }

        }

        #endregion

        #region Eventos del Formulario

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            CrearTabla();
            buscarCaja();
        }

        private void frmPedidos_Resize(object sender, EventArgs e)
        {
            AjustarColumnas();
        }

        private void frmPedidos_Shown(object sender, EventArgs e)
        {
            AjustarColumnas();
        }

        private void frmPedidos_KeyDown(object sender, KeyEventArgs e)
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

            if (e.Control && e.KeyCode == Keys.P)
            {
                iconImprimir_Click(sender, e);
            }
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
                if(e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    if(lblId.Text.Trim() != "0")
                    {
                        int.TryParse(lblId.Text.Trim(), out int idProducto);
                        string producto = lblProducto.Text.Trim();
                        decimal.TryParse(lblPrecioNumero.Text.Trim(), out decimal precio);
                        int.TryParse(lblStock.Text.Trim(), out int stock);
                        string grabaImpuesto = lblGrabaImpuesto.Text.Trim();

                        AgregarProductos(idProducto, producto, precio, stock, grabaImpuesto);
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
                if(dgvDetalle.CurrentCell.ColumnIndex == 1 && e.Control is TextBox txt)
                {
                    txt.KeyPress -= Txt_KeyPressCantidad;
                    txt.KeyPress += Txt_KeyPressCantidad;
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
                if (dgvDetalle.Columns[e.ColumnIndex].Name == "cantidad")
                {
                    if(string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                    {
                        mensaje.mensajeError("La cantidad debe ser un número entero mayor a cero.");
                        e.Cancel = true;
                    }
                    else
                    {
                        int cantidad = int.Parse(e.FormattedValue.ToString());
                        int stockDisponible = Convert.ToInt32(dgvDetalle.CurrentRow.Cells["stock"].Value);
                        if(cantidad > stockDisponible)
                        {
                            mensaje.mensajeInformacion($"La cantidad no puede ser mayor al stock: {stockDisponible}.");
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch(Exception)
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

                    if (fila.Cells["cantidad"].Value != null && fila.Cells["precio"].Value != null)
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
    }
}
