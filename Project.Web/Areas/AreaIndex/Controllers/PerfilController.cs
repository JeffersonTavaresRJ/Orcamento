using Project.Repository.Persistence;
using Project.Web.Areas.AreaIndex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project.Entity;
using Project.Entity.Enuns;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        int cod = 0;
        string mensagem;

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
        public JsonResult Excluir(int idPerfil)
        {
            try
            {
                if (idPerfil > 0)
                {
                    PerfilPersistence pp = new PerfilPersistence();

                    int qtdeUsuarios = pp.ObterUsuarios(idPerfil).Count();

                    if (qtdeUsuarios > 0)
                    {
                        mensagem = "Existe(m) " + qtdeUsuarios + " usuário(s) associados ao perfil a ser excluído. Operação cancelada";
                    }
                    else
                    {
                        Perfil p = pp.ObterPorId(idPerfil);
                        List<Menu> listaMenu = pp.ObterMenus(idPerfil).ToList();

                        foreach (Menu menu in listaMenu)
                        {
                            pp.RemoverMenu(p, menu);
                        }

                        pp.Excluir(p);
                        cod = 1;
                        mensagem = "Perfil " + p.Descricao + " excluído com sucesso.";
                    }

                }
                else
                {
                    mensagem = "O perfil deve ser selecionado";
                }
            }
            catch (Exception e)
            {
                mensagem = "Erro:  " + e.Message.ToString();
            }
            return Json(new { cod, msg = mensagem }, JsonRequestBehavior.AllowGet);
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

                    foreach (var menu in listaMenu.OrderBy(m => m.Nome))
                    {
                        MenuPerfilViewModelConsulta model = new MenuPerfilViewModelConsulta();
                        model.IdPerfil = p.Id;
                        model.IdMenu = menu.Id;
                        model.DescricaoMenu = menu.Nome;

                        if (menu.Status.Equals("A"))
                        {
                            model.Status = Status.A.ObterDescricao();
                        }
                        else if (menu.Status.Equals("I"))
                        {
                            model.Status = Status.I.ObterDescricao();
                        }
                        else
                        {
                            model.Status = "Valor Desconhecido";
                        }

                        if (pp.ObterMenus(p.Id).Where(x => x.Id.Equals(menu.Id)).Count() > 0)
                        {
                            model.Selecionado = "checked";
                        }

                        listaModel.Add(model);
                    }
                }
                var Resultado = new { aaData = listaModel };

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

        [HttpPost]
        public JsonResult EditarPerfilMenus(PerfilMenuViewModelEdicao model)
        {
            try
            {
                if (model.Menus.Count == 0)
                {
                    throw new Exception("Deve existir pelo menos um item de menu cadastrado para o perfil");
                }

                PerfilPersistence pp = new PerfilPersistence();
                MenuPersistence mp = new MenuPersistence();

                Perfil p = pp.ObterPorId(model.IdPerfil);

                List<Menu> listaMenu = pp.ObterMenus(model.IdPerfil).ToList();

                //exclui todos os menus..
                foreach (var m in listaMenu)
                {
                    pp.RemoverMenu(p, m);
                }

                //inclui os menus que estão com o checkbox na tela..
                foreach (var idMenu in model.Menus)
                {
                    pp.IncluiMenu(model.IdPerfil, idMenu);
                }               

                cod = 1;
                mensagem = "Perfil editado com sucesso";

            }
            catch (Exception e)
            {
                mensagem = e.Message.ToString();
            }

            return Json(new { cod, msg = mensagem }, JsonRequestBehavior.AllowGet);

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