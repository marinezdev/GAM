using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAM.Models
{
    public class OportunidadesUsuarios
    {
        public int IdOportunidad { get; set; }
        public int IdAsignado { get; set; }
        public int IdClasificacionResponsable { get; set; }
        public int IdSubClasificacionResponsable { get; set; }
    }
}