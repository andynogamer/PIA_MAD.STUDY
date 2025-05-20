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
    public partial class UsCtrlCancelaciones : UserControl
    {
        private Guid reservacionSeleccionada;
        public UsCtrlCancelaciones()
        {
            InitializeComponent();
        }

        private void siticoneHtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigoReservacionIN_TextChanged(object sender, EventArgs e)
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
            DataTable resultados = enlace.ObtenerReservacionesFiltradas2(codigoBuscado);

            // Mostrar los resultados en el DataGridView
            dgvReservaciones.DataSource = resultados;
        }

        private void CheckIn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(reservacionSeleccionada.ToString()))
            {
                MessageBox.Show("Por favor selecciona una reservación primero.");
                return;
            }

            if (dgvReservaciones.CurrentRow == null)
            {
                MessageBox.Show("No hay una fila seleccionada.");
                return;
            }

            DataGridViewRow fila = dgvReservaciones.CurrentRow;

            if (fila.Cells["Fecha_Ini"].Value == null)
            {
                MessageBox.Show("La fecha de inicio no está disponible.");
                return;
            }

            DateTime fechaInicio = Convert.ToDateTime(fila.Cells["Fecha_Ini"].Value).Date;
            DateTime hoy = DateTime.Today;

            int diasDiferencia = (fechaInicio - hoy).Days;

            string nuevoEstado = diasDiferencia >= 3 ? "Cancelada" : "CanceladaF";

            EnlaceDB enlace = new EnlaceDB();
            bool actualizado = enlace.ActualizarEstadoReservacion(reservacionSeleccionada.ToString(), nuevoEstado);

            if (actualizado)
            {
                MessageBox.Show($"Reservación actualizada a estado: {nuevoEstado}", "Estado actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aquí puedes recargar el DataGridView si lo deseas
            }
            else
            {
                MessageBox.Show("Error al actualizar la reservación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvReservacionesIN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvReservaciones.Rows.Count)
            {
                DataGridViewRow fila = dgvReservaciones.Rows[e.RowIndex];

                if (fila.Cells["IdReservacion"].Value != null)
                {
                    string idReservacion = fila.Cells["IdReservacion"].Value.ToString();

                    MessageBox.Show($"Estás seleccionando esta reservación:\n{idReservacion}", "Reservación seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Si reservacionSeleccionada es tipo Guid
                    reservacionSeleccionada = Guid.Parse(idReservacion);
                }
            }
        }
    }
}
