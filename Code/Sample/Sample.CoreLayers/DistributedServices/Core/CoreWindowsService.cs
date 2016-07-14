/// Alex Sun 13/07/2016
using System.ServiceProcess;
using System.ServiceModel;


/// <summary>
/// Core windows service hosts a main wcf service which provides backend service interfaces and data contracts.
/// </summary>
namespace Sample.DistributedServices.Core
{
    using Autofac.Integration.Wcf;
    using Sample.DistributedServices.Core.Services;

    partial class CoreWindowsService : ServiceBase
    {

        public ServiceHost ServiceHost;

        /// <summary>
        /// Method to initialize windows service
        /// </summary>
        public CoreWindowsService()
        {
            InitializeComponent();

            ServiceName = CrossCutting.Common.ConfigObjects.Enums.ServiceName.CoreService.ToString();
        }

        /// <summary>
        /// start up windows service and create Ioc Container to initialize services and related registrations.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            var container = Bootstrapper.GetIocContainer();
            var serviceHost = new ServiceHost(typeof(CoreService));
            serviceHost.AddDependencyInjectionBehavior<CoreService>(container);
            serviceHost.Open();
        }

        /// <summary>
        /// OnStop method
        /// </summary>
        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            if (ServiceHost != null)
            {
                ServiceHost.Close();
                ServiceHost = null;
            }
        }
    }
}
