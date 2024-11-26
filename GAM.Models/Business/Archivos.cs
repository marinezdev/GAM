using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class Archivos : Repository.ArchivosRepositorio
    {
        public mod.Archivos Seleccionar_PorId(string id)
        {
            return SeleccionarPorId(id);
        }
        public mod.Archivos Seleccionar_PorId2(string id)
        {
            return SeleccionarPorId2(id);
        }

        public string Seleccionar_PorNombre(string id)
        {
            return SeleccionarPorNombre(id);
        }

        public int Cuantos_ArchivosTieneOportunidad(string idoportunidad)
        {
            return CuantosArchivosTieneOportunidad(idoportunidad);
        }

        public List<mod.Archivos> Seleccionar_PorIdOportunidad(string id)
        {
            return SeleccionarPorIdOportunidad(id);
        }

        public int Seleccionar_Consecutivo(int idoportunidad)
        {
            return SeleccionarConsecutivo(idoportunidad);
        }

        public int SeleccionarConsecutivo_Incrementa(int idoportunidad)
        {
            return SeleccionarConsecutivoIncrementa(idoportunidad);
        }

        public int Agregar_Registro(mod.Archivos items)
        {
            return Agregar(items);
        }

        public int Modificar_Registro(string Notas,string Id, string Clasificacion, string SubClasificacion)
        {
            return Modificar(Notas, Id, Clasificacion, SubClasificacion);
        }

        public int Eliminar_Registro(string id)
        {
            return Eliminar(id);
        }

    }
}
