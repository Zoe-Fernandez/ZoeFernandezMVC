using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.Provincias;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Windows.Ninject;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmProvincia : Form
    {
        public frmProvincia(IServicioProvincia servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        IServicioProvincia _servicio;
        List<ProvinciaListDto> _lista;
        IMapper _mapper;
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProvincia_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            try
            {
                _mapper = TarjetaDeCreditoMVC.Mapeador.Mapeador.CrearMapper();
                _lista = _servicio.GetProvincias();
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
            foreach (var provinciaDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, provinciaDto);
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

        private void SetearFila(DataGridViewRow r, ProvinciaListDto p)
        {
            r.Cells[cmnNombreProvincia.Index].Value = p.NombreProvincia;
            r.Tag = p;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            Datos.Rows.Add(r);
        }
        #endregion
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProvinciaAE frm = DI.Create<frmProvinciaAE>();
            frm.Text = "Agregar una provincia";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ProvinciaEditDto provinciaEditDto = frm.GetProvincia();
                    if (_servicio.Existe(provinciaEditDto))
                    {
                        MessageBox.Show("Registro repetido",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(provinciaEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var pListDto = _mapper.Map<ProvinciaListDto>(provinciaEditDto);
                    SetearFila(r, pListDto);
                    AgregarFila(r);
                    MessageBox.Show("Nueva provincia agregada",
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
            var provinciaDto = r.Tag as ProvinciaListDto;
            DialogResult dr = MessageBox.Show($"¿Desea eliminar el registro: '{provinciaDto.NombreProvincia}'?",
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
                _servicio.Borrar(provinciaDto.ProvinciaId);
                Datos.Rows.Remove(r);
                MessageBox.Show("Provincia eliminada",
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
            var provinciaDto = r.Tag as ProvinciaListDto;
            var provinciaDtoCopia = (ProvinciaListDto)provinciaDto.Clone();
            frmProvinciaAE frm = DI.Create<frmProvinciaAE>();
            frm.Text = "Editar nombre de la provincia";
            ProvinciaEditDto provinciaEditDto = _mapper.Map<ProvinciaEditDto>(provinciaDto);
            frm.SetProvincia(provinciaEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            provinciaEditDto = frm.GetProvincia();
            if (_servicio.Existe(provinciaEditDto))
            {
                MessageBox.Show("Registro repetido",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                SetearFila(r, provinciaDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(provinciaEditDto);
                var provinciaListDto = _mapper.Map<ProvinciaListDto>(provinciaEditDto);
                SetearFila(r, provinciaListDto);
                MessageBox.Show("Nombre de la provincia modificada",
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
                SetearFila(r, provinciaDtoCopia);
            }
        }
    }
}
