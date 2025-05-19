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
using static Siticone.Desktop.UI.Native.WinApi;

namespace PIA_MAD.Forms
{
    public partial class UsCtrlHoteles : UserControl
    {
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
        private void CargarEstados(int idPais)
        {
            EnlaceDB enlace = new EnlaceDB();

            // Previene bucles al recargar
            cmdEstado.SelectedIndexChanged -= cmdEstado_SelectedIndexChanged;

            cmdEstado.DataSource = enlace.ObtenerEstados(idPais); // Devuelve DataTable
            cmdEstado.DisplayMember = "Nombre";
            cmdEstado.ValueMember = "IdEstado";
            cmdEstado.SelectedIndex = -1;

            cmdEstado.SelectedIndexChanged += cmdEstado_SelectedIndexChanged;
        }
        private void CargarCiudades(int idEstado)
        {
            EnlaceDB enlace = new EnlaceDB();

            cmbCiudad.SelectedIndexChanged -= cmbCiudad_SelectedIndexChanged;

            cmbCiudad.DataSource = enlace.ObtenerCiudades(idEstado);
            cmbCiudad.DisplayMember = "Nombre";
            cmbCiudad.ValueMember = "IdCiudad";
            cmbCiudad.SelectedIndex = -1;

            cmbCiudad.SelectedIndexChanged += cmbCiudad_SelectedIndexChanged;
        }

        private void CargarMunicipios(int idCiudad)
        {
            EnlaceDB enlace = new EnlaceDB();

            cmbMunicipio.SelectedIndexChanged -= cmbMunicipio_SelectedIndexChanged;

            cmbMunicipio.DataSource = enlace.ObtenerMunicipios(idCiudad);
            cmbMunicipio.DisplayMember = "Nombre";
            cmbMunicipio.ValueMember = "IdMunicipio";
            cmbMunicipio.SelectedIndex = -1;

            cmbMunicipio.SelectedIndexChanged += cmbMunicipio_SelectedIndexChanged;
        }

        private void CargarColonias(int idMunicipio)
        {
            EnlaceDB enlace = new EnlaceDB();

            cmbColonia.DataSource = enlace.ObtenerColonias(idMunicipio);
            cmbColonia.DisplayMember = "Nombre";
            cmbColonia.ValueMember = "IdColonia";
            cmbColonia.SelectedIndex = -1;
        }
        private void CargarCodigoPostal(int idColonia)
        {
            EnlaceDB enlace = new EnlaceDB();
            string codigoPostal = enlace.ObtenerCodigoPostalPorColonia(idColonia); // Este método lo creas en EnlaceDB

            if (!string.IsNullOrEmpty(codigoPostal))
            {
                siticoneComboBoxColonia.Text = codigoPostal; // Asume que tienes un TextBox llamado txtCodigoPostal
            }
        }

        private void CargarHoteles()
        {
            EnlaceDB enlace = new EnlaceDB();
            cmbHoteles.DisplayMember = "Nombre_Hotel";   // Lo que el usuario verá
            cmbHoteles.ValueMember = "IdHotel";          // El valor interno asociado
            cmbHoteles.DataSource = enlace.ObtenerHoteles();  // Método que devuelve DataTable
            cmbHoteles.SelectedIndex = -1; // opcional, para que no haya selección inicial
        }



        public UsCtrlHoteles()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UsCtrlHoteles_Load(object sender, EventArgs e)
        {
            CargarPaises();
            CargarHoteles();
           
        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMunicipio.SelectedIndex != -1)
            {
                int idMunicipioSeleccionado = (int)cmbMunicipio.SelectedValue;
                CargarColonias(idMunicipioSeleccionado);
            }
        }

        private void cmbpais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPais.SelectedValue != null && int.TryParse(cmbPais.SelectedValue.ToString(), out int idPaisSeleccionado))
            {
                CargarEstados(idPaisSeleccionado);
            }
        }

        private void cmdEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdEstado.SelectedIndex != -1)
            {
                int idEstadoSeleccionado = (int)cmdEstado.SelectedValue;
                CargarCiudades(idEstadoSeleccionado);
            }
        }

        private void cmbCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCiudad.SelectedIndex != -1)
            {
                int idCiudadSeleccionada = (int)cmbCiudad.SelectedValue;
                CargarMunicipios(idCiudadSeleccionada);
            }
        }



        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMunicipio.SelectedIndex != -1)
            {
                int idColonia = Convert.ToInt32(cmbMunicipio.SelectedValue);
                CargarCodigoPostal(idColonia);
            }
        }

        private void siticoneTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            var enlaces = new EnlaceDB();

            int idDir = enlaces.InsertarDireccion(
       (int)cmbPais.SelectedValue,
       (int)cmdEstado.SelectedValue,
       (int)cmbCiudad.SelectedValue,
       cmbMunicipio.SelectedIndex != -1 ? (int?)cmbMunicipio.SelectedValue : null,
       cmbColonia.SelectedIndex != -1 ? (int?)cmbColonia.SelectedValue : null,
       Calle.Text,
       NumExterior.Text,
       NumInterior.Text
   );

            if (idDir <= 0)
            {
                MessageBox.Show("Error al crear la dirección.");
                return;
            }
            // 2) Ahora inserto el hotel usando una instancia de EnlaceDB
            var enlace = new EnlaceDB();  // ← instancia, no static

            bool ok = enlace.InsertarHotel(
                Hotel.Text,        // tu TextBox se llama quizá txtHotelNombre
                idDir,
                ZonaTuris.Text,      // tu TextBox de zona turística
                Convert.ToInt32(Pisos.Text),
                FechaOp.Value.Date
            );

            if (ok)
                MessageBox.Show("Hotel registrado correctamente.");
            else
                MessageBox.Show("Error al registrar el hotel.");
        }

        private void actualizar_Click(object sender, EventArgs e)
        {
            var enlace = new EnlaceDB();

            int idHotel = (int)cmbHoteles.SelectedValue;

            int idDireccion = enlace.InsertarDireccion(
                (int)cmbPais.SelectedValue,
                (int)cmdEstado.SelectedValue,
                (int)cmbCiudad.SelectedValue,
                cmbMunicipio.SelectedIndex != -1 ? (int?)cmbMunicipio.SelectedValue : null,
                cmbColonia.SelectedIndex != -1 ? (int?)cmbColonia.SelectedValue : null,
                Calle.Text,
                NumExterior.Text,
                NumInterior.Text
            );

            bool ok = enlace.ActualizarHotel(
                idHotel,
                Hotel.Text,
                idDireccion,
                ZonaTuris.Text,
                FechaOp.Value.Date, // puedes guardar este ID desde el login
                Convert.ToInt32(Pisos.Text)
            );

            if (ok)
                MessageBox.Show("Hotel actualizado correctamente.");
            else
                MessageBox.Show("No se pudo actualizar el hotel.");

        }

        private void siticoneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHoteles.SelectedIndex != -1 && cmbHoteles.SelectedValue != null)
            {
                if (int.TryParse(cmbHoteles.SelectedValue.ToString(), out int idHotel))
                {
                    EnlaceDB enlace = new EnlaceDB();
                    DataTable dt = enlace.ObtenerHotelPorId(idHotel);

                    if (dt.Rows.Count > 0)
                    {
                         DataRow fila = dt.Rows[0];

                        Hotel.Text = fila["Nombre_Hotel"].ToString();
                        ZonaTuris.Text = fila["Zona_turistica"].ToString();
                        Pisos.Text = fila["Pisos"].ToString();
                        FechaOp.Value = Convert.ToDateTime(fila["Fecha_Ini_Ope"]);

                        // Ahora llena los ComboBox de dirección con los valores
                        cmbPais.SelectedValue = fila["IdPais"];
                        cmdEstado.SelectedValue = fila["IdEstado"];
                        cmbCiudad.SelectedValue = fila["IdCiudad"];

                        if (fila["IdMunicipio"] != DBNull.Value)
                            cmbMunicipio.SelectedValue = fila["IdMunicipio"];

                        if (fila["IdColonia"] != DBNull.Value)
                            cmbColonia.SelectedValue = fila["IdColonia"];

                        Calle.Text = fila["Calle"].ToString();
                        NumExterior.Text = fila["NumeroExterior"].ToString();
                        NumInterior.Text = fila["NumeroInterior"].ToString();
                        // falta lo de agregar numero de pisos
                    }
                }
                else
                {
                    MessageBox.Show("Error al convertir el ID del hotel.");
                }
            }
        }

        private void Pisos_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {

        }

      
        private void Costo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ServicioNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
