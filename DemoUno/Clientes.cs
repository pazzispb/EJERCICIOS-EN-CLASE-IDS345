using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUno
{
    internal class Clientes
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Estado { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string Comentario { get; set; }
        public string Sexo { get; set; }
    }
}
