namespace pe.com.gctelecom.ui
{
    partial class frmConsultaCliente
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
            txtFiltroCorreo = new Label();
            chkSoloHabilitados = new CheckBox();
            txtNombreFiltro = new TextBox();
            txtCorreoFiltro = new TextBox();
            btnBuscar = new Button();
            dgvConsultaClientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaClientes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(330, 18);
            label1.Name = "label1";
            label1.Size = new Size(229, 25);
            label1.TabIndex = 0;
            label1.Text = "CONSULTA DE CLIENTES";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 97);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 1;
            label2.Text = "Filtro por Nombre:";
            // 
            // txtFiltroCorreo
            // 
            txtFiltroCorreo.AutoSize = true;
            txtFiltroCorreo.Location = new Point(12, 151);
            txtFiltroCorreo.Name = "txtFiltroCorreo";
            txtFiltroCorreo.Size = new Size(97, 15);
            txtFiltroCorreo.TabIndex = 2;
            txtFiltroCorreo.Text = "Filtro por Correo:";
            // 
            // chkSoloHabilitados
            // 
            chkSoloHabilitados.AutoSize = true;
            chkSoloHabilitados.Location = new Point(12, 205);
            chkSoloHabilitados.Name = "chkSoloHabilitados";
            chkSoloHabilitados.Size = new Size(110, 19);
            chkSoloHabilitados.TabIndex = 3;
            chkSoloHabilitados.Text = "Solo habilitados";
            chkSoloHabilitados.UseVisualStyleBackColor = true;
            // 
            // txtNombreFiltro
            // 
            txtNombreFiltro.Location = new Point(134, 94);
            txtNombreFiltro.Name = "txtNombreFiltro";
            txtNombreFiltro.Size = new Size(764, 23);
            txtNombreFiltro.TabIndex = 4;
            // 
            // txtCorreoFiltro
            // 
            txtCorreoFiltro.Location = new Point(134, 148);
            txtCorreoFiltro.Name = "txtCorreoFiltro";
            txtCorreoFiltro.Size = new Size(764, 23);
            txtCorreoFiltro.TabIndex = 5;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(823, 201);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvConsultaClientes
            // 
            dgvConsultaClientes.AllowUserToAddRows = false;
            dgvConsultaClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaClientes.Location = new Point(12, 230);
            dgvConsultaClientes.Name = "dgvConsultaClientes";
            dgvConsultaClientes.ReadOnly = true;
            dgvConsultaClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultaClientes.Size = new Size(886, 442);
            dgvConsultaClientes.TabIndex = 7;
            dgvConsultaClientes.CellClick += dgvConsultaClientes_CellClick;
            // 
            // frmConsultaCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 684);
            Controls.Add(dgvConsultaClientes);
            Controls.Add(btnBuscar);
            Controls.Add(txtCorreoFiltro);
            Controls.Add(txtNombreFiltro);
            Controls.Add(chkSoloHabilitados);
            Controls.Add(txtFiltroCorreo);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmConsultaCliente";
            Text = "frmConsultaCliente";
            ((System.ComponentModel.ISupportInitialize)dgvConsultaClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label txtFiltroCorreo;
        private CheckBox chkSoloHabilitados;
        private TextBox txtNombreFiltro;
        private TextBox txtCorreoFiltro;
        private Button btnBuscar;
        private DataGridView dgvConsultaClientes;
    }
}