using Microsoft.Data.SqlClient;
using pe.com.gctelecom.bo;
using pe.com.muertelenta.dal;
using System; // Necesario para Exception
using System.Collections.Generic;
using System.Data; // Necesario para CommandType

namespace pe.com.gctelecom.dal
{
    public class ClienteDAL
    {
        private ConexionDAL ConexionDAL = new ConexionDAL();

        public List<ClienteBO> ObtenerClientes(bool? EsVisible = null)
        {
            List<ClienteBO> ListaClientes = new List<ClienteBO>();
            SqlConnection? conexion = null; // Declarar la conexión fuera del try
            try
            {
                conexion = ConexionDAL.Conectar(); // Obtener la conexión
                if (conexion == null)
                {
                    // Si la conexión es nula, significa que hubo un error al conectar
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_CLIENTES", conexion))
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
                            ClienteBO Cliente = new ClienteBO();
                            Cliente.ClienteId = Convert.ToInt32(RespuestaSql["cliente_id"].ToString());
                            Cliente.FuenteId = Convert.ToInt32(RespuestaSql["fuente_id"].ToString());
                            Cliente.Nombre = RespuestaSql["nombre"].ToString();
                            Cliente.Correo = RespuestaSql["correo"].ToString();
                            Cliente.Celular = RespuestaSql["celular"].ToString();
                            Cliente.Direccion = RespuestaSql["direccion"].ToString();
                            Cliente.FechaRegistro = Convert.ToDateTime(RespuestaSql["fecha_registro"].ToString());
                            Cliente.EsVisible = Convert.ToBoolean(RespuestaSql["es_visible"].ToString());
                            ListaClientes.Add(Cliente);
                        }
                    }
                }
                return ListaClientes;
            }
            catch (SqlException excepcionSql) // Capturar SqlException específicamente
            {
                Console.WriteLine("Error de SQL al obtener clientes: " + excepcionSql.ToString());
                // Podrías relanzar la excepción o manejarla de otra forma
                throw; // Relanzar para que la capa BAL la capture
            }
            catch (Exception excepcionGeneral) // Capturar otras excepciones
            {
                Console.WriteLine("Error general al obtener clientes: " + excepcionGeneral.ToString());
                throw; // Relanzar para que la capa BAL la capture
            }
            finally
            {
                // Asegurarse de cerrar la conexión
                ConexionDAL.CerrarConexion();
            }
        }

        // Método auxiliar para enviar datos (Crear, Actualizar, Activar/Desactivar)
        private bool EnviarDatosCliente(string NombreProcedimientoAlmacenado, List<KeyValuePair<string, object>> Parametros)
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
                Console.WriteLine("Error de SQL al enviar datos del cliente: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al enviar datos del cliente: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }

        public bool CrearCliente(ClienteBO Cliente)
        {
            var ClienteParametros = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@fuente_id", Cliente.FuenteId),
                new KeyValuePair<string, object>("@nombre", Cliente.Nombre),
                new KeyValuePair<string, object>("@correo", Cliente.Correo),
                new KeyValuePair<string, object>("@celular", Cliente.Celular),
                new KeyValuePair<string, object>("@direccion", Cliente.Direccion),
            };
            return EnviarDatosCliente("SP_CREAR_CLIENTE", ClienteParametros);
        }

        public bool ActualizarCliente(ClienteBO Cliente)
        {
            var ClienteParametros = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@cliente_id", Cliente.ClienteId),
                new KeyValuePair<string, object>("@fuente_id", Cliente.FuenteId),
                new KeyValuePair<string, object>("@nombre", Cliente.Nombre),
                new KeyValuePair<string, object>("@correo", Cliente.Correo),
                new KeyValuePair<string, object>("@celular", Cliente.Celular),
                new KeyValuePair<string, object>("@direccion", Cliente.Direccion),
            };
            return EnviarDatosCliente("SP_ACTUALIZAR_CLIENTE", ClienteParametros);
        }

        public bool ActivarDesactivarCliente(int ClienteId, bool EsVisible)
        {
            var ClienteParametros = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@cliente_id", ClienteId),
                new KeyValuePair<string, object>("@es_visible", Convert.ToInt16(EsVisible))
            };
            return EnviarDatosCliente("SP_ACTIVAR_DESACTIVAR_CLIENTE", ClienteParametros);
        }

        public int ObtenerSiguienteClienteId()
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

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_SIGUIENTE_CLIENTE_ID", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader RespuestaSql = ComandoSql.ExecuteReader())
                    {
                        if (RespuestaSql.Read()) // Solo esperamos una fila con el ID
                        {
                            SiguienteCodigo = Convert.ToInt32(RespuestaSql["siguiente_cliente_id"].ToString());
                        }
                    }
                }
                return SiguienteCodigo;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al obtener siguiente cliente ID: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al obtener siguiente cliente ID: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }
    }
}
