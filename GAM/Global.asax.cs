using GAM.Controllers;
using Microsoft.Ajax.Utilities;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GAM
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();
            HttpException httpexception = new HttpException();
            string accion = "";
            if (httpexception.GetHttpCode() == 404)
            {
                accion = "NotFound";
            }
            else if (httpexception.GetHttpCode() == 500)
            {
                accion = "NotFunction";
            }
            else
            {
                accion = "Index";
            }
            Context.ClearError();
            RouteData rutaerror = new RouteData();
            rutaerror.Values.Add("controller", "Error");
            rutaerror.Values.Add("action",accion);
            IController controlador = new ErrorController();
            controlador.Execute(new RequestContext(new HttpContextWrapper(Context),rutaerror));
        }
      
    }
}
