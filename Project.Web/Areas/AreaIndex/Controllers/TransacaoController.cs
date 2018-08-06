using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    [Authorize]
    public class TransacaoController : Controller
    {
        // GET: AreaIndex/Transacao
        public ActionResult ManutencaoTransacao()
        {
            return View();
        }
    }
}