using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoNetCore.Models;

namespace CursoNetCore.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteCLS> ListaCliente = null;
            using(var bd = new BDPasajeEntities())
            {
                ListaCliente = (from cliente in bd.Cliente
                                where cliente.BHABILITADO == 1
                                select new ClienteCLS
                                {
                                    iidcliente = cliente.IIDCLIENTE,
                                    nombre = cliente.NOMBRE,
                                    appaterno = cliente.APPATERNO,
                                    apmaterno = cliente.APMATERNO,
                                    email = cliente.EMAIL
                                }
                    ).ToList();
            }
            return View(ListaCliente);
        }
        List<SelectListItem> ListaSexo;
        private void llenarSexo()
        {
            using(var bd = new BDPasajeEntities())
            {
                ListaSexo = (from sexo in bd.Sexo
                             where sexo.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = sexo.NOMBRE,
                                 Value = sexo.IIDSEXO.ToString()
                             }
                    ).ToList();
                ListaSexo.Insert(0, new SelectListItem { Text = "-- Seleccione --", Value = "" });
            }
        }

        public ActionResult Agregar()
        {
            llenarSexo();
            ViewBag.lista = ListaSexo;
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ClienteCLS oClienteCLS)
        {
            if (!ModelState.IsValid)
            {
                llenarSexo();
                ViewBag.lista = ListaSexo;
                return View(oClienteCLS);
            }
            using(var bd = new BDPasajeEntities())
            {
                Cliente oCliente = new Cliente();
                oCliente.NOMBRE = oClienteCLS.nombre;
                oCliente.APMATERNO = oClienteCLS.appaterno;
                oCliente.APMATERNO = oClienteCLS.apmaterno;
                oCliente.EMAIL = oClienteCLS.email;
                oCliente.DIRECCION = oClienteCLS.direccion;
                oCliente.IIDSEXO = oClienteCLS.iidsexo;
                oCliente.TELEFONOCELULAR = oCliente.TELEFONOCELULAR;
                oCliente.BHABILITADO = 1;
                bd.Cliente.Add(oCliente);
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}