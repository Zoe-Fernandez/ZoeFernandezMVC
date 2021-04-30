using System.ComponentModel.DataAnnotations;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia
{
    public class ProvinciaEditViewModel
    {
        public int ProvinciaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre de la provincia")]
        public string NombreProvincia { get; set; }
    }
}
