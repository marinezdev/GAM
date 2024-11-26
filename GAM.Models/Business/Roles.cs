using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class Roles : Repository.RolesRepositorio
    {
        /// <summary>
        /// Obtiene todos los roles
        /// </summary>
        /// <returns></returns>
        public List<mod.Roles> Seleccionar_Registros()
        {
            return Seleccionar();
        }

        public int Agregar_Registro(string Nombre, string Observaciones, string Activo)
        {
            return Agregar(Nombre, Observaciones, Activo);
        }
    }
}
