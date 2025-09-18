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
    public class bLaboratorio
    {
        private static readonly dLaboratorio laboratorioDal = new dLaboratorio();

        public static DataTable listarLaboratorio()
        {
            try
            {
                return laboratorioDal.listarLaboratorio();
            }
            catch(Exception)
            {
                throw new ApplicationException("Error al listar registros.");
            }
        }

        public static DataTable buscarLaboratorio(string valor)
        {
            try
            {
                return laboratorioDal.buscarLaboratorio(valor);
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al buscar registros.");
            }
        }

        private static resultadoOperacion validarLaboratorio(oLaboratorio laboratorio)
        {
            if (string.IsNullOrWhiteSpace(laboratorio.nombreLaboratorio))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el nombre del laboratorio.",
                    campoInvalido = "nombreLaboratorio"
                };

            if (string.IsNullOrWhiteSpace(laboratorio.email))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el email del laboratorio.",
                    campoInvalido = "email"
                };

            if (!Validar.emailValido(laboratorio.email))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "El email no tiene el formato correcto.",
                    campoInvalido = "email"
                };

            if (string.IsNullOrWhiteSpace(laboratorio.telefono))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el teléfono del laboratorio.",
                    campoInvalido = "telefono"
                };

            if (string.IsNullOrWhiteSpace(laboratorio.contacto))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el contacto del laboratorio.",
                    campoInvalido = "contacto"
                };

            return new resultadoOperacion { esValido = true };
        }

        public static resultadoOperacion registrarLaboratorio(oLaboratorio laboratorio)
        {
            var validacion = validarLaboratorio(laboratorio);
            if (!validacion.esValido)
                return validacion;

            try
            {
                bool resultado = laboratorioDal.registrarLaboratorio(laboratorio);

                if(resultado)
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

            catch(Exception)
            {
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ocurrió un error inesperado al guardar el registro."
                };
            }
        }

        public static resultadoOperacion editarLaboratorio(oLaboratorio laboratorio)
        {
            var validacion = validarLaboratorio(laboratorio);
            if (!validacion.esValido)
                return validacion;

            try
            {
                bool resultado = laboratorioDal.editarLaboratorio(laboratorio);

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

        public static string eliminarLaboratorio(int idLaboratorio)
        {
            if (idLaboratorio <= 0)
                return "Debe especificar un registro válido";

            try
            {
                bool resultado = laboratorioDal.eliminarLaboratorio(idLaboratorio);

                if(resultado)
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


