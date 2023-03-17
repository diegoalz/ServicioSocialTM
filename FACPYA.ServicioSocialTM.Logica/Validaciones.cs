using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FACPYA.ServicioSocialTM.Logica
{
    public class Validaciones
    {
        static List<string> Errores = new List<string>();
        static bool ExisteError = false;

        public List<string> GetErrores()
        { 
            return Errores;
        }
        public bool GetExisteError()
        {
            return ExisteError;
        }
        
        public void CleanValues()
        {
            Errores.Clear();
            ExisteError = false;
        }
        public static string CambiarCadena(string termino, string cadenaRemplazable)
        {
            if (termino == cadenaRemplazable)
            {
                return "";
            }
            else
            {
                return termino;
            }
        }
        public string VerificarCadenaNumerica(string cadena, int longitud, string campo, bool estricto)
        {
            SoloNumeros(cadena, campo+":");
            if(estricto == true)
            {
                VerificarLongitud(cadena,longitud,campo+":");
            }
            return cadena;
        }
        public string VerificarNombre(string nombre, string campo)
        {
            NoNumeros(nombre, campo+":");
            return nombre;
        }
        public string VerificarDirecciones(string direccion, string campo)
        {
            NoVacios(direccion, campo+":");
            return direccion;
        }
        public string VerificarCorreo(string correo, string campo)
        {
            NoVacios(correo, campo);
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(correo);
            if (match.Success == false)
            {
                ExisteError = true;
                Errores.Add(campo+":" + " No tiene formato de correo electronico");
            }
            return correo;
        }
        public int VerificarDropDown(int valor, string campo)
        {
            if (valor == 0)
            {
                ExisteError = true;
                Errores.Add(campo+":"+"Falta seleccionar el campo: " + campo);
            }
            return valor;
        }
        protected static void SoloNumeros(string palabra, string campo)
        {
            foreach(char n in palabra)
            {
                if (char.IsDigit(n) == false)
                {
                    ExisteError = true;
                    Errores.Add(campo +" Deben ser solo numericos");
                    break;
                }
            }
        }
        protected static void NoNumeros(string palabra, string campo)
        {
            foreach(char n in palabra)
            {
                if (char.IsDigit(n))
                {
                    ExisteError = true;
                    Errores.Add(campo+" El campo no debe contener numeros");
                    break;
                }
            }
        }
        protected static void VerificarLongitud(string nombre, int longitudNecesaria, string campo)
        {
            int longitudActual = nombre.Length;
            if (longitudActual < longitudNecesaria)
            {
                ExisteError = true;
                Errores.Add(campo+" Faltan caracteres");
            }
            if (longitudActual > longitudNecesaria)
            {
                ExisteError = true;
                Errores.Add(campo+" Demasiados caracteres");
            }
        }
        protected static void NoVacios(string valor, string campo)
        {
            if(valor == null || valor == "" || valor == " ")
            {
                ExisteError = true;
                Errores.Add(campo+" No campos vacios");
            }
        }
    }
}
