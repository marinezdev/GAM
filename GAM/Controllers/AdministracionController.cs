using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using GAM.Models.Models;
using GAM.Models.Repository;
using GAM.Utilerias;
using GAM.Utilerias.WSCorreo;
using System.IO;

namespace GAM.Controllers
{
    [SessionTimeOut]
    public class AdministracionController : BaseController
    {
        private UsuariosRoles usuariorolsesion;

        // GET: Permisos
        public ActionResult Permisos()
        {
            return View("Permisos");
        }

        // GET: Usuarios
        public ActionResult Usuarios()
        {
            ViewBag.Roles = n.roles.Seleccionar_Registros();
            ViewBag.ConfiguracionEmpresas = n.configuracion.Seleccionar_Registros();
            return View(n.usuarios.Seleccionar_Todos());           
        }

        public ActionResult Clasificacion()
        {
            usuariorolsesion = (UsuariosRoles)Session["GranSesion"];
            ViewBag.Empresas = n.configuracion.Seleccionar_Registros();
            dynamic modeloClas = new ExpandoObject();
            //ViewBag.Clasificacion = clar.SeleccionarParaAdministracion();
            //ViewBag.SubClasificacion = scr.SeleccionarParaAdministracion();
            //ViewBag.Etiquetas = cscer.SeleccionarParaAdministracion();
            modeloClas.Clasificacion = n.clasificacion.Seleccionar_ParaAdministracion();
            modeloClas.SubClasificacion = n.subclasificacion.Seleccionar_ParaAdministracion();
            modeloClas.Etiquetas = n.classsubclassetiquetas.Seleccionar_ParaAdministracion();
            return View(modeloClas);
        }

        public ActionResult Configuracion()
        {
            return View(n.configuracion.Seleccionar_Todo());
        }

        public ActionResult Gerentes()
        {
            usuariorolsesion = (UsuariosRoles)Session["GranSesion"];
            if (usuariorolsesion.Configuracion.Id == 2)
                ViewBag.Gerentes = n.usuarios.Seleccionar_UsuariosGerentes(usuariorolsesion.Configuracion.Id.ToString(), usuariorolsesion.Usuarios.Id.ToString(), usuariorolsesion.Roles.Id.ToString());
            else if (usuariorolsesion.Configuracion.Id == 3)
                ViewBag.Gerentes = n.usuarios.Seleccionar_UsuariosGerentesSABE(usuariorolsesion.Usuarios.Id.ToString());
            return View();
        }

        public ActionResult UDN()
        {
            return View(n.udn.Seleccionar_Registros());
        }

        public ActionResult Multi()
        {
            //Proceso de pruebas
            List<Multi2> ee = new List<Multi2>();
            Multi2 e = new Multi2();
            e.Multi.IdConfiguracion = 2;
            e.Multi.IdUsuario = 2;
            e.Usuarios.Nombre = "Juan Perez";
            e.Configuracion.Nombre = "Empresa de Prueba";
            ee.Add(e);
            return View(ee);
        }

        public ActionResult UsuariosR()
        {
            usuariorolsesion = (UsuariosRoles)Session["GranSesion"];
            ViewBag.Usuarios = n.usuarios.Seleccionar_UsuariosResponsables(usuariorolsesion.Configuracion.Id.ToString());
            return View();
        }

        public ActionResult UsuariosRAlta()
        {
            return View();
        }

        public JsonResult QuitarUsuario(string iduser)
        {
            var datos = n.usuarios.Eliminar_Registro(iduser);
            return Json(datos, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UsuariosREdicion(string IdUsuario)
        {
            ViewBag.DetalleUsuario = n.usuarios.Seleccionar_PorId(IdUsuario);
           
            ViewBag.SubClas = n.documentosasaesubclasificaciones.Seleccionar_RegistrosP();

            ViewBag.PersonasEnAsuntos = n.oportunidades.Seleccionar_OportunidadesPorIdResponsable(IdUsuario);
            return View();
        }

        public ActionResult Catalogos()
        {
            return View();
        }

        public ActionResult Empresas()
        {
            ViewBag.EmpresasProveedores = n.empresasproveedores.Seleccionar_Registros();
            return View();
        }

        public ActionResult Notas(int Id)
        {
            return View(n.documentosproveedores.Seleccionar_PorId(Id));
        }

        [HttpPost]
        public ActionResult GuardarNotas(string Id, string Notas, string PalabrasClave)
        {
            n.documentosproveedores.Modificar_Notas(Notas, PalabrasClave, Id);
            var idproveedor = n.documentosproveedores.Seleccionar_PorId(int.Parse(Id)).IdProveedor;
            return Redirect("/Administracion/UsuariosREdicion?IdUsuario=" + idproveedor);
        }

        /// <summary>
        /// Obtiene el detalle del usuario
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult SeleccionarPorId(string Id)
        {
            return Json(n.usuarios.Seleccionar_PorId(Id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Agrega un nuevo usuario
        /// </summary>
        /// <param name="aNombre"></param>
        /// <param name="aClave"></param>
        /// <param name="aContraseña"></param>
        /// <param name="aActivo"></param>
        /// <param name="aRol"></param>
        /// <returns></returns>
        public JsonResult AgregarUsuario(string aNombre, string aApellidoPaterno, string aApellidoMaterno, string aCorreo, string aClave, string aContraseña, string aRol, string IdConfiguracion)
        {
            List<UsuariosRoles> datos = new List<UsuariosRoles>();
            int idusuario = n.usuarios.Agregar_Registro(aNombre, aApellidoPaterno, aApellidoMaterno, aCorreo, aClave, aContraseña);
            if (n.usuariosroles.Agregar_Registro(idusuario.ToString(), aRol))
            {
                //Agregar a Usuarios Configuracion
                n.usuarioconfiguracion.Agregar_Registro(idusuario.ToString(), IdConfiguracion);
                datos = n.usuarios.Seleccionar_Todos().ToList();
            }
            else
                datos = null;
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PreguardadoResponsables(string IdConfiguracion, string Nombre, string Correo, string RFC)
        {
            return Json(n.usuarios.Seleccionar_UsuariosPreGuardado(IdConfiguracion, Nombre, Correo, RFC), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AgregarResponsable(string Nombre, string Correo, string Telefono, string Celular, string Empresa, string Direccion, string Ciudad, string Notas, string Rol, string IdConfiguracion, string FisicaMoral, string RFC, string InternoExterno)
        {
            var respuesta = 0;

            if (n.usuarios.Agregar_Proveedor(Nombre, Correo, Telefono, Celular, Empresa, Direccion, Ciudad, Notas, Rol, IdConfiguracion, FisicaMoral, RFC, InternoExterno, Session["IdUsuario"].ToString()) > 0)
                respuesta = 1;
            //var idusuario = n.usuarios.Agregar_Responsable(Nombre, Correo);
            //if (idusuario > 0)
            //{
                
            //    n.usuarios.Agregar_Detalle(idusuario.ToString(), Telefono, Celular, Empresa, Direccion, Ciudad, Notas, FisicaMoral, RFC, InternoExterno, Session["IdUsuario"].ToString()); //Detalle del usuario
            //    n.usuarioconfiguracion.Agregar_Registro(idusuario.ToString(), IdConfiguracion);                         //Configuracion
            //    n.usuariosroles.Agregar_Registro(idusuario.ToString(), "5");                                            //Roles
            //    n.empresasusuarios.Agregar_Registro(Empresa, idusuario.ToString(), "false");                            //EmpresasUsuarios
            //    var correoresponsable = n.usuarios.Seleccionar_CorreoReponsable(idusuario.ToString());
            //    var titulocorreo = Titulos.TDashboard(Session["IdConfiguracion"].ToString());
            //    //Enviar correo de alta al sistema
            //    if (int.Parse(n.usuariosroles.Seleccionar_RolUsuario(idusuario.ToString())) > 2)
            //    {
            //        correo.EnviarCorreoAltaResponsable(Nombre, correoresponsable, titulocorreo, Session["IdConfiguracion"].ToString());
            //    }
            //    respuesta = 1;                    
            //}

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GuardarResponsableModificado(string Nombre, string Correo, string Telefono, string Celular, string Direccion, string Ciudad, string Notas, string IdUsuario, string FisicaMoral, string RFC, string InternoExterno)
        {
            n.usuarios.Modificar_Responsable(Nombre, Correo, IdUsuario);
            var obtenido = n.usuarios.Modificar_Detalle(Telefono,Celular,Direccion,Ciudad,Notas,IdUsuario, FisicaMoral, RFC, InternoExterno);
            //if (!string.IsNullOrEmpty(Empresa))
            //    n.empresasusuarios.Modificar_EmpresaPorUsuario(IdUsuario, Empresa);
            return Json(obtenido, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SeleccionarUDNPorId(string Id)
        {
            return Json(n.udn.Seleccionar_PorId(Id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AgregarUDN(string aNombre)
        {
            UDN items = new UDN();
            List<UDN> datos = new List<UDN>();
            items.Nombre = aNombre;
            if (n.udn.Agregar_Registro(items) > 0)
            {
                datos = n.udn.Seleccionar_Registros().ToList();                
            }
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ModificarUDN(string nombre, string id)
        {
            var exitoso = 0;
            if (n.udn.Modificar_Registro(nombre, id) > 0)
            {
                exitoso = 1;
            }
            return Json(exitoso, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Agrega un Contacto como un usuario del sistema
        /// </summary>
        /// <param name="aNombre"></param>
        /// <param name="aApellidoPaterno"></param>
        /// <param name="aApellidoMaterno"></param>
        /// <param name="aClave"></param>
        /// <param name="aContraseña"></param>
        /// <param name="aActivo"></param>
        /// <param name="aRol"></param>
        /// <returns></returns>
        public JsonResult AgregarUsuarioContacto(string aNombre, string aApellidoPaterno, string aApellidoMaterno, string aCorreo, string aClave, string aContraseña, string eEmpresa, string aRol, string IdConfiguracion)
        {
            int obtenido = n.usuarios.Agregar_Registro(aNombre, aApellidoPaterno, aApellidoMaterno, aCorreo, aClave, aContraseña);
            if (obtenido > 0)
            {
                n.usuarioconfiguracion.Agregar_Registro(obtenido.ToString(), IdConfiguracion);
                n.usuariosroles.Agregar_Registro(obtenido.ToString(), aRol);
            }
            return Json(obtenido, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Modifica los datos del usuario
        /// </summary>
        /// <param name="eNombre"></param>
        /// <param name="eClave"></param>
        /// <param name="eContraseña"></param>
        /// <param name="eActivo"></param>
        /// <param name="eRol"></param>
        /// <param name="eId"></param>
        /// <returns></returns>
        public JsonResult ModificarUsuario(string eNombre, string eApellidoPaterno, string eApellidoMaterno, string eCorreo,  string eClave, string eContraseña, string eActivo, string eRol, string eId)
        {
            List<UsuariosRoles> datos = new List<UsuariosRoles>();
            if (n.usuarios.Modificar_Registro(eNombre, eApellidoPaterno, eApellidoMaterno, eCorreo, eClave, eContraseña, eActivo, eRol, eId) > 0)
                datos = n.usuarios.Seleccionar_Todos().ToList();
            else
                datos = null;
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        // GET: Roles
        public ActionResult Roles()
        {
            return View(n.roles.Seleccionar_Registros().ToList());
        }

        //Gerentes
        public JsonResult AgregarGerente(string aNombre,string aClave, string aTelefono, string aConfiguracion)
        {
            //Agregado a usuarios
            int obtenido = n.usuarios.Agregar_Registro(aNombre, "", "", aClave, aClave, Funciones.ClaveSalida());
            if (obtenido > 0)
            {
                //Agregar telefono a usuario detalle
                n.usuarios.Agregar_Detalle(obtenido.ToString(), aTelefono, "", "", "", "", "","0", "", "", Session["IdUsuario"].ToString());
                //Agregado a usuario configuracion
                n.usuarioconfiguracion.Agregar_Registro(obtenido.ToString(), aConfiguracion);
                //Agregado usuario rol
                n.usuariosroles.Agregar_Registro(obtenido.ToString(), "3");
                //Enviar correo de acceso para el nuevo gerente
                var titulocorreo = Titulos.TDashboard(Session["IdConfiguracion"].ToString());
                var correogerente = n.usuarios.Seleccionar_ClaveGerente(obtenido.ToString());
                //Enviar correo de alta al sistema                
                correo.EnviarCorreoAltaGerente(aNombre, correogerente, titulocorreo, Session["IdConfiguracion"].ToString());
                //Agregar las empresas para el gerente
                n.empresas.Agregar_EmpresasAGerente(obtenido.ToString(), aConfiguracion);
            }
            return Json(obtenido, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SeleccionarGerentePorId(string id)
        {
            return Json(n.usuarios.Seleccionar_PorId(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ModificarGerente(string eNombre, string eClave,  string eTelefono, string eId)
        {
            n.usuarios.Modificar_Gerente(eNombre, eClave, eTelefono, eId);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SeleccionarEmpresasPorGerente(string id)
        {
            return Json(n.empresasusuarios.Seleccionar_EmpresasPorUsuario(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ActualizarEmpresasPorGerente(string[] listado, string[] listado2, string idusuario)
        {
            var resultado = 0;

            //primero, los no seleccionados
            foreach (var itm in listado2)
            {
                n.empresasusuarios.Modificar_EmpresasPorUsuario(idusuario, itm, "false");
            }


            //segundo, los seleccionados
            foreach (var itm in listado)
            {
                n.empresasusuarios.Modificar_EmpresasPorUsuario(idusuario, itm, "true");
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Agrega un nuevo rol
        /// </summary>
        /// <param name="aNombre"></param>
        /// <param name="aActivo"></param>
        /// <returns></returns>
        public JsonResult AgregarRol(string aNombre, string aObservaciones, string aActivo)
        {
            List<Roles> datos = new List<Roles>();
            if (n.roles.Agregar_Registro(aNombre, aObservaciones, aActivo) > 0)
                datos = n.roles.Seleccionar_Registros().ToList();
            else
                datos = null;
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        //Clasificacion
        public JsonResult AgregarClasificacion(string nombre, string empresa)
        {
            var resultado = new Resultado();
            if (nombre != string.Empty && empresa != string.Empty)
            {
                if (n.clasificacion.Agregar_Registro(nombre, empresa) > 0)
                {
                    resultado.Ok = true;
                    resultado.Mensaje = "Agregado exitosamente";
                }
            }
            else
            {
                resultado.Ok = false;
                resultado.Mensaje = "Algo falló en la inserción, revise";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SeleccionarClasificacionEditar(string id)
        {
            return Json(n.clasificacion.Seleccionar_PorId(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ModificarClasificacion(string nombre, string id)
        {
            var resultado = new Resultado();
            if (nombre != string.Empty && id != string.Empty)
            {
                if (n.clasificacion.Modificar_Registro(nombre, id) > 0)
                {
                    resultado.Ok = true;
                    resultado.Mensaje = "Modificado exitosamente";
                }
            }
            else
            {
                resultado.Ok = false;
                resultado.Mensaje = "Algo falló en la modificación, revise";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //Subclasificacion

        [HttpGet]
        public JsonResult AgregarSubClasificacion(string nombre, string clasificacion)
        {
            var resultado = new Resultado();
            if (nombre != string.Empty && clasificacion != string.Empty)
            {
                if (n.subclasificacion.Agregar_Registro(nombre, clasificacion) >= 1)
                {
                    resultado.Ok = true;
                    resultado.Mensaje = "Todo bien";
                }
                else
                {
                    resultado.Ok = false;
                    resultado.Mensaje = "Algo falló, revise";
                }
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SeleccionarSubClasificacionEditar(string id)
        {
            return Json(n.subclasificacion.Seleccionar_PorIdEditar(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ModificarSubClasificacion(string nombre, string idclasificacion, string id)
        {
            var resultado = new Resultado();
            if (nombre != string.Empty && idclasificacion != string.Empty && id != string.Empty)
            {
                if (n.subclasificacion.Modificar_Registro(nombre, idclasificacion, id) > 0)
                {
                    resultado.Ok = true;
                    resultado.Mensaje = "Modificado exitosamente";
                }
            }
            else
            {
                resultado.Ok = false;
                resultado.Mensaje = "Algo falló en la modificación, revise";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //Etiquetas

        public JsonResult SeleccionarEtiquetas(string clasificacion, string subclasificacion)
        {
            return Json(n.classsubclassetiquetas.Seleccionar_PorIdClasificacionIdSubClasificacionParaEdicion(clasificacion, subclasificacion), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ModificarEtiquetas(string etiqueta1, string etiqueta2, string etiqueta3, string etiqueta4, string idclasificacion, string idsubclasificacion)
        {
            var resultado = new Resultado();
            if (idclasificacion != string.Empty && idsubclasificacion != string.Empty)
            {
                if (n.classsubclassetiquetas.Modificar_Registro(etiqueta1, etiqueta2, etiqueta3, etiqueta4, idclasificacion, idsubclasificacion) > 0)
                {
                    resultado.Ok = true;
                    resultado.Mensaje = "Modificado exitosamente";
                }
            }
            else
            {
                resultado.Ok = false;
                resultado.Mensaje = "Algo falló en la modificación, revise";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //Configuracion
        [HttpGet]
        public JsonResult SeleccionarConfiguracionEditar(string id)
        {
            return Json(n.configuracion.Seleccionar_PorId(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult AgregarConfiguracion(string nombre, string logo, string intermedio)
        {
            var resultado = new Resultado();
            if (nombre != string.Empty && logo != string.Empty && intermedio != string.Empty)
            {
                if (n.configuracion.Agregar_Registro(nombre, logo, intermedio) > 0)
                {
                    resultado.Ok = true;
                    resultado.Mensaje = "Todo bien";
                }
                else
                {
                    resultado.Ok = false;
                    resultado.Mensaje = "Datos incorrectos";
                }
            }
            else
            {
                resultado.Ok = false;
                resultado.Mensaje = "Algo falló, revise";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ModificarConfiguracion(string nombre, string logo, string intermedio, string id)
        {
            var resultado = new Resultado();
            if (nombre != string.Empty && logo != string.Empty && intermedio != string.Empty && id != string.Empty)
            {
                if (n.configuracion.Modificar_Registro(nombre, logo, intermedio, id) > 0)
                {
                    resultado.Ok = true;
                    resultado.Mensaje = "Todo bien";
                }
                else
                {
                    resultado.Ok = false;
                    resultado.Mensaje = "Datos incorrectos";
                }
            }
            else
            {
                resultado.Ok = false;
                resultado.Mensaje = "Algo falló, revise";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //Personas

        public JsonResult CambiarCorreo(string idusuario, string correo)
        {
            Correo correo2 = new Correo();
            string Nombre = n.usuarios.Seleccionar_Nombre(idusuario);
            string correoresponsable = n.usuarios.Seleccionar_CorreoReponsable(idusuario);
            //Enviar correo de modificación en el sistema
            correo2.EnviarCorreoModificacionResponsable(Nombre, correoresponsable, "Cambio de acceso, modificación de correo");
            n.usuarios.Agregar_CorreoAHistorial(idusuario, correoresponsable);
            return Json(n.usuarios.Cambiar_CorreoResponsable(idusuario, correo), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarCorreosCambiados(string idusuario, string correo)
        {
            return Json(n.usuarios.Selecccionar_CorreosCambiados(idusuario), JsonRequestBehavior.AllowGet);
        }

        //Catalogos

        public JsonResult SeleccionarTabla(string tabla, string Id)
        {
            return Json(Models.Catalogos.ListarClas(tabla, Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SeleccionarTablaP(string tabla, string Id)
        {
            return Json(Models.Catalogos.ListarClasP(tabla, Id), JsonRequestBehavior.AllowGet);
        } 
        public JsonResult SeleccionarTabla2(string tabla, string Id)
        {
            return Json(Models.Catalogos.ListarSubClas(tabla, Id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult TablasSeleccionarPorId(string tabla, string id)
        {
            return Json(Models.Catalogos.SeleccionarPorId(tabla,"Id",id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult TablasModificarRegistro(string tabla, string id, string nombre) 
        {
            Models.Catalogos.ModificarNombre(tabla, id, nombre);
            return Json(Models.Catalogos.Seleccionar(tabla), JsonRequestBehavior.AllowGet);
        }

        public JsonResult TablasAgregarNuevo(string tabla, string nombre, string Id)
        {
            Models.Catalogos.Guardar(tabla,nombre,Id);
            return Json(Models.Catalogos.Seleccionar(tabla), JsonRequestBehavior.AllowGet);
        }
        public JsonResult TablasAgregarNuevoP(string tabla, string nombre, string Id)
        {
            Models.Catalogos.GuardarP(tabla,nombre,Id);
            return Json(Models.Catalogos.Seleccionar(tabla), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidarOportunidadSiUSuarioEsPropietarioOTienePermisoParaModificar(string idoportunidad, string idusuario)
        {
            //var validacion = new ValidacionPropietarioPermiso().OportunidadValidarPropietarioPermiso(idoportunidad, idusuario);
            //if (n.usuarios.Seleccionar_CreadorOportunidad(idoportunidad) == idusuario
            //    || n.compartiroportunidades.Validar_SiUsuarioPuedeModificar(idoportunidad, idusuario)
            //    || idusuario == "2")
            if (new ValidacionPropietarioPermiso().OportunidadValidarPropietarioPermiso(idoportunidad, idusuario))
                return Json(1, JsonRequestBehavior.AllowGet);
            else
                return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidarEmpresaSiUSuarioEsPropietarioOTienePermisoParaModificar(string idempresa, string idusuario)
        {
            var validacion = new ValidacionPropietarioPermiso().EmpresaValidarPropietarioPermiso(idempresa, idusuario);
            if (n.empresas.Seleccionar_CreadorEmpresa(idempresa) == idusuario
                || n.compartirempresa.Validar_SiUsuarioPuedeModificar(idempresa, idusuario)
                || idusuario == "2")
                return Json(1, JsonRequestBehavior.AllowGet);
            else
                return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidarContactosSiUSuarioEsPropietarioOTienePermisoParaModificar(string idcontacto, string idusuario)
        {
            var validacion = new ValidacionPropietarioPermiso().ContactoValidarPropietarioPermiso(idcontacto, idusuario);
            if (n.contactos.Seleccionar_CreadorContacto(idcontacto) == idusuario
                || n.compartircontactos.Validar_SiUsuarioPuedeModificar(idcontacto, idusuario)
                || idusuario == "2")
                return Json(1, JsonRequestBehavior.AllowGet);
            else
                return Json(0, JsonRequestBehavior.AllowGet);
        }

        //Empresas Proveedores
        public JsonResult SeleccionarEmpresasProveedores()
        {
            return Json(n.empresasproveedores.Seleccionar_Registros(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SeleccionarEmpresaProveedorPorId(string id)
        { 
            return Json(n.empresasproveedores.Seleccionar_PorId(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AgregarEmpresaProveedor(string nombre, string rfc, string telefono)
        {
            EmpresasProveedores items = new EmpresasProveedores();
            items.Nombre = nombre;
            items.RFC = rfc;
            items.Telefono = telefono;
            return Json(n.empresasproveedores.Agregar_Registro(items), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ModificarEmpresaProveedor(string nombre, string rfc, string telefono, string id)
        {
            EmpresasProveedores items = new EmpresasProveedores();
            items.Nombre = nombre;
            items.RFC = rfc;
            items.Telefono = telefono;
            items.Id = int.Parse(id);
            return Json(n.empresasproveedores.Modificar_Registro(items), JsonRequestBehavior.AllowGet);
        }

        //Proveedores Detalle

        public JsonResult SeleccionarDetalleProveedor(string idusuario)
        {
            return Json(n.usuarios.Seleccionar_PorId(idusuario), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerDdtalleAsuntosAsignados(string idusuario)
        {
            return Json(n.oportunidades.Seleccionar_OportunidadesPorIdResponsable(idusuario), JsonRequestBehavior.AllowGet);
        }



        //DocumentosProveedores

        public JsonResult CargaInicialArchivos(int idproveedor)
        {
            return Json(n.documentosproveedores.Seleccionar_Registros(idproveedor), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DocumentoSeleccionarPorId(int Id)
        {
            return Json(n.documentosproveedores.Seleccionar_PorId(Id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AgregarNotas(string Notas, string Id, int idempresa)
        {
            
            return Json(n.documentosproveedores.Seleccionar_Registros(idempresa), JsonRequestBehavior.AllowGet);
        }

        public JsonResult QuitarArchivo(int iddocumento, int idproveedor)
        {
          
                n.documentosproveedores.Eliminar_Registro(iddocumento);

            return Json(n.documentosproveedores.Seleccionar_Registros(idproveedor), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SubirArchivo()
        {
            // checar si el usuario seleccionó un archivo para subir
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;

                    var idemp = Request.Form["idproveedor"];
                    var notas = Request.Form["notas"];
                    var palcl = Request.Form["palabrasclave"];

                    var clas = Request.Form["clasificacion"];
                    var sclas = Request.Form["subclasificacion"];


                    HttpPostedFileBase file = files[0];
                    string fileName = file.FileName;

                    //Rearmar el nombre del archivo  y agregar un sufijo
                    string nombrearchivo = fileName.Substring(0, fileName.IndexOf("."));
                    string extension = Funciones.ObtenerExtensionArchivo(fileName);
                    int consecutivo = n.documentosproveedores.Seleccionar_Consecutivo(int.Parse(idemp)) == 0 ? 1 : n.documentosproveedores.Seleccionar_Consecutivo(int.Parse(idemp));
                    fileName = nombrearchivo + "_P" + idemp + "_C" + consecutivo.ToString() + extension;

                    // crear un directorio para subir los archivos si no existe
                    string ruta1 = Path.Combine(Server.MapPath("~/Documentos/"), fileName);

                    //Archivo ya existe, se modifica el consecutivo para agregar uno nuevo
                    if (System.IO.File.Exists(ruta1))
                    {
                        nombrearchivo = fileName.Substring(0, fileName.LastIndexOf("_"));
                        extension = Funciones.ObtenerExtensionArchivo(fileName);
                        consecutivo = n.documentosproveedores.Seleccionar_ConsecutivoIncrementa(int.Parse(idemp));
                        fileName = nombrearchivo + "_P" + idemp + "_C" + consecutivo + extension;
                        ruta1 = Path.Combine(Server.MapPath("~/Documentos/"), fileName);
                    }

                    //Guardar en la tabla correspondiente (Archivos)
                    Models.Models.DocumentosProveedores items = new Models.Models.DocumentosProveedores();
                    items.Nombre = fileName;
                    items.IdProveedor = int.Parse(idemp);
                    items.Consecutivo = consecutivo;
                    items.Notas = notas;
                    items.PalabrasClave = palcl;

                    items.Clasificacion = int.Parse(clas);
                    //items.SubClasificacion = int.Parse(sclas);
                    items.SubClasificacion = string.IsNullOrEmpty(sclas) ? 0 : int.Parse(sclas);
                    n.documentosproveedores.Agregar_Registro(items);

                    //Guardar el archivo
                    file.SaveAs(ruta1);

                    //Devolver los archivos
                    return Json(n.documentosproveedores.Seleccionar_Registros(int.Parse(idemp)), JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json("error" + e.Message);
                }
            }

            return Json("Nada");
        }

        //Clasificaciones y subclasificaciones procesos
        public JsonResult EliminarDocumentosASAEClasificacion(string id)
        {
            return Json(n.documentosasaesubclasificaciones.Eliminar_Clasificacion(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult EliminarDocumentosASAEClasificacionP(string id)
        {
            return Json(n.documentosasaesubclasificaciones.Eliminar_ClasificacionP(id), JsonRequestBehavior.AllowGet);
        } 
        public JsonResult EliminarDocumentosASAEClasificacion2(string id)
        {
            return Json(n.documentosasaesubclasificaciones.Eliminar_Clasificacion2(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GuardarDocumentosASAESubClasificacion(string nombre, int clasificacion, int Id)
        {
            Subclasificacion items = new Subclasificacion();
            items.Nombre = nombre;
            items.IdClasificacion = clasificacion;
            items.Id = Id;
            n.documentosasaesubclasificaciones.Agregar_Registro(items);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GuardarDocumentosASAESubClasificacionP(string nombre, int clasificacion, int Id)
        {
            Subclasificacion items = new Subclasificacion();
            items.Nombre = nombre;
            items.IdClasificacion = clasificacion;
            items.Id = Id;
            n.documentosasaesubclasificaciones.Agregar_RegistroP(items);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarDocumentosASAESubClasificacion(string id)
        {
            return Json(n.documentosasaesubclasificaciones.Eliminar_Registro(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult EliminarDocumentosASAESubClasificacionP(string id)
        {
            return Json(n.documentosasaesubclasificaciones.Eliminar_RegistroP(id), JsonRequestBehavior.AllowGet);
        }



        //////???
        public ActionResult DocsSubClas()
        {
            ViewBag.SubClas = n.documentosasaesubclasificaciones.Seleccionar_Registros();
            return View();
        }

        [HttpPost]
        public ActionResult DocsSubClasGuardar(string nombre, int clasificacion)
        {
            Subclasificacion items = new Subclasificacion();
            items.Nombre = nombre;
            items.IdClasificacion = clasificacion;
            n.documentosasaesubclasificaciones.Agregar_Registro(items);
            ViewBag.SubClas = n.documentosasaesubclasificaciones.Seleccionar_Registros();
            return View("DocsSubClas");
        }
    }

    public class Resultado
    { 
        public bool Ok { get; set; }
        public string Mensaje { get; set; }
    }
}
