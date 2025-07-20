using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pe.com.gctelecom.bal; 
using pe.com.gctelecom.bo; 

namespace pe.com.gctelecom.ui
{
    public partial class frmEvento : Form
    {
        // Instancias de las capas de lógica de negocio
        private EventoBAL eventoBAL = new EventoBAL();
        private ClienteBAL clienteBAL = new ClienteBAL(); 
        private VendedorBAL vendedorBAL = new VendedorBAL(); 

        // Variable para almacenar el ID del evento seleccionado 
        private int eventoSeleccionadoId = 0;

        public frmEvento()
        {
            InitializeComponent();
            // Cargar datos al iniciar el formulario
            CargarClientesEnComboBox();
            CargarVendedoresEnComboBox();
            CargarTiposEventoEnComboBox();
            LimpiarCampos(); // Limpiar campos al inicio
            // No hay DataGridView en este formulario, así que no hay método para cargar tabla
        }

        // Método para cargar los clientes en el ComboBox
        private void CargarClientesEnComboBox()
        {
            try
            {
                // Obtener solo los clientes habilitados para el ComboBox
                List<ClienteBO> listaClientes = clienteBAL.ObtenerClientesHabilitados();
                cboCliente.DataSource = listaClientes;
                cboCliente.DisplayMember = "Nombre"; // Propiedad a mostrar en el ComboBox
                cboCliente.ValueMember = "ClienteId"; // Propiedad que representa el valor (ID)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes en el ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los vendedores en el ComboBox
        private void CargarVendedoresEnComboBox()
        {
            try
            {
                // Obtener solo los vendedores habilitados para el ComboBox
                List<VendedorBO> listaVendedores = vendedorBAL.ObtenerVendedorsHabilitados(); // Asumiendo este método en VendedorBAL
                cboVendedor.DataSource = listaVendedores;
                cboVendedor.DisplayMember = "Nombre"; // Propiedad a mostrar en el ComboBox
                cboVendedor.ValueMember = "VendedorId"; // Propiedad que representa el valor (ID)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vendedores en el ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los tipos de evento en el ComboBox (ejemplo estático)
        private void CargarTiposEventoEnComboBox()
        {
            // Puedes cargar esto desde una tabla si tienes una, o de forma estática
            cboTipoEvento.Items.Add("Reunión");
            cboTipoEvento.Items.Add("Llamada");
            cboTipoEvento.SelectedIndex = -1; // Deseleccionar por defecto
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            eventoSeleccionadoId = 0; // Reiniciar el ID del evento seleccionado
            cboCliente.SelectedIndex = -1;
            cboVendedor.SelectedIndex = -1;
            cboTipoEvento.SelectedIndex = -1;
            dtpFechaInicio.Value = DateTime.Now; // Fecha actual
            nudDuracion.Value = 0; // Duración inicial
            txtDescripcion.Clear();
            chkHabilitado.Checked = true; // Por defecto, un nuevo evento está habilitado
            btnGuardar.Text = "Guardar"; // Texto por defecto para guardar
            cboCliente.Focus(); // Poner el foco en el primer campo
        }

        // Método para validar los campos del formulario
        private bool ValidarCampos()
        {
            if (cboCliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCliente.Focus();
                return false;
            }
            if (cboVendedor.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un vendedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboVendedor.Focus();
                return false;
            }
            if (cboTipoEvento.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de evento (Reunión o Llamada).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoEvento.Focus();
                return false;
            }
            if (nudDuracion.Value <= 0)
            {
                MessageBox.Show("La duración del evento debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudDuracion.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción del evento es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }

        // Evento Click del botón Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Evento Click del botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return; // Si la validación falla, no continuar
            }

            EventoBO evento = new EventoBO
            {
                ClienteId = Convert.ToInt32(cboCliente.SelectedValue),
                VendedorId = Convert.ToInt32(cboVendedor.SelectedValue),
                Tipo = cboTipoEvento.SelectedItem.ToString(),
                Descripcion = txtDescripcion.Text.Trim(),
                FechaInicio = dtpFechaInicio.Value,
                Duracion = Convert.ToInt32(nudDuracion.Value),
                EsVisible = chkHabilitado.Checked
            };

            bool exito = false;

            if (eventoSeleccionadoId == 0)
            {
                // Es un nuevo evento
                exito = eventoBAL.CrearEvento(evento);
                if (exito)
                {
                    MessageBox.Show("Evento creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al crear el evento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Es una actualización de un evento existente
                evento.EventoId = eventoSeleccionadoId;
                exito = eventoBAL.ActualizarEvento(evento);
                if (exito)
                {
                    MessageBox.Show("Evento actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el evento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (exito)
            {               
                LimpiarCampos();
            }
        }

        // Evento Click del botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }       
    }
}
