using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Clientes;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioCliente
    {
        List<ClienteListDto> GetLista(string provincia, string localidad, string tipoDeDocumento);
        bool Existe(Cliente cliente);
        void Guardar(Cliente cliente);
        ClienteEditDto GetClientePorId(int? id);
        void Borrar(int provLovDocVmClienteId);
    }
}
