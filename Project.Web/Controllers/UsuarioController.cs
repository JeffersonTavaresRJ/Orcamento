using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Web.Models.Usuario;
using Project.Entity;
using Project.Repository.Persistence;
using System.Web.Security;
using Project.Utility.UtilString;

namespace Project.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            PerfilPersistence pp = new PerfilPersistence();

            ViewBag.ListaPerfis = pp.ListarTodos();
            return View();
        }

        [HttpPost]
        public ActionResult AcessarSistema(UsuarioViewModelLogin usuarioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioPersistence up = new UsuarioPersistence();
                    Usuario u = new Usuario();
                    u = up.ObterLoginSenha(usuarioModel.Login,
                                        Criptografia.EncriptarSenha(usuarioModel.Senha));

                    if (u != null)
                    {
                        if (u.Status.Equals("I"))
                        {
                            throw new Exception("Usuário Inativado." + "\n" + "Procure o Administrador do Sistema");

                        }

                        //criando o tícket para dar acesso a aplicação..
                        FormsAuthenticationTicket ticket =
                            new FormsAuthenticationTicket(u.IdUsuario, false, 5);//cinco minutos de inatividade, retorna ao login..

                        //gravando o ticket em cookie do navegador..
                        HttpCookie cookie =
                            new HttpCookie(FormsAuthentication.FormsCookieName,
                                            FormsAuthentication.Encrypt(ticket));

                        //Gravando o cookie no navegador..
                        Response.Cookies.Add(cookie);

                        //gravando o objeto Usuario em sessão..
                        Session.Add("Usuario", u);


                        return RedirectToAction("Consulta", "Lancamento",
                            new { area = "AreaIndex" });
                    }

                    ViewBag.Mensagem = "Usuário/Senha Inválido";
                }
            }
            catch (Exception ex)
            {

                ViewBag.Mensagem = "Erro: " + ex.Message.ToString();
            }

            return View("Login");


        }

        [HttpPost]
        public ActionResult Novo(UsuarioViewModelCadastro usuarioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioPersistence up = new UsuarioPersistence();
                    Usuario u = new Usuario
                    {
                        IdUsuario = usuarioModel.Id_Usuario,
                        Nome = usuarioModel.Nome,
                        Senha = Criptografia.EncriptarSenha(usuarioModel.Senha),
                        IdPerfil = usuarioModel.IdPerfil

                    };

                    if (up.LoginExistente(u.IdUsuario) > 0)
                    {
                        return Json(new { mensagem = "O Login informado já existe" }, JsonRequestBehavior.AllowGet);
                    }

                    up.Inserir(u);
                    ModelState.Clear();//limpa os campos da tela

                    return Json(new { mensagem = $"Usuário {u.Nome} cadastrado com sucesso." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { mensagem = ex.Message.ToString() });
            }

            return Json(null);
        }


        public ActionResult Logout()
        {
            //destrói o tícket de acesso do usuário..
            FormsAuthentication.SignOut();

            //apaga a sessão do usuário..
            Session.Remove("Usuario");

            return RedirectToAction("Login", "Usuario", new { area = "" });

        }
    }
}