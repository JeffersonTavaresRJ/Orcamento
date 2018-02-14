using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    [Authorize]
    public class LancamentoController : Controller
    {
        // GET: AreaIndex/Lancamento
        public ActionResult Consulta()
        {
            return View();
        }
    }
}