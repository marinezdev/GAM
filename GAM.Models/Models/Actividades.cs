using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAM.Models.Models
{
    public class Actividades
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Clasificacion { get; set; }
        public int SubClasificacion { get; set; }
    }
}