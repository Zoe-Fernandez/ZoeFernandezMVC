using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;

namespace TarjetaDeCreditoMVC.Servicios.Servicios.Facades
{
    public interface IServicioProvincia
    {
        List<ProvinciaListDto> GetProvincias();
        ProvinciaEditDto GetProvinciaId(int? id);
        void Guardar(ProvinciaEditDto provinciaDto);
        void Borrar(int? id);
        bool Existe(ProvinciaEditDto provinciaDto);
    }
}
