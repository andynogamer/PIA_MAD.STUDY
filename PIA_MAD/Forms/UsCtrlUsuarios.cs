using Siticone.Desktop.UI.WinForms;
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
            dgvUsuarios.DataSource = enlace.ObtenerUsuarios();
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
          
        }


        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            // validar que los campos no esten vacios...
            if (idSeleccionado == -1)
            {
                EnlaceDB enlace = new EnlaceDB();
                if (!ValidarContrasena(txtContra.Text))
                {
                    MessageBox.Show("Todas las contraseñas deben de tener al menos 8 caracteres y debe de\r\nincluir una mayúscula, una minúscula y un caracter especial.\r\nCaracter especial es cualquier símbolo generado por el teclado que no sea\r\nletra ni número, por ejemplo: (¡”#$%&/=’?¡¿:;,.-_+*{][})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool exito = enlace.RegistrarUsuario(txtNombres.Text, ApPaternotxt.Text, ApMaternotxt.Text, TxtCorreo.Text,
                    txtNomi.Text, dtpNac.Value, TxtCasa.Text, txtCel.Text,
                    txtContra.Text, Estructuras.SesionUsuario.IdUsuario);
                idSeleccionado = -1;

                if (exito)
                {
                    MessageBox.Show($"Se logro insertar correctamente");
                    txtNombres.Clear();
                    ApPaternotxt.Clear();
                    ApMaternotxt.Clear();
                    TxtCorreo.Clear();
                    txtNomi.Clear();
                    dtpNac.Value = DateTime.Today.AddYears(-18);
                    TxtCasa.Clear();
                    txtCel.Clear();
                    txtContra.Clear();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Verifique los campos.");
                }
                
            }
            else
            {
                    MessageBox.Show($"Tenia seleccionado un id, id limpio");
                idSeleccionado = -1;
            }

        }

        private void UsCtrlUsuarios_Load(object sender, EventArgs e)
        {
            dtpNac.MinDate = new DateTime(1900, 1, 1);                  // No permitir fechas antes de 1900
            dtpNac.MaxDate = DateTime.Today.AddYears(-18);             // Solo mayores de 18 años
            dtpNac.Value = DateTime.Today.AddYears(-18);
            CargarUsuarios();
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
          
        }



        private void siticoneButton2_Click(object sender, EventArgs e)
        {
          
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un usuario primero.");
                return;
            }
            /// tecnicamente con que se seleccione la fila... 
            // Obtén la fila actual
            var fila = dgvUsuarios.SelectedRows[0];
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
            CargarUsuarios();
        }

        private void siticoneTextBox7_TextChanged(object sender, EventArgs e)
        {

            string password = txtContra.Text;
            string mensaje = "";
            Color color = Color.Red;

            bool tieneMayuscula = Regex.IsMatch(password, "[A-Z]");
            bool tieneMinuscula = Regex.IsMatch(password, "[a-z]");
            bool tieneEspecial = Regex.IsMatch(password, @"[!""#$%&/='?¡¿:;,.\-_+\*\{\}\[\]]");
            bool longitudValida = password.Length >= 8;

            if (!longitudValida)
                mensaje = "Debe tener al menos 8 caracteres.";
            else if (!tieneMayuscula)
                mensaje = "Debe contener al menos una letra mayúscula.";
            else if (!tieneMinuscula)
                mensaje = "Debe contener al menos una letra minúscula.";
            else if (!tieneEspecial)
                mensaje = "Debe contener al menos un carácter especial.";
            else
            {
                mensaje = "Contraseña válida.";
                color = Color.Green;
            }

            verificacionlbl.Text = mensaje;
            verificacionlbl.ForeColor = color;

        }

        private void siticoneComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];
                // para mostrar al seleccionado
                string nombreCompleto = $"{fila.Cells["Nombres"].Value} {fila.Cells["Apellido_Paterno"].Value} {fila.Cells["Apellido_Materno"].Value}";
                DialogResult result = MessageBox.Show($"¿Desea seleccionar a:\n\n{nombreCompleto}\n?",
                                                    "Confirmar cliente",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    idSeleccionado = Convert.ToInt32(fila.Cells["IdUsuario"].Value);
                    nombreCompleto = $"Usuario seleccionado: {nombreCompleto}";
                }
                EnlaceDB enlace = new EnlaceDB();
                DataTable dt = enlace.ObtenerUsuarioPorId(idSeleccionado);
                if (dt.Rows.Count > 0)
                {
                    DataRow fila2 = dt.Rows[0];
                    txtNombres.Text = fila2["Nombre_Usu"].ToString();
                    ApPaternotxt.Text = fila2["ApPaterno"].ToString();
                    ApMaternotxt.Text = fila2["ApMaterno"].ToString();
                    TxtCorreo.Text = fila2["Correo"].ToString();
                    txtNomi.Text = fila2["NNS"].ToString();
                    ApMaternotxt.Text = fila2["ApMaterno"].ToString();
                    dtpNac.Value = Convert.ToDateTime(fila2["FechaNac"]);
                    TxtCasa.Text = fila2["Tel_casa"].ToString();
                    txtCel.Text = fila2["Tel_cel"].ToString();
                    txtContra.Text = fila2["Pass"].ToString();
                }
                
            }
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {

            // Si actualmente está ocultando la contraseña
            if (txtContra.PasswordChar == '*')
            {
                txtContra.PasswordChar = '\0'; // Muestra el texto
                btnMostrarOcultar.Text = "Ocultar";
            }
            else
            {
                txtContra.PasswordChar = '*'; // Oculta el texto
                btnMostrarOcultar.Text = "Mostrar";
            }

        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea la tecla
            }

        }

        private void ApPaternotxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea la tecla
            }

        }

        private void ApMaternotxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea la tecla
            }

        }

        private void txtNomi_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void TxtCasa_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtCel_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void TxtCorreo_Leave(object sender, EventArgs e)
        {

            string correo = TxtCorreo.Text.ToLower();
            string[] dominiosValidos = { "@hotmail.com", "@outlook.com", "@gmail.com", "@outlook.es" };

            bool esValido = dominiosValidos.Any(d => correo.EndsWith(d));

            if (!esValido)
            {
                MessageBox.Show("El correo debe ser de tipo Hotmail, Outlook, Live o MSN.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCorreo.Focus();
            }

        }

        private void siticoneButton3_Click_1(object sender, EventArgs e)
        {
            // validar que los campos no esten vacios...
            if (idSeleccionado == -1)
            {
                    MessageBox.Show("Seleccione un usuario!");
            }
            else
            {
                if (!ValidarContrasena(txtContra.Text))
                {
                    MessageBox.Show("Todas las contraseñas deben de tener al menos 8 caracteres y debe de\r\nincluir una mayúscula, una minúscula y un caracter especial.\r\nCaracter especial es cualquier símbolo generado por el teclado que no sea\r\nletra ni número, por ejemplo: (¡”#$%&/=’?¡¿:;,.-_+*{][})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // aqui va el update....
                EnlaceDB enlace = new EnlaceDB();
                bool exito = enlace.ActualizarUsuario(idSeleccionado, txtNombres.Text, ApPaternotxt.Text, ApMaternotxt.Text, TxtCorreo.Text, txtNomi.Text, dtpNac.Value, txtCel.Text, txtCel.Text, txtContra.Text);
                if (exito)
                {
                    MessageBox.Show($"Se logro Actualizar correctamente");
                    idSeleccionado = -1;
                    txtNombres.Clear();
                    ApPaternotxt.Clear();
                    ApMaternotxt.Clear();
                    TxtCorreo.Clear();
                    txtNomi.Clear();
                    dtpNac.Value = DateTime.Today.AddYears(-18);
                    TxtCasa.Clear();
                    txtCel.Clear();
                    txtContra.Clear();
                }
                else
                {
                    MessageBox.Show("Verifique los campos.");
                    idSeleccionado = -1;
                    txtNombres.Clear();
                    ApPaternotxt.Clear();
                    ApMaternotxt.Clear();
                    TxtCorreo.Clear();
                    txtNomi.Clear();
                    dtpNac.Value = DateTime.Today.AddYears(-18);
                    TxtCasa.Clear();
                    txtCel.Clear();
                    txtContra.Clear();

                }
                CargarUsuarios();
            }
        }
    }

}
