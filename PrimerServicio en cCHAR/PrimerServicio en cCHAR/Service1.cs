using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.IO;

namespace PrimerServicio_en_cCHAR
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        public System.Timers.Timer TimerServicio = new System.Timers.Timer();

        protected override void OnStart(string[] args)
        {
            // Agregue el código aquí para iniciar el servicio. Este método debería poner
            // en movimiento los elementos para que el servicio pueda funcionar.        
            TimerServicio = new System.Timers.Timer();
            TimerServicio.Elapsed += (_, __) => EjecutaUnaAccion();
            TimerServicio.Interval = 1000;
            TimerServicio.Start();
        }

        public void EjecutaUnaAccion()
        {
            int i;
            for (i = 1; i <= 1000; i++)
                File.AppendAllText(@"C:\INFORME.TXT", "LINEA: " + i + System.Environment.NewLine);
            
        }

        protected override void OnStop()
        {
            // Agregue el código aquí para realizar cualquier anulación necesaria para detener el servicio.
            TimerServicio.Close();
        }
        protected override void OnPause()
        {
            TimerServicio.Stop();
        }

        protected override void OnContinue()
        {
            TimerServicio.Start();
        }
    }
}
