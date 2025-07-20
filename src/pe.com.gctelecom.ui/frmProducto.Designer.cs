namespace pe.com.gctelecom.ui
{
    partial class frmProducto
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
            txtDescripcion = new TextBox();
            txtPrecio = new TextBox();
            cboMoneda = new ComboBox();
            chkHabilitado = new CheckBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            dgvProducto = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProducto).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(286, 19);
            label1.Name = "label1";
            label1.Size = new Size(238, 25);
            label1.TabIndex = 0;
            label1.Text = "REGISTRO DE PRODUCTO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 85);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 132);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 2;
            label3.Text = "Descripción:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 179);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 3;
            label4.Text = "Precio:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 227);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 4;
            label5.Text = "Moneda:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 276);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 5;
            label6.Text = "Estado";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(94, 82);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(162, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(94, 129);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(162, 23);
            txtDescripcion.TabIndex = 6;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(94, 176);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(162, 23);
            txtPrecio.TabIndex = 6;
            // 
            // cboMoneda
            // 
            cboMoneda.FormattingEnabled = true;
            cboMoneda.Location = new Point(94, 224);
            cboMoneda.Name = "cboMoneda";
            cboMoneda.Size = new Size(162, 23);
            cboMoneda.TabIndex = 7;
            // 
            // chkHabilitado
            // 
            chkHabilitado.AutoSize = true;
            chkHabilitado.Location = new Point(94, 275);
            chkHabilitado.Name = "chkHabilitado";
            chkHabilitado.Size = new Size(81, 19);
            chkHabilitado.TabIndex = 8;
            chkHabilitado.Text = "Habilitado";
            chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(616, 82);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 9;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(713, 82);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(616, 129);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(713, 129);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvProducto
            // 
            dgvProducto.AllowUserToAddRows = false;
            dgvProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducto.Location = new Point(12, 300);
            dgvProducto.Name = "dgvProducto";
            dgvProducto.ReadOnly = true;
            dgvProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducto.Size = new Size(776, 355);
            dgvProducto.TabIndex = 13;
            dgvProducto.CellMouseClick += dgvProducto_CellMouseClick;
            // 
            // frmProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 667);
            Controls.Add(dgvProducto);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(chkHabilitado);
            Controls.Add(cboMoneda);
            Controls.Add(txtPrecio);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmProducto";
            Text = "frmProducto";
            ((System.ComponentModel.ISupportInitialize)dgvProducto).EndInit();
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
        private TextBox txtDescripcion;
        private TextBox txtPrecio;
        private ComboBox cboMoneda;
        private CheckBox chkHabilitado;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private DataGridView dgvProducto;
    }
}