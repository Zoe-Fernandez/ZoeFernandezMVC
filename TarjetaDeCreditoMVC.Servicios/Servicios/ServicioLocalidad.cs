using AutoMapper;
using System;
using System.Collections.Generic;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Datos.UnitOfWork;
using TarjetaDeCreditoMVC.Entidades.DTOs.Localidades;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Servicios.Servicios
{
    public class ServicioLocalidad : IServicioLocalidad
    {
        readonly IRepositorioLocalidades _repositorio;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        public ServicioLocalidad(IRepositorioLocalidades repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int provVmLocalidadId)
        {
            try
            {
                _repositorio.Borrar(provVmLocalidadId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(LocalidadEditDto localidadEditDto)
        {
            try
            {
                Localidad localidad = _mapper.Map<Localidad>(localidadEditDto);
                return _repositorio.Existe(localidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<LocalidadListDto> GetLista(string provincia)
        {
            try
            {
                return _repositorio.GetLocalidad(provincia);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public LocalidadEditDto GetLocalidadPorId(int? id)
        {
            try
            {
                return _repositorio.GetLocalidadPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(LocalidadEditDto localidadDto)
        {
            try
            {
                Localidad localidad = _mapper.Map<Localidad>(localidadDto);
                _repositorio.Guardar(localidad);
                _unitOfWork.Save();
                localidadDto.LocalidadId = localidad.LocalidadId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
