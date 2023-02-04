using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Clientes obj = new Clientes();
                Console.WriteLine("Ingrese el nombre del cliente: ");
                obj.Nombres = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido del cliente: ");
                obj.Apellidos = Console.ReadLine();
                Console.WriteLine("Ingrese la fecha de nacimiento del cliente: ");
                obj.FechaNacimiento = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el estado del cliente: ");
                obj.Estado = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el Comentario del cliente: ");
                obj.Comentario = Console.ReadLine();
                Console.WriteLine("Ingrese el sexo del cliente: ");
                obj.Sexo = Console.ReadLine();
                
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                conn.Open();
                
                SqlCommand cmd = new SqlCommand($"InsertarCliente", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombres", obj.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", obj.Apellidos);
                cmd.Parameters.AddWithValue("@FechaNacimiento", obj.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
                cmd.Parameters.AddWithValue("@Comentario", obj.Comentario);

                cmd.ExecuteNonQuery();
            }
            
        }
    }
}
