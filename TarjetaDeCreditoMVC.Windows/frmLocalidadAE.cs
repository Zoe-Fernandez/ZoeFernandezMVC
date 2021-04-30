using System;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.Localidades;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmLocalidadAE : Form
    {
        public frmLocalidadAE()
        {
            InitializeComponent();
        }

        LocalidadEditDto localidadDto;
        public void SetLocalidad(LocalidadEditDto localidadEditDto)
        {
            localidadDto = localidadEditDto;
        }

        public LocalidadEditDto GetLocalidad()
        {
            return localidadDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboProvincias(ref cboProvincia);
            if (localidadDto != null)
            {
                txtNombreLocalidad.Text = localidadDto.NombreLocalidad;
                cboProvincia.SelectedValue = localidadDto.ProvinciaId;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (localidadDto == null)
                {
                    localidadDto = new LocalidadEditDto();
                }

                localidadDto.NombreLocalidad = txtNombreLocalidad.Text;
                localidadDto.ProvinciaId = ((ProvinciaListDto)cboProvincia.SelectedItem).ProvinciaId;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombreLocalidad.Text)
                || string.IsNullOrWhiteSpace(txtNombreLocalidad.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombreLocalidad, "Registro requerido");
            }

            if (cboProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProvincia, "Debe seleccionar una provincia");
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
