using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarterasDeConsumos;

namespace TarjetaDeCreditoMVC.Servicios.Servicios.Facades
{
    public interface IServicioCarteraDeConsumo
    {
        List<CarteraDeConsumoListDto> GetLista();
        CarteraDeConsumoEditDto GetCarteraDeConsumoId(int? id);
        void Guardar(CarteraDeConsumoEditDto carteraDeConsumoDto);
        void Borrar(int? id);
        bool Existe(CarteraDeConsumoEditDto carteraDeConsumoDto);
    }
}
