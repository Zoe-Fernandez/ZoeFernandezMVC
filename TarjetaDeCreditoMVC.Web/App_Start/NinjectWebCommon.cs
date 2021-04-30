using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using TarjetaDeCreditoMVC.Servicios.Servicios;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Datos;
using TarjetaDeCreditoMVC.Datos.Repositorios;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Datos.UnitOfWork;
using TarjetaDeCreditoMVC.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace TarjetaDeCreditoMVC.Web
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IServicioProvincia>().To<ServicioProvincia>().InRequestScope();
            kernel.Bind<IRepositorioProvincias>().To<RepositorioProvincia>().InRequestScope();

            kernel.Bind<IServicioTipoDeDocumento>().To<ServicioTipoDeDocumento>().InRequestScope();
            kernel.Bind<IRepositorioTiposDeDocumentos>().To<RepositorioTiposDeDocumento>().InRequestScope();

            kernel.Bind<IServicioCarteraDeConsumo>().To<ServicioCarteraDeConsumo>().InRequestScope();
            kernel.Bind<IRepositorioCarterasDeConsumos>().To<RepositorioCarteraDeConsumo>().InRequestScope();

            kernel.Bind<IServicioLocalidad>().To<ServicioLocalidad>().InRequestScope();
            kernel.Bind<IRepositorioLocalidades>().To<RepositorioLocalidad>().InRequestScope();

            kernel.Bind<IServicioComercio>().To<ServicioComercio>().InRequestScope();
            kernel.Bind<IRepositorioComercio>().To<RepositorioComercio>().InRequestScope();

            kernel.Bind<IServicioCliente>().To<ServicioCliente>().InRequestScope();
            kernel.Bind<IRepositorioCliente>().To<RepositorioCliente>().InRequestScope();

            kernel.Bind<IServicioTarjeta>().To<ServicioTarjeta>().InRequestScope();
            kernel.Bind<IRepositorioTarjeta>().To<RepositorioTarjeta>().InRequestScope();


            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind(typeof(TarjetasDeCreditoDbContext)).ToSelf().InSingletonScope();

        }
    }
}