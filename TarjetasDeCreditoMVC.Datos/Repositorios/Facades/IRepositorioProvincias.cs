using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioProvincias
    {
        List<ProvinciaListDto> GetLista();
        ProvinciaEditDto GetProvinciaId(int? id);
        void Guardar(Provincia provincia);
        void Borrar(int? id);
        bool Existe(Provincia provincia);
    }
}
