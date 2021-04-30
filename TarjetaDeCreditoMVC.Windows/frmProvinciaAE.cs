using System;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarterasDeConsumos;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmProvinciaAE : Form
    {
        public frmProvinciaAE()
        {
            InitializeComponent();
        }

        ProvinciaEditDto provinciaDto;

        public ProvinciaEditDto GetProvincia()
        {
            return provinciaDto;
        }

        public void SetProvincia(ProvinciaEditDto provinciaEditDto)
        {
            provinciaDto = provinciaEditDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (provinciaDto != null)
            {
                NombreProviniciaBox.Text = provinciaDto.NombreProvincia;
            }
        }
    

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (provinciaDto == null)
                {
                    provinciaDto = new ProvinciaEditDto();

                }

                provinciaDto.NombreProvincia = NombreProviniciaBox.Text;
                DialogResult = DialogResult.OK;
            }

        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(NombreProviniciaBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(NombreProviniciaBox, "Registro requerido");
            }
            return valido;
        }
    }
}
