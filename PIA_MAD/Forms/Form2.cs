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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void CargarPaises()
        {
            EnlaceDB enlace = new EnlaceDB();
            cmbPais.SelectedIndexChanged -= cmbPais_SelectedIndexChanged;
            cmbPais.DataSource = enlace.ObtenerPaises(); // método que retorna DataTable
            cmbPais.DisplayMember = "Nombre";
            cmbPais.ValueMember = "IdPais";
            cmbPais.SelectedIndex = -1;

            cmbPais.SelectedIndexChanged += cmbPais_SelectedIndexChanged;
        }
        private void CargarEstados(int idPais)
        {
            EnlaceDB enlace = new EnlaceDB();

            // Previene bucles al recargar
            cmdEstado.SelectedIndexChanged -= cmdEstado_SelectedIndexChanged;

            cmdEstado.DataSource = enlace.ObtenerEstados(idPais); // Devuelve DataTable
            cmdEstado.DisplayMember = "Nombre";
            cmdEstado.ValueMember = "IdEstado";
            cmdEstado.SelectedIndex = -1;

            cmdEstado.SelectedIndexChanged += cmdEstado_SelectedIndexChanged;
        }
        private void CargarCiudades(int idEstado)
        {
            EnlaceDB enlace = new EnlaceDB();

            cmbCiudad.SelectedIndexChanged -= cmbCiudad_SelectedIndexChanged;

            cmbCiudad.DataSource = enlace.ObtenerCiudades(idEstado);
            cmbCiudad.DisplayMember = "Nombre";
            cmbCiudad.ValueMember = "IdCiudad";
            cmbCiudad.SelectedIndex = -1;

            cmbCiudad.SelectedIndexChanged += cmbCiudad_SelectedIndexChanged;
        }

       

      
        private void Form2_Load(object sender, EventArgs e)
        {
            CargarPaises();
        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEstados((int)cmbPais.SelectedValue);
        }

        private void cmdEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCiudades((int)cmdEstado.SelectedValue);
        }

        private void cmbCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void siticoneComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            enlace.InsertarPais(PaisText.Text);
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            enlace.InsertarEstado(EstadoText.Text,(int)cmbPais.SelectedValue);
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            enlace.InsertarCiudad(CiudadText.Text, (int)cmdEstado.SelectedValue);
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            enlace.InsertarMunicipio(MunicipioText.Text, (int)cmbCiudad.SelectedValue);
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            enlace.InsertarColonia(ColoniaText.Text,(int)cmbMunicipio.SelectedValue);
        }
    }
}
