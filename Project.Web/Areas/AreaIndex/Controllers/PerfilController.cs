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
            PerfilViewModelInclusao perfis = new PerfilViewModelInclusao();
            perfis.Menus = ListarMenus();
            return View(perfis);
        }

        [HttpPost]
        public JsonResult Incluir(PerfilViewModelInclusao model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PerfilPersistence pp = new PerfilPersistence();
                    MenuPersistence mp = new MenuPersistence();
                    Perfil p = new Perfil();
                    List<Menu> lista = new List<Menu>();

                    p.Descricao = model.Descricao;

                    foreach (var item in model.Menus)
                    {
                        if (item.Checked)
                        {
                            Menu m = mp.ObterMenuPorId(item.Id);
                            lista.Add(m);
                        }

                    }

                    p.Menus = lista;
                    pp.Inserir(p);
                }
                catch (Exception ex)
                {
                    Json(ex.Message);
                }
               
            }
            return Json("");
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

        private List<MenuViewModelConsulta> ListarMenus()
        {
            MenuPersistence mp = new MenuPersistence();
            List<MenuViewModelConsulta> lista = new List<MenuViewModelConsulta>();

            IEnumerable<Menu> menus = mp.ListarMenu(new Menu() { IdMenu = 0 }, "nome");

            foreach (var item in menus)
            {
                if (item.IdMenu > 0)
                {
                    MenuViewModelConsulta menu = new MenuViewModelConsulta();
                    menu.Id = item.Id;
                    menu.IdMenu = item.IdMenu;

                    string nomeMenu = null;
                    int? IdMenuAnt = item.IdMenu;

                    while (IdMenuAnt > 0)
                    {
                        if (nomeMenu == null)
                        {
                            nomeMenu = item.Nome;
                        }
                        Menu m = mp.ObterMenuPorId(IdMenuAnt);
                        nomeMenu = m.Nome + " >> " + nomeMenu;
                        IdMenuAnt = m.IdMenu;
                    }
                    menu.Nome = nomeMenu;
                    lista.Add(menu);
                }
            }

            return lista;
        }
    }
}