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
    public partial class frmAgregarLaboratorio : Form
    {
        private Mensajes mensaje = new Mensajes();
        public event Action registroAgregado;
        Boolean actualizarRegistro = false;
        public frmAgregarLaboratorio()
        {
            InitializeComponent();

            this.KeyPress += Utilidades.PasarFocus;
            this.KeyDown += Utilidades.ControlEsc;
        }

        public frmAgregarLaboratorio(int id, string laboratorio, string email, string telefono, string contacto)
        {
            InitializeComponent();

            this.KeyPress += Utilidades.PasarFocus;
            this.KeyDown += Utilidades.ControlEsc;

            txtId.Text = id.ToString();
            txtLaboratorio.Text = laboratorio;
            txtEmail.Text = email;
            txtTelefono.Text = telefono;
            txtContacto.Text = contacto;

            actualizarRegistro = true;
        }

        #region Métodos

        private void errorControl(string campo)
        {
            switch(campo)
            {
                case "nombreLaboratorio":
                    errorIcono.SetError(txtLaboratorio, "Este campo es obligatorio.");
                    txtLaboratorio.Focus();
                    break;
                case "email":
                    errorIcono.SetError(txtEmail, "Este campo es obligatorio.");
                    txtEmail.Focus();
                    break;
                case "telefono":
                    errorIcono.SetError(txtTelefono, "Este campo es obligatorio.");
                    txtTelefono.Focus();
                    break;
                case "contacto":
                    errorIcono.SetError(txtContacto, "Este campo es obligatorio.");
                    txtContacto.Focus();
                    break;
            }
        }

        private void LimpiarControles()
        {
            txtId.Text = "0";
            txtLaboratorio.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtContacto.Clear();
            txtLaboratorio.Focus();
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

                oLaboratorio laboratorio = new oLaboratorio()
                {
                    nombreLaboratorio = txtLaboratorio.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    telefono = txtTelefono.Text.Trim(),
                    contacto = txtContacto.Text.Trim()
                };

                resultadoOperacion resultado;

                if(int.TryParse(txtId.Text.Trim(), out int Id) && Id == 0)
                {
                    resultado = bLaboratorio.registrarLaboratorio(laboratorio);
                }
                else
                {
                    laboratorio.idLaboratorio = Id;
                    resultado = bLaboratorio.editarLaboratorio(laboratorio);
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
