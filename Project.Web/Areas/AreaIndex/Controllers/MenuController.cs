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

        [Authorize]
        public ActionResult PopularMenu(ICollection<Menu> menus)
        {
            return PartialView("_menu", menus);
        }

        
    }
}