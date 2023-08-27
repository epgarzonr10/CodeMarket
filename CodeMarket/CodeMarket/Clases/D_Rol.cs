using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de D_Rol(D=Datos) ya que en esta clase se almacenan los métodos correspondientes 
    internal class D_Rol
    {
        public List<Rol> ListarRol()
        {
            //Metodo de listar para traer los Roles desde la BD
            List<Rol> listarRol = new List<Rol>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdRol,Descripcion from Rol");  
                    SqlCommand comando = new SqlCommand(query.ToString(), oconexion);
                    comando.CommandType = CommandType.Text;
                    //abrimos la conexion
                    oconexion.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listarRol.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Descripcion = dr["Descripcion"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    listarRol = new List<Rol>();
                }
            }
            return listarRol;
        }
    }
}
