namespace pe.com.gctelecom.ui
{
    partial class frmEvento
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
            gbDatosEvento = new GroupBox();
            txtDescripcion = new TextBox();
            nudDuracion = new NumericUpDown();
            dtpFechaInicio = new DateTimePicker();
            cboTipoEvento = new ComboBox();
            cboVendedor = new ComboBox();
            cboCliente = new ComboBox();
            chkHabilitado = new CheckBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            lblInformacion = new Label();
            gbDatosEvento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuracion).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(105, 22);
            label1.Name = "label1";
            label1.Size = new Size(219, 25);
            label1.TabIndex = 0;
            label1.Text = "REGISTRO DE EVENTOS";
            // 
            // gbDatosEvento
            // 
            gbDatosEvento.Controls.Add(txtDescripcion);
            gbDatosEvento.Controls.Add(nudDuracion);
            gbDatosEvento.Controls.Add(dtpFechaInicio);
            gbDatosEvento.Controls.Add(cboTipoEvento);
            gbDatosEvento.Controls.Add(cboVendedor);
            gbDatosEvento.Controls.Add(cboCliente);
            gbDatosEvento.Controls.Add(chkHabilitado);
            gbDatosEvento.Controls.Add(label7);
            gbDatosEvento.Controls.Add(label6);
            gbDatosEvento.Controls.Add(label5);
            gbDatosEvento.Controls.Add(label4);
            gbDatosEvento.Controls.Add(label3);
            gbDatosEvento.Controls.Add(label2);
            gbDatosEvento.Location = new Point(12, 76);
            gbDatosEvento.Name = "gbDatosEvento";
            gbDatosEvento.Size = new Size(404, 491);
            gbDatosEvento.TabIndex = 1;
            gbDatosEvento.TabStop = false;
            gbDatosEvento.Text = "Datos del evento";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(93, 341);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(302, 101);
            txtDescripcion.TabIndex = 10;
            // 
            // nudDuracion
            // 
            nudDuracion.Location = new Point(93, 278);
            nudDuracion.Name = "nudDuracion";
            nudDuracion.Size = new Size(43, 23);
            nudDuracion.TabIndex = 9;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(93, 211);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(231, 23);
            dtpFechaInicio.TabIndex = 8;
            // 
            // cboTipoEvento
            // 
            cboTipoEvento.FormattingEnabled = true;
            cboTipoEvento.Location = new Point(93, 158);
            cboTipoEvento.Name = "cboTipoEvento";
            cboTipoEvento.Size = new Size(231, 23);
            cboTipoEvento.TabIndex = 7;
            // 
            // cboVendedor
            // 
            cboVendedor.FormattingEnabled = true;
            cboVendedor.Location = new Point(93, 98);
            cboVendedor.Name = "cboVendedor";
            cboVendedor.Size = new Size(231, 23);
            cboVendedor.TabIndex = 7;
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(93, 39);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(231, 23);
            cboCliente.TabIndex = 7;
            // 
            // chkHabilitado
            // 
            chkHabilitado.AutoSize = true;
            chkHabilitado.Location = new Point(6, 466);
            chkHabilitado.Name = "chkHabilitado";
            chkHabilitado.Size = new Size(81, 19);
            chkHabilitado.TabIndex = 6;
            chkHabilitado.Text = "Habilitado";
            chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 344);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 5;
            label7.Text = "Descripción:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 280);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 4;
            label6.Text = "Duración:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 219);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 3;
            label5.Text = "Fecha Inicio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 161);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 2;
            label4.Text = "Tipo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 101);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 1;
            label3.Text = "Vendedor:";
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
            // btnNuevo
            // 
            btnNuevo.Location = new Point(12, 689);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(171, 689);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(341, 689);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblInformacion
            // 
            lblInformacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInformacion.ForeColor = Color.Gray;
            lblInformacion.Location = new Point(65, 606);
            lblInformacion.Name = "lblInformacion";
            lblInformacion.Size = new Size(290, 50);
            lblInformacion.TabIndex = 5;
            lblInformacion.Text = "Este evento será guardado como reunión o llamada asociada al cliente y vendedor seleccionados";
            lblInformacion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmEvento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 724);
            Controls.Add(lblInformacion);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(gbDatosEvento);
            Controls.Add(label1);
            Name = "frmEvento";
            Text = "frmEvento";
            gbDatosEvento.ResumeLayout(false);
            gbDatosEvento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuracion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox gbDatosEvento;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cboTipoEvento;
        private ComboBox cboVendedor;
        private ComboBox cboCliente;
        private CheckBox chkHabilitado;
        private TextBox txtDescripcion;
        private NumericUpDown nudDuracion;
        private DateTimePicker dtpFechaInicio;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblInformacion;
    }
}