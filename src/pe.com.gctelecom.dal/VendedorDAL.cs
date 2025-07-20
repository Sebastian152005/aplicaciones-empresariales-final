using Microsoft.Data.SqlClient;
using pe.com.gctelecom.bo;
using pe.com.muertelenta.dal;
using System; // Necesario para Exception
using System.Collections.Generic;
using System.Data; // Necesario para CommandType

namespace pe.com.gctelecom.dal
{
    public class VendedorDAL
    {
        private ConexionDAL ConexionDAL = new ConexionDAL();

        public List<VendedorBO> ObtenerVendedores(bool? EsVisible = null)
        {
            List<VendedorBO> ListaVendedores = new List<VendedorBO>();
            SqlConnection? conexion = null; // Declarar la conexión fuera del try
            try
            {
                conexion = ConexionDAL.Conectar(); // Obtener la conexión
                if (conexion == null)
                {
                    // Si la conexión es nula, significa que hubo un error al conectar
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_VENDEDORES", conexion))
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
                            VendedorBO Vendedor = new VendedorBO();
                            Vendedor.VendedorId = Convert.ToInt32(RespuestaSql["vendedor_id"].ToString());
                            Vendedor.Nombre = RespuestaSql["nombre"].ToString();
                            Vendedor.Correo = RespuestaSql["correo"].ToString();
                            Vendedor.Celular = RespuestaSql["celular"].ToString();
                            Vendedor.Direccion = RespuestaSql["direccion"].ToString();
                            Vendedor.EsVisible = Convert.ToBoolean(RespuestaSql["es_visible"].ToString());
                            ListaVendedores.Add(Vendedor);
                        }
                    }
                }
                return ListaVendedores;
            }
            catch (SqlException excepcionSql) // Capturar SqlException específicamente
            {
                Console.WriteLine("Error de SQL al obtener vendedores: " + excepcionSql.ToString());
                throw; // Relanzar para que la capa BAL la capture
            }
            catch (Exception excepcionGeneral) // Capturar otras excepciones
            {
                Console.WriteLine("Error general al obtener vendedores: " + excepcionGeneral.ToString());
                throw; // Relanzar para que la capa BAL la capture
            }
            finally
            {
                // Asegurarse de cerrar la conexión
                ConexionDAL.CerrarConexion();
            }
        }

        // Método auxiliar para enviar datos (Crear, Actualizar, Activar/Desactivar)
        private bool EnviarDatosVendedor(string NombreProcedimientoAlmacenado, List<KeyValuePair<string, object>> Parametros)
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
                Console.WriteLine("Error de SQL al enviar datos del vendedor: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al enviar datos del vendedor: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }

        public bool CrearVendedor(VendedorBO Vendedor)
        {
            var VendedorParametros = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@nombre", Vendedor.Nombre),
                new KeyValuePair<string, object>("@correo", Vendedor.Correo),
                new KeyValuePair<string, object>("@celular", Vendedor.Celular),
                new KeyValuePair<string, object>("@direccion", Vendedor.Direccion),
            };
            return EnviarDatosVendedor("SP_CREAR_VENDEDOR", VendedorParametros);
        }

        public bool ActualizarVendedor(VendedorBO Vendedor)
        {
            var VendedorParametros = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@vendedor_id", Vendedor.VendedorId),
                new KeyValuePair<string, object>("@nombre", Vendedor.Nombre),
                new KeyValuePair<string, object>("@correo", Vendedor.Correo),
                new KeyValuePair<string, object>("@celular", Vendedor.Celular),
                new KeyValuePair<string, object>("@direccion", Vendedor.Direccion),
            };
            return EnviarDatosVendedor("SP_ACTUALIZAR_VENDEDOR", VendedorParametros);
        }

        public bool ActivarDesactivarVendedor(int VendedorId, bool EsVisible)
        {
            var VendedorParametros = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@vendedor_id", VendedorId),
                new KeyValuePair<string, object>("@es_visible", Convert.ToInt16(EsVisible))
            };
            return EnviarDatosVendedor("SP_ACTIVAR_DESACTIVAR_VENDEDOR", VendedorParametros);
        }

        public int ObtenerSiguienteVendedorId()
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

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_SIGUIENTE_VENDEDOR_ID", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader RespuestaSql = ComandoSql.ExecuteReader())
                    {
                        if (RespuestaSql.Read()) // Solo esperamos una fila con el ID
                        {
                            SiguienteCodigo = Convert.ToInt32(RespuestaSql["siguiente_vendedor_id"].ToString());
                        }
                    }
                }
                return SiguienteCodigo;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al obtener siguiente vendedor ID: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al obtener siguiente vendedor ID: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }
    }
}
