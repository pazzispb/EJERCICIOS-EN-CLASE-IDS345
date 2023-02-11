using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUno
{
    internal class Movimientos
    {
        public int Id { get; set; }
        public int TipoDocumento { get; set; }
        public string Documento { get; set; }
        public decimal Monto { get; set; }
        public string DbCredito { get; set; }
        public int TipoTransaccion { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string Descripcion { get; set; }
        
    }
}
