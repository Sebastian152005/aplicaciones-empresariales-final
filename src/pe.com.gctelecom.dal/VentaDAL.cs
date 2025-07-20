using Microsoft.Data.SqlClient;
using pe.com.gctelecom.bo;
using pe.com.muertelenta.dal;
using System;
using System.Collections.Generic;
using System.Data; // Necesario para CommandType

namespace pe.com.gctelecom.dal
{
    public class VentaDAL
    {
        private ConexionDAL ConexionDAL = new ConexionDAL();

        // Método para crear una nueva venta
        public bool CrearVenta(VentaBO Venta)
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

                using (SqlCommand ComandoSql = new SqlCommand("SP_CREAR_VENTA", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada (CORREGIDOS para coincidir con el SP: @fecha, @total)
                    ComandoSql.Parameters.AddWithValue("@cliente_id", Venta.ClienteId);
                    ComandoSql.Parameters.AddWithValue("@vendedor_id", Venta.VendedorId);
                    ComandoSql.Parameters.AddWithValue("@fecha", Venta.FechaVenta); // CORREGIDO: @fecha
                    ComandoSql.Parameters.AddWithValue("@total", Venta.MontoTotal); // CORREGIDO: @total
                    ComandoSql.Parameters.AddWithValue("@moneda", Venta.Moneda);
                    ComandoSql.Parameters.AddWithValue("@es_visible", Venta.EsVisible);

                    // Parámetro de salida para el ID de la venta
                    SqlParameter paramVentaId = new SqlParameter("@venta_id_salida", SqlDbType.Int);
                    paramVentaId.Direction = ParameterDirection.Output;
                    ComandoSql.Parameters.Add(paramVentaId);

                    ComandoSql.ExecuteNonQuery();

                    // Obtener el ID de la venta generada
                    Venta.VentaId = Convert.ToInt32(paramVentaId.Value);
                    EsExitoso = Venta.VentaId > 0;
                }
                return EsExitoso;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al crear venta: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al crear venta: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }

        // Método para actualizar una venta existente
        public bool ActualizarVenta(VentaBO Venta)
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

                using (SqlCommand ComandoSql = new SqlCommand("SP_ACTUALIZAR_VENTA", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    ComandoSql.Parameters.AddWithValue("@venta_id", Venta.VentaId);
                    ComandoSql.Parameters.AddWithValue("@cliente_id", Venta.ClienteId);
                    ComandoSql.Parameters.AddWithValue("@vendedor_id", Venta.VendedorId);
                    ComandoSql.Parameters.AddWithValue("@fecha", Venta.FechaVenta); // CORREGIDO: @fecha
                    ComandoSql.Parameters.AddWithValue("@total", Venta.MontoTotal); // CORREGIDO: @total
                    ComandoSql.Parameters.AddWithValue("@moneda", Venta.Moneda);
                    ComandoSql.Parameters.AddWithValue("@es_visible", Venta.EsVisible);

                    int filasAfectadas = ComandoSql.ExecuteNonQuery();
                    EsExitoso = filasAfectadas > 0;
                }
                return EsExitoso;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al actualizar venta: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al actualizar venta: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }

        // Método para activar/desactivar una venta (borrado lógico)
        public bool ActivarDesactivarVenta(int VentaId, bool EsVisible)
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

                using (SqlCommand ComandoSql = new SqlCommand("SP_ACTIVAR_DESACTIVAR_VENTA", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    ComandoSql.Parameters.AddWithValue("@venta_id", VentaId);
                    ComandoSql.Parameters.AddWithValue("@es_visible", Convert.ToInt16(EsVisible));

                    int filasAfectadas = ComandoSql.ExecuteNonQuery();
                    EsExitoso = filasAfectadas > 0;
                }
                return EsExitoso;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al activar/desactivar venta: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al activar/desactivar venta: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }

        // Método para obtener ventas (puedes añadir filtros si los necesitas)
        public List<VentaBO> ObtenerVentas(bool? EsVisible = null)
        {
            List<VentaBO> ListaVentas = new List<VentaBO>();
            SqlConnection? conexion = null;
            try
            {
                conexion = ConexionDAL.Conectar();
                if (conexion == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_VENTAS", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    if (EsVisible.HasValue)
                    {
                        ComandoSql.Parameters.AddWithValue("@es_visible", Convert.ToInt16(EsVisible.Value));
                    }
                    else
                    {
                        ComandoSql.Parameters.AddWithValue("@es_visible", DBNull.Value);
                    }

                    using (SqlDataReader RespuestaSql = ComandoSql.ExecuteReader())
                    {
                        while (RespuestaSql.Read())
                        {
                            VentaBO Venta = new VentaBO();
                            Venta.VentaId = Convert.ToInt32(RespuestaSql["venta_id"].ToString());
                            Venta.ClienteId = Convert.ToInt32(RespuestaSql["cliente_id"].ToString());
                            Venta.VendedorId = Convert.ToInt32(RespuestaSql["vendedor_id"].ToString());
                            // CORREGIDO: Leer de las columnas 'fecha' y 'total'
                            Venta.FechaVenta = Convert.ToDateTime(RespuestaSql["fecha"].ToString());
                            Venta.Moneda = RespuestaSql["moneda"].ToString();
                            Venta.MontoTotal = Convert.ToDecimal(RespuestaSql["total"].ToString());
                            Venta.EsVisible = Convert.ToBoolean(RespuestaSql["es_visible"].ToString());
                            ListaVentas.Add(Venta);
                        }
                    }
                }
                return ListaVentas;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al obtener ventas: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al obtener ventas: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }

        // Método para obtener el siguiente ID de venta (si tu base de datos lo genera así)
        public int ObtenerSiguienteVentaId()
        {
            int SiguienteCodigo = 0;
            SqlConnection? conexion = null;
            try
            {
                conexion = ConexionDAL.Conectar();
                if (conexion == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_SIGUIENTE_VENTA_ID", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader RespuestaSql = ComandoSql.ExecuteReader())
                    {
                        if (RespuestaSql.Read())
                        {
                            SiguienteCodigo = Convert.ToInt32(RespuestaSql["siguiente_venta_id"].ToString());
                        }
                    }
                }
                return SiguienteCodigo;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al obtener siguiente venta ID: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al obtener siguiente venta ID: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }
    }
}
