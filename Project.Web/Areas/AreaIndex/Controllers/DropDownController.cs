using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Entity;
using Project.Entity.Enuns;
using Project.Repository.Persistence;
using Project.Utility.UtilComboBox;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class DropDownController : Controller
    {
        // GET: AreaIndex/Status
        public ActionResult Status()
        {
            ViewBag.ListaStatus = Combobox.Listar(typeof(Status));
            return View();
        }

        // GET: Perfil
        public ActionResult Perfil()
        {
            PerfilPersistence pp = new PerfilPersistence();
            ViewBag.ListaPerfis = pp.ListarTodos();
            return View();
        }

    }
}