
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace pe.com.muertelenta.dal

{
    public class ConexionDAL

    {           
        private string cadena = "Data Source=localhost; Initial Catalog=gctelecomdb; Integrated Security=true; TrustServerCertificate=True;";
        private SqlConnection xcon;
        public SqlConnection? Conectar()
        {
            try
            {
                //Instanciamos la conexion con la cadena
                xcon = new SqlConnection(cadena);
                //Abrimos la conexion
                xcon.Open();
                //Devolvemos la conexion abierta
                return xcon;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        //Creamos un procedimiento para cerrar
        public void CerrarConexion()
        {
            //Cerramos la conexion
            xcon.Close();
            //Liberamos recursos
            xcon.Dispose();
        }
    }
}