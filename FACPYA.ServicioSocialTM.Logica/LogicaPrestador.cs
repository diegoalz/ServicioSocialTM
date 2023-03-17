using FACPYA.ServicioSocialTM.Datos;
using FACPYA.ServicioSocialTM.Entidad.dbEntidad;
using FACPYA.ServicioSocialTM.Entidad.dgEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACPYA.ServicioSocialTM.Logica
{
    public class LogicaPrestador
    {
        // Crear
        public static string Crear(bdPrestador parametro)
        {
            string control;
            try
            {
                DataTable tabla = new DataTable();
                SqlParameter[] parameters = {
                    new SqlParameter ( "@Accion", 1),
                    new SqlParameter ( "@IdCampus", parametro.IdCampus),
                    new SqlParameter ( "@IdDependencia", parametro.IdDependencia),
                    new SqlParameter ( "@IdDepartamento", parametro.IdDepartamento),
                    new SqlParameter ( "@IdModalidad", parametro.IdModalidad),
                    new SqlParameter ( "@IdCarrera", parametro.IdCarrera),
                    new SqlParameter ( "@IdSemestre", parametro.IdSemestre),
                    new SqlParameter ( "@Matricula", parametro.Matricula),
                    new SqlParameter ( "@Nombre", parametro.Nombre),
                    new SqlParameter ( "@PrimerApellido", parametro.PrimerApellido),
                    new SqlParameter ( "@SegundoApellido", parametro.SegundoApellido),
                    new SqlParameter ( "@FechaNacimiento", parametro.FechaNacimiento),
                    new SqlParameter ( "@CorreoUniversitario", parametro.CorreoUniversitario),
                    new SqlParameter ( "@Telefono", parametro.Telefono),
                    new SqlParameter ( "@Calle", parametro.Calle),
                    new SqlParameter ( "@Numero", parametro.Numero),
                    new SqlParameter ( "@Colonia", parametro.Colonia),
                    new SqlParameter ( "@CodigoPostal", parametro.CodigoPostal),
                    new SqlParameter ( "@FechaIngreso", parametro.FechaIngreso),
                    new SqlParameter ( "@HoraInicio", parametro.HoraInicio),
                    // new SqlParameter ( "@HoraFin", parametro.HoraFin),
                    new SqlParameter ( "@RutaDocumento", parametro.RutaDocumento)
                };
                tabla = bdContexto.funcionStored("spPrestador", parameters);
                control = tabla.Rows[0]["MENSAJE"].ToString();
                //control = tabla.ToString();
            }
            catch(Exception e)
            {
                control = e.ToString();
            }
            return control;
        }
        // Leer
        public static List<dgPrestador> Leer(string PMatricula, string PNombre, string PDependencia, string PCampus, string PCarrera, string PPeriodo, string PModalidad) 
        {
            List<dgPrestador> listar = new List<dgPrestador>();
            DataTable tabla = new DataTable();

            SqlParameter[] parameters = {
                    new SqlParameter ( "@Accion", 2),
                    new SqlParameter ("@FiltroMatricula", PMatricula),
                    new SqlParameter ("@PrestadorNombre", PNombre),
                    new SqlParameter ("@FiltroDependencia", PDependencia),
                    new SqlParameter ("@FiltroCampus", PCampus),
                    new SqlParameter ("@FiltroCarrera", PCarrera),
                    new SqlParameter ("@FiltroPeriodo", PPeriodo),
                    new SqlParameter ("@FiltroModalidad", PModalidad)
            };
            tabla = bdContexto.funcionStored("spPrestador", parameters);
            if (tabla.Rows.Count > 0)
            { 
                listar = (from DataRow fila in tabla.Rows select new dgPrestador {
                    IdPrestador = Convert.ToInt32(fila["IdPrestador"].ToString()),
                    IdEstatus = Convert.ToInt32(fila["IdEstatus"].ToString()),
                    IdCampus = Convert.ToInt32(fila["IdCampus"].ToString()),
                    IdDependencia = Convert.ToInt32(fila["IdDependencia"].ToString()),
                    IdDepartamento = Convert.ToInt32(fila["IdDepartamento"].ToString()),
                    IdModalidad = Convert.ToInt32(fila["IdModalidad"].ToString()),
                    IdPeriodo = Convert.ToInt32(fila["IdPeriodo"].ToString()),
                    IdCarrera = Convert.ToInt32(fila["IdCarrera"].ToString()),
                    IdSemestre = Convert.ToInt32(fila["IdSemestre"].ToString()),
                    Matricula = fila["Matricula"].ToString(),
                    Nombre = fila["Nombre"].ToString(),
                    PrimerApellido = fila["PrimerApellido"].ToString(),
                    SegundoApellido = fila["SegundoApellido"].ToString(),
                    FechaNacimiento = fila["FechaNacimiento"].ToString(),
                    CorreoUniversitario = fila["CorreoUniversitario"].ToString(),
                    Telefono = fila["Telefono"].ToString(),
                    Calle = fila["Calle"].ToString(),
                    Numero = fila["Numero"].ToString(),
                    Colonia = fila["Colonia"].ToString(),
                    CodigoPostal = fila["CodigoPostal"].ToString(),
                    FechaIngreso = fila["FechaIngreso"].ToString(),
                    HoraInicio = fila["HoraInicio"].ToString(),
                    HoraFin = fila["HoraFin"].ToString(),
                    RutaDocumento = fila["RutaDocumento"].ToString(),
                    FechaRegistro = fila["FechaRegistro"].ToString(),
                    FechaModificacion = fila["FechaModificacion"].ToString(),
                    FechaBaja = fila["FechaBaja"].ToString(),
                    PrestadorServicioSocial = fila["Prestador Servicio Social"].ToString(),
                    Edad = Convert.ToInt32(fila["Edad"].ToString()),
                    ProgramaEducativo = fila["Programa Educativo"].ToString(),
                    AreaLaboral = fila["Area Laboral"].ToString(),
                    Contacto = fila["Contacto"].ToString()
                }).ToList();
            }
            return listar;
        }
        // Actualizar
        public static string Actualizar(bdPrestador parametro)
        {
            string control;
            try
            {
                DataTable tabla = new DataTable();
                SqlParameter[] parameters = {
                    new SqlParameter ( "@Accion", 3),
                    new SqlParameter ("@IdPrestador", parametro.IdPrestador),
                    new SqlParameter ( "@IdCampus", parametro.IdCampus),
                    new SqlParameter ( "@IdDependencia", parametro.IdDependencia),
                    new SqlParameter ( "@IdDepartamento", parametro.IdDepartamento),
                    new SqlParameter ( "@IdModalidad", parametro.IdModalidad),
                    new SqlParameter ( "@IdCarrera", parametro.IdCarrera),
                    new SqlParameter ( "@IdSemestre", parametro.IdSemestre),
                    new SqlParameter ( "@Matricula", parametro.Matricula),
                    new SqlParameter ( "@Nombre", parametro.Nombre),
                    new SqlParameter ( "@PrimerApellido", parametro.PrimerApellido),
                    new SqlParameter ( "@SegundoApellido", parametro.SegundoApellido),
                    new SqlParameter ( "@FechaNacimiento", parametro.FechaNacimiento),
                    new SqlParameter ( "@CorreoUniversitario", parametro.CorreoUniversitario),
                    new SqlParameter ( "@Telefono", parametro.Telefono),
                    new SqlParameter ( "@Calle", parametro.Calle),
                    new SqlParameter ( "@Numero", parametro.Numero),
                    new SqlParameter ( "@Colonia", parametro.Colonia),
                    new SqlParameter ( "@CodigoPostal", parametro.CodigoPostal),
                    new SqlParameter ( "@FechaIngreso", parametro.FechaIngreso),
                    new SqlParameter ( "@HoraInicio", parametro.HoraInicio),
                    // new SqlParameter ( "@HoraFin", parametro.HoraFin),
                    new SqlParameter ( "@RutaDocumento", parametro.RutaDocumento)
                };
                tabla = bdContexto.funcionStored("spPrestador", parameters);
                control = tabla.Rows[0]["MENSAJE"].ToString();
            }
            catch (Exception e)
            {
                control = e.ToString();
            }
            return control;
        }
        // Eliminar
        public static string Eliminar(bdPrestador parametro)
        {
            string control;
            try
            {
                DataTable tabla = new DataTable();
                SqlParameter[] parameters = {
                    new SqlParameter ( "@Accion", 4),
                    new SqlParameter ("@IdPrestador", parametro.IdPrestador)
                };
                tabla = bdContexto.funcionStored("spPrestador", parameters);
                control = tabla.Rows[0]["MENSAJE"].ToString();
            }
            catch (Exception e)
            {
                control = e.ToString();
            }
            return control;
        }

        public static bdPrestador infoPrestador(int PIdPrestador)
        {
            bdPrestador Prestador = new bdPrestador();
            DataTable tabla = new DataTable();
            SqlParameter[] parameters =
            {
                new SqlParameter ("@Accion", 5),
                new SqlParameter ("@IdPrestador", PIdPrestador)
            };
            tabla = bdContexto.funcionStored("spPrestador", parameters);
            
            if (tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                Prestador.IdPrestador = Convert.ToInt32(fila["IdPrestador"].ToString());
                Prestador.IdEstatus = Convert.ToInt32(fila["IdEstatus"].ToString());
                Prestador.IdCampus = Convert.ToInt32(fila["IdCampus"].ToString());
                Prestador.IdDependencia = Convert.ToInt32(fila["IdDependencia"].ToString());
                Prestador.IdDepartamento = Convert.ToInt32(fila["IdDepartamento"].ToString());
                Prestador.IdModalidad = Convert.ToInt32(fila["IdModalidad"].ToString());
                Prestador.IdPeriodo = Convert.ToInt32(fila["IdPeriodo"].ToString());
                Prestador.IdCarrera = Convert.ToInt32(fila["IdCarrera"].ToString());
                Prestador.IdSemestre = Convert.ToInt32(fila["IdSemestre"].ToString());
                Prestador.Matricula = fila["Matricula"].ToString();
                Prestador.Nombre = fila["Nombre"].ToString();
                Prestador.PrimerApellido = fila["PrimerApellido"].ToString();
                Prestador.SegundoApellido = fila["SegundoApellido"].ToString();
                Prestador.FechaNacimiento = fila["FechaNacimiento"].ToString();
                Prestador.CorreoUniversitario = fila["CorreoUniversitario"].ToString();
                Prestador.Telefono = fila["Telefono"].ToString();
                Prestador.Calle = fila["Calle"].ToString();
                Prestador.Numero = fila["Numero"].ToString();
                Prestador.Colonia = fila["Colonia"].ToString();
                Prestador.CodigoPostal = fila["CodigoPostal"].ToString();
                Prestador.FechaIngreso = fila["FechaIngreso"].ToString();
                Prestador.HoraInicio = fila["HoraInicio"].ToString();
                Prestador.HoraFin = fila["HoraFin"].ToString();
                Prestador.RutaDocumento = fila["RutaDocumento"].ToString();
                Prestador.FechaRegistro = fila["FechaRegistro"].ToString();
                Prestador.FechaModificacion = fila["FechaModificacion"].ToString();
                Prestador.FechaBaja = fila["FechaBaja"].ToString();
            }
            return Prestador;
        }
    }
}
