using Project.Repository.Persistence;
using Project.Web.Areas.AreaIndex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Entity;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {

        public ActionResult ManutencaoPerfil()
        {
            return View();
        }

        public ActionResult Inclusao()
        {
            ViewBag.Titulo = "Incluir Perfil";
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(PerfilViewModelInclusao model)
        {
                try
                {
                    PerfilPersistence pp = new PerfilPersistence(false);
                    Perfil p = new Perfil();

                    p.Descricao = model.Descricao;
                    p.Menus = new List<Menu>();

                    pp.Inserir(p);
                }
                catch (Exception ex)
                {
                    Json(ex.Message);
                }

            return Json("");
        }


        [HttpPost]
        public JsonResult ListarPerfil()
        {
            PerfilPersistence pp = new PerfilPersistence(false);

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