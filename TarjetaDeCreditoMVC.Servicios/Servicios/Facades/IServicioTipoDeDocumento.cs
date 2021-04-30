using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.TiposDeDocumentos;

namespace TarjetaDeCreditoMVC.Servicios.Servicios.Facades
{
    public interface IServicioTipoDeDocumento
    {
        List<TipoDeDocumentoListDto> GetTipoDeDocumentos();
        TipoDeDocumentoEditDto GetTipoDeDocumentoId(int? id);
        void Guardar(TipoDeDocumentoEditDto tipoDeDocumentoDto);
        void Borrar(int? id);
        bool Existe(TipoDeDocumentoEditDto tipoDeDocumentoDto);
    }
}
