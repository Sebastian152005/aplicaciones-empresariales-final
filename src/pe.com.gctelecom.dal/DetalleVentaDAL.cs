using Microsoft.Data.SqlClient;
using pe.com.gctelecom.bo;
using pe.com.muertelenta.dal;
using System;
using System.Collections.Generic;
using System.Data; // Necesario para CommandType

namespace pe.com.gctelecom.dal
{
    public class DetalleVentaDAL
    {
        private ConexionDAL ConexionDAL = new ConexionDAL();

        // Método para crear un nuevo detalle de venta
        public bool CrearDetalleVenta(DetalleVentaBO DetalleVenta)
        {
            bool EsExitoso = false;
            SqlConnection? conexion = null;
            try
            {
                conexion = ConexionDAL.Conectar();
                if (conexion == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_CREAR_DETALLE_VENTA", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    ComandoSql.Parameters.AddWithValue("@venta_id", DetalleVenta.VentaId);
                    ComandoSql.Parameters.AddWithValue("@producto_id", DetalleVenta.ProductoId);
                    ComandoSql.Parameters.AddWithValue("@cantidad", DetalleVenta.Cantidad);
                    ComandoSql.Parameters.AddWithValue("@precio_unitario", DetalleVenta.PrecioUnitario);
                    ComandoSql.Parameters.AddWithValue("@subtotal", DetalleVenta.Subtotal);

                    int filasAfectadas = ComandoSql.ExecuteNonQuery();
                    EsExitoso = filasAfectadas > 0;
                }
                return EsExitoso;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al crear detalle de venta: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al crear detalle de venta: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }

        // Método para obtener detalles de venta por ID de venta
        public List<DetalleVentaBO> ObtenerDetallesPorVentaId(int ventaId)
        {
            List<DetalleVentaBO> ListaDetalles = new List<DetalleVentaBO>();
            SqlConnection? conexion = null;
            try
            {
                conexion = ConexionDAL.Conectar();
                if (conexion == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_DETALLES_VENTA_POR_ID", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;
                    ComandoSql.Parameters.AddWithValue("@venta_id", ventaId);

                    using (SqlDataReader RespuestaSql = ComandoSql.ExecuteReader())
                    {
                        while (RespuestaSql.Read())
                        {
                            DetalleVentaBO Detalle = new DetalleVentaBO();
                            Detalle.DetalleVentaId = Convert.ToInt32(RespuestaSql["detalle_venta_id"].ToString());
                            Detalle.VentaId = Convert.ToInt32(RespuestaSql["venta_id"].ToString());
                            Detalle.ProductoId = Convert.ToInt32(RespuestaSql["producto_id"].ToString());
                            Detalle.Cantidad = Convert.ToInt32(RespuestaSql["cantidad"].ToString());
                            Detalle.PrecioUnitario = Convert.ToDecimal(RespuestaSql["precio_unitario"].ToString());
                            Detalle.Subtotal = Convert.ToDecimal(RespuestaSql["subtotal"].ToString());
                            ListaDetalles.Add(Detalle);
                        }
                    }
                }
                return ListaDetalles;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al obtener detalles de venta: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al obtener detalles de venta: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }

        // Método para eliminar detalles de venta de una venta (útil antes de reinsertar al actualizar)
        public bool EliminarDetallesPorVentaId(int ventaId)
        {
            bool EsExitoso = false;
            SqlConnection? conexion = null;
            try
            {
                conexion = ConexionDAL.Conectar();
                if (conexion == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_ELIMINAR_DETALLES_VENTA_POR_ID", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;
                    ComandoSql.Parameters.AddWithValue("@venta_id", ventaId);

                    int filasAfectadas = ComandoSql.ExecuteNonQuery();
                    EsExitoso = filasAfectadas > 0;
                }
                return EsExitoso;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al eliminar detalles de venta: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al eliminar detalles de venta: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }
    }
}
