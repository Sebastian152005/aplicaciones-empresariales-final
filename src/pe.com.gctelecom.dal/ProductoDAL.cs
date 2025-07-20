using Microsoft.Data.SqlClient;
using pe.com.gctelecom.bo; // Asegúrate de que esta referencia sea correcta
using pe.com.muertelenta.dal;
using System; // Necesario para Exception
using System.Collections.Generic;
using System.Data; // Necesario para CommandType

namespace pe.com.gctelecom.dal
{
    public class ProductoDAL
    {
        private ConexionDAL ConexionDAL = new ConexionDAL();

        public List<ProductoBO> ObtenerProductos(bool? EsVisible = null)
        {
            List<ProductoBO> ListaProductos = new List<ProductoBO>();
            SqlConnection? conexion = null; // Declarar la conexión fuera del try
            try
            {
                conexion = ConexionDAL.Conectar(); // Obtener la conexión
                if (conexion == null)
                {
                    // Si la conexión es nula, significa que hubo un error al conectar
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_PRODUCTOS", conexion))
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
                            ProductoBO Producto = new ProductoBO();
                            Producto.ProductoId = Convert.ToInt32(RespuestaSql["producto_id"].ToString());
                            Producto.Nombre = RespuestaSql["nombre"].ToString();
                            Producto.Descripcion = RespuestaSql["descripcion"].ToString();
                            Producto.Precio = Convert.ToDecimal(RespuestaSql["precio"].ToString());
                            Producto.Moneda = RespuestaSql["moneda"].ToString();
                            Producto.EsVisible = Convert.ToBoolean(RespuestaSql["es_visible"].ToString());
                            ListaProductos.Add(Producto);
                        }
                    }
                }
                return ListaProductos;
            }
            catch (SqlException excepcionSql) // Capturar SqlException específicamente
            {
                Console.WriteLine("Error de SQL al obtener productos: " + excepcionSql.ToString());
                throw; // Relanzar para que la capa BAL la capture
            }
            catch (Exception excepcionGeneral) // Capturar otras excepciones
            {
                Console.WriteLine("Error general al obtener productos: " + excepcionGeneral.ToString());
                throw; // Relanzar para que la capa BAL la capture
            }
            finally
            {
                // Asegurarse de cerrar la conexión
                ConexionDAL.CerrarConexion();
            }
        }

        // Método auxiliar para enviar datos (Crear, Actualizar, Activar/Desactivar)
        private bool EnviarDatosProducto(string NombreProcedimientoAlmacenado, List<KeyValuePair<string, object>> Parametros)
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
                Console.WriteLine("Error de SQL al enviar datos del producto: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al enviar datos del producto: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }

        public bool CrearProducto(ProductoBO Producto)
        {
            var ProductoParametros = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@nombre", Producto.Nombre),
                new KeyValuePair<string, object>("@descripcion", Producto.Descripcion),
                new KeyValuePair<string, object>("@precio", Producto.Precio)
            };
            return EnviarDatosProducto("SP_CREAR_PRODUCTO", ProductoParametros);
        }

        public bool ActualizarProducto(ProductoBO Producto)
        {
            var ProductoParametros = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@producto_id", Producto.ProductoId),
                new KeyValuePair<string, object>("@nombre", Producto.Nombre),
                new KeyValuePair<string, object>("@descripcion", Producto.Descripcion),
                new KeyValuePair<string, object>("@precio", Producto.Precio)
            };
            return EnviarDatosProducto("SP_ACTUALIZAR_PRODUCTO", ProductoParametros);
        }

        public bool ActivarDesactivarProducto(int ProductoId, bool EsVisible)
        {
            var ProductoParametros = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@producto_id", ProductoId),
                new KeyValuePair<string, object>("@es_visible", Convert.ToInt16(EsVisible))
            };
            return EnviarDatosProducto("SP_ACTIVAR_DESACTIVAR_PRODUCTO", ProductoParametros);
        }

        public int ObtenerSiguienteProductoId()
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

                using (SqlCommand ComandoSql = new SqlCommand("SP_OBTENER_SIGUIENTE_PRODUCTO_ID", conexion))
                {
                    ComandoSql.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader RespuestaSql = ComandoSql.ExecuteReader())
                    {
                        if (RespuestaSql.Read()) // Solo esperamos una fila con el ID
                        {
                            SiguienteCodigo = Convert.ToInt32(RespuestaSql["siguiente_producto_id"].ToString());
                        }
                    }
                }
                return SiguienteCodigo;
            }
            catch (SqlException excepcionSql)
            {
                Console.WriteLine("Error de SQL al obtener siguiente producto ID: " + excepcionSql.ToString());
                throw;
            }
            catch (Exception excepcionGeneral)
            {
                Console.WriteLine("Error general al obtener siguiente producto ID: " + excepcionGeneral.ToString());
                throw;
            }
            finally
            {
                ConexionDAL.CerrarConexion();
            }
        }
    }
}
