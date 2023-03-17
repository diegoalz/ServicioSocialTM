using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACPYA.ServicioSocialTM.Entidad.dbEntidad
{
    public class bdPrestador
    {
        public int IdPrestador {get; set;}
        public int IdEstatus {get; set;}
        public int IdCampus {get; set;}
        public int IdDependencia {get; set;}
        public int IdDepartamento {get; set;}
        public int IdModalidad {get; set;}
        public int IdPeriodo {get; set;}
        public int IdCarrera {get; set;}
        public int IdSemestre {get; set;}
        public string Matricula {get; set;}
        public string Nombre {get; set;}
        public string PrimerApellido {get; set;}
        public string SegundoApellido {get; set;}
        public string FechaNacimiento {get; set;}
        public string CorreoUniversitario {get; set;}
        public string Telefono {get; set;}
        public string Calle {get; set;}
        public string Numero {get; set;}
        public string Colonia {get; set;}
        public string CodigoPostal {get; set;}
        public string FechaIngreso {get; set;}
        public string HoraInicio {get; set;}
        public string HoraFin {get; set;}
        public string RutaDocumento {get; set;}
        public string FechaRegistro {get; set;}
        public string FechaModificacion {get; set;}
        public string FechaBaja {get; set;}
    }
}
