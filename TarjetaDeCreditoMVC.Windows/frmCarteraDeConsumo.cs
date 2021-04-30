using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.CarterasDeConsumos;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Windows.Ninject;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmCarteraDeConsumo : Form
    {
        public frmCarteraDeConsumo(IServicioCarteraDeConsumo servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        IServicioCarteraDeConsumo _servicio;
        List<CarteraDeConsumoListDto> _lista;
        IMapper _mapper;
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCarteraDeConsumo_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            try
            {
                _mapper = TarjetaDeCreditoMVC.Mapeador.Mapeador.CrearMapper();
                _lista = _servicio.GetLista();
                MostrarDatosEnLaGrilla();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void MostrarDatosEnLaGrilla()
        {
            Datos.Rows.Clear();
            foreach (var carteraDeConsumoDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, carteraDeConsumoDto);
                AgregarFila(r);
            }
        }

        #region En la grilla
        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(Datos);
            return r;
        }

        private void SetearFila(DataGridViewRow r, CarteraDeConsumoListDto cc)
        {
            r.Cells[cmnDescripcion.Index].Value = cc.Descripcion;
            r.Cells[cmnLimiteCredito.Index].Value = cc.LimiteDeCredito;
            r.Cells[cmnCostoRenovacion.Index].Value = cc.CostoDeRenovacion;
            r.Tag = cc;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            Datos.Rows.Add(r);
        }
        #endregion


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCarteraDeConsumoAE frm = DI.Create<frmCarteraDeConsumoAE>();
            frm.Text = "Agregar una cartera de consumo";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    CarteraDeConsumoEditDto carteraDeConsumoEditDto = frm.GetCarteraDeConsumo();
                    if (_servicio.Existe(carteraDeConsumoEditDto))
                    {
                        MessageBox.Show("Registro repetido",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(carteraDeConsumoEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var carteraDeConsumoListDto = _mapper.Map<CarteraDeConsumoListDto>(carteraDeConsumoEditDto);
                    SetearFila(r, carteraDeConsumoListDto);
                    AgregarFila(r);
                    MessageBox.Show("Nueva cartera de consumo agregada",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (Datos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = Datos.SelectedRows[0];
            var carteraDeConsumoDto = r.Tag as CarteraDeConsumoListDto;
            DialogResult dr = MessageBox.Show($"¿Desea eliminar el registro: '{carteraDeConsumoDto.Descripcion}'?",
                "Confirmar borrar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(carteraDeConsumoDto.CarteraDeConsumoId);
                Datos.Rows.Remove(r);
                MessageBox.Show("Cartera de consumo eliminada",
                    "Mensaje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (Datos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = Datos.SelectedRows[0];
            var carteraDeConsumoDto = r.Tag as CarteraDeConsumoListDto;
            var carteraDeConsumoDtoCopia = (CarteraDeConsumoListDto)carteraDeConsumoDto.Clone();
            frmCarteraDeConsumoAE frm = DI.Create<frmCarteraDeConsumoAE>();
            frm.Text = "Editar registo de la cartera de consumo";
            CarteraDeConsumoEditDto carteraEditDto = _mapper.Map<CarteraDeConsumoEditDto>(carteraDeConsumoDto);
            frm.SetCarteraDeConsumo(carteraEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            carteraEditDto = frm.GetCarteraDeConsumo();
            if (_servicio.Existe(carteraEditDto))
            {
                MessageBox.Show("Registro repetido",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                SetearFila(r, carteraDeConsumoDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(carteraEditDto);
                var carteraDeConsumoListDto = _mapper.Map<CarteraDeConsumoListDto>(carteraEditDto);
                SetearFila(r, carteraDeConsumoListDto);
                MessageBox.Show("Registro de la cartera de consumo modificado",
                    "Mensaje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                SetearFila(r, carteraDeConsumoDtoCopia);
            }
        }
    }
}
