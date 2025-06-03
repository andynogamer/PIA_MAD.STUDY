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
using PIA_MAD.Forms;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PIA_MAD.Forms.Estructuras;
using static TheArtOfDev.HtmlRenderer.Adapters.RGraphicsPath;



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
        public DataTable ObtenerUsuarioPorId(int idUsuario)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("BuscUsu", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener datos del usuario: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }
        public bool ActualizarUsuario(int idUsuario,string nombres,string ApPaterno,string ApMaterno,string Correo,string nomi,DateTime fecha,string tel_casa, string tel_cel, string contra)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("actUsu", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                comando.Parameters.AddWithValue("@Nombre_Usu", nombres);
                comando.Parameters.AddWithValue("@ApPaterno", ApPaterno);
                comando.Parameters.AddWithValue("@ApMaterno", ApMaterno);
                comando.Parameters.AddWithValue("@Correo", Correo);
                comando.Parameters.AddWithValue("@NNS",nomi );
                comando.Parameters.AddWithValue("@FechaNac", fecha);
                comando.Parameters.AddWithValue("@Tel_casa", tel_casa);
                comando.Parameters.AddWithValue("@Tel_cel", tel_cel);
                comando.Parameters.AddWithValue("@Pass", contra);
              
                int rows = comando.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener datos del usuario: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
            return false;
            
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
        public DataTable ObtenerReporteCliente(int id, int? año=null)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerHistorialCliente", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCliente", id);
                comando.Parameters.AddWithValue("@Anio", año);
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
        } // este hay que eliminarlo
        public DataTable ObtenerCiudadesPorPais(int idPais)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar(); // Asume que ya tienes este método en tu clase

                SqlCommand comando = new SqlCommand("ObtenerCiudadesPorPais", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdPais", idPais);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener ciudades: " + ex.Message);
            }
            finally
            {
                desconectar(); // Asume que también tienes este método
            }

            return tabla;
        } // este hay que eliminarlo

        public DataTable ObtenerReporteVentas(int Pais,int ciudad, int año , int? idHotel=null)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerReporteVentas", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdPais", Pais);
                comando.Parameters.AddWithValue("@Anio", año);
                comando.Parameters.AddWithValue("@IdCiudad", ciudad);
                comando.Parameters.AddWithValue("@IdHotel", idHotel);
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
        } // este hay que eliminarlo



        public DataTable ObtenerReporteVentas2(int Pais, int ciudad, int año)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("sp_ReporteIngresosHotel", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdPais", Pais);
                comando.Parameters.AddWithValue("@IdCiudad", ciudad);
                comando.Parameters.AddWithValue("@anio", año);
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
        } // este hay que eliminarlo

        public DataSet ObtenerReporteOcupacionHotel( int ciudad, int anio, int? idHotel = null)
        {
            DataSet tabla = new DataSet();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerInformeOcupacionHotel", _conexion);
                comando.CommandType = CommandType.StoredProcedure;

           
                comando.Parameters.AddWithValue("@IdCiudad", ciudad);
                comando.Parameters.AddWithValue("@Anio", anio);

                // Para parámetro opcional, si no se envía, mandamos DBNull.Value
                if (idHotel.HasValue)
                    comando.Parameters.AddWithValue("@IdHotel", idHotel.Value);
                else
                    comando.Parameters.AddWithValue("@IdHotel", DBNull.Value);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener reporte de ocupación: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        
        public DataTable ObtenerResumenOcupacionHotel(int pais, int ciudad, int anio, int? idHotel = null)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("Resumen_Ocupacion_Hotel", _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@IdPais", pais);
                comando.Parameters.AddWithValue("@IdCiudad", ciudad);
                comando.Parameters.AddWithValue("@Anio", anio);

                if (idHotel.HasValue)
                    comando.Parameters.AddWithValue("@IdHotel", idHotel.Value);
                else
                    comando.Parameters.AddWithValue("@IdHotel", DBNull.Value);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener resumen de ocupación: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        } // este hay que eliminarlo
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
        } // este se queda 
        public void CambiarContrasena(FrmCambioContrasena frmCambioContrasena, string correo, string pass1)
        {
            try
            {
               
                {
                    conectar();

                    SqlCommand cmd = new SqlCommand("sp_CambiarContrasena", _conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@NuevaPass", pass1);
                   

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmCambioContrasena.Close(); // Cierra la ventana modal
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // este hay que checarlo

        public int InsertarDireccion(int idPais,int idEstado,int idCiudad,string calle)
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
                    cmd.Parameters.AddWithValue("@Domicilio", calle);
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
        } // este se queda
        public bool InsertarHotel(string nombreHotel,int idDireccion,int pisos,DateTime fechaIniOpe)
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
        } // este se queda

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
        } // este se queda

        public DataTable ObtenerHoteles()
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("VerHotelesOrdenados", _conexion);
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
        } // este se queda

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
        } // este se queda
        public DataTable ObtenerCantidadHabitaciones(int idHotel)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerResumenHabitacionesPorHotel", _conexion);
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
        } // se elimina

        public bool ActualizarHotel(int idHotel, string nombreHotel, int idDireccion, DateTime fechaIniOpe, int Pisos)
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
                cmd.Parameters.AddWithValue("@FechaIniOpe", fechaIniOpe);
                cmd.Parameters.AddWithValue("@IdUsuario", Estructuras.SesionUsuario.IdUsuario); // puede venir de sesión o contexto
                cmd.Parameters.AddWithValue("@Pisos",Pisos);
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
        public bool AgregarServicio( string nombre,decimal costo,int idHotel)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("InsertarServicio", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Costo", costo);
                cmd.Parameters.AddWithValue("@IdHotel", idHotel);
                int rows = cmd.ExecuteNonQuery();

                exito = (rows >= 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al Insertar Servicio: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }
        public DataTable ObtenerServicios(int idHotel)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("VerServiciosHotel", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdHotel", idHotel);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener Servicios del hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }
        public bool ModificarServicio(string nombre, decimal costo, int Servicio)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("ActServi", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Costo", costo);
                cmd.Parameters.AddWithValue("@IdServicio", Servicio);
                int rows = cmd.ExecuteNonQuery();

                exito = (rows >= 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al modificar Servicio: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }
        public bool eliminarServicio(int Servicio)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("EliminarServi", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdServicio", Servicio);
                int rows = cmd.ExecuteNonQuery();

                exito = (rows >= 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar Servicio: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }
        public bool AgregarCaracter(string nombre, int idHotel)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("InsertCaracter", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdHotel", idHotel);
                cmd.Parameters.AddWithValue("@Caracteristica", nombre);
                int rows = cmd.ExecuteNonQuery();

                exito = (rows >= 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al Insertar Caracteristica: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }
        public bool eliminarCaracteristica(int caract)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("EliminarCaracteristica", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCaracteristica", caract);
                int rows = cmd.ExecuteNonQuery();

                exito = (rows >= 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar Caracteristica: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }
        public DataTable ObtenerCaracteristicas(int idHotel)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("VerCaract", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdHotel", idHotel);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener Caracteristicas del hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        } 
        /********************************** TIPO HABITACIONES ***********************/ 
        public bool InsertarTipoHabitacion(int cantPers,string nivel, int camas,
                                   decimal precio, int idHotel, string tipoCamas)
        {
            SqlCommand cmd = new SqlCommand("InserTipo", _conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cant_Pers", cantPers);
            cmd.Parameters.AddWithValue("@Nivel", nivel);
            cmd.Parameters.AddWithValue("@Camas", camas);
            cmd.Parameters.AddWithValue("@Tipo_camas", tipoCamas);
            cmd.Parameters.AddWithValue("@PrecioxPersonaxNoche", precio);
            cmd.Parameters.AddWithValue("@IdUsuario", Estructuras.SesionUsuario.IdUsuario);
            cmd.Parameters.AddWithValue("@IdHotel", idHotel);
            _conexion.Open();
            int rows = cmd.ExecuteNonQuery();
            _conexion.Close();

            return rows > 0;
        }
        public DataTable BuscarTipoHabiIDHotel(int IdHotel)
        {
            SqlDataAdapter da = new SqlDataAdapter("VerTiposHabitacion", _conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdHotel", IdHotel);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
        public DataTable ObtenerTipoHabiID(int idTipo)
        {
            SqlDataAdapter da = new SqlDataAdapter("BuscaTipoHabiID", _conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdTipo", idTipo);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
        public bool ActualizarTipoHabitacion(int cantPers, string nivel, int camas,
                                   decimal precio, string tipoCamas,int IdTipo)
        {
            using (SqlCommand cmd = new SqlCommand("ActTipo", _conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cant_Pers", cantPers);
                cmd.Parameters.AddWithValue("@Nivel", nivel);
                cmd.Parameters.AddWithValue("@Camas", camas);
                cmd.Parameters.AddWithValue("@Tipo_camas", tipoCamas);
                cmd.Parameters.AddWithValue("@PrecioxPersonaxNoche", precio);
                cmd.Parameters.AddWithValue("@IdUsuario", Estructuras.SesionUsuario.IdUsuario);
                cmd.Parameters.AddWithValue("@IdTipo", IdTipo);
                _conexion.Open();
                int rows = cmd.ExecuteNonQuery();
                _conexion.Close();

                return rows > 0;
            }
        }
        /// caracteristicas del tipo de habitacion
        /// despues van amenidades
        public DataTable verCaractHabi(int IdTipoHabi)
        {
            SqlDataAdapter da = new SqlDataAdapter("VerCaractHabi", _conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdTipoHabi", IdTipoHabi);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        } // vemos 
        public bool AgregarCaracTipo(string nombre, int IdTipo)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("AgregarCaracTipoHabi", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipoHabi", IdTipo);
                cmd.Parameters.AddWithValue("@Caracteristica", nombre);
                int rows = cmd.ExecuteNonQuery();

                exito = (rows >= 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al Insertar Caracteristica: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }
        public bool eliminCaracTipo(int caract)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("EliminCaractTipoHabi", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCaracteristica ", caract);
                int rows = cmd.ExecuteNonQuery();

                exito = (rows > 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar Caracteristica: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }
        // amenidades
        public DataTable verAmendiades(int IdTipoHabi)
        {
            SqlDataAdapter da = new SqlDataAdapter("VerAmenidades", _conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdTipoHabi", IdTipoHabi);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        } // vemos 
        public bool AgregarAmenidad(string nombre, int IdTipoHabi)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("AgregarAmenidad", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipoHabi", IdTipoHabi);
                cmd.Parameters.AddWithValue("@Amenidad", nombre);
                int rows = cmd.ExecuteNonQuery();

                exito = (rows >= 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al Insertar Amenidad: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }
        public bool eliminAmenidad(int amenidad)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("EliminarAmenidad", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAmenidad ", amenidad);
                int rows = cmd.ExecuteNonQuery();

                exito = (rows > 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar Amenidad: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }

        /********************************** HABITACIONES ***********************/
        public bool InsertarHabitaciones( int NumHabitacion, int Tipo,int idHotel)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("InserHabita", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdHotel", idHotel);
                comando.Parameters.AddWithValue("@IdTipo", Tipo);
                comando.Parameters.AddWithValue("@Numero_Habitacion", NumHabitacion);
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

        public DataTable BuscarHabitaciones(int idTipo)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("VerHabi", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
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

        // cliente - reservaciones
        public bool ActualizarCliente(int cliente, string rfc, string nombres, string apPaterno, string apMaterno,
                          int idDireccion, string telCasa, string telCel, string correo,
                          char estadoCivil, DateTime fechaNac)
        {
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("ActualizarCliente", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdCliente",cliente );
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
                MessageBox.Show("Error al Actualizar cliente: " + ex.Message);
                return false;
            }
            finally
            {
                desconectar();
            }
        }
        public DataTable ObtenerClientes()
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("VerCliente", _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                // Log o mensaje si deseas
                MessageBox.Show("Error al obtener Clientes: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }
        public DataTable ObtenerClientesID(int cliente)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("BuscCliente", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCliente", cliente);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                // Log o mensaje si deseas
                MessageBox.Show("Error al obtener Clientes: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable ObtenerClientes(string Busqueda,string filtrar)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("BuscarPorTipo", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Filtro", filtrar);
                comando.Parameters.AddWithValue("@Busqueda", Busqueda);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                // Log o mensaje si deseas
                MessageBox.Show("Error al obtener Clientes: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        // obtener ciudades disponibles
        public DataTable ObtenerCiudadesDisponibles()
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("VerCiu", _conexion);
                comando.CommandType = CommandType.StoredProcedure;

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

        public DataTable ObtenerHotelesPorCiudad(int idCiudad)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("VerHotelesCiudad", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCiudad", idCiudad);

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
        public DataTable ObtenerHotelesPorCiudad2(int idCiudad)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("VerHotelesCiudad", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCiudad", idCiudad);

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

        public void GenerarFacturaArchivo(Guid idReservacion)
        {
            decimal totalDescuentos = 0;
            decimal anticipo = 0;
            //string File = "";
            decimal iva = 0;
            decimal subtotal = 0;
            decimal totalConIVA =0;
            try
            {
                conectar();

                using (SqlCommand comando = new SqlCommand("GenerarDatosFactura", _conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdReservacion", idReservacion);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        // Primer resultado: datos generales
                        string contenido = "";
                        if (reader.Read())
                        {
                            string idFactura = reader["IdFactura"].ToString();
                            string nombreHotel = reader["Nombre_Hotel"].ToString();
                            
                            string cliente = reader["NombreCliente"].ToString();
                            string correo = reader["Correo"].ToString();
                            string tel = reader["TelCel"].ToString();
                            string fechaEmision = Convert.ToDateTime(reader["FechaFactura"]).ToString("yyyy-MM-dd");
                            string fechaIni = Convert.ToDateTime(reader["Fecha_Ini"]).ToString("yyyy-MM-dd");
                            string fechaFin = Convert.ToDateTime(reader["Fecha_Fin"]).ToString("yyyy-MM-dd");
                            anticipo = Convert.ToDecimal(reader["Anticipo"]);
                            decimal totalHospedaje = Convert.ToDecimal(reader["TotalHospedaje"]);
                            decimal totalServicios = Convert.ToDecimal(reader["TotalServicios"]);
                            
                            decimal totalFinal = Convert.ToDecimal(reader["TotalFinal"]);
                            subtotal= totalHospedaje + totalServicios;
                           iva= subtotal * 0.16m;
                             totalConIVA = totalFinal + iva;

                            contenido += $"Factura No.: {idFactura}\n{nombreHotel}\\n\n";
                            contenido += $"Fecha de emisión: {fechaEmision}\n";
                            contenido += $"Código de reservación: {idReservacion}\n";
                            contenido += $"Cliente: {cliente}\nTeléfono: {tel}\nCorreo: {correo}\n\n";
                            contenido += "Cantidad  Descripción                         Precio Unitario     Total\n";
                            contenido += "---------------------------------------------------------------------------\n";
                        }

                        // Segundo resultado: habitaciones reservadas
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                int cantidad = Convert.ToInt32(reader["CantHuespedes"]);
                                string nivel = reader["Nivel"].ToString();
                                string tipoCama = reader["Tipo_Camas"].ToString();
                                decimal precio = Convert.ToDecimal(reader["PrecioUnitario"]);
                                decimal total = Convert.ToDecimal(reader["TotalHabitacion"]);

                                contenido += $"{cantidad}         Hospedaje ({nivel} - {tipoCama})       ${precio}            ${total}\n";
                            }
                        }

                        // Tercer resultado: servicios utilizados
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                int cantidad = Convert.ToInt32(reader["CantidadUtilizada"]);
                                string nombre = reader["Nombre"].ToString();
                                decimal precio = Convert.ToDecimal(reader["Costo"]);
                                 subtotal = Convert.ToDecimal(reader["Subtotal"]);

                                contenido += $"{cantidad}         {nombre}                       ${precio}            ${subtotal}\n";
                            }
                        }

                        // Cuarto resultado: descuentos
                        if (reader.NextResult())
                        {
                            contenido += "\nDescuentos aplicados:\n";
                            while (reader.Read())
                            {
                                string nombre = reader["NombreDescuento"].ToString();
                                decimal valor = Convert.ToDecimal(reader["Valor"]);
                                bool esPorcentaje = Convert.ToBoolean(reader["EsPorcentaje"]);
                                string tipo = reader["TipoDescuento"].ToString();

                                contenido += $"- {nombre} ({(esPorcentaje ? valor + "%" : "$" + valor)}) sobre {tipo}\n";
                            }
                        }

                        // Totales
                        contenido += "\n";
                        contenido += $"Subtotal:                                   ${subtotal}\n";
                        contenido += $"Descuentos:                                 -${totalDescuentos}\n";
                        contenido += $"Anticipo:                                   -${anticipo}\n";
                        contenido += $"IVA (16%):                                  ${iva}\n";
                        contenido += $"Total a pagar:                              ${totalConIVA}\n";
                        contenido += "\nGracias por su preferencia.\n";

                        // Guardar archivo
                        string ruta = $"Factura_{idReservacion}.txt";

                        File.WriteAllText(ruta, contenido);

                        MessageBox.Show($"Factura generada correctamente en el archivo:\n{ruta}", "Factura generada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }
        }

        public DataTable ObtenerHabitacionesLibres(int idHotel,DateTime fecha_ini, DateTime fecha_fin)
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerHabitacionesDisponiblesPorFecha", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdHotel",idHotel);
                comando.Parameters.AddWithValue("@FechaIni", fecha_ini);
                comando.Parameters.AddWithValue("@FechaFin", fecha_fin);
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


        public string RegistrarReservacion(int idCliente, DateTime fechaIni, DateTime fechaFin, decimal pagoRes, List<HabitacionSeleccionada> habitaciones)
        {
            try
            {
                conectar();

                SqlCommand comando = new SqlCommand("RegistrarReservacionConMultiplesHabitaciones", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCliente", idCliente);
                comando.Parameters.AddWithValue("@FechaIni", fechaIni);
                comando.Parameters.AddWithValue("@FechaFin", fechaFin);
                comando.Parameters.AddWithValue("@PagoRes", pagoRes);
                comando.Parameters.AddWithValue("@IdUsuario", Estructuras.SesionUsuario.IdUsuario);

                // Crear DataTable que coincida con HabitacionReservadaTVP
                DataTable tablaHabitaciones = new DataTable();
                tablaHabitaciones.Columns.Add("IdHotel", typeof(int));
                tablaHabitaciones.Columns.Add("Numero_Habitacion", typeof(int));
                tablaHabitaciones.Columns.Add("CantHuespedes", typeof(int));
                tablaHabitaciones.Columns.Add("IdTipo", typeof(int));
                tablaHabitaciones.Columns.Add("PrecioUnitario", typeof(decimal));

                // Llenar DataTable con habitaciones seleccionadas
                foreach (var h in habitaciones)
                {
                    tablaHabitaciones.Rows.Add(h.IdHotel, h.NumeroHabitacion, h.CantHuespedes, h.IdTipo, h.PrecioUnitario);
                }

                // Pasar DataTable como parámetro de tipo tabla (`TVP`)
                SqlParameter paramTVP = comando.Parameters.AddWithValue("@Habitaciones", tablaHabitaciones);
                paramTVP.SqlDbType = SqlDbType.Structured;
                paramTVP.TypeName = "dbo.HabitacionReservadaTVP"; // Asegúrate de que el nombre coincida en SQL Server

                // **Corrección aquí: Definir parámetro de salida**
                SqlParameter paramIdReservacion = new SqlParameter("@CodigoReservacion", SqlDbType.UniqueIdentifier);
                paramIdReservacion.Direction = ParameterDirection.Output;
                comando.Parameters.Add(paramIdReservacion);

                comando.ExecuteNonQuery();

                return paramIdReservacion.Value.ToString(); // Devuelve el GUID correctamente
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
            finally
            {
                desconectar();
            }
        }

        public int GuardarFactura(Guid idReservacion, decimal totalHospedaje, decimal totalServicios, decimal totalFinal)
        {
            int idFactura = 0;

            try
            {
                conectar();

                using (SqlCommand comando = new SqlCommand("GenerarFactura", _conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdReservacion", idReservacion);
                    comando.Parameters.AddWithValue("@TotalHospedaje", totalHospedaje);
                    comando.Parameters.AddWithValue("@TotalServicios", totalServicios);
                    //comando.Parameters.AddWithValue("@TotalFinal", totalFinal);

                    idFactura = Convert.ToInt32(comando.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }

            return idFactura;
        }




        public int HacerReservacion(int idCliente, int idHotel, DateTime fechaIni, DateTime fechaFin)
        {
            int idReservacion = -1;

            try
            {
                conectar();

                SqlCommand cmd = new SqlCommand("HacerReservacion", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                //cmd.Parameters.AddWithValue("@IdHotel", idHotel);
                cmd.Parameters.AddWithValue("@FechaIni", fechaIni.Date);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin.Date);

                SqlParameter outputParam = new SqlParameter("@IdReservacion", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                cmd.ExecuteNonQuery();
                idReservacion = Convert.ToInt32(outputParam.Value);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al hacer la reservación: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return idReservacion;
        }

        public void InsertarHabitacionesReservadas(int idReservacion, List<Estructuras.HabitacionSeleccionada> habitaciones)
        {
            try
            {
                conectar();

                foreach (var h in habitaciones)
                {
                    SqlCommand cmd = new SqlCommand("InsertarHabitacionReservada", _conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdReservacion", idReservacion);
                    cmd.Parameters.AddWithValue("@IdHotel", h.IdHotel);
                    cmd.Parameters.AddWithValue("@NumeroHabitacion", h.NumeroHabitacion);
                    cmd.Parameters.AddWithValue("@CantHuespedes", h.CantHuespedes);
                    cmd.Parameters.AddWithValue("@IdTipo", h.IdTipo);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", h.PrecioUnitario);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar habitaciones reservadas: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void VerificarFechaReservacion()
        {
            try
            {
                conectar();

                
                
                    SqlCommand cmd = new SqlCommand("ProcesarCancelacionReservacionesVencidas", _conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al verificar reservaciones vencidas " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }
        public DataTable ObtenerReservacionesFiltradas(string codigoReservacion)
        {
            DataTable tablaResultados = new DataTable();

            try
            {
                conectar(); // Asegurar conexión antes de ejecutar el procedimiento

                using (SqlCommand comando = new SqlCommand("BuscarReservacionesPorCodigo", _conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodigoReservacion", codigoReservacion);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                    {
                        adapter.Fill(tablaResultados);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar reservaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar(); // Asegurar que la conexión se cierre correctamente
            }

            return tablaResultados;
        }
        public DataTable ObtenerReservacionesFiltradasE(string codigoReservacion)
        {
            DataTable tablaResultados = new DataTable();

            try
            {
                conectar(); // Asegurar conexión antes de ejecutar el procedimiento

                using (SqlCommand comando = new SqlCommand("BuscarReservacionesPorCodigoE", _conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodigoReservacion", codigoReservacion);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                    {
                        adapter.Fill(tablaResultados);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar reservaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar(); // Asegurar que la conexión se cierre correctamente
            }

            return tablaResultados;
        }
        public DataTable ObtenerReservacionesFiltradas2(string codigoReservacion)
        {
            DataTable tablaResultados = new DataTable();

            try
            {
                conectar(); // Asegurar conexión antes de ejecutar el procedimiento

                using (SqlCommand comando = new SqlCommand("BuscarReservacionesPorCodigoC", _conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodigoReservacion", codigoReservacion);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                    {
                        adapter.Fill(tablaResultados);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar reservaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar(); // Asegurar que la conexión se cierre correctamente
            }

            return tablaResultados;
        }

        public bool ActualizarEstadoReservacion(string idReservacion, string nuevoEstado)
        {
            bool exito = false;

            try
            {
                conectar(); // Asegurar conexión antes de ejecutar el procedimiento

                using (SqlCommand comando = new SqlCommand("ActualizarEstadoReservacion", _conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdReservacion", Guid.Parse(idReservacion));
                    comando.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    exito = filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar(); // Cerrar conexión correctamente
            }

            return exito;
        }


        public DataTable ObtenerHabitacionesReservadas(Guid idReservacion)
        {
            DataTable tablaResultados = new DataTable();

            try
            {
                conectar();

                using (SqlCommand comando = new SqlCommand("ObtenerHabitacionesPorReservacion", _conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdReservacion", idReservacion);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                    {
                        adapter.Fill(tablaResultados);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener habitaciones reservadas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }

            return tablaResultados;
        }
        /************************************* Servicios *********************************/
        public bool InsertarServicios(int idHotel, string nombre, decimal cost)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("InsertarServicio", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Cost", cost);
                comando.Parameters.AddWithValue("@IdHotel", idHotel);
              
              
                int rows = comando.ExecuteNonQuery();
                // si devuelve –1 o >0 → éxito
                exito = (rows != 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar Servicio " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }

        public DataTable ObtenerClientesFormatoRFC()
        {
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerClientesFormatoRFC", _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                // Log o mensaje si deseas
                MessageBox.Show("Error al obtener Clientes: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public bool AgregarServicioAReservacion(Guid idReservacion, int idServicio, int cantidad)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("AgregarServicioAReservacion", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdReservacion", idReservacion);
                comando.Parameters.AddWithValue("@IdServicio", idServicio);
                comando.Parameters.AddWithValue("@CantidadUtilizada", cantidad);


                int rows = comando.ExecuteNonQuery();
                // si devuelve –1 o >0 → éxito
                exito = (rows != 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar Servicio " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }

        public bool InsertarServicioReservacion(Guid idReservacion, int idServicio, int cantidadUtilizada = 1)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("InsertarServicioReservacion", _conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@IdReservacion", idReservacion);
                comando.Parameters.AddWithValue("@IdServicio", idServicio);
                comando.Parameters.AddWithValue("@CantidadUtilizada", cantidadUtilizada);

                int rows = comando.ExecuteNonQuery();
                exito = (rows != 0); // éxito si afectó filas
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar Servicio en Reservación: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }

        public DataTable ObtenerServiciosPorHotel(int idHotel)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerServiciosPorHotel", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdHotel", idHotel);

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener servicios del hotel: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable ObtenerServiciosReservados(Guid idReservacion)
        {
            DataTable tablaResultados = new DataTable();

            try
            {
                conectar();

                using (SqlCommand comando = new SqlCommand("ObtenerServiciosPorReservacion", _conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdReservacion", idReservacion);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                    {
                        adapter.Fill(tablaResultados);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener servicios reservados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }

            return tablaResultados;
        }

        /* ******************************************** Amenidades *****************************************************/

        public DataTable ObtenerAmenidadesPorTipo(int idTipo)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("ObtenerAmenidadesHabilitadas", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdTipo", idTipo);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener las amenidades: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public bool InsertarAmenidad(int idTipo, String nombre)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("InsertarAmenidadTipoHabitacion", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@IdTipo", idTipo);
                int filas = comando.ExecuteNonQuery();
                exito = (filas > 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar amenidad: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }
        public bool DeshabilitarAmenidad(int idAmenidad)
        {
            bool exito = false;
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("DeshabilitarAmenidad", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdAmenidad", idAmenidad);

                int filas = comando.ExecuteNonQuery();
                exito = (filas > 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al deshabilitar amenidad: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return exito;
        }
        public int InsertarPais(string nombre)
        {
            int idPais = 0;

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("InsertarPais", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);

                SqlParameter outputId = new SqlParameter("@IdPais", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                comando.Parameters.Add(outputId);

                comando.ExecuteNonQuery();
                idPais = Convert.ToInt32(outputId.Value);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar país: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return idPais;
        }
        public int InsertarEstado(string nombre, int idPais)
        {
            int idEstado = 0;

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("InsertarEstado", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@IdPais", idPais);

                SqlParameter outputId = new SqlParameter("@IdEstado", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                comando.Parameters.Add(outputId);

                comando.ExecuteNonQuery();
                idEstado = Convert.ToInt32(outputId.Value);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar estado: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return idEstado;
        }

        public int InsertarCiudad(string nombre, int idEstado)
        {
            int idCiudad = 0;

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("InsertarCiudad", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@IdEstado", idEstado);

                SqlParameter outputId = new SqlParameter("@IdCiudad", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                comando.Parameters.Add(outputId);

                comando.ExecuteNonQuery();
                idCiudad = Convert.ToInt32(outputId.Value);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar ciudad: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return idCiudad;
        }
        public int InsertarMunicipio(string nombre, int idCiudad)
        {
            int idMunicipio = 0;

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("InsertarMunicipio", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@IdCiudad", idCiudad);

                SqlParameter outputId = new SqlParameter("@IdMunicipio", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                comando.Parameters.Add(outputId);

                comando.ExecuteNonQuery();
                idMunicipio = Convert.ToInt32(outputId.Value);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar municipio: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return idMunicipio;
        }
        public int InsertarColonia(string nombre, int idMunicipio)
        {
            int idColonia = 0;

            try
            {
                conectar();
                SqlCommand comando = new SqlCommand("InsertarColonia", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@IdMunicipio", idMunicipio);

                SqlParameter outputId = new SqlParameter("@IdColonia", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                comando.Parameters.Add(outputId);

                comando.ExecuteNonQuery();
                idColonia = Convert.ToInt32(outputId.Value);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar colonia: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return idColonia;
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
