using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.ViewModels.CarteraDeConsumo;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Tarjeta
{
    public class TarjetaFilterListViewModel
    {
        public List<TarjetaListViewModel> Tarjetas { get; set; }
        public List<CarteraDeConsumoListViewModel> CarterasDeConsumos { get; set; }
    }
}
