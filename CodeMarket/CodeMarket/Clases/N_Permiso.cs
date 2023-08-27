using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de N_Permiso(N=LógicaDelNegocio) ya que en esta clase se llaman a los métodos para ser utilizados por la interfaz 
    internal class N_Permiso
    {           
        private D_Permiso objPermiso = new D_Permiso();

        public List<Permiso> ListarPermiso(int IdUsuario)
        {
            return objPermiso.ListarPermiso(IdUsuario);
        }
    }
    
}