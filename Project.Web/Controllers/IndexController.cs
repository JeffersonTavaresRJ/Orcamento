using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Consulta()
        {
            return View();
        }
    }
}