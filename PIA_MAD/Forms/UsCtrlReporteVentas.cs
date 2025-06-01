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
    public partial class UsCtrlReporteVentas : UserControl
    {
        public UsCtrlReporteVentas()
        {
            InitializeComponent();
        }
        public void BuscarSinHotel()
        {
            EnlaceDB enlace = new EnlaceDB();
            DataTable ventas = enlace.ObtenerReporteVentas2((int)cmbPais.SelectedValue, (int)CiudadesDisponibles.SelectedValue, Convert.ToInt32(dateTimePicker1.Text));
            Ventas.DataSource = ventas;
        }
        public void CargarComboCiudades()
        {
            EnlaceDB enlace = new EnlaceDB();
            DataTable ciudades = enlace.ObtenerCiudadesDisponibles();
            CiudadesDisponibles.DataSource = ciudades;
            CiudadesDisponibles.DisplayMember = "Nombre"; // Lo que el usuario verá
            CiudadesDisponibles.ValueMember = "IdCiudad"; // Lo que realmente se usará en el código
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
        public void CargarHotelesCiudad()
        {
            EnlaceDB enlace = new EnlaceDB();
            HotelesCiudad.DisplayMember = "Nombre_Hotel";
            HotelesCiudad.ValueMember = "IdHotel";
            int idCiudadSeleccionada = Convert.ToInt32(((DataRowView)CiudadesDisponibles.SelectedItem)["IdCiudad"]);
            DataTable ciudades2 = enlace.ObtenerHotelesPorCiudad2(idCiudadSeleccionada);
            HotelesCiudad.DataSource = ciudades2;
            
        }

        private void cmbCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHotelesCiudad();
           
        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargarHotelesCiudad();
            EnlaceDB enlace = new EnlaceDB();
            // obtener Ciudad paises
            CiudadesDisponibles.DisplayMember = "Ciudad";
            CiudadesDisponibles.ValueMember = "IdCiudad";
            DataTable hoteles = enlace.ObtenerCiudadesPorPais((int)cmbPais.SelectedValue);
            CiudadesDisponibles.DataSource= hoteles;
            

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UsCtrlReporteVentas_Load(object sender, EventArgs e)
        {
            CargarPaises();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            // obtener Ciudad paises

            DataTable hoteles = enlace.ObtenerCiudadesPorPais((int)cmbPais.SelectedValue);
           

        }

        private void HotelesCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            DataTable ventas = enlace.ObtenerReporteVentas((int)cmbPais.SelectedValue, (int)CiudadesDisponibles.SelectedValue, Convert.ToInt32(dateTimePicker1.Text), (int)HotelesCiudad.SelectedValue);
            Ventas.DataSource = ventas;
            
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            BuscarSinHotel();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
