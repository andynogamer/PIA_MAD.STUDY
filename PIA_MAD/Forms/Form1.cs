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

            EnlaceDB enlace = new EnlaceDB(); // Instancia de la clase de conexión
            bool exito = enlace.InsertarUsuario("isacc");

            if (exito)
                MessageBox.Show("Usuario insertado correctamente.");
            else
                MessageBox.Show("Hubo un error al insertar el usuario.");
            FrmPantallaInicio newForm = new FrmPantallaInicio();
            
            newForm.ShowDialog();
            this.Close();
        }
    }
}
