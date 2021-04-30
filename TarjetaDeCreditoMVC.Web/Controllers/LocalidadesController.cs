using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using TarjetaDeCreditoMVC.Datos;
using TarjetaDeCreditoMVC.Entidades.DTOs.Localidades;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Localidad;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Entidades.Entidades;

namespace TarjetaDeCreditoMVC.Web.Controllers
{
    public class LocalidadesController : Controller
    {
        readonly IServicioLocalidad _servicio;
        readonly IServicioProvincia _servicioProvincia;
        readonly IMapper _mapper;
        //readonly int _registrosPorPagina = 10;
        //Listador<LocalidadListViewModel> _listador;
        readonly TarjetasDeCreditoDbContext _dbContext;
        public LocalidadesController(IServicioLocalidad servicio, IServicioProvincia servicioProvincia)
        {
            _servicio = servicio;
            _servicioProvincia = servicioProvincia;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: Localidades
        public ActionResult Index(int pagina=1 ,string provincia = null)
        {
            var listaDto = _servicio.GetLista(provincia);
            var listaVm = _mapper.Map<List<LocalidadListViewModel>>(listaDto);

            var localidadFilterVm = new LocalidadFilterListViewModel
            {
                Localidades = listaVm,
                Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias())
            };

            //int totalRegistros = _dbContext.Localidades.Count();

            //var localidades = _dbContext.Localidades
            //    .Include(l => l.Provincia)
            //    .OrderBy(l => l.Provincia.NombreProvincia)
            //    .ThenBy(c => c.NombreLocalidad)
            //    .Skip((pagina - 1) * _registrosPorPagina)
            //    .Take(_registrosPorPagina)
            //    .ToList();

            //var localidadVm = _mapper.Map<List<Localidad>, List<LocalidadListViewModel>>(localidades);
            //localidadVm.ForEach(c =>
            //{
            //    c.CantidadClientes = _dbContext
            //        .Clientes.Count(cl => cl.LocalidadId == c.LocalidadId);
            //    c.CantidadComercios = _dbContext
            //        .Comercios.Count(cc => cc.LocalidadId == c.LocalidadId);
            //});

            //var totalPaginas = (int)Math.Ceiling((double)totalRegistros / _registrosPorPagina);
            //_listador = new Listador<LocalidadListViewModel>()
            //{
            //    RegistrosPorPagina = _registrosPorPagina,
            //    TotalPaginas = totalPaginas,
            //    TotalRegistros = totalRegistros,
            //    PaginaActual = pagina,
            //    Registros = listaVm
            //};
            
            //return View(_listador);
            return View(localidadFilterVm);
        }
        [HttpGet]
        public ActionResult Create()
        {
            LocalidadEditViewModel localidadVm = new LocalidadEditViewModel
            {
                Provincias = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias())
            };
            return View(localidadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocalidadEditViewModel localidadVm)
        {
            if (!ModelState.IsValid)
            {
                localidadVm.Provincias = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                return View(localidadVm);
            }

            LocalidadEditDto localidadDto = _mapper.Map<LocalidadEditDto>(localidadVm);
            if (_servicio.Existe(localidadDto))
            {
                ModelState.AddModelError(string.Empty, @"Localidad existente");
                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                return View(localidadVm);
            }

            try
            {
                _servicio.Guardar(localidadDto);

                TempData["Msg"] = "Localidad agregada";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                return View(localidadVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LocalidadEditDto localidadEditDto = _servicio.GetLocalidadPorId(id);
            LocalidadEditViewModel localidadVm = _mapper.Map<LocalidadEditViewModel>(localidadEditDto);
            localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
            return View(localidadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocalidadEditViewModel localidadVm)
        {
            if (!ModelState.IsValid)
            {
                localidadVm.Provincias = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                return View(localidadVm);
            }

            LocalidadEditDto localidadDto = _mapper.Map<LocalidadEditDto>(localidadVm);
            if (_servicio.Existe(localidadDto))
            {
                ModelState.AddModelError(string.Empty, @"La localidad no existe");
                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                return View(localidadVm);
            }

            try
            {
                _servicio.Guardar(localidadDto);
                TempData["Msg"] = "Localidad modificada";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                return View(localidadVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LocalidadEditDto localidadEditDto = _servicio.GetLocalidadPorId(id);
            if (localidadEditDto == null)
            {
                return HttpNotFound("La localidad no existe");
            }

            LocalidadListDto localidadDto = _mapper.Map<LocalidadListDto>(_servicio.GetLocalidadPorId(id));
            var provincia = _servicioProvincia.GetProvinciaId(localidadEditDto.LocalidadId);
            ///localidadDto.Provincia = provincia.NombreProvincia;
            LocalidadListViewModel localidadVm = _mapper.Map<LocalidadListViewModel>(localidadDto);
            return View(localidadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LocalidadListViewModel localidadVm)
        {
            try
            {
                LocalidadListDto localidadDto = _mapper
                    .Map<LocalidadListDto>(_servicio.GetLocalidadPorId(localidadVm.LocalidadId));
                localidadVm = _mapper.Map<LocalidadListViewModel>(localidadDto);

                _servicio.Borrar(localidadVm.LocalidadId);
                TempData["Msg"] = "Localidad eliminada";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(localidadVm);
            }
        }
        
    }
}