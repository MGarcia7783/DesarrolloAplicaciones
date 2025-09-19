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
    public class bCategoria
    {
        private static readonly dCategoria categoriaDal = new dCategoria();

        public static DataTable listarCategoria()
        {
            try
            {
                return categoriaDal.listarCategoria();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar registros.");
            }
        }

        public static DataTable buscarCategoria(string valor)
        {
            try
            {
                return categoriaDal.buscarCategoria(valor);
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al buscar registros.");
            }
        }

        private static resultadoOperacion validarCategoria(oCategoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.nombreCategoria))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el nombre del categoria.",
                    campoInvalido = "nombreCategoria"
                };

            if (string.IsNullOrWhiteSpace(categoria.descripcionCategoria))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese la descripción para la categoria.",
                    campoInvalido = "descripcionCategoria"
                };

            return new resultadoOperacion { esValido = true };
        }

        public static resultadoOperacion registrarCategoria(oCategoria categoria)
        {
            var validacion = validarCategoria(categoria);
            if (!validacion.esValido)
                return validacion;

            try
            {
                bool resultado = categoriaDal.registrarCategoria(categoria);

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

        public static resultadoOperacion editarCategoria(oCategoria categoria)
        {
            var validacion = validarCategoria(categoria);
            if (!validacion.esValido)
                return validacion;

            try
            {
                bool resultado = categoriaDal.editarCategoria(categoria);

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

        public static string eliminarCategoria(int idCategoria)
        {
            if (idCategoria <= 0)
                return "Debe especificar un registro válido";

            try
            {
                bool resultado = categoriaDal.eliminarCategoria(idCategoria);

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
