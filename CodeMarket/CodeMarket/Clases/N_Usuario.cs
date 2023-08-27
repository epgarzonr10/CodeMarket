using CodeMarket.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarket.Clases
{
    //Esta clase tiene la abreviatura de N_Usuario(N=LógicaDelNegocio) ya que en esta clase se llaman a los métodos para ser utilizados por la interfaz 
    internal class N_Usuario : Usuario
    {
        //Definimos una isntancia desde la clase D_Usuario
        private D_Usuario objUsuario = new D_Usuario();
        //Metetodo para traerusuarios desde la BD haciendo uso de la clase D_usuarios
        public List<Usuario> TraerUsuario() {
            return objUsuario.TraerUsuario();
        }
        //Metodo para Registrar Usuarios a la BD utilizando procedimiento almacenados definidos en la clase D_Usuario
        public int RegistrarUsuarios(Usuario obj, out string Mensaje)
        {
            //Validaciones para poder guardar registrar usuarios
            Mensaje = string.Empty;
            //Si es que el usuario no agrega el documento le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Documento == "") {
                Mensaje += "Es necesario el Nro de Cédula del Usuario\n";
            }
            //Si es que el usuario no agrega su nombre y apellido le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre y apellido del usuario\n";
            }
            //Si es que el usuario no agrega un nombre de usuario le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario un nombre para el usuario, Ejem: ciarias\n";
            }
            //Si es que el usuario no agrega una clave le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Clave == "")
            {
                Mensaje += "Es necesario una clave para el usuario\n";
            }
            //Si es que algun mensaje fue ejecutado no se registrara ningun usuario, caso contrario se registrara con exito el usuario
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else { 
                return objUsuario.RegistrarUsuarios(obj,out Mensaje);
            }
            
        }
        //Metodo para Editar Usuarios a la BD utilizando procedimiento almacenados definidos en la clase D_Usuario
        public bool EditarUsuarios(Usuario obj, out string Mensaje)
        {
            //Validaciones para poder guardar registrar usuarios
            Mensaje = string.Empty;
            //Si es que el usuario no agrega el documento le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Nro de Cédula del Usuario\n";
            }
            //Si es que el usuario no agrega su nombre y apellido le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre y apellido del usuario\n";
            }
            //Si es que el usuario no agrega un nombre de usuario le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario un nombre para el usuario, Ejem: ciarias\n";
            }
            //Si es que el usuario no agrega una clave le saldra un mensaje de error y su respectiva retroalimentacion
            if (obj.Clave == "")
            {
                Mensaje += "Es necesario una clave para el usuario\n";
            }
            //Si es que algun mensaje fue ejecutado no se registrara ningun usuario, caso contrario se registrara con exito el usuario
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objUsuario.EditarUsuarios(obj, out Mensaje);
            }


        }
        //Metodo para Eliminar Usuarios a la BD utilizando procedimiento almacenados definidos en la clase D_Usuario
        public bool EliminarUsuarios(Usuario obj, out string Mensaje)
        {
            return objUsuario.EliminarUsuarios(obj, out Mensaje);
        }
    }
}
