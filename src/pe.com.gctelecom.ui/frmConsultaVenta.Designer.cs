namespace pe.com.gctelecom.ui
{
    partial class frmConsultaVenta
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
            gbVentas = new GroupBox();
            dgvVentas = new DataGridView();
            gbDetalle = new GroupBox();
            dgvDetalleVentaConsulta = new DataGridView();
            gbVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            gbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVentaConsulta).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(278, 18);
            label1.Name = "label1";
            label1.Size = new Size(216, 25);
            label1.TabIndex = 0;
            label1.Text = "CONSULTA DE VENTAS";
            // 
            // gbVentas
            // 
            gbVentas.Controls.Add(dgvVentas);
            gbVentas.Location = new Point(12, 68);
            gbVentas.Name = "gbVentas";
            gbVentas.Size = new Size(776, 302);
            gbVentas.TabIndex = 1;
            gbVentas.TabStop = false;
            gbVentas.Text = "Listado de Ventas";
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(6, 22);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(764, 274);
            dgvVentas.TabIndex = 0;
            dgvVentas.CellClick += dgvVentas_CellClick;
            // 
            // gbDetalle
            // 
            gbDetalle.Controls.Add(dgvDetalleVentaConsulta);
            gbDetalle.Location = new Point(12, 386);
            gbDetalle.Name = "gbDetalle";
            gbDetalle.Size = new Size(776, 302);
            gbDetalle.TabIndex = 2;
            gbDetalle.TabStop = false;
            gbDetalle.Text = "Detalle de la Venta Seleccionada";
            // 
            // dgvDetalleVentaConsulta
            // 
            dgvDetalleVentaConsulta.AllowUserToAddRows = false;
            dgvDetalleVentaConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleVentaConsulta.Location = new Point(6, 22);
            dgvDetalleVentaConsulta.Name = "dgvDetalleVentaConsulta";
            dgvDetalleVentaConsulta.ReadOnly = true;
            dgvDetalleVentaConsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleVentaConsulta.Size = new Size(764, 274);
            dgvDetalleVentaConsulta.TabIndex = 0;
            dgvDetalleVentaConsulta.CellClick += dgvDetalleVentaConsulta_CellClick;
            // 
            // frmConsultaVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 700);
            Controls.Add(gbDetalle);
            Controls.Add(gbVentas);
            Controls.Add(label1);
            Name = "frmConsultaVenta";
            Text = "frmConsultaVenta";
            gbVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            gbDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVentaConsulta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox gbVentas;
        private DataGridView dgvVentas;
        private GroupBox gbDetalle;
        private DataGridView dgvDetalleVentaConsulta;
    }
}