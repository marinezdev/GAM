namespace GAM.Utilerias
{
    public class Correo
    {
        readonly WSCorreo.CorreoSoapClient correoSoap = new WSCorreo.CorreoSoapClient();

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

        public bool EnviarCorreoAltaGerente(string nombre, string correogerente, string titulocorreo, string idconfiguracion) 
        {
            //var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>" +
            //"<p>Ha sido agregado al sistema <strong>Gestión de Asuntos</strong> para llevar a cabo tareas de responsabilidad próximamente.</p>" + 
            //"<p>Le llegará un correo con un nuevo objeto para su atención, sus claves de acceso son las siguientes: </p>" +           
            //"<h3>Correo de acceso: " + correogerente + "</h3>" +
            //"<h3>Contraseña: " + Funciones.ClaveSalida() + "</h3>" +
            //"<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
            //"<h4><a href='http://187.248.23.163:1052/'>Accesar Gestión de Asuntos</a></h4>" +
            //"<p>La clave de acceso debe ser cambiada por una personalizada inmediatamente en la sección Cambiar Contraseña, " +
            //"de lo contrario se bloqueará el acceso al sistema.</p><br /><br /><br />";


            var cuerpocorreo = InicioCorreo();

            cuerpocorreo += "<tr><td>Hola " + nombre.ToUpper() + "</strong></td></tr>" +
            "<tr><td>Ha sido agregado al sistema <strong>Gestión de Asuntos</strong> para llevar a cabo tareas de responsabilidad próximamente.</td></tr>" +
            "<tr><td>Le llegará un correo más adelante con un nuevo asunto para su atención, sus claves de acceso para acceso son las siguientes:</td></tr>" +
            "<tr><td>Correo de acceso: " + correogerente + "</td></tr>" +
            "<tr><td>Contraseña: " + Funciones.ClaveSalida() + "</td></tr>";

            cuerpocorreo += FinCorreo();


            return EnviarCorreo(correogerente, titulocorreo, "Nueva clave de acceso para Gestión de Asuntos", cuerpocorreo);
        }

        public bool EnviarCorreoAltaResponsable(string nombre, string correoresponsable, string titulocorreo, string idconfiguracion) 
        {
            //var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>" +
            //"<p>Ha sido agregado al sistema <strong>Gestión de Asuntos</strong> para llevar a cabo tareas de responsabilidad próximamente.</p>" +
            //"<p>Le llegará un correo con un nuevo asunto para su atención, sus claves de acceso son las siguientes:</p>" + 
            //"<h3>Clave de acceso: " + correoresponsable + "</h3>" +
            //"<h3>Contraseña: " + Funciones.ClaveSalida() + "</h3>" +
            //"<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
            //"<h4><a href='http://187.248.23.163:1052/'>Accesar Gestión de Asuntos</a></h4>" +
            //"<p>La contraseña debe ser cambiada por una personalizada inmediatamente en la sección Cambiar Contraseña, " +
            //"de lo contrario se bloqueará el acceso al sistema.</p>" +
            //"<br /><br /><br />";

            var cuerpocorreo = InicioCorreo();

            cuerpocorreo += "<tr><td>Hola " + nombre.ToUpper() + "</strong></td></tr>" +
                "<tr><td>Ha sido agregado al sistema <strong>Gestión de Asuntos</strong> para llevar a cabo tareas de responsabilidad próximamente.</td></tr>" +
                "<tr><td>Le llegará un correo más adelante con un nuevo asunto para su atención, sus claves de acceso para acceso son las siguientes:</td></tr>" +
                "<tr><td>Correo de acceso: " + correoresponsable + "</td></tr>" +
                "<tr><td>Contraseña: " + Funciones.ClaveSalida() + "</td></tr>";

            cuerpocorreo += FinCorreo();
                
            return EnviarCorreo(correoresponsable, titulocorreo, "Nueva clave de acceso para Gestión de Asuntos", cuerpocorreo);
        }

        public bool EnviarCorreoBajaResponsable(string nombre, string correoresponsable, string titulocorreo, string idconfiguracion)
        {
            //var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>" +
            //"<p>Ha sido desasignado de la tarea de responsabilidad asignada en el sistema <strong>Gestión de Asuntos</strong>.</p>" +
            //"<p>Gracias por su atención. Si necesita revisar sus asignaciones, dé click en la siguiente liga para accesar:</p>" +
            //"<h4><a href='http://187.248.23.163:1052/'>Accesar Gestión de Asuntos</a></h4>" +
            //"<p>La contraseña debe ser cambiada por una personalizada inmediatamente en la sección Cambiar Contraseña, " +
            //"de lo contrario se bloqueará el acceso al sistema.</p>" +
            //"<br /><br /><br />";

            var cuerpocorreo = InicioCorreo();

            cuerpocorreo += "<tr><td>Hola " + nombre.ToUpper() + "</strong></td></tr>" +
            "<tr><td>&nbsp;</td></tr>" +
            "<tr><td>Se le ha desasignado de la tarea de responsabilidad asignada en el sistema <strong>Gestión de Asuntos</strong>.</td></tr>";

            cuerpocorreo += FinCorreo();

            return EnviarCorreo(correoresponsable, titulocorreo, "Desasignación de Responsabilidad Gestión de Asuntos", cuerpocorreo);
        }

        public bool EnviarCorreoModificacionResponsable(string nombre, string correoresponsable, string titulocorreo)
        {
            //var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>" +
            //"<p>Se ha modificado su acceso al sistema <strong>Gestión de Asuntos</strong> cambiando su correo anterior por uno nuevo, accese de nuevo el sistema para comprobarlo y continuar sus asignaciones.</p>" + 
            //"<h3>Nueva Clave de acceso: " + correoresponsable + "</h3>" +
            //"<h3>Contraseña: " + Funciones.ClaveSalida() + "</h3>" +
            //"<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
            //"<h4><a href='http://187.248.23.163:1052/'>Accesar Gestión de Asuntos</a></h4>" +
            //"<p>La contraseña debe ser cambiada por una personalizada inmediatamente en la sección Cambiar Contraseña, " +
            //"de lo contrario se bloqueará el acceso al sistema.</p>" +
            //"<br /><br /><br />";

            var cuerpocorreo = InicioCorreo();

            cuerpocorreo += "<tr><td>Hola " + nombre.ToUpper() + "</strong></td></tr>" +
            "<tr><td>&nbsp;</td></tr>" +
            "<tr><td>Se ha modificado su acceso al sistema <strong>Gestión de Asuntos</strong> cambiando su correo anterior por uno nuevo, accese de nuevo el sistema para comprobarlo y continuar sus asignaciones.</td></tr>" +
            "<tr><td>Nueva Clave de acceso: " + correoresponsable + "</td></tr>" +
            "<tr><td>Contraseña: " + Funciones.ClaveSalida() + "</td></tr>" +
            "<tr><td colspan='3' align='center' style='background-color:#FFFFFF; height: 40px;'>La contraseña debe ser cambiada por una personalizada inmediatamente en la sección Cambiar Contraseña, de lo contrario se bloqueará el acceso al sistema.</td></tr>";

            cuerpocorreo += FinCorreo();            
            
            return EnviarCorreo(correoresponsable, titulocorreo, "Nueva correo de acceso para Gestión de Asuntos", cuerpocorreo);
        }

        public bool EnviarCorreoEscalacion(string tituloasunto, string empresaasignada, string vencimiento, string correoresponsable, string titulocorreo, string idconfiguracion) 
        {
            //var cuerpocorreo = "<p>Hola</p>" + 
            //"<p>Se le ha asignado el siguiente asunto para su atención del sistema <strong>Gestión de Asuntos</strong>:</p>" +
            //"<h3>Asunto: " + tituloasunto + "</h3>" +
            //"<h3>Empresa: " + empresaasignada + "</h3>" +
            //"<h3>Vencimiento: " + vencimiento + "</h3>" +
            //"<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
            //"<h4><a href='http://187.248.23.163:1052/'>Accesar Gestión de Asuntos</a></h4>" +
            //"<br /><br /><br />";

            var cuerpocorreo = InicioCorreo();

            cuerpocorreo += "<tr><td>Se le ha asignado el siguiente asunto para su atención del sistema <strong>Gestión de Asuntos</strong>:</td></tr>" +
            "<tr><td>Asunto: " + tituloasunto + "</td></tr>" +
            "<tr><td>Empresa: " + empresaasignada + "</td></tr>" +
            "<tr><td>Vencimiento: " + vencimiento + "</td></tr>";

            cuerpocorreo += FinCorreo();

            return EnviarCorreo(correoresponsable, titulocorreo, "Escalación de Asunto", cuerpocorreo);
        }

        public bool EnviarCorreoAviso(string nombre, string tituloasunto, string empresaasignada, string vencimiento, string correoresponsable, string titulocorreo, string idconfiguracion) 
        {
            //var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>" + 
            //"<p>Se le ha asignado el siguiente asunto para su atención del sistema </strong>Gestión de Asuntos</strong>:</p>" + 
            //"<h3>Asunto: " + tituloasunto + "</h3>" +
            //"<h3>Empresa: " + empresaasignada + "</h3>" +
            //"<h3>Vencimiento: " + vencimiento + "</h3>" +
            //"<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
            //"<h4><a href='http://187.248.23.163:1052/'>Accesar Gestión de Asuntos</a></h4>" +
            //"<br /><br /><br />";

            var cuerpocorreo = InicioCorreo();

            cuerpocorreo += "<tr><td>Se le ha asignado el siguiente asunto para su atención del sistema <strong>Gestión de Asuntos</strong>:</td></tr>" +
            "<tr><td>Asunto: " + tituloasunto + "</td></tr>" +
            "<tr><td>Empresa: " + empresaasignada + "</td></tr>" +
            "<tr><td>Vencimiento: " + vencimiento + "</td></tr>";

            cuerpocorreo += FinCorreo();

            return EnviarCorreo(correoresponsable, titulocorreo, "Aviso de Seguimiento", cuerpocorreo);
        }

        public bool EnviarCorreoCambioFechaVencimiento(string nombre, string tituloasunto, string empresaasignada, string vencimiento, string correoresponsable, string titulocorreo)
        {
            //var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>" + 
            //"<p>Se le informa que ha cambiado la fecha de vencimiento del siguiente asunto del sistema <strong>Gestión de Asuntos</strong>:</p>" + 
            //"<h3>Asunto: " + tituloasunto + "</h3>" +
            //"<h3>Empresa: " + empresaasignada + "</h3>" +
            //"<h2>Vencimiento: " + vencimiento + "</h2>" +
            //"<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
            //"<h4><a href='http://187.248.23.163:1052/'>Accesar Gestión de Asuntos</a></h4>" +
            //"<br /><br /><br />";

            var cuerpocorreo = InicioCorreo();

            cuerpocorreo += "<tr><td>Hola " + nombre.ToUpper() + "</td></tr>" +
            "<tr><td>&nbsp;</td></tr>" +
            "<tr><td>Ha sido cambiada la fecha de vencimiento del siguiente asunto del sistema <strong>Gestión de Asuntos</strong> en el que esta asignado:</td></tr>" +
            "<tr><td>Asunto: " + tituloasunto + "</td></tr>" +
            "<tr><td>Empresa: " + empresaasignada + "</td></tr>" +
            "<tr><td>Vencimiento: " + vencimiento + "</td></tr>";

            cuerpocorreo += FinCorreo();

            return EnviarCorreo(correoresponsable, titulocorreo, "Cambio de fecha de vencimiento", cuerpocorreo);
        }

        public bool EnviarCorreoAsignadoAAsunto(string nombre, string tituloasunto, string empresaasignada, string vencimiento, string correoresponsable, string titulocorreo, string idconfiguracion) 
        {
            //var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>" + 
            //"<p>Ha sido asignado al sistema <strong>Gestión de Asuntos</strong> para atender lo siguiente:</p>" +
            //"<h3>Asunto: " + tituloasunto + " </h3>";
            //if (empresaasignada != "0")
            //    cuerpocorreo += "<h3>Empresa: " + empresaasignada + "</h3>";
            //cuerpocorreo += "<h3>Vencimiento: " + vencimiento + "</h3>" +
            //"<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
            //"<h4><a href='http://187.248.23.163:1052/'>Accesar Gestión de Asuntos</a></h4>" +
            //"<br /><br /><br />";

            var cuerpocorreo = InicioCorreo();
            
            cuerpocorreo += "<tr><td>Hola " + nombre.ToUpper() + "</td></tr>" +
            "<tr><td>&nbsp;</td></tr>" +
            "<tr><td>Se le ha asignado al sistema <strong>Gestión de Asuntos</strong> para atender lo siguiente:</td></tr>" +
            "<tr><td>Asunto: " + tituloasunto + "</td></tr>";
            if (empresaasignada != "0")
                cuerpocorreo += "<tr><td>Empresa: " + empresaasignada + "</td></tr>";
            cuerpocorreo += "<tr><td>Vencimiento: " + vencimiento + "</td></tr>";

                cuerpocorreo += FinCorreo();

            return EnviarCorreo(correoresponsable, titulocorreo, "Asignación de Responsabilidades", cuerpocorreo);
        }

        public bool EnviarCorreoRecuperacionContraseña(string correoaquienseenvia) 
        {
            var asunto = "Recuperación de Contraseña";

            //var mensaje = "<p>Su contraseña para accesar es<p>" +
            //"<h2>" + Funciones.ClaveSalida() + "</h2> " +
            //"<p>Cambiéla por una personalizada en cuanto accese la aplicación o se bloqueará de nuevo el acceso.</p>" +
            //"<p>Dé click en la siguiente liga para accesar la aplicación:</p>" +
            //"<h4><a href='http://187.248.23.163:1052/'>Accesar Gestión de Asuntos</a></h4>" +
            //"<br /><br /><br />";

            var mensaje = InicioCorreo();

            mensaje += "<tr><th colspan='3' align='center' style='height: 40px; line-height:30px'><h3>Recuperación de Contraseña</h3></th></tr>" +
            "<tr><td>&nbsp;</td></tr>" +
            "<tr><td>Su contraseña para accesar es</td></tr>" +
            "<tr><td>" + Funciones.ClaveSalida() + "</td></tr>" +
            "<tr><td>Cambiéla por una personalizada en cuanto accese la aplicación o se bloqueará de nuevo el acceso.</td></tr>";

            mensaje += FinCorreo();

            return EnviarCorreo(correoaquienseenvia, "Gestión de Asuntos", asunto, mensaje);

        }

        public bool EnviarCorreoAvisoAltaBitacoraAResponsable(string correoresponsable, string usuario, string nombreasunto, string detalleasunto)
        {
            //var asunto = "Alta de información en Bitácora por responsable";
            //var mensaje = "<p>El usuario " + usuario + " ha dejado nueva información en la bitácora para ser revisada.<p>" +
            //"<p>Asunto " + nombreasunto + "</p>" +
            //"<p>Nota de la bitácora: " + detalleasunto + "</p>" +
            //"<p>Dé click en la siguiente liga para poder accesarla:</p>" +
            //"<h4><a href='http://187.248.23.163:1052/'>http://187.248.23.163:1052/</a></h4>" +
            //"<br /><br /><br />";

            var mensaje = InicioCorreo();

            mensaje += LineasCorreo("El usuario <strong>" + usuario + "</strong> ha dejado nueva información en la bitácora para ser revisada sobre el asunto <strong>" + nombreasunto + "</strong>.");
            mensaje += LineasCorreo("Escribió: " + detalleasunto);

            mensaje += FinCorreo();

            return EnviarCorreo(correoresponsable, "Gestión de Asuntos", nombreasunto, mensaje);
        }

        public bool EnviarCorreoAvisoAltaBitacoraAExterno(string correoresponsable, string usuario, string nombreasunto, string detalleasunto)
        {
            //var asunto = "Alta de información en Bitácora por responsable";
            //var mensaje = "<p>El usuario " + usuario + " ha dejado nueva información en la bitácora para ser revisada.<p>" +
            //"<p>Asunto " + nombreasunto + "</p>" +
            //"<p>Nota de la bitácora: " + detalleasunto + "</p>" +
            //"<p>Dé click en la siguiente liga para poder accesarla:</p>" +
            //"<h4><a href='http://187.248.23.163:1052/'>http://187.248.23.163:1052/</a></h4>" +
            //"<br /><br /><br />";

            var mensaje = InicioCorreo();

            mensaje += LineasCorreo("<strong>" + usuario + "</strong> ha escrito sobre el asunto <strong>" + nombreasunto + "</strong>.");
            mensaje += LineasCorreo(detalleasunto);
            mensaje += LineasCorreo("<br /><br /><br />");

            return EnviarCorreo(correoresponsable, "Gestión de Asuntos", nombreasunto, mensaje);
        }

        //******************************* Armados para correos

        public string InicioCorreo()
        {
            return "<html>" +
            "<head>" +
            "<style>" +
            "body {font-family: Arial, Helvética, sans-serif } " +
            "a { text-decoration: none; color: blue } " +
            "a:hover {text-decoration: underline } " +
            "</style>" +
            "</head>" +
            "<body style='background-color: #FFFFFF'>" +
            "<table align='center' border='0' width='600' cellpadding='0' cellspacing='0' style='border-collapse: collapse;'>" +
            "<tr><th colspan='3' align='center' style='height: 40px; line-height:30px'><h2>Gestión de Asuntos</h2></th></tr>" +
            "<tr><td colspan='3' align='center' style='height: 40px; line-height:30px'>&nbsp;</td></tr>";
        }

        public string LineasCorreo(string texto)
        {
            return "<tr><td>" + texto + "</td></tr>";
        }

        public string FinCorreo()
        {
            return "<tr><td>&nbsp;</td></tr>" +
                "<tr><td style='height: 40px; padding: 3px'>" +
                "Para atender asuntos del sistema, dé click en la siguiente liga para accesar:<br />" +
                "<a href='http://187.248.23.163:1052/'>Accesar Gestión de Asuntos</a>" +
                "</td></tr>" +
                "</table>" +
                "</body>" +
                "</html>" +
                "<br /><br /><br />";
        }

        
    }
}
