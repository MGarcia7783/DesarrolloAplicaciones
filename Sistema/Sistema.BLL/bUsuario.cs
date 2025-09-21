using Sistema.DAL;
using Sistema.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.BLL
{
    public class bUsuario
    {
        private static readonly dUsuario usuarioDal = new dUsuario();

        public static DataTable listarUsuario()
        {
            try
            {
                return usuarioDal.listarUsuario();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar registros.");
            }
        }

        public static DataTable buscarUsuario(string nombre)
        {
            try
            {
                return usuarioDal.buscarUsuario(nombre);
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al buscar registros.");
            }
        }

        public static DataTable listarRol()
        {
            try
            {
                return usuarioDal.listarRol();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar registros.");
            }
        }

        private static resultadoOperacion validarUsuario(oUsuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.dniUsuario))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese la identificación del usuario.",
                    campoInvalido = "dniUsuario"
                };

            if (string.IsNullOrWhiteSpace(usuario.nombreUsuario))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el nombre del usuario.",
                    campoInvalido = "nombreUsuario"
                };

            if (string.IsNullOrWhiteSpace(usuario.codigoUsuario))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el código del usuario.",
                    campoInvalido = "codigoUsuario"
                };

            if (string.IsNullOrWhiteSpace(usuario.email))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el email del usuario.",
                    campoInvalido = "email"
                };

            if (!Validar.emailValido(usuario.email))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "El email no tiene el formato correcto.",
                    campoInvalido = "email"
                };

            if (usuario.idRol == 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Seleccione un rol de usuario válido.",
                    campoInvalido = "idRol"
                };

            if (string.IsNullOrWhiteSpace(usuario.clave))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese la contraseña del usuario.",
                    campoInvalido = "clave"
                };

            if (!Validar.claveSegura(usuario.clave))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "La contraseña debe tener al menos 6 caracteres, una mayúscula, una minúscula y un número.",
                    campoInvalido = "clave"
                };

            return new resultadoOperacion { esValido = true };
        }

        public static resultadoOperacion registrarUsuario(oUsuario usuario)
        {
            var validacion = validarUsuario(usuario);
            if (!validacion.esValido)
                return validacion;

            try
            {
                bool resultado = usuarioDal.registrarUsuario(usuario);

                if (resultado)
                {
                    return new resultadoOperacion
                    {
                        esValido = true,
                        mensaje = "Registro almacenado satisfactoriamente."
                    };
                }
                else
                {
                    return new resultadoOperacion
                    {
                        esValido = false,
                        mensaje = "No se puedo crear el registro. Verfique los datos."
                    };
                }
            }

            catch (Exception)
            {
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ocurrió un error inesperado al guardar el registro."
                };
            }
        }

        public static resultadoOperacion editarUsuario(oUsuario usuario)
        {
            var validacion = validarUsuario(usuario);
            if (!validacion.esValido)
                return validacion;

            try
            {
                bool resultado = usuarioDal.editarUsuario(usuario);

                if (resultado)
                {
                    return new resultadoOperacion
                    {
                        esValido = true,
                        mensaje = "Registro actualizado satisfactoriamente."
                    };
                }
                else
                {
                    return new resultadoOperacion
                    {
                        esValido = false,
                        mensaje = "No se puedo editar el registro. Verfique los datos."
                    };
                }
            }

            catch (Exception)
            {
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ocurrió un error inesperado al editar el registro."
                };
            }
        }
        public static string eliminarUsuario(int idUsuario)
        {
            if (idUsuario <= 0)
                return "Debe especificar un registro válido";

            try
            {
                bool resultado = usuarioDal.eliminarUsuario(idUsuario);

                if (resultado)
                {
                    return "Registro eliminado con éxito.";
                }
                else
                {
                    return "No se puedo eliminar el registro.";
                }
            }

            catch (Exception)
            {
                throw new ApplicationException("Error inesperado al eliminar el registro.");
            }
        }

    }
}
