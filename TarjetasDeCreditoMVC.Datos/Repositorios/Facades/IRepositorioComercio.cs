using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Comercios;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioComercio
    {
        List<ComercioListDto> GetComercio(string provincia, string localidad);
        bool Existe(Comercio comercio);
        void Guardar(Comercio comercio);
        ComercioEditDto GetComercioPorId(int? id);
        void Borrar(int provLocVmComercioId);
    }
}
