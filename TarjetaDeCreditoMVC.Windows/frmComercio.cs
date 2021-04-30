using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.Comercios;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Windows.Ninject;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmComercio : Form
    {
        public frmComercio(IServicioComercio servicio, IServicioProvincia servicioProvincia, IServicioLocalidad servicioLocalidad)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioProvincia = servicioProvincia;
            _servicioLocalidad = servicioLocalidad;
        }

        IServicioProvincia _servicioProvincia;
        IServicioLocalidad _servicioLocalidad;
        IServicioComercio _servicio;
        List<ComercioListDto> _lista;
        IMapper _mapper;
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmComercio_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _mapper = TarjetaDeCreditoMVC.Mapeador.Mapeador.CrearMapper();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            try
            {
                _lista = _servicio.GetLista(null, null);
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
            foreach (var comercioDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, comercioDto);
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

        private void SetearFila(DataGridViewRow r, ComercioListDto c)
        {
            r.Cells[cmnRazonSocial.Index].Value = c.RazonSocial;
            r.Cells[cmnPersonaDeContacto.Index].Value = c.PersonaDeContacto;
            r.Cells[cmnDireccion.Index].Value = c.Direccion;
            r.Cells[cmnLocalidad.Index].Value = c.Localidad;
            r.Cells[cmnProvincia.Index].Value = c.Provincia;
            r.Cells[cmnTelFijo.Index].Value = c.TelefonoFijo;
            r.Cells[cmnTelMovil.Index].Value = c.TelefonoMovil;
            r.Cells[cmnCorreoElectronico.Index].Value = c.CorreoElectronico;
            r.Tag = c;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            Datos.Rows.Add(r);
        }
        #endregion

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmComercioAE frm = DI.Create<frmComercioAE>();
            frm.Text = "Agregar comercio";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ComercioEditDto cEditDto = frm.GetComercio();
                    if (_servicio.Existe(cEditDto))
                    {
                        MessageBox.Show("Registro repetido",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(cEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var cListDto = _mapper.Map<ComercioListDto>(cEditDto);
                    cListDto.Provincia = (_servicioProvincia.GetProvinciaId(cEditDto.ProvinciaId)).NombreProvincia;
                    cListDto.Localidad = (_servicioLocalidad.GetLocalidadPorId(cEditDto.LocalidadId)).NombreLocalidad;
                    SetearFila(r, cListDto);
                    AgregarFila(r);
                    MessageBox.Show("Registro agregado", 
                        "Mensaje", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
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
            var cDto = r.Tag as ComercioListDto;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {cDto.RazonSocial}?",
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
                _servicio.Borrar(cDto.ComercioId);
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (Datos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = Datos.SelectedRows[0];
            var cListDto = r.Tag as ComercioListDto;
            var cListDtoCopia = (ComercioListDto)cListDto.Clone();
            frmComercioAE frm = DI.Create<frmComercioAE>();
            frm.Text = "Editar comercio";
            ComercioEditDto cEditDto = _servicio.GetComercioPorId(cListDto.ComercioId);
            frm.SetComercio(cEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            cEditDto = frm.GetComercio();
            if (_servicio.Existe(cEditDto))
            {
                MessageBox.Show("Registro repetido",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                SetearFila(r, cListDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(cEditDto);
                cListDto = _mapper.Map<ComercioListDto>(cEditDto);
                cListDto.Provincia = (_servicioProvincia.GetProvinciaId(cEditDto.ProvinciaId)).NombreProvincia;
                cListDto.Localidad = (_servicioLocalidad.GetLocalidadPorId(cEditDto.LocalidadId)).NombreLocalidad;
                SetearFila(r, cListDto);
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
                SetearFila(r, cListDtoCopia);


            }
        }
    }
}
