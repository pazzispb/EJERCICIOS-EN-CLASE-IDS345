using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DemoCinco
{
    public partial class Service1 : ServiceBase
    {
        Timer timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = int.Parse(ConfigurationManager.AppSettings["INTERVALO"]) * 1000;
            timer.Start();
            fswMonitor.Path = ConfigurationManager.AppSettings["RUTALECTOR"];
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["RUTALOG"].ToString(), true);
            sw.WriteLine(DateTime.Now.ToLongTimeString());
            sw.Flush();
            sw.Close();
        }

        protected override void OnStop()
        {
        }

        private void fswMonitor_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["RUTALOG"].ToString(), true);
            sw.WriteLine(e.Name + "> creado");
            sw.Flush();
            sw.Close();
        }

        private void fswMonitor_Changed(object sender, FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["RUTALOG"].ToString(), true);
            sw.WriteLine(e.Name + "> modificado");
            sw.Flush();
            sw.Close();
        }

        private void fswMonitor_Deleted(object sender, FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["RUTALOG"].ToString(), true);
            sw.WriteLine(e.Name + "> eliminado");
            sw.Flush();
            sw.Close();
        }

        private void fswMonitor_Renamed(object sender, RenamedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["RUTALOG"].ToString(), true);
            sw.WriteLine(e.Name + "> renombrado > " + e.OldName);
            sw.Flush(); //para escribir
            sw.Close();
        }
    }
}
