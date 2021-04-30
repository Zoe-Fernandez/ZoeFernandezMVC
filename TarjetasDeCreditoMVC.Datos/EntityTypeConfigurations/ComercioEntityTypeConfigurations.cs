using System.Data.Entity.ModelConfiguration;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.EntityTypeConfigurations
{
    public class ComercioEntityTypeConfigurations:EntityTypeConfiguration<Comercio>
    {
        public ComercioEntityTypeConfigurations()
        {
            ToTable("Comercios");
        }
    }
}
