using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Reflection;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de D_Permiso(D=Datos) ya que en esta clase se almacenan los métodos correspondientes 
    internal class D_Permiso
    {
        public List<Permiso> ListarPermiso(int idusuario)
        {
            //Metodo de listar para traer los permismos desde la BD
            List<Permiso> listarPermiso = new List<Permiso>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    //utilizamos el StringBuilder para concatenar lineas de codigo en diferente linea
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.IdRol, p.NombreMenu from Permiso p");
                    query.AppendLine("INNER JOIN Rol r on r.IdRol = p.IdRol");
                    query.AppendLine("INNER JOIN Usuario u on u.IdRol = r.IdRol");
                    query.AppendLine("where u.IdUsuario = @idusuario");                  
                    SqlCommand comando = new SqlCommand(query.ToString(), oconexion);
                    comando.Parameters.AddWithValue("@idusuario", idusuario);
                    comando.CommandType = CommandType.Text;
                    //abrimos la conexion
                    oconexion.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //agregamos al listado los datos de la tabla Permiso
                            listarPermiso.Add(new Permiso()
                            {
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"])},
                                NombreMenu = dr["NombreMenu"].ToString(),
                            });

                        }

                    }

                }
                catch (Exception ex)
                {
                    listarPermiso = new List<Permiso>();
                }
            }
            return listarPermiso;
        }


    }
}

