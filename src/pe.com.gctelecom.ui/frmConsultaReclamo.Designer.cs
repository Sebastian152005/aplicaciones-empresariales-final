namespace pe.com.gctelecom.ui
{
    partial class frmConsultaReclamo
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
            gbFiltrosReclamos = new GroupBox();
            btnBuscar = new Button();
            dtpFin = new DateTimePicker();
            label4 = new Label();
            dtpInicio = new DateTimePicker();
            label3 = new Label();
            cboEstado = new ComboBox();
            label2 = new Label();
            gbListaReclamos = new GroupBox();
            dgvReclamos = new DataGridView();
            gbFiltrosReclamos.SuspendLayout();
            gbListaReclamos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReclamos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(263, 19);
            label1.Name = "label1";
            label1.Size = new Size(244, 25);
            label1.TabIndex = 0;
            label1.Text = "CONSULTA DE RECLAMOS";
            // 
            // gbFiltrosReclamos
            // 
            gbFiltrosReclamos.Controls.Add(btnBuscar);
            gbFiltrosReclamos.Controls.Add(dtpFin);
            gbFiltrosReclamos.Controls.Add(label4);
            gbFiltrosReclamos.Controls.Add(dtpInicio);
            gbFiltrosReclamos.Controls.Add(label3);
            gbFiltrosReclamos.Controls.Add(cboEstado);
            gbFiltrosReclamos.Controls.Add(label2);
            gbFiltrosReclamos.Location = new Point(12, 73);
            gbFiltrosReclamos.Name = "gbFiltrosReclamos";
            gbFiltrosReclamos.Size = new Size(776, 198);
            gbFiltrosReclamos.TabIndex = 1;
            gbFiltrosReclamos.TabStop = false;
            gbFiltrosReclamos.Text = "Filtros de búsqueda";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(695, 169);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dtpFin
            // 
            dtpFin.Location = new Point(424, 99);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(228, 23);
            dtpFin.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(376, 102);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 4;
            label4.Text = "Hasta:";
            // 
            // dtpInicio
            // 
            dtpInicio.Location = new Point(424, 35);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(228, 23);
            dtpInicio.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(376, 38);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Desde:";
            // 
            // cboEstado
            // 
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(122, 35);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(230, 23);
            cboEstado.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 38);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 0;
            label2.Text = "Estado del reclamo:";
            // 
            // gbListaReclamos
            // 
            gbListaReclamos.Controls.Add(dgvReclamos);
            gbListaReclamos.Location = new Point(12, 277);
            gbListaReclamos.Name = "gbListaReclamos";
            gbListaReclamos.Size = new Size(776, 309);
            gbListaReclamos.TabIndex = 2;
            gbListaReclamos.TabStop = false;
            gbListaReclamos.Text = "Reclamos encontrados";
            // 
            // dgvReclamos
            // 
            dgvReclamos.AllowUserToAddRows = false;
            dgvReclamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReclamos.Location = new Point(6, 22);
            dgvReclamos.Name = "dgvReclamos";
            dgvReclamos.ReadOnly = true;
            dgvReclamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReclamos.Size = new Size(764, 281);
            dgvReclamos.TabIndex = 0;
            dgvReclamos.CellClick += dgvReclamos_CellClick;
            // 
            // frmConsultaReclamo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 598);
            Controls.Add(gbListaReclamos);
            Controls.Add(gbFiltrosReclamos);
            Controls.Add(label1);
            Name = "frmConsultaReclamo";
            Text = "frmConsultaReclamo";
            gbFiltrosReclamos.ResumeLayout(false);
            gbFiltrosReclamos.PerformLayout();
            gbListaReclamos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReclamos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox gbFiltrosReclamos;
        private Label label3;
        private ComboBox cboEstado;
        private Label label2;
        private GroupBox gbListaReclamos;
        private Button btnBuscar;
        private DateTimePicker dtpFin;
        private Label label4;
        private DateTimePicker dtpInicio;
        private DataGridView dgvReclamos;
    }
}