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

        #endregion

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
                else
                {
                    mensaje.mensajeInformacion("No existe una caja abierta para este usuario.");
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
                iconNuevo.Enabled = true;
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

        #region Botones de comando

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconGuardar_Click(object sender, EventArgs e)
        {
            frmTerminarPedido frm = new frmTerminarPedido();
            mostrarModal.MostrarConCapaTransparente(this, frm);
        }

        private void txtBuscar_IconLeftClick(object sender, EventArgs e)
        {
            frmBuscarProductos frm = new frmBuscarProductos();
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
            MessageBox.Show("Nuevo Registro");
        }

        private void iconImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Imprimir Registro");
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


        #endregion

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
                        int.TryParse(lblId.Text.Trim(), out int stock);
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
    }
}
