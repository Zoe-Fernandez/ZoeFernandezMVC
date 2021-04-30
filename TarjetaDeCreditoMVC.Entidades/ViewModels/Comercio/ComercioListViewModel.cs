using System.ComponentModel.DataAnnotations;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Comercio
{
    public class ComercioListViewModel
    {
        public int ComercioId { get; set; }

        [Display(Name = "Razon social")]
        public string RazonSocial { get; set; }

        [Display(Name = "Persona de contacto")]
        public string PersonaDeContacto { get; set; }
        public string Direccion { get; set; }

        [Display(Name = "Nombre de la localidad")]
        public string Localidad { get; set; }

        [Display(Name = "Nombre de la provincia")]
        public string Provincia { get; set; }

        [Display(Name = "Telefono fijo")]
        public string TelefonoFijo { get; set; }

        [Display(Name = "Telefono movil")]
        public string TelefonoMovil { get; set; }

        [Display(Name = "Correo electronico")]
        public string CorreoElectronico { get; set; }
    }
}
