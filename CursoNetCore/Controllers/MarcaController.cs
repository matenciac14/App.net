using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoNetCore.Models;

namespace CursoNetCore.Controllers
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
                              where marca.BHABILITADO == 1
                              select new MarcaCLS
                              {
                                  iidmarca = marca.IIDMARCA,
                                  nombre = marca.NOMBRE,
                                  descripcion = marca.DESCRIPCION
                              }).ToList();

            }
            return View(ListaMarca);
        }
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(MarcaCLS oMarcaCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(oMarcaCLS);
            }
            else
            {
                using(var bd = new BDPasajeEntities())
                {
                    Marca oMarca = new Marca();
                    oMarca.NOMBRE = oMarcaCLS.nombre;
                    oMarca.DESCRIPCION = oMarcaCLS.descripcion;
                    oMarca.BHABILITADO = 1;
                    bd.Marca.Add(oMarca);
                    bd.SaveChanges();
                }
               
            }
            return RedirectToAction("Index");
        }
    }
}