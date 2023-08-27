using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeMarket.Clases;

namespace CodeMarket
{
    public partial class frmLogin : Form 
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            //Cierra la ventana
            this.Close();
        }

        //Funcion para volver al formulario Login despues de cerrar el Formulario Inicio
        private void abrirFormulario(object sender, FormClosingEventArgs e) {
            txtusuario.Text = "";
            txtclave.Text = "";
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void btningresar_Click_1(object sender, EventArgs e)
        {
            //Instancia de la tabla Usuario y la Clase UsuarioDB para listar los usuarios y acceder 
            List<Usuario> Test = new List<Usuario>();
            Usuario ousuario = new N_Usuario().TraerUsuario().Where(u => u.Correo == txtusuario.Text && u.Clave == txtclave.Text).FirstOrDefault();
            if (ousuario != null)
            {
                //Mostramos el formulario Inicio y ocultamos el formulario Login
                frmInicio formularioInicio = new frmInicio(ousuario);
                formularioInicio.Show();
                this.Hide();
                formularioInicio.FormClosing += abrirFormulario;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
