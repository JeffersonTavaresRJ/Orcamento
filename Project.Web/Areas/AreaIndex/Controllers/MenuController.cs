using System.Collections.Generic;
using System.Web.Mvc;
using Project.Entity;
using Project.Repository.Persistence;
using Project.Web.Areas.AreaIndex.Models;
using System.Linq;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {

        public ActionResult PopularMenu(ICollection<Menu> menus)
        {
            return PartialView("_menu", menus);
        }

    }
}