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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        private void CargarHoteles()
        {
            EnlaceDB enlace = new EnlaceDB();

            dgvHoteles.DataSource = enlace.ObtenerHoteles();  // Método que devuelve DataTable
            dgvHoteles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHoteles.ScrollBars = ScrollBars.Both;
            
        }
        private void limpiarcampos()
        {
            ndPisos.Value = 0;
            Hotel.Text = string.Empty;
            FechaOp.Text = DateTime.Today.ToString();
            Calle.Text = string.Empty;
        }
        private void CargarTipoHabi()
        {
            EnlaceDB enlace = new EnlaceDB();
            dgvTipoHabi.DataSource = enlace.BuscarTipoHabiIDHotel(idSeleccion);  // Método que devuelve DataTable
            dgvTipoHabi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTipoHabi.ScrollBars = ScrollBars.Both;
        }
        private void CargarCaractTipo()
        {
            EnlaceDB enlace = new EnlaceDB();
            dgvCaracteristicas.DataSource = enlace.verCaractHabi(IdtipoHab);
            dgvCaracteristicas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCaracteristicas.ScrollBars = ScrollBars.Both;
            dgvCaracteristicas.Columns["IdCaracteristica"].Visible = false;
        }
        private void CargarAmenidad()
        {
            EnlaceDB enlace = new EnlaceDB();
            dgvAmendiades.DataSource = enlace.verAmendiades(IdtipoHab);
            dgvAmendiades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAmendiades.ScrollBars = ScrollBars.Both;
            dgvAmendiades.Columns["IdAmenidad"].Visible = false;
        }
        private void CargarHabi()
        {
            EnlaceDB enlace = new EnlaceDB();
            dgvHabi.DataSource = enlace.BuscarHabitaciones(IdtipoHab);
            dgvHabi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHabi.ScrollBars = ScrollBars.Both;
        }


        //variables globales
        int idSeleccion = -1; // este es el hotel
        int IdServicioSele = -1;
        int IdCaract=-1;
        int IdtipoHab = -1;
        int IdCaracTH = 0;
        int IdAmenidad = 0;
        public UsCtrlHoteles()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UsCtrlHoteles_Load(object sender, EventArgs e)
        {

            dgvHoteles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoteles.MultiSelect = false;
            ndPisos.DecimalPlaces = 0; // No decimales
            ndPisos.Minimum = 0;       // Valor mínimo
            ndPisos.Increment = 1;
            CargarPaises();
            CargarHoteles();
            dgvHoteles.ClearSelection();
            dgvHoteles.CurrentCell = null;
            nupPrec.Minimum = 0;
            nupPrec.DecimalPlaces = 2;
            nupPrec.ThousandsSeparator = true;

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
            
        }
        private void VerificandoAndo()
        {
            bool haySeleccion;
            if (idSeleccion > 0)
            {
                haySeleccion = true;
            }
            else
            {
                haySeleccion = false;
            }
            // Activa o desactiva los controles según la selección
            // cuando estos se activen hay que ver todo lo que es de ese hotel, caracteristicas etc...
            // servicios
            txtServicio.Enabled = haySeleccion;
            btnAgregarServicio.Enabled = haySeleccion;
            BtnEliminarServicio.Enabled = (haySeleccion);
            nupPrec.Enabled = (haySeleccion);
            // caracteristicas...

            txtCaracteristica.Enabled = haySeleccion;
            btnAgregarCarac.Enabled = (haySeleccion);
            btnEliminar.Enabled = (haySeleccion);
            // tipo habitaciones
            txtNivel.Enabled = haySeleccion;
            txtPersonas.Enabled = haySeleccion;
            cmbTcamas.Enabled = (haySeleccion);
            nupCantCamas.Enabled = (haySeleccion);
            txtPrecio.Enabled = (haySeleccion);
            btnTipo.Enabled = haySeleccion;
            txtCaractHabi.Enabled = (haySeleccion);
            btnGuardarHabi.Enabled = (haySeleccion);
        }

        private void CargaServicios(int hotel)
        {
            int x = hotel;
            EnlaceDB enlace = new EnlaceDB();
            dgvServicios.DataSource = enlace.ObtenerServicios(hotel);  // Método que devuelve DataTable
            dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvServicios.ScrollBars = ScrollBars.Both;
            dgvServicios.Columns["IdServicio"].Visible = false;
        }
        private void cargarCaracter( int hotel)
        {
            int x = hotel;
            EnlaceDB enlace = new EnlaceDB();
            dgvCaract.DataSource = enlace.ObtenerCaracteristicas(x); // Método que devuelve DataTable
            dgvCaract.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCaract.ScrollBars = ScrollBars.Both;
            dgvCaract.Columns["IdCaracteristica"].Visible = false;
        }

        private void Pisos_TextChanged(object sender, EventArgs e)
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

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            Form2 frmDirecciones = new Form2();
            frmDirecciones.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (ndPisos.Value == 0)
            {
                MessageBox.Show("Por favor, Ingresa el numero de pisos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(Hotel.Text) || string.IsNullOrWhiteSpace(Calle.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos de texto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPais.SelectedIndex == -1 || cmdEstado.SelectedIndex == -1 || cmbCiudad.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona un país, estado y ciudad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (idSeleccion == -1)
            { // en este caso estamos  insertando por que no esta seleccionando
                // podemos poner un message box, para limpiar id seleccionado o... mantenerlo... 
                // de esta forma podemos insertar... o actualizar...
                EnlaceDB enlace = new EnlaceDB();
                int idDir = enlace.InsertarDireccion((int)cmbPais.SelectedValue, (int)cmdEstado.SelectedValue, (int)cmbCiudad.SelectedValue, Calle.Text);
                if (idDir <= 0)
                {
                    MessageBox.Show("Error al crear la dirección.");
                    return;
                }
                bool ok = enlace.InsertarHotel(Hotel.Text, idDir, (int)ndPisos.Value, FechaOp.Value.Date);

                if (ok)
                {
                    MessageBox.Show("Hotel registrado correctamente.");
                    limpiarcampos();
                    CargarHoteles();
                    idSeleccion = -1;
                    VerificandoAndo();
                }
                else
                    MessageBox.Show("Error al registrar el hotel.");
            }
            else
            {
                // en este caso debemos cambiar o actualizar los datos del hotel..
                var enlace = new EnlaceDB();
                // ya no usamos el cmb, usamos la variable global
                int idDireccion = enlace.InsertarDireccion((int)cmbPais.SelectedValue,(int)cmdEstado.SelectedValue,(int)cmbCiudad.SelectedValue,Calle.Text);
                bool ok = enlace.ActualizarHotel(idSeleccion,Hotel.Text,idDireccion,FechaOp.Value.Date,(int)ndPisos.Value);

                if (ok)
                {
                    // poner que ya se deselecciono el hotel?
                    MessageBox.Show("Hotel actualizado correctamente.");
                    limpiarcampos();
                    CargarHoteles();
                    idSeleccion = -1;
                    VerificandoAndo();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el hotel, vuelva a seleccionarlo");
                    idSeleccion = -1;
                    VerificandoAndo();
                }

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ndPisos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Bloquea el punto y la coma
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.Handled = true; // Cancela la entrada
            }
        }

        private void Hotel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void dgvHoteles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Asegura que no sea el encabezado
            {
                DataGridViewRow filaSeleccionada = dgvHoteles.Rows[e.RowIndex];

                // Suponiendo que la columna del ID se llama "IdHotel"
                int idSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["IdHotel"].Value);
                string hotelse= Convert.ToString(filaSeleccionada.Cells["Hotel"].Value);
                MessageBox.Show($"El registro seleccionado es: {hotelse}", "Registro seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                EnlaceDB enlace = new EnlaceDB();
                DataTable dt = enlace.ObtenerHotelPorId(idSeleccionado);
                idSeleccion = idSeleccionado; /// almacenamos globalmente nuestro id seleccionado
                VerificandoAndo();
                // aqui deberiamos activar los controles de tipo de habitacion
                CargarTipoHabi();
                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];

                    Hotel.Text = fila["Nombre_Hotel"].ToString();
                    ndPisos.Value =(int)fila["Pisos"];
                    FechaOp.Value = Convert.ToDateTime(fila["Fecha_Ini_Ope"]);
                    // Ahora llena los ComboBox de dirección con los valores
                    cmbPais.SelectedValue = fila["IdPais"];
                    cmdEstado.SelectedValue = fila["IdEstado"];
                    cmbCiudad.SelectedValue = fila["IdCiudad"];
                    Calle.Text = fila["Domicilio"].ToString();
                }
                CargaServicios(idSeleccion);
                cargarCaracter(idSeleccion);
                /// 
            }

        }
        
        private void dgvHoteles_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            // if para identificar si va a modificar o eliminar...
            if(IdServicioSele==-1)
            {
                EnlaceDB enlace = new EnlaceDB();
                bool ok = enlace.AgregarServicio(txtServicio.Text, nupPrec.Value, idSeleccion);
                if (ok)
                {
                    // poner que ya se deselecciono el hotel?
                    MessageBox.Show("Servicio agregado correctamente.");
                    txtServicio.Text = "";
                    nupPrec.Value = 0;
                    CargaServicios(idSeleccion);
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el servicio.");

                }
            }
            else
            {
                // modificar....
                EnlaceDB enlace = new EnlaceDB();
                bool ok = enlace.ModificarServicio(txtServicio.Text,nupPrec.Value,IdServicioSele);
                if (ok)
                {
                    MessageBox.Show("Servicio modificado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al modificar Servicio");
                }
                IdServicioSele = -1;
                txtServicio.Text = "";
                nupPrec.Value = 0;
                CargaServicios(idSeleccion);
            }
            
        }

        private void BtnEliminarServicio_Click(object sender, EventArgs e)
        {
            if(IdServicioSele>0)
            {
                EnlaceDB enlace = new EnlaceDB();
                bool ok = enlace.eliminarServicio(IdServicioSele);
                if (ok)
                {
                    MessageBox.Show("Servicio Eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al eliminar Servicio");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un servicio Primero");
            }
            IdServicioSele = -1;
            txtServicio.Text = "";
            nupPrec.Value = 0;
            CargaServicios(idSeleccion);
        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0) // Asegura que no sea el encabezado
            {
                
                DataGridViewRow filaSeleccionada = dgvServicios.Rows[e.RowIndex];
                txtServicio.Text = Convert.ToString(filaSeleccionada.Cells["Nombre"].Value);
                nupPrec.Value =(decimal)filaSeleccionada.Cells["Costo"].Value;
                IdServicioSele = (int)filaSeleccionada.Cells["IdServicio"].Value;
                string service = txtServicio.Text;
                MessageBox.Show($"EL servicio: {service} ha sido seleccionado ");
            }

        }

        private void nupPrec_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvCaract_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Asegura que no sea el encabezado
            {
                DataGridViewRow filaSeleccionada = dgvCaract.Rows[e.RowIndex];
                IdCaract = (int)filaSeleccionada.Cells["IdCaracteristica"].Value;
            }
        }

        private void btnAgregarCarac_Click(object sender, EventArgs e)
        {
            IdCaract = -1;
            EnlaceDB enlace = new EnlaceDB();
            bool ok = enlace.AgregarCaracter(txtCaracteristica.Text,idSeleccion);
            if (ok)
            {
                MessageBox.Show("caracteristica agregada correctamente.");
            }
            else
            {
                MessageBox.Show("Error al agregar caracteristica");
            }
            cargarCaracter(idSeleccion);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EnlaceDB enlace = new EnlaceDB();
            bool ok = enlace.eliminarCaracteristica(IdCaract);
            if (ok)
            {
                MessageBox.Show("Caracteristica Eliminada correctamente.");
                IdCaract = -1;
                cargarCaracter(idSeleccion);
            }
            else
            {
                MessageBox.Show("Error al eliminar Caracteristica");
                IdCaract = -1;
                cargarCaracter(idSeleccion);
            }
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
           
            EnlaceDB enlace = new EnlaceDB();
            int CantidadP;
            CantidadP = Convert.ToInt16(txtPersonas.Text);
            decimal prec = Convert.ToDecimal(txtPrecio.Text);
            if (IdtipoHab == -1)
            {
                bool ok = enlace.InsertarTipoHabitacion(CantidadP, txtNivel.Text, (int)nupCantCamas.Value, prec, idSeleccion, cmbTcamas.Text);
                if (ok)
                {
                    MessageBox.Show("Tipo de habitacion registrada correctamente.");
                    IdCaract = -1;
                    cargarCaracter(idSeleccion);
                    CargarTipoHabi();
                }
                else
                {
                    MessageBox.Show("Error al registrar tipo de habitacion");
                    IdCaract = -1;
                    cargarCaracter(idSeleccion);
                    CargarTipoHabi();
                    //cargarCaracteristicas
                }
                // limpiar campos
                txtPersonas.Text = "0";
                txtPrecio.Text = "0.00";
                txtNivel.Text = "";
                nupCantCamas.Value = 0;
                cmbTcamas.Text = "";
            }
            else
            {
                //ejecutar actualizacion
                bool ok = enlace.ActualizarTipoHabitacion(CantidadP, txtNivel.Text, (int)nupCantCamas.Value, prec,cmbTcamas.Text,IdtipoHab);
                if (ok)
                {
                    MessageBox.Show("Tipo de habitacion actualizada correctamente.");
                    IdCaract = -1;
                }
                else
                {
                    MessageBox.Show("Error al Actualizar ");
                    IdCaract = -1;
                   
                }
                CargarTipoHabi();
                IdtipoHab = -1;
                //limpiar campos
                txtPersonas.Text = "0";
                txtPrecio.Text = "0.00";
                txtNivel.Text = "";
                nupCantCamas.Value = 0;
                cmbTcamas.Text = "";
            }
        }

        private void dgvTipoHabi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegura que no sea el encabezado
            {
                DataGridViewRow filaSeleccionada = dgvTipoHabi.Rows[e.RowIndex];
                // Suponiendo que la columna del ID se llama "IdHotel"
                IdtipoHab = Convert.ToInt32(filaSeleccionada.Cells["IdTipo"].Value);
                string TipoHabi = Convert.ToString(filaSeleccionada.Cells["Nivel"].Value);
                MessageBox.Show($"El registro seleccionado es: {TipoHabi}", "Registro seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCaractTipo();
                CargarAmenidad();
                CargarHabi();

                EnlaceDB enlace = new EnlaceDB();
                DataTable dt = enlace.ObtenerTipoHabiID(IdtipoHab);
                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    txtNivel.Text = fila["Nivel"].ToString();
                    txtPersonas.Text= fila["Cant_Pers"].ToString();
                    nupCantCamas.Value = (int)fila["Camas"];
                    cmbTcamas.Text = fila["Tipo_Camas"].ToString();
                    txtPrecio.Text= fila["PrecioxPersonaxNoche"].ToString();
                }
               

            }
        }

        private void cmbTcamas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarHabi_Click(object sender, EventArgs e)
        {
            if(txtCaractHabi.Text=="")
            {
                return;
            }
            EnlaceDB enlace = new EnlaceDB();
            bool ok = enlace.AgregarCaracTipo(txtCaractHabi.Text, IdtipoHab);
            if (ok)
            {
                MessageBox.Show("caracteristica agregada correctamente.");
            }
            else
            {
                MessageBox.Show("Error al agregar caracteristica");
            }
            CargarCaractTipo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = IdCaracTH;
            // codigo de obtener lo seleccionado
            EnlaceDB enlace = new EnlaceDB();
            bool ok = enlace.eliminCaracTipo(IdCaracTH);
            if (ok)
            {
                MessageBox.Show("caracteristica eliminada correctamente.");
            }
            else
            {
                MessageBox.Show("Error al eliminar caracteristica");
            }
            CargarCaractTipo();
            IdCaracTH = 0;
        }

        private void dgvCaracteristicas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegura que no sea el encabezado
            {
                DataGridViewRow filaSeleccionada = dgvCaracteristicas.Rows[e.RowIndex];
                // Suponiendo que la columna del ID se llama "IdHotel"
                IdCaracTH = Convert.ToInt32(filaSeleccionada.Cells["IdCaracteristica"].Value);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtAmenidad.Text == "")
            {
                return;
            }
            EnlaceDB enlace = new EnlaceDB();
            bool ok = enlace.AgregarAmenidad(txtAmenidad.Text, IdtipoHab);
            if (ok)
            {
                MessageBox.Show("Amenidad agregada correctamente.");
            }
            else
            {
                MessageBox.Show("Error al agregar Amendiad");
            }
            CargarAmenidad();
            IdAmenidad = 0;
        }

        private void btnEliminarAmenidad_Click(object sender, EventArgs e)
        {
            // checar el id de amenidad...
            int x = IdAmenidad;
            // codigo de obtener lo seleccionado
            EnlaceDB enlace = new EnlaceDB();
            bool ok = enlace.eliminAmenidad(IdAmenidad);
            if (ok)
            {
                MessageBox.Show("Amenidad eliminada correctamente.");
            }
            else
            {
                MessageBox.Show("Error al eliminar Amenidad");
            }
            CargarAmenidad();
            IdAmenidad = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegura que no sea el encabezado
            {
                DataGridViewRow filaSeleccionada = dgvAmendiades.Rows[e.RowIndex];
                // Suponiendo que la columna del ID se llama "IdHotel"
                IdAmenidad = Convert.ToInt32(filaSeleccionada.Cells["IdAmenidad"].Value);
            }
        }

        private void btnAgregarHab_Click(object sender, EventArgs e)
        {
            if (textNumHabi.Text == ""|| IdtipoHab==-1 || idSeleccion==-1)
            {
                return;
            }
            EnlaceDB enlace = new EnlaceDB();
            int x = Convert.ToInt16(textNumHabi.Text);
            bool ok = enlace.InsertarHabitaciones(x, IdtipoHab,idSeleccion);
            if (ok)
            {
                MessageBox.Show("Habitacion agregada correctamente.");
            }
            else
            {
                MessageBox.Show("Error al agregar Habitacion");
            }
            CargarHabi();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
