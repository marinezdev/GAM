﻿using GAM.Models.Business.Inyeccion;

namespace GAM.Models.Business
{
    /// <summary>
    /// Clase que usa inyección de dependencias para validar procedimientos
    /// </summary>
    public class ValidacionPropietarioPermiso
    {
        public bool OportunidadValidarPropietarioPermiso(string id, string idusuario)
        {
            var ejecutor = new ConcentradorValidacion(new CompartirOportunidades());
            return ejecutor.PropietarioPermiso(id, idusuario);
        }

        public bool EmpresaValidarPropietarioPermiso(string id, string idusuario)
        {
            var ejecutor = new ConcentradorValidacion(new CompartirEmpresa());
            return ejecutor.PropietarioPermiso(id, idusuario);
        }

        public bool ContactoValidarPropietarioPermiso(string id, string idusuario)
        {
            var ejecutor = new ConcentradorValidacion(new CompartirContactos());
            return ejecutor.PropietarioPermiso(id, idusuario);
        }

        public bool ActividadValidarPropiedad(string idactividad, string idusuario)
        {
            var ejecutor = new ConcentradorValidacion(new OportunidadesActividades());
            return ejecutor.PropietarioPermiso(idactividad, idusuario);
        }

        public bool ActividadesValidarPropiedad2(string idactividad, string idusuario)
        {
            return new ConcentradorValidacion(new OportunidadesActividades()).PropietarioPermiso(idactividad, idusuario);
        }


    }
}
