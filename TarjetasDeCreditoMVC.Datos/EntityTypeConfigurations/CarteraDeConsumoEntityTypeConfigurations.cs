using System.Data.Entity.ModelConfiguration;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.EntityTypeConfigurations
{
    public class CarteraDeConsumoEntityTypeConfigurations : EntityTypeConfiguration<CarteraDeConsumo>
    {
        public CarteraDeConsumoEntityTypeConfigurations()
        {
            ToTable("CarterasDeConsumos");
        }
    }
}
