using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAM.Models.Models
{
    public class OportunidadesBuscar
    {
        public Oportunidades Oportunidades { get; set; }
        public Empresas Empresas { get; set; }

        public OportunidadesBuscar()
        {
            Oportunidades = new Oportunidades();
            Empresas = new Empresas();
        }
    }
}