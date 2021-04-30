using AutoMapper;
using System;
using System.Collections.Generic;
using TarjetaDeCreditoMVC.Entidades.DTOs.Clientes;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using System.Data.Entity;
using System.Linq;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        readonly TarjetasDeCreditoDbContext _context;
        readonly IMapper _mapper;
        public RepositorioCliente(TarjetasDeCreditoDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int provLovDocVmClienteId)
        {
            try
            {
                var clienteInDb = _context.Clientes.SingleOrDefault(c => c.ClienteId == provLovDocVmClienteId);
                if (clienteInDb == null)
                {
                    throw new Exception("Cliente inexistente");

                }

                _context.Entry(clienteInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un cliente");
            }
        }

        public bool Existe(Cliente cliente)
        {
            if (cliente.ClienteId == 0)
            {
                return _context.Clientes.Any(c => c.NumeroDeDocumento == cliente.NumeroDeDocumento);
            }

            return _context.Clientes.Any(c => c.NumeroDeDocumento == cliente.NumeroDeDocumento && c.ClienteId != cliente.ClienteId);
        }

        public ClienteEditDto GetClientePorId(int? id)
        {
            try
            {
                return _mapper.Map<ClienteEditDto>(_context.Clientes
                        .Include(c => c.Provincia)
                        .Include(c => c.Localidad)
                        .Include(c => c.TipoDeDocumento)
                        .SingleOrDefault(c => c.ClienteId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer  un cliente");
            }
        }

        public List<ClienteListDto> GetLista(string provincia, string localidad, string tipoDeDocumento)
        {
            
            try
            {
                if (provincia == null)
                {
                    var lista = _context.Clientes
                                .Include(c => c.Provincia)
                                .Select(c => new ClienteListDto
                                {
                                    ClienteId = c.ClienteId,
                                    Nombre = c.Nombre,
                                    Apellido = c.Apellido,
                                    TipoDeDocumento = c.TipoDeDocumento.Descripcion,
                                    NumeroDeDocumento = c.NumeroDeDocumento,
                                    Direccion = c.Direccion,
                                    Localidad = c.Localidad.NombreLocalidad,
                                    Provincia = c.Provincia.NombreProvincia,
                                    TelefonoFijo = c.TelefonoFijo,
                                    TelefonoMovil = c.TelefonoMovil,
                                    CorreoElectronico = c.CorreoElectronico,
                                    FechaDeNacimiento = c.FechaDeNacimiento,
                                    Suspendido = c.Suspendido
                                }).ToList();
                    return lista;
                }
                else if (localidad == null)
                {
                    var lista = _context.Clientes
                                .Include(c => c.Localidad)
                                .Select(c => new ClienteListDto
                                {
                                    ClienteId = c.ClienteId,
                                    Nombre = c.Nombre,
                                    Apellido = c.Apellido,
                                    TipoDeDocumento = c.TipoDeDocumento.Descripcion,
                                    NumeroDeDocumento = c.NumeroDeDocumento,
                                    Direccion = c.Direccion,
                                    Localidad = c.Localidad.NombreLocalidad,
                                    Provincia = c.Provincia.NombreProvincia,
                                    TelefonoFijo = c.TelefonoFijo,
                                    TelefonoMovil = c.TelefonoMovil,
                                    CorreoElectronico = c.CorreoElectronico,
                                    FechaDeNacimiento = c.FechaDeNacimiento,
                                    Suspendido = c.Suspendido
                                }).ToList();
                    return lista;
                }
                else
                {
                    var lista = _context.Clientes
                                .Include(c => c.Provincia)
                                .Include(c => c.Localidad)
                                .Include(c=>c.TipoDeDocumento)
                                .Where(c => c.Provincia.NombreProvincia == provincia)
                                .Where(c => c.Localidad.NombreLocalidad == localidad)
                                .Where(c => c.TipoDeDocumento.Descripcion == tipoDeDocumento)
                                .Select(c => new ClienteListDto
                                {
                                    ClienteId = c.ClienteId,
                                    Nombre = c.Nombre,
                                    Apellido = c.Apellido,
                                    TipoDeDocumento = c.TipoDeDocumento.Descripcion,
                                    NumeroDeDocumento = c.NumeroDeDocumento,
                                    Direccion = c.Direccion,
                                    Localidad = c.Localidad.NombreLocalidad,
                                    Provincia = c.Provincia.NombreProvincia,
                                    TelefonoFijo = c.TelefonoFijo,
                                    TelefonoMovil = c.TelefonoMovil,
                                    CorreoElectronico = c.CorreoElectronico,
                                    FechaDeNacimiento = c.FechaDeNacimiento,
                                    Suspendido = c.Suspendido
                                }).ToList();
                    return lista;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los clientes");
            }
        }

        public void Guardar(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId == 0)
                {
                    _context.Clientes.Add(cliente);
                }
                else
                {
                    var clienteInDb = _context.Clientes
                        .SingleOrDefault(c => c.ClienteId == cliente.ClienteId);
                    clienteInDb.ClienteId = cliente.ClienteId;
                    clienteInDb.Nombre = cliente.Nombre;
                    clienteInDb.Apellido = cliente.Apellido;
                    clienteInDb.TipoDeDocumentoId = cliente.TipoDeDocumentoId;
                    clienteInDb.NumeroDeDocumento = cliente.NumeroDeDocumento;
                    clienteInDb.Direccion = cliente.Direccion;
                    clienteInDb.LocalidadId = cliente.LocalidadId;
                    clienteInDb.ProvinciaId = cliente.ProvinciaId;
                    clienteInDb.TelefonoFijo = cliente.TelefonoFijo;
                    clienteInDb.TelefonoMovil = cliente.TelefonoMovil;
                    clienteInDb.CorreoElectronico = cliente.CorreoElectronico;
                    clienteInDb.FechaDeNacimiento = cliente.FechaDeNacimiento;
                    clienteInDb.Suspendido = cliente.Suspendido;
                    _context.Entry(clienteInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar un cliente");
            }
        }
    }
}
