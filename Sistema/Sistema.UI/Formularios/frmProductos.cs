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
    public partial class frmProductos : frmPlantilla
    {
        private Mensajes mensaje = new Mensajes();
        public frmProductos()
        {
            InitializeComponent();
        }

        #region Métodos

        private void listarTodosProducto()
        {
            try
            {
                dgvListado.DataSource = bProducto.listarTodosProductos();
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
                dgvListado.Columns[3].Visible = false;
                dgvListado.Columns[4].Visible = false;
                dgvListado.Columns[9].Visible = false;
                dgvListado.Columns[10].Visible = false;
                dgvListado.Columns[11].Visible = false;
                dgvListado.Columns[12].Visible = false;

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
                string codigo = dgvListado.Rows[filaSeleccionada].Cells["CODIGO"].Value?.ToString();
                string producto = dgvListado.Rows[filaSeleccionada].Cells["PRODUCTO"].Value?.ToString();
                string formatoCompra = dgvListado.Rows[filaSeleccionada].Cells["FORMATO"].Value?.ToString();
                string categoria = dgvListado.Rows[filaSeleccionada].Cells["CATEGORIA"].Value?.ToString();
                string laboratorio = dgvListado.Rows[filaSeleccionada].Cells["LABORATORIO"].Value?.ToString();

                int stock = Convert.ToInt32(dgvListado.Rows[filaSeleccionada].Cells["STOCK"].Value);
                int stockMinimo = Convert.ToInt32(dgvListado.Rows[filaSeleccionada].Cells["MINIMO"].Value);

                string ventaReceta = dgvListado.Rows[filaSeleccionada].Cells["RECETA"].Value?.ToString();
                string grabaImpuesto = dgvListado.Rows[filaSeleccionada].Cells["IMPUESTO"].Value?.ToString();

                decimal precioCompra = Convert.ToDecimal(dgvListado.Rows[filaSeleccionada].Cells["P_COMPRA"].Value);
                decimal precioVenta = Convert.ToDecimal(dgvListado.Rows[filaSeleccionada].Cells["P_VENTA"].Value);

                bool conVencimiento = Convert.ToBoolean(dgvListado.Rows[filaSeleccionada].Cells["tieneVencimiento"].Value);

                DateTime? fechaVencimiento = null;

                if(conVencimiento)
                {
                    var fecha = dgvListado.Rows[filaSeleccionada].Cells["VENCIMIENTO"].Value;
                    if(fecha != null && DateTime.TryParse(fecha.ToString(), out DateTime tempFecha))
                    {
                        fechaVencimiento = tempFecha;  
                    }
                }

                bool impuesto = grabaImpuesto.Trim() == "G";


                AgregarProducto frm = new AgregarProducto(id, codigo, impuesto, producto, formatoCompra, categoria, laboratorio, stock, stockMinimo, ventaReceta, precioCompra, precioVenta, conVencimiento, fechaVencimiento);
                frm.registroAgregado += listarTodosProducto; ;
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
                    string resultado = bProducto.eliminarProducto(id);

                    if (resultado.Contains("éxito"))
                    {
                        mensaje.mensajeOk(resultado);
                    }
                    else
                    {
                        mensaje.mensajeInformacion(resultado);
                    }

                    listarTodosProducto();
                }
            }

            catch (Exception)
            {
                mensaje.mensajeError("Error al eliminar el registro.");
            }
        }
        #endregion

        #region Eventos del Formulario

        private void frmProductos_Load(object sender, EventArgs e)
        {
            listarTodosProducto();
        }


        #endregion

        private void iconAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto frm = new AgregarProducto();
            frm.registroAgregado += listarTodosProducto;
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = bProducto.buscarTodosProducto(1, txtBuscar.Text.Trim());
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
