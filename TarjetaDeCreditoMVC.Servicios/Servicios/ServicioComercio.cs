using AutoMapper;
using System;
using System.Collections.Generic;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Datos.UnitOfWork;
using TarjetaDeCreditoMVC.Entidades.DTOs.Comercios;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Servicios.Servicios
{
    public class ServicioComercio : IServicioComercio
    {
        readonly IRepositorioComercio _repositorio;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        public ServicioComercio(IRepositorioComercio repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int provLocVmComercioId)
        {
            try
            {
                _repositorio.Borrar(provLocVmComercioId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ComercioEditDto comercioEditDto)
        {
            try
            {
                Comercio comercio = _mapper.Map<Comercio>(comercioEditDto);
                return _repositorio.Existe(comercio);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ComercioEditDto GetComercioPorId(int? id)
        {
            try
            {
                return _repositorio.GetComercioPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ComercioListDto> GetLista(string provincia, string localidad)
        {
            try
            {
                return _repositorio.GetComercio(provincia, localidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(ComercioEditDto comercioDto)
        {
            try
            {
                Comercio comercio = _mapper.Map<Comercio>(comercioDto);
                _repositorio.Guardar(comercio);
                _unitOfWork.Save();
                comercioDto.ComercioId = comercio.ComercioId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
