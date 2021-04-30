using System;

namespace TarjetaDeCreditoMVC.Entidades.DTOs.Clientes
{
    public class ClienteListDto : ICloneable
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDeDocumento { get; set; }
        public string NumeroDeDocumento { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public bool Suspendido { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
