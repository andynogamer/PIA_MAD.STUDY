using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using WindowsFormsApplication1;

namespace PIA_MAD.Forms
{
    public partial class UsCtrlTipoHabit : UserControl
    {
        public UsCtrlTipoHabit()
        {
            InitializeComponent();
        }
        private void CargarTiposHabitacion()
        {
            EnlaceDB enlace = new EnlaceDB();
            int idHotel = Convert.ToInt32(cmbHoteles.SelectedValue); // Asegúrate de que este combo esté cargado primer
            
            cmbTiposHab.DisplayMember = "Nivel"; // Mostrar al usuario
            cmbTiposHab.ValueMember = "IdTipo";  // Usar para lógica interna
            //// la siguiente linea va al ginal de a fuerza o no funciona este pex
            cmbTiposHab.DataSource = enlace.ObtenerTiposHabitacionPorHotel2(idHotel);


        }
        private void CargarHoteles()
        {
            EnlaceDB enlace = new EnlaceDB();
            cmbHoteles.DisplayMember = "Nombre_Hotel";   // Lo que el usuario verá
            cmbHoteles.ValueMember = "IdHotel";          // El valor interno asociado
            cmbHoteles.DataSource = enlace.ObtenerHoteles();  // Método que devuelve DataTable
            cmbHoteles.SelectedIndex = -1; // opcional, para que no haya selección inicial
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            int cantPers = int.Parse(txtPersonas.Text);
            string caracteristicas =txtCaracteristicas.Text;
            string nivel = txtNivel.Text;
            int camas = int.Parse(txtCamas.Text);
            string amenidades = txtAmenidades.Text;
            float precio = float.Parse(txtPrecio.Text);
            int idHotel = (int)cmbHoteles.SelectedValue;
            string tipoCamas = txtTipoCamas.Text;

            bool ok = enlace.InsertarTipoHabitacion(cantPers, caracteristicas,nivel, camas, amenidades, precio, idHotel, tipoCamas);

            if (ok)
                MessageBox.Show("Tipo de habitación registrada correctamente.");
            else
                MessageBox.Show("Ocurrió un error al registrar el tipo de habitación.");

        }

        private void UsCtrlTipoHabit_Load(object sender, EventArgs e)
        {
            CargarHoteles();
            //CargarTiposHabitacion();

        }

        private void cmbHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTiposHabitacion();

        }

        private void cmbTiposHab_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            int idHotel = (int)cmbHoteles.SelectedValue;
            int idTipo = (int)cmbTiposHab.SelectedValue;
            DataTable dt = enlace.ObtenerTiposHabitacionPorHotel(idHotel,idTipo);

            // Llenas los campos con los datos recuperados
           // txtNombre.Text = dt.Rows[0]["NombreTipo"].ToString();
            txtNivel.Text = dt.Rows[0]["Nivel"].ToString();
            txtPrecio.Text = dt.Rows[0]["Precio"].ToString();
            txtCamas.Text = dt.Rows[0]["Camas"].ToString();
            txtTipoCamas.Text = dt.Rows[0]["Tipo_Camas"].ToString();
            txtPersonas.Text = dt.Rows[0]["Cant_Pers"].ToString();
            

        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            int idTipo = (int)cmbTiposHab.SelectedValue;
            int cantPers = int.Parse(txtPersonas.Text);
            string caracteristicas = txtCaracteristicas.Text;
            string nivel = txtNivel.Text;
            int camas = int.Parse(txtCamas.Text);
            string tipoCamas = txtTipoCamas.Text;
            float precio = float.Parse(txtPrecio.Text);

            EnlaceDB enlace = new EnlaceDB();
            bool ok = enlace.ActualizarTipoHabitacion(idTipo, cantPers, caracteristicas, nivel, camas, tipoCamas, precio);

            if (ok)
                MessageBox.Show("Tipo de habitación actualizado correctamente.");
            else
                MessageBox.Show("No se pudo actualizar el tipo de habitación.");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
