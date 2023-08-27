using CodeMarket.Clases;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;


namespace CodeMarket
{
    public partial class frmInicio : Form
    {
        private static Usuario usuarioActual;
        //variables para indicar que formulario esta activo en el panel
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        internal frmInicio(Usuario objusuario)
        {
            usuarioActual = objusuario;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermisos = new N_Permiso().ListarPermiso(usuarioActual.IdUsuario);
            foreach (IconMenuItem iconMenu in menu.Items) {
                bool encontrado = listaPermisos.Any(m => m.NombreMenu == iconMenu.Name);
                if (encontrado == false) {
                    iconMenu.Visible = false;
                }
            }
            lblusuario.Text = usuarioActual.NombreCompleto;
        }
        //Metodo para abrir los formularios
        private void AbrirFormularios(IconMenuItem menu, Form formulario){
            //Si es que ya hay un menu activo, que se ponga de color blanco
            if (MenuActivo != null) {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;
            if (FormularioActivo !=null) {
                FormularioActivo.Close();
            }
            //configurar el formulario
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.Firebrick;
            //Agregar el formulario al contenedor
            contenedor.Controls.Add(formulario);
            formulario.Show();

        }
        //Abrir el formulario Usuario
        private void menuusuario_Click(object sender, EventArgs e)
        {
            AbrirFormularios((IconMenuItem)sender, new frmUsuarios());
        }

        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menumantenedor, new frmCategoria());
        }

        private void submenuproducto_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menumantenedor, new frmProducto());
        }

        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menumantenedor, new frmVentas());
        }

        private void submenuverdetalleventa_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menumantenedor, new frmDetalleVenta());
        }

        private void submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menumantenedor, new frmCompras());
        }

        private void submenuverdetallecompra_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menumantenedor, new frmDetalleCompra());
        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormularios((IconMenuItem)sender, new frmClientes());
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormularios((IconMenuItem)sender, new frmProveedores());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            AbrirFormularios((IconMenuItem)sender, new frmReportes());
        }

    }
}
