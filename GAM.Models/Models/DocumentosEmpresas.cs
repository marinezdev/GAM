using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Models.Models
{
    public class DocumentosEmpresas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdEmpresa { get; set; }
        public string Notas { get; set; }
        public string PalabrasClave { get; set; }
        public int Consecutivo { get; set; }
        public DateTime Fecha { get; set; }

        //CAMBIOS
        public int Clasificacion { get; set; }
        public int SubClasificacion { get; set; }
    }
}
