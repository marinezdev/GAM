using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class Menu : Repository.MenuRepositorio
    {
        public List<mod.MenuMenuRoles> Seleccionar_Registros(string idrol, string idconfiguracion)
        {
            return SeleccionarMenuPorIdRol(idrol, idconfiguracion); 
        }

    }
}
