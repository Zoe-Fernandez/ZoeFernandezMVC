using System;
using System.ComponentModel.DataAnnotations;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Cliente
{
    public class ClienteListViewModel
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Display(Name = "Tipo de documento")]
        public string TipoDeDocumento { get; set; }

        [Display(Name = "Numero de documento")]
        public string NumeroDeDocumento { get; set; }
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

        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaDeNacimiento { get; set; }
        public bool Suspendido { get; set; }

    }
}
