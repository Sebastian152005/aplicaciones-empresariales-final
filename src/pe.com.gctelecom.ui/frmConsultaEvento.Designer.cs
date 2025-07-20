namespace pe.com.gctelecom.ui
{
    partial class frmConsultaEvento
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
            label1 = new Label();
            gbFiltros = new GroupBox();
            btnLimpiar = new Button();
            btnBuscar = new Button();
            dtpFin = new DateTimePicker();
            dtpInicio = new DateTimePicker();
            cboTipoEvento = new ComboBox();
            cboCliente = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            gbResultados = new GroupBox();
            dgvEventos = new DataGridView();
            btnCerrar = new Button();
            btnVolver = new Button();
            gbFiltros.SuspendLayout();
            gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEventos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(184, 21);
            label1.Name = "label1";
            label1.Size = new Size(232, 25);
            label1.TabIndex = 0;
            label1.Text = " CONSULTA DE EVENTOS";
            // 
            // gbFiltros
            // 
            gbFiltros.Controls.Add(btnLimpiar);
            gbFiltros.Controls.Add(btnBuscar);
            gbFiltros.Controls.Add(dtpFin);
            gbFiltros.Controls.Add(dtpInicio);
            gbFiltros.Controls.Add(cboTipoEvento);
            gbFiltros.Controls.Add(cboCliente);
            gbFiltros.Controls.Add(label5);
            gbFiltros.Controls.Add(label4);
            gbFiltros.Controls.Add(label3);
            gbFiltros.Controls.Add(label2);
            gbFiltros.Location = new Point(12, 77);
            gbFiltros.Name = "gbFiltros";
            gbFiltros.Size = new Size(590, 263);
            gbFiltros.TabIndex = 1;
            gbFiltros.TabStop = false;
            gbFiltros.Text = "Filtros de búsqueda";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(433, 167);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(433, 102);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dtpFin
            // 
            dtpFin.Location = new Point(118, 228);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(225, 23);
            dtpFin.TabIndex = 5;
            // 
            // dtpInicio
            // 
            dtpInicio.Location = new Point(118, 167);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(225, 23);
            dtpInicio.TabIndex = 5;
            // 
            // cboTipoEvento
            // 
            cboTipoEvento.FormattingEnabled = true;
            cboTipoEvento.Location = new Point(118, 105);
            cboTipoEvento.Name = "cboTipoEvento";
            cboTipoEvento.Size = new Size(225, 23);
            cboTipoEvento.TabIndex = 4;
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(118, 39);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(225, 23);
            cboCliente.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 234);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 3;
            label5.Text = "Hasta:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 167);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 2;
            label4.Text = "Desde:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 105);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 1;
            label3.Text = "Tipo Evento:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 42);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 0;
            label2.Text = "Cliente:";
            // 
            // gbResultados
            // 
            gbResultados.Controls.Add(dgvEventos);
            gbResultados.Location = new Point(12, 346);
            gbResultados.Name = "gbResultados";
            gbResultados.Size = new Size(590, 303);
            gbResultados.TabIndex = 2;
            gbResultados.TabStop = false;
            gbResultados.Text = "Listado de eventos";
            // 
            // dgvEventos
            // 
            dgvEventos.AllowUserToAddRows = false;
            dgvEventos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEventos.Location = new Point(6, 22);
            dgvEventos.Name = "dgvEventos";
            dgvEventos.ReadOnly = true;
            dgvEventos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEventos.Size = new Size(578, 275);
            dgvEventos.TabIndex = 0;
            dgvEventos.CellClick += dgvEventos_CellClick;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(527, 661);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(12, 661);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // frmConsultaEvento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 696);
            Controls.Add(btnVolver);
            Controls.Add(btnCerrar);
            Controls.Add(gbResultados);
            Controls.Add(gbFiltros);
            Controls.Add(label1);
            Name = "frmConsultaEvento";
            Text = "frmConsultaEvento";
            gbFiltros.ResumeLayout(false);
            gbFiltros.PerformLayout();
            gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEventos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox gbFiltros;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpFin;
        private DateTimePicker dtpInicio;
        private ComboBox cboTipoEvento;
        private ComboBox cboCliente;
        private Button btnLimpiar;
        private Button btnBuscar;
        private GroupBox gbResultados;
        private DataGridView dgvEventos;
        private Button btnCerrar;
        private Button btnVolver;
    }
}