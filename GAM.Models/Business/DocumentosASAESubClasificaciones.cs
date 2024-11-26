using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class DocumentosASAESubClasificaciones : Repository.DocumentosASAESubClasificacionesRepository
    {
        public List<mod.Subclasificacion> Seleccionar_Registros()
        {
            return Seleccionar();
        }
        public List<mod.Subclasificacion> Seleccionar_RegistrosP()
        {
            return SeleccionarP();
        }

        public mod.Subclasificacion Seleccionar_PorId(string id)
        {
            return SeleccionarPorId(id);
        }

        public List<mod.Subclasificacion> Seleccionar_SubClasificacionesPorClasificacion(string idclasificacion)
        {
            return SeleccionarSubClasificacionesPorClasificacion(idclasificacion);
        } 
        public List<mod.Subclasificacion> Seleccionar_SubClasificacionesPorClasificacionP(string idclasificacion)
        {
            return SeleccionarSubClasificacionesPorClasificacionP(idclasificacion);
        }

        public int Agregar_Registro(mod.Subclasificacion items)
        {
            return Agregar(items);
        }
        public int Agregar_RegistroP(mod.Subclasificacion items)
        {
            return AgregarP(items);
        }

        public int Modificar_Registro(mod.Subclasificacion items)
        {
            return Modificar(items);
        }

        public int Eliminar_Registro(string id)
        {
            return Eliminar(id);
        }
        public int Eliminar_RegistroP(string id)
        {
            return EliminarP(id);
        }

        public int Eliminar_Clasificacion(string id)
        {
            return EliminarClasificacion(id);
        } 
        public int Eliminar_ClasificacionP(string id)
        {
            return EliminarClasificacionP(id);
        } 
        public int Eliminar_Clasificacion2(string id)
        {
            return EliminarClasificacion2(id);
        }

    }
}
