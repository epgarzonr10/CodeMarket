using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de D_Proveedor(D=Datos) ya que en esta clase se almacenan los métodos correspondientes 
    internal class D_Proveedor
    {
        //Metodo de listar para traer los Proveedors desde la BD
        public List<Proveedor> TraerProveedor()
        {
            List<Proveedor> traProveedor = new List<Proveedor>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    //utilizamos el StringBuilder para concatenar lineas de codigo en diferente linea
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdProveedor,Documento,RazonSocial,Correo,Telefono,Estado from Proveedor");
                    SqlCommand comando = new SqlCommand(query.ToString(), oconexion);
                    comando.CommandType = CommandType.Text;
                    //abrimos la conexion
                    oconexion.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //agregamos al listado los datos de la tabla Proveedor
                            traProveedor.Add(new Proveedor()
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                Documento = dr["Documento"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    traProveedor = new List<Proveedor>();
                }
            }
            return traProveedor;
        }
        //Metodo para registrar Proveedors utilizando procedimientos almacenados
        public int RegistrarProveedors(Proveedor obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            int idProveedorgenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("RegistrarProveedor", oconexion);
                    comando.Parameters.AddWithValue("Documento", obj.Documento);
                    comando.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
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
                    idProveedorgenerado = Convert.ToInt32(comando.Parameters["Resultado"].Value);
                    Mensaje = comando.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idProveedorgenerado = 0;
                Mensaje = ex.Message;
            }
            return idProveedorgenerado;
        }

        //Metodo para editar Proveedors utilizando procedimientos almacenados
        public bool EditarProveedors(Proveedor obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("EditarProveedor", oconexion);
                    comando.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
                    comando.Parameters.AddWithValue("Documento", obj.Documento);
                    comando.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
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

        //Metodo para eliminar Proveedors utilizando procedimientos almacenados
        public bool EliminarProveedors(Proveedor obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("EliminarProveedor", oconexion);
                    comando.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
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
