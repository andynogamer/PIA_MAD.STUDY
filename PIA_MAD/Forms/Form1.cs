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
            
         
            EnlaceDB enlace = new EnlaceDB();
            bool exito = enlace.ValidarLogin(txtCorreo.Text, txtContraseña.Text);

            if (exito)
            {
                MessageBox.Show($"Bienvenido");
                /// if para mostrar un menu u/otro
                if (Estructuras.SesionUsuario.TipoUsu == 1)
                {
                    FrmPantallaInicioADMIN newForm = new FrmPantallaInicioADMIN();
                    newForm.ShowDialog();
                    this.Close();
                }
                else
                { 
                    FrmPantallaInicio operativo = new FrmPantallaInicio(); 
                   operativo.ShowDialog();
                    this.Close();
                }
               
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos.");
            }

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmCambioContrasena frmCambio = new FrmCambioContrasena();
            frmCambio.ShowDialog(); 
        }
    }
}
