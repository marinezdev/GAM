﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class ClassSubClass : Repository.ClassSubClassRepositorio
    {
        public mod.ClassSubClass Seleccionar_PorIdOportunidad(string id)
        {
            return SeleccionarPorIdOportunidad(id);
        }

        public int Agregar_Modificar(mod.ClassSubClass items)
        {
            return AgregarModificar(items);
        }
    }
}
