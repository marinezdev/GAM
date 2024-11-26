using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Models.Business
{
    /// <summary>
    /// Instancias de negocio
    /// </summary>
    public class Business
    {
        public Actividades actividades;
        public ActividadesContacto actividadescontacto;
        public ActividadesContactoDetalle actividadescontactodetalle;
        public Archivos archivos;
        public ArchivosBitacora archivosbitacora;
        public Area area;
        public Aviso aviso;
        public Bitacora bitacora;
        public BitacoraUsuarios bitacorausuarios;
        public BitacoraUsuariosDetalle bitacorausuariosdetalle;
        public Buscar buscar;
        public Busqueda busqueda;
        public Clasificacion clasificacion;
        public ClasificacionRolesContactos clasificacionrolescontactos;
        public ClassSubClass classsubclass;
        public ClassSubClassEtiquetas classsubclassetiquetas;
        public CodigoPostal codigopostal;
        public CompartirContactos compartircontactos;
        public CompartirEmpresa compartirempresa;
        public CompartirOportunidades compartiroportunidades;
        public Configuracion configuracion;
        public ContactoRol contactorol;
        public Contactos contactos;
        public ContactosActividades contactosactividades;
        public ContactosDetalle contactosdetalle;
        public ContactosEmpresas contactosempresas;
        public DocumentosEmpresas documentosempresas;
        public DocumentosProveedores documentosproveedores;
        public DocumentosASAESubClasificaciones documentosasaesubclasificaciones;
        public Empresas empresas;
        public EmpresasDetalle empresasdetalle;
        public EmpresasDirecciones empresasdirecciones;
        public EmpresasProveedores empresasproveedores;
        public EmpresasUsuarios empresasusuarios;
        public Escalacion escalacion;
        public Estadisticas estadisticas;
        public EstadoOportunidad estadooportunidad;
        public EtapasBitacora etapasbitacora;
        public EtapasOportunidad etapasoportunidad;
        public FechaVencimientoCambios fechavencimientocambios;
        public Menu menu;
        public Moneda moneda;
        public MultiRepositorio multirepositorio;
        public Oportunidades oportunidades;
        public OportunidadesActividades oportunidadesactividades;
        public OportunidadesEmpresasContactosUsuarios oecu;
        public OportunidadesImportes oportunidadesimportes;
        public OportunidadesResponsables oportunidadesresponsables;
        public OportunidadesUsuarios oportunidadesusuarios;
        public Paises paises;
        public Roles roles;
        public SubClasificacion subclasificacion;
        public TipoPersona tipopersona;
        public UDN udn;
        public UsuarioConfiguracion usuarioconfiguracion;
        public Usuarios usuarios;
        public UsuariosEmpresasOportunidades ueo;
        public UsuariosRoles usuariosroles;

        public Business()
        {
            documentosasaesubclasificaciones = new DocumentosASAESubClasificaciones();

            actividades = new Actividades();
            actividadescontacto = new ActividadesContacto();
            actividadescontactodetalle = new ActividadesContactoDetalle();
            archivos = new Archivos();
            archivosbitacora = new ArchivosBitacora();
            area = new Area();
            aviso = new Aviso();
            bitacora = new Bitacora();
            bitacorausuarios = new BitacoraUsuarios();
            bitacorausuariosdetalle = new BitacoraUsuariosDetalle();
            buscar = new Buscar();
            busqueda = new Busqueda();
            clasificacion = new Clasificacion();
            clasificacionrolescontactos = new ClasificacionRolesContactos();
            classsubclass = new ClassSubClass();
            classsubclassetiquetas = new ClassSubClassEtiquetas();
            codigopostal = new CodigoPostal();
            compartircontactos = new CompartirContactos();
            compartirempresa = new CompartirEmpresa();
            compartiroportunidades = new CompartirOportunidades();
            configuracion = new Configuracion();
            contactorol = new ContactoRol();
            contactos = new Contactos();
            contactosactividades = new ContactosActividades();
            contactosdetalle = new ContactosDetalle();
            contactosempresas = new ContactosEmpresas();
            documentosempresas = new DocumentosEmpresas();
            documentosproveedores = new DocumentosProveedores();
            empresas = new Empresas();
            empresasdetalle = new EmpresasDetalle();
            empresasdirecciones = new EmpresasDirecciones();
            empresasproveedores = new EmpresasProveedores();
            empresasusuarios = new EmpresasUsuarios();
            escalacion = new Escalacion();
            estadisticas = new Estadisticas();
            estadooportunidad = new EstadoOportunidad();
            etapasbitacora = new EtapasBitacora();
            etapasoportunidad = new EtapasOportunidad();
            fechavencimientocambios = new FechaVencimientoCambios();
            menu = new Menu();
            moneda = new Moneda();
            multirepositorio = new MultiRepositorio();
            oportunidades = new Oportunidades();
            oportunidadesactividades = new OportunidadesActividades();
            oecu = new OportunidadesEmpresasContactosUsuarios();
            oportunidadesimportes = new OportunidadesImportes();
            oportunidadesresponsables = new OportunidadesResponsables();
            oportunidadesusuarios = new OportunidadesUsuarios();
            paises = new Paises();
            roles = new Roles();
            subclasificacion = new SubClasificacion();
            tipopersona = new TipoPersona();
            udn = new UDN();
            usuarioconfiguracion = new UsuarioConfiguracion();
            usuarios = new Usuarios();
            ueo = new UsuariosEmpresasOportunidades();
            usuariosroles = new UsuariosRoles();
        }
    }
}
