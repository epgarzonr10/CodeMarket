using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de D_Usuario(D=Datos) ya que en esta clase se almacenan los métodos correspondientes 
    internal class D_Usuario : Usuario
    {
        //Metodo de listar para traer los usuarios desde la BD
        public List<Usuario> TraerUsuario() {
            List<Usuario> trausuario = new List<Usuario>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) {
                try
                {
                    //utilizamos el StringBuilder para concatenar lineas de codigo en diferente linea
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT u.IdUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Telefono,u.Estado,r.IdRol,r.Descripcion FROM usuario u");
                    query.AppendLine("INNER JOIN Rol r on r.IdRol = u.IdRol");
                    SqlCommand comando = new SqlCommand(query.ToString(), oconexion);
                    comando.CommandType = CommandType.Text;
                    //abrimos la conexion
                    oconexion.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //agregamos al listado los datos de la tabla Usuario
                            trausuario.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                //en el caso de Rol como es una clase debemos instanciarla como clase y convertirla a entero
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]),
                                Descripcion = dr["Descripcion"].ToString()
                                }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    trausuario = new List<Usuario>();
                }
            }
            return trausuario;
        }
        //Metodo para registrar usuarios utilizando procedimientos almacenados
        public int RegistrarUsuarios(Usuario obj,out string Mensaje) {

            int idusuariogenerado = 0;
            Mensaje = string.Empty;

            try {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) {
                    //Parametros de entrada del procedimiento almacenado
                   SqlCommand comando = new SqlCommand("RegistrarUsuario", oconexion);
                    comando.Parameters.AddWithValue("Documento",obj.Documento);
                    comando.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    comando.Parameters.AddWithValue("Correo", obj.Correo);
                    comando.Parameters.AddWithValue("Clave", obj.Clave);
                    comando.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    comando.Parameters.AddWithValue("Estado", obj.Estado);
                    //Parametros de salida del procedimiento almacenado
                    comando.Parameters.Add("IdUsuarioResultado",SqlDbType.Int).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    //abrimos la conexion
                    oconexion.Open();
                    comando.ExecuteNonQuery();
                    //Obtenemos los valores de salida del procedimiento almacenado
                    idusuariogenerado = Convert.ToInt32(comando.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = comando.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch(Exception ex)
            {
                idusuariogenerado = 0;
                Mensaje = ex.Message;
            }
            return idusuariogenerado;
        }

        //Metodo para editar usuarios utilizando procedimientos almacenados
        public bool EditarUsuarios(Usuario obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("EditarUsuario", oconexion);
                    comando.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    comando.Parameters.AddWithValue("Documento", obj.Documento);
                    comando.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    comando.Parameters.AddWithValue("Correo", obj.Correo);
                    comando.Parameters.AddWithValue("Clave", obj.Clave);
                    comando.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    comando.Parameters.AddWithValue("Estado", obj.Estado);
                    //Parametros de salida del procedimiento almacenado
                    comando.Parameters.Add("@Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    //abrimos la conexion
                    oconexion.Open();
                    comando.ExecuteNonQuery();
                    //Obtenemos los valores de salida del procedimiento almacenado
                    respuesta = Convert.ToBoolean(comando.Parameters["Respuesta"].Value);
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

        //Metodo para eliminar usuarios utilizando procedimientos almacenados
        public bool EliminarUsuarios(Usuario obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("EliminarUsuario", oconexion);
                    comando.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    //Parametros de salida del procedimiento almacenado
                    comando.Parameters.Add("@Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    //abrimos la conexion
                    oconexion.Open();
                    comando.ExecuteNonQuery();
                    //Obtenemos los valores de salida del procedimiento almacenado
                    respuesta = Convert.ToBoolean(comando.Parameters["Respuesta"].Value);
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
