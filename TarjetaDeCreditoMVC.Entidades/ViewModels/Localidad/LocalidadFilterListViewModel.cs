using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Localidad
{
    public class LocalidadFilterListViewModel
    {
        public List<LocalidadListViewModel> Localidades { get; set; }
        public List<ProvinciaListViewModel> Provincias { get; set; }
    }
}
