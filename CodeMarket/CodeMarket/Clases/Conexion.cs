using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Clase Conexion de tipo Padre para heredar a las demas clases el ConnectionStrings
    internal class Conexion
    {
        public static string cadena = ConfigurationManager.ConnectionStrings["CodeMarket"].ToString();
    }
}
