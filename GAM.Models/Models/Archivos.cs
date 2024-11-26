using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAM.Models.Models
{
    public class Archivos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdOportunidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Notas { get; set; }
        public int Version { get; set; } //Ahora contempla el consecutivo del archivo para una oportunidad

        public int Clasificacion { get; set; }
        public int SubClasificacion { get; set; }
        public int Activo { get; set; }
        
        
    }
}