using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Models.Models
{
    public class Buscar
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public string Archivo { get; set; }
        public DateTime Fecha { get; set; }
        public string EncontradoEn { get; set; }
        public string PalabrasClave { get; set; }
        public string PalabraBuscada { get; set; }
        public string EmpresaBuscada { get; set; }
        public int Creador { get; set; }
    }
}
