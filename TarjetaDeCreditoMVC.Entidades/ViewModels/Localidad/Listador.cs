using System.Collections.Generic;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Localidad
{
    public class Listador<T> : PaginadorGenerico where T : class
    {
        public IEnumerable<T> Registros { get; set; }
    }
}
