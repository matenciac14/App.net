using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Curso.net.Models;

namespace Curso.net.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            List<SucursalCLS> ListaSucursal = null;
            using(var bd = new BDPasajeEntities)
            {
                ListaSucursal 

            }
            return View();
        }
    }
}