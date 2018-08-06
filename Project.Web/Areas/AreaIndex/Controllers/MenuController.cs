using System.Collections.Generic;
using System.Web.Mvc;
using Project.Entity;
using Project.Repository.Persistence;
using Project.Web.Areas.AreaIndex.Models;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        public ActionResult ManutencaoMenu()
        {
            MenuPersistence mp = new MenuPersistence(true);
            List<MenuViewModelConsulta> lista = new List<MenuViewModelConsulta>();

            IEnumerable<Menu> menus = mp.ListarMenu(new Menu() {IdMenu = 0}, "nome");
            

            foreach (var item in menus)
            {
                if (item.IdMenu >0) {
                    MenuViewModelConsulta menu = new MenuViewModelConsulta();
                    menu.Id = item.Id;
                    menu.IdMenu = item.IdMenu;

                    string nomeMenu = null;
                    int? IdMenuAnt = item.IdMenu;

                    while( IdMenuAnt > 0)
                    {
                        if(nomeMenu == null)
                        {
                            nomeMenu = item.Nome;
                        }
                        Menu m    = mp.ObterMenuPorId(IdMenuAnt);
                        nomeMenu  = m.Nome + " >> " + nomeMenu;
                        IdMenuAnt = m.IdMenu;
                    }
                    menu.Nome = nomeMenu;
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