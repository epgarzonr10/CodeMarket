using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de D_Categoria(D=Datos) ya que en esta clase se almacenan los métodos correspondientes 

    internal class D_Categoria
    {
        //Metodo de listar para traer los Categorias desde la BD
        public List<Categoria> TraerCategoria()
        {
            List<Categoria> traCategoria = new List<Categoria>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    //utilizamos el StringBuilder para concatenar lineas de codigo en diferente linea
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdCategoria, Descripcion,Estado FROM Categoria");
                    SqlCommand comando = new SqlCommand(query.ToString(), oconexion);
                    comando.CommandType = CommandType.Text;
                    //abrimos la conexion
                    oconexion.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //agregamos al listado los datos de la tabla Categoria
                            traCategoria.Add(new Categoria()
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    traCategoria = new List<Categoria>();
                }
            }
            return traCategoria;
        }
        //Metodo para registrar Categorias utilizando procedimientos almacenados
        public int RegistrarCategorias(Categoria obj, out string Mensaje)
        {

            int idCategoriagenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("RegistrarCategoria", oconexion);
                    comando.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    comando.Parameters.AddWithValue("Estado", obj.Estado);
                    //Parametros de salida del procedimiento almacenado
                    comando.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    //abrimos la conexion
                    oconexion.Open();
                    comando.ExecuteNonQuery();
                    //Obtenemos los valores de salida del procedimiento almacenado
                    idCategoriagenerado = Convert.ToInt32(comando.Parameters["Resultado"].Value);
                    Mensaje = comando.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idCategoriagenerado = 0;
                Mensaje = ex.Message;
            }

            return idCategoriagenerado;
        }

        //Metodo para editar Categorias utilizando procedimientos almacenados
        public bool EditarCategorias(Categoria obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("EditarCategoria", oconexion);
                    comando.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);
                    comando.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    comando.Parameters.AddWithValue("Estado", obj.Estado);
                    //Parametros de salida del procedimiento almacenado
                    comando.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    //abrimos la conexion
                    oconexion.Open();
                    comando.ExecuteNonQuery();
                    //Obtenemos los valores de salida del procedimiento almacenado
                    respuesta = Convert.ToBoolean(comando.Parameters["Resultado"].Value);
                    Mensaje = comando.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

        //Metodo para eliminar Categorias utilizando procedimientos almacenados
        public bool EliminarCategorias(Categoria obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("EliminarCategoria", oconexion);
                    comando.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);
                    //Parametros de salida del procedimiento almacenado
                    comando.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    //abrimos la conexion
                    oconexion.Open();
                    comando.ExecuteNonQuery();
                    //Obtenemos los valores de salida del procedimiento almacenado
                    respuesta = Convert.ToBoolean(comando.Parameters["Resultado"].Value);
                    Mensaje = comando.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}
