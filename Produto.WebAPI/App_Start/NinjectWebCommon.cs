using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Produto.Application;
using Produto.Application.Interface;
using Produto.Domain.Interfaces.Repositories;
using Produto.Domain.Interfaces.Services;
using Produto.Domain.Services;
using Produto.WebAPI.App_Start;
using Produto.Infra.Data.Repositories;
using System;
using System.Web;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace Produto.WebAPI.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Ninject.WebApi.DependencyResolver.NinjectDependencyResolver(kernel);
            RegisterServices(kernel);
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<ICelulaAppService>().To<CelulaAppService>();
            kernel.Bind<ISetorAppService>().To<SetorAppService>();
            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<ICelulaService>().To<CelulaService>();
            kernel.Bind<ISetorService>().To<SetorService>();
            kernel.Bind<IUsuarioService>().To<UsuarioService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<ICelulaRepository>().To<CelulaRepository>();
            kernel.Bind<ISetorRepository>().To<SetorRepository>();
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();

        }
    }
}