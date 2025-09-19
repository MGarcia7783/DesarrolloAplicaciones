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
    public class dProducto
    {
        public DataTable listarTodosProductos()
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ListarTodosProductos", cn))
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

        public DataTable listarProductos()
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ListarProductos", cn))
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

        public DataTable buscarTodosProductos(int filtro, string valor)
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_BuscarTodosProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Filtro", filtro);
                    cmd.Parameters.AddWithValue("@Valor", valor);
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

        public DataTable buscarProductos(int filtro, string valor)
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_BuscarProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Filtro", filtro);
                    cmd.Parameters.AddWithValue("@Valor", valor);
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

        public bool registrarProducto(oProducto producto)
        {
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_RegistrarProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Codigo", producto.codigo);
                    cmd.Parameters.AddWithValue("@Impuesto", producto.impuesto);
                    cmd.Parameters.AddWithValue("@Producto", producto.nombreProducto);
                    cmd.Parameters.AddWithValue("@Formato", producto.formatoCompra);
                    cmd.Parameters.AddWithValue("@IdCategoria", producto.idCategoria);
                    cmd.Parameters.AddWithValue("@IdLaboratorio", producto.idLaboratorio);
                    cmd.Parameters.AddWithValue("@Stock", producto.stock);
                    cmd.Parameters.AddWithValue("@StockMinimo", producto.stockMinimo);
                    cmd.Parameters.AddWithValue("@VentaReceta ", producto.ventaConReceta);
                    cmd.Parameters.AddWithValue("@PrecioCompra", producto.precioCompra);
                    cmd.Parameters.AddWithValue("@PrecioVenta", producto.precioVenta);
                    cmd.Parameters.AddWithValue("@TieneVencimiento", producto.tieneVencimiento);

                    if(producto.fechaVencimiento.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@Vencimiento", producto.fechaVencimiento);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Vencimiento", DBNull.Value);
                    }                     

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

        public bool edtiarProducto(oProducto producto)
        {
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProducto", producto.idProducto);
                    cmd.Parameters.AddWithValue("@Codigo", producto.codigo);
                    cmd.Parameters.AddWithValue("@Impuesto", producto.impuesto);
                    cmd.Parameters.AddWithValue("@Producto", producto.nombreProducto);
                    cmd.Parameters.AddWithValue("@Formato", producto.formatoCompra);
                    cmd.Parameters.AddWithValue("@IdCategoria", producto.idCategoria);
                    cmd.Parameters.AddWithValue("@IdLaboratorio", producto.idLaboratorio);
                    cmd.Parameters.AddWithValue("@Stock", producto.stock);
                    cmd.Parameters.AddWithValue("@StockMinimo", producto.stockMinimo);
                    cmd.Parameters.AddWithValue("@VentaReceta ", producto.ventaConReceta);
                    cmd.Parameters.AddWithValue("@PrecioCompra", producto.precioCompra);
                    cmd.Parameters.AddWithValue("@PrecioVenta", producto.precioVenta);
                    cmd.Parameters.AddWithValue("@TieneVencimiento", producto.tieneVencimiento);

                    if (producto.fechaVencimiento.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@Vencimiento", producto.fechaVencimiento);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Vencimiento", DBNull.Value);
                    }

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
                throw new ApplicationException("Error al editar el registro.");
            }
        }

        public bool eliminarProducto(int idProducto)
        {
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_EliminarProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);

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
                throw new ApplicationException("Error al eliminar el registro.");
            }
        }
    }
}
