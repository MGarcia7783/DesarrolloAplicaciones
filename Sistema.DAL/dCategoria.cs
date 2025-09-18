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
    public class dCategoria
    {
        public DataTable listarCategoria()
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ListarCategoria", cn))
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

        public DataTable buscarCategoria(string valor)
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_BuscarCategoria", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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

        public bool registrarCategoria(oCategoria categoria)
        {
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_RegistrarCategoria", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Categoria", categoria.nombreCategoria);
                    cmd.Parameters.AddWithValue("@Descripcion", categoria.descripcionCategoria);

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

        public bool editarCategoria(oCategoria categoria)
        {
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_EditarCategoria", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCategoria", categoria.idCategoria);
                    cmd.Parameters.AddWithValue("@Categoria", categoria.nombreCategoria);
                    cmd.Parameters.AddWithValue("@Descripcion", categoria.descripcionCategoria);

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

        public bool eliminarCategoria(int idCategoria)
        {
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("spEliminarCategoria", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);

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
