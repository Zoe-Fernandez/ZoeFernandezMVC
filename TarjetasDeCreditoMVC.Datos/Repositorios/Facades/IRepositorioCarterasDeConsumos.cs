using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarterasDeConsumos;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioCarterasDeConsumos
    {
        List<CarteraDeConsumoListDto> GetLista();
        CarteraDeConsumoEditDto GetCarteraDeConsumoId(int? id);
        void Guardar(CarteraDeConsumo carteraDeConsumo);
        void Borrar(int? id);
        bool Existe(CarteraDeConsumo carteraDeConsumo);
    }
}
