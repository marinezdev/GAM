using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAM.Models.Models
{
    public class Subclasificacion
    {
        public int Id { get; set; }
        public int Idempresa { get; set; }
        public string Nombre { get; set; }
        public int IdClasificacion { get; set; }

    }
}