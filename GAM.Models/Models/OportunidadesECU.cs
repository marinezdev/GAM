using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAM.Models.Models
{
    public class OportunidadesECU
    {
        public Oportunidades Oportunidades { get; set; }
        public OportunidadesEmpresasContactosUsuarios OECU { get; set; }
        public Clasificacion Clasificacion { get; set; }
        public Subclasificacion SubClasificacion { get; set; }
        public ClassSubClass ClassSubClass { get; set; }
        public Empresas Empresas { get; set; }
        public Escalacion Escalacion { get; set; }
        public UDN UDN { get; set; }

        public Usuarios Usuarios { get; set; }

        public OportunidadesECU()
        {
            Oportunidades = new Oportunidades();
            OECU = new OportunidadesEmpresasContactosUsuarios();
            Clasificacion = new Clasificacion();
            SubClasificacion = new Subclasificacion();
            ClassSubClass = new ClassSubClass();
            Empresas = new Empresas();
            Escalacion = new Escalacion();
            UDN = new UDN();
            Usuarios = new Usuarios();
        }
    }
}