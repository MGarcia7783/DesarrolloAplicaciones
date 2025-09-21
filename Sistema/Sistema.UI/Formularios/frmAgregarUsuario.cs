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
    public partial class frmAgregarUsuario : Form
    {
        private Mensajes mensaje = new Mensajes();
        private Utilidades utilidades = new Utilidades();   
        public event Action registroAgregado;
        Boolean actualizarRegistro = false;

        public frmAgregarUsuario()
        {
            InitializeComponent();

            CargarRoles();
            cboRol.SelectedIndex = 0;

            this.KeyPress += Utilidades.PasarFocus;
            this.KeyDown += Utilidades.ControlEsc;
        }

        public frmAgregarUsuario(int id, string dniUsuario, string nombreUsuario, string codigoUsuario, string email, string rol)
        {
            try
            {
                InitializeComponent();

                this.KeyPress += Utilidades.PasarFocus;
                this.KeyDown += Utilidades.ControlEsc;

                CargarRoles();

                txtId.Text = id.ToString();
                txtIdentificacion.Text = dniUsuario;
                txtUsuario.Text = nombreUsuario;
                txtCodigo.Text = codigoUsuario;
                txtEmail.Text = email;
                cboRol.Text = rol;

                actualizarRegistro = true;
            }

            catch (Exception)
            {
                mensaje.mensajeError("Error al inicializar el formulario.");
            }
            
        }

        #region Métodos

        private void CargarRoles()
        {
            try
            {
                var usuario = bUsuario.listarRol();
                if (usuario != null && usuario.Rows.Count > 0)
                {
                    cboRol.DataSource = usuario;
                    cboRol.ValueMember = "ID";
                    cboRol.DisplayMember = "ROL";
                    cboRol.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al cargar las categorías.");
            }
        }

        private void errorControl(string campo)
        {
            switch (campo)
            {
                case "dniUsuario":
                    errorIcono.SetError(txtIdentificacion, "Este campo es obligatorio.");
                    txtIdentificacion.Focus();
                    break;
                case "nombreUsuario":
                    errorIcono.SetError(txtUsuario, "Este campo es obligatorio.");
                    txtUsuario.Focus();
                    break;
                case "codigoUsuario":
                    errorIcono.SetError(txtCodigo, "Este campo es obligatorio.");
                    txtCodigo.Focus();
                    break;
                case "email":
                    errorIcono.SetError(txtEmail, "Este campo es obligatorio.");
                    txtEmail.Focus();
                    break;
                case "idRol":
                    errorIcono.SetError(cboRol, "Este campo es obligatorio.");
                    cboRol.Focus();
                    break;
                case "clave":
                    errorIcono.SetError(txtClave, "Este campo es obligatorio.");
                    txtClave.Focus();
                    break;
            }
        }

        private void LimpiarControles()
        {
            txtId.Text = "0";
            txtIdentificacion.Clear();
            txtUsuario.Clear();
            txtCodigo.Clear();
            txtEmail.Clear();
            cboRol.SelectedIndex = 0;
            txtClave.Clear();
            txtIdentificacion.Focus();
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

                if(!int.TryParse(cboRol.SelectedValue?.ToString(), out int idRol))
                {
                    mensaje.mensajeValidacion("Debe seleccionar un rol válido.");
                    errorIcono.SetError(cboRol, "Este campo es obligatorio.");
                    cboRol.Focus();
                    return;
                }

                oUsuario laboratorio = new oUsuario()
                {
                    dniUsuario = txtIdentificacion.Text.Trim(),
                    nombreUsuario = txtUsuario.Text.Trim(),
                    codigoUsuario = txtCodigo.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    idRol = idRol,
                    clave = txtClave.Text.Trim()
                };

                resultadoOperacion resultado;

                if (int.TryParse(txtId.Text.Trim(), out int Id) && Id == 0)
                {
                    resultado = bUsuario.registrarUsuario(laboratorio);
                }
                else
                {
                    laboratorio.idUsuario = Id;
                    resultado = bUsuario.editarUsuario(laboratorio);
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
                txtIdentificacion.Focus();
            }
            catch (Exception)
            {
                mensaje.mensajeError("Ocurrió un error inesperado.");
            }
        }


        #endregion

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMostrar.Checked)
            {
                txtClave.PasswordChar = '\0'; 
            }
            else
            {
                txtClave.PasswordChar = '*';
            }
        }
    }
}
