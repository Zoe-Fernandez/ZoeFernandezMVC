using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.TiposDeDocumentos;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Windows.Ninject;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmTipoDeDocumento : Form
    {
        public frmTipoDeDocumento(IServicioTipoDeDocumento servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        IServicioTipoDeDocumento _servicio;
        List<TipoDeDocumentoListDto> _lista;
        IMapper _mapper;
        private void frmTipoDeDocumento_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            try
            {
                _mapper = TarjetaDeCreditoMVC.Mapeador.Mapeador.CrearMapper();
                _lista = _servicio.GetTipoDeDocumentos();
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
            foreach (var documentoDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, documentoDto);
                AgregarFila(r);
            }
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(Datos);
            return r;
        }

        private void SetearFila(DataGridViewRow r, TipoDeDocumentoListDto td)
        {
            r.Cells[cmnDocumento.Index].Value = td.Descripcion;
            r.Tag = td;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            Datos.Rows.Add(r);
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmTipoDeDocumentoAE frm = DI.Create<frmTipoDeDocumentoAE>();
            frm.Text = "Agregar una descripcion de tipo de documento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeDocumentoEditDto tipoDeDocumentoEditDto = frm.GetTipoDeDocumento();
                    if (_servicio.Existe(tipoDeDocumentoEditDto))
                    {
                        MessageBox.Show("Registro repetido",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(tipoDeDocumentoEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var tipoDeDocumentoListDto = _mapper.Map<TipoDeDocumentoListDto>(tipoDeDocumentoEditDto);
                    SetearFila(r, tipoDeDocumentoListDto);
                    AgregarFila(r);
                    MessageBox.Show("Nuevo tipo de documento agregado",
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
            var tipoDeDocumentoDto = r.Tag as TipoDeDocumentoListDto;
            DialogResult dr = MessageBox.Show($"¿Desea eliminar el registro: '{tipoDeDocumentoDto.Descripcion}'?",
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
                _servicio.Borrar(tipoDeDocumentoDto.TipoDeDocumentoId);
                Datos.Rows.Remove(r);
                MessageBox.Show("Tipo de documento eliminado",
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
            var tipoDeDocumentoDto = r.Tag as TipoDeDocumentoListDto;
            var tipoDeDocumentoDtoCopia = (TipoDeDocumentoListDto)tipoDeDocumentoDto.Clone();
            frmTipoDeDocumentoAE frm = DI.Create<frmTipoDeDocumentoAE>();
            frm.Text = "Editar descripcion del tipo de documento";
            TipoDeDocumentoEditDto tipoDeDocumentoEditDto = _mapper.Map<TipoDeDocumentoEditDto>(tipoDeDocumentoDto);
            frm.SetTipoDeDocumento(tipoDeDocumentoEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            tipoDeDocumentoEditDto = frm.GetTipoDeDocumento();
            if (_servicio.Existe(tipoDeDocumentoEditDto))
            {
                MessageBox.Show("Registro repetido",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                SetearFila(r, tipoDeDocumentoDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(tipoDeDocumentoEditDto);
                var tipoDeDocumentoListDto = _mapper.Map<TipoDeDocumentoListDto>(tipoDeDocumentoEditDto);
                SetearFila(r, tipoDeDocumentoListDto);
                MessageBox.Show("Descripcion modificada",
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
                SetearFila(r, tipoDeDocumentoDtoCopia);
            }
        }
    }
}
