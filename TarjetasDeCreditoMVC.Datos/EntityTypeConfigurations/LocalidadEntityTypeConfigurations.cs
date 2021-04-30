using System.Data.Entity.ModelConfiguration;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.EntityTypeConfigurations
{
    public class LocalidadEntityTypeConfigurations:EntityTypeConfiguration<Localidad>
    {
        public LocalidadEntityTypeConfigurations()
        {
            ToTable("Localidades");
        }
    }
}
