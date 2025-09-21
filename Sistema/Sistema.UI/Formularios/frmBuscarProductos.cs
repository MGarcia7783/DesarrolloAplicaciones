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
    public partial class frmBuscarProductos : Form
    {
        private Mensajes mensaje = new Mensajes();

        public frmBuscarProductos(tipoFormulario invocador)
        {
            InitializeComponent();

            formularioInvocador = invocador;
        }

        private void iconSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Métodos

        public enum tipoFormulario
        {
            venta,
            compra
        } 

        public tipoFormulario formularioInvocador {  get; set; }

        private void listarProductos()
        {
            try
            {
                if(formularioInvocador == tipoFormulario.venta)
                {
                    dgvListado.DataSource = bProducto.listarProductos();

                    dgvListado.Columns[0].Visible = false;
                    dgvListado.Columns[4].Visible = false;
                    dgvListado.Columns[6].Visible = false;
                    dgvListado.Columns[9].Visible = false;
                    dgvListado.Columns[10].Visible = false;
                    dgvListado.Columns[11].Visible = false;
                    dgvListado.Columns[12].Visible = false;
                    dgvListado.Columns[13].Visible = false;
                }
                else if(formularioInvocador == tipoFormulario.compra)
                {
                    dgvListado.DataSource = bProducto.listarTodosProductos();

                    dgvListado.Columns[0].Visible = false;
                    dgvListado.Columns[3].Visible = false;
                    dgvListado.Columns[4].Visible = false;
                    dgvListado.Columns[9].Visible = false;
                    dgvListado.Columns[10].Visible = false;
                    dgvListado.Columns[11].Visible = false;
                    dgvListado.Columns[12].Visible = false;
                    dgvListado.Columns[13].Visible = false;
                }

                if(dgvListado.Rows.Count > 0)
                {
                    panelVacio.Visible = false;
                    txtBuscar.Enabled = true;
                }
                else
                {
                    panelVacio.Visible = true;
                    txtBuscar.Enabled = false;
                }
                
                txtBuscar.Focus();
            }

            catch (Exception)
            {
                mensaje.mensajeError("Error al cargar registros.");
            }
        }

        private void BuscarProducto(string nombreProducto)
        {
            try
            {
                dgvListado.DataSource = bProducto.buscarProducto(1, nombreProducto);
                if (dgvListado.Rows.Count > 0)
                {
                    panelVacio.Visible = false;
                }
                else
                {
                    panelVacio.Visible = true;
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al buscar registros.");
            }
        }

        private bool SeleccionarRegistro()
        {
            try
            {
                if(dgvListado.SelectedRows.Count > 0 && dgvListado.CurrentRow != null)
                {
                    Variables.idProducto = Convert.ToInt32(dgvListado.CurrentRow.Cells[0].Value);
                    Variables.nombreProducto = dgvListado.CurrentRow.Cells[2].Value.ToString();
                    Variables.precioCompra = Convert.ToDecimal(dgvListado.CurrentRow.Cells[6].Value);
                    Variables.precioVenta = Convert.ToDecimal(dgvListado.CurrentRow.Cells[7].Value);
                    Variables.stock = Convert.ToInt32(dgvListado.CurrentRow.Cells[8].Value);
                    Variables.impuesto = dgvListado.CurrentRow.Cells[11].Value.ToString();

                    return true;
                }
                else
                {
                    panelVacio.Visible = true;
                    return false;
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al seleccionar el registro.");
                return false;
            }
        }

        #endregion

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProducto(txtBuscar.Text.Trim());
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    bool agregarRegistro = SeleccionarRegistro();

                    if(agregarRegistro)
                    {
                        if(formularioInvocador == tipoFormulario.venta)
                        {
                            frmPedidos formularioPedido = this.Owner as frmPedidos;
                            if(formularioPedido != null)
                            {
                                formularioPedido.AgregarProductos(Variables.idProducto, Variables.nombreProducto, Variables.precioVenta, Variables.stock, Variables.impuesto);
                            }

                            e.Handled = true;
                            e.SuppressKeyPress = true;
                        }
                        else
                        {
                            frmCompra formularioCompra = this.Owner as frmCompra;
                            if (formularioCompra != null)
                            {
                                formularioCompra.AgregarProductos(Variables.idProducto, Variables.nombreProducto, 1, Variables.precioCompra, Variables.precioVenta, Variables.impuesto);
                            }

                            e.Handled = true;
                            e.SuppressKeyPress = true;
                        }
                    }
                }
            }
            catch(Exception)
            {
                mensaje.mensajeError("Error inesperado al agregar registro.");
            }
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvListado.SelectedRows.Count >= 1)
            {
                KeyEventArgs keyEventArgs = new KeyEventArgs(Keys.Enter);
                txtBuscar_KeyDown(this.txtBuscar, keyEventArgs);
            }
        }

        private void frmBuscarProductos_Load(object sender, EventArgs e)
        {
            listarProductos();
        }
    }
}
