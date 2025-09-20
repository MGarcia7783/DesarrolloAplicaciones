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
    public class bPedido
    {
        private static readonly dPedido pedidoDal = new dPedido();

        public static DataTable listarPedido()
        {
            try
            {
                return pedidoDal.listarPedido();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar registros.");
            }
        }

        public static DataTable buscarPedido(string pedido)
        {
            try
            {
                return pedidoDal.buscarPedido(pedido);
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al buscar el registro.");
            }
        }

        public static DataTable buscarDetallePedido(int id)
        {
            try
            {
                return pedidoDal.buscarDetallePedido(id);
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al buscar registros.");
            }
        }

        private static resultadoOperacion validarPedido(oPedido pedido)
        {
            if (pedido.detalles == null || pedido.detalles.Rows.Count == 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Debe agregar al menos un producto al carrito de compras.",
                };

            if (pedido.totalGeneral <= 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "El total de la venta debe ser mayor a cero.",
                    campoInvalido = "totalGeneral"
                };

            if (pedido.impuesto > pedido.totalGeneral)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "El impuesto no puede ser mayor al total facturado.",
                    campoInvalido = "totalGeneral"
                };

            return new resultadoOperacion { esValido = true };
        }

        public static resultadoOperacion registrarPedido(oPedido pedido)
        {
            var validacion = validarPedido(pedido);
            if (!validacion.esValido)
                return validacion;

            try
            {
                string pedidoGenerado;
                bool resultado = pedidoDal.registrarPedido(pedido, out pedidoGenerado);

                if (resultado)
                {
                    return new resultadoOperacion
                    {
                        esValido = true,
                        mensaje = "Registro almacenado satisfactoriamente.",
                        numeroPedido = pedidoGenerado
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
