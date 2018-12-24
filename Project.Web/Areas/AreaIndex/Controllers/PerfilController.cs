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
            PerfilMenuViewModelInclusao perfil = new PerfilMenuViewModelInclusao();
            ListarMenus(perfil);
            return View(perfil);
        }

        public ActionResult InclusaoPagedList(int? pagina)
        {
            PerfilMenuViewModelInclusao model = new PerfilMenuViewModelInclusao();

            MenuPersistence mp = new MenuPersistence();
            List<MenuViewModelSelecionaEdicao> lista = new List<MenuViewModelSelecionaEdicao>();

            int numeroPagina = pagina ?? 1;

            foreach (var item in mp.ListarTableMenus())
            {
                MenuViewModelSelecionaEdicao menu = new MenuViewModelSelecionaEdicao();
                menu.Id = item.Id;
                menu.IdMenu = item.IdMenu;
                menu.Descricao = item.Nome;
                lista.Add(menu);
            }

          //  model.Menus = lista.ToPagedList(numeroPagina, 3);            
            return View(model);
        }

        [HttpPost]
        public ActionResult Inclusao(PerfilMenuViewModelInclusao model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PerfilPersistence pp = new PerfilPersistence();
                    MenuPersistence mp = new MenuPersistence();

                    Perfil p = new Perfil();
                    p.Menus = new List<Menu>();

                    p.Descricao = model.NomePerfil;
                    foreach (int id in model.getSelectedIds())
                    {
                        Menu m = mp.ObterMenuPorId(id);
                        p.Menus.Add(m);
                    }

                    pp.Inserir(p);
                }
                catch (Exception ex)
                {
                    Json(ex.Message);
                }

            }
            return View(model);
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

        private void ListarMenus(PerfilMenuViewModelInclusao model)
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
                    menu.IdMenu = item.IdMenu;

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
                    menu.Selecionado = false;
                    model.Menus.Add(menu);
                }
            }


        }
    }
}