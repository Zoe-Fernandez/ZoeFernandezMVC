using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Windows.Ninject;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmCarteraDeConsumo frm = DI.Create<frmCarteraDeConsumo>();
            frm.ShowDialog(this);
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            //frmTarjeta frm = DI.Create<frmTarjeta>();
            //frm.ShowDialog(this);
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmCliente frm = DI.Create<frmCliente>();
            frm.ShowDialog(this);
        }

        private void btnDocumento_Click(object sender, EventArgs e)
        {
            frmTipoDeDocumento frm = DI.Create<frmTipoDeDocumento>();
            frm.ShowDialog(this);
        }

        private void btnProv_Click(object sender, EventArgs e)
        {
            frmProvincia frm = DI.Create<frmProvincia>();
            frm.ShowDialog(this);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            frmLocalidad frm = DI.Create<frmLocalidad>();
            frm.ShowDialog(this);
        }

        private void btnComercio_Click(object sender, EventArgs e)
        {
            frmComercio frm = DI.Create<frmComercio>();
            frm.ShowDialog(this);
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            //frmCompra frm = DI.Create<frmCompra>();
            //frm.ShowDialog(this);
        }
    }
}