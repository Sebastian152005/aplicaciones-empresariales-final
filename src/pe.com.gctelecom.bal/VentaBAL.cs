using pe.com.gctelecom.bo;
using pe.com.gctelecom.dal;
using System;
using System.Collections.Generic;

namespace pe.com.gctelecom.bal
{
    public class VentaBAL
    {
        private VentaDAL VentaDAL = new VentaDAL();
        private DetalleVentaDAL DetalleVentaDAL = new DetalleVentaDAL(); // Para manejar el detalle

        // Método para crear una venta y sus detalles
        public bool CrearVenta(VentaBO venta, List<DetalleVentaBO> detalles)
        {
            try
            {
                // Primero, crear la cabecera de la venta
                bool ventaCreada = VentaDAL.CrearVenta(venta);
                if (ventaCreada)
                {
                    // Si la venta se creó exitosamente, guardar sus detalles
                    foreach (var detalle in detalles)
                    {
                        detalle.VentaId = venta.VentaId; // Asignar el ID de la venta recién creada
                        DetalleVentaDAL.CrearDetalleVenta(detalle);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en BAL al crear venta y detalles: " + ex.ToString());
                throw; // Relanzar para que la UI lo capture
            }
        }

        // Método para actualizar una venta y sus detalles
        public bool ActualizarVenta(VentaBO venta, List<DetalleVentaBO> nuevosDetalles)
        {
            try
            {
                // Primero, actualizar la cabecera de la venta
                bool ventaActualizada = VentaDAL.ActualizarVenta(venta);
                if (ventaActualizada)
                {
                    // Eliminar los detalles existentes para esta venta
                    DetalleVentaDAL.EliminarDetallesPorVentaId(venta.VentaId);

                    // Insertar los nuevos detalles
                    foreach (var detalle in nuevosDetalles)
                    {
                        detalle.VentaId = venta.VentaId; // Asegurarse de que el ID de venta sea correcto
                        DetalleVentaDAL.CrearDetalleVenta(detalle);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en BAL al actualizar venta y detalles: " + ex.ToString());
                throw; // Relanzar para que la UI lo capture
            }
        }

        // Método para borrar (desactivar) una venta
        public bool BorrarVenta(int ventaId)
        {
            try
            {
                // Borrado lógico de la cabecera de la venta
                return VentaDAL.ActivarDesactivarVenta(ventaId, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en BAL al borrar venta: " + ex.ToString());
                throw;
            }
        }

        // Método para habilitar una venta
        public bool HabilitarVenta(int ventaId)
        {
            try
            {
                // Habilitar la cabecera de la venta
                return VentaDAL.ActivarDesactivarVenta(ventaId, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en BAL al habilitar venta: " + ex.ToString());
                throw;
            }
        }

        // Método para obtener todas las ventas habilitadas
        public List<VentaBO> ObtenerVentasHabilitadas()
        {
            try
            {
                return VentaDAL.ObtenerVentas(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en BAL al obtener ventas habilitadas: " + ex.ToString());
                throw;
            }
        }

        // Método para obtener una venta por su ID (útil para edición)
        public VentaBO? ObtenerVentaPorId(int ventaId)
        {
            try
            {
                // Obtener todas las ventas y filtrar por ID (puedes crear un método específico en DAL si es más eficiente)
                return VentaDAL.ObtenerVentas(null).FirstOrDefault(v => v.VentaId == ventaId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en BAL al obtener venta por ID: " + ex.ToString());
                throw;
            }
        }

        // Método para obtener los detalles de una venta específica
        public List<DetalleVentaBO> ObtenerDetallesDeVenta(int ventaId)
        {
            try
            {
                return DetalleVentaDAL.ObtenerDetallesPorVentaId(ventaId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en BAL al obtener detalles de venta: " + ex.ToString());
                throw;
            }
        }
    }
}
