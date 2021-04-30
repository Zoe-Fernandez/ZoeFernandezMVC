using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TarjetaDeCreditoMVC.Entidades.DTOs.Localidades;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios.Facades
{
    public class RepositorioLocalidad : IRepositorioLocalidades
    {
        readonly TarjetasDeCreditoDbContext _context;
        readonly IMapper _mapper;

        public RepositorioLocalidad(TarjetasDeCreditoDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int provVmLocalidadId)
        {
            try
            {
                var localidadInDb = _context.Localidades.SingleOrDefault(l => l.LocalidadId == provVmLocalidadId);
                if (localidadInDb == null)
                {
                    throw new Exception("La localidad no existe");

                }

                _context.Entry(localidadInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar una localidad");
            }

        }

        public bool Existe(Localidad localidad)
        {
            if (localidad.LocalidadId == 0)
            {
                return _context.Localidades.Any(l => l.NombreLocalidad == localidad.NombreLocalidad);
            }

            return _context.Localidades.Any(l =>
                l.NombreLocalidad == localidad.NombreLocalidad && l.LocalidadId != localidad.LocalidadId);
        }

        public List<LocalidadListDto> GetLocalidad(string provincia)
        {
            try
            {
                if (provincia==null)
                {
                    var lista = _context.Localidades
                               .Include(l => l.Provincia)
                               .Select(l => new LocalidadListDto
                               {
                                   LocalidadId = l.LocalidadId,
                                   NombreLocalidad = l.NombreLocalidad,
                                   Provincia = l.Provincia.NombreProvincia
                               }).ToList();
                    return lista; 
                }
                else
                {
                    var lista = _context.Localidades.
                        Include(l => l.Provincia)
                        .Where(l => l.Provincia.NombreProvincia == provincia)
                        .Select(l => new LocalidadListDto
                        {
                            LocalidadId = l.LocalidadId,
                            NombreLocalidad = l.NombreLocalidad,
                            Provincia = l.Provincia.NombreProvincia
                        }).ToList();
                    return lista;

                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las localidades");
            }
        }

        public List<LocalidadListDto> GetLocalidades()
        {
            try
            {
                var lista = _context.Localidades.ToList();
                return _mapper.Map<List<LocalidadListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las localidades");
            }
        }

        public LocalidadEditDto GetLocalidadPorId(int? id)
        {
            try
            {
                return _mapper
                    .Map<LocalidadEditDto>(_context.Localidades
                        .Include(l => l.Provincia)
                        .SingleOrDefault(l => l.LocalidadId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer una localidad");
            }
        }

        public void Guardar(Localidad localidad)
        {
            try
            {
                if (localidad.LocalidadId == 0)
                {
                    _context.Localidades.Add(localidad);
                }
                else
                {
                    var localidadInDb = _context
                        .Localidades
                        .SingleOrDefault(l => l.LocalidadId == localidad.LocalidadId);
                    localidadInDb.LocalidadId = localidad.LocalidadId;
                    localidadInDb.NombreLocalidad = localidad.NombreLocalidad;
                    localidadInDb.ProvinciaId = localidad.ProvinciaId;
                    _context.Entry(localidadInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar una localidad");
            }
        }
    }
}
