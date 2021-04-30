using System;
using System.Collections.Generic;
using System.Linq;
using TarjetaDeCreditoMVC.Datos;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Web.Classes
{
    public class CombosHelper : IDisposable
    {
        private static readonly TarjetasDeCreditoDbContext Db = new TarjetasDeCreditoDbContext();

        public static List<Provincia> GetProvincias()
        {
            var defaultProvincia = new Provincia
            {
                ProvinciaId = 0,
                NombreProvincia = "<Seleccione una provincia>"
            };
            var listaProvincia = Db.Provincias.OrderBy(p => p.NombreProvincia).ToList();
            listaProvincia.Insert(0, defaultProvincia);
            return listaProvincia;
        }

        public static List<Localidad> GetLocalidades(int provinciaId = 0)
        {
            var defaultLocalidad = new Localidad
            {
                LocalidadId = 0,
                NombreLocalidad = "<Seleccione una localidad>"
            };
            var listaLocalidades = Db.Localidades
                .Where(l => l.ProvinciaId == provinciaId)
                .OrderBy(l => l.NombreLocalidad).ToList();
            listaLocalidades.Insert(0, defaultLocalidad);
            return listaLocalidades;
        }

        public static List<CarteraDeConsumo> GetCarteraDeConsumos()
        {
            var defaultCarteraDeConsumo = new CarteraDeConsumo
            {
                CarteraDeConsumoId = 0,
                Descripcion = "<Seleccione cartera de consumo>"
            };
            var listaCarteraDeConsumo = Db.CarteraDeConsumos
                .OrderBy(cc => cc.Descripcion).ToList();
            listaCarteraDeConsumo.Insert(0, defaultCarteraDeConsumo);
            return listaCarteraDeConsumo;
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}