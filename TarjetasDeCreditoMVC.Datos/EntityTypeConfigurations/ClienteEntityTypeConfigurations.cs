using System.Data.Entity.ModelConfiguration;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetasDeCreditoMVC.Datos.EntityTypeConfigurations
{
    public class ClienteEntityTypeConfigurations : EntityTypeConfiguration<Cliente>
    {
        public ClienteEntityTypeConfigurations()
        {
            ToTable("Clientes");
        }
    }
}
