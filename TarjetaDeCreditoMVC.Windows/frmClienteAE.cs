using System;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.Clientes;
using TarjetaDeCreditoMVC.Entidades.DTOs.Localidades;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;
using TarjetaDeCreditoMVC.Entidades.DTOs.TiposDeDocumentos;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmClienteAE : Form
    {
        public frmClienteAE()
        {
            InitializeComponent();
        }

        ClienteEditDto clienteDto;
        //ClienteListViewModel clienteListView;
        ProvinciaListDto provinciaDto;
        public ClienteEditDto GetCliente()
        {
            return clienteDto;
        }

        public void SetCliente(ClienteEditDto clienteEditDro)
        {
            clienteDto = clienteEditDro;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboProvincias(ref cboProvincia);
            Helper.Helper.CargarComboDocumentos(ref cboDocumento);
            if (clienteDto != null)
            {
                txtNombres.Text = clienteDto.Nombre;
                txtApellido.Text = clienteDto.Apellido;
                cboDocumento.SelectedValue = clienteDto.TipoDeDocumentoId;
                cboProvincia.SelectedValue = clienteDto.ProvinciaId;
                Helper.Helper.CargarDatosComboLocalidades(ref cboLocalidad, provinciaDto.NombreProvincia);
                cboLocalidad.SelectedValue = clienteDto.LocalidadId;
                txtDireccion.Text = clienteDto.Direccion;
                txtTelefonoFijo.Text = clienteDto.TelefonoFijo;
                txtTelefonoMovil.Text = clienteDto.TelefonoMovil;
                txtEmail.Text = clienteDto.CorreoElectronico;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (clienteDto == null)
                {
                    clienteDto = new ClienteEditDto();
                }

                clienteDto.Nombre = txtNombres.Text;
                clienteDto.Apellido = txtApellido.Text;
                clienteDto.NumeroDeDocumento = txtNroDoc.Text;
                clienteDto.TipoDeDocumentoId = ((TipoDeDocumentoListDto)cboDocumento.SelectedItem).TipoDeDocumentoId;
                clienteDto.FechaDeNacimiento = dtpFechaNac.Value.Date;
                clienteDto.ProvinciaId = ((ProvinciaListDto)cboProvincia.SelectedItem).ProvinciaId;
                clienteDto.LocalidadId = ((LocalidadListDto)cboLocalidad.SelectedItem).LocalidadId; ;
                clienteDto.Direccion = txtDireccion.Text;
                clienteDto.TelefonoFijo = txtTelefonoFijo.Text;
                clienteDto.TelefonoMovil = txtTelefonoMovil.Text;
                clienteDto.CorreoElectronico = txtEmail.Text;
                clienteDto.Suspendido = cbSuspendido.Checked;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (dtpFechaNac.Value > DateTime.Now)
            {
                valido = false;
                errorProvider1.SetError(dtpFechaNac, "Fecha superior a la fecha actual");
            }
            if (cbSuspendido.Checked)
            {
                valido = false;
                errorProvider1.SetError(cbSuspendido, "No es posible guardar el cliente");
            }
            if (string.IsNullOrEmpty(txtNroDoc.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNroDoc, "Debe ingresar un DNI");
            }

            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "Debe ingresar un apellido");
            }

            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombres, "Debe ingresar un nombre");
            }

            if (cboProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProvincia, "Debe seleccionar una provincia");
            }

            if (cboLocalidad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboLocalidad, "Debe seleccionar una localidad");
            }

            if (cboDocumento.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboLocalidad, "Debe seleccionar un documento");
            }

            if (string.IsNullOrEmpty(txtEmail.Text)
                && string.IsNullOrEmpty(txtTelefonoFijo.Text)
                && string.IsNullOrEmpty(txtTelefonoMovil.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTelefonoFijo, "Debe ingresar al menos un medio de comunicación");
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

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
