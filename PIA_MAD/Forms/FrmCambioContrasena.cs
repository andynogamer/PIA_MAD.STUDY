using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class FrmCambioContrasena : Form
    {
        public FrmCambioContrasena()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            string correo = txtCorreoCmb.Text.Trim();
            string pass1 = txtContraCmb.Text.Trim();
            string pass2 = txtContraConfirmCmb.Text.Trim();
            bool isPassValid = ValidarContrasena(pass1);

            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(pass1) || string.IsNullOrWhiteSpace(pass2))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass1 != pass2)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isPassValid)
            {
                MessageBox.Show("Todas las contraseñas deben de tener al menos 8 caracteres y debe de\r\nincluir una mayúscula, una minúscula y un caracter especial.\r\nCaracter especial es cualquier símbolo generado por el teclado que no sea\r\nletra ni número, por ejemplo: (¡”#$%&/=’?¡¿:;,.-_+*{][})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var enlace = new EnlaceDB();
            var usuario = new Usuario();
            
            enlace.CambiarContrasena(this, correo, pass1);

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void txtContraCmb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
