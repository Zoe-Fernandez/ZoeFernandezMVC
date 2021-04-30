using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.TiposDeDocumentos;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioTiposDeDocumentos
    {
        List<TipoDeDocumentoListDto> GetTipoDeDocumentos();
        TipoDeDocumentoEditDto GetTipoDeDocumentoId(int? id);
        void Guardar(TipoDeDocumento tipoDeDocumento);
        void Borrar(int? id);
        bool Existe(TipoDeDocumento tipoDeDocumento);

    }
}
