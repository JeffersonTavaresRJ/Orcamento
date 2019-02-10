using Project.Entity;
using Project.Repository.Persistence;
using System.Web.Mvc;
using Project.Web.Areas.AreaIndex.Models;
using System.Collections.Generic;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class GrupoController : Controller
    {
        // GET: AreaIndex/Grupo
        public ActionResult ManutencaoGrupo()
        {
            return View();
        }

        public ActionResult TabelaGrupos( int pagina = 1)
        {
            GrupoPersistence gp = new GrupoPersistence();
            List<GrupoViewModelConsulta> lista = new List<GrupoViewModelConsulta>();

            foreach (var item in gp.ListarTodosGrupos())
            {
                GrupoViewModelConsulta model = new GrupoViewModelConsulta();
                model.Id = item.Id;
                model.Descricao = item.Descricao;
                lista.Add(model);
            }
            return View(lista);
        }

        [HttpPost]
        public ActionResult IncluirGrupo(GrupoViewModelInclusao Model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GrupoPersistence gp = new GrupoPersistence();
                    Grupo g = new Grupo();
                    g.Descricao = Model.NomeGrupo;
                    gp.Inserir(g);
                    ViewBag.MsgGrupo = "O grupo " + Model.NomeGrupo + " foi gravado com sucesso!";

                }
                catch (System.Exception e)
                {
                    ViewBag.MsgGrupo = "Erro: " + e.Message.ToString();
                }
            }
            return View("ManutencaoGrupo");
        }

        [HttpPost]
        public JsonResult ExcluirGrupo(int Id)
        {
            try
            {
                GrupoPersistence gp = new GrupoPersistence();
                Grupo g = gp.ObterPorId(Id);
                gp.Excluir(g);
                ViewBag.MsgGrupo = "O grupo " + g.Descricao + " foi excluído com sucesso!";
            }
            catch (System.Exception e)
            {
                ViewBag.MsgGrupo = "Erro: " + e.ToString();
            }

            return Json("");
        }
    }
}