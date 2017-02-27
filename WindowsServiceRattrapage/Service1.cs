using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsServiceRattrapage
{
    public partial class Service1 : ServiceBase
    {
        public object Timer1 { get; private set; }

        public Service1()
        {
            InitializeComponent();
            //TIMER
            System.Timers.Timer Timer1 = new System.Timers.Timer(); // Initialisation
            Timer1.Interval = 60000; // 1min = 60000ms
            Timer1.Elapsed += OnTimedEvent; // Se déclenche chaque minute
            //Timer1.AutoReset = true;
            Timer1.Start();  // Start the timer

            //Console.ReadKey();
            //Console.WriteLine("Press the Enter key to exit the program at any time... ");
            //Console.ReadLine();

            // GC.KeepAlive(Timer1);
        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            //Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            //Console.WriteLine("Coucou at {0}", e.SignalTime);

            String Source = "WindowsServiceCoucou";
            String Log = "Application";
            String Event = "Coucou";

            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, Log);
            }

            EventLog.WriteEntry(Source, Event);
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
