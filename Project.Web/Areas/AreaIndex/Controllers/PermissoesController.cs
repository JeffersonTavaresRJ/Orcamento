using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project.Entity;
using Project.Repository.Persistence;
using Project.Entity.Enuns;
using Project.Utility.UtilComboBox;
using Project.Web.Areas.AreaIndex.Models;
using Project.Web.Models.Usuario;
using Project.Utility.UtilString;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class PermissoesController : Controller
    {
        public ActionResult Consulta()
        {
            PerfilPersistence pp = new PerfilPersistence();

            List<Perfil> listPerfil = pp.ListarTodos().ToList();
            listPerfil.Add(new Perfil { IdPerfil = -1, Descricao = "--Selecione--" });

            ViewBag.ListaPerfis = new SelectList(listPerfil.OrderBy(p => p.IdPerfil), "IdPerfil", "Descricao", -1);
            ViewBag.ListaStatus = new SelectList(Combobox.Listar(typeof(Status)), "Key", "Value");

            return View();
        }

        public ActionResult Listar(PermissoesViewModelFiltro model)
        {

            UsuarioPersistence up = new UsuarioPersistence();

            IEnumerable<Usuario> usuarios = null;

            if (model.Busca != null)
            {
                usuarios = up.ListarTodos().Where(u => u.IdUsuario.Contains(model.Busca) || u.Nome.Contains(model.Busca))
                                           .OrderBy(u => u.IdUsuario);
            }

            if (model.IdPerfil > 0)
            {
                if (usuarios == null)
                {
                    usuarios = up.ListarTodos().OrderBy(u => u.IdUsuario);
                }
                usuarios = usuarios.Where(u => u.IdPerfil.Equals(model.IdPerfil));
            }

            if (model.IdStatus != "-1" && model.IdStatus != null)
            {
                if (usuarios == null)
                {
                    usuarios = up.ListarTodos().OrderBy(u => u.IdUsuario);
                }
                usuarios = usuarios.Where(u => u.Status.Equals(model.IdStatus == Convert.ToString(-1) ? "" : model.IdStatus));
            }
            return PartialView("Usuarios", usuarios);
        }


        public ActionResult Cadastro(string id)
        {
            PerfilPersistence pp = new PerfilPersistence();
            ViewBag.ListaPerfis = pp.ListarTodos();

            UsuarioPersistence up = new UsuarioPersistence();
            UsuarioViewModelCadastro model = new UsuarioViewModelCadastro();

            if (id == null)
            {
                model.Acao = "I";
            }
            else
            {
                var usuario = up.ObterPorId(id);
                model.Acao = "E";
                model.Id_Usuario = usuario.IdUsuario;
                model.Nome = usuario.Nome;
                model.IdPerfil = usuario.IdPerfil;
                model.Senha = usuario.Senha;
                model.ConfirmaSenha = usuario.Senha;
            }

            return View(model);
        }

        public ActionResult Salvar(UsuarioViewModelCadastro usuarioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioPersistence up = new UsuarioPersistence();
                    PerfilPersistence pp = new PerfilPersistence();

                    Usuario u = new Usuario();
                    u.IdUsuario = usuarioModel.Id_Usuario;
                    u.Nome = usuarioModel.Nome;
                    u.Senha = Criptografia.EncriptarSenha(usuarioModel.Senha);
                    u.IdPerfil = usuarioModel.IdPerfil;

                    if (usuarioModel.Acao.Equals("I"))
                    {
                        if (up.LoginExistente(u.IdUsuario) > 0)
                        {
                            return Json(new { mensagem = "O Login informado já existe" }, JsonRequestBehavior.AllowGet);
                        }
                        up.Inserir(u);

                        //após inserir, a tela deve ser fechada
                        ModelState.Clear();//limpa os campos da tela
                    }
                    else
                    {
                        up.Atualizar(u);
                    }
                    return Json(new { mensagem = $"Os dados do Usuário {u.Nome} foram salvos com sucesso." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { mensagem = ex.Message.ToString() });
            }

            return Json(null);
        }




    }
}