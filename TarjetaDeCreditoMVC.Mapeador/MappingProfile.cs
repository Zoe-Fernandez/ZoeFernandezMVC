using AutoMapper;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarterasDeConsumos;
using TarjetaDeCreditoMVC.Entidades.DTOs.Clientes;
using TarjetaDeCreditoMVC.Entidades.DTOs.Comercios;
using TarjetaDeCreditoMVC.Entidades.DTOs.Localidades;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;
using TarjetaDeCreditoMVC.Entidades.DTOs.Tarjetas;
using TarjetaDeCreditoMVC.Entidades.DTOs.TiposDeDocumentos;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Entidades.ViewModels.CarteraDeConsumo;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Cliente;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Comercio;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Localidad;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Tarjeta;
using TarjetaDeCreditoMVC.Entidades.ViewModels.TipoDeDocumento;

namespace TarjetaDeCreditoMVC.Mapeador
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadCarteraDeConsumo();
            LoadProvincia();
            LoadTipoDeDocumento();
            LoadLocalidad();
            LoadComercio();
            LoadTarjeta();
            LoadCliente();
        }

        private void LoadCliente()
        {
            CreateMap<ClienteListDto, ClienteListViewModel>();
            CreateMap<ClienteEditViewModel, ClienteEditDto>().ReverseMap();
            CreateMap<ClienteEditDto, Cliente>().ReverseMap();
            CreateMap<ClienteEditDto, ClienteListDto>();
        }

        private void LoadTarjeta()
        {
            CreateMap<TarjetaListDto, TarjetaListViewModel>();
            CreateMap<TarjetaEditViewModel, TarjetaEditDto>().ReverseMap();
            CreateMap<TarjetaEditDto, Tarjeta>().ReverseMap();
            CreateMap<TarjetaEditDto, TarjetaListDto>();
        }

        private void LoadComercio()
        {
            CreateMap<ComercioListDto, ComercioListViewModel>();
            CreateMap<ComercioEditViewModel, ComercioEditDto>().ReverseMap();
            CreateMap<ComercioEditDto, Comercio>().ReverseMap();
            CreateMap<ComercioEditDto, ComercioListDto>();

            
        }

        private void LoadLocalidad()
        {
            CreateMap<LocalidadListDto, LocalidadListViewModel>();
            CreateMap<LocalidadEditViewModel, LocalidadEditDto>().ReverseMap();
            CreateMap<LocalidadEditDto, Localidad>().ReverseMap();
            CreateMap<LocalidadEditDto, LocalidadListDto>();
        }

        private void LoadTipoDeDocumento()
        {
            CreateMap<TipoDeDocumento, TipoDeDocumentoListDto>();
            CreateMap<TipoDeDocumento, TipoDeDocumentoEditDto>().ReverseMap();
            CreateMap<TipoDeDocumentoListDto, TipoDeDocumentoListViewModel>().ReverseMap();
            CreateMap<TipoDeDocumentoEditDto, TipoDeDocumentoEditViewModel>().ReverseMap();
            CreateMap<TipoDeDocumentoEditDto, TipoDeDocumentoListDto>().ReverseMap();
        }

        private void LoadProvincia()
        {
            CreateMap<Provincia, ProvinciaListDto>();
            CreateMap<Provincia, ProvinciaEditDto>().ReverseMap();
            CreateMap<ProvinciaListDto, ProvinciaListViewModel>().ReverseMap();
            CreateMap<ProvinciaEditDto, ProvinciaEditViewModel>().ReverseMap();
            CreateMap<ProvinciaEditDto, ProvinciaListDto>().ReverseMap();
        }

        private void LoadCarteraDeConsumo()
        {
            CreateMap<CarteraDeConsumo, CarteraDeConsumoListDto>();
            CreateMap<CarteraDeConsumo, CarteraDeConsumoEditDto>().ReverseMap();
            CreateMap<CarteraDeConsumoListDto, CarteraDeConsumoListViewModel>().ReverseMap();
            CreateMap<CarteraDeConsumoEditDto, CarteraDeConsumoEditViewModel>().ReverseMap();
            CreateMap<CarteraDeConsumoEditDto, CarteraDeConsumoListDto>().ReverseMap();
        }
    }
}
