using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de N_Cliente(N=LógicaDelNegocio) ya que en esta clase se llaman a los métodos para ser utilizados por la interfaz 
    internal class N_Cliente
    {
        //Definimos una isntancia desde la clase D_Cliente
        private D_Cliente objCliente = new D_Cliente();
        //Metetodo para traerClientes desde la BD haciendo uso de la clase D_Clientes
        public List<Cliente> TraerCliente()
        {
            return objCliente.TraerCliente();
        }
        //Metodo para Registrar Clientes a la BD utilizando procedimiento almacenados definidos en la clase D_Cliente
        public int RegistrarClientes(Cliente obj, out string Mensaje)
        {
            //Validaciones para poder registrar Clientes
            Mensaje = string.Empty;
            //Si es que el Cliente no agrega el documento le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Nro de Cédula del Cliente\n";
            }
            //Si es que el Cliente no agrega su nombre y apellido le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre y apellido del Cliente\n";
            }
            //Si es que el Cliente no agrega un correo de Cliente le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario un correo para el Cliente\n";
            }
            //Si es que el Cliente no agrega un telefono le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Telefono == "")
            {
                Mensaje += "Es necesario colocar un # de telefono para el Cliente\n";
            }
            //Si es que algun mensaje fue ejecutado no se registrara ningun Cliente, caso contrario se registrara con exito el Cliente
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCliente.RegistrarClientes(obj, out Mensaje);
            }

        }
        //Metodo para Editar Clientes a la BD utilizando procedimiento almacenados definidos en la clase D_Cliente
        public bool EditarClientes(Cliente obj, out string Mensaje)
        {
            //Validaciones para poder registrar Clientes
            Mensaje = string.Empty;
            //Si es que el Cliente no agrega el documento le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Nro de Cédula del Cliente\n";
            }
            //Si es que el Cliente no agrega su nombre y apellido le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre y apellido del Cliente\n";
            }
            //Si es que el Cliente no agrega un correo de Cliente le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario un correo para el Cliente\n";
            }
            //Si es que el Cliente no agrega un telefono le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Telefono == "")
            {
                Mensaje += "Es necesario colocar un # de telefono para el Cliente\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCliente.EditarClientes(obj, out Mensaje);
            }


        }
        //Metodo para Eliminar Clientes a la BD utilizando procedimiento almacenados definidos en la clase D_Cliente
        public bool EliminarClientes(Cliente obj, out string Mensaje)
        {
            return objCliente.EliminarClientes(obj, out Mensaje);
        }
    }
}
