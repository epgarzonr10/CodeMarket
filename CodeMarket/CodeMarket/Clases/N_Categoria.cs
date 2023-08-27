using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de N_Categoria(N=LógicaDelNegocio) ya que en esta clase se llaman a los métodos para ser utilizados por la interfaz 
    internal class N_Categoria
    {
        //Definimos una isntancia desde la clase D_Categoria
        private D_Categoria objCategoria = new D_Categoria();
        //Metetodo para traerCategorias desde la BD haciendo uso de la clase D_Categorias
        public List<Categoria> TraerCategoria()
        {
            return objCategoria.TraerCategoria();
        }
        //Metodo para Registrar Categorias a la BD utilizando procedimiento almacenados definidos en la clase D_Categoria
        public int RegistrarCategorias(Categoria obj, out string Mensaje)
        {
            //Validaciones para poder guardar registrar Categorias
            Mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion de la CATEGORIA\n";
            }
            //Si es que algun mensaje fue ejecutado no se registrara ningun Categoria, caso contrario se registrara con exito el Categoria
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCategoria.RegistrarCategorias(obj, out Mensaje);
            }

        }
        //Metodo para Editar Categorias a la BD utilizando procedimiento almacenados definidos en la clase D_Categoria
        public bool EditarCategorias(Categoria obj, out string Mensaje)
        {
            //Validaciones para poder guardar registrar Categorias
            Mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion de la CATEGORIA\n";
            }
            //Si es que algun mensaje fue ejecutado no se registrara ningun Categoria, caso contrario se registrara con exito el Categoria
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCategoria.EditarCategorias(obj, out Mensaje);
            }


        }
        //Metodo para Eliminar Categorias a la BD utilizando procedimiento almacenados definidos en la clase D_Categoria
        public bool EliminarCategorias(Categoria obj, out string Mensaje)
        {
            return objCategoria.EliminarCategorias(obj, out Mensaje);
        }
    }
}
