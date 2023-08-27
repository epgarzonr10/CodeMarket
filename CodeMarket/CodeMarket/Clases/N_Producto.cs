using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de N_Producto(N=LógicaDelNegocio) ya que en esta clase se llaman a los métodos para ser utilizados por la interfaz 
    internal class N_Producto
    {
        //Definimos una isntancia desde la clase D_Producto
        private D_Producto objProducto = new D_Producto();
        //Metetodo para traerProductos desde la BD haciendo uso de la clase D_Productos
        public List<Producto> TraerProducto()
        {
            return objProducto.TraerProducto();
        }
        //Metodo para Registrar Productos a la BD utilizando procedimiento almacenados definidos en la clase D_Producto
        public int RegistrarProductos(Producto obj, out string Mensaje)
        {
            //Validaciones para poder registrar Productos
            Mensaje = string.Empty;
            //Si es que al Producto no se le agrega el codigo le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario ingresar el código del Producto\n";
            }
            //Si es que al Producto no se le agrega un nombre le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }
            //Si es que al Producto no se le agrega una descripcion le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario escribir una descripcion para el producto\n";
            }
            //Si es que algun mensaje fue ejecutado no se registrara ningun Producto, caso contrario se registrara con exito el Producto
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objProducto.RegistrarProductos(obj, out Mensaje);
            }

        }
        //Metodo para Editar Productos a la BD utilizando procedimiento almacenados definidos en la clase D_Producto
        public bool EditarProductos(Producto obj, out string Mensaje)
        {
            //Validaciones para poder registrar Productos
            Mensaje = string.Empty;
            //Si es que al Producto no se le agrega el codigo le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario ingresar el código del Producto\n";
            }
            //Si es que al Producto no se le agrega un nombre le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }
            //Si es que al Producto no se le agrega una descripcion le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario escribir una descripcion para el producto\n";
            }
            //Si es que algun mensaje fue ejecutado no se registrara ningun Producto, caso contrario se registrara con exito el Producto
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objProducto.EditarProductos(obj, out Mensaje);
            }


        }
        //Metodo para Eliminar Productos a la BD utilizando procedimiento almacenados definidos en la clase D_Producto
        public bool EliminarProductos(Producto obj, out string Mensaje)
        {
            return objProducto.EliminarProductos(obj, out Mensaje);
        }
    }
}
