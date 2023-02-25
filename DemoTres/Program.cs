using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTres
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        static void Main(string[] args)
        {
            //log.Info("Esto es una informacion");
            //log.Error("Esto es un error");
            //log.Fatal("Esto es un error mas critico");
            //log.Debug("Esto es un mensaje de depuracion");

            EventLog log1 = new EventLog();
            log1.Source = "Application";
            log1.WriteEntry("Prueba", EventLogEntryType.Information);
        }
    }
}
