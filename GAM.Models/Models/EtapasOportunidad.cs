﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAM.Models.Models
{
    public class EtapasOportunidad
    {
        public int IdOportunidad { get; set; }
        public int Etapa { get; set; }
        public DateTime Fecha { get; set; }
        public int Completada { get; set; }
        public DateTime FechaCompletada { get; set; }
    }
}