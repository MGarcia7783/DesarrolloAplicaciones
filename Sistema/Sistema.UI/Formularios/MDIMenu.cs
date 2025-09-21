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
    public partial class MDIMenu : Form
    {
        public static bool confirmarSalir = false;
        private Mensajes mensaje = new Mensajes();
        private Form formularioActivo = null;
        public MDIMenu()
        {
            InitializeComponent();
        }

        #region Métodos

        private void centrarEtiquetas()
        {
            try
            {
                var anchoContenedor = panelContenedor.ClientSize.Width;
                var altoContenedor = panelContenedor.ClientSize.Height;

                int espacioEntreLabels = 10;
                int altoTotal = lblTitulo.Height + espacioEntreLabels + lblEmpresa.Height;

                int topInicial = (altoContenedor - altoTotal) / 2;

                lblTitulo.Top = topInicial;
                lblTitulo.Left = (anchoContenedor - lblTitulo.Width) / 2;

                lblEmpresa.Top = lblTitulo.Bottom + espacioEntreLabels;
                lblEmpresa.Left = (anchoContenedor - lblEmpresa.Width) / 2;
            }

            catch(Exception)
            {

            }
        }

        private void AbrirFormulario(Form formularioHijo, bool esHijoDelPanelContenedor = true)
        {
            try
            {
                // Si el formulario debe ser hijo del panelContenedor
                if (esHijoDelPanelContenedor)
                {
                    // Si hay un formulario activo, lo cerramos
                    if (formularioActivo != null)
                    {
                        formularioActivo.Close();
                    }

                    // Configuramos el nuevo formulario como hijo
                    formularioActivo = formularioHijo;
                    formularioHijo.TopLevel = false;
                    formularioHijo.FormBorderStyle = FormBorderStyle.None;
                    formularioHijo.Dock = DockStyle.Fill;

                    // Añadimos el formulario al panel contenedor
                    panelContenedor.Controls.Add(formularioHijo);
                    panelContenedor.Tag = formularioHijo;
                    formularioHijo.BringToFront();

                    formularioHijo.Show();
                }
                else
                {
                    // Si no debe ser hijo, lo configuramos como un formulario independiente
                    formularioHijo.TopLevel = true;
                    formularioHijo.FormBorderStyle = FormBorderStyle.Sizable; // Permite redimensionar

                    formularioHijo.ShowDialog();
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Se ha generado un error inesperado al cargar el formulario.");
            }
        }

        private void buscarCaja()
        {
            try
            {
                var cajaAbierta = bCaja.buscarCaja(Variables.idUsuario);
                if (cajaAbierta.Rows.Count == 0)
                {
                    frmAbirCaja frm = new frmAbirCaja(true);
                    mostrarModal.MostrarConCapaTransparente(this, frm);
                    toolCaja.Text = "Caja: " + Variables.idCaja;
                }
                else
                {
                    toolCaja.Text = "Caja: " + cajaAbierta.Rows[0]["CAJA"].ToString();
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Ocurrió un error al verificar el estado de la caja.");
            }
        }

        #endregion

        #region Eventos del Formulario

        private void MDIMenu_Load(object sender, EventArgs e)
        {
            centrarEtiquetas();
            buscarCaja();
        }

        private void MDIMenu_Resize(object sender, EventArgs e)
        {
            centrarEtiquetas();
        }


        #endregion

        private void MDIMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!confirmarSalir)
            {
                if(mensaje.mensajeConfirmacion("¿Seguro que desea salir del sistema?") == DialogResult.OK)
                {
                    confirmarSalir = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #region Opciones del Menú

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmPedidos(), true);
        }

        private void listadoDeLaboratoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmLaboratorio(), true);
        }

        private void listadoDeCategoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmCategorias(), true);
        }

        private void listadoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmProductos(), true);
        }

        private void aperturaDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbirCaja frm = new frmAbirCaja(false);
            mostrarModal.MostrarConCapaTransparente(this, frm);
        }

        private void historialDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmHistorialPedidos(), true);
        }

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCerrarCaja frm = new frmCerrarCaja();
            mostrarModal.MostrarConCapaTransparente(this, frm);
        }

        private void cierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListarCierreCaja(), true);
        }


        #endregion

    }
}
