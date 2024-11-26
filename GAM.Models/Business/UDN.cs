using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class UDN : Repository.UDNRepositorio
    {
        public List<mod.UDN> Seleccionar_Registros()
        { 
            return Seleccionar();
        }

        public mod.UDN Seleccionar_PorId(string id)
        { 
            return SeleccionarPorId(id);
        }

        /* Proyectos e importes por mes acumulado y por mes en curso obtenidos por estado ****************************/

        public List<mod.UDNEstadisticas> Seleccionar_ProyectosAcumuladosAlMesPorUDNPorEstado(string estado)
        {
            return SeleccionarProyectosAcumuladosAlMesPorUDNPorEstado(estado);
        }

        public List<mod.UDNEstadisticas> Seleccionar_ProyectosPorUDNEnElMesPorEstado(string estado)
        {
            return SeleccionarProyectosPorUDNEnElMesPorEstado(estado);
        }

        public List<mod.UDNEstadisticas> Seleccionar_ProyectosAcumuladosAlMesPorUDNPorEstado34(string estado)
        { 
            return SeleccionarProyectosEnElMesPorUDNPorEstado34(estado);
        }

        public List<mod.UDNEstadisticas> Seleccionar_ImportesPorUDNAlMesPorEstado(string estado)
        {
            return SeleccionarImportesPorUDNAlMesPorEstado(estado);
        }

        public List<mod.UDNEstadisticas> Seleccionar_ImportesPorUDNEnElMesPorEstado(string estado)
        { 
            return SeleccionarImportesPorUDNEnElMesPorEstado(estado);
        }

        public List<mod.UDNEstadisticas> Seleccionar_ImportesPorUDNEnElMesPorEstado34(string estado)
        { 
            return SeleccionarImportesPorUDNEnElMesPorEstado34(estado);
        }


        /*************************************************************************************************************/

        /* Proyectos e importes por mes acumulado y por mes en curso obtenidos por estado para gráficos **************/

        public List<mod.Modelos> Seleccionar_ProyectosImportesAcumuladoPorEstado(string estado)
        {
            return SeleccionarProyectosImportesAcumuladoPorEstado(estado);
        }

        public List<mod.Modelos> Seleccionar_ProyectosImportesEnElMesPorEstado(string estado)
        {
            return SeleccionarProyectosImportesEnElMesPorEstado(estado);
        }

        /*************************************************************************************************************/
        public List<mod.UDNEstadisticas> Seleccionar_ProyectosPorUDN()
        { 
            return SeleccionarProyectosPorUDN();
        }

        public List<mod.UDNEstadisticas> Seleccionar_ProyectosAcumuladosAlMesPorUDN()
        { 
            return SeleccionarProyectosAcumuladosAlMesPorUDN();
        }

        public List<mod.UDNEstadisticas> Seleccionar_ProyectosPorUDNCerrados()
        { 
            return SeleccionarProyectosPorUDNCerrados();
        }

        //Proyectos CerradosGanados/Cerradosperdidos acumulados al mes
        public List<mod.UDNEstadisticas> Seleccionar_ProyectosPorUDNCerradosGanadosAlMes()
        {
            return SeleccionarProyectosAcumuladosCerradosGanadosAlMesPorUDN();
        }
        public List<mod.UDNEstadisticas> Seleccionar_ProyectosPorUDNCerradosPerdidosAlMes()
        {
            return SeleccionarProyectosAcumuladosCerradosPerdidosAlMesPorUDN();
        }

        //Proyectos cerradosganados/cerradosperdidos en el mes
        public List<mod.UDNEstadisticas> Seleccionar_ProyectosPorUDNCerradosGanadosEnElMes()
        {
            return SeleccionarProyectosPorUDNCerradosGanadosEnElMes();
        }

        public List<mod.UDNEstadisticas> Seleccionar_ProyectosPorUDNCerradosPerdidosEnElMes()
        {
            return SeleccionarProyectosPorUDNCerradosPerdidosEnElMes();
        }

        //Montos cerradosganados/cerradosperdidos acumulados al mes

        public List<mod.UDNEstadisticas> Seleccionar_ImportesAcumuladosAlMesPorUDNCerradosPerdidos()
        {
            return SeleccionarImportesAcumuladosAlMesPorUDNCerradosPerdidos();
        }
        public List<mod.UDNEstadisticas> Seleccionar_ImportesAcumuladosAlMesPorUDNCerradosGanados()
        {
            return SeleccionarImportesAcumuladosAlMesPorUDNCerradosGanados();
        }

        //Montos cerrados ganados/cerrados perdidos en el mes

        public List<mod.UDNEstadisticas> Seleccionar_ImportesEnElMesPorUDNCerradosGanados()
        {
            return SeleccionarImportesPorUDNCerradosGanados();
        }
        public List<mod.UDNEstadisticas> Seleccionar_ImportesEnElMesPorUDNCerradosPerdidos()
        {
            return SeleccionarImportesPorUDNCerradosPerdidos();
        }


        public List<mod.UDNEstadisticas> Seleccionar_ProyectosAcumuladosAlMesPorUDNCerrados()
        { 
            return SeleccionarProyectosAcumuladosAlMesPorUDNCerrados();
        }

        public List<mod.UDNEstadisticas> Seleccionar_ImportesPorUDN()
        { 
            return SeleccionarImportesPorUDN();
        }

        public List<mod.UDNEstadisticas> Seleccionar_ImportesAcumuladosAlMesPorUDN()
        { 
            return SeleccionarImportesAcumuladosAlMesPorUDN();
        }

        public List<mod.UDNEstadisticas> Seleccionar_ImportesPorUDNCerrados()
        { 
            return SeleccionarImportesPorUDNCerrados();
        }

        public List<mod.UDNEstadisticas> Seleccionar_ImportesAcumuladosAlMesPorUDNCerrados()
        { 
            return SeleccionarImportesAcumuladosAlMesPorUDNCerrados();
        }

        public List<mod.UDNXMes> Seleccionar_ProyectosPorMes()
        { 
            return SeleccionarProyectosPorMes();
        }

        public List<mod.UDNXMes> Seleccionar_ImportesPorMes()
        { 
            return SeleccionarImportesPorMes();
        }

        public void Actualizar_ProyectosImportes()
        {
            ActualizarProyectosImportes();
        }

        public int Agregar_Registro(mod.UDN items)
        { 
            return Agregar(items);
        }

        public int Modificar_Registro(string nombre, string id)
        { 
            return Modificar(nombre, id);
        }
    }
}
