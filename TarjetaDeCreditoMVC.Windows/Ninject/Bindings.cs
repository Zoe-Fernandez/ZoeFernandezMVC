using Ninject.Modules;
using TarjetaDeCreditoMVC.Servicios.Servicios;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Datos;
using TarjetaDeCreditoMVC.Datos.Repositorios;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Datos.UnitOfWork;

namespace TarjetaDeCreditoMVC.Windows.Ninject
{
    public class Bindings: NinjectModule
    {
        public override void Load()
        {
            Bind<TarjetasDeCreditoDbContext>().ToSelf().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            //PROVINCIAS
            Bind<IRepositorioProvincias>().To<RepositorioProvincia>();
            Bind<IServicioProvincia>().To<ServicioProvincia>();

            //TIPOS DE DOCUMENTOS
            Bind<IRepositorioTiposDeDocumentos>().To<RepositorioTiposDeDocumento>();
            Bind<IServicioTipoDeDocumento>().To<ServicioTipoDeDocumento>();

            //CARTERAS DE CONSUMOS
            Bind<IRepositorioCarterasDeConsumos>().To<RepositorioCarteraDeConsumo>();
            Bind<IServicioCarteraDeConsumo>().To<ServicioCarteraDeConsumo>();

            //LOCALIDADES
            Bind<IRepositorioLocalidades>().To<RepositorioLocalidad>();
            Bind<IServicioLocalidad>().To<ServicioLocalidad>();

            //COMERCIOS
            Bind<IRepositorioComercio>().To<RepositorioComercio>();
            Bind<IServicioComercio>().To<ServicioComercio>();

            //CLIENTES
            Bind<IRepositorioCliente>().To<RepositorioCliente>();
            Bind<IServicioCliente>().To<ServicioCliente>();

            //TARJETAS
            Bind<IRepositorioTarjeta>().To<RepositorioTarjeta>();
            Bind<IServicioTarjeta>().To<ServicioTarjeta>();

        }
    }
}
