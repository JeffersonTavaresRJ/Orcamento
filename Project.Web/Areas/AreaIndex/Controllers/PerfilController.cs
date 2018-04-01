using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Repository.Persistence;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult DropDownPerfil()
        {
            PerfilPersistence pp = new PerfilPersistence();
            ViewBag.ListaPerfis = pp.ListarTodos();
            return View();
        }
    }
}