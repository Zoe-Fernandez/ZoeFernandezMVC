using System.Data.Entity.ModelConfiguration;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.EntityTypeConfigurations
{
    public class ProvinciaEntityTypeConfigurations:EntityTypeConfiguration<Provincia>
    {
        public ProvinciaEntityTypeConfigurations()
        {
            ToTable("Provincias");
        }
    }
}
