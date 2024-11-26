using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class DocumentosProveedores : Repository.DocumentosProveedores
    {
        public List<m.DocumentosProveedores> Seleccionar_Registros(int idempresa)
        {
            return Seleccionar(idempresa);
        }

        public m.DocumentosProveedores Seleccionar_PorId(int id)
        {
            return SeleccionarPorId(id);
        }

        public int Seleccionar_Consecutivo(int idempresa)
        {
            return SeleccionarConsecutivo(idempresa);
        }

        public int Seleccionar_ConsecutivoIncrementa(int idempresa)
        {
            return SeleccionarConsecutivoIncrementa(idempresa);
        }

        public string Seleccionar_PorNombre(int id)
        {
            return SeleccionarPorNombre(id);
        }

        public int Agregar_Registro(m.DocumentosProveedores items)
        {
            return Agregar(items);
        }

        public int Modificar_Registro(m.DocumentosProveedores items)
        {
            return Modificar(items);
        }

        public int Modificar_Notas(string Notas, string PalabrasClave, string Id)
        {
            return ModificarNotas(Notas, PalabrasClave, Id);
        }

        public int Eliminar_Registro(int id)
        {
            return Eliminar(id);
        }
    }
}
