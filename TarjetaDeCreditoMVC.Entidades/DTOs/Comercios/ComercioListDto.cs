using System;

namespace TarjetaDeCreditoMVC.Entidades.DTOs.Comercios
{
    public class ComercioListDto : ICloneable
    {
        public int ComercioId { get; set; }
        public string RazonSocial { get; set; }
        public string PersonaDeContacto { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
