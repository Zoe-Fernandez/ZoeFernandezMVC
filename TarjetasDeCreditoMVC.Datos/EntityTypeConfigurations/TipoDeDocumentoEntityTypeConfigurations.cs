using System.Data.Entity.ModelConfiguration;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.EntityTypeConfigurations
{
    public class TipoDeDocumentoEntityTypeConfigurations : EntityTypeConfiguration<TipoDeDocumento>
    {
        public TipoDeDocumentoEntityTypeConfigurations()
        {
            ToTable("TiposDeDocumentos");
        }
    }
}
