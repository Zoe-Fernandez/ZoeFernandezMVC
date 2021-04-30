namespace TarjetaDeCreditoMVC.Entidades.Entidades
{
    public class Comercio
    {
        public int ComercioId { get; set; }
        public string RazonSocial { get; set; }
        public string PersonaDeContacto { get; set; }
        public string Direccion { get; set; }
        public int LocalidadId { get; set; }
        public Localidad Localidad { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
