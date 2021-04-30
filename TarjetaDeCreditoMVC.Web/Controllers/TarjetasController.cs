using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TarjetaDeCreditoMVC.Entidades.DTOs.Tarjetas;
using TarjetaDeCreditoMVC.Entidades.ViewModels.CarteraDeConsumo;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Cliente;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Tarjeta;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Web.Controllers
{
    public class TarjetasController : Controller
    {
        readonly IServicioTarjeta _servicio;
        readonly IServicioCliente _servicioCliente;
        readonly IServicioCarteraDeConsumo _servicioCarteraDeConsumo;
        readonly IMapper _mapper;
        public TarjetasController(IServicioTarjeta servicio, IServicioCliente serviciosCliente, IServicioCarteraDeConsumo serviciosCarteraDeConsumo)
        {
            _servicio = servicio;
            _servicioCliente = serviciosCliente;
            _servicioCarteraDeConsumo = serviciosCarteraDeConsumo;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: Tarjetas
        public ActionResult Index(string cliente = null, string carteraDeConsumo = null)
        {
            var listaDto = _servicio.GetLista(cliente, carteraDeConsumo);
            var listaVm = _mapper.Map<List<TarjetaListViewModel>>(listaDto);

            var tarjetaFilterVm = new TarjetaFilterListViewModel
            {
                Tarjetas = listaVm,
                CarterasDeConsumos = _mapper.Map<List<CarteraDeConsumoListViewModel>>(_servicioCarteraDeConsumo.GetLista())
            };
            return View(tarjetaFilterVm);
        }
        [HttpGet]
        public ActionResult Create()
        {
            TarjetaEditViewModel tVm = new TarjetaEditViewModel
            {
                CarteraDeConsumo = _mapper.Map<List<CarteraDeConsumoListViewModel>>(_servicioCarteraDeConsumo.GetLista()),
                Clientes = _mapper.Map<List<ClienteListViewModel>>(_servicioCliente.GetLista(null, null, null))
            };
            return View(tVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TarjetaEditViewModel tVm)
        {
            if (!ModelState.IsValid)
            {
                tVm.CarteraDeConsumo = _mapper.Map<List<CarteraDeConsumoListViewModel>>(_servicioCarteraDeConsumo.GetLista());
                tVm.Clientes = _mapper.Map<List<ClienteListViewModel>>(_servicioCliente.GetLista(null, null,null));
                return View(tVm);
            }

            TarjetaEditDto tarjetaDto = _mapper.Map<TarjetaEditDto>(tVm);
            if (_servicio.Existe(tarjetaDto))
            {
                ModelState.AddModelError(string.Empty, @"Tarjeta existente");
                tVm.CarteraDeConsumo = _mapper.Map<List<CarteraDeConsumoListViewModel>>(_servicioCarteraDeConsumo.GetLista());
                tVm.Clientes = _mapper.Map<List<ClienteListViewModel>>(_servicioCliente.GetLista(null,null,null));
                return View(tVm);
            }

            try
            {
                _servicio.Guardar(tarjetaDto);

                TempData["Msg"] = "Tarjeta agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                tVm.CarteraDeConsumo = _mapper.Map<List<CarteraDeConsumoListViewModel>>(_servicioCarteraDeConsumo.GetLista());
                tVm.Clientes = _mapper.Map<List<ClienteListViewModel>>(_servicioCliente.GetLista(null, null, null));
                return View(tVm);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TarjetaEditDto tEditDto = _servicio.GetTarjetaPorId(id);
            TarjetaEditViewModel tVm = _mapper.Map<TarjetaEditViewModel>(tEditDto);
            tVm.CarteraDeConsumo = _mapper.Map<List<CarteraDeConsumoListViewModel>>(_servicioCarteraDeConsumo.GetLista());
            tVm.Clientes = _mapper.Map<List<ClienteListViewModel>>(_servicioCliente.GetLista(null, null, null));
            return View(tVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TarjetaEditViewModel tVm)
        {
            if (!ModelState.IsValid)
            {
                tVm.CarteraDeConsumo = _mapper.Map<List<CarteraDeConsumoListViewModel>>(_servicioCarteraDeConsumo.GetLista());
                tVm.Clientes = _mapper.Map<List<ClienteListViewModel>>(_servicioCliente.GetLista(null, null, null));
                return View(tVm);
            }

            TarjetaEditDto tDto = _mapper.Map<TarjetaEditDto>(tVm);
            if (_servicio.Existe(tDto))
            {
                tVm.CarteraDeConsumo = _mapper.Map<List<CarteraDeConsumoListViewModel>>(_servicioCarteraDeConsumo.GetLista());
                tVm.Clientes = _mapper.Map<List<ClienteListViewModel>>(_servicioCliente.GetLista(null, null, null));
                return View(tVm);
            }

            try
            {
                _servicio.Guardar(tDto);
                TempData["Msg"] = "Tarjeta editado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                tVm.CarteraDeConsumo = _mapper.Map<List<CarteraDeConsumoListViewModel>>(_servicioCarteraDeConsumo.GetLista());
                tVm.Clientes = _mapper.Map<List<ClienteListViewModel>>(_servicioCliente.GetLista(null, null, null));
                return View(tVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TarjetaEditDto tEditDto = _servicio.GetTarjetaPorId(id);
            if (tEditDto == null)
            {
                return HttpNotFound("Tarjeta inexistente");
            }

            TarjetaListDto tDto = _mapper.Map<TarjetaListDto>(_servicio.GetTarjetaPorId(id));
            var carteraDeConsumo = _servicioCarteraDeConsumo.GetCarteraDeConsumoId(tEditDto.CarteraDeConsumoId);
            var cliente = _servicioCliente.GetClientePorId(tEditDto.ClienteId);
            tDto.CarteraDeConsumo = carteraDeConsumo.Descripcion;
            tDto.Cliente = cliente.NumeroDeDocumento;

            TarjetaListViewModel tVm = _mapper.Map<TarjetaListViewModel>(tDto);

            return View(tVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TarjetaListViewModel tVm)
        {
            try
            {
                TarjetaListDto tDto = _mapper.Map<TarjetaListDto>(_servicio.GetTarjetaPorId(tVm.TarjetaId));
                tVm = _mapper.Map<TarjetaListViewModel>(tDto);

                _servicio.Borrar(tVm.TarjetaId);
                TempData["Msg"] = "Tarjeta eliminado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(tVm);
            }
        }
    }
}