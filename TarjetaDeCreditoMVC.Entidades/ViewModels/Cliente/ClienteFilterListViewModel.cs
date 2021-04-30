using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Cliente
{
    public class ClienteFilterListViewModel
    {
        public List<ClienteListViewModel> Clientes { get; set; }
        public List<ProvinciaListViewModel> Provincias { get; set; }
    }
}
