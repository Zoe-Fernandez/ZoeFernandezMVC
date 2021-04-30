using AutoMapper;
using System;
using System.Collections.Generic;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Datos.UnitOfWork;
using TarjetaDeCreditoMVC.Entidades.DTOs.Tarjetas;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Servicios.Servicios.Facades
{
    public class ServicioTarjeta : IServicioTarjeta
    {
        readonly IRepositorioTarjeta _repositorio;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        public ServicioTarjeta(IRepositorioTarjeta repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }
        public void Borrar(int cartClienVmTarjetaId)
        {
            try
            {
                _repositorio.Borrar(cartClienVmTarjetaId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TarjetaEditDto tarjetaEditDto)
        {
            try
            {
                Tarjeta tarjeta = _mapper.Map<Tarjeta>(tarjetaEditDto);
                return _repositorio.Existe(tarjeta);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TarjetaListDto> GetLista(string cliente, string carteraDeConsumo)
        {
            try
            {
                return _repositorio.GetLista(cliente, carteraDeConsumo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TarjetaEditDto GetTarjetaPorId(int? id)
        {
            try
            {
                return _repositorio.GetTarjetaPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TarjetaEditDto tarjetaDto)
        {
            try
            {
                Tarjeta tarjeta = _mapper.Map<Tarjeta>(tarjetaDto);
                _repositorio.Guardar(tarjeta);
                _unitOfWork.Save();
                tarjetaDto.TarjetaId = tarjeta.TarjetaId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
