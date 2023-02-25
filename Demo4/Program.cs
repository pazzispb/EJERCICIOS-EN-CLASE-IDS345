using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ejercicio1Entities entity = new Ejercicio1Entities();
            entity.tblClientes.Add(new tblCliente()
            {
                Nombres = "Juan",
                Apellidos = "Perez",
                Sexo = "M",
                FechaIngreso = DateTime.Now,
                TipoDocumento = 1,
                Documento = "1234567",
                Balance = 0,
                FechaNacimiento = DateTime.Now,
                Estado = 1,
                Comentario = "Ninguno"
            });

            entity.SaveChanges();
            entity.tblClientes.ToList().ForEach(x => Console.WriteLine(x.Nombres));
            
        }
    }
}
