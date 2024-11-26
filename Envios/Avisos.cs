using System.Collections.Generic;
using System.Data;

namespace Envios
{
    public class Avisos
    {
        ReferenciaDeServicioDeCorreoDeASAE.CorreoSoapClient correoSoap = new ReferenciaDeServicioDeCorreoDeASAE.CorreoSoapClient();

        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public void EnvioAvisos()
        {
            if (SelecccionarUsuariosParaEnviarAviso().Count > 0)
            {
                foreach (var item in SelecccionarUsuariosParaEnviarAviso())
                {
                    var tituloasunto = "Aviso de Asignación";
                    var asunto = SeleccionarNombreTemaPorIdoportunidad(item.Id.ToString());
                    var empresaasignada = SeleccionarNombreEmpresaPorIdOportunidad(item.Id.ToString());
                    var vencimiento = SeleccionarVencimientoTemaPorIdoportunidad(item.Id.ToString());
                    //var cuerpocorreo = "<p>Hola " + item.Nombre + "</p>";
                    //var titulocorreo = "Gestión de Asuntos - Aviso";
                    //cuerpocorreo += "<p>Se le ha asignado el siguiente objeto para su atención:</p>";
                    //cuerpocorreo += "<h3>" + tituloasunto + "</h3>" +
                    //    "<h3>Empresa: " + empresaasignada + "</h3>" +
                    //    "<h3>Vencimiento: " + vencimiento + "</h3>" +
                    //    "<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
                    //    "<h4><a href='http://187.248.23.163:1052/'>http://187.248.23.163:1052/</a></h4>" +
                    //    "<br /><br /><br />";

                    var cuerpocorreo = InicioCorreo();

                    cuerpocorreo += "<tr><td>Se le informa que ha sido asignado al sistema <strong>Gestión de Asuntos</strong> para que atienda el siguiente Asunto:</td></tr>" +
                    "<tr><td>Nombre: " + tituloasunto + "</td></tr>" +
                    "<tr><td>Empresa: " + empresaasignada + "</td></tr>" +
                    "<tr><td>Vencimiento: " + vencimiento + "</td></tr>";

                    cuerpocorreo += FinCorreo();

                    EnviarCorreo(item.Correo, "Asignación a Asunto de Gestión de Asuntos", asunto, cuerpocorreo);
                }
                //Enviar correo de aviso al creador del objeto/oportunidad
                foreach (var item in SelecccionarUsuariosParaEnviarAviso())
                {
                    var usuario = SeleccionarCreadorOportunidad(item.Id.ToString());
                    var asunto = SeleccionarNombreTemaPorIdoportunidad(item.Id.ToString());
                    //var cuerpocorreo = "<h3>Hola " + usuario.Nombre + "</h3>" +
                    //    "<p>Este correo es para recordarle que se ha enviado un aviso a un usuario asignado para: " + asunto + "</p>" +
                    //    "<br /><br /><br />";

                    var cuerpocorreo = InicioCorreo();

                    cuerpocorreo += "<tr><td>Hola " + usuario.Nombre + "</td></tr>" +
                    "<tr><td>Este correo es para recordarle que se ha enviado un aviso a un usuario asignado para: " + asunto + "</td></tr>";

                    cuerpocorreo += FinCorreo();

                    EnviarCorreo(usuario.Correo, "Aviso", "Recordatorio de Aviso", cuerpocorreo);
                }
            }
        }

        public void EnvioEscalaciones()
        {
            if (SelecccionarUsuariosParaEnviarEscalacion().Count > 0)
            {
                foreach (var item in SelecccionarUsuariosParaEnviarEscalacion())
                {
                    var tituloasunto = "Escalación de Asignación";
                    var asunto = SeleccionarNombreTemaPorIdoportunidad(item.Id.ToString());
                    var empresaasignada = SeleccionarNombreEmpresaPorIdOportunidad(item.Id.ToString());
                    var vencimiento = SeleccionarVencimientoTemaPorIdoportunidad(item.Id.ToString());
                    //var cuerpocorreo = "<p>Hola " + item.Nombre + "</p>";
                    var titulocorreo = "Gestión de Asuntos - Escalación";
                    //cuerpocorreo += "<p>Se le ha asignado el siguiente asunto para su atención:</p>";
                    //cuerpocorreo += "<h3>" + tituloasunto + "</h3>" +
                    //    "<h3>Empresa: " + empresaasignada + "</h3>" +
                    //    "<h3>Vencimiento: " + vencimiento + "</h3>" +
                    //    "<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
                    //    "<h4><a href='http://187.248.23.163:1052/'>http://187.248.23.163:1052/</a></h4>" +
                    //    "<br /><br /><br />";

                    var cuerpocorreo = InicioCorreo();

                    cuerpocorreo += "<tr><td>Se le informa que ha sido asignado al sistema <strong>Gestión de Asuntos</strong> para que atienda el siguiente Asunto:</td></tr>" +
                    "<tr><td>Nombre: " + tituloasunto + "</td></tr>" +
                    "<tr><td>Empresa: " + empresaasignada + "</td></tr>" +
                    "<tr><td>Vencimiento: " + vencimiento + "</td></tr>";

                    cuerpocorreo += FinCorreo();
                    
                    EnviarCorreo(item.Correo, titulocorreo, asunto, cuerpocorreo);
                }

                //Enviar correo de escalación al creador del objeto/oportunidad
                foreach (var item in SelecccionarUsuariosParaEnviarAviso())
                {
                    var usuario = SeleccionarCreadorOportunidad(item.Id.ToString());
                    var asunto = SeleccionarNombreTemaPorIdoportunidad(item.Id.ToString());
                    //var cuerpocorreo = "<h3>Hola " + usuario.Nombre + "</h3>" +
                    //    "<p>Este correo es para recordarle que se ha enviado un aviso de escalación a un usuario asignado para: " + asunto + "</p>" +
                    //    "<br /><br /><br />";

                    var cuerpocorreo = InicioCorreo();

                    cuerpocorreo += "<tr><td>Hola " + usuario.Nombre + "</td></tr>" +
                    "<tr><td>Este correo es para recordarle que se ha enviado un aviso a un usuario asignado para: " + asunto + "</td></tr>";

                    cuerpocorreo += FinCorreo();

                    EnviarCorreo(usuario.Correo, "Aviso", "Recordatorio de Aviso", cuerpocorreo);
                }
            }
        }

        public void EnvioAvisosActividadesOportunidades()
        {
            if (SelecccionarUsuariosParaEnviarOportunidadesActividades().Count > 0)
            {
                foreach (var item in SelecccionarUsuariosParaEnviarOportunidadesActividades())
                {
                    var tituloasunto = "Aviso de Actividades de Asunto";
                    var asunto = SeleccionarNombreTemaPorIdoportunidad(item.Id.ToString());
                    var empresaasignada = SeleccionarNombreEmpresaPorIdOportunidad(item.Id.ToString());
                    var vencimiento = SeleccionarVencimientoTemaPorIdoportunidad(item.Id.ToString());
                    var titulocorreo = "Gestión de Asuntos - Aviso de Actividades de Asunto";

                    var cuerpocorreo = InicioCorreo();

                    cuerpocorreo += "<td><tr>Hola " + item.Nombre + "</td></tr>" +

                    "<tr><td>Asunto: " + tituloasunto + "</td></tr>" +
                    "<tr><td>Empresa: " + empresaasignada + "</td></tr>" +
                    "<tr><td>Vencimiento: " + vencimiento + "</td><tr>";

                    cuerpocorreo += FinCorreo();

                    EnviarCorreo(item.Correo, titulocorreo, asunto, cuerpocorreo);
                }

                //Enviar correo de escalación al creador del objeto/oportunidad
                foreach (var item in SelecccionarUsuariosParaEnviarAviso())
                {
                    var usuario = SeleccionarCreadorOportunidad(item.Id.ToString());
                    var asunto = SeleccionarNombreTemaPorIdoportunidad(item.Id.ToString());

                    var cuerpocorreo = InicioCorreo();
                    cuerpocorreo += "<tr><td>Hola " + usuario.Nombre + "</td></tr>" +
                    "<tr><td>" + item.Notas + "</td></tr>";

                    cuerpocorreo += FinCorreo();
                    
                    EnviarCorreo(usuario.Correo, "Aviso de Actividades de Gestión de Asuntos", "Mensaje Importante", cuerpocorreo);
                }
            }
        }

        public bool EnviarCorreo(string correoaqueinseenvia, string titulo, string asunto, string mensaje)
        {
            if (correoSoap.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_",
                correoaqueinseenvia, //A quién se va a enviar el correo
                titulo,              //Titulo de quién lo envia
                asunto,              //Asunto del correo
                mensaje) == "Correo Enviado")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<GAM.Models.Models.Usuarios> SelecccionarUsuariosParaEnviarAviso()
        {
            string consulta = "SELECT avi.idoportunidad,avi.idusuario,usu.Correo, opor.IdConfiguracion, usu.Nombre + ' ' + ISNULL(usu.ApellidoPaterno,'') + ' ' + ISNULL(usu.ApellidoMaterno,'') AS Nombre " +
            "FROM aviso avi " +
            "INNER JOIN usuarios usu ON usu.id = avi.IdUsuario " +
            "INNER JOIN oportunidades opor ON opor.id=avi.IdOportunidad " +
            "WHERE avi.fecha = CONVERT(VARCHAR, GETDATE(), 23)";
            b.ExecuteCommandQuery(consulta);
            List<GAM.Models.Models.Usuarios> resultado = new List<GAM.Models.Models.Usuarios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                GAM.Models.Models.Usuarios item = new GAM.Models.Models.Usuarios();
                item.Id = int.Parse(reader["idoportunidad"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                item.IdUsuario = int.Parse(reader["idusuario"].ToString());
                item.Correo = reader["Correo"].ToString();
                item.Empresa = int.Parse(reader["idconfiguracion"].ToString());
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        public List<GAM.Models.Models.Usuarios> SelecccionarUsuariosParaEnviarEscalacion()
        {
            string consulta = "SELECT esc.idoportunidad, esc.idusuariocontacto, usu.Correo, opor.IdConfiguracion, usu.Nombre + ' ' + ISNULL(usu.ApellidoPaterno,'') + ' ' + ISNULL(usu.ApellidoMaterno,'') AS Nombre " +
            "FROM escalacion esc " +
            "INNER JOIN usuarios usu ON usu.id = esc.IdUsuariocontacto " +
            "INNER JOIN oportunidades opor ON opor.id = esc.IdOportunidad " +
            "WHERE esc.fecha = CONVERT(VARCHAR, GETDATE(), 23)";
            b.ExecuteCommandQuery(consulta);
            List<GAM.Models.Models.Usuarios> resultado = new List<GAM.Models.Models.Usuarios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                GAM.Models.Models.Usuarios item = new GAM.Models.Models.Usuarios();
                item.Id = int.Parse(reader["idoportunidad"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                item.IdUsuario = int.Parse(reader["idusuariocontacto"].ToString());
                item.Correo = reader["Correo"].ToString();
                item.Empresa = int.Parse(reader["idconfiguracion"].ToString());
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        //Envío de correos de las actividades

        public List<GAM.Models.Models.Usuarios> SelecccionarUsuariosParaEnviarOportunidadesActividades()
        {
            string consulta = "SELECT oa.idoportunidad, oa.idusuario, usu.Correo, opor.IdConfiguracion, usu.Nombre + ' ' + ISNULL(usu.ApellidoPaterno,'') + ' ' + ISNULL(usu.ApellidoMaterno,'') AS Nombre, oa.notas " +
            "FROM OportunidadesActividades oa " +
            "INNER JOIN usuarios usu ON usu.id = oa.idusuario " +
            "INNER JOIN oportunidades opor ON opor.id = oa.IdOportunidad " +
            "WHERE oa.fecha = CONVERT(VARCHAR, GETDATE(), 23)";
            b.ExecuteCommandQuery(consulta);
            List<GAM.Models.Models.Usuarios> resultado = new List<GAM.Models.Models.Usuarios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                GAM.Models.Models.Usuarios item = new GAM.Models.Models.Usuarios();
                item.Id = int.Parse(reader["idoportunidad"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                item.IdUsuario = int.Parse(reader["idusuario"].ToString());
                item.Correo = reader["Correo"].ToString();
                item.Empresa = int.Parse(reader["idconfiguracion"].ToString());
                item.Notas = reader["notas"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        //Fin de Envío de correos de las actividades

        public string SeleccionarNombreTemaPorIdoportunidad(string id)
        {
            b.ExecuteCommandQuery("SELECT nombre FROM oportunidades WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.SelectString();
        }

        public string SeleccionarNombreEmpresaPorIdOportunidad(string id)
        {
            b.ExecuteCommandQuery("SELECT emp.nombre " +
            "FROM oportunidades opor " +
            "INNER JOIN oecu ON oecu.IdOportunidad = opor.id " +
            "INNER JOIN empresas emp ON emp.id = oecu.IdEmpresa " +
            "WHERE opor.id = @id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.SelectString();
        }

        public string SeleccionarVencimientoTemaPorIdoportunidad(string id)
        {
            b.ExecuteCommandQuery("SELECT cierre FROM oportunidades WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.SelectString();
        }

        public GAM.Models.Models.Usuarios SeleccionarCreadorOportunidad(string id)
        {
            string consulta = "SELECT usu.nombre + ' ' + ISNULL(usu.ApellidoPaterno, '') + ' ' + ISNULL(usu.ApellidoMaterno, '') AS Nombre, usu.correo " +
            "FROM oecu " +
            "INNER JOIN usuarios usu ON usu.Id = oecu.IdUsuario " +
            "INNER JOIN Oportunidades opor ON opor.Id = oecu.IdOportunidad " +
            "WHERE oecu.IdOportunidad=@idoportunidad";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idoportunidad", id, SqlDbType.Int);
            GAM.Models.Models.Usuarios resultado = new GAM.Models.Models.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Correo = reader["Correo"].ToString();
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        //Procesa los datos de las estadísticas

        /// <summary>
        /// Actualiza los datos de la tablas que contienen los acumulados de proyectos e importes por mes
        /// </summary>
        public void ActualizaProyectosImportes()
        {
            b.ExecuteCommandSP("EstadisticasProyectosImportes_Actualizar");
            b.SelectString();
        }

        public List<enviosmismafecha> SeleccionarOportunidadesAEnviarAvisosCadaAñoEnLaMismaFecha()
        {
            string consulta = "" +
            //"SELECT opo.nombre, emp.nombre, opo.Cierre, MONTH(GETDATE()) AS MesActual, MONTH(cierre) AS MesCierre, " +
            //"CAST(DAY(GETDATE()) AS VARCHAR) + '/' + CAST(MONTH(GETDATE()) AS VARCHAR)  AS DiaHoy, " +
            //"CAST(DAY(cierre) AS VARCHAR)  + '/' + CAST(MONTH(cierre) AS VARCHAR) AS DiaCierre, " +
            //"DATEDIFF(d, getdate(), cierre) DiasFaltanParaAvisos, " +
            "SELECT opo.id, " +
            "CASE " +
            "    WHEN DATEDIFF(d, getdate(), cierre) = 30 THEN 'Primero' " +
            "    WHEN DATEDIFF(d, getdate(), cierre) = 15 THEN 'Segundo' " +
            "    ELSE '' " +
            "END AS Mensaje " +
            "FROM oportunidades opo " +
            "INNER JOIN oecu ON oecu.IdOportunidad = opo.Id " +
            "INNER JOIN Empresas emp ON emp.Id = oecu.IdEmpresa " +
            "WHERE opo.Estado=1 " +
            "AND oecu.idconfiguracion=3 " +
            "AND repetirproximoaño=1";
            b.ExecuteCommandQuery(consulta);
            List<enviosmismafecha> resultado = new List<enviosmismafecha>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                enviosmismafecha item = new enviosmismafecha();
                item.Id = int.Parse(reader["id"].ToString());
                item.Mensaje = reader["mensaje"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;

        }

        public void UsuariosQueDanSeguimientoAOportunidadAvisoCadaAño(string idoportunidad)
        { 
            
        }

        public string InicioCorreo()
        {
            return "<html>" +
            "<head>" +
            "<style>" +
            "body {font-family: Arial, Helvética, sans-serif }" +
            "a { text-decoration: none; color: blue }" +
            "a:hover {text-decoration: underline }" +
            "</style>" +
            "</head>" +
            "<body style='background-color: #FFFFCC'>" +
            "<table align='center' border='0' width='600' cellpadding='0' cellspacing='0' style='border-collapse: collapse;'>" +
            "<tr><th colspan='3' align='center' style='height: 40px; line-height:30px'><h2>Gestión de Asuntos</h2></th></tr>" +
            "<tr><td colspan='3' align='center' style='height: 40px; line-height:30px'>&nbsp;</td></tr>";
        }

        public string FinCorreo()
        {
            return "<tr><td>&nbsp;</td></tr>" +
                "<tr><td style='background-color:#FF6A00; height: 40px; padding: 3px'>Para atender asuntos del sistema, dé click en la siguiente liga para accesar:</td></tr>" +
                "<tr><td colspan='3' align='left' style='background-color:#FF6A00; height: 40px; padding: 3px'><a href='http://187.248.23.163:1052/'>Accesar Gestión de Asuntos</a></td></tr>" +
                "</table>" +
                "</body>" +
                "</html>" +
                "<br /><br /><br />";
        }

    }

    public class enviosmismafecha
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
    }
}
