using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Entity.Enuns;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class StatusController : Controller
    {
        // GET: AreaIndex/Status
        public ActionResult DropDownStatus()
        {
            List<ObjStatus> lista = new List<ObjStatus>();
            foreach (string item in Enum.GetValues(typeof(Status)))
            {
                ObjStatus status = new ObjStatus();
                status.IdStatus = item;
                status.Descricao = Enum.GetName(typeof(Status), item);

                lista.Add(status);
            }
            ViewBag.ListaStatus = lista.OrderBy(s=>s.IdStatus);
            return View();
        }
    }

    public class ObjStatus
    {
        public string IdStatus { get; set; }
        public string Descricao { get; set; }
    }
}