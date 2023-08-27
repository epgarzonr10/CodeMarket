using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de D_Prodcutos(D=Datos) ya que en esta clase se almacenan los métodos correspondientes 
    internal class D_Producto
    {
        //Metodo de listar para traer los Productos desde la BD
        public List<Producto> TraerProducto()
        {
            List<Producto> traProducto = new List<Producto>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    //utilizamos el StringBuilder para concatenar lineas de codigo en diferente linea
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdProducto,Codigo,Nombre,p.Descripcion,c.IdCategoria,c.Descripcion[DescripcionCategoria],Stock,PrecioCompra,PrecioVenta,p.Estado from Producto p");
                    query.AppendLine("INNER JOIN Categoria c on c.IdCategoria = p.IdCategoria");
                    SqlCommand comando = new SqlCommand(query.ToString(), oconexion);
                    comando.CommandType = CommandType.Text;
                    //abrimos la conexion
                    oconexion.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //agregamos al listado los datos de la tabla Producto
                            traProducto.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oCategoria = new Categoria() { IdCategoria= Convert.ToInt32(dr["IdCategoria"]), Descripcion = dr["DescripcionCategoria"].ToString()},
                                Stock = Convert.ToInt32(dr["Stock"].ToString()),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    traProducto = new List<Producto>();
                }
            }
            return traProducto;
        }
        //Metodo para registrar Productos utilizando procedimientos almacenados
        public int RegistrarProductos(Producto obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            int idProductogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("RegistrarProducto", oconexion);
                    comando.Parameters.AddWithValue("Codigo", obj.Codigo);
                    comando.Parameters.AddWithValue("Nombre", obj.Nombre);
                    comando.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    comando.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    comando.Parameters.AddWithValue("Estado", obj.Estado);
                    //Parametros de salida del procedimiento almacenado
                    comando.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    //abrimos la conexion
                    oconexion.Open();
                    comando.ExecuteNonQuery();
                    //Obtenemos los valores de salida del procedimiento almacenado
                    idProductogenerado = Convert.ToInt32(comando.Parameters["Resultado"].Value);
                    Mensaje = comando.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idProductogenerado = 0;
                Mensaje = ex.Message;
            }

            return idProductogenerado;
        }

        //Metodo para editar Productos utilizando procedimientos almacenados
        public bool EditarProductos(Producto obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("EditarProducto", oconexion);
                    comando.Parameters.AddWithValue("IdProducto", obj.IdProducto);
                    comando.Parameters.AddWithValue("Codigo", obj.Codigo);
                    comando.Parameters.AddWithValue("Nombre", obj.Nombre);
                    comando.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    comando.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
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

        //Metodo para eliminar Productos utilizando procedimientos almacenados
        public bool EliminarProductos(Producto obj, out string Mensaje)
        {
            //Inicializamos varibles para utilizarlas
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Parametros de entrada del procedimiento almacenado
                    SqlCommand comando = new SqlCommand("EliminarProducto", oconexion);
                    comando.Parameters.AddWithValue("IdProducto", obj.IdProducto);
                    //Parametros de salida del procedimiento almacenado
                    comando.Parameters.Add("@Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
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
