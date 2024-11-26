using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Models.Models
{
    public class DocumentosTipoArchivo
    {
        public int Id { get; set; }
        public string Extensiones { get; set; }
        public int TamMaxPermitido { get; set; }
        public bool Permitir { get; set; }
    }
}
