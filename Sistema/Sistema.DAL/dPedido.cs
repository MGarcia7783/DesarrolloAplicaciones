using Sistema.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.DAL
{
    public class dPedido
    {
        public DataTable listarPedido()
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ListarPedidos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        lista.Load(dr);
                    }
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar los registros.");
            }

            return lista;
        }

        public DataTable buscarPedido(string pedido)
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_BuscarPedidos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Pedido", pedido);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        lista.Load(dr);
                    }
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al buscar los registros.");
            }

            return lista;
        }

        public bool registrarPedido(oPedido pedido, out string pedidoGenerado)
        {
            pedidoGenerado = string.Empty;
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_RegistrarPedido", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", pedido.idUsuario);
                    cmd.Parameters.AddWithValue("@IdCaja", pedido.idCaja);
                    cmd.Parameters.AddWithValue("@SubTotal", pedido.subTotal);
                    cmd.Parameters.AddWithValue("@Impuesto", pedido.impuesto);
                    cmd.Parameters.AddWithValue("@Total", pedido.totalGeneral);
                    cmd.Parameters.AddWithValue("@MontoEfectivo", pedido.montoEfectivo);
                    cmd.Parameters.AddWithValue("@MontoTarjeta", pedido.montoTarjeta);
                    cmd.Parameters.AddWithValue("@Cambio", pedido.cambio);
                    cmd.Parameters.AddWithValue("@Detalles", pedido.detalles);

                    SqlParameter numeroPedido = new SqlParameter("@Pedido", SqlDbType.VarChar, 20)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(numeroPedido);

                    SqlParameter respuesta = new SqlParameter("@Respuesta", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(respuesta);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    int resultado = Convert.ToInt32(respuesta.Value);
                    return resultado == 1;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al agregar el registro.");
            }
        }
    }
}
