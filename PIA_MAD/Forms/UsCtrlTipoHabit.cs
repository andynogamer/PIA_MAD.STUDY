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
           /* EnlaceDB enlace = new EnlaceDB();
            int idHotel = Convert.ToInt32(cmbHoteles.SelectedValue); // Asegúrate de que este combo esté cargado primer
            
            cmbTiposHab.DisplayMember = "Nivel"; // Mostrar al usuario
            cmbTiposHab.ValueMember = "IdTipo";  // Usar para lógica interna
            //// la siguiente linea va al ginal de a fuerza o no funciona este pex
            cmbTiposHab.DataSource = enlace.ObtenerTiposHabitacionPorHotel2(idHotel);

*/
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
           
            /*EnlaceDB enlace = new EnlaceDB();
            int cantPers = (int)txtPersonas.Value;
            string caracteristicas =txtCaracteristicas.Text;
            string nivel = txtNivel.Text;
            int camas = (int)txtCamas.Value;
            string amenidades = txtAmenidades.Text;
            decimal precio = txtPrecio.Value;
            int idHotel = (int)cmbHoteles.SelectedValue;
            string tipoCamas = txtTipoCamas.Text;

            bool ok = enlace.InsertarTipoHabitacion(cantPers, caracteristicas,nivel, camas, amenidades, precio, idHotel, tipoCamas);

            if (ok)
                MessageBox.Show("Tipo de habitación registrada correctamente.");
            else
                MessageBox.Show("Ocurrió un error al registrar el tipo de habitación.");
            */
        }

        private void UsCtrlTipoHabit_Load(object sender, EventArgs e)
        {
            txtPrecio.Maximum = 1000000; // O el valor que necesites
            txtPrecio.Minimum = 100;
            txtPrecio.Increment = 10;
            txtPrecio.ThousandsSeparator = true;
            txtPrecio.DecimalPlaces = 2;
            // camas
            txtCamas.Minimum = 1; 
            txtCamas.Increment = 1;
            txtCamas.DecimalPlaces = 0;
            // personas
            txtPersonas.Minimum = 1;
            txtPersonas.Increment = 1;
            txtPersonas.DecimalPlaces = 0;

            CargarHoteles();
            //CargarTiposHabitacion();

        }

        private void cmbHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTiposHabitacion();

        }

        private void cmbTiposHab_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* EnlaceDB enlace = new EnlaceDB();
            int idHotel = (int)cmbHoteles.SelectedValue;
            int idTipo = (int)cmbTiposHab.SelectedValue;
            DataTable dt = enlace.ObtenerTiposHabitacionPorHotel(idHotel,idTipo);

            // Llenas los campos con los datos recuperados
           // txtNombre.Text = dt.Rows[0]["NombreTipo"].ToString();
            txtNivel.Text = dt.Rows[0]["Nivel"].ToString();
            txtPrecio.Value = Convert.ToDecimal(dt.Rows[0]["Precio"]);
            txtCamas.Value = Convert.ToDecimal(dt.Rows[0]["Camas"]);
            txtTipoCamas.Text = dt.Rows[0]["Tipo_Camas"].ToString();
            txtPersonas.Value= Convert.ToDecimal(dt.Rows[0]["Cant_Pers"]);
            txtCaracteristicas.Text = dt.Rows[0]["Caracteristicas"].ToString();

            /// aqui debe cargar las amenidades de dicho tipo de habitacion
            DataTable dt2 = new DataTable();
            dt2 = enlace.ObtenerAmenidadesPorTipo(idTipo);
            dgvAmenidades.DataSource= dt2;
            dgvAmenidades.Columns["IdAmenidad"].Visible = false;
           */
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
           /* int idTipo = (int)cmbTiposHab.SelectedValue;
            int cantPers = (int)txtPersonas.Value;
            string caracteristicas = txtCaracteristicas.Text;
            string nivel = txtNivel.Text;
            int camas = (int)txtCamas.Value;
            string tipoCamas = txtTipoCamas.Text;
            decimal precio = txtPrecio.Value;

            EnlaceDB enlace = new EnlaceDB();
            bool ok = enlace.ActualizarTipoHabitacion(idTipo, cantPers, caracteristicas, nivel, camas, tipoCamas, precio);

            if (ok)
                MessageBox.Show("Tipo de habitación actualizado correctamente.");
            else
                MessageBox.Show("No se pudo actualizar el tipo de habitación.");
           */
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtCaracteristicas_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCamas_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtAmenidades_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvAmenidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAmenidades.Rows[e.RowIndex];
                string nombreAmenidad = row.Cells["Nombre"].Value.ToString();
                string idAmenidad = row.Cells["IdAmenidad"].Value.ToString();

                MessageBox.Show($"Esta es la amenidad seleccionada: {nombreAmenidad}\nID: {idAmenidad}");
            }
        }

        private void EliminatBtn_Click(object sender, EventArgs e)
        {
            if (dgvAmenidades.CurrentRow != null)
            {
                int idAmenidad = Convert.ToInt32(dgvAmenidades.CurrentRow.Cells["IdAmenidad"].Value);
                string nombreAmenidad = dgvAmenidades.CurrentRow.Cells["Nombre"].Value.ToString();

                DialogResult result = MessageBox.Show($"¿Seguro que deseas eliminar la amenidad \"{nombreAmenidad}\"?", "Confirmación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    EnlaceDB enlace = new EnlaceDB();
                    bool exito = enlace.DeshabilitarAmenidad(idAmenidad);
                    if (exito)
                    {
                        MessageBox.Show("Amenidad eliminada correctamente.");
                        // Refresca el DataGridView
                        int idTipo = (int)cmbTiposHab.SelectedValue;
                        dgvAmenidades.DataSource = enlace.ObtenerAmenidadesPorTipo(idTipo);
                        dgvAmenidades.Columns["IdAmenidad"].Visible = false;
                    }
                }
            }
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            int idTipo = (int)cmbTiposHab.SelectedValue;
            bool exito = enlace.InsertarAmenidad(idTipo, txtAmenidades.Text);
            if (exito)
            {
                MessageBox.Show("Amenidad Insertada correctamente.");
                dgvAmenidades.DataSource = enlace.ObtenerAmenidadesPorTipo(idTipo);
                dgvAmenidades.Columns["IdAmenidad"].Visible = false;
            }
        }

        private void txtPrecio_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
