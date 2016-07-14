using System.Reflection;
using System.ServiceModel;

namespace Sample.Presentation.Web
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.Wcf;
    using Components.SvcRefLib.Core.Core;

    public static class Bootstrapper
    {
        static readonly ContainerBuilder Builder;
        static IContainer _container;
        static bool _isContainerAlive;

        static Bootstrapper()
        {
            Builder = new ContainerBuilder();
            Initialize();
        }

        private static void Initialize()
        {
            Builder.RegisterControllers(Assembly.GetExecutingAssembly());
            RegisterWcfServices();
        }

        public static IContainer GetIOCContainer()
        {
            if (!_isContainerAlive)
                BuildContainer();

            return _container;
        }

        public static void DisposeContainer()
        {
            if (_container == null) return;
            _container.Dispose();
            _isContainerAlive = false;
        }

        static void BuildContainer()
        {
            _container = Builder.Build();
            _isContainerAlive = true;
        }

        /// <summary>
        /// Method to register wcf services
        /// </summary>
        static void RegisterWcfServices()
        {
            Builder.RegisterControllers(Assembly.GetExecutingAssembly());

            #region WCF Services
            //1. Authentication service
            Builder.Register(c => new ChannelFactory<ICoreService>("WSHttpBinding_ICoreService")).SingleInstance();
            Builder.Register(c => c.Resolve<ChannelFactory<ICoreService>>().CreateChannel()).UseWcfSafeRelease();
            #endregion
        }
    }
}