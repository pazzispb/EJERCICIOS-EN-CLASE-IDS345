using DemoDos.Demo2DSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DemoDos.Demo2DS;

namespace DemoDos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            tblClientesTableAdapter adapter = new tblClientesTableAdapter();
            //adapter.Insert("Mauricio", "Suarez", DateTime.Now.AddYears(20), "M", DateTime.Now, 1, "NA", 15, "3", 100M);
            tblClientesDataTable clientes = adapter.GetData();
            foreach (var item in clientes)
            {
                Console.WriteLine($"{item.Nombres}, {item.Apellidos}, {item.Balance}");
            }
            SqlTransaction t = null;
            try
            {
                adapter.Connection.Open();
                t = adapter.Connection.BeginTransaction();
                adapter.Transaction = t;
                adapter.UpsertCliente("Mauricio", "Suarez", DateTime.Now.AddYears(20), "M", "NA", 1, "647", 1000M, 1); //Llamada a un stored procedure
                adapter.InsertarMovimiento(1, "647", 1000M, "db", 1, "NA", "Blue Mall");
                t.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                t.Rollback();
            }
        }
    }
}
