using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Tarjetas;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioTarjeta
    {
        List<TarjetaListDto> GetLista(string cliente, string carteraDeConsumo);
        bool Existe(Tarjeta tarjeta);
        void Guardar(Tarjeta tarjeta);
        TarjetaEditDto GetTarjetaPorId(int? id);
        void Borrar(int cartClienVmTarjetaId);
    }
}
