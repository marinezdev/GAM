using System;

namespace Envios
{
    class Program
    {        
        static void Main(string[] args)
        {
            Avisos avisos = new Avisos();
            avisos.EnvioAvisos();
            //avisos.EnvioEscalaciones();
            //avisos.ActualizaProyectosImportes();
            avisos.EnvioAvisosActividadesOportunidades();
            Environment.Exit(0);
        }
    }
}
