using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarterasDeConsumos;
using TarjetaDeCreditoMVC.Entidades.DTOs.Localidades;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;
using TarjetaDeCreditoMVC.Entidades.DTOs.TiposDeDocumentos;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Windows.Ninject;

namespace TarjetaDeCreditoMVC.Windows.Helper
{
    public class Helper
    {
        public static void CargarComboProvincias(ref ComboBox combo)
        {
            IServicioProvincia serviciosProvincia = DI.Create<IServicioProvincia>();
            var lista = serviciosProvincia.GetProvincias();
            var defaultProvincia = new ProvinciaListDto
            {
                ProvinciaId = 0,
                NombreProvincia = "<Seleccione una provincia>"
            };
            lista.Insert(0, defaultProvincia);
            combo.DataSource = lista;
            combo.ValueMember = "ProvinciaId";
            combo.DisplayMember = "NombreProvincia";
            combo.SelectedIndex = 0;



        }
        public static void CargarComboCarteras(ref ComboBox combo)
        {
            IServicioCarteraDeConsumo servicioCarteraDeConsumo = DI.Create<IServicioCarteraDeConsumo>();
            var lista = servicioCarteraDeConsumo.GetLista();
            var defaultTipo = new CarteraDeConsumoListDto
            {
                CarteraDeConsumoId = 0,
                Descripcion = "<Seleccione una cartera de consumo>"
            };
            lista.Insert(0, defaultTipo);
            combo.DataSource = lista;
            combo.ValueMember = "CarteraDeConsumoId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboDocumentos(ref ComboBox combo)
        {
            IServicioTipoDeDocumento servicioTipoDeDocumento = DI.Create<IServicioTipoDeDocumento>();
            var lista = servicioTipoDeDocumento.GetTipoDeDocumentos();
            var defaultTipoDeDocumento = new TipoDeDocumentoListDto
            {
                TipoDeDocumentoId = 0,
                Descripcion = "<Seleccione un documento>"
            };
            lista.Insert(0, defaultTipoDeDocumento);
            combo.DataSource = lista;
            combo.ValueMember = "TipoDeDocumentoId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }

        public static void CargarDatosComboLocalidades(ref ComboBox cboLocalidad, string provinciaId)
        {
            IServicioLocalidad servicioLocalidad = DI.Create<IServicioLocalidad>();
            var lista = servicioLocalidad.GetLista(provinciaId);
            var defaultObjeto = new LocalidadListDto
            {
                NombreLocalidad = "<Seleccione Localidad>",
                Provincia = null
            };
            lista.Insert(0, defaultObjeto);
            cboLocalidad.ValueMember = "LocalidadId";
            cboLocalidad.DisplayMember = "NombreLocalidad";
            cboLocalidad.DataSource = lista;
            cboLocalidad.SelectedIndex = 0;

        }

       

        
    }
}
