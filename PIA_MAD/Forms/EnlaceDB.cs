/*
Autor: Alejandro Villarreal

LMAD

PARA EL PROYECTO ES OBLIGATORIO EL USO DE ESTA CLASE, 
EN EL SENTIDO DE QUE LOS DATOS DE CONEXION AL SERVIDOR ESTAN DEFINIDOS EN EL App.Config
Y NO TENER ESOS DATOS EN CODIGO DURO DEL PROYECTO.

NO SE PERMITE HARDCODE.

LOS MÉTODOS QUE SE DEFINEN EN ESTA CLASE SON EJEMPLOS, PARA QUE SE BASEN Y USTEDES HAGAN LOS SUYOS PROPIOS
Y DEFINAN Y PROGRAMEN TODOS LOS MÉTODOS QUE SEAN NECESARIOS PARA SU PROYECTO.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using PIA_MAD.Forms;
using Siticone.Desktop.UI.WinForms;


/*
Se tiene que cambiar el namespace para el que usen en su proyecto
*/
namespace WindowsFormsApplication1
{
    public class EnlaceDB
    {
        static private string _aux { set; get; }
        static private SqlConnection _conexion;
        static private SqlDataAdapter _adaptador = new SqlDataAdapter();
        static private SqlCommand _comandosql = new SqlCommand();
        static private DataTable _tabla = new DataTable();
        static private DataSet _DS = new DataSet();

        public DataTable obtenertabla
        {
            get
            {
                return _tabla;
            }
        }

        private static void conectar()
        {
            /*
			Para que funcione el ConfigurationManager
			en la sección de "Referencias" de su proyecto, en el "Solution Explorer"
			dar clic al botón derecho del mouse y dar clic a "Add Reference"
			Luego elegir la opción System.Configuration
			
			tal como lo vimos en clase.
			*/
            string cnn = ConfigurationManager.ConnectionStrings["ConexionMAD"].ToString(); 
			// Cambiar Grupo01 por el que ustedes hayan definido en el App.Confif
            _conexion = new SqlConnection(cnn);
            _conexion.Open();
        }
        private static void desconectar()
        {
            _conexion.Close();
        }
        /* 
         
         *********************************************PRUEBAS**********************************************************************
         
         */
        

        /*
         *************************************** AQUI EMPIEZA LO BUENO *************************************
         */

        /////////////////////  funcion login
        public bool ValidarLogin(string correo, string contraseña)
        {
            bool loginCorrecto = false;

            try
            {
                conectar();
                string procedureName = "UsuLogin";
                _comandosql = new SqlCommand(procedureName, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.AddWithValue("@Correo", correo);
                _comandosql.Parameters.AddWithValue("@Pass", contraseña);

                SqlDataReader reader = _comandosql.ExecuteReader();

                if (reader.Read()) // 🔵 Si encontró un usuario válido
                {
                    loginCorrecto = true;

                    // 🔥 Aquí colocas la carga en Estructuras
                    Estructuras.SesionUsuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    Estructuras.SesionUsuario.Correo = reader["Correo"].ToString();
                    Estructuras.SesionUsuario.TipoUsu = Convert.ToInt32(reader["TipoUsu"]);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                loginCorrecto = false;
                // (Opcional: puedes capturar el error)
            }
            finally
            {
                desconectar();
            }

            return loginCorrecto;
        }

        /************************************************Funcion insertar usuario ********************************************************/
        public bool RegistrarUsuario(
        string nombre, string apPaterno, string apMaterno,
        string correo, string nns, DateTime fechaNac,
        string telCasa, string telCel, string contraseña, int idUsu)
        {
            bool insertado = false;

            try
            {
                conectar();
                string procedureName = "RegistrarOp";
                _comandosql = new SqlCommand(procedureName, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;

                _comandosql.Parameters.AddWithValue("@Nombre", nombre);
                _comandosql.Parameters.AddWithValue("@ApPaterno", apPaterno);
                _comandosql.Parameters.AddWithValue("@ApMaterno", apMaterno);
                _comandosql.Parameters.AddWithValue("@Correo", correo);
                _comandosql.Parameters.AddWithValue("@NNS", nns);
                _comandosql.Parameters.AddWithValue("@FechaNac", fechaNac.Date);
                _comandosql.Parameters.AddWithValue("@Tel_casa", telCasa);
                _comandosql.Parameters.AddWithValue("@Tel_cel", telCel);
                _comandosql.Parameters.AddWithValue("@Contraseña", contraseña);
                _comandosql.Parameters.AddWithValue("@IdUsu", idUsu);

                int resultado = _comandosql.ExecuteNonQuery(); // filas afectadas

                insertado = resultado > 0;
            }
            catch (SqlException ex)
            {
                // Aquí podrías registrar el error con logs si lo deseas
                insertado = false;
            }
            finally
            {
                desconectar();
            }

            return insertado;
        }

        public DataTable ObtenerUsuarios()
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("MostrarUsu", _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                // Log o mensaje si deseas
                MessageBox.Show("Error al obtener usuarios: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }
        public bool CambiarEstatusUsuario(int idUsuario, string nuevoEstatus)
        {
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("CambiarEstatusUsuario", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@NuevoEstatus", nuevoEstatus);
                cmd.Parameters.AddWithValue("@IdModificador", Estructuras.SesionUsuario.IdUsuario);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally
            {
                desconectar();
            }
        }

        public DataTable ObtenerPaises()
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerPaises", _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener países: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable ObtenerEstados(int idPais)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerEstados", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdPais", idPais);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener estados: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable ObtenerCiudades(int idEstado)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerCiudades", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdEstado", idEstado);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener ciudades: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable ObtenerMunicipios(int idCiudad)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerMunicipios", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCiudad", idCiudad);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener municipios: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable ObtenerColonias(int idMunicipio)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerColonias", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdMunicipio", idMunicipio);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener colonias: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public string ObtenerCodigoPostalPorColonia(int idColonia)
        {
            string codigoPostal = "";

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerCodigoPostal", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdColonia", idColonia);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    codigoPostal = reader["CodigoPostal"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener el código postal: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return codigoPostal;
        }

        public int InsertarDireccion(
    int idPais,
    int idEstado,
    int idCiudad,
    int? idMunicipio,
    int? idColonia,
    string calle,
    string numeroExterior,
    string numeroInterior)
        {
            int newId = -1;

            try
            {
                conectar();
                using (SqlCommand cmd = new SqlCommand("InsertarDireccion", _conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPais", idPais);
                    cmd.Parameters.AddWithValue("@IdEstado", idEstado);
                    cmd.Parameters.AddWithValue("@IdCiudad", idCiudad);
                    cmd.Parameters.AddWithValue("@IdMunicipio", (object)idMunicipio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdColonia", (object)idColonia ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Calle", calle);
                    cmd.Parameters.AddWithValue("@NumeroExterior", (object)numeroExterior ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NumeroInterior", (object)numeroInterior ?? DBNull.Value);

                    // Parámetro de salida
                    var outParam = new SqlParameter("@NewIdDireccion", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();

                    newId = (int)outParam.Value;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar dirección: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return newId;
        }

        public bool InsertarHotel(
    string nombreHotel,
    int idDireccion,
    string zonaTuristica,int pisos,
    DateTime fechaIniOpe)
        {
            bool éxito = false;

            try
            {
                conectar();
                using (SqlCommand cmd = new SqlCommand("RegistrarHotel", _conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreHotel", nombreHotel);
                    cmd.Parameters.AddWithValue("@IdDireccion", idDireccion);
                    cmd.Parameters.AddWithValue("@ZonaTuristica",
                        string.IsNullOrWhiteSpace(zonaTuristica)
                          ? (object)DBNull.Value
                          : zonaTuristica);
                    cmd.Parameters.AddWithValue("@Pisos", pisos);
                    cmd.Parameters.AddWithValue("@FechaIniOpe", fechaIniOpe);
                    // Usamos el usuario que inició sesión
                    cmd.Parameters.AddWithValue("@IdUsuario", Estructuras.SesionUsuario.IdUsuario);
                    

                    int rows = cmd.ExecuteNonQuery();
                    // si devuelve –1 o >0 → éxito
                     éxito = (rows != 0);

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al registrar hotel: " + ex.Message);
                éxito = false;
            }
            finally
            {
                desconectar();
            }

            return éxito;
        }

        public bool ActualizarDireccionHotel(int idHotel, int nuevoIdDireccion)
        {
            bool exito = false;

            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("ActualizarDireccionHotel", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdHotel", idHotel);
                cmd.Parameters.AddWithValue("@NuevoIdDireccion", nuevoIdDireccion);

                int rows = cmd.ExecuteNonQuery();
                exito = (rows > 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar la dirección del hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }

        public DataTable ObtenerHoteles()
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerHoteles", _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener hoteles: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable ObtenerHotelPorId(int idHotel)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerHotelPorId", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdHotel", idHotel);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener datos del hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }


        public bool ActualizarHotel(int idHotel, string nombreHotel, int idDireccion, string zonaTuristica, DateTime fechaIniOpe)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("ActualizarHotel", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdHotel", idHotel);
                cmd.Parameters.AddWithValue("@NombreHotel", nombreHotel);
                cmd.Parameters.AddWithValue("@IdDireccion", idDireccion);
                cmd.Parameters.AddWithValue("@ZonaTuristica", string.IsNullOrEmpty(zonaTuristica) ? (object)DBNull.Value : zonaTuristica);
                cmd.Parameters.AddWithValue("@FechaIniOpe", fechaIniOpe);
                cmd.Parameters.AddWithValue("@IdUsuario", Estructuras.SesionUsuario.IdUsuario); // puede venir de sesión o contexto

                int rows = cmd.ExecuteNonQuery();
                
                exito = (rows >= 0); 
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }

        public bool InsertarTipoHabitacion(int cantPers, string caracteristicas,string nivel, int camas, string amenidades,
                                   float precio, int idHotel, string tipoCamas)
        {
            SqlCommand cmd = new SqlCommand("InsertarTipoHabitacion", _conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cant_Pers", cantPers);
            cmd.Parameters.AddWithValue("@Caracteristicas",caracteristicas);
            cmd.Parameters.AddWithValue("@Nivel", nivel);
            cmd.Parameters.AddWithValue("@Camas", camas);
            cmd.Parameters.AddWithValue("@PrecioxPersonaXNoche", precio);
            cmd.Parameters.AddWithValue("@IdUsuario", Estructuras.SesionUsuario.IdUsuario);
            cmd.Parameters.AddWithValue("@IdHotel", idHotel);
            cmd.Parameters.AddWithValue("@Tipo_camas", tipoCamas);

            _conexion.Open();
            int rows = cmd.ExecuteNonQuery();
            _conexion.Close();

            return rows > 0;
        }
        public DataTable ObtenerTiposHabitacionPorHotel(int idHotel,int idTipo)
        {
            SqlDataAdapter da = new SqlDataAdapter("ObtenerTiposHabitacionPorHotel", _conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdHotel", idHotel);
            da.SelectCommand.Parameters.AddWithValue("@IdTipo", idTipo);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
        public DataTable ObtenerTiposHabitacionPorHotel2(int idHotel)
        {
            SqlDataAdapter da = new SqlDataAdapter("ObtenerTiposHabitacionPorHotel2", _conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdHotel", idHotel);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
        public bool ActualizarTipoHabitacion(int idTipo, int cantPers, string caracteristicas, string nivel,
                                     int camas, string tipoCamas, float precio)
        {
            using (SqlCommand cmd = new SqlCommand("ActualizarTipoHabitacion", _conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipo", idTipo);
                cmd.Parameters.AddWithValue("@Cant_Pers", cantPers);
                cmd.Parameters.AddWithValue("@Caracteristicas", caracteristicas);
                cmd.Parameters.AddWithValue("@Nivel", nivel);
                cmd.Parameters.AddWithValue("@Camas", camas);
                cmd.Parameters.AddWithValue("@Tipo_camas", tipoCamas);
                cmd.Parameters.AddWithValue("@PrecioxPersonaxNoche", precio);
                cmd.Parameters.AddWithValue("@IdUsuario", Estructuras.SesionUsuario.IdUsuario);

                _conexion.Open();
                int rows = cmd.ExecuteNonQuery();
                _conexion.Close();

                return rows > 0;
            }
        }
        /********************************** HABITACIONES ***********************/
        public bool InsertarHabitaciones(int idHotel, int NumHabitacion, int Tipo, string caracteristicas)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("InsertarHabitaciones", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdHotel", idHotel); 
                comando.Parameters.AddWithValue("@Numero_Habitacion", NumHabitacion);
                comando.Parameters.AddWithValue("@IdTipo", Tipo);
                comando.Parameters.AddWithValue("@IdUsuario", Estructuras.SesionUsuario.IdUsuario);
                comando.Parameters.AddWithValue("@Caracteristicas",caracteristicas);

                int rows = comando.ExecuteNonQuery();
                // si devuelve –1 o >0 → éxito
                exito = (rows != 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar habitacion " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }

        public DataTable BuscarHabitaciones(int idHotel, int idTipo)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("BuscarHabitaciones", _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@IdHotel", idHotel);
                comando.Parameters.AddWithValue("@IdTipo", idTipo);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al buscar habitaciones: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public bool ActualizarHabitacion(int idHotel, int NumHabitacion, int IdTipo, string status,
                                     string caracteristicas)
        {
            using (SqlCommand cmd = new SqlCommand("ActualizarHabitacion", _conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdHotel", idHotel);
                cmd.Parameters.AddWithValue("@Numero_Habitacion", NumHabitacion);
                cmd.Parameters.AddWithValue("@IdTipo", IdTipo);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Caracteristicas", caracteristicas);
                cmd.Parameters.AddWithValue("@IdUsuario", Estructuras.SesionUsuario.IdUsuario);

                _conexion.Open();
                int rows = cmd.ExecuteNonQuery();
                _conexion.Close();

                return rows > 0;
            }
        }

        /************************ Clientes ************************/
        public bool InsertarCliente(string rfc, string nombres, string apPaterno, string apMaterno,
                            int idDireccion, string telCasa, string telCel, string correo,
                            char estadoCivil, DateTime fechaNac)
        {
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("InsertarCliente", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RFC", rfc);
                cmd.Parameters.AddWithValue("@Nombres", nombres);
                cmd.Parameters.AddWithValue("@ApPaterno", apPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", apMaterno);
                cmd.Parameters.AddWithValue("@IdDireccion", idDireccion);
                cmd.Parameters.AddWithValue("@TelCasa", telCasa);
                cmd.Parameters.AddWithValue("@TelCel", telCel);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Estado_Civil", estadoCivil);
                cmd.Parameters.AddWithValue("@Fecha_Nac", fechaNac);
                cmd.Parameters.AddWithValue("@IdUsuario", Estructuras.SesionUsuario.IdUsuario);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar cliente: " + ex.Message);
                return false;
            }
            finally
            {
                desconectar();
            }
        }

        /*
         
         ********************************************* EJEMPLOS DEL PROFE *****************************************************
         
         */
        public bool Autentificar(string us, string ps)
        {
            bool isValid = false;
            try
            {
                conectar();
                string qry = "SP_ValidaUser";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                var parametro1 = _comandosql.Parameters.Add("@u", SqlDbType.Char, 20);
                parametro1.Value = us;
                var parametro2 = _comandosql.Parameters.Add("@p", SqlDbType.Char, 20);
                parametro2.Value = ps;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(_tabla);

                if(_tabla.Rows.Count > 0)
                {
                    isValid = true;
                }

            }
            catch(SqlException e)
            {
                isValid = false;
            }
            finally
            {
                desconectar();
            }

            return isValid;
        }

        public DataTable get_Users()
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
				// Ejemplo de cómo ejecutar un query, 
				// PERO lo correcto es siempre usar SP para cualquier consulta a la base de datos
                string qry = "Select Nombre, email, Fecha_modif from Usuarios where Activo = 0;";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.Text;
						// Esta opción solo la podrían utilizar si hacen un EXEC al SP concatenando los parámetros.
                _comandosql.CommandTimeout = 1200;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

		// Ejemplo de método para recibir una consulta en forma de tabla
		// Cuando el SP ejecutará un SELECT
        public DataTable get_Deptos(string opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Gestiona_Deptos";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla); 
				// la ejecución del SP espera que regrese datos en formato tabla

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }
		
		// Ejemplo de método para ejecutar un SP que no se espera que regrese información, 
		// solo que ejecute ya sea un INSERT, UPDATE o DELETE
        public bool Add_Deptos(string opc, string depto)
        {
            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "sp_Gestiona_Deptos";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 20);
                parametro2.Value = depto;

                _adaptador.InsertCommand = _comandosql;
				// También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand
                
                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();                
            }

            return add;
        }

    }
}
