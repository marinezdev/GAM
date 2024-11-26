using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Models.Models
{
    public class DocumentosHistorico
    {
        public int Id { get; set; }
        public int IdDocumento { get; set; }
        public string Nombre { get; set; }
        public int Version { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public int IdUsuarioPosicion { get; set; }
        public string Comentarios { get; set; }
    }
}
