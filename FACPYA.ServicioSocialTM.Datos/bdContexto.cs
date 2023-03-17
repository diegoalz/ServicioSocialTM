using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACPYA.ServicioSocialTM.Datos
{
    public class bdContexto
    {
        // Solo cadena de conexion, si se necesita ver detalles, editar o agregar una cadena de conexion nueva, ir al archivo
        // Web.config de FACPYA.SIGA.Presentacion

        // Nombre del ConnectionStrings a libre eleccion, si se desea cambiar afectar tambien al archivo web.config de Presentacion

        static private readonly string appConexion = ConfigurationManager.ConnectionStrings["bdConexion"].ConnectionString;

        // Se ejecuta stored con paramaetros
        public static DataTable funcionStored(string sentencia, SqlParameter[] parametroSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = new SqlConnection(appConexion))
                {
                    conn.Open();
                    using (var comando = new SqlCommand(sentencia, conn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddRange(parametroSQL);
                        using (var adaptador = new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Se ejecuta stored sin parametros
        public static DataTable funcionStored(string sentencia)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = new SqlConnection(appConexion))
                {
                    conn.Open();
                    using (var comando = new SqlCommand(sentencia, conn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        using (var adaptador = new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
