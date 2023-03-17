<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FACPYA.ServicioSocialTM.Presentacion.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Servicio de Prestadores</title>
    <script src="https://code.jquery.com/jquery-3.6.2.js" integrity="sha256-pkn2CUZmheSeyssYw3vMp1+xyub4m+e+QK4sQskvuo4=" crossorigin="anonymous"></script>
    <script src="https://cdn.tailwindcss.com"></script>
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
            <br />
            <div class="flex flex-row-reverse">
                <asp:LinkButton ID="IndexLimpiar" runat="server" class="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded" OnClick="IndexLimpiarFiltros">Limpiar</asp:LinkButton>
                <asp:Button ID="buscar" runat="server" Text="Buscar" class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" OnClick="buscar_Click"/>
                <div class="inline-block relative w-30">
                    <div class="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
                        <svg class="w-5 h-5 text-gray-500 dark:text-gray-400" fill="currentColor" viewBox="0 0 20 20"
                            xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd"
                                d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z"
                                clip-rule="evenodd"></path>
                        </svg>
                    </div>
                    <asp:TextBox ID="BuscarNombre" runat="server" PlaceHolder="Nombre o Apellidos" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full pl-10 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"></asp:TextBox>
                </div>
                <div class="inline-block relative w-30">
                    <div class="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
                        <svg class="w-5 h-5 text-gray-500 dark:text-gray-400" fill="currentColor" viewBox="0 0 20 20"
                            xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd"
                                d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z"
                                clip-rule="evenodd"></path>
                        </svg>
                    </div>
                    <asp:TextBox ID="BuscarMatricula" runat="server" PlaceHolder="Matricula" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full pl-10 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"></asp:TextBox>
                </div>
                <div class="flex justify-start"><asp:LinkButton ID="IndexCrear" runat="server" class="bg-orange-500 hover:bg-orange-700 text-white font-bold py-2 px-4 rounded" OnClick="IndexCrear_Click">Crear</asp:LinkButton></div>                
            </div>
            <details open class="p-3">
                <summary>Filtros</summary>
                <div>
                    <div class="inline-block relative w-30">
                        <asp:Label ID="lblDependencia" runat="server" Text="Dependencia"></asp:Label>
                        <asp:DropDownList ID="ddlDependencia" runat="server" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="inline-block relative w-30">
                        <asp:Label ID="lblCampus" runat="server" Text="Campus"></asp:Label>
                        <asp:DropDownList ID="ddlCampus" runat="server" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline" AutoPostBack="True" OnSelectedIndexChanged="ddlCampus_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="inline-block relative w-30">
                        <asp:Label ID="lblCarrera" runat="server" Text="Carrera"></asp:Label>
                        <asp:DropDownList ID="ddlCarrera" runat="server" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline" OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <br />
                    <div class="inline-block relative w-30">
                        <asp:Label ID="lblPeriodo" runat="server" Text="Periodo"></asp:Label>
                        <asp:DropDownList ID="ddlPeriodo" runat="server" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="inline-block relative w-30">
                        <asp:Label ID="lblModalidad" runat="server" Text="Modalidad"></asp:Label>
                        <asp:DropDownList ID="ddlModalidad" runat="server" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline" OnSelectedIndexChanged="ddlModalidad_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </details>
        </div>
    <br />
        <asp:GridView ID="dgPrestadorTabla" runat="server" DataKeyNames="IdPrestador" AutoGenerateColumns="false" 
            class="min-w-full border-collapse block md:table block" OnSelectedIndexChanged="dgPrestadorTabla_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                <asp:BoundField DataField="PrestadorServicioSocial" HeaderText="Prestador del servicio social" />
                <asp:BoundField DataField="Edad" HeaderText="Edad" />
                <asp:BoundField DataField="Contacto" HeaderText="Contacto" />
                <asp:BoundField DataField="AreaLaboral" HeaderText="Area laboral" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" OnClick="Editar_Click" Value="IdPrestador" Text="Editar" class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-2 border border-blue-500 rounded" />
                        <asp:Button ID="btnBorrar" runat="server" OnClick="Borrar_Click" Value="IdPrestador" Text="Eliminar" class="bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-2 border border-red-500 rounded" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </form>
        <!-- Barra de busqueda
                <div class="inline-block relative w-30 py-4 px-1">
                <div class="relative mt-1">
                    <div class="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
                        <svg class="w-5 h-5 text-gray-500 dark:text-gray-400" fill="currentColor" viewBox="0 0 20 20"
                            xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd"
                                d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z"
                                clip-rule="evenodd"></path>
                        </svg>
                    </div>
                    <input type="text" id="table-search" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full pl-10 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Nombre, Apellidos, Correo">
                </div>
                </div> -->
            <!-- <div class="grid grid-flow-row-dense grid-cols-6 grid-rows-1">

                <div class="inline-block relative w-30">
                    <label for="dependencia">Dependencia</label>
                    <select id="dependencia" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline">
                        <option>Opcion 1</option>
                        <option>Option 2</option>
                        <option>Option 3</option>
                    </select>
                    <div class="pointer-events-none absolute inset-y-0 right-0 flex items-center px-2 text-gray-700">
                        <svg class="fill-current h-4 w-4" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20"><path d="M9.293 12.95l.707.707L15.657 8l-1.414-1.414L10 10.828 5.757 6.586 4.343 8z"/></svg>
                    </div>
                </div>
                <div class="inline-block relative w-30">
                    <label for="campus">Campus</label>
                    <select id="campus" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline">
                        <option>Opcion 1</option>
                        <option>Option 2</option>
                        <option>Option 3</option>
                    </select>
                    <div class="pointer-events-none absolute inset-y-0 right-0 flex items-center px-2 text-gray-700">
                        <svg class="fill-current h-4 w-4" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20"><path d="M9.293 12.95l.707.707L15.657 8l-1.414-1.414L10 10.828 5.757 6.586 4.343 8z"/></svg>
                    </div>
                </div>            
                <div class="inline-block relative w-30">
                    <label for="carrera">Carrera</label>
                    <select id="carrera" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline">
                        <option>Opcion 1</option>
                        <option>Option 2</option>
                        <option>Option 3</option>
                    </select>
                    <div class="pointer-events-none absolute inset-y-0 right-0 flex items-center px-2 text-gray-700">
                        <svg class="fill-current h-4 w-4" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20"><path d="M9.293 12.95l.707.707L15.657 8l-1.414-1.414L10 10.828 5.757 6.586 4.343 8z"/></svg>
                    </div>
                </div>
                <div class="inline-block relative w-30">
                    <label for="periodo">Periodo</label>
                    <select id="periodo" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline">
                        <option>Opcion 1</option>
                        <option>Option 2</option>
                        <option>Option 3</option>
                    </select>
                    <div class="pointer-events-none absolute inset-y-0 right-0 flex items-center px-2 text-gray-700">
                        <svg class="fill-current h-4 w-4" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20"><path d="M9.293 12.95l.707.707L15.657 8l-1.414-1.414L10 10.828 5.757 6.586 4.343 8z"/></svg>
                    </div>
                </div>
                <div class="inline-block relative w-30">
                    <label for="modalidad">Modalidad</label>
                    <select id="modalidad" class="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline">
                        <option>Opcion 1</option>
                        <option>Option 2</option>
                        <option>Option 3</option>
                    </select>
                    <div class="pointer-events-none absolute inset-y-0 right-0 flex items-center px-2 text-gray-700">
                        <svg class="fill-current h-4 w-4" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20"><path d="M9.293 12.95l.707.707L15.657 8l-1.414-1.414L10 10.828 5.757 6.586 4.343 8z"/></svg>
                    </div>
                </div> -->
            <!-- Area de la tabla -->
            <!-- <table class="min-w-full border-collapse block md:table">
                    <thead class="block md:table-header-group">
                        <tr class="border border-grey-500 md:border-none block md:table-row absolute -top-full md:top-auto -left-full md:left-auto  md:relative ">
                            <th class="bg-gray-600 p-2 text-white font-bold md:border md:border-grey-500 text-left block md:table-cell">Matricula</th>
                            <th class="bg-gray-600 p-2 text-white font-bold md:border md:border-grey-500 text-left block md:table-cell">Prestador Servicio Social</th>
                            <th class="bg-gray-600 p-2 text-white font-bold md:border md:border-grey-500 text-left block md:table-cell">Edad</th>
                            <th class="bg-gray-600 p-2 text-white font-bold md:border md:border-grey-500 text-left block md:table-cell">Programa Educativo</th>
                            <th class="bg-gray-600 p-2 text-white font-bold md:border md:border-grey-500 text-left block md:table-cell">Area Laboral</th>
                            <th class="bg-gray-600 p-2 text-white font-bold md:border md:border-grey-500 text-left block md:table-cell">Contacto</th>
                            <th class="bg-gray-600 p-2 text-white font-bold md:border md:border-grey-500 text-left block md:table-cell">Actions</th>
                        </tr>
                    </thead>
                    <tbody class="block md:table-row-group">
                        <tr class="bg-gray-300 border border-grey-500 md:border-none block md:table-row">
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell"><span class="inline-block w-1/3 md:hidden font-bold">Matricula</span>1846641</td>
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell"><span class="inline-block w-1/3 md:hidden font-bold">Prestador Servicio Social</span>Diego Armando Luna Zavalija</td>
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell"><span class="inline-block w-1/3 md:hidden font-bold">Edad</span>22</td>
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell"><span class="inline-block w-1/3 md:hidden font-bold">Programa Educativo</span>CPA 9 Semestre</td>
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell"><span class="inline-block w-1/3 md:hidden font-bold">Area Laboral</span>RECURSOS HUMANOS-PRESENCIAL(12:00:00 A 16:00:00)</td>
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell"><span class="inline-block w-1/3 md:hidden font-bold">Contacto</span>diego.lunaza@uanl.edu.mx 8116223840</td>
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell">
                                <span class="inline-block w-1/3 md:hidden font-bold">Acciones</span>
                                <a href="./Formulario.aspx"><button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-2 border border-blue-500 rounded">Editar</button></a>
                                <button class="bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-2 border border-red-500 rounded">Borrar</button>
                            </td>
                        </tr>
                        <tr class="bg-white-300 border border-grey-500 md:border-none block md:table-row">
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell"><span class="inline-block w-1/3 md:hidden font-bold">Matricula</span>1846641</td>
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell"><span class="inline-block w-1/3 md:hidden font-bold">Prestador Servicio Social</span>Diego Armando Luna Zavalija</td>
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell"><span class="inline-block w-1/3 md:hidden font-bold">Edad</span>22</td>
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell"><span class="inline-block w-1/3 md:hidden font-bold">Programa Educativo</span>CPA 9 Semestre</td>
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell"><span class="inline-block w-1/3 md:hidden font-bold">Area Laboral</span>RECURSOS HUMANOS-PRESENCIAL(12:00:00 A 16:00:00)</td>
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell"><span class="inline-block w-1/3 md:hidden font-bold">Contacto</span>diego.lunaza@uanl.edu.mx 8116223840</td>
                            <td class="p-2 md:border md:border-grey-500 text-left block md:table-cell">
                                <span class="inline-block w-1/3 md:hidden font-bold">Acciones</span>
                                <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-2 border border-blue-500 rounded">Editar</button>
                                <button class="bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-2 border border-red-500 rounded">Borrar</button>
                            </td>
                        </tr>
                    </tbody>
                </table> -->
    </div>
</body>
</html>
