using Autofac;

namespace Sample.DistributedServices.Core
{
    using ApplicationServices.Modules.Parser;
    using ApplicationServices.Modules.Receiver;
    using AppService.ParserService.AbstractBase.DataExtractor;
    using AppService.ParserService.AbstractBase.ParserLogic;
    using AppService.ParserService.Google;
    using AppService.ReceiverService.AbstractBase.ReceiverLogic;
    using AppService.ReceiverService.AbstractBase.ReceiverRetriever;
    using AppService.ReceiverService.AbstractBase.ReceiverSource;
    using AppService.ReceiverService.Google;
    using IServices;
    using Services;

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

        /// <summary>
        /// register dependencies 
        /// </summary>
        static void Initialize()
        {
            RegisterWcfServices(); //register wcf services

            RegisterAppServices(); 

            BuildContainer();
        }

        /// <summary>
        /// register wcf services
        /// </summary>
        static void RegisterWcfServices()
        {
            Builder.RegisterType<CoreService>().As<ICoreService>().InstancePerLifetimeScope();
            Builder.RegisterType<CoreService>().AsSelf();
        }
        /// <summary>
        /// register app services
        /// </summary>
        static void RegisterAppServices()
        {
            Builder.RegisterType<ParserAppService>().As<IParserAppService>().InstancePerLifetimeScope();
            Builder.RegisterType<ReceiverAppService>().As<IReceiverAppService>().InstancePerLifetimeScope();
            //For this sample code, I just simply hard coded google as default setting. However, dynamically loading different type of receivers according to configuration can be achieved by implementing Factory, GenericType and XML. To keep it simple and save time, I use Google in denpendency registration directly.
            Builder.RegisterType<GoogleReceiverLogic>().As<IReceiverLogic>().InstancePerLifetimeScope();
            Builder.RegisterType<GoogleReceiverRetriever>().As<IReceiverRetriever>().InstancePerLifetimeScope();
            Builder.RegisterType<GoogleReceiverSource>().As<IReceiverSource>().InstancePerLifetimeScope();

            Builder.RegisterType<LinkPositionParserDataExtractor>().As<IParserDataExtractor>().InstancePerLifetimeScope();
            Builder.RegisterType<LinkPositionParserLogic>().As<IParserLogic>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// return ioc container
        /// </summary>
        /// <returns></returns>
        public static IContainer GetIocContainer()
        {
            if (!_isContainerAlive)
                BuildContainer();

            return _container;
        }

        /// <summary>
        /// build ioc container
        /// </summary>
        static void BuildContainer()
        {
            _container = Builder.Build();
            _isContainerAlive = true;
        }
    }
}
