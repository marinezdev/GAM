using GAM.Models;
using GAM.Models.Business;
using GAM.Models.Business.Inyeccion;
using Microsoft.Ajax.Utilities;

namespace GAM.Utilerias
{
    /// <summary>
    /// Pruebas de accesibilidad
    /// </summary>
    public class Cualquiera : Business
    {
        //Esta clase es para probar como se conecta con la clase business para obtener el acceso a todas las instancias.
        public Cualquiera()
        {
            actividades.Seleccionar_Registros();
            usuarios.Seleccionar_Todos();
            estadisticas.Seleccionar_AsuntosPorEmpresaGeneral("2");
            oportunidades.Seleccionar_OportunidadesPorIdResponsable("2");
            configuracion.Seleccionar_Todo();

            //Llevar a cabo todas las tareas para las que se ha seleccionado todo el relajo


            //Accesar todos los con ascii 60<>62
            //Todo esto se manifiesta de alguna u otra forma, aunque es ideal para lo que se esta haciendo.
            //Es facil de llevar comodamente, aunque habra que ver la forma de encontrar algun otro teclado mas pequeño
            // y fácil de llevar a todos lados, no termina de convencerme.

            //Solicitar agregar un registro a un catalogo al administrador

            //Probar implementaciones con los modelos
            Modelos modelos = new Modelos();
            

            var x = Usuario(modelos).Usuarios.Nombre;

            Models.Models.EmpresasMabe m = new Models.Models.EmpresasMabe();
            m.Observaciones = "Al parecer todo bien.";
            m.Activo = true;

            Modelos mm = new Modelos();
            mm.Bitacora.Id = 1;
            mm.Bitacora.Notas = "Esto es lo que está sucediendo en este momento";

        }

        public Modelos Usuario(Modelos modelos)
        {
            Comun comun = new Comun();

            var creador = comun.n.usuarios.Seleccionar_DetalleCreadorOportunidad("2");
            string a = creador.Nombre;
            string b = creador.Correo;
            modelos.Usuarios.Nombre = "Juan Perez";
            comun.n.usuarios.Calculo(); //El método que contiene no se puede accesar por que es por instanciación y su modificador de acceso es protected.
            return modelos;
        }
    }

    public class Cualquiera2 : Models.Business.Usuarios
    {
        public void Calculacion()
        {
            Calcular(); //Accesible porque se  hereda la clase donde se creó aunque el modificador de acceso sea protected
        }
    }

    

    public interface IValidacion
    {
        bool PropietarioPermiso(string id, string idusuario);        
    }

    public class ValidacionOportunidad : Comun, IValidacion
    {
        public bool PropietarioPermiso(string idoportunidad, string idusuario)
        {
            return n.compartiroportunidades.Validar_OportunidadUsuarioPermiso(idoportunidad, idusuario);
        }
    }

    public class ValidacionEmpresa : Comun, IValidacion
    {
        public bool PropietarioPermiso(string idempresa, string idusuario)
        {
            return n.compartirempresa.Validar_EmpresaUsuarioPermiso(idempresa, idusuario);
        }
    }

    public class ValidacionContacto : Comun, IValidacion
    {
        public bool PropietarioPermiso(string idcontacto, string idusuario)
        {
            var idcreador = n.contactos.Seleccionar_CreadorContacto(idcontacto);
            var modificar = n.compartircontactos.Validar_SiUsuarioPuedeModificar(idcontacto, idusuario);
            if (idcreador == idusuario || modificar || idusuario == "2")
                return true;
            else
                return false;
        }
    }

    public class ValidacionActividades : Comun, IValidacion
    {
        public bool PropietarioPermiso(string idactividad, string idusuario)
        {
            var idcreador = n.oportunidadesactividades.Seleccionar_SiUsuarioEsCreadorActividad(idactividad, idusuario);
            if (idcreador == int.Parse(idusuario) || idusuario == "2")
                return true;
            else
                return false;
        }
    }

    public class ConcentradorValidacion
    {
        protected IValidacion validacion;

        public ConcentradorValidacion(IValidacion _ivalidacion)
        {
            validacion = _ivalidacion;
        }

        public bool PropietarioPermiso(string id, string idusuario)
        {
            return validacion.PropietarioPermiso(id, idusuario);
        }
    }

    /// <summary>
    /// Clase contenedora de la validación para cada uno de los procedimientos necesarios a validar
    /// </summary>
    /// <example>
    /// Cómo se aplica:
    /// var validacion = new ValidacionPropietarioPermiso().ContactoValidarPropietarioPermiso(idcontacto, idusuario);
    /// Validación directa en un if
    /// if (new ValidacionPropietarioPermiso().ContactoValidarPropietarioPermiso(idcontacto, idusuario))
    /// </example>
    public class ValidacionPropietarioPermiso
    {
        /// <summary>
        /// Valida si el usuario es el creador de la oportunidad o si tiene permisos para modificarla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        public bool OportunidadValidarPropietarioPermiso(string id, string idusuario)
        {
            var ejecutor = new ConcentradorValidacion(new ValidacionOportunidad());
            return ejecutor.PropietarioPermiso(id, idusuario);
        }

        /// <summary>
        /// Valida si el usuario es el creador de la empresa o si tiene permisos para modificarla
        /// </summary>
        /// <param name="idempresa"></param>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        public bool EmpresaValidarPropietarioPermiso(string idempresa, string idusuario)
        {
            var ejecutor = new ConcentradorValidacion(new ValidacionEmpresa());
            return ejecutor.PropietarioPermiso(idempresa, idusuario);                
        }

        /// <summary>
        /// Valida si el usuario es el creador del contacto o si tiene permisos para modificarlo
        /// </summary>
        /// <param name="idcontacto"></param>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        public bool ContactoValidarPropietarioPermiso(string idcontacto, string idusuario)
        {
            var ejecutor = new ConcentradorValidacion(new ValidacionContacto());
            return ejecutor.PropietarioPermiso(idcontacto, idusuario);
        }

        /// <summary>
        /// Valida si el usuario es el creador de la actividad o si tiene permisos para modificarla o eliminarla
        /// </summary>
        /// <param name="idactividad"></param>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        public bool ActividadValidarPropiedad(string idactividad, string idusuario)
        {
            var ejecutor = new ConcentradorValidacion(new ValidacionActividades());
            return ejecutor.PropietarioPermiso(idactividad, idusuario);
        }

        /// <summary>
        /// Implementación
        /// Inyección de dependencias desde una clase en negocio
        /// </summary>
        public bool Prueba()
        {
            var x = Prueba2().Usuarios.Nombre;
            var ejecute = new Models.Business.ValidacionPropietarioPermiso();
            return ejecute.OportunidadValidarPropietarioPermiso("58", "11");
        }

        public Modelos Prueba2()
        {
            Cualquiera cualquiera = new Cualquiera();            
            Modelos modelos = new Modelos();
            modelos.Usuarios.Nombre = "";
            cualquiera.Usuario(modelos);
            return modelos;
        }

        public void Prueba3()
        {
            //No se puede accesar ningun método con esta instanciación, todo debe pasar por herencia
            Models.Repository.ActividadesContactoDetalleRepositorio acdr = new Models.Repository.ActividadesContactoDetalleRepositorio();            
        }

        public bool Prueba4()
        {
            return new Models.Business.ValidacionPropietarioPermiso().OportunidadValidarPropietarioPermiso("58", "11");
        }
    }
}