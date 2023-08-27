using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de N_Rol(N=LógicaDelNegocio) ya que en esta clase se llaman a los métodos para ser utilizados por la interfaz 
    internal class N_Rol
    {
        private D_Rol objRol = new D_Rol();

        public List<Rol> ListarRol()
        {
            return objRol.ListarRol();
        }
    }
}
