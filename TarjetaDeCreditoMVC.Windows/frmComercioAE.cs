using System;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.Comercios;
using TarjetaDeCreditoMVC.Entidades.DTOs.Localidades;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;
using TarjetaDeCreditoMVC.Entidades.Entidades;
using TarjetaDeCreditoMVC.Entidades.ViewModels.Comercio;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmComercioAE : Form
    {
        public frmComercioAE()
        {
            InitializeComponent();
        }
        ComercioEditDto comercioDto;
        ComercioListViewModel comercioListView;
        public ComercioEditDto GetComercio()
        {
            return comercioDto;
        }

        public void SetComercio(ComercioEditDto comercioEditDto)
        {
            comercioDto = comercioEditDto;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboProvincias(ref cboProvincia);
            if (comercioDto != null)
            {
                txtRazonSocial.Text = comercioDto.RazonSocial;
                txtPersonaContacto.Text = comercioDto.PersonaDeContacto;
                cboProvincia.SelectedValue = comercioDto.ProvinciaId;
                Helper.Helper.CargarDatosComboLocalidades(ref cboLocalidad, provinciaDto.NombreProvincia);
                cboLocalidad.SelectedValue = comercioDto.LocalidadId;
                txtDireccion.Text = comercioDto.Direccion;
                txtFijo.Text = comercioDto.TelefonoFijo;
                txtMovil.Text = comercioDto.TelefonoMovil;
                txtCorreo.Text = comercioDto.CorreoElectronico;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (comercioDto == null)
                {
                    comercioDto = new ComercioEditDto();
                }

                comercioDto.RazonSocial = txtRazonSocial.Text;
                comercioDto.PersonaDeContacto = txtPersonaContacto.Text;
                comercioDto.ProvinciaId = ((ProvinciaListDto)cboProvincia.SelectedItem).ProvinciaId;
                comercioDto.LocalidadId = ((LocalidadListDto)cboLocalidad.SelectedItem).LocalidadId; ;
                comercioDto.Direccion = txtDireccion.Text;
                comercioDto.TelefonoFijo = txtFijo.Text;
                comercioDto.TelefonoMovil = txtMovil.Text;
                comercioDto.CorreoElectronico = txtCorreo.Text;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtRazonSocial.Text)
                || string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                valido = false;
                errorProvider1.SetError(txtRazonSocial, "Registro requerido");
            }

            if (string.IsNullOrEmpty(txtPersonaContacto.Text)
                || string.IsNullOrWhiteSpace(txtPersonaContacto.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPersonaContacto, "Registro requerido");
            }

            if (cboLocalidad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboLocalidad, "Debe seleccionar una localidad");
            }

            if (cboProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProvincia, "Debe seleccionar una provincia");
            }

            if (string.IsNullOrEmpty(txtDireccion.Text)
                || string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDireccion, "Registro requerido");
            }
            if (string.IsNullOrEmpty(txtCorreo.Text)
                && string.IsNullOrEmpty(txtFijo.Text)
                && string.IsNullOrEmpty(txtMovil.Text))
            {
                valido = false;
                errorProvider1.SetError(txtMovil, "Debe ingresar al menos un medio de comunicación");
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        ProvinciaListDto provinciaDto;
        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex > 0)
            {
                provinciaDto = (ProvinciaListDto)cboProvincia.SelectedItem;
                Helper.Helper.CargarDatosComboLocalidades(ref cboLocalidad, provinciaDto.NombreProvincia);
            }
            else
            {
                provinciaDto = null;
                cboLocalidad.DataSource = null;
            }
        }
    }
}
