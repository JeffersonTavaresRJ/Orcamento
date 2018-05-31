using System.Collections.Generic;
using System.Web.Mvc;
using Project.Entity;
using Project.Repository.Persistence;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class MenuController : Controller
    {
        // GET: AreaIndex/Menu
        public ActionResult ConsultaFiltro()
        {
           List<Menu> lista = new List<Menu>();

            MenuPersistence mp = new MenuPersistence();

            lista = mp.ListarTodos();

            return View(lista);
        }

        //[HttpPost]
        //public JsonResult PopulaMenu(Perfil perfil)
        //{
        //    List<Menu> lista = new List<Menu>();
        //    MenuPersistence mp = new MenuPersistence();

        //    lista = mp.ObterItensMenus(perfil);
        //    return Json(lista);
        //}
    }
}