using GAM.Models.Business.Abstractas;
using GAM.Models.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Models
{
    class UsuarioDetalle : Usuario, IEtiquetas
    {
        public UsuarioDetalle(string nombre) : base(nombre)
        {

        }

        public string Nombre()
        {
            return nombre;
        }

        public string Persona()
        {
            return "";
        }

        public string InternoExterno()
        {
            return "";
        }
    }
}
