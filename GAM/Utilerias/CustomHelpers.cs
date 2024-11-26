using GAM.Models;
using GAM.Models.Repository;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GAM.Utilerias
{
    public static class CustomHelpers
    {        
        public static MvcHtmlString EstadosdeProceso(string estado, string idoportunidad)
        {                        
            if (estado == "EnProceso1") //Mas de 60 días
            {
                return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id="+ idoportunidad +"'><i class='fas fa-cogs' style='color: lightblue' data-toggle='tooltip' data-placement='left' title='En Proceso'></i></a></td>");
            }
            else if (estado == "EnProceso2") //Sin terminar a 15 días
            {
                return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id=" + idoportunidad + "'><i class='fas fa-flag' style='color: yellow' data-toggle='tooltip' data-placement='left' title='Alerta'></i></a></td>");
            }
            else if (estado == "EnProceso3") //Sin terminar a 7 días
            {
                return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id=" + idoportunidad + "'><i class='fas fa-flag' style='color: orange' data-toggle='tooltip' data-placement='left' title='Por Vencer'></i></a></td>");
            }
            else if (estado == "EnProceso4")
            {
                return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id=" + idoportunidad + "'><i class='fas fa-flag' style='color: red' data-toggle='tooltip' data-placement='left' title='Vencido'></i></a></td>");
            }
            else if (estado == "Cerrado") //Cerrado por el propietario por negociación
            {
                return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id=" + idoportunidad + "'><i class='fas fa-hands-helping' style='color: coral' data-toggle='tooltip' data-placement='left' title='Cerrado'></i></a></td>");
            }
            else if (estado == "CerradoPerdido") //Cerrado Perdido
            {
                return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id=" + idoportunidad + "'><i class='fas fa-sad-tear' style='color: red' data-toggle='tooltip' data-placement='left' title='Cerrado Perdido'></i></a></td>");
            }
            else if (estado == "CerradoGanado") //Cerrado Ganado
            {
                return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id=" + idoportunidad + "'><i class='far fa-handshake' style='color: green' data-toggle='tooltip' data-placement='left' title='Cerrado Ganado'></i></a></td>");
            }
            //else if (estado == "Terminado") //Terminado
            //{
            //    return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id=" + idoportunidad + "'><i class='fas fa-check-circle' style='color: greenyellow' data-toggle='tooltip' data-placement='left' title='Terminado'></i></a></td>");
            //}
            else if (estado == "Cancelado") //Cancelado por el propietario
            {
                return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id=" + idoportunidad + "'><i class='fas fa-times-circle' style='color: darkkhaki' data-toggle='tooltip' data-placement='left' title='Cancelado'></i></a></td>");
            }
            else if (estado == "Suspendido") //Suspendido por el propietario
            {
                return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id=" + idoportunidad + "'><i class='fas fa-times-circle' style='color: deeppink' data-toggle='tooltip' data-placement='left' title='Suspendido'></i></a></td>");
            }
            else if (estado == "Reasignar") //Reasignar
            {
                return MvcHtmlString.Create("<td style='background-color: gray'>Reasignar</td>");
            }
            else
            {
                return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id=" + idoportunidad + "'><i class='fas fa-exclamation-circle' data-toggle='tooltip' data-placement='left' title='No Definido (requiere atención)'></i></a></td>");
            }
        }

        public static MvcHtmlString EstadosdeProcesoSABE(string estado, string idoportunidad)
        {
            if (estado == "EnProceso1") //Mas de 60 días
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida(" + idoportunidad + ")><i class='fas fa-cogs' style='color: lightblue' data-toggle='tooltip' data-placement='left' title='En Proceso'></i></a></td>");
            }
            else if (estado == "EnProceso2") //Sin terminar a 15 días
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida(" + idoportunidad + ")><i class='fas fa-flag' style='color: yellow' data-toggle='tooltip' data-placement='left' title='Alerta'></i></a></td>");
            }
            else if (estado == "EnProceso3") //Sin terminar a 7 días
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida(" + idoportunidad + ")><i class='fas fa-flag' style='color: orange' data-toggle='tooltip' data-placement='left' title='Por Vencer'></i></a></td>");
            }
            else if (estado == "EnProceso4")
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida(" + idoportunidad + ")><i class='fas fa-flag' style='color: red' data-toggle='tooltip' data-placement='left' title='Vencido'></i></a></td>");
            }
            else if (estado == "Cerrado") //Cerrado por el propietario por negociación
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida(" + idoportunidad + ")><i class='fas fa-hands-helping' style='color: coral' data-toggle='tooltip' data-placement='left' title='Cerrado'></i></a></td>");
            }
            else if (estado == "CerradoPerdido") //Cerrado Perdido
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida(" + idoportunidad + ")><i class='fas fa-sad-tear' style='color: red' data-toggle='tooltip' data-placement='left' title='Cerrado Perdido'></i></a></td>");
            }
            else if (estado == "CerradoGanado") //Cerrado Ganado
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida(" + idoportunidad + ")><i class='far fa-handshake' style='color: green' data-toggle='tooltip' data-placement='left' title='Cerrado Ganado'></i></a></td>");
            }
            //else if (estado == "Terminado") //Terminado
            //{
            //    return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id=" + idoportunidad + "'><i class='fas fa-check-circle' style='color: greenyellow' data-toggle='tooltip' data-placement='left' title='Terminado'></i></a></td>");
            //}
            else if (estado == "Cancelado") //Cancelado por el propietario
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida(" + idoportunidad + ")><i class='fas fa-times-circle' style='color: darkkhaki' data-toggle='tooltip' data-placement='left' title='Cancelado'></i></a></td>");
            }
            else if (estado == "Suspendido") //Suspendido por el propietario
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida(" + idoportunidad + ")><i class='fas fa-times-circle' style='color: deeppink' data-toggle='tooltip' data-placement='left' title='Suspendido'></i></a></td>");
            }
            else if (estado == "Reasignar") //Reasignar
            {
                return MvcHtmlString.Create("<td style='background-color: gray'>Reasignar</td>");
            }
            else
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida(" + idoportunidad + ")><i class='fas fa-exclamation-circle' data-toggle='tooltip' data-placement='left' title='No Definido (requiere atención)'></i></a></td>");
            }
        }

        public static MvcHtmlString EstadosdeProcesoSABE2(string estado, string idoportunidad)
        {
            if (estado == "EnProceso1") //Mas de 60 días
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida2(" + idoportunidad + ")><i class='fas fa-cogs' style='color: lightblue' data-toggle='tooltip' data-placement='left' title='En Proceso'></i></a></td>");
            }
            else if (estado == "EnProceso2") //Sin terminar a 15 días
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida2(" + idoportunidad + ")><i class='fas fa-flag' style='color: yellow' data-toggle='tooltip' data-placement='left' title='Alerta'></i></a></td>");
            }
            else if (estado == "EnProceso3") //Sin terminar a 7 días
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida2(" + idoportunidad + ")><i class='fas fa-flag' style='color: orange' data-toggle='tooltip' data-placement='left' title='Por Vencer'></i></a></td>");
            }
            else if (estado == "EnProceso4")
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida2(" + idoportunidad + ")><i class='fas fa-flag' style='color: red' data-toggle='tooltip' data-placement='left' title='Vencido'></i></a></td>");
            }
            else if (estado == "Cerrado") //Cerrado por el propietario por negociación
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida2(" + idoportunidad + ")><i class='fas fa-hands-helping' style='color: coral' data-toggle='tooltip' data-placement='left' title='Cerrado'></i></a></td>");
            }
            else if (estado == "CerradoPerdido") //Cerrado Perdido
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida2(" + idoportunidad + ")><i class='fas fa-sad-tear' style='color: red' data-toggle='tooltip' data-placement='left' title='Cerrado Perdido'></i></a></td>");
            }
            else if (estado == "CerradoGanado") //Cerrado Ganado
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida2(" + idoportunidad + ")><i class='far fa-handshake' style='color: green' data-toggle='tooltip' data-placement='left' title='Cerrado Ganado'></i></a></td>");
            }
            //else if (estado == "Terminado") //Terminado
            //{
            //    return MvcHtmlString.Create("<td align='center'><a href='/Oportunidades/Editar?Id=" + idoportunidad + "'><i class='fas fa-check-circle' style='color: greenyellow' data-toggle='tooltip' data-placement='left' title='Terminado'></i></a></td>");
            //}
            else if (estado == "Cancelado") //Cancelado por el propietario
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida2(" + idoportunidad + ")><i class='fas fa-times-circle' style='color: darkkhaki' data-toggle='tooltip' data-placement='left' title='Cancelado'></i></a></td>");
            }
            else if (estado == "Suspendido") //Suspendido por el propietario
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida2(" + idoportunidad + ")><i class='fas fa-times-circle' style='color: deeppink' data-toggle='tooltip' data-placement='left' title='Suspendido'></i></a></td>");
            }
            else if (estado == "Reasignar") //Reasignar
            {
                return MvcHtmlString.Create("<td style='background-color: gray'>Reasignar</td>");
            }
            else
            {
                return MvcHtmlString.Create("<td align='center'><a href='#' onclick=ObtenerDetalleVistaRapida2(" + idoportunidad + ")><i class='fas fa-exclamation-circle' data-toggle='tooltip' data-placement='left' title='No Definido (requiere atención)'></i></a></td>");
            }
        }

        public static MvcHtmlString ResponsablesSiNo(string idoportunidad)
        {            
            Comun comun = new Comun();
                        
            OportunidadesResponsablesRepositorio orr = new OportunidadesResponsablesRepositorio();
            BitacoraUsuariosDetalleRepositorio budr = new BitacoraUsuariosDetalleRepositorio();
            BitacoraUsuariosRepositorio bur = new BitacoraUsuariosRepositorio();


            string cadena = string.Empty;
            if (comun.n.bitacorausuarios.Seleccionar_SiOportunidadTieneResponsablesAsignados(idoportunidad) == 1)
            {
                cadena = "<td align='center'><i class='fas fa-users' style='color: green' data-toggle='tooltip' data-placement='left' title='Con Proveedores/Responsables Asignados (Dé click para mostrar la bitácora)' onclick='UsuariosBitacoraOportunidad(" + idoportunidad + ")'></i></td>";
            }
            else if (comun.n.bitacorausuarios.Seleccionar_SiOportunidadTieneResponsablesAsignados(idoportunidad) == 0)
            {
                cadena = "<td align='center'><i class='fas fa-user-slash' style='color: orange' data-toggle='tooltip' data-placement='left' title='Sin Proveedores/Responsables Asignados'></i></td>";
            }
            return MvcHtmlString.Create(cadena);

        }

        public static MvcHtmlString ResponsablesSiNoASAE(string idoportunidad)
        {
            /*
            Comun comun = new Comun();
            comun.oporrespr.SeleccionarSiOportunidadTieneResponsablesAsignados(idoportunidad);
            comun.budr.SeleccionarSiOportunidadTieneUsuariosResponsablesAsignados(idoportunidad);
            */
            OportunidadesResponsablesRepositorio orr = new OportunidadesResponsablesRepositorio();
            BitacoraUsuariosDetalleRepositorio budr = new BitacoraUsuariosDetalleRepositorio();
            BitacoraUsuariosRepositorio bur = new BitacoraUsuariosRepositorio();

            string cadena = string.Empty;
            //if (bur.SeleccionarSiOportunidadTieneResponsablesAsignados(idoportunidad) == 1)
            //{
            cadena = "<td align='center'><i class='fas fa-users' style='color: green' data-toggle='tooltip' data-placement='left' title='Con Responsables Asignados (Dé click para mostrar la bitácora)' onclick='UsuariosBitacoraOportunidad(" + idoportunidad + ")'></i></td>";
            //}
            //else if (bur.SeleccionarSiOportunidadTieneResponsablesAsignados(idoportunidad) == 0)
            //{
            //    cadena = "<td align='center'><i class='fas fa-user-slash' style='color: orange' data-toggle='tooltip' data-placement='top' title='Sin Responsables Asignados'></i></td>";
            //}
            return MvcHtmlString.Create(cadena);

        }

        public static MvcHtmlString EtiquetaNombre(string idconfiguracion)
        {
            string nombre = string.Empty;
            if (idconfiguracion == "3")
            {
                nombre = "Asunto";
            }
            else if (idconfiguracion == "2")
            {
                nombre = "Descripción";
            }

            return MvcHtmlString.Create("<label for='Asunto' class='col-md-4 labe1'>" + nombre + "</label>");
        }

        public static MvcHtmlString ActividadesDeOportunidad(string idoportunidad)
        {
            Comun comun = new Comun();

            string cadena = string.Empty;
            if (comun.n.oportunidadesactividades.Seleccionar_CuantasActividadesTieneOportunidad(idoportunidad) > 0)
            {
                cadena = "<td align='center'><i class='fas fa-layer-group' style='color: green' data-toggle='tooltip' data-placement='left' title='Mostrar Actividades (Dé click para mostrar)' onclick='UsuariosActividadesOportunidad(" + idoportunidad + ")'></i></td>";
            }
            else
            {
                cadena = "<td align='center'><i class='fas fa-layer-group' style='color: orange' data-toggle='tooltip' data-placement='left' title='No se han agregado actividades'></i></td>";
            }
            return MvcHtmlString.Create(cadena);

        }

        public static MvcHtmlString ArchivosDeOportunidad(string idoportunidad)
        {
            OportunidadesActividadesRepositorio oar = new OportunidadesActividadesRepositorio();
            ArchivosRepositorio ar = new ArchivosRepositorio();
            Comun comun = new Comun();

            string cadena = string.Empty;
            if (comun.n.archivos.Cuantos_ArchivosTieneOportunidad(idoportunidad) > 0)
            {
                cadena = "<td align='center'><i class='fas fa-file' style='color: green' data-toggle='tooltip' data-placement='left' title='Mostrar Archivos (Dé click para mostrar)' onclick='ArchivosOportunidad(" + idoportunidad + ")'></i></td>";
            }
            else
            {
                cadena = "<td align='center'><i class='fas fa-file' style='color: orange' data-toggle='tooltip' data-placement='left' title='No se han agregado archivos'></i></td>";
            }
            return MvcHtmlString.Create(cadena);

        }

        public static MvcHtmlString NombreUsuario(string idusuario)
        {
            Comun comun = new Comun();
            string cadena = string.Empty;
            if (string.IsNullOrEmpty(idusuario) || idusuario == "0")
            {
                cadena = "<span>No Aplica</span>";
            }
            else
            {
                cadena = comun.n.usuarios.Seleccionar_Nombre(idusuario);
            }
            return MvcHtmlString.Create(cadena);
        }

        public static MvcHtmlString NombreCreadorOportunidad(string idoportunidad)
        {
            Comun comun = new Comun();
            var nombre = comun.n.usuarios.Seleccionar_Nombre(comun.n.usuarios.Seleccionar_CreadorOportunidad(idoportunidad));
            return MvcHtmlString.Create(nombre);
        }

        public static MvcHtmlString SemaforoCompletadoEmpresa(string idempresa)
        {
            //Revisa si los datos de la empresa está o no completados
            Comun comun = new Comun();
            string cadena = string.Empty;
            if (comun.n.empresas.Seleccionar_SiCamposIncompletos(idempresa) == "Completo")
            {
                cadena = "<td align='center'><i class='fas fa-check' style='color: green' data-toggle='tooltip' data-placement='bottom' title='Datos Completos'></i></td>";
            }
            else
            {
                cadena = "<td align='center'><i class='fas fa-times' style='color: orange' data-toggle='tooltip' data-placement='top' title='Datos Incompletos'></i></td>";
            }
            return MvcHtmlString.Create(cadena);
        }

        public static MvcHtmlString TipoDireccion(string idtipodireccion)
        {            
            string cadena = string.Empty;
            if (idtipodireccion == "1")
            {
                cadena = "Dirección";
            }
            else
            {
                cadena = "Fiscal";
            }
            return MvcHtmlString.Create(cadena);
        }

        public static string Menu(string idrol, string idconfiguracion)
        {
            Models.Business.Menu m = new Models.Business.Menu();
            string cadena = string.Empty;
            foreach (var item in m.Seleccionar_Registros(idrol, idconfiguracion))
            {
                cadena += "<li class='nav-item' id='" + item.Menu.IdJquery + "'>";
                cadena += "<a href=" + item.Menu.Ruta + ">";
                cadena += "<i class='" + item.Menu.Icono + "'></i>";
                cadena += "<p>" + item.Menu.Nombre + "</p>";
                cadena += "</a>";
                cadena += "</li>";
            }
            return cadena;
        }

        public static bool ValidarSiUsuarioPuedeVerOportunidadesNoSuyas(string idoportunidad, string idusuario)
        {
            //Comun comun = new Comun();
            //if (comun.n.usuarios.Seleccionar_CreadorOportunidad(idoportunidad) == idusuario
            //    || comun.n.compartiroportunidades.Validar_SiUsuarioPuedeModificar(idoportunidad, idusuario)
            //    || idusuario == "2")
            if (new ValidacionPropietarioPermiso().OportunidadValidarPropietarioPermiso(idoportunidad, idusuario))
                return true;
            else
                return false;
        }


        //******************************** Selects *******************************

        public static MvcHtmlString SelectResponsables(string idconfiguracion, string idempresa, string idusuario, string idrol)
        {
            Comun comun = new Comun();

            string cadena = string.Empty;

            foreach (var item in comun.n.usuarios.Seleccionar_UsuariosResponsables("3", idempresa, idusuario, idrol))
            {
                cadena += "<option value=" + item.Id + ">" + item.Nombre + " [" + item.ApellidoPaterno.Trim() +  "]</option>";
            }
                        
            return MvcHtmlString.Create(cadena);
        }

        public static MvcHtmlString SelectResponsablesOptionsSABE(string idusuario)
        {
            Comun comun = new Comun();

            string cadena = string.Empty;
            cadena += "<option value=''>&nbsp;</option>";
            foreach (var item in comun.n.usuarios.Seleccionar_UsuariosResponsables("3"))
            {
                cadena += "<option value=" + item.Id + ">" + item.ApellidoPaterno.Trim() + " " + item.ApellidoMaterno.Trim() + " " + item.Nombre + "</option>";
            }
                       
            return MvcHtmlString.Create(cadena);
        }

        public static MvcHtmlString SelectResponsablesOptionsASAE(string idconfiguracion, string idusuario)
        {
            UsuariosRepositorio ur = new UsuariosRepositorio();
            Comun comun = new Comun();

            string cadena = string.Empty;
            cadena += "<option value=''>&nbsp;</option>";
            foreach (var item in comun.n.usuarios.Seleccionar_UsuariosResponsablesASAE(idconfiguracion, idusuario))
            {
                cadena += "<option value=" + item.Id + ">" + item.ApellidoPaterno.Trim() + " " + item.ApellidoMaterno.Trim() + " " + item.Nombre + "</option>";
            }            
            return MvcHtmlString.Create(cadena);
        }

        public static MvcHtmlString SelectEmpresas(string idconfiguracion, string IdRol, string IdUsuario)
        {
            Comun comun = new Comun();

            string cadena = string.Empty;
            cadena = "<select class='form-control form-control-sm input-solid' id='Empresa' name='Empresa' required style='width: 180px' onchange='DireccionEmpresa()'>";

            cadena += "<option value=''>&nbsp;</option>";
            foreach (var item in comun.n.empresas.Seleccionar_Registros(idconfiguracion, IdRol, IdUsuario))
            {
                cadena += "<option value=" + item.Id + ">" + item.Nombre + "</option>";
            }
            cadena += "</select>";

            return MvcHtmlString.Create(cadena);
        }

        public static MvcHtmlString SelectEmpresaSABEEdicion(string idconfiguracion, string IdRol, string IdUsuario)
        {
            Comun comun = new Comun();

            string cadena = string.Empty;
            cadena = "<select class='form-control form-control-sm input-solid' id='Empresa' name='Empresa' required style='width: 350px' onchange='DireccionEmpresa()'>";

            cadena += "<option value=''>&nbsp;</option>";
            foreach (var item in comun.n.empresas.Seleccionar_Registros(idconfiguracion, IdRol, IdUsuario))
            {
                cadena += "<option value=" + item.Id + ">" + item.Nombre + "</option>";
            }
            cadena += "</select>";

            return MvcHtmlString.Create(cadena);
        }

        public static MvcHtmlString SelectEmpresasProveedor()
        {
            Comun comun = new Comun();

            string cadena = string.Empty;
            cadena = "<select class='form-control form-control-sm input-solid' id='Empresa' name='Empresa' required style='width: 180px'>";

            cadena += "<option value=''>&nbsp;</option>";
            foreach (var item in comun.n.empresasproveedores.Seleccionar_Registros())
            {
                cadena += "<option value=" + item.Id + ">" + item.Nombre + "</option>";
            }
            cadena += "</select>";

            return MvcHtmlString.Create(cadena);
        }

        public static MvcHtmlString SelectUnidadDeNegocio()
        {
            UDNRepositorio udnr = new UDNRepositorio();
            Comun comun = new Comun();

            string cadena = string.Empty;
            cadena = "<select class='form-control form-control-sm input-solid' id='UDN' name='UDN' required style='width: 200px'>";

            cadena += "<option value=''>&nbsp;</option>";
            foreach (var item in comun.n.udn.Seleccionar_Registros())
            {
                cadena += "<option value=" + item.Id + ">" + item.Nombre + "</option>";
            }
            cadena += "</select>";

            return MvcHtmlString.Create(cadena);
        }

        public static string EstadoPorCodigoPostal(string cp)
        {
            Comun comun = new Comun();
            if (!string.IsNullOrEmpty(cp))
                return comun.n.codigopostal.Seleccionar_EstadoPorCodigoPostal(cp);
            else
                return "";
        }

        public static MvcHtmlString TipoActividad()
        {
            string cadena = string.Empty;
            cadena = "<select class='form-control form-control-sm input-solid' id='TipoActividad' name='TipoActividad' required style='width: 200px'>";

            cadena += "<option value=''>&nbsp;</option>";
            foreach (var item in Catalogos.Seleccionar("TipoActividad"))
            {
                cadena += "<option value=" + item.Id + ">" + item.Nombre + "</option>";
            }
            cadena += "</select>";

            return MvcHtmlString.Create(cadena);
            
        }

        public static MvcHtmlString Roles()
        {
            string cadena = string.Empty;
            cadena = "<select class='form-control form-control-sm input-solid' id='Roles' name='Roles' required style='width: 200px'>";

            cadena += "<option value=''>&nbsp;</option>";
            foreach (var item in Catalogos.Seleccionar("Roles"))
            {
                cadena += "<option value=" + item.Id + ">" + item.Nombre + "</option>";
            }
            cadena += "</select>";

            return MvcHtmlString.Create(cadena);

        }

        public static MvcHtmlString ConfiguracionEmpresas()
        {
            string cadena = string.Empty;
            cadena = "<select class='form-control form-control-sm input-solid' id='Empresa' name='Empresa' required style='width: 200px'>";

            cadena += "<option value=''>&nbsp;</option>";
            foreach (var item in Catalogos.Seleccionar("ConfiguracionEmpresas"))
            {
                cadena += "<option value=" + item.Id + ">" + item.Nombre + "</option>";
            }
            cadena += "</select>";

            return MvcHtmlString.Create(cadena);

        }
    }


}