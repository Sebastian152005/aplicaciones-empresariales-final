using pe.com.gctelecom.bo;
using pe.com.gctelecom.dal;
using System;
using System.Collections.Generic;

namespace pe.com.gctelecom.bal
{
    public class DetalleVentaBAL
    {
        private DetalleVentaDAL DetalleVentaDAL = new DetalleVentaDAL();  
        public bool CrearDetalleVenta(DetalleVentaBO detalle)
        {
            try
            {
                return DetalleVentaDAL.CrearDetalleVenta(detalle);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en BAL al crear detalle de venta: " + ex.ToString());
                throw;
            }
        }

        public List<DetalleVentaBO> ObtenerDetallesPorVentaId(int ventaId)
        {
            try
            {
                return DetalleVentaDAL.ObtenerDetallesPorVentaId(ventaId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en BAL al obtener detalles por VentaId: " + ex.ToString());
                throw;
            }
        }

        public bool EliminarDetallesPorVentaId(int ventaId)
        {
            try
            {
                return DetalleVentaDAL.EliminarDetallesPorVentaId(ventaId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en BAL al eliminar detalles por VentaId: " + ex.ToString());
                throw;
            }
        }
    }
}
