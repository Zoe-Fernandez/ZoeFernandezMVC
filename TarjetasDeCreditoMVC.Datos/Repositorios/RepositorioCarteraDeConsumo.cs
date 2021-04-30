using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TarjetaDeCreditoMVC.Datos.Repositorios.Facades;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarterasDeConsumos;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Datos.Repositorios
{
    public class RepositorioCarteraDeConsumo : IRepositorioCarterasDeConsumos
    {
        readonly TarjetasDeCreditoDbContext _context;
        readonly IMapper _mapper;
        public RepositorioCarteraDeConsumo(TarjetasDeCreditoDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                var carteraDeConsumoInDb = _context.CarteraDeConsumos.SingleOrDefault(cc => cc.CarteraDeConsumoId == id);
                _context.Entry(carteraDeConsumoInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar una cartera de consumo");
            }
        }

        public bool Existe(CarteraDeConsumo carteraDeConsumo)
        {
            if (carteraDeConsumo.CarteraDeConsumoId == 0)
            {
                return _context.CarteraDeConsumos.Any(cc => cc.Descripcion == carteraDeConsumo.Descripcion);
            }
            return _context.CarteraDeConsumos.Any(cc => cc.Descripcion == carteraDeConsumo.Descripcion && cc.CarteraDeConsumoId != carteraDeConsumo.CarteraDeConsumoId);
        }

        public CarteraDeConsumoEditDto GetCarteraDeConsumoId(int? id)
        {
            try
            {
                return _mapper.Map<CarteraDeConsumoEditDto>(_context.CarteraDeConsumos.SingleOrDefault(cc => cc.CarteraDeConsumoId == id));
            }
            catch (Exception)
            {

                throw new Exception("No se puede leer las descripciones de la cartera de consumo"); ;
            }
        }

        public List<CarteraDeConsumoListDto> GetLista()
        {
            var lista = _context.CarteraDeConsumos.ToList();
            return _mapper.Map<List<CarteraDeConsumoListDto>>(lista);
        }

        public void Guardar(CarteraDeConsumo carteraDeConsumo)
        {
            //Guardar registro nuevo o existente
            //verificar que existe el id

            try
            {
                if (carteraDeConsumo.CarteraDeConsumoId == 0)
                {
                    _context.CarteraDeConsumos.Add(carteraDeConsumo);
                }
                else
                {
                    var carteraDeConsumoInDb = _context.CarteraDeConsumos
                       .SingleOrDefault(cc => cc.CarteraDeConsumoId == carteraDeConsumo.CarteraDeConsumoId);
                    carteraDeConsumoInDb.Descripcion = carteraDeConsumo.Descripcion;
                    carteraDeConsumoInDb.LimiteDeCredito = carteraDeConsumo.LimiteDeCredito;
                    carteraDeConsumoInDb.CostoDeRenovacion = carteraDeConsumo.CostoDeRenovacion;
                    carteraDeConsumoInDb.Imagen = carteraDeConsumo.Imagen;
                    _context.Entry(carteraDeConsumoInDb).State = EntityState.Modified;
                    
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar/editar una cartera de consumo");
            }
        }
    }
}
