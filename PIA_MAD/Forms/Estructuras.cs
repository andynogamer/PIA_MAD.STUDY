using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Forms
{
    public class Estructuras
    {
            public class HabitacionSeleccionada
            {
                public int IdHotel { get; set; }
                public int NumeroHabitacion { get; set; }
                public int IdTipo { get; set; }
                public int CantHuespedes { get; set; }
                public decimal PrecioUnitario { get; set; } // Precio en el momento de la reservación
            }
        public static class SesionUsuario
        {
            public static int IdUsuario { get; set; }
            public static string Correo { get; set; }
            public static int TipoUsu {  get; set; }  
        }

        public class Usuario
        {
            public int IdUsuario { get; set; }
            public string Nombre_Usu { get; set; }
            public string ApPaterno { get; set; }
            public string ApMaterno { get; set; }
            public string Correo { get; set; }
            public string NNS { get; set; }
            public string FechaNac { get; set; }
            public string Tel_casa { get; set; }
            public string Tel_cel { get; set; }
            public string Pass { get; set; }
            public string Pass2 { get; set; }
            public string Pass3 { get; set; }
            public string Estatus { get; set; }
            public string FechRegis { get; set; }
            public int IdUsu { get; set; }
            public string Fech_act { get; set; }
        }

    }
}
