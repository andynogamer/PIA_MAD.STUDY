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
            DataSet informeData = enlace.ObtenerReporteOcupacionHotel((int)CiudadesDisponibles.SelectedValue, Convert.ToInt32(dateTimePicker1.Text), null); ;

            if (checkBox1.Checked)
            {
                informeData = enlace.ObtenerReporteOcupacionHotel((int)CiudadesDisponibles.SelectedValue, Convert.ToInt32(dateTimePicker1.Text), (int)HotelesCiudad.SelectedValue);
            }
            
            if (informeData != null && informeData.Tables.Count > 0)
            {
                DataTable tablaDetalle = informeData.Tables[0];
                Report1.DataSource = tablaDetalle;
            }
            if (informeData != null && informeData.Tables.Count > 1)
            {
                DataTable tablaDetalle = informeData.Tables[1];
                Repoert2.DataSource = tablaDetalle;
            }


        }
        private void CargarPaises()
        {
            EnlaceDB enlace = new EnlaceDB();
            cmbPais.DisplayMember = "Nombre";
            cmbPais.ValueMember = "IdPais";
            cmbPais.SelectedIndexChanged -= cmbPais_SelectedIndexChanged;
            cmbPais.DataSource = enlace.ObtenerPaises(); // método que retorna DataTable
            
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

            CiudadesDisponibles.DisplayMember = "Ciudad";
            CiudadesDisponibles.ValueMember = "IdCiudad";
            DataTable hoteles = enlace.ObtenerCiudadesPorPais((int)cmbPais.SelectedValue);
            CiudadesDisponibles.DataSource = hoteles;
            
        }

        private void CiudadesDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHotelesCiudad();
        }

        private void HotelesCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            /// hay que modifcar a la funcion correspondiente son 2 
            EnlaceDB enlace = new EnlaceDB();
            DataSet ventas = enlace.ObtenerReporteOcupacionHotel( (int)CiudadesDisponibles.SelectedValue, Convert.ToInt32(dateTimePicker1.Text), (int)HotelesCiudad.SelectedValue);
            
            
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            BuscarSinHotel();

        }
    }
}
