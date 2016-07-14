using System.ServiceModel;
using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace Sample.DistributedServices.Core
{
    using Autofac.Integration.Wcf;
    using Services;


    public class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            try
            {
                using (var container = Bootstrapper.GetIocContainer())
                {
                    var host = new ServiceHost(typeof(CoreService));
                    host.AddDependencyInjectionBehavior<CoreService>(container);
                    host.Open();
                    Console.WriteLine("\n Sample Core Service is running now...");
                    Console.ReadKey();
                    host.Close();
                }
            }
            catch (Exception err)
            {
                EventLog.WriteEntry("Core Service"
                    , string.Format("Encounter an error while starting core service. Error: {0}", err.Message)
                    , EventLogEntryType.Error);
                throw;
            }

#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] { new CoreWindowsService() };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
