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
        public JsonResult Consultar()
        {
            List<MenuPerfilViewModelConsulta> listaModel = new List<MenuPerfilViewModelConsulta>();
            try
            {
                string sPerfil = Request.Params["sPerfil"].ToString();

                if (!sPerfil.Trim().Equals("") && !sPerfil.Equals("-1"))
                {
                    PerfilPersistence pp = new PerfilPersistence();
                    Perfil p = pp.ObterPorId(Convert.ToInt32(sPerfil));

                    MenuPersistence mp = new MenuPersistence();
                    List<Menu> listaMenu = mp.ListarTableMenus();

                    foreach (var item in listaMenu)
                    {
                        MenuPerfilViewModelConsulta model = new MenuPerfilViewModelConsulta();
                        model.IdPerfil = p.Id;
                        model.IdMenu = item.Id;
                        model.DescricaoMenu = item.Nome;
                        model.Status = item.Status;

                        if (pp.ObterMenus(p.Id).Where(x => x.Id.Equals(item.Id)).Count() > 0)
                        {
                            model.Selecionado = "checked";
                        }
                        listaModel.Add(model);
                    }
                }

                var Resultado = new
                {
                    aaData = listaModel
                };
                return Json(Resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Incluir(PerfilMenuViewModelInclusao model)
        {
            try
            {
                if (model.NomePerfil == null)
                {
                    throw new Exception("O nome do perfil deve ser informado");
                }

                PerfilPersistence pp = new PerfilPersistence();

                if (pp.ObterPorDescricao(model.NomePerfil).Count() > 0)
                {
                    throw new Exception("Este perfil já existe");
                }

                if (model.IdMenus == null)
                {
                    throw new Exception("Pelo menos um item de menu deverá ser selecionado");
                }

                Perfil p = new Perfil();
                p.Descricao = model.NomePerfil;

                //MenuPersistence mp = new MenuPersistence();                
                //List<Menu> lista = new List<Menu>();
                //foreach (var item in model.IdMenus)
                //{
                //    lista.Add(mp.ObterMenuPorId(item));
                //}

                //para pegar o menu, deverá ser feito dentro do mesmo context..
                //daí se passa o list de códigos do menu para pegar os objetos de cada menu através de um único context..
                pp.InserirPerfilMenu(p, model.IdMenus);
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
            List<PerfilViewModelConsulta> lista = new List<PerfilViewModelConsulta>();
            try
            {
                PerfilPersistence pp = new PerfilPersistence();
                foreach (var item in pp.ListarTodos().ToList())
                {
                    PerfilViewModelConsulta p = new PerfilViewModelConsulta();
                    p.Id = item.Id;
                    p.Descricao = item.Descricao;
                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoverMenu(int idPerfil, int idMenu)
        {
            try
            {
                PerfilPersistence pp = new PerfilPersistence();
                Perfil p = pp.ObterPorId(idPerfil);

                MenuPersistence mp = new MenuPersistence();
                Menu m = mp.ObterPorId(idMenu);

                pp.RemoverMenu(p, m);

            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Json("Item de menu removido com sucesso", JsonRequestBehavior.AllowGet);
        }

        private void ListarMenus(PerfilMenuViewModelConsulta model)
        {
            try
            {
                MenuPersistence mp = new MenuPersistence();
                List<Menu> listaMenu = mp.ListarTableMenus();

                foreach (var item in listaMenu)
                {
                    if (item.IdMenu > 0)
                    {
                        MenuViewModelSelecionaEdicao menu = new MenuViewModelSelecionaEdicao()
                        {
                            Id = item.Id,
                            Descricao = item.Nome
                        };
                        model.Menus.Add(menu);
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}