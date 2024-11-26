using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class ActividadesContacto : Repository.ActividadesContactoRepositorio
    {
        public int Agregar_Registro(mod.ActividadesContacto items)
        {
            return Agregar(items);
        }
    }
}
