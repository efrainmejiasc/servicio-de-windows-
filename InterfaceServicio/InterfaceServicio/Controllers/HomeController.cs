using InterfaceServicio.Engine;
using InterfaceServicio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterfaceServicio.Controllers
{
    public class HomeController : Controller
    {
        private IEngineInterface Funcion;

        public HomeController(IEngineInterface _Funcion)
        {
            this.Funcion = _Funcion;
        }


        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult SendParameters(string descripcion, double cantidad)
        {
            TestService model = Funcion.ConstruirTestService(descripcion, cantidad);
            string json = JsonConvert.SerializeObject(model);
            bool resultado = Funcion.SendInformacionSocket(json);
            Response response = new Response();
            if (resultado)
            {
                response.Respuesta = "Transaccion Exitosa";
            }
            else
            {
                response.Respuesta = "Transaccion Fallida";
            }

            return Json(response);
        }

    }
}