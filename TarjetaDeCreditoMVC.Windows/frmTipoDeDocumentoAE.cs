using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.TiposDeDocumentos;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmTipoDeDocumentoAE : Form
    {
        public frmTipoDeDocumentoAE()
        {
            InitializeComponent();
        }

        TipoDeDocumentoEditDto tipoDeDocumentoDto;
        public TipoDeDocumentoEditDto GetTipoDeDocumento()
        {
            return tipoDeDocumentoDto;
        }

        public void SetTipoDeDocumento(TipoDeDocumentoEditDto tipoDeDocumentoEditDto)
        {
            tipoDeDocumentoDto = tipoDeDocumentoEditDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoDeDocumentoDto != null)
            {
                DescripcionBox.Text = tipoDeDocumentoDto.Descripcion;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoDeDocumentoDto == null)
                {
                    tipoDeDocumentoDto = new TipoDeDocumentoEditDto();

                }

                tipoDeDocumentoDto.Descripcion = DescripcionBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(DescripcionBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(DescripcionBox, "Registro requerido");
            }
            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
