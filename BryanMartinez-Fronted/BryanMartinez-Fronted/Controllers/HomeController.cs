using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace BryanMartinez_Fronted.Controllers
{
    public class HomeController : Controller
    {

        NuevoLogica logica = new NuevoLogica();
        RegistrosLogic logica2 = new RegistrosLogic();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult EjecutarApi_NuevoRegistro(string id, DateTime fecha)
        {
            bool respuesta = logica.NuevoDato(id, fecha);
            if (respuesta)
            
                return Json(new { ok = true, mensaje = "Registrado correctamente" }, JsonRequestBehavior.AllowGet);
            
            return Json( new { ok = false, mensaje = "Error al registrar" },JsonRequestBehavior.AllowGet);
        }


        public PartialViewResult ListaDatos(string ids)
        {
            ViewBag.resultados = logica2.ListaRegistros(ids);
            return PartialView("_ListaDatos");
        }

    }
}