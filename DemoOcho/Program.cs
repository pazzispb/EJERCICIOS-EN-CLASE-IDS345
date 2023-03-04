using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOcho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WS.WebService1SoapClient cliente = new WS.WebService1SoapClient();
            Console.WriteLine(cliente.Sumar(1, 2));

            WS.Cliente obj = new WS.Cliente()
            {
                ID = 1,
                Nombres = "Pazzis Paulino"
            };

            var respuesta = cliente.RegistrarCliente(obj);

            Console.WriteLine($"{respuesta.Mensaje}");
            
        }
    }
}
