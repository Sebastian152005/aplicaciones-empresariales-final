namespace pe.com.gctelecom.ui
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtNombre = new TextBox();
            txtCorreo = new TextBox();
            txtCelular = new TextBox();
            txtDireccion = new TextBox();
            cboFuente = new ComboBox();
            chkEstado = new CheckBox();
            btnGuardar = new Button();
            btnNuevo = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            dgvClientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(295, 19);
            label1.Name = "label1";
            label1.Size = new Size(320, 25);
            label1.TabIndex = 0;
            label1.Text = "REGISTRO Y EDICIÓN DE CLIENTES";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 89);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre del Cliente:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 131);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 2;
            label3.Text = "Correo electrónico:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 175);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 3;
            label4.Text = "Celular:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 216);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 4;
            label5.Text = "Dirección:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 262);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 5;
            label6.Text = "Fuente de origen:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 307);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 6;
            label7.Text = "Estado:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(172, 86);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(121, 23);
            txtNombre.TabIndex = 7;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(172, 128);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(121, 23);
            txtCorreo.TabIndex = 7;
            // 
            // txtCelular
            // 
            txtCelular.Location = new Point(172, 167);
            txtCelular.Name = "txtCelular";
            txtCelular.Size = new Size(121, 23);
            txtCelular.TabIndex = 7;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(172, 213);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(121, 23);
            txtDireccion.TabIndex = 7;
            // 
            // cboFuente
            // 
            cboFuente.FormattingEnabled = true;
            cboFuente.Location = new Point(172, 259);
            cboFuente.Name = "cboFuente";
            cboFuente.Size = new Size(121, 23);
            cboFuente.TabIndex = 8;
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.Location = new Point(172, 307);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(81, 19);
            chkEstado.TabIndex = 9;
            chkEstado.Text = "Habilitado";
            chkEstado.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(654, 86);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 23);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar cliente";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(798, 86);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(103, 23);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(654, 127);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(103, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(798, 127);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(103, 23);
            btnCerrar.TabIndex = 13;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 332);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(889, 375);
            dgvClientes.TabIndex = 14;
            dgvClientes.CellMouseClick += dgvClientes_CellMouseClick;
            // 
            // frmCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 719);
            Controls.Add(dgvClientes);
            Controls.Add(btnCerrar);
            Controls.Add(btnEliminar);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(chkEstado);
            Controls.Add(cboFuente);
            Controls.Add(txtDireccion);
            Controls.Add(txtCelular);
            Controls.Add(txtCorreo);
            Controls.Add(txtNombre);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmCliente";
            Text = "frmCliente";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtNombre;
        private TextBox txtCorreo;
        private TextBox txtCelular;
        private TextBox txtDireccion;
        private ComboBox cboFuente;
        private CheckBox chkEstado;
        private Button btnGuardar;
        private Button btnNuevo;
        private Button btnEliminar;
        private Button btnCerrar;
        private DataGridView dgvClientes;
    }
}