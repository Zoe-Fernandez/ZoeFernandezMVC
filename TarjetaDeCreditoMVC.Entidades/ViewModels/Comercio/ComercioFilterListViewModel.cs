using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Comercio
{
    public class ComercioFilterListViewModel
    {
        public List<ComercioListViewModel> Comercios { get; set; }
        public List<ProvinciaListViewModel> Provincias { get; set; }
    }
}
