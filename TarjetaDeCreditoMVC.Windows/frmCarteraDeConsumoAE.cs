using System;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarterasDeConsumos;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmCarteraDeConsumoAE : Form
    {
        public frmCarteraDeConsumoAE()
        {
            InitializeComponent();
        }

        CarteraDeConsumoEditDto carteraDeConsumoDto;
        public CarteraDeConsumoEditDto GetCarteraDeConsumo()
        {
            return carteraDeConsumoDto;
        }
        public void SetCarteraDeConsumo(CarteraDeConsumoEditDto carteraEditDto)
        {
            carteraDeConsumoDto = carteraEditDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (carteraDeConsumoDto != null)
            {
                DescripcionBox.Text = carteraDeConsumoDto.Descripcion;
                LimiteDeCreditoBox.Text = carteraDeConsumoDto.LimiteDeCredito.ToString();
                CostoDeRenovacionBox.Text = carteraDeConsumoDto.CostoDeRenovacion.ToString();

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (carteraDeConsumoDto == null)
                {
                    carteraDeConsumoDto = new CarteraDeConsumoEditDto();

                }

                carteraDeConsumoDto.Descripcion = DescripcionBox.Text;
                carteraDeConsumoDto.LimiteDeCredito = decimal.Parse(LimiteDeCreditoBox.Text);
                carteraDeConsumoDto.CostoDeRenovacion = decimal.Parse(CostoDeRenovacionBox.Text);
                DialogResult = DialogResult.OK;
            }

        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(DescripcionBox.Text)
                || string.IsNullOrWhiteSpace(DescripcionBox.Text))
            {
                valido = false;
                errorProvider1.SetError(DescripcionBox, "Registro requerido");
            }

            if (LimiteDeCreditoBox.Text == "")
            {
                valido = false;
                LimiteDeCreditoBox.Select(0, LimiteDeCreditoBox.Text.Length);
                errorProvider1.SetError(LimiteDeCreditoBox, "Registro requerido");
            }
            if (LimiteDeCreditoBox.Text == "0")
            {
                valido = false;
                LimiteDeCreditoBox.Select(0, LimiteDeCreditoBox.Text.Length);
                errorProvider1.SetError(LimiteDeCreditoBox, "Debe ingresar un valor decimal");
            }
            if (CostoDeRenovacionBox.Text == "")
            {
                valido = false;
                CostoDeRenovacionBox.Select(0, CostoDeRenovacionBox.Text.Length);
                errorProvider1.SetError(CostoDeRenovacionBox, "Registro requerido");
            }
            if (CostoDeRenovacionBox.Text == "0")
            {
                valido = false;
                CostoDeRenovacionBox.Select(0, CostoDeRenovacionBox.Text.Length);
                errorProvider1.SetError(CostoDeRenovacionBox, "Debe ingresar un valor decimal");
            }
            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
