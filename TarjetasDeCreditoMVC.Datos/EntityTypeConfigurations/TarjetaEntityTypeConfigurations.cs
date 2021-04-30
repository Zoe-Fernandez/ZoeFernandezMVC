using System.Data.Entity.ModelConfiguration;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetasDeCreditoMVC.Datos.EntityTypeConfigurations
{
    public class TarjetaEntityTypeConfigurations : EntityTypeConfiguration<Tarjeta>
    {
        public TarjetaEntityTypeConfigurations()
        {
            ToTable("Tarjetas");
        }
    }
}
