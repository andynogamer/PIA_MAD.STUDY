using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace PIA_MAD.Forms
{
    public partial class UsCtrlUsuarios : UserControl
    {
        public UsCtrlUsuarios()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            bool exito = enlace.RegistrarUsuario(siticoneTextBox8.Text, ApPaternotxt.Text, ApMaternotxt.Text, siticoneTextBox2.Text,
                siticoneTextBox4.Text, siticoneDateTimePicker1.Value, siticoneTextBox6.Text, siticoneTextBox5.Text,
                siticoneTextBox7.Text,Estructuras.SesionUsuario.TipoUsu);

            if (exito)
            {
                MessageBox.Show($"SE logro insertar correctamente");
            }
            else
            {
                MessageBox.Show("Verifique los campos.");
            }

        }
    }
}
