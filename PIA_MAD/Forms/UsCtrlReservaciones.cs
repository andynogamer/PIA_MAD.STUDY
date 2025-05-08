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

namespace PIA_MAD.Forms
{
    public partial class UsCtrlReservaciones : UserControl
    {
        public UsCtrlReservaciones()
        {
            InitializeComponent();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {

        }
        private void CargarClientes()
        {
            EnlaceDB enlace = new EnlaceDB();
            ClientesEncontrados.DataSource = enlace.ObtenerClientes(Busqueda.Text);
            ClientesEncontrados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Asignar nombres personalizados a las columnas que sí mostraremos
            ClientesEncontrados.Columns["IdCliente"].HeaderText = "ID Cliente";
            ClientesEncontrados.Columns["RFC"].HeaderText = "RFC";
            ClientesEncontrados.Columns["Nombres"].HeaderText = "Nombre";
            ClientesEncontrados.Columns["ApPaterno"].HeaderText = "Apellido Paterno";
            ClientesEncontrados.Columns["ApMaterno"].HeaderText = "Apellido Materno";
            ClientesEncontrados.Columns["Correo"].HeaderText = "Correo Electrónico";
            ClientesEncontrados.Columns["TelCel"].HeaderText = "Teléfono Celular";
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
            HotelesCiudad.DataSource = ciudades2;
            HotelesCiudad.DisplayMember = "Nombre_Hotel";
            HotelesCiudad.ValueMember = "IdHotel";
        }

        private void UsCtrlReservaciones_Load(object sender, EventArgs e)
        {
            // Configurar ajuste automático de columnas
            CargarComboCiudades();

        }

        private void siticoneDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
