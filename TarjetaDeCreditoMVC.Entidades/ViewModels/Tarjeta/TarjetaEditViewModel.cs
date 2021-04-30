using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TarjetaDeCreditoMVC.Entidades.ViewModels.CarteraDeConsumo;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Cliente;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Tarjeta
{
    public class TarjetaEditViewModel
    {
        public int TarjetaId { get; set; }

        [Display(Name = "Numero de tarjeta")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(16, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string NumeroDeTarjeta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Cartera de consumo")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una cartera de consumo")]
        public int CarteraDeConsumoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre y Apellido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Valida desde")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(4, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        public string ValidaDesde { get; set; }

        [Display(Name = "Valida hasta")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(4, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        public string ValidaHasta { get; set; }
        public bool Vigente { get; set; }

        public List<ClienteListViewModel> Clientes { get; set; }
        public List<CarteraDeConsumoListViewModel> CarteraDeConsumo { get; set; }

    }
}
