using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.CarteraDeConsumo
{
    public class CarteraDeConsumoEditViewModel
    {
        public int CarteraDeConsumoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(30, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Limite de credito")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ser un numero decimal")]
        public decimal LimiteDeCredito { get; set; }

        [Display(Name = "Costo de renovacion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ser un numero decimal")]
        public decimal CostoDeRenovacion { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }
        public HttpPostedFileBase ImagenFile { get; set; }

    }
}
