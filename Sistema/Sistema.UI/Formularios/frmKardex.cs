using Sistema.BLL;
using Sistema.UI.Modulos;
using Sistema.UI.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.UI.Formularios
{
    public partial class frmKardex : Form
    {
        private Mensajes mensaje = new Mensajes();

        public frmKardex()
        {
            InitializeComponent();
        }

        #region Métodos

        private void BuscarKardex(string codigo, DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                string nombreProducto;

                dgvListado.DataSource = bProducto.BuscarKardex(codigo, fechaInicio, fechaFinal, out nombreProducto);
                if (dgvListado.Rows.Count == 0)
                {
                    mensaje.mensajeValidacion("No hay movimientos en el kardex para esta consulta.");
                    return;
                }

                txtProducto.Text = nombreProducto;
                iconImprimir.Enabled = true;
                FormatoTabla();
                txtCodigo.Focus();
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al buscar registros.");
            }
        }

        private void FormatoTabla()
        {
            dgvListado.Columns[0].Width = 120;
            //dgvListado.Columns[1].Width = 130;
            dgvListado.Columns[2].Width = 300;
            dgvListado.Columns[4].Width = 130;
            dgvListado.Columns[5].Width = 130;
            dgvListado.Columns[6].Width = 120;
            dgvListado.Columns[7].Width = 130;
            dgvListado.Columns[8].Width = 130;
            dgvListado.Columns[9].Width = 120;
            dgvListado.Columns[10].Width = 130;
            dgvListado.Columns[11].Width = 130;

            dgvListado.Columns["C_ENTRADA"].DefaultCellStyle.Format = "N2";
            dgvListado.Columns["T_ENTRADA"].DefaultCellStyle.Format = "N2";
            dgvListado.Columns["C_SALIDA"].DefaultCellStyle.Format = "N2";
            dgvListado.Columns["T_SALIDA"].DefaultCellStyle.Format = "N2";
            dgvListado.Columns["PROMEDIO"].DefaultCellStyle.Format = "N2";
            dgvListado.Columns["COSTO"].DefaultCellStyle.Format = "N2";
        }

        #endregion

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txtProducto.Text = "";
                dgvListado.DataSource = null;
            }

            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                try
                {
                    if(string.IsNullOrWhiteSpace(txtCodigo.Text.Trim()))
                    {
                        mensaje.mensajeValidacion("Debe ingresar el código del producto.");
                        return;
                    }

                    DateTime fechaInicial = dtpFechaInicio.Value.Date;
                    DateTime fechaFinal = dtpFechaFinal.Value.Date;

                    if(fechaInicial > fechaFinal)
                    {
                        mensaje.mensajeValidacion("La fecha de inicio no puede ser mayor que la fecha final.");
                        return;
                    }

                    BuscarKardex(txtCodigo.Text.Trim(), fechaInicial, fechaFinal);
                }

                catch (Exception)
                {
                    mensaje.mensajeError("Error al buscar registros.");
                }
            }          
        }

        #region Botones de Comando

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvListado.Rows.Count == 0)
                {
                    mensaje.mensajeInformacion("No hay registros disponibles para mostrar.");
                    return;
                }

                string codigo = txtCodigo.Text.Trim();
                string nombrePrducto;

                string fechaInicio = dtpFechaInicio.Value.Date.ToString("dd/MM/yyyy");
                string fechaFinal = dtpFechaFinal.Value.Date.ToString("dd/MM/yyyy");

                string periodo = $"Período del: {fechaInicio} al {fechaFinal}";

                DataTable datos = bProducto.BuscarKardex(codigo, dtpFechaInicio.Value.Date, dtpFechaFinal.Value.Date, out nombrePrducto);

                frmReporteKardex frm = new frmReporteKardex(datos, codigo, nombrePrducto, periodo);
                frm.ShowDialog();   
            }
            catch(Exception)
            {
                mensaje.mensajeError("Error al cargar el reporte.");
            }
        }


        #endregion

        private void frmKardex_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFinal.Value = DateTime.Now;
            txtCodigo.Focus();
        }
    }
}
