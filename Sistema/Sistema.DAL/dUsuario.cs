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
    public class dUsuario
    {
        public DataTable listarUsuario()
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", cn))
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

        public DataTable buscarUsuario(string nombre)
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_BuscarUsuarios", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", nombre);
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

        public DataTable listarRol()
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ListarRoles", cn))
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

        public bool registrarUsuario(oUsuario usuario)
        {
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_RegistrarUsuarios", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DniUsuario", usuario.nombreUsuario);
                    cmd.Parameters.AddWithValue("@Usuario", usuario.nombreUsuario);
                    cmd.Parameters.AddWithValue("@Email", usuario.email);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.idRol);
                    cmd.Parameters.AddWithValue("@Codigo", usuario.codigoUsuario);
                    cmd.Parameters.AddWithValue("@Clave", usuario.clave);

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

        public bool editarUsuario(oUsuario usuario)
        {
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarUsuarios", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.idUsuario);
                    cmd.Parameters.AddWithValue("@DniUsuario", usuario.nombreUsuario);
                    cmd.Parameters.AddWithValue("@Usuario", usuario.nombreUsuario);
                    cmd.Parameters.AddWithValue("@Email", usuario.email);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.idRol);
                    cmd.Parameters.AddWithValue("@Codigo", usuario.codigoUsuario);
                    cmd.Parameters.AddWithValue("@Clave", usuario.clave);

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

        public bool eliminarUsuario(int idUsuario)
        {
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_EliminarUsuarios", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

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
