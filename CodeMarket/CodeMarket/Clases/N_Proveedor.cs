using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de N_proveedor(N=LógicaDelNegocio) ya que en esta clase se llaman a los métodos para ser utilizados por la interfaz 
    internal class N_Proveedor
    {
        //Definimos una isntancia desde la clase D_Proveedor
        private D_Proveedor objProveedor = new D_Proveedor();
        //Metetodo para traerProveedors desde la BD haciendo uso de la clase D_Proveedors
        public List<Proveedor> TraerProveedor()
        {
            return objProveedor.TraerProveedor();
        }
        //Metodo para Registrar Proveedors a la BD utilizando procedimiento almacenados definidos en la clase D_Proveedor
        public int RegistrarProveedors(Proveedor obj, out string Mensaje)
        {
            //Validaciones para poder registrar Proveedors
            Mensaje = string.Empty;
            //Si es que el Proveedor no agrega el documento le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Nro de Documento del Proveedor\n";
            }
            //Si es que el Proveedor no agrega su RazonSocial le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario la razon social del Proveedor\n";
            }
            //Si es que el Proveedor no agrega un correo de Proveedor le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario un correo para el Proveedor\n";
            }
            //Si es que el Proveedor no agrega un telefono le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Telefono == "")
            {
                Mensaje += "Es necesario colocar un # de telefono para el Proveedor\n";
            }
            //Si es que algun mensaje fue ejecutado no se registrara ningun Proveedor, caso contrario se registrara con exito el Proveedor
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objProveedor.RegistrarProveedors(obj, out Mensaje);
            }

        }
        //Metodo para Editar Proveedors a la BD utilizando procedimiento almacenados definidos en la clase D_Proveedor
        public bool EditarProveedors(Proveedor obj, out string Mensaje)
        {
            //Validaciones para poder registrar Proveedors
            Mensaje = string.Empty;
            //Si es que el Proveedor no agrega el documento le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Nro de Documento del Proveedor\n";
            }
            //Si es que el Proveedor no agrega su razon social le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario la razon social del Proveedor\n";
            }
            //Si es que el Proveedor no agrega un correo de Proveedor le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario un correo para el Proveedor\n";
            }
            //Si es que el Proveedor no agrega un telefono le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Telefono == "")
            {
                Mensaje += "Es necesario colocar un # de telefono para el Proveedor\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objProveedor.EditarProveedors(obj, out Mensaje);
            }


        }
        //Metodo para Eliminar Proveedors a la BD utilizando procedimiento almacenados definidos en la clase D_Proveedor
        public bool EliminarProveedors(Proveedor obj, out string Mensaje)
        {
            return objProveedor.EliminarProveedors(obj, out Mensaje);
        }
    }
}
