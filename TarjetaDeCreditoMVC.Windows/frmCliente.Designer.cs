
namespace TarjetaDeCreditoMVC.Windows
{
    partial class frmCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Datos = new System.Windows.Forms.DataGridView();
            this.cmnNombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnApellidoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnFechaNac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnNroDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnLoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnFijo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnMovil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnSuspendido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbBorrar = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBuscar = new System.Windows.Forms.ToolStripButton();
            this.tsbActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCerrar = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Datos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 423);
            this.panel1.TabIndex = 9;
            // 
            // Datos
            // 
            this.Datos.AllowUserToAddRows = false;
            this.Datos.AllowUserToDeleteRows = false;
            this.Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Datos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnNombreCliente,
            this.cmnApellidoCliente,
            this.cmnFechaNac,
            this.cmnDocumento,
            this.cmnNroDoc,
            this.cmnProv,
            this.cmnLoc,
            this.cmnDireccion,
            this.cmnFijo,
            this.cmnMovil,
            this.cmnEmail,
            this.cmnSuspendido});
            this.Datos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Datos.Location = new System.Drawing.Point(0, 0);
            this.Datos.Margin = new System.Windows.Forms.Padding(4);
            this.Datos.MultiSelect = false;
            this.Datos.Name = "Datos";
            this.Datos.ReadOnly = true;
            this.Datos.RowHeadersVisible = false;
            this.Datos.RowHeadersWidth = 51;
            this.Datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Datos.Size = new System.Drawing.Size(800, 423);
            this.Datos.TabIndex = 0;
            // 
            // cmnNombreCliente
            // 
            this.cmnNombreCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnNombreCliente.HeaderText = "Nombres";
            this.cmnNombreCliente.MinimumWidth = 6;
            this.cmnNombreCliente.Name = "cmnNombreCliente";
            this.cmnNombreCliente.ReadOnly = true;
            // 
            // cmnApellidoCliente
            // 
            this.cmnApellidoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnApellidoCliente.HeaderText = "Apellidos";
            this.cmnApellidoCliente.MinimumWidth = 6;
            this.cmnApellidoCliente.Name = "cmnApellidoCliente";
            this.cmnApellidoCliente.ReadOnly = true;
            // 
            // cmnFechaNac
            // 
            this.cmnFechaNac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnFechaNac.HeaderText = "Fecha de nacimiento";
            this.cmnFechaNac.MinimumWidth = 6;
            this.cmnFechaNac.Name = "cmnFechaNac";
            this.cmnFechaNac.ReadOnly = true;
            // 
            // cmnDocumento
            // 
            this.cmnDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnDocumento.HeaderText = "Tipo de documento";
            this.cmnDocumento.MinimumWidth = 6;
            this.cmnDocumento.Name = "cmnDocumento";
            this.cmnDocumento.ReadOnly = true;
            // 
            // cmnNroDoc
            // 
            this.cmnNroDoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnNroDoc.HeaderText = "Numero de documento";
            this.cmnNroDoc.MinimumWidth = 6;
            this.cmnNroDoc.Name = "cmnNroDoc";
            this.cmnNroDoc.ReadOnly = true;
            // 
            // cmnProv
            // 
            this.cmnProv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnProv.HeaderText = "Provincia";
            this.cmnProv.MinimumWidth = 6;
            this.cmnProv.Name = "cmnProv";
            this.cmnProv.ReadOnly = true;
            // 
            // cmnLoc
            // 
            this.cmnLoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnLoc.HeaderText = "Localidad";
            this.cmnLoc.MinimumWidth = 6;
            this.cmnLoc.Name = "cmnLoc";
            this.cmnLoc.ReadOnly = true;
            // 
            // cmnDireccion
            // 
            this.cmnDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnDireccion.HeaderText = "Direccion";
            this.cmnDireccion.MinimumWidth = 6;
            this.cmnDireccion.Name = "cmnDireccion";
            this.cmnDireccion.ReadOnly = true;
            // 
            // cmnFijo
            // 
            this.cmnFijo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnFijo.HeaderText = "Tel. Fijo";
            this.cmnFijo.MinimumWidth = 6;
            this.cmnFijo.Name = "cmnFijo";
            this.cmnFijo.ReadOnly = true;
            // 
            // cmnMovil
            // 
            this.cmnMovil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnMovil.HeaderText = "Tel. Movil";
            this.cmnMovil.MinimumWidth = 6;
            this.cmnMovil.Name = "cmnMovil";
            this.cmnMovil.ReadOnly = true;
            // 
            // cmnEmail
            // 
            this.cmnEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnEmail.HeaderText = "Email";
            this.cmnEmail.MinimumWidth = 6;
            this.cmnEmail.Name = "cmnEmail";
            this.cmnEmail.ReadOnly = true;
            // 
            // cmnSuspendido
            // 
            this.cmnSuspendido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnSuspendido.HeaderText = "Suspendido";
            this.cmnSuspendido.MinimumWidth = 6;
            this.cmnSuspendido.Name = "cmnSuspendido";
            this.cmnSuspendido.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbBorrar,
            this.tsbEditar,
            this.toolStripSeparator1,
            this.tsbBuscar,
            this.tsbActualizar,
            this.toolStripSeparator2,
            this.tsbCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(56, 24);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbBorrar
            // 
            this.tsbBorrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBorrar.Name = "tsbBorrar";
            this.tsbBorrar.Size = new System.Drawing.Size(54, 24);
            this.tsbBorrar.Text = "Borrar";
            this.tsbBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbBorrar.Click += new System.EventHandler(this.tsbBorrar_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(52, 24);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbBuscar
            // 
            this.tsbBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuscar.Name = "tsbBuscar";
            this.tsbBuscar.Size = new System.Drawing.Size(56, 24);
            this.tsbBuscar.Text = "Buscar";
            this.tsbBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbActualizar
            // 
            this.tsbActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActualizar.Name = "tsbActualizar";
            this.tsbActualizar.Size = new System.Drawing.Size(79, 24);
            this.tsbActualizar.Text = "Actualizar";
            this.tsbActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbActualizar.Click += new System.EventHandler(this.tsbActualizar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbCerrar
            // 
            this.tsbCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCerrar.Name = "tsbCerrar";
            this.tsbCerrar.Size = new System.Drawing.Size(53, 24);
            this.tsbCerrar.Text = "Cerrar";
            this.tsbCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCerrar.Click += new System.EventHandler(this.tsbCerrar_Click);
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCliente";
            this.Text = "frmCliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCliente_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView Datos;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbBorrar;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbBuscar;
        private System.Windows.Forms.ToolStripButton tsbActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnNombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnApellidoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnFechaNac;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnNroDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnLoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnFijo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnMovil;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnSuspendido;
    }
}