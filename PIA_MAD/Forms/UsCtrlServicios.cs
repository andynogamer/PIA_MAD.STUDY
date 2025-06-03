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
    public partial class UsCtrlServicios : UserControl
    {
        public UsCtrlServicios()
        {
            InitializeComponent();
        }
        string reservacionSeleccionada = "";
        int idServicio = 0;
        private void CargarHoteles()
        {
            EnlaceDB enlace = new EnlaceDB();
            
        }

        private void UsCtrlServicios_Load(object sender, EventArgs e)
        {
            CargarHoteles();
            
            Cantidad.Minimum = 1;
            Cantidad.Increment = 1;
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
           
            
        }

        private void Cantidad_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void ServiciosHotel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {

            string codigoBuscado = txtCodigoReservacion.Text.Trim();

            // Si el usuario borra el texto, limpiamos el DataGridView
            if (string.IsNullOrEmpty(codigoBuscado))
            {
                dgvReservaciones.DataSource = null;
                return;
            }

            // Instancia de EnlaceDB para buscar las reservaciones
            EnlaceDB enlace = new EnlaceDB();
            DataTable resultados = enlace.ObtenerReservacionesFiltradasE(codigoBuscado);

            // Mostrar los resultados en el DataGridView
            dgvReservaciones.DataSource = resultados;
        }

        private void dgvReservaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
               reservacionSeleccionada = dgvReservaciones.Rows[e.RowIndex].Cells["IdReservacion"].Value.ToString();
               

                MessageBox.Show($"Reservación: {reservacionSeleccionada} seleccionada ", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Guardar el código de reservación
                txtCodigoReservacion.Text = reservacionSeleccionada;
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            Guid idReservacion = Guid.Parse(reservacionSeleccionada);

            bool ok = enlace.InsertarServicioReservacion(idReservacion, idServicio, (int)Cantidad.Value);
            if (ok)
                MessageBox.Show("Servicio agregado correctamente.");
            else
                MessageBox.Show("No se pudo agregar servicio");
        }
    }
}
