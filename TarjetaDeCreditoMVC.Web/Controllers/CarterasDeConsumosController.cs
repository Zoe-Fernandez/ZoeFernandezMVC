using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarterasDeConsumos;
using TarjetaDeCreditoMVC.Entidades.ViewModels.CarteraDeConsumo;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Web.Classes;

namespace TarjetaDeCreditoMVC.Web.Controllers
{
    public class CarterasDeConsumosController : Controller
    {
        readonly IServicioCarteraDeConsumo _servicio;
        readonly IMapper _mapper;
        readonly string folder = "~/Content/Imagenes/CarteraDeConsumo/";
        public CarterasDeConsumosController(IServicioCarteraDeConsumo servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: CarterasDeConsumos
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<CarteraDeConsumoListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //return View();

            CarteraDeConsumoEditViewModel carteraDeConsumoVm = new CarteraDeConsumoEditViewModel
            {
                Imagen = $"SinImagenDisponible.jpg"
            };
            return View(carteraDeConsumoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarteraDeConsumoEditViewModel ccVm)
        {
            if (!ModelState.IsValid)
            {
                ccVm.Imagen = $"SinImagenDisponible.jpg";
                return View(ccVm);
            }

            CarteraDeConsumoEditDto ccDto = _mapper.Map<CarteraDeConsumoEditDto>(ccVm);
            if (_servicio.Existe(ccDto))
            {
                ModelState.AddModelError(string.Empty, "Registro repetido");
                ccVm.Imagen = $"SinImagenDisponible.jpg";
                return View(ccVm);
            }

            try
            {
                if (ccVm.ImagenFile != null)
                {
                    ccDto.Imagen = $"{ccVm.ImagenFile.FileName}";
                }
                _servicio.Guardar(ccDto);
                if (ccVm.ImagenFile != null)
                {
                    var file = $"{ccVm.ImagenFile.FileName}";
                    var response = FileHelper.UploadPhoto(ccVm.ImagenFile, folder, file);
                }
                TempData["Msg"] = "Nueva cartera de consumo guardada";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                ccVm.Imagen = $"SinImagenDisponible.jpg";
                return View(ccVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CarteraDeConsumoEditDto ccDto = _servicio.GetCarteraDeConsumoId(id);
            if (ccDto == null)
            {
                return HttpNotFound("Registro inexistente");
            }
            
            CarteraDeConsumoEditViewModel ccVm = _mapper.Map<CarteraDeConsumoEditViewModel>(ccDto);
            return View(ccVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CarteraDeConsumoEditViewModel ccVm)
        {
            try
            {
                ccVm = _mapper.Map<CarteraDeConsumoEditViewModel>(_servicio.GetCarteraDeConsumoId(ccVm.CarteraDeConsumoId));

                _servicio.Borrar(ccVm.CarteraDeConsumoId);
                TempData["Msg"] = "Cartera de consumo eliminada";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(ccVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CarteraDeConsumoEditDto ccDto = _servicio.GetCarteraDeConsumoId(id);
            CarteraDeConsumoEditViewModel ccVm = _mapper.Map<CarteraDeConsumoEditViewModel>(ccDto);
            if (ccVm.Imagen == null)
            {
                ccVm.Imagen = $"SinImagenDisponible.jpg";
            }
            else
            {
                ccVm.Imagen = $"{ccVm.Imagen}";
            }
            return View(ccVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarteraDeConsumoEditViewModel ccVm)
        {
            if (!ModelState.IsValid)
            {
                ccVm.Imagen = $"SinImagenDisponible.jpg";
                return View(ccVm);
            }

            CarteraDeConsumoEditDto ccDto = _mapper.Map<CarteraDeConsumoEditDto>(ccVm);
            if (_servicio.Existe(ccDto))
            {
                ModelState.AddModelError(string.Empty, "Registro repetido");
                ccVm.Imagen = $"SinImagenDisponible.jpg";
                return View(ccVm);
            }

            try
            {
                if (ccVm.ImagenFile != null)
                {
                    ccDto.Imagen = $"{ccVm.ImagenFile.FileName}";
                }
                _servicio.Guardar(ccDto);
                if (ccVm.ImagenFile != null)
                {
                    var file = $"{ccVm.ImagenFile.FileName}";
                    var response = FileHelper.UploadPhoto(ccVm.ImagenFile, folder, file);
                }
                TempData["Msg"] = "Cartera de consumo modificada";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                ccVm.Imagen = $"{folder}SinImagenDisponible.jpg";
                return View(ccVm);
            }
        }

    }
}