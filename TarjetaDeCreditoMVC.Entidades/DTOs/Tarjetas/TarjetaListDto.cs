using System;

namespace TarjetaDeCreditoMVC.Entidades.DTOs.Tarjetas
{
    public class TarjetaListDto : ICloneable
    {
        public int TarjetaId { get; set; }
        public string NumeroDeTarjeta { get; set; }
        public string CarteraDeConsumo { get; set; }
        public string Cliente { get; set; }
        public string ValidaDesde { get; set; }
        public string ValidaHasta { get; set; }
        public bool Vigente { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
