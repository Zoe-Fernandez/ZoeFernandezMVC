using AutoMapper;
using System;
using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Tarjetas;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using System.Data.Entity;
using System.Linq;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios
{
    public class RepositorioTarjeta: IRepositorioTarjeta
    {
        readonly TarjetasDeCreditoDbContext _context;
        readonly IMapper _mapper;
        public RepositorioTarjeta (TarjetasDeCreditoDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int cartClienVmTarjetaId)
        {
            try
            {
                var tarjetaInDb = _context.Tarjetas.SingleOrDefault(t => t.TarjetaId == cartClienVmTarjetaId);
                if (tarjetaInDb == null)
                {
                    throw new Exception("Comercio inexistente");

                }

                _context.Entry(tarjetaInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar una tarjeta");
            }
        }

        public bool Existe(Tarjeta tarjeta)
        {
            if (tarjeta.TarjetaId == 0)
            {
                return _context.Tarjetas.Any(t => t.NumeroDeTarjeta == tarjeta.NumeroDeTarjeta);
            }

            return _context.Tarjetas.Any(t => t.NumeroDeTarjeta == tarjeta.NumeroDeTarjeta && t.TarjetaId != tarjeta.TarjetaId);
        }

        public List<TarjetaListDto> GetLista(string cliente, string carteraDeConsumo)
        {
            try
            {
                if (cliente == null)
                {
                    var lista = _context.Tarjetas
                                .Include(t => t.Cliente)
                                .Select(t => new TarjetaListDto
                                {
                                    TarjetaId = t.TarjetaId,
                                    NumeroDeTarjeta = t.NumeroDeTarjeta,
                                    CarteraDeConsumo = t.CarteraDeConsumo.Descripcion,
                                    Cliente = t.Cliente.NumeroDeDocumento,
                                    ValidaDesde = t.ValidaDesde,
                                    ValidaHasta = t.ValidaHasta,
                                    Vigente = t.Vigente
                                }).ToList();
                    return lista;
                }
                else if (carteraDeConsumo == null)
                {
                    var lista = _context.Tarjetas
                               .Include(t => t.CarteraDeConsumo)
                               .Select(t => new TarjetaListDto
                               {
                                   TarjetaId = t.TarjetaId,
                                   NumeroDeTarjeta = t.NumeroDeTarjeta,
                                   CarteraDeConsumo = t.CarteraDeConsumo.Descripcion,
                                   Cliente = t.Cliente.NumeroDeDocumento,
                                   ValidaDesde = t.ValidaDesde,
                                   ValidaHasta = t.ValidaHasta,
                                   Vigente = t.Vigente
                               }).ToList();
                    return lista;
                }
                else
                {
                    var lista = _context.Tarjetas
                                .Include(t => t.Cliente)
                                .Include(t => t.CarteraDeConsumo)
                                .Select(t => new TarjetaListDto
                                {
                                    TarjetaId = t.TarjetaId,
                                    NumeroDeTarjeta = t.NumeroDeTarjeta,
                                    CarteraDeConsumo = t.CarteraDeConsumo.Descripcion,
                                    Cliente = t.Cliente.NumeroDeDocumento,
                                    ValidaDesde = t.ValidaDesde,
                                    ValidaHasta = t.ValidaHasta,
                                    Vigente = t.Vigente
                                }).ToList();
                    return lista;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las tarjetas");
            };
        }

        public TarjetaEditDto GetTarjetaPorId(int? id)
        {
            try
            {
                return _mapper.Map<TarjetaEditDto>(_context.Tarjetas
                        .Include(t => t.Cliente)
                        .Include(t => t.CarteraDeConsumo)
                        .SingleOrDefault(t => t.TarjetaId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer  una tarjeta");
            }
        }

        public void Guardar(Tarjeta tarjeta)
        {
            try
            {
                if (tarjeta.TarjetaId == 0)
                {
                    _context.Tarjetas.Add(tarjeta);
                }
                else
                {
                    var tarjetaInDb = _context.Tarjetas
                        .SingleOrDefault(t => t.TarjetaId == tarjeta.TarjetaId);
                    tarjetaInDb.TarjetaId = tarjeta.TarjetaId;
                    tarjetaInDb.NumeroDeTarjeta = tarjeta.NumeroDeTarjeta;
                    tarjetaInDb.CarteraDeConsumoId = tarjeta.CarteraDeConsumoId;
                    tarjetaInDb.ClienteId = tarjeta.ClienteId;
                    tarjetaInDb.ValidaDesde = tarjeta.ValidaDesde;
                    tarjetaInDb.ValidaHasta = tarjeta.ValidaHasta;
                    tarjetaInDb.Vigente = tarjeta.Vigente;
                    _context.Entry(tarjetaInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar unz tarjeta");
            }
        }
    }
}
