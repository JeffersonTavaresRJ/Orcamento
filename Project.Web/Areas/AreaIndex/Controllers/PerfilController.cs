using Project.Repository.Persistence;
using Project.Web.Areas.AreaIndex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project.Entity;
using PagedList;

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
            PerfilMenuViewModelConsulta model = new PerfilMenuViewModelConsulta();
            ListarMenus(model);
            return View(model);
        }


        [HttpPost]
        public ActionResult Inclusao(PerfilMenuViewModelInclusao model)
        {
            try
            {
                if (model.NomePerfil == null)
                {
                   throw new Exception("O nome do perfil deve ser informado");
                }

                if (model.IdMenus == null)
                {
                    throw new Exception("Pelo menos um item de menu deverá ser selecionado");
                }

                PerfilPersistence pp = new PerfilPersistence();

                if (pp.ObterPorDescricao(model.NomePerfil).Count() > 0)
                {
                    throw new Exception("Este perfil já existe");
                }

                MenuPersistence mp = new MenuPersistence();
                Perfil p = new Perfil();

                p.Menus = new List<Menu>();

                foreach (var item in model.IdMenus)
                {
                    Menu m = new Menu();
                    m = mp.ObterMenuPorId(item);
                    p.Menus.Add(m);
                }

                p.Descricao = model.NomePerfil;

                pp.Inserir(p);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            return Json("Perfil cadastrado com sucesso", JsonRequestBehavior.AllowGet);
        }

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

        private void ListarMenus(PerfilMenuViewModelConsulta model)
        {
            MenuPersistence mp = new MenuPersistence();
            List<MenuViewModelSelecionaEdicao> lista = new List<MenuViewModelSelecionaEdicao>();

            IEnumerable<Menu> menus = mp.ListarMenu(new Menu() { IdMenu = 0 }, "nome");

            foreach (var item in menus)
            {
                if (item.IdMenu > 0)
                {
                    MenuViewModelSelecionaEdicao menu = new MenuViewModelSelecionaEdicao();
                    menu.Id = item.Id;
                    string descricaoMenu = null;
                    int? IdMenuAnt = item.IdMenu;

                    while (IdMenuAnt > 0)
                    {
                        if (descricaoMenu == null)
                        {
                            descricaoMenu = item.Nome;
                        }
                        Menu m = mp.ObterMenuPorId(IdMenuAnt);
                        descricaoMenu = m.Nome + " >> " + descricaoMenu;
                        IdMenuAnt = m.IdMenu;
                    }
                    menu.Descricao = descricaoMenu;

                    model.Menus.Add(menu);
                }
            }


        }
    }
}