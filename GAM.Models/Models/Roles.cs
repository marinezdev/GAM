using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAM.Models.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Observaciones { get; set; }
        public bool? Activo { get; set; }


    }
}