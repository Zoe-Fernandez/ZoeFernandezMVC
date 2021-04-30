namespace TarjetaDeCreditoMVC.Entidades.Entidades
{
    public class Tarjeta
    {
        public int TarjetaId { get; set; }
        public string NumeroDeTarjeta { get; set; }
        public int CarteraDeConsumoId { get; set; }
        public CarteraDeConsumo CarteraDeConsumo { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string ValidaDesde { get; set; }
        public string ValidaHasta { get; set; }
        public bool Vigente { get; set; }

    }
}
