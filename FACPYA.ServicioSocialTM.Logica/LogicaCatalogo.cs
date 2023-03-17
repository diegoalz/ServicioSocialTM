using FACPYA.ServicioSocialTM.Datos;
using FACPYA.ServicioSocialTM.Entidad.ddlEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACPYA.ServicioSocialTM.Logica
{
    public class LogicaCatalogo
    {
        public static List<ddlCatalogo> LeerCatalogo(string PNombreTabla, int? PTieneEstatus, string PNombreId, int? PCampusDependencia, int? PIdCampus)
        {
            List < ddlCatalogo > catalogo = new List<ddlCatalogo>();
            DataTable tabla = new DataTable();
            SqlParameter[] parameters = {
                    new SqlParameter ( "@NombreTabla", PNombreTabla),
                    new SqlParameter ("@TieneEstatus", PTieneEstatus),
                    new SqlParameter ("@NombreId", PNombreId),
                    new SqlParameter ("@CampusDependencia", PCampusDependencia),
                    new SqlParameter ("@IdCampus", PIdCampus)
            };
            tabla = bdContexto.funcionStored("spLeerTablas", parameters);
            if (tabla.Rows.Count > 0)
            {
                catalogo = (from DataRow fila in tabla.Rows
                          select new ddlCatalogo
                          {
                              Id = Convert.ToInt32(fila["Id"].ToString()),
                              Descripcion = fila["Descripcion"].ToString()
                          }).ToList();
            }
            return catalogo;
        }
    }
}
