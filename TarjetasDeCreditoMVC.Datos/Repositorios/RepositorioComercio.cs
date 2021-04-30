using AutoMapper;
using System;
using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Comercios;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using System.Data.Entity;
using System.Linq;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios
{
    public class RepositorioComercio : IRepositorioComercio
    {
        readonly TarjetasDeCreditoDbContext _context;
        readonly IMapper _mapper;
        public RepositorioComercio(TarjetasDeCreditoDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int provLocVmComercioId)
        {
            try
            {
                var comercioInDb = _context.Comercios.SingleOrDefault(c => c.ComercioId == provLocVmComercioId);
                if (comercioInDb == null)
                {
                    throw new Exception("Comercio inexistente");

                }

                _context.Entry(comercioInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un comercio");
            }
        }

        public bool Existe(Comercio comercio)
        {
            if (comercio.ComercioId == 0)
            {
                return _context.Comercios.Any(c => c.RazonSocial == comercio.RazonSocial);
            }

            return _context.Comercios.Any(c => c.RazonSocial == comercio.RazonSocial && c.ComercioId != comercio.ComercioId);
        }

        public List<ComercioListDto> GetComercio(string provincia, string localidad)
        {
            try
            {
                if (provincia == null)
                {
                    var lista = _context.Comercios
                                .Include(c => c.Provincia)
                                .Select(c => new ComercioListDto
                                {
                                    ComercioId = c.ComercioId,
                                    RazonSocial = c.RazonSocial,
                                    PersonaDeContacto = c.PersonaDeContacto,
                                    Direccion = c.Direccion,
                                    Localidad = c.Localidad.NombreLocalidad,
                                    Provincia = c.Provincia.NombreProvincia,
                                    TelefonoFijo = c.TelefonoFijo,
                                    TelefonoMovil = c.TelefonoMovil,
                                    CorreoElectronico = c.CorreoElectronico
                                }).ToList();
                    return lista;
                }
                else if (localidad==null)
                {
                    var lista = _context.Comercios
                                .Include(c => c.Localidad)
                                .Select(c => new ComercioListDto
                                {
                                    ComercioId = c.ComercioId,
                                    RazonSocial = c.RazonSocial,
                                    PersonaDeContacto = c.PersonaDeContacto,
                                    Direccion = c.Direccion,
                                    Localidad = c.Localidad.NombreLocalidad,
                                    Provincia = c.Provincia.NombreProvincia,
                                    TelefonoFijo = c.TelefonoFijo,
                                    TelefonoMovil = c.TelefonoMovil,
                                    CorreoElectronico = c.CorreoElectronico
                                }).ToList();
                    return lista;
                }
                else
                {
                    var lista = _context.Comercios
                                .Include(c => c.Provincia)
                                .Include(c => c.Localidad)
                                .Where(c => c.Provincia.NombreProvincia == provincia)
                                .Where(c => c.Localidad.NombreLocalidad == localidad)
                                .Select(c => new ComercioListDto
                                {
                                    ComercioId = c.ComercioId,
                                    RazonSocial = c.RazonSocial,
                                    PersonaDeContacto = c.PersonaDeContacto,
                                    Direccion = c.Direccion,
                                    Localidad = c.Localidad.NombreLocalidad,
                                    Provincia = c.Provincia.NombreProvincia,
                                    TelefonoFijo = c.TelefonoFijo,
                                    TelefonoMovil = c.TelefonoMovil,
                                    CorreoElectronico = c.CorreoElectronico
                                }).ToList();
                    return lista;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los comercios");
            }
        }

        public ComercioEditDto GetComercioPorId(int? id)
        {
            try
            {
                return _mapper.Map<ComercioEditDto>(_context.Comercios
                        .Include(c => c.Provincia)
                        .Include(c => c.Localidad)
                        .SingleOrDefault(c => c.ComercioId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer  un comercio");
            }
        }

        public void Guardar(Comercio comercio)
        {
            try
            {
                if (comercio.ComercioId == 0)
                {
                    _context.Comercios.Add(comercio);
                }
                else
                {
                    var comercioInDb = _context.Comercios
                        .SingleOrDefault(c => c.ComercioId == comercio.ComercioId);
                    comercioInDb.ComercioId = comercio.ComercioId;
                    comercioInDb.RazonSocial = comercio.RazonSocial;
                    comercioInDb.PersonaDeContacto = comercio.PersonaDeContacto;
                    comercioInDb.Direccion = comercio.Direccion;
                    comercioInDb.LocalidadId = comercio.LocalidadId;
                    comercioInDb.ProvinciaId = comercio.ProvinciaId;
                    comercioInDb.TelefonoFijo = comercio.TelefonoFijo;
                    comercioInDb.TelefonoMovil = comercio.TelefonoMovil;
                    comercioInDb.CorreoElectronico = comercio.CorreoElectronico;
                    _context.Entry(comercioInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar un comercio");
            }
        }
    }
}
