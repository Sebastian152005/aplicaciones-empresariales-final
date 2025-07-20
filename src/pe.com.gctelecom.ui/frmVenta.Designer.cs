namespace pe.com.gctelecom.ui
{
    partial class frmVenta
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
            cboCliente = new ComboBox();
            cboVendedor = new ComboBox();
            dtpFecha = new DateTimePicker();
            cboMoneda = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            cboProducto = new ComboBox();
            btnAgregarProducto = new Button();
            label8 = new Label();
            txtMontoTotal = new TextBox();
            btnGuardarVenta = new Button();
            btnCancelarVenta = new Button();
            gbAgregarProducto = new GroupBox();
            nudCantidad = new NumericUpDown();
            gbDatosVenta = new GroupBox();
            gbDetalleVenta = new GroupBox();
            dgvDetalleVenta = new DataGridView();
            gbAgregarProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            gbDatosVenta.SuspendLayout();
            gbDetalleVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(295, 20);
            label1.Name = "label1";
            label1.Size = new Size(197, 25);
            label1.TabIndex = 0;
            label1.Text = "REGISTRO DE VENTA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 28);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "Cliente:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 77);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 2;
            label3.Text = "Vendedor:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 125);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 3;
            label4.Text = "Fecha:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 173);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 4;
            label5.Text = "Moneda:";
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(67, 25);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(236, 23);
            cboCliente.TabIndex = 5;
            // 
            // cboVendedor
            // 
            cboVendedor.FormattingEnabled = true;
            cboVendedor.Location = new Point(67, 74);
            cboVendedor.Name = "cboVendedor";
            cboVendedor.Size = new Size(236, 23);
            cboVendedor.TabIndex = 5;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(67, 122);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(236, 23);
            dtpFecha.TabIndex = 6;
            // 
            // cboMoneda
            // 
            cboMoneda.FormattingEnabled = true;
            cboMoneda.Location = new Point(67, 167);
            cboMoneda.Name = "cboMoneda";
            cboMoneda.Size = new Size(236, 23);
            cboMoneda.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 25);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 8;
            label6.Text = "Producto:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 74);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 9;
            label7.Text = "Cantidad:";
            // 
            // cboProducto
            // 
            cboProducto.FormattingEnabled = true;
            cboProducto.Location = new Point(75, 22);
            cboProducto.Name = "cboProducto";
            cboProducto.Size = new Size(157, 23);
            cboProducto.TabIndex = 10;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(238, 22);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(128, 23);
            btnAgregarProducto.TabIndex = 12;
            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(473, 374);
            label8.Name = "label8";
            label8.Size = new Size(75, 15);
            label8.TabIndex = 14;
            label8.Text = "Monto Total:";
            // 
            // txtMontoTotal
            // 
            txtMontoTotal.Location = new Point(560, 371);
            txtMontoTotal.Name = "txtMontoTotal";
            txtMontoTotal.ReadOnly = true;
            txtMontoTotal.Size = new Size(210, 23);
            txtMontoTotal.TabIndex = 15;
            txtMontoTotal.TextAlign = HorizontalAlignment.Center;
            // 
            // btnGuardarVenta
            // 
            btnGuardarVenta.Location = new Point(244, 720);
            btnGuardarVenta.Name = "btnGuardarVenta";
            btnGuardarVenta.Size = new Size(114, 23);
            btnGuardarVenta.TabIndex = 16;
            btnGuardarVenta.Text = "Guardar Venta";
            btnGuardarVenta.UseVisualStyleBackColor = true;
            btnGuardarVenta.Click += btnGuardarVenta_Click;
            // 
            // btnCancelarVenta
            // 
            btnCancelarVenta.Location = new Point(426, 720);
            btnCancelarVenta.Name = "btnCancelarVenta";
            btnCancelarVenta.Size = new Size(114, 23);
            btnCancelarVenta.TabIndex = 17;
            btnCancelarVenta.Text = "Cancelar Venta";
            btnCancelarVenta.UseVisualStyleBackColor = true;
            btnCancelarVenta.Click += btnCancelarVenta_Click;
            // 
            // gbAgregarProducto
            // 
            gbAgregarProducto.Controls.Add(nudCantidad);
            gbAgregarProducto.Controls.Add(cboProducto);
            gbAgregarProducto.Controls.Add(label6);
            gbAgregarProducto.Controls.Add(label7);
            gbAgregarProducto.Controls.Add(btnAgregarProducto);
            gbAgregarProducto.Location = new Point(410, 137);
            gbAgregarProducto.Name = "gbAgregarProducto";
            gbAgregarProducto.Size = new Size(372, 109);
            gbAgregarProducto.TabIndex = 18;
            gbAgregarProducto.TabStop = false;
            gbAgregarProducto.Text = "Agregar Producto";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(75, 72);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(54, 23);
            nudCantidad.TabIndex = 21;
            // 
            // gbDatosVenta
            // 
            gbDatosVenta.Controls.Add(cboCliente);
            gbDatosVenta.Controls.Add(label2);
            gbDatosVenta.Controls.Add(label3);
            gbDatosVenta.Controls.Add(label4);
            gbDatosVenta.Controls.Add(label5);
            gbDatosVenta.Controls.Add(cboVendedor);
            gbDatosVenta.Controls.Add(dtpFecha);
            gbDatosVenta.Controls.Add(cboMoneda);
            gbDatosVenta.Location = new Point(12, 89);
            gbDatosVenta.Name = "gbDatosVenta";
            gbDatosVenta.Size = new Size(309, 209);
            gbDatosVenta.TabIndex = 19;
            gbDatosVenta.TabStop = false;
            gbDatosVenta.Text = "Datos de Venta";
            // 
            // gbDetalleVenta
            // 
            gbDetalleVenta.Controls.Add(dgvDetalleVenta);
            gbDetalleVenta.Controls.Add(txtMontoTotal);
            gbDetalleVenta.Controls.Add(label8);
            gbDetalleVenta.Location = new Point(12, 304);
            gbDetalleVenta.Name = "gbDetalleVenta";
            gbDetalleVenta.Size = new Size(776, 410);
            gbDetalleVenta.TabIndex = 20;
            gbDetalleVenta.TabStop = false;
            gbDetalleVenta.Text = "Detalle de Venta";
            // 
            // dgvDetalleVenta
            // 
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleVenta.Location = new Point(6, 22);
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleVenta.Size = new Size(764, 333);
            dgvDetalleVenta.TabIndex = 0;
            // 
            // frmVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 755);
            Controls.Add(gbDetalleVenta);
            Controls.Add(gbDatosVenta);
            Controls.Add(gbAgregarProducto);
            Controls.Add(btnCancelarVenta);
            Controls.Add(btnGuardarVenta);
            Controls.Add(label1);
            Name = "frmVenta";
            Text = "frmVenta";
            gbAgregarProducto.ResumeLayout(false);
            gbAgregarProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            gbDatosVenta.ResumeLayout(false);
            gbDatosVenta.PerformLayout();
            gbDetalleVenta.ResumeLayout(false);
            gbDetalleVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cboCliente;
        private ComboBox cboVendedor;
        private DateTimePicker dtpFecha;
        private ComboBox cboMoneda;
        private Label label6;
        private Label label7;
        private ComboBox cboProducto;
        private Button btnAgregarProducto;
        private Label label8;
        private TextBox txtMontoTotal;
        private Button btnGuardarVenta;
        private Button btnCancelarVenta;
        private GroupBox gbAgregarProducto;
        private GroupBox gbDatosVenta;
        private GroupBox gbDetalleVenta;
        private DataGridView dgvDetalleVenta;
        private NumericUpDown nudCantidad;
    }
}