using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class EstadoOportunidad : Repository.EstadoOportunidadRepositorio
    {
        public List<mod.EstadoOportunidad> Seleccionar_PorIdOportunidad(string idoportunidad)
        { 
            return SeleccionarPorIdOportunidad(idoportunidad);
        }

        public int Agregar_Registro(string idoportunidad, string estado, string comentarios)
        {
            return Agregar(idoportunidad, estado, comentarios);
        }
    }
}
