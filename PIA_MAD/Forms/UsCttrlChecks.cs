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
            decimal totalDescuentos = 0;
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

            // Restar descuentos aplicados
            foreach (DataGridViewRow fila in dgvDescuentos.Rows)
            {
                decimal valorDescuento = Convert.ToDecimal(fila.Cells["Valor"].Value.ToString().Replace("%", "").Replace("$", ""));
                bool esPorcentaje = fila.Cells["Tipo"].Value.ToString() == "Porcentaje";

                if (esPorcentaje)
                    totalDescuentos += (totalHospedaje + totalServicios) * (valorDescuento / 100);
                else
                    totalDescuentos += valorDescuento;
            }

            // Calcular total final restando anticipo
            decimal totalFinal = (totalHospedaje + totalServicios) - totalDescuentos - anticipo;
            txtTotalFinal.Text = totalFinal.ToString("C2"); // Muestra el monto actualizado
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
            DataTable resultados = enlace.ObtenerReservacionesFiltradas(codigoBuscado);

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
            decimal totalDescuentos = 0;

            // Calcular el total de hospedaje desde `DataGridView`
            foreach (DataGridViewRow fila in dgvHabitacionesReservadas.Rows)
            {
                totalHospedaje += Convert.ToDecimal(fila.Cells["TotalHabitacion"].Value);
            }

            // Calcular el total de servicios utilizados
            foreach (DataGridViewRow fila in dgvServiciosUtilizados.Rows)
            {
                totalServicios += Convert.ToDecimal(fila.Cells["Subtotal"].Value);
            }

            // Restar descuentos aplicados
            foreach (DataGridViewRow fila in dgvDescuentos.Rows)
            {
                decimal valorDescuento = Convert.ToDecimal(fila.Cells["Valor"].Value.ToString().Replace("%", "").Replace("$", ""));
                bool esPorcentaje = fila.Cells["Tipo"].Value.ToString() == "Porcentaje";

                if (esPorcentaje)
                    totalDescuentos += (totalHospedaje + totalServicios) * (valorDescuento / 100);
                else
                    totalDescuentos += valorDescuento;
            }

            // Calcular total final (el anticipo se obtiene directamente en SQL)
            decimal totalFinal = (totalHospedaje + totalServicios) - totalDescuentos;

            // Guardar la factura en la base de datos
            EnlaceDB enlace = new EnlaceDB();
            int idFactura = enlace.GuardarFactura(idReservacion, totalHospedaje, totalServicios, totalDescuentos, totalFinal);

            if (idFactura > 0)
            {
                MessageBox.Show($"Factura generada correctamente con ID {idFactura}.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
