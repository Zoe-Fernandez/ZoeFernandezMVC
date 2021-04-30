using System.ComponentModel.DataAnnotations;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Tarjeta
{
    public class TarjetaListViewModel
    {
        public int TarjetaId { get; set; }

        [Display(Name = "Numero de la tarjeta")]
        public string NumeroDeTarjeta { get; set; }

        [Display(Name = "Cartera de consumo")]
        public string CarteraDeConsumo { get; set; }

        [Display(Name = "Numero de documento")]
        public string Cliente { get; set; }

        [Display(Name = "Valida desde")]
        public string ValidaDesde { get; set; }

        [Display(Name = "Valida hasta")]
        public string ValidaHasta { get; set; }
        public bool Vigente { get; set; }
    }
}
