using System.Collections.Generic;
using System.Web.Mvc;
using Project.Entity;
using Project.Repository.Persistence;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class MenuController : Controller
    {
        [Authorize]
        public ActionResult PopularMenu(ICollection<Menu> menus)
        {
            return PartialView("_menu", menus);
        }
    }
}