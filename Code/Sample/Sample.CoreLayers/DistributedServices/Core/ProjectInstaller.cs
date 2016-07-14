using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.ServiceProcess;

/// <summary>
/// This class will install windows service. In this sample projects, WCF is hosted in windows service. Alex Sun 13/07/2016
/// </summary>
namespace Sample.DistributedServices.Core
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        readonly ServiceProcessInstaller _process;
        readonly ServiceInstaller _service;

        public ProjectInstaller()
        {
#if DEBUG
            if (Debugger.IsAttached)
                Debugger.Break();
#endif

            _process = new ServiceProcessInstaller();
            _service = new ServiceInstaller();

            Installers.Add(_process);
            Installers.Add(_service);
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);

            //# Service Information
            _service.ServiceName = Context.Parameters["ServiceName"];
            _service.Description = Context.Parameters["ServiceName"];
            _service.DisplayName = Context.Parameters["ServiceName"];
            _service.StartType = ServiceStartMode.Automatic;
            _service.DelayedAutoStart = true;

            //# Service Account Information
            _process.Account = ServiceAccount.LocalSystem;
        }

        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);

            //# Service Information
            _service.ServiceName = Context.Parameters["ServiceName"];
            _service.Description = Context.Parameters["ServiceName"];
            _service.DisplayName = Context.Parameters["ServiceName"];

            //# Service Account Information
            _process.Account = ServiceAccount.LocalSystem;
        }
    }
}
