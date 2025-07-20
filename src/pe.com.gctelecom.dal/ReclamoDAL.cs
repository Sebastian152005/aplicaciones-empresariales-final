using Microsoft.Data.SqlClient;
using pe.com.gctelecom.bo;
using pe.com.muertelenta.dal;
using System;
using System.Collections.Generic;
using System.Data;


namespace pe.com.gctelecom.dal
{
    public class ReclamoDAL
    {
        private ConexionDAL ConexionDAL = new ConexionDAL();

        public List<ReclamoBO> ObtenerReclamos(bool? EsVisible = null)
        {
            List<ReclamoBO> ListaReclamos = new List<ReclamoBO>();
            SqlConnection? conexion = null;
            try
            {
                conexion = ConexionDAL.Conectar();
                if (conexion == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos. Verifique la cadena de conexión.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_RECLAMOS", conexion))
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
                            ReclamoBO Reclamo = new ReclamoBO();
                            Reclamo.ReclamoId = Convert.ToInt32(RespuestaSql["reclamo_id"].ToString());
                            Reclamo.ProductoId = Convert.ToInt32(RespuestaSql["producto_id"].ToString());
                            Reclamo.NombreProducto = RespuestaSql["nombre_producto"].ToString(); // Leer el nombre del producto
                            Reclamo.Descripcion = RespuestaSql["descripcion"].ToString();
                            Reclamo.Fecha = Convert.ToDateTime(RespuestaSql["fecha"].ToString());
                            Reclamo.Estado = RespuestaSql["estado"].ToString();
                            Reclamo.EsVisible = Convert.ToBoolean(RespuestaSql["es_visible"].ToString());
                            ListaReclamos.Add(Reclamo);
                        }
                    }
                }
                return ListaReclamos;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al obtener reclamos: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al obtener reclamos: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }
        public bool CrearReclamo(ReclamoBO Reclamo)
        {
            bool EsExitoso = false;
            SqlConnection? conexion = null;
            try
            {
                conexion = ConexionDAL.Conectar();
                if (conexion == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos. Verifique la cadena de conexión.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_CREAR_RECLAMO", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;
                    ComandoSql.Parameters.AddWithValue("@producto_id", Reclamo.ProductoId);
                    ComandoSql.Parameters.AddWithValue("@descripcion", Reclamo.Descripcion);
                    ComandoSql.Parameters.AddWithValue("@fecha", Reclamo.Fecha);
                    ComandoSql.Parameters.AddWithValue("@estado", Reclamo.Estado);
                    ComandoSql.Parameters.AddWithValue("@es_visible", Reclamo.EsVisible); // Asegúrate que el SP tenga este parámetro

                    int filasAfectadas = ComandoSql.ExecuteNonQuery();
                    EsExitoso = filasAfectadas > 0;
                }
                return EsExitoso;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al crear reclamo: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al crear reclamo: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }

        public bool ActualizarReclamo(ReclamoBO Reclamo)
        {
            bool EsExitoso = false;
            SqlConnection? conexion = null;
            try
            {
                conexion = ConexionDAL.Conectar();
                if (conexion == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos. Verifique la cadena de conexión.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_ACTUALIZAR_RECLAMO", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;
                    ComandoSql.Parameters.AddWithValue("@reclamo_id", Reclamo.ReclamoId);
                    ComandoSql.Parameters.AddWithValue("@producto_id", Reclamo.ProductoId);
                    ComandoSql.Parameters.AddWithValue("@descripcion", Reclamo.Descripcion);
                    ComandoSql.Parameters.AddWithValue("@fecha", Reclamo.Fecha);
                    ComandoSql.Parameters.AddWithValue("@estado", Reclamo.Estado);
                    ComandoSql.Parameters.AddWithValue("@es_visible", Reclamo.EsVisible); // Asegúrate que el SP tenga este parámetro

                    int filasAfectadas = ComandoSql.ExecuteNonQuery();
                    EsExitoso = filasAfectadas > 0;
                }
                return EsExitoso;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al actualizar reclamo: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al actualizar reclamo: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }

        public bool ActivarDesactivarReclamo(int ReclamoId, bool EsVisible)
        {
            bool EsExitoso = false;
            SqlConnection? conexion = null;
            try
            {
                conexion = ConexionDAL.Conectar();
                if (conexion == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos. Verifique la cadena de conexión.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_ACTIVAR_DESACTIVAR_RECLAMO", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;
                    ComandoSql.Parameters.AddWithValue("@reclamo_id", ReclamoId);
                    ComandoSql.Parameters.AddWithValue("@es_visible", Convert.ToInt16(EsVisible));
                    int filasAfectadas = ComandoSql.ExecuteNonQuery();
                    EsExitoso = filasAfectadas > 0;
                }
                return EsExitoso;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al activar/desactivar reclamo: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al activar/desactivar reclamo: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }
        public int ObtenerSiguienteReclamoId()
        {
            int SiguienteCodigo = 0;
            SqlConnection? conexion = null;
            try
            {
                conexion = ConexionDAL.Conectar();
                if (conexion == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos. Verifique la cadena de conexión.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_SIGUIENTE_RECLAMO_ID", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader RespuestaSql = ComandoSql.ExecuteReader())
                    {
                        if (RespuestaSql.Read()) // Solo esperamos una fila con el ID
                        {
                            SiguienteCodigo = Convert.ToInt32(RespuestaSql["siguiente_reclamo_id"].ToString());
                        }
                    }
                }
                return SiguienteCodigo;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al obtener siguiente reclamo ID: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al obtener siguiente reclamo ID: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }
    }
}
