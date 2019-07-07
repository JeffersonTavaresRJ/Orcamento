using Project.Entity;
using Project.Repository.Persistence;
using System.Web.Mvc;
using Project.Web.Areas.AreaIndex.Models;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class GrupoController : Controller
    {
        string mensagem = null;

        // GET: AreaIndex/Grupo
        public ActionResult ManutencaoGrupo( int pagina = 1)
        {
            GrupoPersistence gp = new GrupoPersistence();
            //var lista = gp.ListarTodosGrupos().ToPagedList(pagina, 3);
            var lista = gp.ListarTodosGrupos();
            return View(lista);
        }

        public ActionResult Inclusao()
        {
            try
            {
                GrupoPersistence gp = new GrupoPersistence();
                ViewBag.ListaGrupos = new SelectList(gp.ListarGruposNivel_1(), "Id", "Descricao");
            }
            catch (System.Exception ex)
            {
                ViewBag.Mensagem = "Erro: " + ex.Message;
            }

            return View();
        }

        public ActionResult Edicao(int id)
        {
            GrupoViewModelEdicao grupoModel = new GrupoViewModelEdicao();
            try
            {
                GrupoPersistence gp = new GrupoPersistence();
                ViewBag.ListaGrupos = new SelectList(gp.ListarGruposNivel_1(), "Id", "Descricao");
                Grupo g = gp.ObterPorId(id);

                grupoModel.Id = id;
                grupoModel.Id_Grupo = g.IdGrupo;
                grupoModel.Descricao = g.Descricao;

            }
            catch (System.Exception ex)
            {

                ViewBag.Mensagem = "Erro: " + ex.Message;
            }
            return View(grupoModel);
        }

        [HttpPost]
        public JsonResult Incluir(GrupoViewModel grupoModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GrupoPersistence gp = new GrupoPersistence();
                    Grupo g = new Grupo();

                    g.IdGrupo = grupoModel.Id_Grupo;
                    g.Descricao = grupoModel.Descricao;

                    gp.Inserir(g);

                    mensagem = "Grupo " + g.Descricao + " incluído com sucesso!";
                }
                catch (System.Exception ex)
                {
                    mensagem = "Erro: " + ex.Message;
                }
            }
            return Json(new { msg = mensagem });
        }

        [HttpPost]
        public JsonResult Editar(GrupoViewModelEdicao grupoModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GrupoPersistence gp = new GrupoPersistence();
                    //obtém o grupo para alterá-lo
                    Grupo g = gp.ObterPorId(grupoModel.Id);

                    //edito as informações
                    g.IdGrupo = grupoModel.Id_Grupo;
                    g.Descricao = grupoModel.Descricao;

                    //salvo no mesma variável de persistência
                    gp.Atualizar(g);
                    mensagem = "O grupo " + g.Descricao + " foi editado com sucesso";
                }
                catch (System.Exception ex)
                {

                    mensagem = "Erro: "+ ex.Message;
                }
            }

            return Json(new { msg = mensagem });
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
        public JsonResult Excluir(int Id)
        {
            try
            {
                GrupoPersistence gp = new GrupoPersistence();
                Grupo g = gp.ObterPorId(Id);
                gp.Excluir(g);

                mensagem = "O grupo " + g.Descricao + " foi excluído com sucesso!";
            }
            catch (System.Exception e)
            {
                mensagem = "Erro: " + e.ToString();
            }

            return Json(new { msg=mensagem });
        }
    }
}