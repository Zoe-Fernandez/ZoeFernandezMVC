using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Localidad;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Comercio
{
    public class ComercioEditViewModel
    {
        public int ComercioId { get; set; }

        [Display(Name = "Razon social")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string RazonSocial { get; set; }

        [Display(Name = "Persona de contacto")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(120, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string PersonaDeContacto { get; set; }

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
        [StringLength(20, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string CorreoElectronico { get; set; }
        public List<ProvinciaListViewModel> Provincias { get; set; }
        public List<LocalidadListViewModel> Localidades { get; set; }


    }
}
