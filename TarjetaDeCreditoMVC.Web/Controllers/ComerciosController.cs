using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TarjetaDeCreditoMVC.Entidades.DTOs.Comercios;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Comercio;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Localidad;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Web.Classes;

namespace TarjetaDeCreditoMVC.Web.Controllers
{
    public class ComerciosController : Controller
    {
        readonly IServicioComercio _servicio;
        readonly IServicioProvincia _servicioProvincia;
        readonly IServicioLocalidad _servicioLocalidad;
        readonly IMapper _mapper;
        public ComerciosController(IServicioComercio servicio, IServicioProvincia serviciosProvincia, IServicioLocalidad serviciosLocalidad)
        {
            _servicio = servicio;
            _servicioProvincia = serviciosProvincia;
            _servicioLocalidad = serviciosLocalidad;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: Comercio
        public ActionResult Index(string localidad = null, string provincia = null)
        {
            var listaDto = _servicio.GetLista(localidad, provincia);
            var listaVm = _mapper.Map<List<ComercioListViewModel>>(listaDto);

            var comercioFilterVm = new ComercioFilterListViewModel
            {
                Comercios = listaVm,
                Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias())
            };
            return View(comercioFilterVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ComercioEditViewModel cVm = new ComercioEditViewModel
            {
                Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias()),
                Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null))
            };
            return View(cVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComercioEditViewModel cVm)
        {
            if (!ModelState.IsValid)
            {
                cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
                return View(cVm);
            }

            ComercioEditDto comercioDto = _mapper.Map<ComercioEditDto>(cVm);
            if (_servicio.Existe(comercioDto))
            {
                ModelState.AddModelError(string.Empty, @"Comercio existente");
                cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
                return View(cVm);
            }

            try
            {
                _servicio.Guardar(comercioDto);

                TempData["Msg"] = "Comercio agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
                return View(cVm);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ComercioEditDto cEditDto = _servicio.GetComercioPorId(id);
            ComercioEditViewModel cVm = _mapper.Map<ComercioEditViewModel>(cEditDto);
            cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
            cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
            return View(cVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComercioEditViewModel cVm)
        {
            if (!ModelState.IsValid)
            {
                cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
                return View(cVm);
            }

            ComercioEditDto cDto = _mapper.Map<ComercioEditDto>(cVm);
            if (_servicio.Existe(cDto))
            {
                cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
                return View(cVm);
            }

            try
            {
                _servicio.Guardar(cDto);
                TempData["Msg"] = "Comercio editado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
                return View(cVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ComercioEditDto cEditDto = _servicio.GetComercioPorId(id);
            if (cEditDto == null)
            {
                return HttpNotFound("Comercio inexistente");
            }

            ComercioListDto cDto = _mapper.Map<ComercioListDto>(_servicio.GetComercioPorId(id));
            var provincia = _servicioProvincia.GetProvinciaId(cEditDto.ProvinciaId);
            var localidad = _servicioLocalidad.GetLocalidadPorId(cEditDto.LocalidadId);
            cDto.Provincia = provincia.NombreProvincia;
            cDto.Localidad = localidad.NombreLocalidad;

            ComercioListViewModel cVm = _mapper.Map<ComercioListViewModel>(cDto);

            return View(cVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ComercioListViewModel cVm)
        {
            try
            {
                ComercioListDto cDto = _mapper.Map<ComercioListDto>(_servicio.GetComercioPorId(cVm.ComercioId));
                cVm = _mapper.Map<ComercioListViewModel>(cDto);

                _servicio.Borrar(cVm.ComercioId);
                TempData["Msg"] = "Comercio eliminado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(cVm);
            }
        }
    }
}