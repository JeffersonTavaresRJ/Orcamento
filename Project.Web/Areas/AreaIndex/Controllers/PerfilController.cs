using Project.Repository.Persistence;
using Project.Web.Areas.AreaIndex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class PerfilController : Controller
    {
        [HttpPost]
        public JsonResult ListarPerfil()
        {
            PerfilPersistence pp = new PerfilPersistence();

            List<PerfilViewModelConsulta> lista = new List<PerfilViewModelConsulta>();

            foreach (var item in pp.ListarTodos().ToList())
            {
                PerfilViewModelConsulta p = new PerfilViewModelConsulta();
                p.Id = item.Id;
                p.Descricao = item.Descricao;
                lista.Add(p);
            }

            return Json(lista);
        }
    }
}