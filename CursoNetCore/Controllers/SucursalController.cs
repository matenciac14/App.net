using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoNetCore.Models;


namespace CursoNetCore.Controllers
{
    public class SucursalController : Controller
    {       
        // GET: Sucursal
        public ActionResult Index()
        {
            List<SucursalCLS> ListaSucursal = null;
            using (var bd = new BDPasajeEntities())
            {
                ListaSucursal = (from sucursal in bd.Sucursal
                                 where sucursal.BHABILITADO ==1
                                 select new SucursalCLS
                                 {
                                     iidsucursal = sucursal.IIDSUCURSAL,
                                     nombre = sucursal.NOMBRE,
                                     telefono = sucursal.TELEFONO,
                                     direccion = sucursal.DIRECCION,
                                     email = sucursal.EMAIL
                                 }
                                 ).ToList();

            }
                return View(ListaSucursal);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(SucursalCLS oSucursalCLS)
        {
            if (!ModelState.IsValid) {
                return View(oSucursalCLS);
            }
            else
            {
                using(var bd = new BDPasajeEntities())
                {
                    Sucursal oSucursal = new Sucursal();
                    oSucursal.NOMBRE = oSucursalCLS.nombre;
                    oSucursal.DIRECCION = oSucursalCLS.direccion;
                    oSucursal.TELEFONO = oSucursalCLS.telefono;
                    oSucursal.EMAIL = oSucursalCLS.email;
                    oSucursal.FECHAAPERTURA = oSucursalCLS.fechaapertura;
                    oSucursal.BHABILITADO = 1;
                    bd.Sucursal.Add(oSucursal);
                    bd.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}