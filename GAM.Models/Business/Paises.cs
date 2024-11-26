using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fun = GAM.Utilerias;

namespace GAM.Models.Business
{
    public class Paises :  Repository.PaisesRepository
    {
        public List<fun.Generico> Seleccionar_Paises()
        { 
            return SeleccionarPaises();
        }
    }
}
