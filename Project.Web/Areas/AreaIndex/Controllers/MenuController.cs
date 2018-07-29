using System.Collections.Generic;
using System.Web.Mvc;
using Project.Entity;
using Project.Repository.Persistence;
using Project.Web.Areas.AreaIndex.Models;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult ManutencaoMenu()
        {
            MenuPersistence mp = new MenuPersistence();
            List<MenuViewModelConsulta> lista = new List<MenuViewModelConsulta>();

            foreach (var item in mp.ListarTodos())
            {
                if (item.IdMenu >0) {
                    MenuViewModelConsulta menu = new MenuViewModelConsulta();
                    menu.Id = item.Id;
                    menu.IdMenu = item.IdMenu;
                    menu.Nome = item.Nome;
                    lista.Add(menu);
                }
            }
            return PartialView(lista);
        }

        [Authorize]
        public ActionResult PopularMenu(ICollection<Menu> menus)
        {
            return PartialView("_menu", menus);
        }

        
    }
}