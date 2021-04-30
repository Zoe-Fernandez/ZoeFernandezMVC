using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Web.Controllers
{
    public class ProvinciasController : Controller
    {
        readonly IServicioProvincia _servicio;
        readonly IMapper _mapper;
        public ProvinciasController(IServicioProvincia servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: Provincias
        public ActionResult Index()
        {
            var listaDto = _servicio.GetProvincias();
            var listaVm = _mapper.Map<List<ProvinciaListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProvinciaEditViewModel pVm)
        {
            if (!ModelState.IsValid)
            {
                return View(pVm);
            }

            ProvinciaEditDto pDto = _mapper.Map<ProvinciaEditDto>(pVm);
            if (_servicio.Existe(pDto))
            {
                ModelState.AddModelError(string.Empty, "Registro repetido");
                return View(pVm);
            }

            try
            {
                _servicio.Guardar(pDto);
                TempData["Msg"] = "Nueva provincia guardada";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(pVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProvinciaEditDto pDto = _servicio.GetProvinciaId(id);
            if (pDto == null)
            {
                return HttpNotFound("Registro inexistente");
            }

            ProvinciaEditViewModel pVm = _mapper.Map<ProvinciaEditViewModel>(pDto);
            return View(pVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProvinciaEditViewModel pVm)
        {
            try
            {
                pVm = _mapper.Map<ProvinciaEditViewModel>(_servicio.GetProvinciaId(pVm.ProvinciaId));

                _servicio.Borrar(pVm.ProvinciaId);
                TempData["Msg"] = "Provincia eliminada";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Registro relacionado con otros registros");
                return View(pVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProvinciaEditDto pDto = _servicio.GetProvinciaId(id);
            ProvinciaEditViewModel pVm = _mapper.Map<ProvinciaEditViewModel>(pDto);
            return View(pVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProvinciaEditViewModel pVm)
        {
            if (!ModelState.IsValid)
            {
                return View(pVm);
            }

            ProvinciaEditDto pDto = _mapper.Map<ProvinciaEditDto>(pVm);
            if (_servicio.Existe(pDto))
            {
                ModelState.AddModelError(string.Empty, "Registro repetido");
                return View(pVm);
            }

            try
            {
                _servicio.Guardar(pDto);
                TempData["Msg"] = "Provincia modificada";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Registro relacionado con otros registros");
                return View(pVm);
            }
        }
    }
}