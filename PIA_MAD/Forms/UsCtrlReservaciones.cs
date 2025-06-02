using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using static PIA_MAD.Forms.Estructuras;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIA_MAD.Forms
{
    public partial class UsCtrlReservaciones : UserControl
    {
        public UsCtrlReservaciones()
        {
            InitializeComponent();
        }
        int idClienteSeleccionado = -1;
        int idHotelSelec = -1;
        private void DgvHabitaciones_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvHabitaciones.Columns[e.ColumnIndex].Name == "CantidadHuespedes")
            {
                string input = e.FormattedValue?.ToString()?.Trim();

                // Si el campo está vacío, lo permitimos
                if (string.IsNullOrEmpty(input))
                {
                    dgvHabitaciones.Rows[e.RowIndex].ErrorText = "";
                    return; // no cancelamos
                }

                // Validar que sea número
                if (!int.TryParse(input, out int value))
                {
                    dgvHabitaciones.Rows[e.RowIndex].ErrorText = "Solo se permiten números.";
                    e.Cancel = true;
                    return;
                }

                // Validar que sea ≥ 1
                if (value < 1)
                {
                    dgvHabitaciones.Rows[e.RowIndex].ErrorText = "Debe ingresar al menos 1 huésped.";
                    e.Cancel = true;
                    return;
                }

                // Validar contra capacidad
                int capacidad = Convert.ToInt32(dgvHabitaciones.Rows[e.RowIndex].Cells["Cant_Pers"].Value);
                if (value > capacidad)
                {
                    dgvHabitaciones.Rows[e.RowIndex].ErrorText = $"La capacidad máxima es {capacidad}.";
                    e.Cancel = true;
                }
                else
                {
                    dgvHabitaciones.Rows[e.RowIndex].ErrorText = ""; // todo correcto
                }
            }
        }

        private void DgvHabitaciones_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvHabitaciones.CurrentCell.OwningColumn.Name == "CantidadHuespedes")
            {
                /*
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= OnlyNumbers_KeyPress;
                    txt.KeyPress += OnlyNumbers_KeyPress;
                }
                */
            }
        }

        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {

        }
        private void CargarClientes()
        {
            EnlaceDB enlace = new EnlaceDB();
            string filtro = cmbFiltro.Text;
            ClientesEncontrados.DataSource = enlace.ObtenerClientes(Busqueda.Text,filtro);
            ClientesEncontrados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Asignar nombres personalizados a las columnas que sí mostraremos
            ClientesEncontrados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            ClientesEncontrados.ColumnHeadersHeight = 18; // Ajusta si lo ves muy bajo
            

        }
       public void CargarComboCiudades()
        {
            EnlaceDB enlace = new EnlaceDB();
            DataTable ciudades = enlace.ObtenerCiudadesDisponibles();
            CiudadesDisponibles.DataSource = ciudades;
            CiudadesDisponibles.DisplayMember = "Nombre"; // Lo que el usuario verá
            CiudadesDisponibles.ValueMember = "IdCiudad"; // Lo que realmente se usará en el código
        }
       public void CargarHotelesCiudad()
        {
            EnlaceDB enlace = new EnlaceDB();
            int idCiudadSeleccionada = Convert.ToInt32(((DataRowView)CiudadesDisponibles.SelectedItem)["IdCiudad"]);
            DataTable ciudades2 = enlace.ObtenerHotelesPorCiudad(idCiudadSeleccionada);
            dgvHotelesDispo.DataSource = ciudades2;
            dgvHotelesDispo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


        }
        public void mostrarPosibles()
        {
            EnlaceDB enlace = new EnlaceDB();
            dgvHabitaciones.AutoGenerateColumns = true;
            dgvHabitaciones.DataSource = enlace.ObtenerHabitacionesLibres(idHotelSelec, dtpHoy.Value.Date, dtpMañana.Value.Date);
            dgvHabitaciones.Columns["IdTipo"].Visible = false; // Ocultamos el ID en la UI
            dgvHabitaciones.Columns["Nivel"].HeaderText = "Tipo de Habitación";
            dgvHabitaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHabitaciones.Refresh();

            // Mostrar encabezado        
            dgvHabitaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvHabitaciones.ColumnHeadersHeight = 19; // Ajusta si lo ves muy bajo

            // Autoajuste
            dgvHabitaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHabitaciones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Asegura altura mínima de filas
            dgvHabitaciones.RowTemplate.Height = 25;
            dgvHabitaciones.RowHeadersVisible = false;

            // Renombrar encabezados si existen
            if (dgvHabitaciones.Columns.Contains("PrecioxPersonaxNoche"))
                dgvHabitaciones.Columns["PrecioxPersonaxNoche"].HeaderText = "Precio Unitario";
            if (dgvHabitaciones.Columns.Contains("Numero_Habitacion"))
                dgvHabitaciones.Columns["Numero_Habitacion"].HeaderText = "N° Habitación";
            if (dgvHabitaciones.Columns.Contains("Nivel"))
                dgvHabitaciones.Columns["Nivel"].HeaderText = "Tipo de Habitación";
            // (continúa igual para los demás)

            // Agregar columnas personalizadas si no existen
            if (!dgvHabitaciones.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn seleccionar = new DataGridViewCheckBoxColumn
                {
                    Name = "Seleccionar",
                    HeaderText = "Seleccionar",
                    Width = 80
                };
                dgvHabitaciones.Columns.Insert(0, seleccionar);
            }

            if (!dgvHabitaciones.Columns.Contains("CantidadHuespedes"))
            {
                DataGridViewTextBoxColumn cantidad = new DataGridViewTextBoxColumn
                {
                    Name = "CantidadHuespedes",
                    HeaderText = "Cantidad a Hospedar",
                    Width = 120,
                    ValueType = typeof(int),
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                dgvHabitaciones.Columns.Add(cantidad);
            }
            dgvHabitaciones.EditingControlShowing += DgvHabitaciones_EditingControlShowing;
            dgvHabitaciones.CellValidating += DgvHabitaciones_CellValidating;

        }

        private void UsCtrlReservaciones_Load(object sender, EventArgs e)
        {
            // Configurar ajuste automático de columnas
         CargarComboCiudades();
            
            // Configurar dtpHoy para que solo permita seleccionar fechas a partir de hoy
            dtpHoy.MinDate = DateTime.Today;

            // Configurar dtpMañana para que solo permita fechas al menos un día después de dtpHoy
            dtpMañana.MinDate = dtpHoy.Value.AddDays(1);

            numericUpDownAnticipo.DecimalPlaces = 2;  // Permite dos decimales
            numericUpDownAnticipo.Minimum = 0;        // Establece un mínimo de 0 (puedes cambiarlo si lo necesitas)
            numericUpDownAnticipo.Maximum = 10000;    // Límite superior, ajusta según tu necesidad
            numericUpDownAnticipo.Increment = 0.01M;  // Asegura incrementos de 0.01 para precisión decimal
            numericUpDownAnticipo.ThousandsSeparator = true; // Separa miles si es necesario
            if (cmbFiltro.Items.Count > 0)
            {
                cmbFiltro.SelectedIndex = 0;
            }


        }

        private void siticoneDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = ClientesEncontrados.Rows[e.RowIndex];

                string nombreCompleto = $"{fila.Cells["Nombres"].Value} {fila.Cells["ApPaterno"].Value} {fila.Cells["ApMaterno"].Value}";
                string rfc = fila.Cells["RFC"].Value.ToString();

                DialogResult result = MessageBox.Show($"¿Desea seleccionar a:\n\n{nombreCompleto}\nRFC: {rfc}?",
                                                      "Confirmar cliente",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                   idClienteSeleccionado = Convert.ToInt32(fila.Cells["IdCliente"].Value);
                   string lblClienteSeleccionado = $"Cliente seleccionado: {nombreCompleto}";
                }
            }
        }

        private void siticoneContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Busqueda_TextChanged(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void siticoneComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHotelesCiudad();

        }

        private void siticoneComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void siticoneDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void siticoneDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dtpMañana.MinDate = dtpHoy.Value.AddDays(1);
            mostrarPosibles();
        }

        private void siticoneDateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            mostrarPosibles();
          
        }

        private void Reservarbtn_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un cliente
            if (idClienteSeleccionado == -1)
            {
                MessageBox.Show("Primero debe seleccionar un cliente.", "Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lista de habitaciones seleccionadas
            List<HabitacionSeleccionada> habitacionesSeleccionadas = new List<HabitacionSeleccionada>();

            // Recorrer el DataGridView para verificar habitaciones seleccionadas
            foreach (DataGridViewRow fila in dgvHabitaciones.Rows)
            {
                DataGridViewCheckBoxCell checkCell = fila.Cells["Seleccionar"] as DataGridViewCheckBoxCell; // Acceder al CheckBox
                // todo esto ya no se va a ocupar
                if (checkCell != null && checkCell.Value != null && Convert.ToBoolean(checkCell.Value) == true) // Validar selección
                {
                    if (fila.Cells["CantidadHuespedes"].Value != null &&
                        int.TryParse(fila.Cells["CantidadHuespedes"].Value.ToString(), out int cantHuespedes) &&
                        cantHuespedes > 0)
                    {
                        habitacionesSeleccionadas.Add(new HabitacionSeleccionada
                        {
                            IdHotel = Convert.ToInt32(fila.Cells["IdHotel"].Value),
                            NumeroHabitacion = Convert.ToInt32(fila.Cells["Numero_Habitacion"].Value),
                            IdTipo = Convert.ToInt32(fila.Cells["IdTipo"].Value),
                            CantHuespedes = cantHuespedes,
                            PrecioUnitario = Convert.ToDecimal(fila.Cells["PrecioxPersonaxNoche"].Value)
                        });
                    }
                }
            }

            // Validar que al menos una habitación fue seleccionada
            if (habitacionesSeleccionadas.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una habitación con cantidad válida.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener datos de la reservación
            DateTime fechaIni = dtpHoy.Value.Date;
            DateTime fechaFin = dtpMañana.Value.Date;
            decimal pagoRes = numericUpDownAnticipo.Value;

            // Ejecutar la reserva
            EnlaceDB enlace = new EnlaceDB();
            string idReservacion = enlace.RegistrarReservacion(idClienteSeleccionado, fechaIni, fechaFin, pagoRes, habitacionesSeleccionadas);
            if (!string.IsNullOrEmpty(idReservacion))
            {
                // Mostrar el MessageBox con la opción de copiar el código
                DialogResult resultado = MessageBox.Show($"¡Reservación registrada correctamente!\nCódigo de reservación: {idReservacion}\n\n¿Desea copiar el código?",
                    "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                // Si el usuario elige "Sí", copiamos el GUID al portapapeles
                if (resultado == DialogResult.Yes)
                {
                    Clipboard.SetText(idReservacion);
                    MessageBox.Show("Código de reservación copiado al portapapeles.", "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Limpiar DataGridView después de la reserva
                dgvHabitaciones.DataSource = null;
                dgvHabitaciones.Columns.Remove("Seleccionar");
                dgvHabitaciones.Columns.Remove("CantidadHuespedes");
            }
            else
            {
                MessageBox.Show("Error al registrar la reservación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void siticoneNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {

        }

        private void dgvHotelesDispo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvHotelesDispo.Rows[e.RowIndex];
                string nombreCompleto = $"{fila.Cells["Nombre_Hotel"].Value}";
                DialogResult result = MessageBox.Show($"¿Desea seleccionar a:\n\n{nombreCompleto}\n?",
                                                    "Confirmar Hotel",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    idHotelSelec = Convert.ToInt32(fila.Cells["IdHotel"].Value);
                    nombreCompleto = $"Hotel seleccionado:: {nombreCompleto}";
                }
               
            }
            mostrarPosibles();
        }
    }
}
