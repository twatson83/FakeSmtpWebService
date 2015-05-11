using System;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace FakeSmtpWebService
{
    class Program
    {
        public static IDisposable WebAppStart { get; set; }

        public class Service : ServiceBase
        {
            public Service()
            {
                ServiceName = "FakeSmtpWebService";
            }

            protected override void OnStart(string[] args)
            {
                Start(args);
            }

            protected override void OnStop()
            {
                Program.Stop();
            }
        }

        static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
                using (var service = new Service())
                    ServiceBase.Run(service);
            else
            {
                Start(args);

                Console.WriteLine();
                Console.WriteLine("Press any key to stop...");
                Console.ReadKey(true);

                Stop();
            }
        }

        private static void Start(string[] args)
        {
            WebAppStart = WebApp.Start<AuditConfig>(System.Configuration.ConfigurationManager.AppSettings["Url"]);
        }

        private static void Stop()
        {
            WebAppStart.Dispose();
        }
    }
}