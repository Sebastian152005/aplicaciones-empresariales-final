using Microsoft.Data.SqlClient;
using pe.com.gctelecom.bo; // Asegúrate de que esta referencia sea correcta
using pe.com.muertelenta.dal;
using System; // Necesario para Exception
using System.Collections.Generic;
using System.Data; // Necesario para CommandType

namespace pe.com.gctelecom.dal
{
    // Asumiendo que tienes una clase FuenteBO en pe.com.gctelecom.bo
    // Si no la tienes, aquí hay un ejemplo básico:
    /*
    namespace pe.com.gctelecom.bo
    {
        public class FuenteBO
        {
            public int FuenteId { get; set; }
            public string Nombre { get; set; }
            public bool EsVisible { get; set; }
        }
    }
    */

    public class FuenteDAL
    {
        private ConexionDAL ConexionDAL = new ConexionDAL();

        public List<FuenteBO> ObtenerFuentes(bool? EsVisible = null)
        {
            List<FuenteBO> ListaFuentes = new List<FuenteBO>();
            SqlConnection? conexion = null; // Declarar la conexión fuera del try
            try
            {
                conexion = ConexionDAL.Conectar(); // Obtener la conexión
                if (conexion == null)
                {
                    // Si la conexión es nula, significa que hubo un error al conectar
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_FUENTES", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    // Añadir el parámetro @es_visible
                    if (EsVisible.HasValue)
                    {
                        ComandoSql.Parameters.AddWithValue("@es_visible", Convert.ToInt16(EsVisible.Value));
                    }
                    else
                    {
                        ComandoSql.Parameters.AddWithValue("@es_visible", DBNull.Value); // Pasar DBNull para NULL
                    }

                    using (SqlDataReader RespuestaSql = ComandoSql.ExecuteReader())
                    {
                        while (RespuestaSql.Read())
                        {
                            FuenteBO Fuente = new FuenteBO();
                            Fuente.FuenteId = Convert.ToInt32(RespuestaSql["fuente_id"].ToString());
                            Fuente.Nombre = RespuestaSql["nombre"].ToString();
                            Fuente.EsVisible = Convert.ToBoolean(RespuestaSql["es_visible"].ToString());
                            ListaFuentes.Add(Fuente);
                        }
                    }
                }
                return ListaFuentes;
            }
            catch (SqlException excepcionSql) // Capturar SqlException específicamente
            {
                Console.WriteLine("Error de SQL al obtener fuentes: " + excepcionSql.ToString());
                throw; // Relanzar para que la capa BAL la capture
            }
            catch (Exception excepcionGeneral) // Capturar otras excepciones
            {
                Console.WriteLine("Error general al obtener fuentes: " + excepcionGeneral.ToString());
                throw; // Relanzar para que la capa BAL la capture
            }
            finally
            {
                // Asegurarse de cerrar la conexión
                ConexionDAL.CerrarConexion();
            }
        }

        // Método auxiliar para enviar datos (Crear, Actualizar, Activar/Desactivar)
        private bool EnviarDatosFuente(string NombreProcedimientoAlmacenado, List<KeyValuePair<string, object>> Parametros)
        {
            bool EsExitoso = false;
            SqlConnection? conexion = null; // Declarar la conexión fuera del try
            try
            {
                conexion = ConexionDAL.Conectar(); // Obtener la conexión
                if (conexion == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                using (SqlCommand ComandoSql = new SqlCommand(NombreProcedimientoAlmacenado, conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    foreach (var param in Parametros)
                    {
                        if (param.Value == null)
                        {
                            ComandoSql.Parameters.AddWithValue(param.Key, DBNull.Value);
                        }
                        else
                        {
                            ComandoSql.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    int filasAfectadas = ComandoSql.ExecuteNonQuery();
                    EsExitoso = filasAfectadas > 0; // Si se afectó al menos una fila, es exitoso
                }
                return EsExitoso;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al enviar datos de la fuente: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al enviar datos de la fuente: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }

        public bool CrearFuente(FuenteBO Fuente)
        {
            var FuenteParametros = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@nombre", Fuente.Nombre),
            };
            return EnviarDatosFuente("SP_CREAR_FUENTE", FuenteParametros);
        }

        public bool ActualizarFuente(FuenteBO Fuente)
        {
            var FuenteParametros = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@fuente_id", Fuente.FuenteId),
                new KeyValuePair<string, object>("@nombre", Fuente.Nombre),
            };
            return EnviarDatosFuente("SP_ACTUALIZAR_FUENTE", FuenteParametros);
        }

        public bool ActivarDesactivarFuente(int FuenteId, bool EsVisible)
        {
            var FuenteParametros = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@fuente_id", FuenteId),
                new KeyValuePair<string, object>("@es_visible", Convert.ToInt16(EsVisible))
            };
            return EnviarDatosFuente("SP_ACTIVAR_DESACTIVAR_FUENTE", FuenteParametros);
        }

        public int ObtenerSiguienteFuenteId()
        {
            int SiguienteCodigo = 0;
            SqlConnection? conexion = null; // Declarar la conexión fuera del try
            try
            {
                conexion = ConexionDAL.Conectar(); // Obtener la conexión
                if (conexion == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_SIGUIENTE_FUENTE_ID", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader RespuestaSql = ComandoSql.ExecuteReader())
                    {
                        if (RespuestaSql.Read()) // Solo esperamos una fila con el ID
                        {
                            SiguienteCodigo = Convert.ToInt32(RespuestaSql["siguiente_fuente_id"].ToString());
                        }
                    }
                }
                return SiguienteCodigo;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al obtener siguiente fuente ID: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al obtener siguiente fuente ID: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }
    }
}
