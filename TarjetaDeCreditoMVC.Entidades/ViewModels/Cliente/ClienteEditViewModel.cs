using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Localidad;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia;
using TarjetaDeCreditoMVC.Entidades.ViewModels.TipoDeDocumento;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Cliente
{
    public class ClienteEditViewModel
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de documento")]
        public int TipoDeDocumentoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(10, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Numero de documento")]
        public string NumeroDeDocumento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre de la localidad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una localidad")]
        public int LocalidadId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre de la provincia")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una provincia")]
        public int ProvinciaId { get; set; }

        [Display(Name = "Telefono fijo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(20, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string TelefonoFijo { get; set; }

        [Display(Name = "Telefono movil")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(20, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string TelefonoMovil { get; set; }

        [Display(Name = "Correo electronico")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(150, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaDeNacimiento { get; set; }
        public bool Suspendido { get; set; }
        public List<TipoDeDocumentoListViewModel> TiposDeDocumentos { get; set; }
        public List<LocalidadListViewModel> Localidades { get; set; }
        public List<ProvinciaListViewModel> Provincias { get; set; }
    }
}
