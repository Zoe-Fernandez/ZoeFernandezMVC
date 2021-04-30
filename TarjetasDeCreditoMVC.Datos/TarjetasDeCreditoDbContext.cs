using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos
{
    public class TarjetasDeCreditoDbContext:DbContext
    {
        public TarjetasDeCreditoDbContext():base("MiConexion")
        {
            Database.CommandTimeout = 50;
            Configuration.UseDatabaseNullSemantics = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TarjetasDeCreditoDbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<TipoDeDocumento> TipoDeDocumentos { get; set; }
        public DbSet<CarteraDeConsumo> CarteraDeConsumos { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Comercio> Comercios { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
