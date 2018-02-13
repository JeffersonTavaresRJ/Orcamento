using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Web.Models.Usuario;
using Project.Entity;
using Project.Repository.Persistence;

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
                    u = up.ObterLoginSenha(usuarioModel.Login, usuarioModel.Senha);
                    if(u != null)
                    {
                        TempData["Usuario"] = "Olá, " + u.Nome;
                        return RedirectToAction("Consulta", "Index");
                    }

                    ViewBag.Mensagem = "Usuário Inválido";      
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
                        Senha = usuarioModel.Senha
                    };

                    if (up.LoginExistente(u.IdUsuario) > 0)
                    {
                        throw new Exception("Login já existe!");
                    }

                    up.Inserir(u);

                    ViewBag.Mensagem = String.Format("O usuário {0} foi cadastrado com sucesso!", u.Nome);
                }
            }
            catch (Exception ex)
            {

                ViewBag.Mensagem = "Erro: " + ex.Message.ToString();
            }

            return View("Cadastro");
        }
    }
}