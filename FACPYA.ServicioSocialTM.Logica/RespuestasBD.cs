using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACPYA.ServicioSocialTM.Logica
{
    public class RespuestasBD
    {
        public static string ExcepcionesAgregar(string Valor)
        {
            string Mensaje = "";
            if(Valor == "1")
            {
                Mensaje = "Prestador agregador correctamente";
            }
            if(Valor == "2") 
            {
                Mensaje = "Este periodo ya no esta activo";
            }
            if(Valor == "3")
            {
                Mensaje = "El correo ya existe";
            }
            if(Valor == "4")
            {
                Mensaje = "La matricula ya existe";
            }
            return Mensaje;
        }
        public static string ExcepcionesActualizar(string Valor)
        {
            string Mensaje = "";
            if(Valor == "1") 
            {
                Mensaje = "Prestador actualizado correctamente";
            }
            if(Valor == "2")
            {
                Mensaje = "El correo ya existe";
            }
            if(Valor == "3")
            {
                Mensaje = "El prestador no existe";
            }
            return Mensaje;
        }
        public static string ExcepcionesBorrar(string Valor)
        {
            string Mensaje = "";
            if(Valor == "1")
            {
                Mensaje = "Prestador eliminado correctamente";
            }
            if(Valor == "2")
            {
                Mensaje = "El prestador no existe";
            }
            return Mensaje;
        }
    }
}
