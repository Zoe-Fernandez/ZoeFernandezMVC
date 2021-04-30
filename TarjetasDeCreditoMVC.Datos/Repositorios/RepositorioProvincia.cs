using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios
{
    public class RepositorioProvincia : IRepositorioProvincias
    {
        readonly TarjetasDeCreditoDbContext _context;
        readonly IMapper _mapper;
        public RepositorioProvincia(TarjetasDeCreditoDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int? id)
        {
            try
            {
                var provinciaInDb = _context.Provincias.SingleOrDefault(p => p.ProvinciaId == id);
                _context.Entry(provinciaInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar una provincia");
            }
        }

        public bool Existe(Provincia provincia)
        {
            if (provincia.ProvinciaId == 0)
            {
                return _context.Provincias.Any(p => p.NombreProvincia == provincia.NombreProvincia);
            }
            return _context.Provincias.Any(p => p.NombreProvincia == provincia.NombreProvincia && p.ProvinciaId == provincia.ProvinciaId);
        }

        public List<ProvinciaListDto> GetLista()
        {
            try
            {
                var lista = _context.Provincias.ToList();
                return _mapper.Map<List<ProvinciaListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("No se puede leer los nombres de las provincias");
            }
        }

        public ProvinciaEditDto GetProvinciaId(int? id)
        {
            try
            {
                return _mapper.Map<ProvinciaEditDto>(_context.Provincias.SingleOrDefault(p => p.ProvinciaId == id));
            }
            catch (Exception )
            {

                throw new Exception("No se puede leer los nombres de las provincias"); ;
            }
        }

        public void Guardar(Provincia provincia)
        {
            try
            {
                if (provincia.ProvinciaId == 0)
                {
                    _context.Provincias.Add(provincia);
                }
                else
                {
                    var provinciaInDb = _context.Provincias.SingleOrDefault(p => p.ProvinciaId == provincia.ProvinciaId);
                    provinciaInDb.NombreProvincia = provincia.NombreProvincia;
                    _context.Entry(provinciaInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar/editar una provincia");
            }
        }
    }
}
