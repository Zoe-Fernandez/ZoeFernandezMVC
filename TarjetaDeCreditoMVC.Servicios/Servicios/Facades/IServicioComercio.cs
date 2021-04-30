using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Comercios;

namespace TarjetaDeCreditoMVC.Servicios.Servicios.Facades
{
    public interface IServicioComercio
    {
        List<ComercioListDto> GetLista(string provincia, string localidad);
        bool Existe(ComercioEditDto comercioEditDto);
        void Guardar(ComercioEditDto comercioDto);
        ComercioEditDto GetComercioPorId(int? id);
        void Borrar(int provLocVmComercioId);
    }
}
