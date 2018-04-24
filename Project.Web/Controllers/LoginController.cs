﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Entity;
using Project.Repository.Persistence;
using System.Web.Security;
using Project.Utility.UtilString;
using Project.Web.Models.Login;

namespace Project.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AcessarSistema(LoginViewModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioPersistence up = new UsuarioPersistence();
                    Usuario u = new Usuario();
                    u = up.ObterLoginSenha(loginModel.Login,
                                        Criptografia.EncriptarSenha(loginModel.Senha));

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


        public ActionResult Logout()
        {
            //destrói o tícket de acesso do usuário..
            FormsAuthentication.SignOut();

            //apaga a sessão do usuário..
            Session.Remove("Usuario");

            return RedirectToAction("Login", "Login", new { area = "" });

        }
    }
}