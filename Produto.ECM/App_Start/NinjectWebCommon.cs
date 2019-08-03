using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Produto.ECM.App_Start;
using System;
using System.Web;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace Produto.ECM.App_Start
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

                RegisterServices(kernel);
                return kernel;
            }
            private static void RegisterServices(IKernel kernel)
            {
                //Descontinuado, agora as chamadas são via API
                //kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
                //kernel.Bind<ICelulaService>().To<CelulaService>();
                //kernel.Bind<ISetorService>().To<SetorService>();
                //kernel.Bind<IUsuarioService>().To<UsuarioService>();

        }
    }
}