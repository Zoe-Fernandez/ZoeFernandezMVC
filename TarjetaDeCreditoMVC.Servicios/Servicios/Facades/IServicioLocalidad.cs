using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Localidades;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;

namespace TarjetaDeCreditoMVC.Servicios.Servicios.Facades
{
    public interface IServicioLocalidad
    {
        List<LocalidadListDto> GetLista(string provincia);
        bool Existe(LocalidadEditDto localidadEditDto);
        void Guardar(LocalidadEditDto localidadDto);
        LocalidadEditDto GetLocalidadPorId(int? id);
        void Borrar(int provVmLocalidadId);
    }
}
