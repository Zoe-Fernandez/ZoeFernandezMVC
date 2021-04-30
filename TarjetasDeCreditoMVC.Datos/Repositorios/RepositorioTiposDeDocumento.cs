using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TarjetaDeCreditoMVC.Entidades.DTOs.TiposDeDocumentos;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios
{
    public class RepositorioTiposDeDocumento : IRepositorioTiposDeDocumentos
    {
        readonly TarjetasDeCreditoDbContext _context;
        readonly IMapper _mapper;
        public RepositorioTiposDeDocumento(TarjetasDeCreditoDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                var tipoDeDocumentoInDb = _context.TipoDeDocumentos.SingleOrDefault(td => td.TipoDeDocumentoId == id);
                _context.Entry(tipoDeDocumentoInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar un tipo de documento");
            }
        }

        public bool Existe(TipoDeDocumento tipoDeDocumento)
        {
            if (tipoDeDocumento.TipoDeDocumentoId == 0)
            {
                return _context.TipoDeDocumentos.Any(td => td.Descripcion == tipoDeDocumento.Descripcion);
            }
            return _context.TipoDeDocumentos.Any(td => td.Descripcion == tipoDeDocumento.Descripcion && td.TipoDeDocumentoId == tipoDeDocumento.TipoDeDocumentoId);
        }

        public List<TipoDeDocumentoListDto> GetTipoDeDocumentos()
        {
            try
            {
                var lista= _context.TipoDeDocumentos.ToList();
                return _mapper.Map<List<TipoDeDocumentoListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("No se puede leer los tipos de documentos");
            }
        }

        public TipoDeDocumentoEditDto GetTipoDeDocumentoId(int? id)
        {
            try
            {
                return _mapper.Map<TipoDeDocumentoEditDto>(_context.TipoDeDocumentos.SingleOrDefault(td => td.TipoDeDocumentoId == id));
            }
            catch (Exception)
            {

                throw new Exception("No se puede leer los tipos de documentos"); ;
            }
        }

        public void Guardar(TipoDeDocumento tipoDeDocumento)
        {
            //Guardar registro nuevo o existente
            //verificar que existe el id

            try
            {
                if (tipoDeDocumento.TipoDeDocumentoId == 0)
                {
                    _context.TipoDeDocumentos.Add(tipoDeDocumento);
                }
                else
                {
                    var tipoDeDocumentoInDb = _context.TipoDeDocumentos.SingleOrDefault(td => td.TipoDeDocumentoId == tipoDeDocumento.TipoDeDocumentoId);
                    tipoDeDocumentoInDb.Descripcion = tipoDeDocumento.Descripcion;
                    _context.Entry(tipoDeDocumentoInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar/editar un tipo de documento");
            }
        }
    }
}
