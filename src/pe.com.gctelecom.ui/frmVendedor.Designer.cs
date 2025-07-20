namespace pe.com.gctelecom.ui
{
    partial class frmVendedor
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
            txtNombre = new TextBox();
            txtCorreo = new TextBox();
            txtCelular = new TextBox();
            txtDireccion = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            dgvVendedor = new DataGridView();
            chkHabilitado = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvVendedor).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(290, 19);
            label1.Name = "label1";
            label1.Size = new Size(238, 25);
            label1.TabIndex = 0;
            label1.Text = "REGISTRO DE VENDEDOR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 128);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 2;
            label3.Text = "Correo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 171);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 3;
            label4.Text = "Celular:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 213);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 4;
            label5.Text = "Dirección:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 256);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 5;
            label6.Text = "Estado:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(85, 85);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(191, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(85, 125);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(191, 23);
            txtCorreo.TabIndex = 7;
            // 
            // txtCelular
            // 
            txtCelular.Location = new Point(85, 168);
            txtCelular.Name = "txtCelular";
            txtCelular.Size = new Size(191, 23);
            txtCelular.TabIndex = 8;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(85, 210);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(191, 23);
            txtDireccion.TabIndex = 8;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(617, 85);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 9;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(713, 85);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(617, 125);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(713, 125);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvVendedor
            // 
            dgvVendedor.AllowUserToAddRows = false;
            dgvVendedor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendedor.Location = new Point(12, 291);
            dgvVendedor.Name = "dgvVendedor";
            dgvVendedor.ReadOnly = true;
            dgvVendedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendedor.Size = new Size(776, 398);
            dgvVendedor.TabIndex = 13;
            dgvVendedor.CellClick += dgvVendedor_CellClick;
            // 
            // chkHabilitado
            // 
            chkHabilitado.AutoSize = true;
            chkHabilitado.Location = new Point(85, 255);
            chkHabilitado.Name = "chkHabilitado";
            chkHabilitado.Size = new Size(81, 19);
            chkHabilitado.TabIndex = 14;
            chkHabilitado.Text = "Habilitado";
            chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // frmVendedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 701);
            Controls.Add(chkHabilitado);
            Controls.Add(dgvVendedor);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtDireccion);
            Controls.Add(txtCelular);
            Controls.Add(txtCorreo);
            Controls.Add(txtNombre);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmVendedor";
            Text = "frmVendedor";
            ((System.ComponentModel.ISupportInitialize)dgvVendedor).EndInit();
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
        private TextBox txtNombre;
        private TextBox txtCorreo;
        private TextBox txtCelular;
        private TextBox txtDireccion;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private DataGridView dgvVendedor;
        private CheckBox chkHabilitado;
    }
}