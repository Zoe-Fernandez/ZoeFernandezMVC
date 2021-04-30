using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Localidades;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioLocalidades
    {
        List<LocalidadListDto> GetLocalidad(string provincia);
        bool Existe(Localidad localidad);
        void Guardar(Localidad localidad);
        LocalidadEditDto GetLocalidadPorId(int? id);
        void Borrar(int provVmLocalidadId);
        List<LocalidadListDto> GetLocalidades();
    }
}
