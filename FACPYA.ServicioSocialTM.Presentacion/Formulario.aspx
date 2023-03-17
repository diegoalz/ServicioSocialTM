<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="FACPYA.ServicioSocialTM.Presentacion.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://code.jquery.com/jquery-3.6.2.js" integrity="sha256-pkn2CUZmheSeyssYw3vMp1+xyub4m+e+QK4sQskvuo4=" crossorigin="anonymous"></script>
    <script src="https://cdn.tailwindcss.com"></script>
    <title>Formulario de registro</title>
    <!-- JavaScript -->
    <script src="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/alertify.min.js"></script>
    <!-- CSS -->
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/alertify.min.css"/>
    <!-- Default theme -->
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/default.min.css"/>
    <!-- Semantic UI theme -->
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/semantic.min.css"/>
</head>
<body>
          <script>

           function EjecutarAlerta(mensaje) {
               if (!alertify.myAlert) {
                   //define a new dialog
                   alertify.dialog('myAlert', function () {
                       return {
                           main: function (message) {
                               this.message = message;
                           },
                           setup: function () {
                               return {
                                   buttons: [{ text: "Entendido", key: 27/*Esc*/ }],
                                   focus: { element: 0 }
                               };
                           },
                           prepare: function () {
                               this.setContent(this.message);
                           }
                       }
                   });
               }
               alertify.myAlert(mensaje);
           }
        //launch it.
        //alertify.myAlert("Browser dialogs made easy!");
          </script>
    <div>
        <form id="form1" runat="server">
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800" OnClick="btnRegresarIndex" />
            <div class="grid justify-items-stretch">
                <h1 class="justify-self-center"><asp:Label ID="HeaderAccion" runat="server" Text="" CssClass="text-2xl"></asp:Label></h1>
            </div>
            <div class="max-w-6xl mx-auto bg-white p-16">
                <div>
                    <div class="grid gap-6 mb-6 lg:grid-cols-6">
                        <div class="col-span-2">
                            <label for="TxtNombre" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Nombre</label>
                            <!--<input type="text" id="Nombre" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="John" required>-->
                            <asp:TextBox ID="TxtNombre" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" PLACEHOLDER="primer y segundo" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-span-2">
                            <label for="TxtApellido_paterno" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Apellido Paterno</label>
                            <asp:TextBox ID="TxtApellido_paterno" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" PLACEHOLDER="Apellido paterno" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-span-2">
                            <label for="TxtApellido_materno" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Apellido Materno</label>
                            <asp:TextBox ID="TxtApellido_materno" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" PLACEHOLDER="Apellido materno" required runat="server"></asp:TextBox>
                        </div>  
                        <div class="col-span-1">
                            <label for="TxtFecha_nacimiento" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Fecha Nacimiento</label>
                            <!--<input type="date" id="fecha_nacimiento" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="123-45-678" pattern="[0-9]{3}-[0-9]{2}-[0-9]{3}" required>-->
                            <asp:TextBox ID="TxtFecha_nacimiento" Type="date" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-span-1">
                            <label for="TxtMatricula" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Matricula</label>
                            <asp:TextBox ID="TxtMatricula" MinLength="7" MaxLength="7" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" PLACEHOLDER="7 dígitos" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-span-3">
                            <label for="TxtCorreo" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Dirección de correo</label>
                            <asp:TextBox ID="TxtCorreo" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" PLACEHOLDER="correo@ejemplo.com" required runat="server"></asp:TextBox>
                        </div> 
                        <div class="col-span-1">
                            <label for="TxtTelefono" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Telefono</label>
                            <asp:TextBox ID="TxtTelefono" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" PLACEHOLDER="123-45-678" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-span-4">
                            <label for="TxtCalle" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Calle</label>
                            <asp:TextBox ID="TxtCalle" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" PLACEHOLDER="calle" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-span-2">
                            <label for="TxtNumero" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Numero</label>
                            <asp:TextBox ID="TxtNumero" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" PLACEHOLDER="numero" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-span-4">
                            <label for="TxtColonia" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Colonia</label>
                            <asp:TextBox ID="TxtColonia" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" PLACEHOLDER="colonia" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-span-2">
                            <label for="TxtCodigo_postal" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Codigo postal</label>
                            <asp:TextBox ID="TxtCodigo_postal" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" PLACEHOLDER="codigo postal" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-span-1">
                            <label for="TxtFecha_ingreso" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Fecha ingreso</label>
                            <asp:TextBox ID="TxtFecha_ingreso" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" Type="date" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-span-1">
                            <label for="TxtHora_inicio" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Hora de inicio</label>
                            <!--<input type="time" step="2" id="hora_inicio" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="123-45-678" pattern="[0-9]{3}-[0-9]{2}-[0-9]{3}" required>-->
                            <asp:TextBox ID="TxtHora_inicio" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" Type="time" step="2" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-span-4">
                            <label for="TxtRuta_documento" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Ruta de fotogragia</label>
                            <!--<input type="url" id="ruta_documento" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="flowbite.com" required>-->
                            <asp:TextBox ID="TxtRuta_documento" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" Type="url" PLACEHOLDER="ruta de la fotografia" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-span-2 relative">
                            <asp:Label ID="lblCampus" runat="server" Text="Campus"></asp:Label>
                            <asp:DropDownList ID="ddlCampus" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline" runat="server" OnSelectedIndexChanged="ddlCampus_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </div>
                        <div class="col-span-2 relative">
                            <asp:Label ID="lblDependencia" runat="server" Text="Dependencia"></asp:Label>
                            <asp:DropDownList ID="ddlDependencia" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-span-2 relative">
                            <asp:Label ID="lblDepartamento" runat="server" Text="Departamento"></asp:Label>
                            <asp:DropDownList ID="ddlDepartamento" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-span-2 relative">
                            <asp:Label ID="lblModalidad" runat="server" Text="Modalidad"></asp:Label>
                            <asp:DropDownList ID="ddlModalidad" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-span-2 relative">
                            <asp:Label ID="lblCarrera" runat="server" Text="Carrera"></asp:Label>
                            <asp:DropDownList ID="ddlCarrera" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-span-2 relative">
                            <asp:Label ID="lblSemestre" runat="server" Text="Semestre"></asp:Label>
                            <asp:DropDownList ID="ddlSemestre" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <asp:Button ID="btnCrear" runat="server" Text="Guardar" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800" OnClick="btnCrear_Click"  OnClientClick = "return confirm('Seguro que quiere borrar?')"/>
        </form>
    </div>
    </div>
</body>
</html>
