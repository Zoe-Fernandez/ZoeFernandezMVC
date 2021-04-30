using AutoMapper;
using System;
using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Datos.UnitOfWork;

namespace TarjetaDeCreditoMVC.Servicios.Servicios
{
    public class ServicioProvincia : IServicioProvincia
    {
        readonly IRepositorioProvincias _repositorio;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;

        public ServicioProvincia(IRepositorioProvincias repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }
        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ProvinciaEditDto provinciaDto)
        {
            try
            {
                Provincia p = _mapper.Map<Provincia>(provinciaDto);
                return _repositorio.Existe(p);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ProvinciaEditDto GetProvinciaId(int? id)
        {
            try
            {
                return _repositorio.GetProvinciaId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ProvinciaListDto> GetProvincias()
        {
            try
            {
                return _repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(ProvinciaEditDto provinciaDto)
        {
            try
            {
                Provincia p = _mapper.Map<Provincia>(provinciaDto);
                _repositorio.Guardar(p);
                _unitOfWork.Save();
                provinciaDto.ProvinciaId = p.ProvinciaId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
