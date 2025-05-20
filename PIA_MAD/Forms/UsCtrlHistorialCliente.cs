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
    public partial class UsCtrlHistorialCliente : UserControl
    {
        int idClienteSeleccionado = -1;
        public UsCtrlHistorialCliente()
        {
            InitializeComponent();
        }
        private void CargarPaises()
        {
            EnlaceDB enlace = new EnlaceDB();
            cmbPais.SelectedIndexChanged -= cmbpais_SelectedIndexChanged;
            cmbPais.DataSource = enlace.ObtenerPaises(); // método que retorna DataTable
            cmbPais.DisplayMember = "Nombre";
            cmbPais.ValueMember = "IdPais";
            cmbPais.SelectedIndex = -1;

            cmbPais.SelectedIndexChanged += cmbpais_SelectedIndexChanged;
        }
        private void CargarClientes()
        {
            EnlaceDB enlace = new EnlaceDB();
            ClientesEncontrados.DataSource = enlace.ObtenerClientes(Busqueda.Text);
            ClientesEncontrados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Asignar nombres personalizados a las columnas que sí mostraremos
            ClientesEncontrados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            ClientesEncontrados.ColumnHeadersHeight = 18; // Ajusta si lo ves muy bajo
            ClientesEncontrados.Columns["IdCliente"].HeaderText = "ID Cliente";
            ClientesEncontrados.Columns["RFC"].HeaderText = "RFC";
            ClientesEncontrados.Columns["Nombres"].HeaderText = "Nombre";
            ClientesEncontrados.Columns["ApPaterno"].HeaderText = "Apellido Paterno";
            ClientesEncontrados.Columns["ApMaterno"].HeaderText = "Apellido Materno";
            ClientesEncontrados.Columns["Correo"].HeaderText = "Correo Electrónico";
            ClientesEncontrados.Columns["TelCel"].HeaderText = "Teléfono Celular";

        }
        private void Busqueda_TextChanged(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            ClientesEncontrados.DataSource = enlace.ObtenerClientes(Busqueda.Text);
        }

        private void ClientesEncontrados_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    //idClienteSeleccionado = Convert.ToInt32(fila.Cells["IdCliente"].Value);
                    //string lblClienteSeleccionado = $"Clien{nombreCompleto}";

                    // aqui debo mandar a llamar todo
                    EnlaceDB enlace = new EnlaceDB();
                    Historial.DataSource = enlace.ObtenerReporteCliente(rfc,Convert.ToInt32(dateTimePicker1.Text));
                }
            }
        }

        private void siticoneDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void UsCtrlHistorialCliente_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            CargarPaises();

        }

        private void cmbpais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
