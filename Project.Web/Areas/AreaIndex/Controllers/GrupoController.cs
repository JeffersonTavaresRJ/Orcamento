using Project.Entity;
using Project.Repository.Persistence;
using System.Web.Mvc;
using Project.Web.Areas.AreaIndex.Models;
using System.Collections.Generic;
using X.PagedList;
using X.PagedList.Mvc;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class GrupoController : Controller
    {
        // GET: AreaIndex/Grupo
        public ActionResult ManutencaoGrupo( int pagina = 1)
        {
            GrupoPersistence gp = new GrupoPersistence();
            var lista = gp.ListarTodosGrupos().ToPagedList(pagina, 3);
            return View(lista);
        }

        [HttpPost]
        public JsonResult Consultar()
        {
            GrupoPersistence gp = new GrupoPersistence();
            var lista = gp.ListarTodos();
            var Resultado = new
            {
                aaData = lista
            };

            return Json(Resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //este método é chamado através de um beginForm..
        public ActionResult IncluirGrupo(string DescricaoGrupo)
        {
            GrupoPersistence gp = new GrupoPersistence();
            if (DescricaoGrupo.Trim() != null)
            {
                try
                {                   
                    Grupo g = new Grupo();
                    g.Descricao = DescricaoGrupo;
                    gp.Inserir(g);
                    ViewBag.MsgGrupo = "O grupo " + DescricaoGrupo + " foi gravado com sucesso!";

                }
                catch (System.Exception e)
                {
                    ViewBag.MsgGrupo = "Erro: " + e.Message.ToString();
                }
            }
            var lista = gp.ListarTodosGrupos().ToPagedList(1, 3);
            return View("ManutencaoGrupo", lista);
        }

        [HttpPost]
        public JsonResult ExcluirGrupo(int Id)
        {
            try
            {
                GrupoPersistence gp = new GrupoPersistence();
                Grupo g = gp.ObterPorId(Id);
                gp.Excluir(g);

                //falta fazer o tratamento da saída da mensagem via json..
                ViewBag.MsgGrupo = "O grupo " + g.Descricao + " foi excluído com sucesso!";
            }
            catch (System.Exception e)
            {
                //falta fazer o tratamento da saída da mensagem via json..
                ViewBag.MsgGrupo = "Erro: " + e.ToString();
            }

            return Json("");
        }
    }
}