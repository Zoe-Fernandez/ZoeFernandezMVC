using System.ComponentModel.DataAnnotations;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.TipoDeDocumento
{
    public class TipoDeDocumentoEditViewModel
    {
        public int TipoDeDocumentoId { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(30, ErrorMessage ="El campo {0} debe tener entre {2} y {1} caracteres",MinimumLength =2 )]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }
}
