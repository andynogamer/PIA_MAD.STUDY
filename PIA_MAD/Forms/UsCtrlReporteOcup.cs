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
    public partial class UsCtrlReporteOcup : UserControl
    {
        public UsCtrlReporteOcup()
        {
            InitializeComponent();
        }
        public void BuscarSinHotel()
        {
            EnlaceDB enlace = new EnlaceDB();
            DataTable ventas = enlace.ObtenerReporteOcupacionHotel((int)cmbPais.SelectedValue, (int)CiudadesDisponibles.SelectedValue, Convert.ToInt32(dateTimePicker1.Text),null);

            Report1.DataSource = ventas;
            DataTable reporte2 = enlace.ObtenerResumenOcupacionHotel((int)cmbPais.SelectedValue, (int)CiudadesDisponibles.SelectedValue, Convert.ToInt32(dateTimePicker1.Text),null);
            Repoert2.DataSource = reporte2;
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
            int idCiudadSeleccionada = Convert.ToInt32(((DataRowView)CiudadesDisponibles.SelectedItem)["IdCiudad"]);
            DataTable ciudades2 = enlace.ObtenerHotelesPorCiudad2(idCiudadSeleccionada);
            HotelesCiudad.DataSource = ciudades2;
            HotelesCiudad.DisplayMember = "Nombre_Hotel";
            HotelesCiudad.ValueMember = "IdHotel";
        }
        private void UsCtrlReporteOcup_Load(object sender, EventArgs e)
        {
            CargarPaises();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            // obtener Ciudad paises

            DataTable hoteles = enlace.ObtenerCiudadesPorPais((int)cmbPais.SelectedValue);
            CiudadesDisponibles.DataSource = hoteles;
            CiudadesDisponibles.DisplayMember = "Ciudad";
            CiudadesDisponibles.ValueMember = "IdCiudad";
        }

        private void CiudadesDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHotelesCiudad();
        }

        private void HotelesCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            /// hay que modifcar a la funcion correspondiente son 2 
            EnlaceDB enlace = new EnlaceDB();
            DataTable ventas = enlace.ObtenerReporteOcupacionHotel((int)cmbPais.SelectedValue, (int)CiudadesDisponibles.SelectedValue, Convert.ToInt32(dateTimePicker1.Text), (int)HotelesCiudad.SelectedValue);
            
            Report1.DataSource = ventas;
            DataTable reporte2 = enlace.ObtenerResumenOcupacionHotel((int)cmbPais.SelectedValue, (int)CiudadesDisponibles.SelectedValue, Convert.ToInt32(dateTimePicker1.Text), (int)HotelesCiudad.SelectedValue);
            Repoert2.DataSource = reporte2;
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            BuscarSinHotel();

        }
    }
}
