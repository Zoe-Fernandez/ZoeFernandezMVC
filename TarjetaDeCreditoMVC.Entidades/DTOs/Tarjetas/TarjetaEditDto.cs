namespace TarjetaDeCreditoMVC.Entidades.DTOs.Tarjetas
{
    public class TarjetaEditDto
    {
        public int TarjetaId { get; set; }
        public string NumeroDeTarjeta { get; set; }
        public int CarteraDeConsumoId { get; set; }
        public int ClienteId { get; set; }
        public string ValidaDesde { get; set; }
        public string ValidaHasta { get; set; }
        public bool Vigente { get; set; }
    }
}
