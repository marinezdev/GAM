using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAM.Models.Models
{
    public class Escalacion
    {
        public int IdOportunidad { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuarioContacto { get; set; }
    }
}