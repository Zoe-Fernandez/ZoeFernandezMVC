using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Tarjetas;

namespace TarjetaDeCreditoMVC.Servicios.Servicios.Facades
{
    public interface IServicioTarjeta
    {
        List<TarjetaListDto> GetLista(string cliente, string carteraDeConsumo);
        bool Existe(TarjetaEditDto tarjetaEditDto);
        void Guardar(TarjetaEditDto tarjetaDto);
        TarjetaEditDto GetTarjetaPorId(int? id);
        void Borrar(int cartClienVmTarjetaId);
    }
}
