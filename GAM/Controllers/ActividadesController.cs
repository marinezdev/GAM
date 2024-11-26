using GAM.Models.Models;
using GAM.Utilerias;
using System.Web.Mvc;

namespace GAM.Controllers
{
    [SessionTimeOut]
    [HandleError]
    public class ActividadesController : Utilerias.Comun
    {
        /// <summary>
        /// Agrega una nueva actividad
        /// </summary>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Agregar(string Nombre)
        {
            Actividades items = new Actividades();
            items.Nombre = Nombre;

            if (n.actividades.Agregar_Registro(items))
            {
                ViewBag.Mensaje = "Agregado";
            }
            else
                ViewBag.Mensaje = "Fallo al agregar, revise sus datos.";
            return View("Index");
        }

        /// <summary>
        /// Agrega una nueva actividad
        /// </summary>
        /// <param name="eNombre"></param>
        /// <returns></returns>
        public JsonResult AgregarActividad(string eNombre)
        {
            Actividades item = new Actividades();
            item.Nombre = eNombre;
            return Json(n.actividades.Agregar_Seleccionar(item), JsonRequestBehavior.AllowGet);
        }
    }
}
