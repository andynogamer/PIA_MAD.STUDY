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
    public partial class UsCtrlClientes : UserControl
    {
        private void CargarPaises()
        {
            EnlaceDB enlace = new EnlaceDB();
            cmbPais.SelectedIndexChanged -= cmbPais_SelectedIndexChanged;
            cmbPais.DataSource = enlace.ObtenerPaises(); // método que retorna DataTable
            cmbPais.DisplayMember = "Nombre";
            cmbPais.ValueMember = "IdPais";
            cmbPais.SelectedIndex = -1;

            cmbPais.SelectedIndexChanged += cmbPais_SelectedIndexChanged;
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

        private void CargarClientes()
        {
            EnlaceDB enlace = new EnlaceDB();
            dgvClientes.DataSource = enlace.ObtenerClientes();
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        int cliente = -1;

     
     
        public UsCtrlClientes()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
         
        }

        private void siticoneDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void UsCtrlClientes_Load(object sender, EventArgs e)
        {
            Dictionary<char, string> estadoCivil = new Dictionary<char, string>()
            {
             { 'C', "Casado" },
             { 'S', "Soltero" }
            };

            cmbEstadoCivil.DataSource = new BindingSource(estadoCivil, null);
            cmbEstadoCivil.DisplayMember = "Value"; // Lo que ve el usuario
            cmbEstadoCivil.ValueMember = "Key";     // Lo que se usará internamente
            CargarPaises();
            dtpFechaNac.MinDate = new DateTime(1900, 1, 1);                  // No permitir fechas antes de 1900
            dtpFechaNac.MaxDate = DateTime.Today.AddYears(-18);             // Solo mayores de 18 años
            dtpFechaNac.Value = DateTime.Today.AddYears(-18);
            CargarClientes();
        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
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
            
        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtApPaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApMaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private bool IsNotFilled()
        {
            return (txtNombres.Text == "" || txtApPaterno.Text == "" || txtRFC.Text == "" || txtTelCel.Text == "" || txtTelCasa.Text == "" || txtCorreo.Text == "" || cmbEstadoCivil.SelectedIndex == -1
                || cmbPais.SelectedIndex == -1 || cmdEstado.SelectedIndex == -1 || cmbCiudad.SelectedIndex == -1 || Calle.Text == "");
        }


        private void btnGuardarCli_Click(object sender, EventArgs e)
        {
            if (IsNotFilled())
            {
                MessageBox.Show("Tiene que rellenar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (cliente > 0)
            {
                cliente = -1;
                MessageBox.Show("Intentelo de neuvo, tenia seleccionado un cliente.");
                return;
            }
            /// validar que no este vacio para aplicar un return...
             var enlaces = new EnlaceDB();
            int idDir = enlaces.InsertarDireccion((int)cmbPais.SelectedValue,(int)cmdEstado.SelectedValue,(int)cmbCiudad.SelectedValue, Calle.Text);

            if (idDir <= 0)
            {
                MessageBox.Show("Error al crear la dirección.");
                return;
            }
            // 2) Ahora inserto el hotel usando una instancia de EnlaceDB
            char estadoCivilSeleccionado = ((KeyValuePair<char, string>)cmbEstadoCivil.SelectedItem).Key;

          bool ok = enlaces.InsertarCliente(txtRFC.Text,txtNombres.Text,txtApPaterno.Text,txtApMaterno.Text,idDir,txtTelCasa.Text,txtTelCel.Text,txtCorreo.Text, estadoCivilSeleccionado,dtpFechaNac.Value.Date);
            if (ok)
            {
                MessageBox.Show("cliente registrado correctamente.");
                txtNombres.Text = "";
                txtRFC.Text = "";
                txtApPaterno.Text = "";
                txtApMaterno.Text = "";
                txtCorreo.Text = "";
                dtpFechaNac.MaxDate = DateTime.Today.AddYears(-18);
                txtTelCasa.Text = "";
                txtTelCel.Text = "";
                cmbEstadoCivil.Text = "";
            }
            else
            {
                MessageBox.Show("Error al registrar cliente");
            }
            CargarClientes();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (IsNotFilled())
            {
                MessageBox.Show("Tiene que rellenar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cliente > 0)
            {
                var enlaces = new EnlaceDB();
                int idDir = enlaces.InsertarDireccion((int)cmbPais.SelectedValue, (int)cmdEstado.SelectedValue, (int)cmbCiudad.SelectedValue, Calle.Text);

                if (idDir <= 0)
                {
                    MessageBox.Show("Error al crear la dirección.");
                    return;
                }
                // 2) Ahora inserto el hotel usando una instancia de EnlaceDB
                char estadoCivilSeleccionado = ((KeyValuePair<char, string>)cmbEstadoCivil.SelectedItem).Key;

                bool ok = enlaces.ActualizarCliente(cliente, txtRFC.Text, txtNombres.Text, txtApPaterno.Text, txtApMaterno.Text, idDir, txtTelCasa.Text, txtTelCel.Text, txtCorreo.Text, estadoCivilSeleccionado, dtpFechaNac.Value.Date);
                if (ok)
                    MessageBox.Show("Cliente actualizado correctamente.");
                else
                    MessageBox.Show("Error al actualizar el cliente.");

                CargarClientes();
                cliente = -1;
                txtNombres.Text = "";
                txtRFC.Text = "";
                txtApPaterno.Text = "";
                txtApMaterno.Text = "";
                txtCorreo.Text = "";
                // limpiar fecha...
                txtTelCasa.Text ="";
                txtTelCel.Text = "";
                cmbEstadoCivil.Text ="";
            }
            else
            {
                return;
            }

                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];
                // para mostrar al seleccionado
                string nombreCompleto = $"{fila.Cells["Nombre_Completo"].Value}";
                DialogResult result = MessageBox.Show($"¿Desea seleccionar a:\n\n{nombreCompleto}\n?",
                                                    "Confirmar cliente",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    cliente = Convert.ToInt32(fila.Cells["IdCliente"].Value);
                    nombreCompleto = $"Usuario seleccionado: {nombreCompleto}";
                }
                EnlaceDB enlace = new EnlaceDB();
                //
                DataTable dt = enlace.ObtenerClientesID(cliente);
                if (dt.Rows.Count > 0)
                {
                    DataRow fila2 = dt.Rows[0];
                    txtNombres.Text = fila2["Nombres"].ToString();
                    txtRFC.Text = fila2["RFC"].ToString();
                    txtApPaterno.Text = fila2["ApPaterno"].ToString();
                    txtApMaterno.Text = fila2["ApMaterno"].ToString();
                    txtCorreo.Text = fila2["Correo"].ToString();
                    dtpFechaNac.Value = Convert.ToDateTime(fila2["Fecha_Nac"]);
                    txtTelCasa.Text = fila2["TelCasa"].ToString();
                    txtTelCel.Text = fila2["Telcel"].ToString();
                    cmbEstadoCivil.Text = fila2["Estado_Civil"].ToString();
                    cmbPais.SelectedValue = fila2["IdPais"];
                    cmdEstado.SelectedValue = fila2["IdEstado"];
                    cmbCiudad.SelectedValue = fila2["IdCiudad"];
                    Calle.Text = fila2["Domicilio"].ToString();
                }

            }
        }
    }
}
