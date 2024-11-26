using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAM.Models.Models
{
    /// <summary>
    /// Clase concentradora de todos los modelos
    /// </summary>
    public class Modelos
    {
        public Actividades Actividades { get; set; }
        public Archivos Archivos { get; set; }
        public Aviso Aviso { get; set; }
        public Bitacora Bitacora { get; set; }
        public Configuracion Configuracion { get; set; }
        public Contactos Contactos { get; set; }
        public ContactosActividades ContactosActividades { get; set; }
        public DocumentosEmpresas DocumentosEmpresas { get; set; }
        public DocumentosProveedores DocumentosProveedores { get; set; }
        public Empresas Empresas { get; set; }
        public Escalacion Escalacion { get; set; }
        public Mensajes Mensajes { get; set; }
        public Moneda Moneda { get; set; }
        public Oportunidades Oportunidades { get; set; }
        public OportunidadesActividades OportunidadesActividades { get; set; }
        public OportunidadesEmpresasContactosUsuarios OECU { get; set; }
        public OportunidadesResponsables OportunidadesResponsables { get; set; }
        public Roles Roles { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public UDN UDN { get; set; }
        public Usuarios Usuarios { get; set; }
        public UsuariosRoles UsuariosRoles { get; set; }

        public Modelos()
        {
            Actividades = new Actividades();
            Archivos = new Archivos();
            Aviso = new Aviso();
            Bitacora = new Bitacora();
            Configuracion = new Configuracion();
            Contactos = new Contactos();
            ContactosActividades = new ContactosActividades();
            DocumentosEmpresas = new DocumentosEmpresas();
            DocumentosProveedores = new DocumentosProveedores();
            Empresas = new Empresas();
            Escalacion = new Escalacion();
            Mensajes = new Mensajes();
            Moneda = new Moneda();
            Oportunidades = new Oportunidades();
            OportunidadesActividades = new OportunidadesActividades();
            OECU = new OportunidadesEmpresasContactosUsuarios();
            OportunidadesResponsables = new OportunidadesResponsables();
            Roles = new Roles();
            TipoPersona = new TipoPersona();
            UDN = new UDN();
            Usuarios = new Usuarios();
            UsuariosRoles = new UsuariosRoles();
        }
    }

    public class Mensajes
    { 
        public bool Ok { get; set; }
        public string Mensaje { get; set; }
    }
}