using Microsoft.Data.SqlClient;
using pe.com.gctelecom.bo;
using pe.com.muertelenta.dal;
using System; // Necesario para Exception
using System.Collections.Generic;
using System.Data; 


namespace pe.com.gctelecom.dal
{
    public class EventoDAL
    {
        private ConexionDAL ConexionDAL = new ConexionDAL();

      
        public List<EventoBO> ObtenerEventos(bool? EsVisible = null)
        {
            List<EventoBO> ListaEventos = new List<EventoBO>();
            SqlConnection? conexion = null; // Declarar la conexión fuera del try
            try
            {
                conexion = ConexionDAL.Conectar(); // Obtener la conexión
                if (conexion == null)
                {
                    // Si la conexión es nula, significa que hubo un error al conectar
                    throw new Exception("No se pudo establecer la conexión a la base de datos. Verifique la cadena de conexión.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_EVENTOS", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    // Añadir el parámetro @es_visible al procedimiento almacenado
                    if (EsVisible.HasValue)
                    {
                        ComandoSql.Parameters.AddWithValue("@es_visible", Convert.ToInt16(EsVisible.Value));
                    }
                    else
                    {
                        // Si EsVisible es null, se pasa DBNull.Value para que el SP no filtre por visibilidad
                        ComandoSql.Parameters.AddWithValue("@es_visible", DBNull.Value);
                    }

                    using (SqlDataReader RespuestaSql = ComandoSql.ExecuteReader())
                    {
                        while (RespuestaSql.Read())
                        {
                            EventoBO Evento = new EventoBO();
                            // Mapear los datos del SqlDataReader a las propiedades de EventoBO
                            // Asegúrate de que los nombres de las columnas aquí coincidan exactamente con el SELECT de tu SP_OBTENER_EVENTOS
                            Evento.EventoId = Convert.ToInt32(RespuestaSql["evento_id"].ToString());
                            Evento.ClienteId = Convert.ToInt32(RespuestaSql["cliente_id"].ToString());
                            Evento.NombreCliente = RespuestaSql["nombre_cliente"].ToString(); // Esta columna viene del JOIN en el SP
                            Evento.VendedorId = Convert.ToInt32(RespuestaSql["vendedor_id"].ToString());
                            Evento.NombreVendedor = RespuestaSql["nombre_vendedor"].ToString(); // Esta columna viene del JOIN en el SP
                            Evento.Tipo = RespuestaSql["tipo"].ToString();
                            Evento.Descripcion = RespuestaSql["descripcion"].ToString();
                            Evento.FechaInicio = Convert.ToDateTime(RespuestaSql["fecha_inicio"].ToString());
                            Evento.Duracion = Convert.ToInt32(RespuestaSql["duracion"].ToString());
                            Evento.EsVisible = Convert.ToBoolean(RespuestaSql["es_visible"].ToString());
                            ListaEventos.Add(Evento);
                        }
                    }
                }
                return ListaEventos;
            }
            catch (SqlException excepcionSql) // Capturar SqlException específicamente para errores de base de datos
            {
                Console.WriteLine("Error de SQL al obtener eventos: " + excepcionSql.ToString());
                throw; // Relanza la excepción para que la capa BAL la capture y la UI pueda mostrar un mensaje más amigable
            }
            catch (Exception excepcionGeneral) // Capturar otras excepciones generales
            {
                Console.WriteLine("Error general al obtener eventos: " + excepcionGeneral.ToString());
                throw; // Relanza la excepción
            }
            finally
            {
                // Asegurarse de cerrar la conexión a la base de datos en el bloque finally
                ConexionDAL.CerrarConexion();
            }
        }
        public bool CrearEvento(EventoBO Evento)
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

                using (SqlCommand ComandoSql = new SqlCommand("SP_CREAR_EVENTO", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;
                    ComandoSql.Parameters.AddWithValue("@cliente_id", Evento.ClienteId);
                    ComandoSql.Parameters.AddWithValue("@vendedor_id", Evento.VendedorId);
                    ComandoSql.Parameters.AddWithValue("@tipo", Evento.Tipo);
                    ComandoSql.Parameters.AddWithValue("@descripcion", Evento.Descripcion);
                    ComandoSql.Parameters.AddWithValue("@fecha_inicio", Evento.FechaInicio);
                    ComandoSql.Parameters.AddWithValue("@duracion", Evento.Duracion);
                    // IMPORTANTE: Asegúrate de que tu SP_CREAR_EVENTO en SQL Server tenga este parámetro
                    ComandoSql.Parameters.AddWithValue("@es_visible", Evento.EsVisible);

                    int filasAfectadas = ComandoSql.ExecuteNonQuery();
                    EsExitoso = filasAfectadas > 0;
                }
                return EsExitoso;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al crear evento: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al crear evento: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }      
        public bool ActualizarEvento(EventoBO Evento)
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

                using (SqlCommand ComandoSql = new SqlCommand("SP_ACTUALIZAR_EVENTO", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;
                    ComandoSql.Parameters.AddWithValue("@evento_id", Evento.EventoId);
                    ComandoSql.Parameters.AddWithValue("@cliente_id", Evento.ClienteId);
                    ComandoSql.Parameters.AddWithValue("@vendedor_id", Evento.VendedorId);
                    ComandoSql.Parameters.AddWithValue("@tipo", Evento.Tipo);
                    ComandoSql.Parameters.AddWithValue("@descripcion", Evento.Descripcion);
                    ComandoSql.Parameters.AddWithValue("@fecha_inicio", Evento.FechaInicio);
                    ComandoSql.Parameters.AddWithValue("@duracion", Evento.Duracion);
                    // IMPORTANTE: Asegúrate de que tu SP_ACTUALIZAR_EVENTO en SQL Server tenga este parámetro
                    ComandoSql.Parameters.AddWithValue("@es_visible", Evento.EsVisible);

                    int filasAfectadas = ComandoSql.ExecuteNonQuery();
                    EsExitoso = filasAfectadas > 0;
                }
                return EsExitoso;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al actualizar evento: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al actualizar evento: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }        
        public bool ActivarDesactivarEvento(int EventoId, bool EsVisible)
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

                using (SqlCommand ComandoSql = new SqlCommand("SP_ACTIVAR_DESACTIVAR_EVENTO", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;
                    ComandoSql.Parameters.AddWithValue("@evento_id", EventoId);
                    ComandoSql.Parameters.AddWithValue("@es_visible", Convert.ToInt16(EsVisible));
                    int filasAfectadas = ComandoSql.ExecuteNonQuery();
                    EsExitoso = filasAfectadas > 0;
                }
                return EsExitoso;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al activar/desactivar evento: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al activar/desactivar evento: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }
        public int ObtenerSiguienteEventoId()
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

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_SIGUIENTE_EVENTO_ID", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader RespuestaSql = ComandoSql.ExecuteReader())
                    {
                        if (RespuestaSql.Read()) // Solo esperamos una fila con el ID
                        {
                            SiguienteCodigo = Convert.ToInt32(RespuestaSql["siguiente_evento_id"].ToString());
                        }
                    }
                }
                return SiguienteCodigo;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al obtener siguiente evento ID: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al obtener siguiente evento ID: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }
    }
}
