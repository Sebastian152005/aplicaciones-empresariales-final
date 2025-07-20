namespace pe.com.gctelecom.ui
{
    partial class frmFuente
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
            txtNombre = new TextBox();
            chkEstado = new CheckBox();
            btnRegistrar = new Button();
            btnActualizar = new Button();
            btnLimpiar = new Button();
            dgvFuentes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvFuentes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(261, 20);
            label1.Name = "label1";
            label1.Size = new Size(288, 25);
            label1.TabIndex = 0;
            label1.Text = "MANTENIMIENTO DE FUENTES";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 89);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre de la fuente:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(161, 86);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 2;
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.Location = new Point(12, 145);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(81, 19);
            chkEstado.TabIndex = 3;
            chkEstado.Text = "Habilitado";
            chkEstado.UseVisualStyleBackColor = true;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(524, 86);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 23);
            btnRegistrar.TabIndex = 4;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(618, 86);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(713, 86);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvFuentes
            // 
            dgvFuentes.AllowUserToAddRows = false;
            dgvFuentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFuentes.Location = new Point(12, 180);
            dgvFuentes.Name = "dgvFuentes";
            dgvFuentes.ReadOnly = true;
            dgvFuentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFuentes.Size = new Size(776, 258);
            dgvFuentes.TabIndex = 7;
            dgvFuentes.CellMouseClick += dgvFuentes_CellMouseClick;
            // 
            // frmFuente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvFuentes);
            Controls.Add(btnLimpiar);
            Controls.Add(btnActualizar);
            Controls.Add(btnRegistrar);
            Controls.Add(chkEstado);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmFuente";
            Text = "frmFuente";
            ((System.ComponentModel.ISupportInitialize)dgvFuentes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private CheckBox chkEstado;
        private Button btnRegistrar;
        private Button btnActualizar;
        private Button btnLimpiar;
        private DataGridView dgvFuentes;
    }
}