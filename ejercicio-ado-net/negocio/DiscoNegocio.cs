using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class DiscoNegocio
    {
        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database= DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Genero, T.Descripcion Tipo, D.IdEstilo, D.IdTipoEdicion, D.Id FROM DISCOS D, ESTILOS E, TIPOSEDICION T WHERE E.Id = D.IdEstilo AND T.Id = D.IdTipoEdicion AND D.Activo = 1";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    if (!(lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.Genero = new Estilo();
                    aux.Genero.Id = (int)lector["IdEstilo"];
                    aux.Genero.Descripcion = (string)lector["Genero"];
                    aux.Tipo = new TipoEdicion();
                    aux.Tipo.Id = (int)lector["IdTipoEdicion"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string fechaFormateada = nuevo.FechaLanzamiento.ToString("yyyy-MM-dd HH:mm:ss");
                datos.setearConsulta("INSERT INTO DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, IdEstilo, IdTipoEdicion, UrlImagenTapa) VALUES ('" + nuevo.Titulo + "', '" + fechaFormateada + "'," + nuevo.CantidadCanciones + ", @idEstilo, @idTipoEdicion, @urlImagenTapa)");
                datos.setearParametro("@idEstilo", nuevo.Genero.Id);
                datos.setearParametro("@idTipoEdicion", nuevo.Tipo.Id);
                datos.setearParametro("@urlImagenTapa", nuevo.UrlImagenTapa);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Disco disco)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE DISCOS SET Titulo = @titulo, FechaLanzamiento = @fecha, CantidadCanciones = @cantidad, UrlImagenTapa = @img, IdEstilo = @idEstilo, IdTipoEdicion = @idTipoEdicion WHERE Id = @id");
                datos.setearParametro("@titulo", disco.Titulo);
                datos.setearParametro("@fecha", disco.FechaLanzamiento);
                datos.setearParametro("@cantidad", disco.CantidadCanciones);
                datos.setearParametro("@img", disco.UrlImagenTapa);
                datos.setearParametro("@idEstilo", disco.Genero.Id);
                datos.setearParametro("@idTipoEdicion", disco.Tipo.Id);
                datos.setearParametro("@id", disco.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminarFisico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM DISCOS WHERE Id = @id;");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminarLogico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE DISCOS SET Activo = 0 WHERE Id = @id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Disco> filtrar(string campo, string criterio, string filtro)
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Genero, T.Descripcion Tipo, D.IdEstilo, D.IdTipoEdicion, D.Id FROM DISCOS D, ESTILOS E, TIPOSEDICION T WHERE E.Id = D.IdEstilo AND T.Id = D.IdTipoEdicion AND ";
                if (campo == "Cantidad de canciones")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "CantidadCanciones > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "CantidadCanciones < " + filtro;
                            break;
                        default:
                            consulta += "CantidadCanciones = " + filtro;
                            break;
                    }

                }
                else if (campo == "Titulo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Titulo like '" + filtro + "%'";
                            break;

                        case "Termina con":
                            consulta += "Titulo like '%" + filtro + "'";
                            break;

                        default:
                            consulta += "Titulo like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "E.Descripcion like '" + filtro + "%'";
                            break;

                        case "Termina con":
                            consulta += "E.Descripcion like '%" + filtro + "' ";
                            break;

                        default:
                            consulta += "E.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    aux.Genero = new Estilo();
                    aux.Genero.Id = (int)datos.Lector["IdEstilo"];
                    aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Tipo = new TipoEdicion();
                    aux.Tipo.Id = (int)datos.Lector["IdTipoEdicion"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void recuperarEliminado(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE DISCOS SET Activo = 1 WHERE Id = @id");
                datos.setearParametro("Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Disco> listaRecuperados()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Disco> lista = new List<Disco>();
            try
            {
                datos.setearConsulta("SELECT Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Genero, T.Descripcion Tipo, D.IdEstilo, D.IdTipoEdicion, D.Id FROM DISCOS D, ESTILOS E, TIPOSEDICION T WHERE E.Id = D.IdEstilo AND T.Id = D.IdTipoEdicion AND D.Activo = 0");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                    {
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    }
                    aux.Genero = new Estilo();
                    aux.Genero.Id = (int)datos.Lector["IdEstilo"];
                    aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Tipo = new TipoEdicion();
                    aux.Tipo.Id = (int)datos.Lector["IdTipoEdicion"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];

                    lista.Add(aux);

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
