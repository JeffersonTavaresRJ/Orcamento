using Project.Entity;
using Project.Repository.Persistence;
using System.Collections.Generic;
using System.Web.Mvc;
using Project.Web.Areas.AreaIndex.Models;
namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class GrupoController : Controller
    {
        // GET: AreaIndex/Grupo
        public ActionResult ManutencaoGrupo()
        {
            GrupoPersistence gp = new GrupoPersistence();
            ViewBag.Grupos = gp.ListarTodos();
            return View();
        }
    }
}