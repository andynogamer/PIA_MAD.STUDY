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
    public partial class UsCtrlHistorialCliente : UserControl
    {
        int idClienteSeleccionado = -1;
        public UsCtrlHistorialCliente()
        {
            InitializeComponent();
            CargarClientes();
        }
        private void CargarPaises()
        {
            EnlaceDB enlace = new EnlaceDB();
            
        }
        private void CargarClientes()
        {
            EnlaceDB enlace = new EnlaceDB();
            
            siticoneDataGridView1.DataSource = enlace.ObtenerClientesFormatoRFC();

        }
        private void Busqueda_TextChanged(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
          //  ClientesEncontrados.DataSource = enlace.ObtenerClientes(Busqueda.Text);
        }

        private void ClientesEncontrados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = siticoneDataGridView1.Rows[e.RowIndex];

                string nombreCompleto = $"{fila.Cells["Nombres"].Value} {fila.Cells["Apellido_Paterno"].Value} {fila.Cells["Apellido_Materno"].Value}";
                string rfc = fila.Cells["RFC"].Value.ToString();

                int idCliente = Convert.ToInt32(fila.Cells["Id"].Value);

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
                    if (checkBox1.Checked)
                    {
                        Historial.DataSource = enlace.ObtenerReporteCliente(idCliente, Convert.ToInt32(dateTimePicker1.Text));
                    }
                    else {
                        Historial.DataSource = enlace.ObtenerReporteCliente(idCliente);

                    }
                }
            }
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
