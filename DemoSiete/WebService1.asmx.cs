using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace DemoSiete
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "https://www.intec.edu.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        
        [WebMethod]
        public int Sumar(int n1, int n2)
        {
            return n1 + n2;
        }

        [WebMethod]
        public Respuesta RegistrarCliente(Cliente cliente)
        {
            //TODO: Registra al cliente en la base de datos
            Respuesta respuesta = new Respuesta()
            {
                Codigo = 0,
                Mensaje = "Cliente registrado",
                Tipo = 0
            };
            return respuesta;
        }

    }
}
