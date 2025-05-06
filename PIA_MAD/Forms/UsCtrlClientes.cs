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
    public partial class UsCtrlClientes : UserControl
    {
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

        private void CargarMunicipios(int idCiudad)
        {
            EnlaceDB enlace = new EnlaceDB();

            cmbMunicipio.SelectedIndexChanged -= cmbMunicipio_SelectedIndexChanged;

            cmbMunicipio.DataSource = enlace.ObtenerMunicipios(idCiudad);
            cmbMunicipio.DisplayMember = "Nombre";
            cmbMunicipio.ValueMember = "IdMunicipio";
            cmbMunicipio.SelectedIndex = -1;

            cmbMunicipio.SelectedIndexChanged += cmbMunicipio_SelectedIndexChanged;
        }

        private void CargarColonias(int idMunicipio)
        {
            EnlaceDB enlace = new EnlaceDB();

            cmbColonia.DataSource = enlace.ObtenerColonias(idMunicipio);
            cmbColonia.DisplayMember = "Nombre";
            cmbColonia.ValueMember = "IdColonia";
            cmbColonia.SelectedIndex = -1;
        }
        private void CargarCodigoPostal(int idColonia)
        {
            EnlaceDB enlace = new EnlaceDB();
            string codigoPostal = enlace.ObtenerCodigoPostalPorColonia(idColonia); // Este método lo creas en EnlaceDB

            if (!string.IsNullOrEmpty(codigoPostal))
            {
                siticoneComboBoxColonia.Text = codigoPostal; // Asume que tienes un TextBox llamado txtCodigoPostal
            }
        }
        public UsCtrlClientes()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            var enlaces = new EnlaceDB();

            int idDir = enlaces.InsertarDireccion(
       (int)cmbPais.SelectedValue,
       (int)cmdEstado.SelectedValue,
       (int)cmbCiudad.SelectedValue,
       cmbMunicipio.SelectedIndex != -1 ? (int?)cmbMunicipio.SelectedValue : null,
       cmbColonia.SelectedIndex != -1 ? (int?)cmbColonia.SelectedValue : null,
       Calle.Text,
       NumExterior.Text,
       NumInterior.Text
   );

            if (idDir <= 0)
            {
                MessageBox.Show("Error al crear la dirección.");
                return;
            }
            // 2) Ahora inserto el hotel usando una instancia de EnlaceDB
            char estadoCivilSeleccionado = ((KeyValuePair<char, string>)cmbEstadoCivil.SelectedItem).Key;

            bool ok = enlaces.InsertarCliente(txtRFC.Text,txtNombres.Text,txtApPaterno.Text,txtApMaterno.Text,idDir,txtTelCasa.Text,
    txtTelCel.Text,txtCorreo.Text, estadoCivilSeleccionado, // suponiendo que el ComboBox guarda 'C' o 'S'
    dtpFechaNac.Value.Date);

            if (ok)
                MessageBox.Show("Hotel registrado correctamente.");
            else
                MessageBox.Show("Error al registrar el hotel.");
        }

        private void siticoneDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void UsCtrlClientes_Load(object sender, EventArgs e)
        {
            Dictionary<char, string> estadoCivil = new Dictionary<char, string>()
        {
        { 'C', "Casado" },
        { 'S', "Soltero" }
        };

            cmbEstadoCivil.DataSource = new BindingSource(estadoCivil, null);
            cmbEstadoCivil.DisplayMember = "Value"; // Lo que ve el usuario
            cmbEstadoCivil.ValueMember = "Key";     // Lo que se usará internamente
            CargarPaises();
            dtpFechaNac.MinDate = new DateTime(1900, 1, 1);                  // No permitir fechas antes de 1900
            dtpFechaNac.MaxDate = DateTime.Today.AddYears(-18);             // Solo mayores de 18 años
            dtpFechaNac.Value = DateTime.Today.AddYears(-18);
        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPais.SelectedValue != null && int.TryParse(cmbPais.SelectedValue.ToString(), out int idPaisSeleccionado))
            {
                CargarEstados(idPaisSeleccionado);
            }
        }

        private void cmdEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdEstado.SelectedIndex != -1)
            {
                int idEstadoSeleccionado = (int)cmdEstado.SelectedValue;
                CargarCiudades(idEstadoSeleccionado);
            }
        }

        private void cmbCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCiudad.SelectedIndex != -1)
            {
                int idCiudadSeleccionada = (int)cmbCiudad.SelectedValue;
                CargarMunicipios(idCiudadSeleccionada);
            }
        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMunicipio.SelectedIndex != -1)
            {
                int idMunicipioSeleccionado = (int)cmbMunicipio.SelectedValue;
                CargarColonias(idMunicipioSeleccionado);
            }
        }

        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMunicipio.SelectedIndex != -1)
            {
                int idColonia = Convert.ToInt32(cmbMunicipio.SelectedValue);
                CargarCodigoPostal(idColonia);
            }
        }
    }
}
