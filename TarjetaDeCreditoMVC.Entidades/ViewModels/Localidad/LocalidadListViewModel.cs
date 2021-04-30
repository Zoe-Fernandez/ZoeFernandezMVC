using System.ComponentModel.DataAnnotations;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Localidad
{
    public class LocalidadListViewModel
    {
        public int LocalidadId { get; set; }

        [Display(Name = "Nombre de la localidad")]
        public string NombreLocalidad { get; set; }

        [Display(Name = "Nombre de la provincia")]
        public string Provincia { get; set; }

        [Display(Name = " Cantidad de clientes")]
        public int CantidadClientes { get; set; }

        [Display(Name = " Cantidad de comercios")]
        public int CantidadComercios { get; set; }
    }
}
