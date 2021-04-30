using AutoMapper;
using System;
using System.Collections.Generic;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Datos.UnitOfWork;
using TarjetaDeCreditoMVC.Entidades.DTOs.Clientes;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Servicios.Servicios
{
    public class ServicioCliente : IServicioCliente
    {
        readonly IRepositorioCliente _repositorio;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        public ServicioCliente(IRepositorioCliente repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }
        public void Borrar(int provLocDocVmClienteId)
        {
            try
            {
                _repositorio.Borrar(provLocDocVmClienteId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ClienteEditDto clienteEditDto)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteEditDto);
                return _repositorio.Existe(cliente);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ClienteEditDto GetClientePorId(int? id)
        {
            try
            {
                return _repositorio.GetClientePorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ClienteListDto> GetLista(string provincia, string localidad, string tipoDeDocumento)
        {
            try
            {
                return _repositorio.GetLista(provincia, localidad, tipoDeDocumento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(ClienteEditDto clienteDto)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteDto);
                _repositorio.Guardar(cliente);
                _unitOfWork.Save();
                clienteDto.ClienteId = cliente.ClienteId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
