﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class MultiRepositorio : Repository.MultiRepositorio
    {
        public List<mod.Multi2> Seleccionar_Registros()
        {
            return Seleccionar();
        }

        public int Eliminar_Registro(string idconfiguracion, string idusuario)
        { 
            return Eliminar(idconfiguracion, idusuario);
        }
    }
}
