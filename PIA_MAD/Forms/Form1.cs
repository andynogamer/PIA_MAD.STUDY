using PIA_MAD.Forms;
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

namespace PIA_MAD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            /// hay que cambiar el registro de insertar usuario.
            /// hay que hacer que dependiendo el usuario vaya a una pantalla y deshabilite lo que no puede hacer.
            /// 
            EnlaceDB enlace = new EnlaceDB();
            bool exito = enlace.ValidarLogin(txtCorreo.Text, txtContraseña.Text);

            if (exito)
            {
                MessageBox.Show($"Bienvenido. ID de Usuario: {Estructuras.SesionUsuario.IdUsuario}, Tipo de usuario:  {Estructuras.SesionUsuario.TipoUsu}");

                FrmPantallaInicio newForm = new FrmPantallaInicio();
                newForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos.");
            }

        }
    }
}
