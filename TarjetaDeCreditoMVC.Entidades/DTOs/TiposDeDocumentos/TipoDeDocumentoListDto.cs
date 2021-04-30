using System;

namespace TarjetaDeCreditoMVC.Entidades.DTOs.TiposDeDocumentos
{
    public class TipoDeDocumentoListDto:ICloneable
    {
        public int TipoDeDocumentoId { get; set; }
        public string Descripcion { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
