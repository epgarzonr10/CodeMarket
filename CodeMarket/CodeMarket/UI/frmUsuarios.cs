using CodeMarket.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeMarket
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            //Llenado de ComboBox para el apartado de Estado
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo"});
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            //Llenado de ComboBox para el apartado de Rol desde la BD

            List<Rol> listaRol = new N_Rol().ListarRol();
            foreach (Rol item  in listaRol) {
            cborol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cborol.DisplayMember = "Texto";
            cborol.ValueMember = "Valor";
            cborol.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvdata.Columns) {
                if (columna.Visible ==true && columna.Name != "btnseleccionar") {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText});
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            //Mostar todos los usuarios

            List<Usuario> listaUsuario = new N_Usuario().TraerUsuario();
            foreach (Usuario item in listaUsuario)
            {
                dgvdata.Rows.Add(new object[] {"",item.IdUsuario,item.Documento,item.NombreCompleto,item.Correo,item.Clave,
                    item.oRol.IdRol, item.oRol.Descripcion,item.Estado == true ? 1 : 0, item.Estado == true ? "Activo" : "No Activo",          
                });
            }
        }
        //Metodo para guardar los datos en el datagridview
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            //Pase de los valores de los text box a las propiedades 
            Usuario objusuario = new Usuario() {
                IdUsuario = Convert.ToInt32(txtid.Text),
                Documento = txtdocumento.Text,
                NombreCompleto = txtnombreyapellido.Text,
                Correo = txtnombreusuario.Text,
                Clave = txtclave.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cborol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };
            //Si es que el usuario no se encuentra en la BD se registra como nuevo
            if (objusuario.IdUsuario == 0)
            {
                int idusuariogenerado = new N_Usuario().RegistrarUsuarios(objusuario, out Mensaje);
                if (idusuariogenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"",idusuariogenerado,txtdocumento.Text,txtnombreyapellido.Text,txtnombreusuario.Text,txtclave.Text,
                ((OpcionCombo)cborol.SelectedItem).Valor.ToString(),((OpcionCombo)cborol.SelectedItem).Texto.ToString(),
                ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),((OpcionCombo)cboestado.SelectedItem).Texto.ToString()
                });
                    MessageBox.Show("El usuario se a REGISTRADO con exito");
                    limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
            //Caso contrario se edita el usuario
            else { 
                bool resultado= new N_Usuario().EditarUsuarios(objusuario, out Mensaje);
                if (!resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txtdocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtnombreyapellido.Text;
                    row.Cells["Correo"].Value = txtnombreusuario.Text;
                    row.Cells["Clave"].Value = txtclave.Text;
                    row.Cells["IdRol"].Value = ((OpcionCombo)cborol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((OpcionCombo)cborol.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();
                    MessageBox.Show("El usuario se a EDITADO con exito");
                    limpiar();
                }
                else {
                    MessageBox.Show(Mensaje);
                }

            }
           
        }
        //Metodo para limpiar los datos de los textbox
        private void limpiar (){
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtnombreyapellido.Text = "";
            txtnombreusuario.Text = "";
            txtclave.Text = "";
            txtconfirmarclave.Text = "";
            cborol.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;
            txtdocumento.Select();
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex<0) {
                return;
            }
            if (e.ColumnIndex ==0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check.Width;
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width-w)/2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                e.Handled = true;

            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name== "btnseleccionar") {
                int indice = e.RowIndex;
                if (indice>=0) {
                    txtindice.Text = indice.ToString(); 
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombreyapellido.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtnombreusuario.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    txtconfirmarclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    foreach (OpcionCombo oc in cborol.Items) {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdRol"].Value) ) { 
                            int indice_combo = cborol.Items.IndexOf(oc);
                            cborol.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            //condicional para saber si a seleccionado un usuario
            if (Convert.ToInt32(txtid.Text) != 0) {
                if (MessageBox.Show("¿Desea ELIMINAR el usuario?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes) {
                    string Mensaje = string.Empty;
                    Usuario objusuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(txtid.Text),
                      };
                    bool respuesta = new N_Usuario().EliminarUsuarios(objusuario, out Mensaje);
                    //condicional para eliminar el usuario 
                    if (!respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        MessageBox.Show("El usuario se a ELIMINADO con exito");
                        limpiar();
                    }
                    else { 
                        MessageBox.Show(Mensaje,"Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                } 
            }
        }

        private void txtbusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            string columnafiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnafiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
