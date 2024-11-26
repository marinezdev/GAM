using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class ClasificacionRolesContactos : Repository.ClasificacionRolesContactosRespositorio
    {
        public List<mod.ClasificacionRolesContactos> Seleccionar_Registros()
        {
            return Seleccionar();
        }
    }
}
