using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PIA_MAD.Forms
{
    public partial class UsCtrlHabit : UserControl
    {
        public UsCtrlHabit()
        {
            InitializeComponent();
        }
        private void CargarHoteles()
        {
            EnlaceDB enlace = new EnlaceDB();
            cmbHoteles.DisplayMember = "Nombre_Hotel";   // Lo que el usuario verá
            cmbHoteles.ValueMember = "IdHotel";          // El valor interno asociado
            cmbHoteles.DataSource = enlace.ObtenerHoteles();  // Método que devuelve DataTable
            cmbHoteles.SelectedIndex = -1; // opcional, para que no haya selección inicial
        }
        private void CargarTiposHabitacion()
        {
            EnlaceDB enlace = new EnlaceDB();
            int idHotel = Convert.ToInt32(cmbHoteles.SelectedValue); // Asegúrate de que este combo esté cargado primer

            cmbTiposHab.DisplayMember = "Nivel"; // Mostrar al usuario
            cmbTiposHab.ValueMember = "IdTipo";  // Usar para lógica interna
            //// la siguiente linea va al ginal de a fuerza o no funciona este pex
            cmbTiposHab.DataSource = enlace.ObtenerTiposHabitacionPorHotel2(idHotel);

            TipHabitacion.DisplayMember = "Nivel";
            TipHabitacion.ValueMember = "IdTipo";
            TipHabitacion.DataSource=enlace.ObtenerTiposHabitacionPorHotel2(idHotel);


        }
        private void CargarHabitaciones()
        {
            int idHotel = (int)cmbHoteles.SelectedValue;
            int TipHab = (int)cmbTiposHab.SelectedValue;
            EnlaceDB enlace = new EnlaceDB();
            Habitaciones.DisplayMember = "Numero_Habitacion";   // Lo que el usuario verá
            Habitaciones.ValueMember = "Numero_Habitacion";          // El valor interno asociado
            Habitaciones.DataSource = enlace.BuscarHabitaciones(idHotel,TipHab);  // Método que devuelve DataTable
            Habitaciones.SelectedIndex = -1; // opcional, para que no haya selección inicial
        }

        private void siticoneComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void UsCtrlHabit_Load(object sender, EventArgs e)
        {
            CargarHoteles();
        }

        private void siticoneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTiposHabitacion();
        }

        private void cmbTiposHab_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHabitaciones();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            int cant = Convert.ToInt32(Cantidad.Text);
            var enlaces = new EnlaceDB();
        
        int idHotel = (int)cmbHoteles.SelectedValue;
        int TipHab = (int)cmbTiposHab.SelectedValue;
        int NumHabi = Convert.ToInt32(NumHabitacion.Text);
        
        string caract = Caracterisiticas.Text;
            for(int i=0;i<=cant-1; i++)
            {
                bool ok = enlaces.InsertarHabitaciones(idHotel, NumHabi+i, TipHab, caract);
                if (ok)
                    MessageBox.Show("Habitacion registrada correctamente.");
                else
                    MessageBox.Show("Error al registrar habitacion.");
            }
            
            
        }

        private void siticoneComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            int idHotel = (int)cmbHoteles.SelectedValue;
            int TipHab = (int)TipHabitacion.SelectedValue;
            int NumHabi = Convert.ToInt32(Habitaciones.Text);
            string status = Estatus.Text;
            string caracteris = Caracterisiticas.Text;
            var enlaces = new EnlaceDB();
            bool ok = enlaces.ActualizarHabitacion(idHotel,NumHabi,TipHab,status,caracteris);
            if (ok)
                MessageBox.Show("Habitacion actualizada Correctamente.");
            else
                MessageBox.Show("Error al registrar el hotel.");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
