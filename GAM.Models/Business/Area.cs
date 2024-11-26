using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class Area : Repository.AreaRepositorio
    {
        public List<mod.Area> Seleccionar_Registros()
        {
            return Seleccionar();
        }

        public int Agregar_Registro(string nombre)
        {
            return Agregar(nombre);
        }

    }
}
