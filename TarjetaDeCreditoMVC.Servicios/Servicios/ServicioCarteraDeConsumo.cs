using AutoMapper;
using System;
using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarterasDeConsumos;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Datos.UnitOfWork;

namespace TarjetaDeCreditoMVC.Servicios.Servicios
{
    public class ServicioCarteraDeConsumo : IServicioCarteraDeConsumo
    {
        readonly IRepositorioCarterasDeConsumos _repositorio;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;

        public ServicioCarteraDeConsumo(IRepositorioCarterasDeConsumos repositorio, IUnitOfWork unitOfWork)
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

        public bool Existe(CarteraDeConsumoEditDto carteraDeConsumoDto)
        {
            try
            {
                CarteraDeConsumo cc = _mapper.Map<CarteraDeConsumo>(carteraDeConsumoDto);
                return _repositorio.Existe(cc);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CarteraDeConsumoEditDto GetCarteraDeConsumoId(int? id)
        {
            try
            {
                return _repositorio.GetCarteraDeConsumoId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<CarteraDeConsumoListDto> GetLista()
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

        public void Guardar(CarteraDeConsumoEditDto carteraDeConsumoDto)
        {
            try
            {
                CarteraDeConsumo cc = _mapper.Map<CarteraDeConsumo>(carteraDeConsumoDto);
                _repositorio.Guardar(cc);
                _unitOfWork.Save();
                carteraDeConsumoDto.CarteraDeConsumoId = cc.CarteraDeConsumoId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
