using ServicioDeWindows.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioDeWindows
{
    public partial class Service1 : ServiceBase
    {
        private Thread hilo;
        private string directorio = ConfigurationManager.AppSettings["Directorio"];
        private string pathArchivo = ConfigurationManager.AppSettings["PathArchivo"];

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.hilo = new Thread(Iniciado);
            this.hilo.Start();
        }

        protected override void OnStop()
        {
            this.hilo = null;
        }

        public void Iniciado()
        {
            EngineService Funcion = new EngineService();
            Funcion.CrearCarpetaArchivo();
            Funcion.EstablecerConexionSocket(pathArchivo, true);
        }
    }
}
