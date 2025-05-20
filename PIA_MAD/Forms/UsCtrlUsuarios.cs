using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using static PIA_MAD.Forms.Estructuras;

namespace PIA_MAD.Forms
{
    public partial class UsCtrlUsuarios : UserControl
    {
        private int idSeleccionado = -1;
        public UsCtrlUsuarios()
        {
            InitializeComponent();
            int usuType = SesionUsuario.TipoUsu;
            if (usuType == 2)
            {
                siticoneButton2.Enabled = false;
            }


        }

        public static bool ValidarContrasena(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 8)
                return false;

            bool tieneMayuscula = Regex.IsMatch(password, "[A-Z]");
            bool tieneMinuscula = Regex.IsMatch(password, "[a-z]");
            bool tieneEspecial = Regex.IsMatch(password, @"[!""#$%&/=\'?¡¿:;,.\-_+\*\{\}\[\]]");

            return tieneMayuscula && tieneMinuscula && tieneEspecial;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void CargarUsuarios()
        {
            EnlaceDB enlace = new EnlaceDB();

            // Llamamos al procedimiento MostrarUsu
            siticoneDataGridView1.DataSource = enlace.ObtenerUsuarios();

            // Ajustamos el tamaño de las columnas
            siticoneDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Opcional: Si quieres dar nombres personalizados a las columnas
            /*siticoneDataGridView1.Columns["IdUsuario"].HeaderText = "ID de Usuario";
            siticoneDataGridView1.Columns["Nombre_Usu"].HeaderText = "Nombre del Usuario";
            siticoneDataGridView1.Columns["ApPaterno"].HeaderText = "Apellido Paterno";
            siticoneDataGridView1.Columns["ApMaterno"].HeaderText = "Apellido Materno";
            siticoneDataGridView1.Columns["Correo"].HeaderText = "Correo Electrónico";
            siticoneDataGridView1.Columns["FechaNac"].HeaderText = "Fecha de Nacimiento";
            siticoneDataGridView1.Columns["Tel_casa"].HeaderText = "Teléfono Casa";
            siticoneDataGridView1.Columns["Tel_cel"].HeaderText = "Teléfono Celular";
            siticoneDataGridView1.Columns["Estatus"].HeaderText = "Estatus";
            siticoneDataGridView1.Columns["FechRegis"].HeaderText = "Fecha de Registro";
            siticoneDataGridView1.Columns["Fech_act"].HeaderText = "Fecha de Actualizacion"; */
        }


        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            // validar que los campos no esten vacios...
            EnlaceDB enlace = new EnlaceDB();
            if (!ValidarContrasena(siticoneTextBox7.Text))
            {
                MessageBox.Show("Todas las contraseñas deben de tener al menos 8 caracteres y debe de\r\nincluir una mayúscula, una minúscula y un caracter especial.\r\nCaracter especial es cualquier símbolo generado por el teclado que no sea\r\nletra ni número, por ejemplo: (¡”#$%&/=’?¡¿:;,.-_+*{][})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool exito = enlace.RegistrarUsuario(siticoneTextBox8.Text, ApPaternotxt.Text, ApMaternotxt.Text, siticoneTextBox2.Text,
                siticoneTextBox4.Text, siticoneDateTimePicker1.Value, siticoneTextBox6.Text, siticoneTextBox5.Text,
                siticoneTextBox7.Text,Estructuras.SesionUsuario.IdUsuario);

            if (exito)
            {
                MessageBox.Show($"SE logro insertar correctamente");
            }
            else
            {
                MessageBox.Show("Verifique los campos.");
            }

        }

        private void UsCtrlUsuarios_Load(object sender, EventArgs e)
        {
            siticoneDateTimePicker1.MinDate = new DateTime(1900, 1, 1);                  // No permitir fechas antes de 1900
            siticoneDateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);             // Solo mayores de 18 años
            siticoneDateTimePicker1.Value = DateTime.Today.AddYears(-18);
            CargarUsuarios();

        }

        private void siticoneDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = siticoneDataGridView1.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["ID de Usuario"].Value);
            }
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un usuario primero.");
                return;
            }

            // Obtén la fila actual
            var fila = siticoneDataGridView1.SelectedRows[0];
            string estatusActual = fila.Cells["Estatus"].Value.ToString();

            // Determinar nuevo estatus
            string nuevoEstatus = (estatusActual == "Habilitado") ? "D" : "H";

            // Llamar procedimiento
            EnlaceDB enlace = new EnlaceDB();
            bool actualizado = enlace.CambiarEstatusUsuario(idSeleccionado, nuevoEstatus);

            if (actualizado)
            {
                MessageBox.Show("Estatus actualizado correctamente.");
                CargarUsuarios(); // Recargar usuarios en el grid
            }
            else
            {
                MessageBox.Show("Error al actualizar estatus.");
            }
        }

        private void siticoneTextBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
