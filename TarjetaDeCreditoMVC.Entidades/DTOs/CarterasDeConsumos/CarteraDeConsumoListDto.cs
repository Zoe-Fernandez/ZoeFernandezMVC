using System;

namespace TarjetaDeCreditoMVC.Entidades.DTOs.CarterasDeConsumos
{
    public class CarteraDeConsumoListDto: ICloneable
    {
        public int CarteraDeConsumoId { get; set; }
        public string Descripcion { get; set; }
        public decimal LimiteDeCredito { get; set; }
        public decimal CostoDeRenovacion { get; set; }
        public string Imagen { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
