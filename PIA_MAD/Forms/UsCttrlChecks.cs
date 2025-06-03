using Siticone.Desktop.UI.WinForms;
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
    public partial class UsCttrlChecks : UserControl
    {
        private Guid reservacionSeleccionada;

        private void CleanComponents()
        {
            txtCodigoReservacion.Clear();
            dgvReservaciones.Rows.Clear();
            


        }

        public UsCttrlChecks()
        {
            InitializeComponent();
        }
        private void ConfigurarFechaHoy()
        {
            dtpFechaHoy.Value = DateTime.Today;
            dtpFechaHoy.Enabled = false; // Para evitar modificaciones
        }
        private void CargarServiciosReservados()
        {
            if (dgvReservaciones.SelectedRows.Count == 0) return;

            Guid idReservacion = Guid.Parse(dgvReservaciones.SelectedRows[0].Cells["IdReservacion"].Value.ToString());

            EnlaceDB enlace = new EnlaceDB();
            dgvServiciosUtilizados.DataSource = enlace.ObtenerServiciosReservados(idReservacion);
        }
        private void CargarHabitacionesReservadas()
        {
            if (dgvReservaciones.SelectedRows.Count == 0) return;

            Guid idReservacion = Guid.Parse(dgvReservaciones.SelectedRows[0].Cells["IdReservacion"].Value.ToString());

            EnlaceDB enlace = new EnlaceDB();
            dgvHabitacionesReservadas.DataSource = enlace.ObtenerHabitacionesReservadas(idReservacion);
        }
        private void RecalcularTotalFactura()
        {
            decimal totalHospedaje = 0;
            decimal totalServicios = 0;
           
            decimal anticipo = Convert.ToDecimal(dgvReservaciones.SelectedRows[0].Cells["Pago_Res"].Value); // Tomado de la BD

            // Sumar costos de hospedaje
            foreach (DataGridViewRow fila in dgvHabitacionesReservadas.Rows)
            {
                totalHospedaje += Convert.ToDecimal(fila.Cells["TotalHabitacion"].Value);
            }

            // Sumar servicios utilizados
            foreach (DataGridViewRow fila in dgvServiciosUtilizados.Rows)
            {
                totalServicios += Convert.ToDecimal(fila.Cells["Subtotal"].Value);
            }

            

            // Calcular total final restando anticipo
            decimal totalFinal = (totalHospedaje + totalServicios) - anticipo;
            
        }


        private void dgvHabitacionesReservadas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            RecalcularTotalFactura();
        }

        private void dgvServiciosUtilizados_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            RecalcularTotalFactura();
        }

        private void dgvDescuentos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            RecalcularTotalFactura();
        }

        private void dgvDescuentos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RecalcularTotalFactura();
        }

        private void siticoneHtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (dgvReservaciones.RowCount == 0)
            {
                MessageBox.Show("No ha seleccionado algun dato...");
                return;
            }
            DateTime fechaSalida = Convert.ToDateTime(dgvReservaciones.SelectedRows[0].Cells["Fecha_Fin"].Value);

            if (fechaSalida > DateTime.Today)
            {
                MessageBox.Show("La fecha de salida no puede ser posterior a hoy. Se ajustará automáticamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fechaSalida = DateTime.Today;
            }
        }

        private void siticoneTextBox2_TextChanged(object sender, EventArgs e)
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

        private void siticoneDataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string reservacionSeleccionada = dgvReservaciones.Rows[e.RowIndex].Cells["IdReservacion"].Value.ToString();
                DateTime fechaSalida = Convert.ToDateTime(dgvReservaciones.Rows[e.RowIndex].Cells["Fecha_Fin"].Value);

                MessageBox.Show($"Reservación: {reservacionSeleccionada} seleccionada\nFecha de salida: {fechaSalida.ToShortDateString()}", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Guardar el código de reservación
                txtCodigoReservacion.Text = reservacionSeleccionada;

                // Llamar a la función para cargar habitaciones
                CargarHabitacionesReservadas();

                CargarServiciosReservados();
                // Habilitar el botón para continuar con costos
                btnContinuarCostos.Enabled = true;
            }

        }

        private void UsCttrlChecks_Load(object sender, EventArgs e)
        {
            ConfigurarFechaHoy();
        }

        private void siticoneHtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void GenerarFactura_Click(object sender, EventArgs e)
        {
             if (dgvReservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reservación antes de generar la factura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID de la reservación seleccionada
            Guid idReservacion = Guid.Parse(dgvReservaciones.SelectedRows[0].Cells["IdReservacion"].Value.ToString());

            decimal totalHospedaje = 0;
            decimal totalServicios = 0;
            

            // Calcular el total de hospedaje desde `DataGridView`
            foreach (DataGridViewRow fila in dgvHabitacionesReservadas.Rows)
            {
                totalHospedaje += Convert.ToDecimal(fila.Cells["TotalHabitacion"].Value);
            }
            EnlaceDB enlace = new EnlaceDB();
            // Calcular el total de servicios utilizados
            foreach (DataGridViewRow fila in dgvServiciosUtilizados.Rows)
            {
                if ((fila.Cells["Cantidad"].Value) != DBNull.Value)
                {
                    
                    totalServicios += (Convert.ToDecimal(fila.Cells["Costo"].Value) * Convert.ToDecimal(fila.Cells["Cantidad"].Value));

                    bool isNotEmpty = enlace.AgregarServicioAReservacion(idReservacion, Convert.ToInt32(fila.Cells["IdServicio"].Value), Convert.ToInt32(fila.Cells["Cantidad"].Value));
                }
                
            }

            
            decimal totalFinal = (totalHospedaje + totalServicios);

            // Guardar la factura en la base de datos
           
            int idFactura = enlace.GuardarFactura(idReservacion, totalHospedaje, totalServicios, totalFinal);

            if (idFactura > 0)
            {

                MessageBox.Show($"Factura generada correctamente con ID {idFactura}.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cambiar estado de la reservación a "Efectuada"
                bool actualizado = enlace.ActualizarEstadoReservacion(idReservacion.ToString(), "Efectuada");

                if (actualizado)
                {
                    MessageBox.Show("Estado de la reservación actualizado a 'Efectuada'.", "Estado actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    enlace.GenerarFacturaArchivo(idReservacion);

                    CleanComponents();

                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado de la reservación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void siticoneDataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvReservaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string reservacionSeleccionada = dgvReservaciones.Rows[e.RowIndex].Cells["IdReservacion"].Value.ToString();
                DateTime fechaSalida = Convert.ToDateTime(dgvReservaciones.Rows[e.RowIndex].Cells["Fecha_Fin"].Value);

                MessageBox.Show($"Reservación: {reservacionSeleccionada} seleccionada\nFecha de salida: {fechaSalida.ToShortDateString()}", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Guardar el código de reservación
                txtCodigoReservacion.Text = reservacionSeleccionada;

                // Llamar a la función para cargar habitaciones y servicios
                CargarHabitacionesReservadas();
                CargarServiciosReservados();

                // Recalcular costos ahora que los datos están disponibles
                RecalcularTotalFactura();

                // Habilitar el botón para continuar con costos
                btnContinuarCostos.Enabled = true;
            }
        }

        private void dgvHabitacionesReservadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void siticoneDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvReservacionesIN.Rows.Count)
            {
                DataGridViewRow fila = dgvReservacionesIN.Rows[e.RowIndex];

                if (fila.Cells["IdReservacion"].Value != null)
                {
                    string idReservacion = fila.Cells["IdReservacion"].Value.ToString();

                    MessageBox.Show($"Estás seleccionando esta reservación:\n{idReservacion}", "Reservación seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Si reservacionSeleccionada es tipo Guid
                    reservacionSeleccionada = Guid.Parse(idReservacion);
                }
            }
        }


        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {
            string codigoBuscado = txtCodigoReservacionIN.Text.Trim();

            // Si el usuario borra el texto, limpiamos el DataGridView esto hay que hacerlo con el filtro de busqued de cliente en reservaciones
            if (string.IsNullOrEmpty(codigoBuscado))
            {
                dgvReservaciones.DataSource = null;
                return;
            }

            // Instancia de EnlaceDB para buscar las reservaciones
            EnlaceDB enlace = new EnlaceDB();
            DataTable resultados = enlace.ObtenerReservacionesFiltradas2(codigoBuscado); 
            /// hay que cambiar a que si no tiene la fecha de hoy no se puede filtrar

            // Mostrar los resultados en el DataGridView
            dgvReservacionesIN.DataSource = resultados;
        }

        private void CheckIn_Click(object sender, EventArgs e)
        {
            // Verificamos si hay una reservación seleccionada
            if (reservacionSeleccionada == Guid.Empty)
            {
                MessageBox.Show("Por favor selecciona una reservación primero.");
                return;
            }

            
            DataGridViewRow fila = dgvReservacionesIN.CurrentRow;

            DateTime fechaInicio = Convert.ToDateTime(fila.Cells["Fecha_Ini"].Value);
            DateTime fechaHoy = DateTime.Today;

            if (fechaHoy < fechaInicio.Date)
            {
                MessageBox.Show("Aún no es la fecha de llegada.");
                return;
            }

            string nuevoEstado;

            // Comparamos las fechas
            if (fechaHoy == fechaInicio.Date)
            {
                nuevoEstado = "Estadia"; // Check-in válido
            }
            else
            {
                nuevoEstado = "CanceladaF"; // Llegó tarde, se marca como cancelada fuera de tiempo
            }
            EnlaceDB enlace = new EnlaceDB();
            bool actualizado = enlace.ActualizarEstadoReservacion(reservacionSeleccionada.ToString(), nuevoEstado);

            // Mostramos el resultado
            if (actualizado)
            {
                MessageBox.Show($"Reservación actualizada a estado: {nuevoEstado}");
            }
            else
            {
                MessageBox.Show("Error al actualizar la reservación.");
            }

        }

        private void siticoneHtmlLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
