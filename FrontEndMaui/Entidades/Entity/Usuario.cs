using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndMaui.Entidades
{
    public class Usuario
    {
        public Int64 Id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string correoElectronico { get; set; }
        public string password { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
