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
    public class bProducto
    {
        private static readonly dProducto productoDal = new dProducto();

        public static DataTable listarTodosProductos()
        {
            try
            {
                return productoDal.listarTodosProductos();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar registros.");
            }
        }

        public static DataTable listarProductos()
        {
            try
            {
                return productoDal.listarProductos();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar registros.");
            }
        }

        public static DataTable buscarTodosProducto(int filtro, string valor)
        {
            try
            {
                return productoDal.buscarTodosProductos(filtro, valor);
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al buscar registros.");
            }
        }

        public static DataTable buscarProducto(int filtro, string valor)
        {
            try
            {
                return productoDal.buscarProductos(filtro, valor);
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al buscar registros.");
            }
        }

        private static resultadoOperacion validarProducto(oProducto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.codigo))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el código del Producto.",
                    campoInvalido = "codigo"
                };

            if (string.IsNullOrWhiteSpace(producto.nombreProducto))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el nombre del Producto.",
                    campoInvalido = "nombreProducto"
                };

            if (string.IsNullOrWhiteSpace(producto.formatoCompra))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el formato de compra.",
                    campoInvalido = "formatoCompra"
                };

            if (producto.idCategoria == 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Seleccione una categoría.",
                    campoInvalido = "idProducto"
                };

            if (producto.idLaboratorio == 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Seleccione un labotorio.",
                    campoInvalido = "idLaboratorio"
                };

            if (producto.stock <= 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "El stock debe ser mayor a cero.",
                    campoInvalido = "stock"
                };

            if (producto.stockMinimo < 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "El stock mínimo debe ser igual o mayor a cero.",
                    campoInvalido = "stockMinimo"
                };

            if (string.IsNullOrWhiteSpace(producto.ventaConReceta))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Seleccione si el producto requiere receta.",
                    campoInvalido = "ventaReceta"
                };

            if (producto.precioCompra <= 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "El precio de compra debe ser mayor a cero.",
                    campoInvalido = "precioCompra"
                };

            if (producto.precioVenta <= 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "El precio de venta debe ser mayor a cero.",
                    campoInvalido = "precioVenta"
                };

            if (producto.precioCompra >= producto.precioVenta)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "El precio de compra debe ser menor que el precio de venta.",
                    campoInvalido = "precioVenta"
                };

            return new resultadoOperacion { esValido = true };
        }

        public static resultadoOperacion registrarProducto(oProducto Producto)
        {
            var validacion = validarProducto(Producto);
            if (!validacion.esValido)
                return validacion;

            try
            {
                bool resultado = productoDal.registrarProducto(Producto);

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

        public static resultadoOperacion editarProducto(oProducto Producto)
        {
            var validacion = validarProducto(Producto);
            if (!validacion.esValido)
                return validacion;

            try
            {
                bool resultado = productoDal.edtiarProducto(Producto);

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

        public static string eliminarProducto(int idProducto)
        {
            if (idProducto <= 0)
                return "Debe especificar un registro válido";

            try
            {
                bool resultado = productoDal.eliminarProducto(idProducto);

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
