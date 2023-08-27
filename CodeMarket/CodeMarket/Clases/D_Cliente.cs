using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de D_Cliente(D=Datos) ya que en esta clase se almacenan los métodos correspondientes 
    internal class D_Cliente
    {
        //Metodo de listar para traer los Clientes desde la BD
        public List<Cliente> TraerCliente()
        {
            List<Cliente> traCliente = new List<Cliente>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    //utilizamos el StringBuilder para concatenar lineas de codigo en diferente linea
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdCliente,Documento,NombreCompleto,Correo,Telefono,Estado from Cliente");
                    SqlCommand comando = new SqlCommand(query.ToString(), oconexion);
                    comando.CommandType = CommandType.Text;
                    //abrimos la conexion
                    oconexion.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //agregamos al listado los datos de la tabla Cliente
                            traCliente.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    traCliente = new List<Cliente>();
                }
            }
            return traCliente;
        }
        //Metodo para registrar Clientes utilizando procedimientos almacenados
        public int RegistrarClientes(Cliente obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            int idClientegenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("RegistrarCliente", oconexion);
                    comando.Parameters.AddWithValue("Documento", obj.Documento);
                    comando.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    comando.Parameters.AddWithValue("Correo", obj.Correo);
                    comando.Parameters.AddWithValue("Telefono", obj.Telefono);
                    comando.Parameters.AddWithValue("Estado", obj.Estado);
                    //Parametros de salida del procedimiento almacenado
                    comando.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    //abrimos la conexion
                    oconexion.Open();
                    comando.ExecuteNonQuery();
                    //Obtenemos los valores de salida del procedimiento almacenado
                    idClientegenerado = Convert.ToInt32(comando.Parameters["Resultado"].Value);
                    Mensaje = comando.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idClientegenerado = 0;
                Mensaje = ex.Message;
            }
            return idClientegenerado;
        }

        //Metodo para editar Clientes utilizando procedimientos almacenados
        public bool EditarClientes(Cliente obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("EditarCliente", oconexion);
                    comando.Parameters.AddWithValue("IdCliente", obj.IdCliente);
                    comando.Parameters.AddWithValue("Documento", obj.Documento);
                    comando.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    comando.Parameters.AddWithValue("Correo", obj.Correo);
                    comando.Parameters.AddWithValue("Telefono", obj.Telefono);
                    comando.Parameters.AddWithValue("Estado", obj.Estado);
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

        //Metodo para eliminar Clientes utilizando procedimientos almacenados
        public bool EliminarClientes(Cliente obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("Delete from Cliente where IdCliente = @Id", oconexion);
                    comando.Parameters.AddWithValue("@id", obj.IdCliente);
                    comando.CommandType = CommandType.Text;
                    //abrimos la conexion
                    oconexion.Open();
                    respuesta = comando.ExecuteNonQuery() > 0 ? true : false;
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
