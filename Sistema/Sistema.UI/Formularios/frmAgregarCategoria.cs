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
    public partial class frmAgregarCategoria : Form
    {
        private Mensajes mensaje = new Mensajes();
        public event Action registroAgregado;
        Boolean actualizarRegistro = false;

        public frmAgregarCategoria()
        {
            InitializeComponent();

            this.KeyPress += Utilidades.PasarFocus;
            this.KeyDown += Utilidades.ControlEsc;
        }

        public frmAgregarCategoria(int idCategoria, string nombreCategoria, string descripcionCategoria)
        {
            InitializeComponent();

            this.KeyPress += Utilidades.PasarFocus;
            this.KeyDown += Utilidades.ControlEsc;

            txtId.Text = idCategoria.ToString();
            txtCategoria.Text = nombreCategoria;
            txtDescripcion.Text = descripcionCategoria;

            actualizarRegistro = true;
        }

        #region Métodos

        private void errorControl(string campo)
        {
            switch (campo)
            {
                case "nombreCategoria":
                    errorIcono.SetError(txtCategoria, "Este campo es obligatorio.");
                    txtCategoria.Focus();
                    break;
                case "descripcionCategoria":
                    errorIcono.SetError(txtDescripcion, "Este campo es obligatorio.");
                    txtDescripcion.Focus();
                    break;
            }
        }

        private void LimpiarControles()
        {
            txtId.Text = "0";
            txtCategoria.Clear();
            txtDescripcion.Clear();
            txtCategoria.Focus();
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

                oCategoria categoria = new oCategoria()
                {
                    nombreCategoria = txtCategoria.Text.Trim(),
                    descripcionCategoria = txtDescripcion.Text.Trim()
                };

                resultadoOperacion resultado;

                if (int.TryParse(txtId.Text.Trim(), out int Id) && Id == 0)
                {
                    resultado = bCategoria.registrarCategoria(categoria);
                }
                else
                {
                    categoria.idCategoria = Id;
                    resultado = bCategoria.editarCategoria(categoria);
                }

                if (!resultado.esValido)
                {
                    mensaje.mensajeValidacion(resultado.mensaje);

                    if (!string.IsNullOrWhiteSpace(resultado.campoInvalido))
                    {
                        errorControl(resultado.campoInvalido);
                    }

                    return;
                }

                mensaje.mensajeOk(resultado.mensaje);
                registroAgregado?.Invoke();
                LimpiarControles();
                if (actualizarRegistro) Close();
            }
            catch (Exception)
            {
                mensaje.mensajeError("Ocurrió un error inesperado.");
            }
        }

        #endregion


    }
}
