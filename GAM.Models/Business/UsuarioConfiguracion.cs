using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class UsuarioConfiguracion : Repository.UsuarioConfiguracionRepositorio
    {
        public int Agregar_Registro(string idusuario, string idconfiguracion)
        { 
            return Agregar(idusuario, idconfiguracion);
        }
    }
}
