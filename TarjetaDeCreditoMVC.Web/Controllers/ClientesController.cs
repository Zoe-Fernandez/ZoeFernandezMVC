using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TarjetaDeCreditoMVC.Entidades.DTOs.Clientes;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Cliente;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Localidad;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia;
using TarjetaDeCreditoMVC.Entidades.ViewModels.TipoDeDocumento;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;

namespace TarjetaDeCreditoMVC.Web.Controllers
{
    public class ClientesController : Controller
    {
        readonly IServicioCliente _servicio;
        readonly IServicioProvincia _servicioProvincia;
        readonly IServicioLocalidad _servicioLocalidad;
        readonly IServicioTipoDeDocumento _servicioTipoDeDocumento;
        readonly IMapper _mapper;
        public ClientesController(IServicioCliente servicio, IServicioProvincia serviciosProvincia, IServicioLocalidad serviciosLocalidad, IServicioTipoDeDocumento serviciosTipoDeDocumento)
        {
            _servicio = servicio;
            _servicioProvincia = serviciosProvincia;
            _servicioLocalidad = serviciosLocalidad;
            _servicioTipoDeDocumento = serviciosTipoDeDocumento;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: Cliente
        public ActionResult Index(string localidad = null, string provincia = null, string tipoDeDocumento=null)
        {
            var listaDto = _servicio.GetLista(localidad, provincia, tipoDeDocumento);
            var listaVm = _mapper.Map<List<ClienteListViewModel>>(listaDto);

            var clienteFilterVm = new ClienteFilterListViewModel
            {
                Clientes = listaVm,
                Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias())
            };
            return View(clienteFilterVm);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ClienteEditViewModel cVm = new ClienteEditViewModel
            {
                Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias()),
                Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null)),
                TiposDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_servicioTipoDeDocumento.GetTipoDeDocumentos())
            };
            return View(cVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEditViewModel cVm)
        {
            if (!ModelState.IsValid)
            {
                cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
                cVm.TiposDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_servicioTipoDeDocumento.GetTipoDeDocumentos());
                return View(cVm);
            }

            ClienteEditDto clienteDto = _mapper.Map<ClienteEditDto>(cVm);
            if (_servicio.Existe(clienteDto))
            {
                ModelState.AddModelError(string.Empty, @"Cliente existente");
                cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
                cVm.TiposDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_servicioTipoDeDocumento.GetTipoDeDocumentos());
                return View(cVm);
            }

            try
            {
                _servicio.Guardar(clienteDto);

                TempData["Msg"] = "Cliente agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
                cVm.TiposDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_servicioTipoDeDocumento.GetTipoDeDocumentos());
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

            ClienteEditDto cEditDto = _servicio.GetClientePorId(id);
            ClienteEditViewModel cVm = _mapper.Map<ClienteEditViewModel>(cEditDto);
            cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
            cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
            cVm.TiposDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_servicioTipoDeDocumento.GetTipoDeDocumentos());
            return View(cVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteEditViewModel cVm)
        {
            if (!ModelState.IsValid)
            {
                cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
                cVm.TiposDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_servicioTipoDeDocumento.GetTipoDeDocumentos());
                return View(cVm);
            }

            ClienteEditDto cDto = _mapper.Map<ClienteEditDto>(cVm);
            if (_servicio.Existe(cDto))
            {
                cVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetProvincias());
                cVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));
                cVm.TiposDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_servicioTipoDeDocumento.GetTipoDeDocumentos());
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
                cVm.TiposDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_servicioTipoDeDocumento.GetTipoDeDocumentos());
                return View(cVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClienteEditDto cEditDto = _servicio.GetClientePorId(id);
            if (cEditDto == null)
            {
                return HttpNotFound("Cliente inexistente");
            }

            ClienteListDto cDto = _mapper.Map<ClienteListDto>(_servicio.GetClientePorId(id));
            var provincia = _servicioProvincia.GetProvinciaId(cEditDto.ProvinciaId);
            var localidad = _servicioLocalidad.GetLocalidadPorId(cEditDto.LocalidadId);
            var tipoDeDocumento = _servicioTipoDeDocumento.GetTipoDeDocumentoId(cEditDto.TipoDeDocumentoId);
            cDto.Provincia = provincia.NombreProvincia;
            cDto.Localidad = localidad.NombreLocalidad;
            cDto.TipoDeDocumento = tipoDeDocumento.Descripcion;

            ClienteListViewModel cVm = _mapper.Map<ClienteListViewModel>(cDto);

            return View(cVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClienteListViewModel cVm)
        {
            try
            {
                ClienteListDto cDto = _mapper.Map<ClienteListDto>(_servicio.GetClientePorId(cVm.ClienteId));
                cVm = _mapper.Map<ClienteListViewModel>(cDto);

                _servicio.Borrar(cVm.ClienteId);
                TempData["Msg"] = "Cliente eliminado";
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