using System.ComponentModel.DataAnnotations;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.CarteraDeConsumo
{
    public class CarteraDeConsumoListViewModel
    {
        public int CarteraDeConsumoId { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Limite de credito")]
        public decimal LimiteDeCredito { get; set; }

        [Display(Name = "Costo de renovacion")]
        public decimal CostoDeRenovacion { get; set; }
        public string Imagen { get; set; }
    }
}
