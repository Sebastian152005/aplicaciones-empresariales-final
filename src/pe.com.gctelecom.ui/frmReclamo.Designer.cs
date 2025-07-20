namespace pe.com.gctelecom.ui
{
    partial class frmReclamo
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
            gbDatosReclamo = new GroupBox();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            txtDescripcion = new TextBox();
            chkHabilitado = new CheckBox();
            cboEstado = new ComboBox();
            dtpFecha = new DateTimePicker();
            cboVenta = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            gbListaReclamos = new GroupBox();
            dgvReclamos = new DataGridView();
            gbDatosReclamo.SuspendLayout();
            gbListaReclamos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReclamos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(274, 18);
            label1.Name = "label1";
            label1.Size = new Size(241, 25);
            label1.TabIndex = 0;
            label1.Text = " REGISTRO DE RECLAMOS";
            // 
            // gbDatosReclamo
            // 
            gbDatosReclamo.Controls.Add(btnEliminar);
            gbDatosReclamo.Controls.Add(btnEditar);
            gbDatosReclamo.Controls.Add(btnGuardar);
            gbDatosReclamo.Controls.Add(btnNuevo);
            gbDatosReclamo.Controls.Add(txtDescripcion);
            gbDatosReclamo.Controls.Add(chkHabilitado);
            gbDatosReclamo.Controls.Add(cboEstado);
            gbDatosReclamo.Controls.Add(dtpFecha);
            gbDatosReclamo.Controls.Add(cboVenta);
            gbDatosReclamo.Controls.Add(label6);
            gbDatosReclamo.Controls.Add(label5);
            gbDatosReclamo.Controls.Add(label4);
            gbDatosReclamo.Controls.Add(label3);
            gbDatosReclamo.Controls.Add(label2);
            gbDatosReclamo.Location = new Point(12, 70);
            gbDatosReclamo.Name = "gbDatosReclamo";
            gbDatosReclamo.Size = new Size(776, 295);
            gbDatosReclamo.TabIndex = 1;
            gbDatosReclamo.TabStop = false;
            gbDatosReclamo.Text = "Datos del Reclamo";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(695, 76);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(602, 76);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(695, 38);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(602, 38);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 10;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(125, 204);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(231, 85);
            txtDescripcion.TabIndex = 9;
            // 
            // chkHabilitado
            // 
            chkHabilitado.AutoSize = true;
            chkHabilitado.Location = new Point(6, 162);
            chkHabilitado.Name = "chkHabilitado";
            chkHabilitado.Size = new Size(81, 19);
            chkHabilitado.TabIndex = 8;
            chkHabilitado.Text = "Habilitado";
            chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // cboEstado
            // 
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(125, 119);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(231, 23);
            cboEstado.TabIndex = 7;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(125, 76);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(231, 23);
            dtpFecha.TabIndex = 6;
            // 
            // cboVenta
            // 
            cboVenta.FormattingEnabled = true;
            cboVenta.Location = new Point(125, 38);
            cboVenta.Name = "cboVenta";
            cboVenta.Size = new Size(231, 23);
            cboVenta.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 204);
            label6.Name = "label6";
            label6.Size = new Size(72, 15);
            label6.TabIndex = 4;
            label6.Text = "Descripción:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 162);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 122);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 2;
            label4.Text = "Estado:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 82);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 1;
            label3.Text = "Fecha del Reclamo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 41);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 0;
            label2.Text = "Venta relacionada:";
            // 
            // gbListaReclamos
            // 
            gbListaReclamos.Controls.Add(dgvReclamos);
            gbListaReclamos.Location = new Point(12, 380);
            gbListaReclamos.Name = "gbListaReclamos";
            gbListaReclamos.Size = new Size(776, 314);
            gbListaReclamos.TabIndex = 2;
            gbListaReclamos.TabStop = false;
            gbListaReclamos.Text = "Lista de Reclamos";
            // 
            // dgvReclamos
            // 
            dgvReclamos.AllowUserToAddRows = false;
            dgvReclamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReclamos.Location = new Point(6, 22);
            dgvReclamos.Name = "dgvReclamos";
            dgvReclamos.ReadOnly = true;
            dgvReclamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReclamos.Size = new Size(764, 286);
            dgvReclamos.TabIndex = 0;
            dgvReclamos.CellClick += dgvReclamos_CellClick;
            // 
            // frmReclamo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 706);
            Controls.Add(gbListaReclamos);
            Controls.Add(gbDatosReclamo);
            Controls.Add(label1);
            Name = "frmReclamo";
            Text = "frmReclamo";
            gbDatosReclamo.ResumeLayout(false);
            gbDatosReclamo.PerformLayout();
            gbListaReclamos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReclamos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox gbDatosReclamo;
        private ComboBox cboVenta;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpFecha;
        private CheckBox chkHabilitado;
        private ComboBox cboEstado;
        private TextBox txtDescripcion;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
        private Button btnNuevo;
        private GroupBox gbListaReclamos;
        private DataGridView dgvReclamos;
    }
}