using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TarjetaDeCreditoMVC.Entidades.DTOs.TiposDeDocumentos;
using TarjetaDeCreditoMVC.Entidades.ViewModels.TipoDeDocumento;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Web.Controllers
{
    public class TiposDeDocumentosController : Controller
    {
        readonly IServicioTipoDeDocumento _servicio;
        readonly IMapper _mapper;
        public TiposDeDocumentosController(IServicioTipoDeDocumento servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: TiposDeDocumentos
        public ActionResult Index()
        {
            var listaDto = _servicio.GetTipoDeDocumentos();
            var listaVm = _mapper.Map<List<TipoDeDocumentoListViewModel>>(listaDto);
            return View(listaVm);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeDocumentoEditViewModel tdVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tdVm);
            }

            TipoDeDocumentoEditDto tdDto = _mapper.Map<TipoDeDocumentoEditDto>(tdVm);
            if (_servicio.Existe(tdDto))
            {
                ModelState.AddModelError(string.Empty, "Registro repetido");
                return View(tdVm);
            }

            try
            {
                _servicio.Guardar(tdDto);
                TempData["Msg"] = "Nuevo tipo de documento guardado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tdVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoDeDocumentoEditDto tdDto = _servicio.GetTipoDeDocumentoId(id);
            if (tdDto == null)
            {
                return HttpNotFound("Registro inexistente");
            }

            TipoDeDocumentoEditViewModel tdVm = _mapper.Map<TipoDeDocumentoEditViewModel>(tdDto);
            return View(tdVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoDeDocumentoEditViewModel tdVm)
        {
            try
            {
                tdVm = _mapper.Map<TipoDeDocumentoEditViewModel>(_servicio.GetTipoDeDocumentoId(tdVm.TipoDeDocumentoId));

                _servicio.Borrar(tdVm.TipoDeDocumentoId);
                TempData["Msg"] = "Tipo de documento eliminado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(tdVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoDeDocumentoEditDto tdDto = _servicio.GetTipoDeDocumentoId(id);
            TipoDeDocumentoEditViewModel tdVm = _mapper.Map<TipoDeDocumentoEditViewModel>(tdDto);
            return View(tdVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeDocumentoEditViewModel tdVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tdVm);
            }

            TipoDeDocumentoEditDto tdDto = _mapper.Map<TipoDeDocumentoEditDto>(tdVm);
            if (_servicio.Existe(tdDto))
            {
                ModelState.AddModelError(string.Empty, "Registro repetido");
                return View(tdVm);
            }

            try
            {
                _servicio.Guardar(tdDto);
                TempData["Msg"] = "Tipo de documento modificado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tdVm);
            }
        }
    }
}