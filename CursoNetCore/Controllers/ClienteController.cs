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
            }
        }

        public ActionResult Agregar()
        {
            llenarSexo();
            ViewBag.lista = ListaSexo;
            return View();
        }
    }
}