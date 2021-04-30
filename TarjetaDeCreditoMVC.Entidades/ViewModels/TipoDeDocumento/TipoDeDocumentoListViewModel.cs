using System.ComponentModel.DataAnnotations;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.TipoDeDocumento
{
    public class TipoDeDocumentoListViewModel
    {
        public int TipoDeDocumentoId { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }
}
