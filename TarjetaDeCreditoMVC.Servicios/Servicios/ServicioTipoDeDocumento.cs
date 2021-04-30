using AutoMapper;
using System;
using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.TiposDeDocumentos;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Datos.UnitOfWork;

namespace TarjetaDeCreditoMVC.Servicios.Servicios
{
    public class ServicioTipoDeDocumento : IServicioTipoDeDocumento
    {
        readonly IRepositorioTiposDeDocumentos _repositorio;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        public ServicioTipoDeDocumento(IRepositorioTiposDeDocumentos repositorio, IUnitOfWork unitOfWork)
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
        public bool Existe(TipoDeDocumentoEditDto tipoDeDocumentoDto)
        {
            try
            {
                TipoDeDocumento td = _mapper.Map<TipoDeDocumento>(tipoDeDocumentoDto);
                return _repositorio.Existe(td);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoDeDocumentoEditDto GetTipoDeDocumentoId(int? id)
        {
            try
            {
                return _repositorio.GetTipoDeDocumentoId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoDeDocumentoListDto> GetTipoDeDocumentos()
        {
            try
            {
                return _repositorio.GetTipoDeDocumentos();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Guardar(TipoDeDocumentoEditDto tipoDeDocumentoDto)
        {
            try
            {
                TipoDeDocumento td = _mapper.Map<TipoDeDocumento>(tipoDeDocumentoDto);
                _repositorio.Guardar(td);
                _unitOfWork.Save();
                tipoDeDocumentoDto.TipoDeDocumentoId = td.TipoDeDocumentoId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
