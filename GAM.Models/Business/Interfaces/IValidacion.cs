﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Models.Business.Interfaces
{
    public interface IValidacion
    {
        bool PropietarioPermiso(string id, string idusuario);
    }
}
