using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Clientes;

namespace TarjetaDeCreditoMVC.Servicios.Servicios.Facades
{
    public interface IServicioCliente
    {
        List<ClienteListDto> GetLista(string provincia, string localidad, string tipoDeDocumento);
        bool Existe(ClienteEditDto clienteEditDto);
        void Guardar(ClienteEditDto clienteDto);
        ClienteEditDto GetClientePorId(int? id);
        void Borrar(int provLocDocVmClienteId);
    }
}
