using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Curso.net.Models;
namespace Curso.net.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            List<MarcaCLS> ListaMarca = null;
            using (var bd = new BDPasajeEntities())
            {
                ListaMarca = (from marca in bd.Marca
                                             select new MarcaCLS
                                             {
                                                 iidmarca = marca.IIDMARCA,
                                                 nombre = marca.NOMBRE,
                                                 descripcion = marca.DESCRIPCION
                                             }).ToList();

            }
            return View(ListaMarca);
        }
    }
}