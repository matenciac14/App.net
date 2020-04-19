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
                                     email = sucursal.EMAIL
                                 }
                                 ).ToList();

            }
                return View(ListaSucursal);
        }
    }
}