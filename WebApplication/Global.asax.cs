﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LightInject;
using SKBKontur.Infrastructure.Common;
using SKBKontur.Infrastructure.ContainerConfiguration;
using System.Linq;
using System.Threading.Tasks;
using SKBKontur.BlocksMapping.Blocks;
using SKBKontur.Treller.WebApplication.Implementation.Infrastructure.Abstractions;
using SKBKontur.Treller.WebApplication.Implementation.Services.Operationals;
using SKBKontur.Treller.WebApplication.Implementation.TaskList.BusinessObjects.Blocks;
using SKBKontur.Treller.WebApplication.Implementation.TaskList.BusinessObjects.ViewModels;
using SKBKontur.Treller.WebApplication.Implementation.VirtualMachines.Runspaces;

namespace SKBKontur.Treller.WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        IVirtualMachinesRunspacePool runspacePool;

        protected void Application_Start()
        {
            var container = new ContainerConfigurator().Configure();
            var serviceContainer = container.Get<IServiceContainer>();
            var assemblyService = container.Get<IAssemblyService>();

            serviceContainer.RegisterControllers(assemblyService.GetLoadedAssemblies().ToArray());
            serviceContainer.EnableMvc();
            
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ReactConfig.Configure();

            BundleTable.EnableOptimizations = false;
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            runspacePool = container.Get<IVirtualMachinesRunspacePool>();
            Task.Factory.StartNew(() => WarmUp(container));
        }

        private static void WarmUp(IContainer container)
        {
            var warmedBlocks = container.Get<IBlocksBuilder>().BuildBlocks(ContextKeys.TasksKey, new[] { typeof(BoardsBlock), typeof(CardListBlock) }, new CardListEnterModel { BoardIds = new string[0], ShowMode = ShowMode.All }).Result;
            container.Get<IOperationalService>().Start();
        }

        protected void Application_End()
        {
            try
            {
                runspacePool.Dispose();
            }
            catch { }
        }
    }
}