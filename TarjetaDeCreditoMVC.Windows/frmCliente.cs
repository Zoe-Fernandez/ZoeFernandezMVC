using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TarjetaDeCreditoMVC.Entidades.DTOs.Clientes;
using TarjetaDeCreditoMVC.Servicios.Servicios.Facades;
using TarjetaDeCreditoMVC.Windows.Ninject;

namespace TarjetaDeCreditoMVC.Windows
{
    public partial class frmCliente : Form
    {
        public frmCliente(IServicioCliente servicio, IServicioProvincia servicioProvincia, IServicioLocalidad servicioLocalidad, IServicioTipoDeDocumento servicioTipoDeDocumento)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioProvincia = servicioProvincia;
            _servicioLocalidad = servicioLocalidad;
            _servicioTipoDeDocumento = servicioTipoDeDocumento;
        }

        IServicioTipoDeDocumento _servicioTipoDeDocumento;
        IServicioProvincia _servicioProvincia;
        IServicioLocalidad _servicioLocalidad;
        IServicioCliente _servicio;
        List<ClienteListDto> _lista;
        IMapper _mapper;

        private void frmCliente_Load(object sender, EventArgs e)
        {
            _mapper = TarjetaDeCreditoMVC.Mapeador.Mapeador.CrearMapper();
            ActualizarLaGrilla();
        }

        private void ActualizarLaGrilla()
        {
            try
            {
                _lista = _servicio.GetLista(null, null, null);
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
            foreach (var clienteDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, clienteDto);
                AgregarFila(r);
            }
        }


        #region Operaciones en la grilla
        private void AgregarFila(DataGridViewRow r)
        {
            Datos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ClienteListDto c)
        {
            r.Cells[cmnNombreCliente.Index].Value = c.Nombre;
            r.Cells[cmnApellidoCliente.Index].Value = c.Apellido;
            r.Cells[cmnNroDoc.Index].Value = c.NumeroDeDocumento;
            r.Cells[cmnDocumento.Index].Value = c.TipoDeDocumento;
            r.Cells[cmnDireccion.Index].Value = c.Direccion;
            r.Cells[cmnLoc.Index].Value = c.Localidad;
            r.Cells[cmnProv.Index].Value = c.Provincia;
            r.Cells[cmnFijo.Index].Value = c.TelefonoFijo;
            r.Cells[cmnMovil.Index].Value = c.TelefonoMovil;
            r.Cells[cmnEmail.Index].Value = c.CorreoElectronico;
            r.Cells[cmnSuspendido.Index].Value = c.Suspendido;
            r.Tag = c;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(Datos);
            return r;
        }
        #endregion

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            ActualizarLaGrilla();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmClienteAE frm = DI.Create<frmClienteAE>();
            frm.Text = "Agregar cliente";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ClienteEditDto cEditDto = frm.GetCliente();
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
                    var cListDto = _mapper.Map<ClienteListDto>(cEditDto);
                    cListDto.Provincia = (_servicioProvincia.GetProvinciaId(cEditDto.ProvinciaId)).NombreProvincia;
                    cListDto.Localidad = (_servicioLocalidad.GetLocalidadPorId(cEditDto.LocalidadId)).NombreLocalidad;
                    cListDto.TipoDeDocumento = (_servicioTipoDeDocumento.GetTipoDeDocumentoId(cEditDto.TipoDeDocumentoId)).Descripcion;
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (Datos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = Datos.SelectedRows[0];
            var cListDto = r.Tag as ClienteListDto;
            var cListDtoCopia = (ClienteListDto)cListDto.Clone();
            frmClienteAE frm = DI.Create<frmClienteAE>();
            frm.Text = "Editar cliente";
            ClienteEditDto cEditDto = _servicio.GetClientePorId(cListDto.ClienteId);
            frm.SetCliente(cEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            cEditDto = frm.GetCliente();
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
                cListDto = _mapper.Map<ClienteListDto>(cEditDto);
                cListDto.Provincia = (_servicioProvincia.GetProvinciaId(cEditDto.ProvinciaId)).NombreProvincia;
                cListDto.Localidad = (_servicioLocalidad.GetLocalidadPorId(cEditDto.LocalidadId)).NombreLocalidad;
                cListDto.TipoDeDocumento = (_servicioTipoDeDocumento.GetTipoDeDocumentoId(cEditDto.TipoDeDocumentoId)).Descripcion;
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

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (Datos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = Datos.SelectedRows[0];
            var cDto = r.Tag as ClienteListDto;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {cDto.Apellido}, {cDto.Nombre}; {cDto.NumeroDeDocumento}?",
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
                _servicio.Borrar(cDto.ClienteId);
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
    }
}
