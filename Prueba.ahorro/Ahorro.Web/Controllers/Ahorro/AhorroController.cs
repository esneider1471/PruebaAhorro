using Entidades.Barrios;
using Entidades.Resultados;
using Entidades.Socios;
using Logica.Barrios;
using Logica.Socios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ahorro.Web.Controllers.Ahorro
{
    public class AhorroController : Controller
    {
        // GET: Ahorro
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CrearBarrio(string objBarrio)
        {
            ResultadosEnt Respuesta = new ResultadosEnt();
            BarriosEnt barriosEnt = new BarriosEnt();
            BarriosLog barriosLog = new BarriosLog();
            barriosEnt = JsonConvert.DeserializeObject<BarriosEnt>(objBarrio);
            Respuesta = barriosLog.CrearBarrio(barriosEnt);
            return Json(Respuesta, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ListarBarrios()
        {
            List<BarriosEnt> listBarrios = new List<BarriosEnt>();
            BarriosLog barriosLog = new BarriosLog();
            listBarrios = barriosLog.ListarBarrios();
            return Json(listBarrios, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ListarSocios()
        {
            List<SociosEnt> sociosEnts = new List<SociosEnt>();
            SociosLog sociosLog = new SociosLog();
            sociosEnts = sociosLog.ListarSocios();
            return Json(sociosEnts, JsonRequestBehavior.AllowGet);
            
        }

        public JsonResult CrearSocio(string objSocio)
        {
            ResultadosEnt resultadosEnt = new ResultadosEnt();
            SociosEnt sociosEnt = new SociosEnt();
            SociosLog sociosLog = new SociosLog();
            sociosEnt = JsonConvert.DeserializeObject<SociosEnt>(objSocio);
            resultadosEnt = sociosLog.InsertarSocio(sociosEnt);
            return Json(resultadosEnt, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ActualizarSocio(string objSocio)
        {
            ResultadosEnt resultadosEnt = new ResultadosEnt();
            SociosEnt sociosEnt = new SociosEnt();
            SociosLog sociosLog = new SociosLog();
            sociosEnt = JsonConvert.DeserializeObject<SociosEnt>(objSocio);
            resultadosEnt = sociosLog.ActualizarSocio(sociosEnt);
            return Json(resultadosEnt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarSocio(string objSocio)
        {
            ResultadosEnt resultadosEnt = new ResultadosEnt();
            SociosEnt sociosEnt = new SociosEnt();
            SociosLog sociosLog = new SociosLog();
            sociosEnt = JsonConvert.DeserializeObject<SociosEnt>(objSocio);
            resultadosEnt = sociosLog.EliminarSocio(sociosEnt);
            return Json(resultadosEnt, JsonRequestBehavior.AllowGet);
        }
    }
}