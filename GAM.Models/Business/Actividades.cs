using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    /// <summary>
    /// Catálogo de actividades
    /// </summary>
    public class Actividades : Repository.ActividadesRepositorio
    {
        public List<mod.Actividades> Seleccionar_Registros()
        {
            return Seleccionar();
        }

        public List<mod.Actividades> Agregar_Seleccionar(mod.Actividades items)
        {
            Agregar(items);
            return Seleccionar();
        }

        public bool Agregar_Registro(mod.Actividades items)
        {
            return Agregar(items);
        }
    }
}
