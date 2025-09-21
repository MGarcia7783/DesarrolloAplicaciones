using Sistema.DAL;
using Sistema.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.BLL
{
    public class bCompra
    {
        private static readonly dCompra compraDal = new dCompra();

        public static DataTable listarCompra()
        {
            try
            {
                return compraDal.listarCompra();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar registros.");
            }
        }

        public static DataTable buscarCompra(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                return compraDal.buscarCompra(fechaInicio, fechaFinal);
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al buscar el registro.");
            }
        }

        public static DataTable buscarDetalleCompra(int id)
        {
            try
            {
                return compraDal.buscarDetalleCompra(id);
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al buscar registros.");
            }
        }

        private static resultadoOperacion validarCompra(oCompra compra)
        {
            if (compra.detalleCompra == null || compra.detalleCompra.Rows.Count == 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Debe agregar al menos un producto para procesar la compra.",
                };

            if (string.IsNullOrWhiteSpace(compra.numeroFactura))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Debe especificar el número de factura.",
                    campoInvalido = "numeroFactura"
                };

            if (compra.totalGeneral <= 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "El total de la compra debe ser mayor a cero.",
                    campoInvalido = "totalGeneral"
                };

            if (compra.impuesto > compra.totalGeneral)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "El impuesto no puede ser mayor al total facturado.",
                    campoInvalido = "totalGeneral"
                };

            return new resultadoOperacion { esValido = true };
        }

        public static resultadoOperacion registrarCompra(oCompra compra)
        {
            var validacion = validarCompra(compra);
            if (!validacion.esValido)
                return validacion;

            try
            {
                bool resultado = compraDal.registrarCompra(compra);

                if (resultado)
                {
                    return new resultadoOperacion
                    {
                        esValido = true,
                        mensaje = "Registro almacenado satisfactoriamente.",
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
    }
}
