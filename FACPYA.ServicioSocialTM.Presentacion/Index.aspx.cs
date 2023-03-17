using FACPYA.ServicioSocialTM.Entidad.ddlEntidad;
using FACPYA.ServicioSocialTM.Entidad.dgEntidad;
using FACPYA.ServicioSocialTM.Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FACPYA.ServicioSocialTM.Presentacion
{
    public partial class Index : System.Web.UI.Page
    {
        //Llamado a la capa logica para llenar la tabla de prestadores
        public void leerPrestadores()
        {
            dgPrestadorTabla.DataSource = LogicaPrestador.Leer("", "","","","","","");
            dgPrestadorTabla.DataBind();
        }

        //Llamado a la capa de logica para llenar el catalogo
        public void ddlLlenar()
        {   
            // Generar dropdown de dependencia
            ddlDependencia.DataSource = LogicaCatalogo.LeerCatalogo("DEPENDENCIA", 1, "IdDependencia", null, null);
            ddlDependencia.DataValueField = "Id";
            ddlDependencia.DataTextField = "Descripcion";
            ddlDependencia.DataBind();
            ddlDependencia.Items.Insert(0, new ListItem("Seleccione", "0"));
            // Generar dropdown del campus
            ddlCampus.DataSource = LogicaCatalogo.LeerCatalogo("CAMPUS", 1, "IdCampus", null, null);
            ddlCampus.DataValueField = "Id";
            ddlCampus.DataTextField = "Descripcion";
            ddlCampus.DataBind();
            ddlCampus.Items.Insert(0, new ListItem("Seleccione", "0"));
            // Generar dropdown de la carrera
            ddlCarrera.DataSource = LogicaCatalogo.LeerCatalogo("CARRERA", 1, "IdCarrera", null, null);
            ddlCarrera.DataValueField = "Id";
            ddlCarrera.DataTextField = "Descripcion";
            ddlCarrera.DataBind();
            ddlCarrera.Items.Insert(0, new ListItem("Seleccione", "0"));
            // Generar dropdown del periodo
            ddlPeriodo.DataSource = LogicaCatalogo.LeerCatalogo("PERIODO", 1, "IdPeriodo", null, null);
            ddlPeriodo.DataValueField = "Id";
            ddlPeriodo.DataTextField = "Descripcion";
            ddlPeriodo.DataBind();
            ddlPeriodo.Items.Insert(0, new ListItem("Seleccione", "0"));
            // Generar dropwdown de la modalidad
            ddlModalidad.DataSource = LogicaCatalogo.LeerCatalogo("MODALIDAD", 1, "IdModalidad", null, null);
            ddlModalidad.DataValueField = "Id";
            ddlModalidad.DataTextField = "Descripcion";
            ddlModalidad.DataBind();
            ddlModalidad.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        //Metodos que se ejecutan al iniciar la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlLlenar();
                leerPrestadores();
                dgPrestadorTabla.HeaderStyle.CssClass = "bg-gray-600 p-2 text-white font-bold md:border md:border-grey-500 text-left block border md:border-none block md:table-row absolute -top-full md:top-auto -left-full md:left-auto md:relative ";
                dgPrestadorTabla.RowStyle.CssClass = "p-2 md:border md:border-grey-500 text-left bg-gray-300 border border-grey-500";
                dgPrestadorTabla.AlternatingRowStyle.CssClass = "p-2 md:border md:border-grey-500 text-left bg-white-300 border border-grey-500";
            }
        }

        protected void tablaPrestador_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Se ejecuta automaticamente el metodo tipo evento cuando cambia el campo de campus
        protected void ddlCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlCampus.SelectedItem.Value == "0")
            {
                ddlDependencia.DataSource = LogicaCatalogo.LeerCatalogo("DEPENDENCIA", 1, "IdDependencia", null, null);
                ddlDependencia.DataValueField = "Id";
                ddlDependencia.DataTextField = "Descripcion";
                ddlDependencia.DataBind();
                ddlDependencia.Items.Insert(0, new ListItem("Seleccione", "0"));
            }else if(ddlCampus.SelectedItem.Value != "0")
            {
                ddlDependencia.DataSource = LogicaCatalogo.LeerCatalogo(null, null, null, 1, Convert.ToInt32(ddlCampus.SelectedItem.Value));
                ddlDependencia.DataValueField = "Id";
                ddlDependencia.DataTextField = "Descripcion";
                ddlDependencia.DataBind();
                ddlDependencia.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
        }

        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        // Metodo que se ejecuta para mandar los datos de busqueda
        protected void buscar_Click(object sender, EventArgs e)
        {
            string dependencia = Validaciones.CambiarCadena(ddlDependencia.SelectedItem.Text, "Seleccione");
            string campus = Validaciones.CambiarCadena(ddlCampus.SelectedItem.Text, "Seleccione");
            string carrera = Validaciones.CambiarCadena(ddlCarrera.SelectedItem.Text, "Seleccione");
            string periodo = Validaciones.CambiarCadena(ddlPeriodo.SelectedItem.Text, "Seleccione");
            string modalidad = Validaciones.CambiarCadena(ddlModalidad.SelectedItem.Text, "Seleccione");
            Validaciones objeto = new Validaciones();
            string matricula = objeto.VerificarCadenaNumerica(BuscarMatricula.Text,7 ,"Matricula", false);
            string nombre = objeto.VerificarNombre(BuscarNombre.Text, "Nombre");
            // Verificar que existan errores
            if (objeto.GetExisteError() == true)
            {
                // Recorrer lista de errores y mandarlos a javascript
                List<string> listaErrores = objeto.GetErrores();
                if (listaErrores.Count > 0)
                {
                    string alerta = "";
                    foreach (string n in listaErrores)
                    {
                        alerta += n+"</br>";
                    }
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "EjecutarAlerta('"+ alerta +"'); ", true);
                }
                listaErrores.Clear();
            }
            else
            { 
                dgPrestadorTabla.DataSource = LogicaPrestador.Leer(matricula, nombre, dependencia, campus, carrera, periodo, modalidad);
                dgPrestadorTabla.DataBind();
            }
            objeto.CleanValues();
        }
        // Metodo para redirigir al formulario mediante el boton Crear
        protected void IndexCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Formulario.aspx?opcion=C");
        }
        // Metodo que se utiliza para redirigir al formulario mediante el boton editar
        protected void Editar_Click(object sender, EventArgs e)
        {
            // Aqui el original
            string Id;
            Button btnEditar = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnEditar.NamingContainer;
            int rowIndex = selectedRow.RowIndex;
            Id = dgPrestadorTabla.DataKeys[rowIndex].Value.ToString();
            Response.Redirect("~/Formulario.aspx?opcion=U" + "&Id=" + Id);
        }
        // Metodo que se utiliza para redirigir al formulario mediante el boton borrar
        protected void Borrar_Click(object sender, EventArgs e)
        {
            string Id;
            Button btnEditar = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnEditar.NamingContainer;
            int rowIndex = selectedRow.RowIndex;
            Id = dgPrestadorTabla.DataKeys[rowIndex].Value.ToString();
            //Id = selectedRow.Cells[1].Text;
            Response.Redirect("~/Formulario.aspx?opcion=D" + "&Id=" + Id);
        }
        protected void dgPrestadorTabla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Metodo para limpiar los filtros
        protected void IndexLimpiarFiltros(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
            //ddlDependencia.SelectedItem.Text = "Seleccione";
            //ddlCampus.SelectedItem.Text = "Seleccione";
            //ddlCarrera.SelectedItem.Text = "Seleccione";
            //ddlPeriodo.SelectedItem.Text = "Seleccione";
            //ddlModalidad.SelectedItem.Text = "Seleccione";
            //BuscarMatricula.Text = "";
            //BuscarNombre.Text = "";
        }
    }
}