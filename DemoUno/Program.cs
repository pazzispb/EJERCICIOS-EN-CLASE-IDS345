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
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

                SqlTransaction transaction = null;
                conn.Open();

                Clientes obj = new Clientes();
                Console.WriteLine("-----------DATOS DEL CLIENTE------------------");
                Console.Write("Ingrese el tipo de documento del cliente: ");
                obj.TipoDocumento = int.Parse(Console.ReadLine());
                
                Console.Write("Ingrese el documento del cliente: ");
                obj.Documento = Console.ReadLine();
                
                SqlCommand cmd = new SqlCommand("GetCliente",conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoDocumento", obj.TipoDocumento);
                cmd.Parameters.AddWithValue("@Documento", obj.Documento);


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    obj.Nombres = dr["Nombres"].ToString();
                    Console.WriteLine("Nombre del cliente: " + obj.Nombres);

                    obj.Apellidos = dr["Apellidos"].ToString();
                    Console.WriteLine("Apellido del cliente: " + obj.Apellidos);

                    obj.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                    Console.WriteLine("Fecha de nacimiento del cliente: " + obj.FechaNacimiento.ToShortDateString());

                    obj.Estado = (int)dr["Estado"];
                    Console.WriteLine("Estado del cliente: " + obj.Estado);

                    obj.Comentario = dr["Comentario"].ToString();
                    Console.WriteLine("Comentario del cliente: " + obj.Comentario);

                    obj.Sexo = dr["Sexo"].ToString();
                    Console.WriteLine("Sexo del cliente: " + obj.Sexo);

                    obj.Balance = (decimal)dr["Balance"];
                    Console.WriteLine("Balance del cliente: " + obj.Balance);

                }
                else
                {
                    Console.Write("Ingrese el nombre del cliente: ");
                    obj.Nombres = Console.ReadLine();

                    Console.Write("Ingrese el apellido del cliente: ");
                    obj.Apellidos = Console.ReadLine();

                    Console.Write("Ingrese la fecha de nacimiento del cliente: ");
                    obj.FechaNacimiento = DateTime.Parse(Console.ReadLine());

                    Console.Write("Ingrese el estado del cliente: ");
                    obj.Estado = int.Parse(Console.ReadLine());

                    Console.Write("Ingrese el Comentario del cliente: ");
                    obj.Comentario = Console.ReadLine();

                    Console.Write("Ingrese el sexo del cliente: ");
                    obj.Sexo = Console.ReadLine();
                    
                }
                
                dr.Close();
                Console.WriteLine("--------------DATOS DEL MOVIMIENTO-------------------");
                Console.WriteLine("Ingrese el balance del cliente: ");
                obj.Balance = decimal.Parse(Console.ReadLine());

                Movimientos mov = new Movimientos();
                
                Console.WriteLine("DB/CR del movimiento: ");
                mov.DbCredito = Console.ReadLine();
                
                Console.WriteLine("Ingrese el tipo de transaccion del movimiento: ");
                mov.TipoTransaccion = int.Parse(Console.ReadLine());
                
                transaction = conn.BeginTransaction(); //comienzo del happy path
                cmd.Transaction = transaction;

                try
                {
                    cmd.CommandText = "UpsertCliente";

                    cmd.Parameters.Clear();

                    
                    cmd.Parameters.AddWithValue("@Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", obj.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
                    cmd.Parameters.AddWithValue("@Comentario", obj.Comentario);
                    cmd.Parameters.AddWithValue("@TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("@Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("@Balance", obj.Balance);
                    cmd.Parameters.AddWithValue("@TipoTransaccion", mov.TipoTransaccion);

                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    cmd.CommandText = "InsertarMovimiento";
                    cmd.Parameters.AddWithValue("@TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("@Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("@Monto", obj.Balance);
                    cmd.Parameters.AddWithValue("@TipoTransaccion", mov.TipoTransaccion);
                    cmd.Parameters.AddWithValue("@DbCredito", mov.DbCredito);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Comentario);
                    cmd.Parameters.AddWithValue("@Oficina", ConfigurationManager.AppSettings["Oficina"]);

                    cmd.ExecuteNonQuery();
                    transaction.Commit(); //confirmar la transaccion
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback(); //revertir la transaccion
                }

            }

        }
    }
}
