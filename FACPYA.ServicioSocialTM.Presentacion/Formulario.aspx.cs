using FACPYA.ServicioSocialTM.Entidad.dbEntidad;
using FACPYA.ServicioSocialTM.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FACPYA.ServicioSocialTM.Presentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private void ddlLlenar()
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
            // Generar dropwdown de la modalidad
            ddlModalidad.DataSource = LogicaCatalogo.LeerCatalogo("MODALIDAD", 1, "IdModalidad", null, null);
            ddlModalidad.DataValueField = "Id";
            ddlModalidad.DataTextField = "Descripcion";
            ddlModalidad.DataBind();
            ddlModalidad.Items.Insert(0, new ListItem("Seleccione", "0"));
            // Generar dropdown de la departamento
            ddlDepartamento.DataSource = LogicaCatalogo.LeerCatalogo("Departamento", 1, "IdDepartamento", null, null);
            ddlDepartamento.DataValueField = "Id";
            ddlDepartamento.DataTextField = "Descripcion";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccione", "0"));
            // Generar dropdown del semestre
            ddlSemestre.DataSource = LogicaCatalogo.LeerCatalogo("SEMESTRE", 0, "IdSemestre", null, null);
            ddlSemestre.DataValueField = "Id";
            ddlSemestre.DataTextField = "Descripcion";
            ddlSemestre.DataBind();
            ddlSemestre.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        private void llenarFormulario()
        {
            if (Request.QueryString["Id"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                bdPrestador PrestadorActual = LogicaPrestador.infoPrestador(Id);
                // Rellenar input text
                TxtNombre.Text = PrestadorActual.Nombre;
                TxtApellido_paterno.Text = PrestadorActual.PrimerApellido;
                TxtApellido_materno.Text = PrestadorActual.SegundoApellido;
                TxtFecha_nacimiento.Text = Convert.ToDateTime(PrestadorActual.FechaNacimiento).ToString("yyyy-MM-dd");
                TxtMatricula.Text = PrestadorActual.Matricula;
                TxtCorreo.Text = PrestadorActual.CorreoUniversitario;
                TxtTelefono.Text = PrestadorActual.Telefono;
                TxtCalle.Text = PrestadorActual.Calle;
                TxtNumero.Text = PrestadorActual.Numero;
                TxtColonia.Text = PrestadorActual.Colonia;
                TxtCodigo_postal.Text = PrestadorActual.CodigoPostal;
                TxtFecha_ingreso.Text = Convert.ToDateTime(PrestadorActual.FechaIngreso).ToString("yyyy-MM-dd");
                TxtHora_inicio.Text = PrestadorActual.HoraInicio;
                TxtRuta_documento.Text = PrestadorActual.RutaDocumento;
                // Colocar valor a los dropdown
                ddlCampus.SelectedValue = Convert.ToString(PrestadorActual.IdCampus);
                ddlDependencia.SelectedValue = Convert.ToString(PrestadorActual.IdDependencia);
                ddlDepartamento.SelectedValue = Convert.ToString(PrestadorActual.IdDepartamento);
                ddlModalidad.SelectedValue = Convert.ToString(PrestadorActual.IdModalidad);
                ddlCarrera.SelectedValue = Convert.ToString(PrestadorActual.IdCarrera);
                ddlSemestre.SelectedValue = Convert.ToString(PrestadorActual.IdSemestre);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["opcion"] != null)
                {
                    string CrudOpcion = Request.QueryString["opcion"];
                    switch (CrudOpcion)
                    {
                        case "C":
                            ddlLlenar();
                            HeaderAccion.Text = "Registrar prestador";
                            break;
                        case "U":
                            ddlLlenar();
                            llenarFormulario();
                            HeaderAccion.Text = "Editar prestador";
                            break;
                        case "D":
                            ddlLlenar();
                            llenarFormulario();
                            bloquearCampos();
                            HeaderAccion.Text = "Eliminar Prestador";
                            break;
                    }
                }
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            string EstatusRespuesta = "";
            string Mensaje;
            Validaciones objeto = new Validaciones();
            int idCampus = objeto.VerificarDropDown(Convert.ToInt32(ddlCampus.SelectedItem.Value), "Campus");
            int idDependencia = objeto.VerificarDropDown(Convert.ToInt32(ddlDependencia.SelectedItem.Value), "Dependencia");
            int idDepartamento = objeto.VerificarDropDown(Convert.ToInt32(ddlDepartamento.SelectedItem.Value), "Departamento");
            int idModalidad = objeto.VerificarDropDown(Convert.ToInt32(ddlModalidad.SelectedItem.Value), "Modalidad");
            int idCarrera = objeto.VerificarDropDown(Convert.ToInt32(ddlCarrera.SelectedItem.Value), "Carrera");
            int idSemestre = objeto.VerificarDropDown(Convert.ToInt32(ddlSemestre.SelectedItem.Value), "Semestre");
            string nombre = objeto.VerificarNombre(TxtNombre.Text, "Nombre");
            string matricula = objeto.VerificarCadenaNumerica(TxtMatricula.Text,7,"Matricula", true);
            string primerApellido = objeto.VerificarNombre(TxtApellido_paterno.Text, "Apellido Paterno");
            string segundoApellido = objeto.VerificarNombre(TxtApellido_materno.Text, "Apellido Materno");
            string correo = objeto.VerificarCorreo(TxtCorreo.Text, "Correo");
            string telefono = objeto.VerificarCadenaNumerica(TxtTelefono.Text, 10, "Telefono", true);
            string calle = objeto.VerificarDirecciones(TxtCalle.Text, "Calle");
            string numero = objeto.VerificarCadenaNumerica(TxtNumero.Text, 3, "Numero", true);
            string colonia = objeto.VerificarDirecciones(TxtColonia.Text, "Colonia");
            string codigoPostal = objeto.VerificarCadenaNumerica(TxtCodigo_postal.Text, 5, "Codigo Postal", true);
            string ruta = objeto.VerificarDirecciones(TxtRuta_documento.Text, "Ruta del Documento");
            if (objeto.GetExisteError() == true)
            {
                List<string> listaErrores = objeto.GetErrores();
                if (listaErrores.Count > 0)
                {
                    string alerta = "";
                    foreach (string n in listaErrores)
                    {
                        alerta += n + "</br>";
                    }
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "EjecutarAlerta('" + alerta + "'); ", true);
                }
                listaErrores.Clear();
            }
            else
            {
                bdPrestador parametros = new bdPrestador
                {
                    IdPrestador = 0,
                    IdEstatus = 0,
                    IdCampus = idCampus,
                    IdDependencia = idDependencia,
                    IdDepartamento = idDepartamento,
                    IdModalidad = idModalidad,
                    IdPeriodo = 0,
                    IdCarrera = idCarrera,
                    IdSemestre = idSemestre,
                    Matricula = matricula,
                    Nombre = nombre,
                    PrimerApellido = primerApellido,
                    SegundoApellido = segundoApellido,
                    FechaNacimiento = TxtFecha_nacimiento.Text,
                    CorreoUniversitario = correo,
                    Telefono = telefono,
                    Calle = calle,
                    Numero = numero,
                    Colonia = colonia,
                    CodigoPostal = codigoPostal,
                    FechaIngreso = TxtFecha_ingreso.Text,
                    HoraInicio = TxtHora_inicio.Text,
                    HoraFin = "",
                    RutaDocumento = ruta,
                    FechaRegistro = "",
                    FechaModificacion = "",
                    FechaBaja = ""
                };
                if (Request.QueryString["opcion"] != null)
                {
                    if (Request.QueryString["opcion"] == "C")
                    {
                        EstatusRespuesta = LogicaPrestador.Crear(parametros);
                        Mensaje = RespuestasBD.ExcepcionesAgregar(EstatusRespuesta);
                        ClientScript.RegisterStartupScript(GetType(), "Javascript", "EjecutarAlerta('" + Mensaje + "'); ", true);
                        //Response.Write("<script>alert(" + Mensaje + ")</script>");
                    }
                    if (Request.QueryString["Id"] != null)
                    {
                        parametros.IdPrestador = Convert.ToInt32(Request.QueryString["Id"]);
                        if (Request.QueryString["opcion"] == "U")
                        {
                            EstatusRespuesta = LogicaPrestador.Actualizar(parametros);
                            Mensaje = RespuestasBD.ExcepcionesActualizar(EstatusRespuesta);
                            ClientScript.RegisterStartupScript(GetType(), "Javascript", "EjecutarAlerta('" + Mensaje + "'); ", true);
                            //Response.Write("<script>alert(" + Mensaje + ")</script>");
                        }
                        if (Request.QueryString["opcion"] == "D")
                        {
                            EstatusRespuesta = LogicaPrestador.Eliminar(parametros);
                            Mensaje = RespuestasBD.ExcepcionesActualizar(EstatusRespuesta);
                            ClientScript.RegisterStartupScript(GetType(), "Javascript", "EjecutarAlerta('" + Mensaje + "'); ", true);
                            Response.Write("<script>alert(" + Mensaje + ")</script>");
                        }
                    }
                }
                if (EstatusRespuesta == "1")
                {
                    Response.Redirect("~/Index.aspx");
                }
            }
            objeto.CleanValues();
        }

        protected void ddlCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampus.SelectedItem.Value == "0")
            {
                ddlDependencia.DataSource = LogicaCatalogo.LeerCatalogo("DEPENDENCIA", 1, "IdDependencia", null, null);
                ddlDependencia.DataValueField = "Id";
                ddlDependencia.DataTextField = "Descripcion";
                ddlDependencia.DataBind();
                ddlDependencia.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
            else if (ddlCampus.SelectedItem.Value != "0")
            {
                ddlDependencia.DataSource = LogicaCatalogo.LeerCatalogo(null, null, null, 1, Convert.ToInt32(ddlCampus.SelectedItem.Value));
                ddlDependencia.DataValueField = "Id";
                ddlDependencia.DataTextField = "Descripcion";
                ddlDependencia.DataBind();
                ddlDependencia.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
        }
        protected void bloquearCampos()
        {
            ddlCampus.Enabled = false;
            ddlDependencia.Enabled = false;
            ddlDepartamento.Enabled = false;
            ddlModalidad.Enabled = false;
            ddlCarrera.Enabled = false;
            ddlSemestre.Enabled = false;
            TxtNombre.Enabled = false;
            TxtMatricula.Enabled = false;
            TxtApellido_paterno.Enabled = false;
            TxtApellido_materno.Enabled = false;
            TxtCorreo.Enabled = false;
            TxtTelefono.Enabled = false;
            TxtCalle.Enabled = false;
            TxtNumero.Enabled = false;
            TxtColonia.Enabled = false;
            TxtCodigo_postal.Enabled = false;
            TxtRuta_documento.Enabled = false;
        }

        protected void btnRegresarIndex(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
        }
    }
}