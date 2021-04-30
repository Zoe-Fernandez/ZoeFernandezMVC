using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.Localidades;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Windows.Ninject;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmLocalidad : Form
    {
        public frmLocalidad(IServicioLocalidad servicio, IServicioProvincia serviciosProvincia)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioProvincia = serviciosProvincia;
        }

        IServicioLocalidad _servicio;
        IServicioProvincia _servicioProvincia;
        List<LocalidadListDto> _lista;
        IMapper _mapper;
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLocalidad_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _mapper = TarjetaDeCreditoMVC.Mapeador.Mapeador.CrearMapper();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            try
            {
                _lista = _servicio.GetLista(null);
                MostrarDatosEnLaGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, 
                    "Error",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnLaGrilla()
        {
            Datos.Rows.Clear();
            foreach (var localidadDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, localidadDto);
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

        private void SetearFila(DataGridViewRow r, LocalidadListDto l)
        {
            r.Cells[cmnNombreLocalidad.Index].Value = l.NombreLocalidad;
            r.Cells[cmnNombreProvincia.Index].Value = l.Provincia;
            r.Tag = l;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            Datos.Rows.Add(r);
        }
        #endregion

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmLocalidadAE frm = DI.Create<frmLocalidadAE>();
            frm.Text = "Agregar localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    LocalidadEditDto lEditDto = frm.GetLocalidad();
                    if (_servicio.Existe(lEditDto))
                    {
                        MessageBox.Show("Registro repetido", 
                            "Error", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(lEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var lListDto = _mapper.Map<LocalidadListDto>(lEditDto);
                    lListDto.Provincia = (_servicioProvincia.GetProvinciaId(lEditDto.ProvinciaId)) .NombreProvincia;
                    SetearFila(r, lListDto);
                    AgregarFila(r);
                    MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (Datos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = Datos.SelectedRows[0];
            var lListDto = r.Tag as LocalidadListDto;
            var lListDtoCopia = (LocalidadListDto)lListDto.Clone();
            frmLocalidadAE frm = DI.Create<frmLocalidadAE>();
            frm.Text = "Editar localidad";
            LocalidadEditDto lEditDto = _servicio.GetLocalidadPorId(lListDto.LocalidadId);
            frm.SetLocalidad(lEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            lEditDto = frm.GetLocalidad();
            if (_servicio.Existe(lEditDto))
            {
                MessageBox.Show("Registro repetido", 
                    "Error",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                SetearFila(r, lListDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(lEditDto);
                lListDto = _mapper.Map<LocalidadListDto>(lEditDto);
                lListDto.Provincia = (_servicioProvincia
                    .GetProvinciaId(lEditDto.ProvinciaId)).NombreProvincia;
                SetearFila(r, lListDto);
                MessageBox.Show("Registro modificado",
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
                SetearFila(r, lListDtoCopia);


            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (Datos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = Datos.SelectedRows[0];
            var lDto = r.Tag as LocalidadListDto;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {lDto.NombreLocalidad}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(lDto.LocalidadId);
                Datos.Rows.Remove(r);
                MessageBox.Show("Registro borrado", 
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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}
