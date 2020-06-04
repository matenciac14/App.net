using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoNetCore.Models;

namespace CursoNetCore.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoCLS> ListaEmpleado = null;
            using (var bd = new BDPasajeEntities()) {
                ListaEmpleado = (from empleado in bd.Empleado
                                 join tipousuario in bd.TipoUsuario
                                 on empleado.IIDTIPOUSUARIO equals tipousuario.IIDTIPOUSUARIO
                                 join tipocontrato in bd.TipoContrato
                                 on empleado.IIDTIPOCONTRATO equals tipocontrato.IIDTIPOCONTRATO

                                 select new EmpleadoCLS
                                 {
                                     iidempleado = empleado.IIDEMPLEADO,
                                     nombre = empleado.NOMBRE,
                                     appaterno = empleado.APPATERNO,
                                     apmaterno = empleado.APMATERNO,
                                     nombreTipoContrato = tipocontrato.NOMBRE,
                                     nombretipoUsuario = tipousuario.NOMBRE
                                 }).ToList();
            }
            return View();
        }
    }
}